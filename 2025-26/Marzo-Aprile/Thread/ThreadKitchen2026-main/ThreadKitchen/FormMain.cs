using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ThreadKitchen
{
    public partial class FormMain : Form
    {
        // Lista dei cuochi
        private List<Chef> _chefs;

        // Array paralleli ai controlli del Designer: permettono di accedere
        // a label e progress bar per indice invece che per nome.
        private readonly Label[]       _lblChef;
        private readonly ProgressBar[] _pbChef;
        private readonly Label[]       _lblPercChef;

        // ⚠️ Random NON è thread-safe: in produzione ogni thread dovrebbe avere
        // la propria istanza. Qui l'effetto è trascurabile a scopo didattico.
        private readonly Random _rnd = new Random();

        // _totalSteps: incrementato in modo NON atomico → soggetto a race condition.
        // _expectedSteps: incrementato con Interlocked.Add → sempre corretto.
        // Il confronto tra i due rende la race condition visibile su lblSteps.
        private int _totalSteps    = 0;
        private int _expectedSteps = 0;

        // Mutex condiviso tra tutti i thread per le sezioni critiche.
        private readonly object _lockObj = new object();

        // Id del primo cuoco che ha completato il piatto (-1 = nessuno ancora).
        private int _firstFinished = -1;

        // Semaforo con 2 slot: modella i 2 fornelli disponibili.
        // A differenza di lock (1 thread alla volta), SemaphoreSlim ammette N thread
        // contemporaneamente. I parametri (2, 2) = slot iniziali e massimo assoluto.
        private SemaphoreSlim _semFornelli = new SemaphoreSlim(2, 2);

        // Sorgente del token di cancellazione, ricreata a ogni avvio.
        // CancellationToken è preferibile a Thread.Abort perché cooperativo:
        // il thread decide lui quando uscire, in un punto sicuro del codice.
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public FormMain()
        {
            InitializeComponent();

            // Raccoglie i controlli del Designer in array indicizzati per cuoco.
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
            // Il try/catch è indispensabile nei thread secondari: un'eccezione non
            // gestita qui terminerebbe l'intera applicazione. Il catch la intercetta,
            // la logga e lascia gli altri thread in esecuzione.
            try
            {
                Chef chef = _chefs[chefId];
                Stopwatch sw = Stopwatch.StartNew();

                // Soglie casuali e diverse per ogni cuoco: la contesa sui fornelli
                // avviene in momenti imprevedibili, come in uno scenario reale.
                int sogliaPrendiFornello = _rnd.Next(30, 51);
                int sogliaLasciaFornello = Math.Min(sogliaPrendiFornello + _rnd.Next(25, 31), 80);

                // ── Fase 1: preparazione ingredienti (0% → soglia) ──────────────
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
                    // Invoke: i controlli UI appartengono al thread UI, non al worker.
                    Invoke(new Action(() =>
                    {
                        _pbChef[chefId].Value     = progressoCorrente;
                        _lblPercChef[chefId].Text = progressoCorrente + "%";
                    }));

                    IncrementaPassi(incremento);
                }

                // ── Fase 2: cottura sul fornello (soglia → sogliaLascia) ──────────
                // Pattern acquire → use → release in finally: lo stesso usato per
                // connessioni DB, file handle e qualsiasi risorsa limitata.
                if (token.IsCancellationRequested)
                    return;

                AppendLog("⏳ " + chef.Name + " aspetta un fornello...");

                // Riferimento locale: se il Reset ricrea _semFornelli mentre siamo
                // nel finally, Release() deve operare sull'istanza acquisita qui,
                // non su quella nuova (già piena), altrimenti causa overflow.
                SemaphoreSlim semCorrente = _semFornelli;

                // Wait(token): si blocca finché un fornello è libero.
                // Il token è essenziale: senza di esso Wait ignorerebbe il Reset
                // e il thread resterebbe bloccato per sempre.
                // 📌 I cuochi in attesa appaiono fermi ognuno alla propria soglia
                //    casuale: è la dimostrazione visiva della contesa sulla risorsa.
                semCorrente.Wait(token);

                try
                {
                    int inUso = 2 - semCorrente.CurrentCount;
                    AppendLog("🔥 " + chef.Name + " ha il fornello, inizia la cottura (in uso: " + inUso + " / 2)");
                    Invoke(new Action(() =>
                    {
                        lblFornelli.Text      = "Fornelli in uso: " + inUso + " / 2";
                        lblFornelli.ForeColor = System.Drawing.Color.Lime;
                    }));

                    // La barra avanza lentamente anche durante la cottura.
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
                    // Il log va scritto PRIMA di Release(): Release() sblocca
                    // immediatamente il thread in coda, che potrebbe loggare
                    // "ha il fornello" prima che questo finally scriva "libera".
                    // Il conteggio post-rilascio si calcola sottraendo 1 da CurrentCount
                    // (ancora non aggiornato) per mostrare il valore corretto.
                    int inUsoDopo = (2 - semCorrente.CurrentCount) - 1;

                    // Dopo un Reset il log e la UI vengono soppressi: messaggi
                    // di "libera fornello" successivi al reset sarebbero fuorvianti.
                    // Release() va eseguito comunque per non lasciare slot occupati.
                    if (!token.IsCancellationRequested)
                        AppendLog("⬛ " + chef.Name + " libera il fornello (in uso: " + inUsoDopo + " / 2)");

                    // Release nel finally garantisce che il fornello venga sempre
                    // liberato, anche in caso di eccezione o cancellazione.
                    semCorrente.Release();

                    if (!token.IsCancellationRequested)
                        Invoke(new Action(() =>
                        {
                            lblFornelli.Text      = "Fornelli in uso: " + inUsoDopo + " / 2";
                            lblFornelli.ForeColor = System.Drawing.Color.Lime;
                        }));
                }

                // ── Fase 3: impiattamento (sogliaLascia → 100%) ─────────────────
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

                sw.Stop();
                chef.ElapsedSeconds = sw.Elapsed.TotalSeconds;
                chef.IsFinished     = true;

                // lock necessario: due thread potrebbero leggere _firstFinished == -1
                // quasi contemporaneamente e dichiarare entrambi vincitori.
                lock (_lockObj)
                {
                    if (_firstFinished == -1)
                    {
                        _firstFinished = chefId;

                        // Variabili locali per la lambda: i dati del cuoco
                        // appartengono al thread worker, meglio copiarli prima di Invoke.
                        string nomeVincitore   = chef.Name;
                        string piattoVincitore = chef.Dish;
                        Invoke(new Action(() =>
                        {
                            lblWinner.Text      = "\uD83C\uDFC6 Primo piatto pronto: " + nomeVincitore + " con " + piattoVincitore + "!";
                            lblWinner.ForeColor = System.Drawing.Color.Gold;
                        }));
                    }
                }

                AppendLog("\u2705 " + chef.Name + " ha finito \u00ab" + chef.Dish + "\u00bb in " +
                          chef.ElapsedSeconds.ToString("F1") + "s");
            }
            catch (OperationCanceledException)
            {
                // Cancellazione richiesta dal Reset: uscita pulita, nessun log.
            }
            catch (Exception ex)
            {
                AppendLog("\u274C Errore in " + _chefs[chefId].Name + ": " + ex.Message);
            }
        }

        // ── Pulsante Avvia ───────────────────────────────────────────────────────
        private void BtnAvvia_Click(object sender, EventArgs e)
        {
            btnAvvia.Enabled = false;

            // Nuovo CancellationTokenSource a ogni avvio: quello precedente
            // è già annullato e non può essere riutilizzato.
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            AppendLog("▶ La cucina è aperta — " + _chefs.Count + " cuochi al lavoro!");

            for (int i = 0; i < _chefs.Count; i++)
            {
                // Variabile locale necessaria: senza di essa tutti i thread
                // catturerebbero lo stesso 'i' finale del loop (problema di closure).
                int id = i;

                Thread t = new Thread(() => CookDish(id, token))
                {
                    IsBackground = true,   // termina automaticamente alla chiusura della form
                    Name         = "Thread-" + _chefs[id].Name
                };

                t.Start();
                AppendLog("🍳 " + _chefs[id].Name + " ha iniziato a cucinare «" + _chefs[id].Dish + "»");
            }

            // Abilitato dopo il loop: il Reset è disponibile solo a tutti i thread avviati.
            btnReset.Enabled = true;
        }

        // ── Pulsante Reset ───────────────────────────────────────────────────────
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Segnala a tutti i thread di uscire al prossimo check del token.
            _cts?.Cancel();

            foreach (Chef chef in _chefs)
            {
                chef.Progress       = 0;
                chef.IsFinished     = false;
                chef.ElapsedSeconds = 0;
            }

            for (int i = 0; i < _pbChef.Length; i++)
            {
                _pbChef[i].Value     = 0;
                _lblPercChef[i].Text = "0%";
            }

            btnReset.Enabled = false;
            btnAvvia.Enabled = true;

            // I contatori vengono azzerati dentro lo stesso lock dei thread worker
            // per evitare che un thread legga un valore parzialmente azzerato.
            lock (_lockObj)
            {
                _totalSteps    = 0;
                _expectedSteps = 0;
                _firstFinished = -1;
            }

            // Non chiamiamo Dispose() sul vecchio semaforo: thread in transizione
            // dalla cancellazione potrebbero ancora essere nel finally e chiamare
            // Release(); Dispose() prematuro causerebbe ObjectDisposedException.
            // SemaphoreSlim non usa handle kernel: il GC gestirà la pulizia.
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
        /// Aggiorna _totalSteps in tre passi separati (leggi → sleep → scrivi).
        /// ⚠️ VOLUTAMENTE NON ATOMICO: senza lock il Thread.Sleep(1) allarga la
        /// finestra temporale in cui un altro thread può sovrascrivere il valore.
        /// Con il lock attivo i passi sono protetti: i due contatori coincidono
        /// sempre e lblSteps rimane verde — dimostrazione visiva del fix.
        /// </summary>
        private void IncrementaPassi(int step)
        {
            lock (_lockObj)
            {
                int temp = _totalSteps;  // Passo 1: lettura
                Thread.Sleep(1);         // Passo 2: pausa artificiale
                _totalSteps = temp + step; // Passo 3: scrittura
            }

            // Interlocked.Add è atomico: non ha bisogno del lock.
            Interlocked.Add(ref _expectedSteps, step);

            int atteso = _expectedSteps;
            int reale  = _totalSteps;

            Invoke(new Action(() =>
            {
                lblSteps.Text = "Atteso: " + atteso + "   Reale: " + reale;
                lblSteps.ForeColor = (atteso != reale)
                    ? System.Drawing.Color.Red
                    : System.Drawing.Color.Lime;
            }));
        }

        /// <summary>
        /// Aggiunge una riga al log in modo thread-safe tramite Invoke.
        /// </summary>
        private void AppendLog(string messaggio)
        {
            if (rtbLog.InvokeRequired)
            {
                Invoke(new Action(() => AppendLog(messaggio)));
                return;
            }
            rtbLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + messaggio + Environment.NewLine);
            rtbLog.ScrollToCaret();
        }
    }
}
