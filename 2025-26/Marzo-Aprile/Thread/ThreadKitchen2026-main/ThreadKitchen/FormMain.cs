using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ThreadKitchen
{
    public partial class FormMain : Form
    {
        // Lista cuochi (struttura dati)
        private List<Chef> _chefs;

        // Array di comodo per accedere ai controlli per indice nel codice
        private readonly Label[]       _lblChef;
        private readonly ProgressBar[] _pbChef;
        private readonly Label[]       _lblPercChef;

        // Generatore di numeri casuali condiviso.
        // ⚠️  Random NON è thread-safe: chiamate concorrenti da più thread possono
        // corromperne lo stato interno e restituire sempre 0. In questo progetto
        // l'effetto è trascurabile (al più incrementi uniformi), ma in produzione
        // ogni thread dovrebbe usare una propria istanza di Random.
        private readonly Random _rnd = new Random();

        // Contatore soggetto a race condition: incrementato in modo NON atomico
        private int _totalSteps = 0;

        // Contatore di riferimento: incrementato in modo atomico con Interlocked
        private int _expectedSteps = 0;

        // Oggetto usato come mutex per i blocchi lock: un'unica istanza condivisa
        // da tutti i thread garantisce l'accesso esclusivo alle sezioni critiche
        private readonly object _lockObj = new object();

        // Id del primo cuoco che ha raggiunto Progress == 100 (-1 = nessuno ancora)
        private int _firstFinished = -1;

        // ── Fornelli (risorsa limitata) ──────────────────────────────────────────
        // SemaphoreSlim è un semaforo leggero ottimizzato per scenari in-process.
        // Differisce da lock in un aspetto fondamentale: lock consente l'accesso
        // a UN solo thread alla volta, mentre SemaphoreSlim consente l'accesso
        // a N thread contemporaneamente (qui N = 2, i fornelli disponibili).
        // Il primo parametro è il numero di accessi inizialmente consentiti,
        // il secondo è il massimo assoluto: entrambi 2 perché partiamo con
        // entrambi i fornelli liberi e non vogliamo mai superare quel limite.
        private SemaphoreSlim _semFornelli = new SemaphoreSlim(2, 2);

        // Sorgente del token di cancellazione: viene creata a ogni avvio e annullata
        // al Reset. CancellationToken è preferibile a Thread.Abort perché:
        //   - Thread.Abort è deprecato (.NET Core lo ha rimosso del tutto) e lancia
        //     ThreadAbortException in un punto imprevedibile del codice, rendendo
        //     difficile rilasciare risorse in modo ordinato;
        //   - CancellationToken è cooperativo: il thread controlla esplicitamente il
        //     flag e termina in un punto sicuro, lasciando tutto in stato consistente.
        private CancellationTokenSource _cts;

        public FormMain()
        {
            InitializeComponent();

            // Raccoglie i controlli nominali del Designer in array
            // così il resto del codice può usare _lblChef[i], _pbChef[i], ecc.
            _lblChef     = new Label[]       { lblChef0,     lblChef1,     lblChef2,     lblChef3     };
            _pbChef      = new ProgressBar[] { pbChef0,      pbChef1,      pbChef2,      pbChef3      };
            _lblPercChef = new Label[]       { lblPercChef0, lblPercChef1, lblPercChef2, lblPercChef3 };
        }

        // ── Caricamento form ─────────────────────────────────────────────────────
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Carica i cuochi predefiniti e aggiorna la UI
            _chefs = Chef.GetDefaultChefs();
            ImpostaLabelCuochi();
            AggiornaCuochi();

            AppendLog("🍳 Cucina pronta. Premi «Avvia cucina» per iniziare.");
        }

        // ── Metodo eseguito dal thread — simula la cottura di un piatto ──────────
        private void CookDish(int chefId, CancellationToken token)
        {
            // Il try/catch è indispensabile nei thread secondari: qualsiasi eccezione
            // non gestita in un thread diverso dall'UI causa la terminazione dell'intera
            // applicazione senza messaggi d'errore comprensibili. Il catch permette di
            // intercettare il problema, loggarlo e lasciare gli altri thread in esecuzione.
            try
            {
                Chef chef = _chefs[chefId];

                // Avvia il cronometro per misurare il tempo totale di cottura
                Stopwatch sw = Stopwatch.StartNew();

                // Soglia casuale tra 30% e 50% a cui il cuoco inizierà a usare il fornello,
                // e fine casuale tra soglia+25% e soglia+30% (max 80%) in cui lo libera.
                // Ogni cuoco ha tempi diversi: la contesa sul semaforo è meno prevedibile
                // e più simile a uno scenario reale rispetto a una soglia fissa uguale per tutti.
                int sogliaPrendiFornello = _rnd.Next(30, 51);
                int sogliaLasciaFornello = Math.Min(sogliaPrendiFornello + _rnd.Next(25, 31), 80);

                // ── Fase 1: avanzamento da 0 alla soglia casuale ────────────────────
                // Il cuoco prepara gli ingredienti: la progress bar avanza liberamente
                // senza alcuna contesa su risorse condivise.
                while (chef.Progress < sogliaPrendiFornello)
                {
                    if (token.IsCancellationRequested)
                        return;

                    Thread.Sleep(_rnd.Next(100, 501));

                    if (token.IsCancellationRequested)
                        return;

                    int incremento = _rnd.Next(1, 9);
                    chef.Progress = Math.Min(chef.Progress + incremento, sogliaPrendiFornello);

                    int progressoCorrente = chef.Progress;
                    Invoke(new Action(() =>
                    {
                        _pbChef[chefId].Value     = progressoCorrente;
                        _lblPercChef[chefId].Text = progressoCorrente + "%";
                    }));

                    IncrementaPassi(incremento);
                }

                // ── Fase 2: uso del fornello ─────────────────────────────────────────
                // Questo pattern (acquire → use → release in finally) è lo stesso
                // usato ovunque si gestiscano risorse limitate: connessioni a database,
                // file handle, slot in un pool di oggetti. La forma cambia (using,
                // SemaphoreSlim, lock...) ma la struttura è sempre la stessa.
                if (token.IsCancellationRequested)
                    return;

                AppendLog("⏳ " + chef.Name + " aspetta un fornello...");

                // Wait(token) si blocca finché uno dei 2 slot del semaforo è libero.
                // Passare il token è essenziale: se l'utente preme Reset mentre
                // il cuoco è in attesa, Wait lancia OperationCanceledException
                // che viene catturata dal catch esterno — senza token il thread
                // rimarrebbe bloccato per sempre su Wait() ignorando il Reset.
                //
                // 📌 NOTA DIDATTICA: i cuochi in coda qui appaiono fermi alla loro
                // soglia casuale (tra 30% e 50%): ognuno si blocca in un punto diverso,
                // rendendo la contesa visivamente più realistica di una soglia fissa.
                _semFornelli.Wait(token);

                try
                {
                    int inUso = 2 - _semFornelli.CurrentCount;
                    AppendLog("🔥 " + chef.Name + " ha il fornello, inizia la cottura (in uso: " + inUso + " / 2)");

                    Invoke(new Action(() =>
                    {
                        lblFornelli.Text      = "Fornelli in uso: " + inUso + " / 2";
                        lblFornelli.ForeColor = System.Drawing.Color.Lime;
                    }));

                    // La cottura sul fornello avanza la progress bar a scatti fino
                    // alla soglia di fine fornello (casuale, max 80%): il cuoco
                    // è visivamente attivo anche mentre usa la risorsa.
                    while (chef.Progress < sogliaLasciaFornello)
                    {
                        if (token.IsCancellationRequested)
                            return;

                        Thread.Sleep(_rnd.Next(300, 801));

                        if (token.IsCancellationRequested)
                            return;

                        int inc = _rnd.Next(1, 6);
                        chef.Progress = Math.Min(chef.Progress + inc, sogliaLasciaFornello);

                        int prog = chef.Progress;
                        Invoke(new Action(() =>
                        {
                            _pbChef[chefId].Value     = prog;
                            _lblPercChef[chefId].Text = prog + "%";
                        }));

                        IncrementaPassi(inc);
                    }
                }
                finally
                {
                    // Release va nel finally e NON dopo il try: se il thread
                    // venisse interrotto (eccezione, cancellazione) durante
                    // il while interno, il fornello verrebbe liberato comunque.
                    // Senza finally un'eccezione lascerebbe il semaforo
                    // decrementato per sempre, bloccando gli altri thread.
                    _semFornelli.Release();

                    int inUsoDopo = 2 - _semFornelli.CurrentCount;
                    AppendLog("⬛ " + chef.Name + " libera il fornello (in uso: " + inUsoDopo + " / 2)");

                    // ⚠️  Invoke in un finally è corretto, ma se l'utente chiude
                    // la finestra mentre questo finally è in esecuzione, Invoke
                    // può lanciare ObjectDisposedException. Con IsBackground=true
                    // il sistema operativo termina il thread alla chiusura del
                    // processo, quindi in pratica non è un problema per questa demo.
                    Invoke(new Action(() =>
                    {
                        lblFornelli.Text      = "Fornelli in uso: " + inUsoDopo + " / 2";
                        lblFornelli.ForeColor = System.Drawing.Color.Lime;
                    }));
                }

                // ── Fase 3: avanzamento dalla soglia di fine fornello al 100% ────────
                // Il cuoco impiatta: torna ad avanzare liberamente dopo aver rilasciato
                // il fornello. La progress bar riprende a muoversi al ritmo normale.
                while (chef.Progress < 100)
                {
                    if (token.IsCancellationRequested)
                        return;

                    Thread.Sleep(_rnd.Next(100, 501));

                    if (token.IsCancellationRequested)
                        return;

                    int incremento2 = _rnd.Next(1, 9);
                    chef.Progress = Math.Min(chef.Progress + incremento2, 100);

                    int progressoCorrente2 = chef.Progress;
                    Invoke(new Action(() =>
                    {
                        _pbChef[chefId].Value     = progressoCorrente2;
                        _lblPercChef[chefId].Text = progressoCorrente2 + "%";
                    }));

                    IncrementaPassi(incremento2);
                }

                // Cottura completata: registra il tempo e imposta il flag
                sw.Stop();
                chef.ElapsedSeconds = sw.Elapsed.TotalSeconds;
                chef.IsFinished     = true;

                // Sezione critica: controlla e assegna _firstFinished.
                // Il lock è necessario perché due thread potrebbero terminare quasi
                // contemporaneamente e leggere entrambi _firstFinished == -1 prima
                // che uno dei due abbia avuto modo di aggiornarlo (stessa race condition
                // del contatore, ma applicata alla dichiarazione del vincitore).
                lock (_lockObj)
                {
                    if (_firstFinished == -1)
                    {
                        _firstFinished = chefId;

                        // Cattura i valori per la lambda: dentro Invoke siamo sul thread UI,
                        // ma i dati del cuoco appartengono al thread worker — meglio copiarli ora
                        string nomeVincitore   = chef.Name;
                        string piattoVincitore = chef.Dish;

                        // Invoke: lblWinner è un controllo UI, va toccato solo sul thread UI
                        Invoke(new Action(() =>
                        {
                            lblWinner.Text      = "\uD83C\uDFC6 Primo piatto pronto: " + nomeVincitore + " con " + piattoVincitore + "!";
                            lblWinner.ForeColor = System.Drawing.Color.Gold;
                        }));
                    }
                }

                // Notifica nel log — AppendLog usa Invoke internamente, è thread-safe
                AppendLog("\u2705 " + chef.Name + " ha finito \u00ab" + chef.Dish + "\u00bb in " +
                          chef.ElapsedSeconds.ToString("F1") + "s");
            }
            catch (OperationCanceledException)
            {
                // Cancellazione esplicita richiesta dal Reset: non è un errore,
                // il thread termina semplicemente senza loggare nulla
            }
            catch (Exception ex)
            {
                // Errore imprevisto: lo logghiamo con il nome del cuoco così
                // l'utente capisce quale thread ha avuto problemi
                AppendLog("\u274C Errore in " + _chefs[chefId].Name + ": " + ex.Message);
            }
        }

        // ── Pulsante Avvia ───────────────────────────────────────────────────────
        private void BtnAvvia_Click(object sender, EventArgs e)
        {
            // Disabilita il pulsante Start ed abilita Reset durante la cottura
            btnAvvia.Enabled = false;
            btnReset.Enabled = true;

            // Crea un nuovo CancellationTokenSource a ogni avvio: se l'utente
            // ha già eseguito un Reset in precedenza, il vecchio _cts è già annullato
            // e va sostituito con uno fresco prima di lanciare i nuovi thread
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            AppendLog("▶ La cucina è aperta — " + _chefs.Count + " cuochi al lavoro!");

            // Avvia un thread separato per ciascun cuoco
            for (int i = 0; i < _chefs.Count; i++)
            {
                // ⚠️  Variabile locale necessaria: senza di essa tutti i thread
                // catturerebbero lo stesso riferimento a 'i' e leggerebbero il
                // valore finale del loop (closure su variabile del loop).
                int id = i;

                // Background thread: termina automaticamente alla chiusura della form
                Thread t = new Thread(() => CookDish(id, token))
                {
                    IsBackground = true,
                    Name         = "Thread-" + _chefs[id].Name
                };

                t.Start();

                AppendLog("🍳 " + _chefs[id].Name + " ha iniziato a cucinare «" + _chefs[id].Dish + "»");
            }
        }

        // ── Pulsante Reset ───────────────────────────────────────────────────────
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Segnala a tutti i thread di fermarsi: ciascuno controllerà
            // token.IsCancellationRequested all'inizio della prossima iterazione
            // e uscirà in modo pulito, senza eccezioni né stati inconsistenti
            _cts?.Cancel();

            // Riporta tutti i cuochi al loro stato iniziale
            foreach (Chef chef in _chefs)
            {
                chef.Progress        = 0;
                chef.IsFinished      = false;
                chef.ElapsedSeconds  = 0;
            }

            // Azzera tutte le ProgressBar e le label percentuale tramite gli array
            for (int i = 0; i < _pbChef.Length; i++)
            {
                _pbChef[i].Value     = 0;
                _lblPercChef[i].Text = "0%";
            }

            // Ripristina lo stato dei pulsanti
            btnReset.Enabled = false;
            btnAvvia.Enabled = true;

            // Azzera i contatori dentro lo stesso lock usato dai thread worker:
            // in questo modo nessun thread può leggere un valore parzialmente azzerato
            lock (_lockObj)
            {
                _totalSteps    = 0;
                _expectedSteps = 0;

                // Azzera il vincitore: -1 significa "nessuno ha ancora finito"
                _firstFinished = -1;
            }

            // Ricrea il semaforo con entrambi i fornelli liberi.
            // Non esiste un metodo Reset() su SemaphoreSlim: la riassegnazione
            // è il modo idiomatico per riportarlo allo stato iniziale.
            // Non chiamiamo Dispose() sul vecchio semaforo: al momento del Reset
            // potrebbero esserci thread in attesa su Wait(token) che non hanno
            // ancora processato la cancellazione; un Dispose() prematuro
            // causerebbe ObjectDisposedException invece della attesa
            // OperationCanceledException, sfuggendo al catch corretto.
            // SemaphoreSlim senza handle kernel non ha risorse native urgenti
            // da rilasciare: il GC gestirà la pulizia in modo sicuro.
            _semFornelli = new SemaphoreSlim(2, 2);

            lblSteps.Text       = "Atteso: 0   Reale: 0";
            lblSteps.ForeColor  = System.Drawing.Color.Lime;
            lblWinner.Text      = "";
            lblWinner.ForeColor = System.Drawing.Color.Gainsboro;
            lblFornelli.Text      = "Fornelli in uso: 0 / 2";
            lblFornelli.ForeColor = System.Drawing.Color.Lime;

            rtbLog.Clear();
            AppendLog("↺ Reset eseguito. La cucina è pronta per un nuovo turno.");
        }

        // ── Metodi di supporto UI ────────────────────────────────────────────────

        /// <summary>
        /// Imposta il testo delle label con nome e piatto di ogni cuoco.
        /// Chiamato una sola volta al caricamento.
        /// </summary>
        private void ImpostaLabelCuochi()
        {
            string[] icone = { "👨‍🍳", "👩‍🍳", "👨‍🍳", "👩‍🍳" };

            for (int i = 0; i < _chefs.Count; i++)
            {
                _lblChef[i].Text = icone[i] + " " + _chefs[i].Name + " — " + _chefs[i].Dish;
            }
        }

        /// <summary>
        /// Aggiorna le ProgressBar e le label percentuale in base
        /// allo stato corrente di ogni cuoco.
        /// </summary>
        private void AggiornaCuochi()
        {
            for (int i = 0; i < _chefs.Count; i++)
            {
                _pbChef[i].Value     = _chefs[i].Progress;
                _lblPercChef[i].Text = _chefs[i].Progress + "%";
            }
        }

        // ── Race condition didattica ─────────────────────────────────────────────

        /// <summary>
        /// Incrementa _totalSteps in tre passi volutamente separati e lenti,
        /// causando una race condition osservabile quando più thread chiamano
        /// questo metodo contemporaneamente.
        /// ⚠️  IMPLEMENTAZIONE VOLUTAMENTE SCORRETTA A SCOPO DIDATTICO:
        ///     l'operazione di lettura-modifica-scrittura NON è atomica;
        ///     il Thread.Sleep(1) amplifica la finestra temporale in cui
        ///     un altro thread può sovrascrivere il valore letto da questo.
        /// </summary>
        private void IncrementaPassi(int step)
        {
            // lock(_lockObj) garantisce che un solo thread alla volta esegua i tre
            // passi di lettura-modifica-scrittura su _totalSteps: nessun altro thread
            // può interrompere questa sequenza, eliminando la race condition.
            lock (_lockObj)
            {
                // Passo 1: legge il valore corrente in una variabile temporanea
                int temp = _totalSteps;

                // Passo 2: pausa artificiale — con il lock non crea più problemi,
                // ma la manteniamo per mostrare che il lock protegge anche sezioni lente
                Thread.Sleep(1);

                // Passo 3: riscrive il campo con il valore incrementato.
                // Grazie al lock nessun altro thread può aver modificato _totalSteps
                // tra il Passo 1 e questo: il lost update è impossibile.
                _totalSteps = temp + step;
            }

            // Interlocked.Add è già atomico per definizione: non ha bisogno del lock
            Interlocked.Add(ref _expectedSteps, step);

            // Cattura i valori per la lambda (evita letture instabili nella closure)
            int atteso = _expectedSteps;
            int reale  = _totalSteps;

            // Aggiorna la label sul thread UI
            Invoke(new Action(() =>
            {
                lblSteps.Text = "Atteso: " + atteso + "   Reale: " + reale;

                // Con il lock attivo i due valori coincidono sempre: lblSteps
                // rimane sempre verde. Il verde persistente è la dimostrazione
                // visiva che il lock ha eliminato la race condition.
                lblSteps.ForeColor = (atteso != reale)
                    ? System.Drawing.Color.Red
                    : System.Drawing.Color.Lime;
            }));
        }

        /// <summary>
        /// Aggiunge una riga con timestamp al log attività in modo thread-safe.
        /// Usa Invoke per garantire che l'accesso a rtbLog avvenga sempre
        /// sul thread UI, indipendentemente da chi chiama questo metodo.
        /// </summary>
        private void AppendLog(string messaggio)
        {
            // InvokeRequired è true quando il metodo viene chiamato da un thread
            // diverso da quello che ha creato il controllo (il thread UI).
            if (rtbLog.InvokeRequired)
            {
                // Rimanda l'esecuzione al thread UI tramite Invoke
                Invoke(new Action(() => AppendLog(messaggio)));
                return;
            }

            rtbLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + messaggio + Environment.NewLine);
            rtbLog.ScrollToCaret();
        }
    }
}
