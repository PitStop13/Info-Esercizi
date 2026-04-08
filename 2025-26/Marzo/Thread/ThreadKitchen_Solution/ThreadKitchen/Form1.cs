using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ThreadKitchen
{
    public partial class Form1 : Form
    {
        // 1. I DATI DEL NOSTRO PROGRAMMA
        // Questa lista contiene le "schede" dei nostri cuochi.
        private List<Chef> _chefs = new List<Chef>();

        // Questi array (liste a dimensione fissa) ci permettono di gestire comodamente 
        // le etichette e le barre di caricamento della grafica usando un indice (es. da 0 a 3).
        private Label[] _lblChef;
        private ProgressBar[] _pbChef;
        private Label[] _lblPrecChef;

        // 2. IL GENERATORE DI NUMERI CASUALI (SICURO PER I THREAD)
        // Immagina che 'Random' sia un dado. Se due thread (i nostri cuochi) cercano di tirare 
        // lo stesso dado nello stesso istante, si scontrano e il risultato si rompe (generano numeri uguali o zero).
        // ThreadLocal significa: "Dai un dado personale e unico a ogni thread".
        private readonly ThreadLocal<Random> _threadRnd = new ThreadLocal<Random>(() =>
            new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));

        // 3. VARIABILI PER TESTARE I PROBLEMI DI CONCORRENZA (RACE CONDITION)
        private int _totalSteps = 0;    // Valore reale, lo proteggeremo con un lucchetto (lock)
        private int _expectedSteps = 0; // Valore atteso, lo proteggeremo con comandi atomici (Interlocked)

        // 4. IL LUCCHETTO (LOCK)
        // È come la chiave dell'unico bagno in un ristorante. Se un thread ha questa chiave,
        // entra e fa il suo lavoro. Gli altri thread devono aspettare in fila finché la chiave non viene restituita.
        private readonly object _lockObject = new object();

        // 5. STATO DELLA GARA E GESTIONE THREAD
        // Serve a sapere se qualcuno ha già tagliato il traguardo
        private bool _hasWinner = false;

        // Qui teniamo traccia di tutti i thread (i cuochi al lavoro) per poterli gestire
        private readonly List<Thread> _workerThreads = new List<Thread>();

        // 6. IL PULSANTE DI EMERGENZA (VOLATILE)
        // La parola 'volatile' è fondamentale qui. Dice al computer: "Attenzione, questa variabile
        // può essere cambiata in qualsiasi momento da qualcun altro. Non fare giochetti strani, 
        // leggila sempre fresca dalla memoria principale!".
        private volatile bool _cancellationRequested = false;

        public Form1()
        {
            InitializeComponent();

            // Raggruppo i controlli dell'interfaccia (che hai già disegnato nel form)
            // in questi array, così sarà facilissimo aggiornarli in un ciclo for.
            _lblChef = new Label[] { lblChef0, lblChef1, lblChef2, lblChef3 };
            _pbChef = new ProgressBar[] { pbChef0, pbChef1, pbChef2, pbChef3 };
            _lblPrecChef = new Label[] { lblPrecChef0, lblPrecChef1, lblPrecChef2, lblPrecChef3 };

            // AGGIUNTA: Diciamo al form di eseguire una funzione quando l'utente clicca la "X" per chiudere la finestra
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnStart.Enabled = true;

            _chefs = Chef.GetDefaultChefs();
            ImpostaLabelCuochi();
            AggiornaCuochi();

            lblVincitore.Text = "In attesa dell'inizio...";
            AppendLog("🍳 Cucina pronta. Premi «Avvia cucina» per iniziare.");
        }

        // AGGIUNTA: Gestiamo la chiusura della finestra in sicurezza
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Se l'utente chiude la finestra, urliamo ai cuochi (i thread) di fermarsi immediatamente
            _cancellationRequested = true;
        }

        // Questa funzione somma i "passi" di lavoro. Serve per dimostrare come far
        // collaborare più thread su una singola variabile senza fare disastri.
        private void IncrementaPassi(int incremento)
        {
            // LOCK: Solo un thread alla volta entra qui dentro. È lento, ma sicurissimo.
            lock (_lockObject)
            {
                int temp = _totalSteps;
                Thread.Sleep(1); // Facciamo finta di fare una cosa lunga...
                _totalSteps = temp + incremento;
            }

            // INTERLOCKED: Questo è un comando "atomico" di C#. Fa l'addizione in un colpo solo
            // a livello di processore. Nessuno può interromperlo. Più veloce del lock!
            Interlocked.Add(ref _expectedSteps, incremento);
        }

        // IL CUORE DEL PROGRAMMA: Questo metodo viene eseguito da ogni thread (cuoco) separatamente
        private void CookDish(int chefId)
        {
            Chef chef = _chefs[chefId];
            Stopwatch sw = Stopwatch.StartNew();
            Random rnd = _threadRnd.Value; // Prendiamo il "dado" personale di questo thread

            // Finché il cuoco non ha finito (100%) continua a cucinare
            while (chef.Progress < 100)
            {
                // Prima di continuare, il cuoco guarda il "semaforo"
                // Se è stata richiesta la cancellazione (es: abbiamo premuto Reset), esce dal ciclo
                if (_cancellationRequested)
                {
                    AppendLog($"⚠️ {chef.Name} si ferma, gara annullata.");
                    return; // "return" fa finire immediatamente questo metodo e "uccide" pacificamente il thread
                }

                // Il cuoco lavora per un tempo casuale (tra 0.1 e 0.5 secondi)
                Thread.Sleep(rnd.Next(100, 501));

                // Il cuoco fa un progresso casuale (da 1 a 8 percento)
                int incremento = rnd.Next(1, 9);
                chef.Progress = Math.Min(100, chef.Progress + incremento);

                // Aggiorniamo i contatori di sicurezza
                IncrementaPassi(incremento);

                // IMPORTANTE: I THREAD NON POSSONO TOCCARE LA GRAFICA!
                // Per modificare una ProgressBar, il thread lavoratore deve chiedere un "favore" 
                // al thread principale (quello della grafica) usando "Invoke".
                this.Invoke((Action)(() =>
                {
                    // AGGIUNTA DI SICUREZZA:
                    // Se stiamo chiudendo la finestra o se è già stata distrutta, non fare nulla, 
                    // altrimenti il programma andrebbe in crash cercando di aggiornare grafica che non esiste più.
                    if (!this.IsHandleCreated || this.IsDisposed) return;

                    // Ora siamo al sicuro sul thread principale, aggiorniamo l'interfaccia
                    _pbChef[chefId].Value = chef.Progress;
                    _lblPrecChef[chefId].Text = chef.Progress + "%";

                    bool ok = (_totalSteps == _expectedSteps);
                    lblExpected.Text = $"Atteso: {_expectedSteps} Reale: {_totalSteps}";
                    lblExpected.ForeColor = ok ? Color.Lime : Color.Red;
                }));
            }

            // --- SE ARRIVIAMO QUI, IL CUOCO HA RAGGIUNTO IL 100% ---
            sw.Stop();
            chef.ElapsedSeconds = sw.Elapsed.TotalSeconds;
            chef.IsFinished = true;

            AppendLog($"{chef.Name} ha finito in {chef.ElapsedSeconds:F2} secondi");

            // CHI È IL VINCITORE?
            // Usiamo il lucchetto (lock). Il primo thread che arriva prende la chiave.
            lock (_lockObject)
            {
                // Se _hasWinner è ancora falso, significa che nessuno è passato di qui prima!
                if (!_hasWinner)
                {
                    _hasWinner = true; // "Chiudo la porta": i prossimi thread troveranno true e non entreranno qui

                    this.Invoke((Action)(() =>
                    {
                        if (!this.IsHandleCreated || this.IsDisposed) return;
                        lblVincitore.Text = $"{chef.Name}!";
                        lblVincitore.ForeColor = Color.DarkOrange;
                    }));

                    AppendLog($"🏅 IL VINCITORE È {chef.Name.ToUpper()}!");
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnReset.Enabled = true;

            // Prepariamo la gara azzerando tutto
            _totalSteps = 0;
            _expectedSteps = 0;
            lblExpected.Text = "Atteso: 0 Reale: 0";
            lblExpected.ForeColor = Color.White;
            _hasWinner = false;
            lblVincitore.Text = "Gara in corso...";
            lblVincitore.ForeColor = Color.Black;

            // Spegniamo l'interruttore di cancellazione
            _cancellationRequested = false;
            _workerThreads.Clear();

            // Creiamo un thread per ogni cuoco
            for (int i = 0; i < _chefs.Count; i++)
            {
                // DEVI copiare 'i' in una nuova variabile 'index'.
                // Se usassi direttamente 'i', entro il momento in cui il thread parte per davvero,
                // il ciclo potrebbe aver già finito, e tutti i thread leggerebbero i = 4, scatenando un errore.
                int index = i;

                // Creiamo il "lavoratore" (il thread) e gli diciamo che lavoro fare (CookDish)
                Thread thread = new Thread(() => CookDish(index));

                // IsBackground è FONDAMENTALE. Significa: "Se chiudo il programma, uccidi anche questo thread".
                // Se fosse falso (Foreground), il programma rimarrebbe bloccato in esecuzione di nascosto
                // finché tutti i cuochi non finiscono di cucinare.
                thread.IsBackground = true;

                // Avvia il lavoro!
                thread.Start();

                // Lo salviamo in lista, così sappiamo chi sta lavorando
                _workerThreads.Add(thread);

                AppendLog($"▶ Avvia cottura di {_chefs[index].Name}...");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // 1. Diciamo ai thread in background: "Fermatevi appena potete!"
            _cancellationRequested = true;
            AppendLog("↪ Richiesta di interruzione ai cuochi in corso...");

            // (CORREZIONE) Ho rimosso l'attesa (.Join) che avevi prima. 
            // Aspettare (Join) i thread dal pulsante Reset bloccava la grafica. 
            // Ora, dicendo semplicemente "_cancellationRequested = true", i thread leggeranno
            // questa variabile al prossimo giro del loro ciclo "while" e moriranno da soli in background.

            // 2. Resettiamo le grafiche e i dati
            _chefs = Chef.GetDefaultChefs();
            AggiornaCuochi();
            rtbLog.Clear();

            _totalSteps = 0;
            _expectedSteps = 0;
            lblExpected.Text = "Atteso: 0 Reale: 0";
            lblExpected.ForeColor = Color.White;

            _hasWinner = false;
            lblVincitore.Text = "In attesa dell'inizio...";
            lblVincitore.ForeColor = Color.Black;

            AppendLog("↺ Reset eseguito. La cucina è pronta per un nuovo turno.");

            // 3. Svuotiamo la nostra lista. I vecchi thread si stanno auto-distruggendo in background
            // grazie al comando _cancellationRequested = true.
            _workerThreads.Clear();

            btnStart.Enabled = true;
            btnReset.Enabled = false;
        }

        // Funzioni di servizio per l'interfaccia grafica
        private void ImpostaLabelCuochi()
        {
            string[] icone = { "👨‍🍳", "👨‍🍳", "👨‍🍳", "👨‍🍳" };
            for (int i = 0; i < _chefs.Count; i++)
            {
                _lblChef[i].Text = icone[i] + " " + _chefs[i].Name + " - " + _chefs[i].Dish;
                _lblPrecChef[i].Text = _chefs[i].Progress + "%";
            }
        }

        private void AggiornaCuochi()
        {
            for (int i = 0; i < _chefs.Count; i++)
            {
                _pbChef[i].Value = _chefs[i].Progress;
                _lblPrecChef[i].Text = _chefs[i].Progress + "%";
            }
        }

        private void AppendLog(string messaggio)
        {
            // Anche la scrittura dei log può arrivare dai thread in background, quindi usiamo Invoke
            this.Invoke((Action)(() =>
            {
                // Stesso controllo di sicurezza visto prima
                if (!this.IsHandleCreated || this.IsDisposed) return;

                rtbLog.AppendText($"\n[{DateTime.Now.ToString("HH:mm:ss")}] {messaggio}");
                rtbLog.SelectionStart = rtbLog.Text.Length;
                rtbLog.ScrollToCaret();
            }));
        }
    }
}