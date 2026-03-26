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
        // Lista cuochi (struttura dati)
        private List<Chef> _chefs = new List<Chef>();

        private Label[] _lblChef;
        private ProgressBar[] _pbChef;
        private Label[] _lblPrecChef;

        private readonly Random _rnd = new Random();

        // --- COMMIT 4: Variabili per la Race Condition ---
        private int _totalSteps = 0;
        private int _expectedSteps = 0;

        public Form1()
        {
            InitializeComponent();

            _lblChef = new Label[] { lblChef0, lblChef1, lblChef2, lblChef3 };
            _pbChef = new ProgressBar[] { pbChef0, pbChef1, pbChef2, pbChef3 };
            _lblPrecChef = new Label[] { lblPrecChef0, lblPrecChef1, lblPrecChef2, lblPrecChef3 };
        }

        // --- Caricamento form
        private void Form1_Load(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnStart.Enabled = true;

            _chefs = Chef.GetDefaultChefs();
            ImpostaLabelCuochi();
            AggiornaCuochi();

            AppendLog("🍳 Cucina pronta. Premi «Avvia cucina» per iniziare.");
        }

        // --- Metodo eseguito in un thread che simula la cottura di un piatto
        private void CookDish(int chefId)
        {
            Chef chef = _chefs[chefId];
            Stopwatch sw = Stopwatch.StartNew();

            while (chef.Progress < 100)
            {
                Thread.Sleep(_rnd.Next(100, 501));

                int incremento = _rnd.Next(1, 9);
                chef.Progress = Math.Min(100, chef.Progress + incremento);

                // --- INIZIO COMMIT 4: Race Condition ---

                // Valore ATTESO: Atomico e thread-safe
                Interlocked.Add(ref _expectedSteps, incremento);

                // Valore REALE: Lento e soggetto a race condition
                int temp = _totalSteps;
                Thread.Sleep(1); // Simula interruzione del SO
                _totalSteps = temp + incremento;

                // --- FINE COMMIT 4 ---

                int currentProgress = chef.Progress;

                // Aggiorniamo la UI
                this.Invoke((Action)(() =>
                {
                    _pbChef[chefId].Value = currentProgress;
                    _lblPrecChef[chefId].Text = currentProgress + "%";

                    // Aggiorniamo l'etichetta del bug
                    bool ok = (_totalSteps == _expectedSteps);
                    lblExpected.Text = $"Atteso: {_expectedSteps} Reale: {_totalSteps}";
                    lblExpected.ForeColor = ok ? Color.Lime : Color.Red;
                }));
            }

            sw.Stop();
            chef.ElapsedSeconds = sw.Elapsed.TotalSeconds;
            chef.IsFinished = true;

            AppendLog($"{chef.Name} ha finito in {chef.ElapsedSeconds:F2} secondi");
        }

        // --- Pulsante Avvia
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnReset.Enabled = true;

            // Azzero i contatori della race condition
            _totalSteps = 0;
            _expectedSteps = 0;
            lblExpected.Text = "Atteso: 0 Reale: 0";
            lblExpected.ForeColor = Color.White;

            for (int i = 0; i < _chefs.Count; i++)
            {
                int index = i;
                Thread thread = new Thread(() => CookDish(index));
                thread.IsBackground = true;
                thread.Start();

                AppendLog($"▶ Avvia cottura di {_chefs[index].Name}...");
            }
        }

        // --- Pulsante Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            _chefs = Chef.GetDefaultChefs();
            AggiornaCuochi();
            rtbLog.Clear();

            // Reset contatori e label
            _totalSteps = 0;
            _expectedSteps = 0;
            lblExpected.Text = "Atteso: 0 Reale: 0";
            lblExpected.ForeColor = Color.White;

            AppendLog("↺ Reset eseguito. La cucina è pronta per un nuovo turno.");

            btnStart.Enabled = true;
            btnReset.Enabled = false;
        }

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
            this.Invoke((Action)(() =>
            {
                // Uso HH maiuscolo per le 24 ore
                rtbLog.AppendText($"\n[{DateTime.Now.ToString("HH:mm:ss")}] {messaggio}");
                rtbLog.SelectionStart = rtbLog.Text.Length;
                rtbLog.ScrollToCaret();
            }));
        }

    }
}