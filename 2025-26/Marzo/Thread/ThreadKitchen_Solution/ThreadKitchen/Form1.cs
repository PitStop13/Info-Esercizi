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
        // --- Strutture dati essenziali ---
        private List<Chef> _chefs = new List<Chef>();

        private Label[] _lblChef;
        private ProgressBar[] _pbChef;
        private Label[] _lblPrecChef;

        // Generatore random thread-safe per non avere collisioni tra i thread
        private readonly ThreadLocal<Random> _threadRnd = new ThreadLocal<Random>(() =>
            new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));

        // --- Variabili per dimostrare la Race Condition ---
        private int _totalSteps = 0;
        private int _expectedSteps = 0;

        // Oggetto lucchetto per le sezioni critiche
        private readonly object _lockObj = new object();

        // --- Variabile per il Vincitore ---
        private int _firstFinished = -1; // -1 significa che non c'è ancora un vincitore

        // --- Gestione della Cancellazione ---
        private CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();

            // Mappatura dei controlli creati dal Designer negli array per ciclarli facilmente
            _lblChef = new Label[] { lblChef0, lblChef1, lblChef2, lblChef3 };
            _pbChef = new ProgressBar[] { pbChef0, pbChef1, pbChef2, pbChef3 };
            _lblPrecChef = new Label[] { lblPrecChef0, lblPrecChef1, lblPrecChef2, lblPrecChef3 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnStart.Enabled = true;

            // Inizializza la lista dei cuochi (come da direttive del prof)
            _chefs = new List<Chef>
            {
                new Chef { Id = 0, Name = "Mario",    Dish = "Lasagna"              },
                new Chef { Id = 1, Name = "Giulia",   Dish = "Risotto ai funghi"    },
                new Chef { Id = 2, Name = "Luca",     Dish = "Tiramisu'"            },
                new Chef { Id = 3, Name = "Federica", Dish = "Ossobuco alla milanese"}
            };

            ImpostaLabelCuochi();
            AggiornaCuochi();

            lblVincitore.Text = "...";
            AppendLog("🍳 Cucina pronta. Premi «Avvia cucina» per iniziare.");
        }

        // Se l'utente chiude la finestra improvvisamente, fermiamo i thread
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();
            base.OnFormClosing(e);
        }

        // --- METODO PER LA RACE CONDITION ---
        private void IncrementaPassi(int step)
        {
            // Il lock impedisce il "lost update" tra thread multipli
            lock (_lockObj)
            {
                int temp = _totalSteps;
                Thread.Sleep(1); // Mette in evidenza la race condition (se il lock venisse rimosso)
                _totalSteps = temp + step;
            }

            // Incremento atomico (sicuro senza bisogno di lock)
            Interlocked.Add(ref _expectedSteps, step);
        }

        // --- IL CUORE DEL THREAD: COTTURA ---
        private void CookDish(int chefId, CancellationToken token)
        {
            try
            {
                Chef chef = _chefs[chefId];
                Stopwatch sw = Stopwatch.StartNew();
                Random rnd = _threadRnd.Value;

                AppendLog(chef.Name + " inizia a preparare " + chef.Dish);

                while (chef.Progress < 100)
                {
                    // Controllo cooperativo di interruzione (richiesto dal Token)
                    token.ThrowIfCancellationRequested();

                    // Simula il tempo di lavoro
                    Thread.Sleep(rnd.Next(100, 501));

                    // Controllo nuovamente per sicurezza dopo il sonno
                    token.ThrowIfCancellationRequested();

                    int step = rnd.Next(1, 9);
                    chef.Progress = Math.Min(100, chef.Progress + step);

                    IncrementaPassi(step);

                    // Aggiornamento sicuro della UI tramite Invoke
                    this.Invoke((Action)(() =>
                    {
                        // Controllo di sicurezza se la finestra si sta chiudendo in questo istante
                        if (!this.IsHandleCreated || this.IsDisposed) return;

                        _pbChef[chefId].Value = chef.Progress;
                        _lblPrecChef[chefId].Text = chef.Progress + "%";

                        lblExpected.Text = $"Atteso: {_expectedSteps} Reale: {_totalSteps}";
                        lblExpected.ForeColor = (_expectedSteps != _totalSteps) ? Color.Red : Color.Lime;
                    }));
                }

                sw.Stop();
                chef.ElapsedSeconds = sw.Elapsed.TotalSeconds;
                chef.IsFinished = true;

                AppendLog(chef.Name + " ha finito in " + chef.ElapsedSeconds.ToString("F2") + " secondi!");

                // CHECK-THEN-ACT SUL VINCITORE CON LOCK
                lock (_lockObj)
                {
                    if (_firstFinished == -1) // Il primo che trova -1 diventa il vincitore
                    {
                        _firstFinished = chefId;
                        this.Invoke(new Action(() =>
                        {
                            if (!this.IsHandleCreated || this.IsDisposed) return;
                            lblVincitore.Text = chef.Name + "!";
                            lblVincitore.ForeColor = Color.Lime;
                        }));
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Un'interruzione volontaria (tasto Reset o chiusura Form). Non logghiamo l'errore.
            }
            catch (Exception ex)
            {
                // Perqualsiasi altro errore inatteso
                AppendLog($"❌ Errore in {_chefs[chefId].Name}: {ex.Message}");
            }
        }

        // --- BOTTONI E UI ---
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnReset.Enabled = true;

            // Reset stato gara
            _totalSteps = 0;
            _expectedSteps = 0;
            lblExpected.Text = "Atteso: 0 Reale: 0";
            lblExpected.ForeColor = Color.White;
            _firstFinished = -1;
            lblVincitore.Text = "Gara in corso...";
            lblVincitore.ForeColor = Color.White;

            // Inizializza un nuovo Token per la gara
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            // Creazione e avvio dei thread
            for (int i = 0; i < _chefs.Count; i++)
            {
                int id = i; // Closure corretta dell'indice
                Thread t = new Thread(() => CookDish(id, token));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Ferma immediatamente tutti i thread passando l'eccezione OperationCanceledException
            _cts?.Cancel();

            AppendLog("↪ Richiesta di interruzione ai cuochi in corso...");

            // Azzera lo stato locale (i thread andranno a morire silenziosamente)
            for (int i = 0; i < _chefs.Count; i++)
            {
                _chefs[i].Progress = 0;
                _chefs[i].IsFinished = false;
                _chefs[i].ElapsedSeconds = 0;
                _pbChef[i].Value = 0;
                _lblPrecChef[i].Text = "0%";
            }

            rtbLog.Clear();
            _totalSteps = 0;
            _expectedSteps = 0;
            lblExpected.Text = "Atteso: 0 Reale: 0";
            lblExpected.ForeColor = Color.White;
            _firstFinished = -1;
            lblVincitore.Text = "...";

            AppendLog("↺ Reset eseguito. La cucina è pronta per un nuovo turno.");

            btnStart.Enabled = true;
            btnReset.Enabled = false;
        }

        // Pattern InvokeRequired richiesto dal prof per il Log
        private void AppendLog(string messaggio)
        {
            if (rtbLog.InvokeRequired)
            {
                Invoke(new Action(() => AppendLog(messaggio)));
                return;
            }

            // A questo punto siamo sicuri di essere sul thread della UI
            if (this.IsDisposed) return;

            rtbLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + messaggio + Environment.NewLine);
            rtbLog.ScrollToCaret();
        }

        private void ImpostaLabelCuochi()
        {
            string[] icone = { "👨‍🍳", "👨‍🍳", "👨‍🍳", "👨‍🍳" };
            for (int i = 0; i < _chefs.Count; i++)
            {
                _lblChef[i].Text = icone[i] + " " + _chefs[i].Name + " - " + _chefs[i].Dish;
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
    }    
}