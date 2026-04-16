using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadKitchen
{
    public partial class FormMain : Form
    {
        private List<Chef> _chefs = new List<Chef>();
        private Label[] _lblChef;
        private ProgressBar[] _pbChef;
        private Label[] _lblPercChef;

        private readonly Random _rnd = new Random();
        private int _totalSteps = 0;
        private int _expectedSteps = 0;
        private int _firstFinished = -1;
        private readonly object _lockObj = new object();
        private CancellationTokenSource _cts;

        private SemaphoreSlim _semaFornelli = new SemaphoreSlim(2, 2);

        public FormMain()
        {
            InitializeComponent();

            _lblChef = new Label[] { lblChef0, lblChef1, lblChef2, lblChef3 };
            _pbChef = new ProgressBar[] { pbChef0, pbChef1, pbChef2, pbChef3 };
            _lblPercChef = new Label[] { lblPrecChef0, lblPrecChef1, lblPrecChef2, lblPrecChef3 };

            this.FormClosing += FormMain_FormClosing;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts?.Cancel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnStart.Enabled = true;

            _chefs = Chef.GetDefaultChefs();
            ResetChefState();
            AggiornaUI();

            AppendLog("🍳 Cucina pronta. Premi «Avvia cucina» per iniziare.");
        }

        private async void CookDish(int chefId, CancellationToken token)
        {
            try
            {
                Chef chef = _chefs[chefId];
                Stopwatch sw = Stopwatch.StartNew();

                while (chef.Progress < 100)
                {
                    token.ThrowIfCancellationRequested();

                    // Simula lavoro base
                    await Task.Delay(_rnd.Next(100, 501), token);
                    int incremento = _rnd.Next(1, 9);
                    chef.Progress = Math.Min(100, chef.Progress + incremento);

                    // Aggiorna UI dopo ogni incremento
                    UpdateChefUI(chefId, chef.Progress);
                    IncrementaPassi(incremento);

                    // Accesso al fornello se necessario
                    if (chef.Progress >= 50 && !chef.isUsingFornello)
                    {
                        // Attende un fornello libero (con supporto alla cancellazione)
                        await _semaFornelli.WaitAsync(token);
                        try
                        {
                            // Cuoce sul fornello fino a raggiungere almeno l'80%
                            while (chef.Progress < 80)
                            {
                                token.ThrowIfCancellationRequested();
                                await Task.Delay(_rnd.Next(100, 501), token);
                                incremento = _rnd.Next(1, 9);
                                chef.Progress = Math.Min(100, chef.Progress + incremento);
                                UpdateChefUI(chefId, chef.Progress);
                                IncrementaPassi(incremento);
                            }
                            chef.isUsingFornello = true;
                        }
                        finally
                        {
                            _semaFornelli.Release();
                            UpdateFornelliUI();
                        }
                    }

                    // Aggiorna UI fornelli dopo eventuale rilascio
                    UpdateFornelliUI();
                }

                sw.Stop();
                chef.ElapsedSeconds = sw.Elapsed.TotalSeconds;
                chef.IsFinished = true;

                lock (_lockObj)
                {
                    if (_firstFinished == -1)
                    {
                        _firstFinished = chef.Id;
                        string message = $"🏆 {chef.Name} è il primo a finire";
                        AppendLog(message);
                        this.Invoke(new Action(() =>
                        {
                            lblWinner.Text = $"Winner: 🏆 {chef.Name}";
                            lblWinner.ForeColor = Color.Gold;
                        }));
                    }
                }

                AppendLog($"{chef.Name} ha finito di cucinare {chef.Dish} in {chef.ElapsedSeconds:F2} secondi");
            }
            catch (OperationCanceledException)
            {
                AppendLog($"⛔ {_chefs[chefId].Name} ha interrotto la cottura di «{_chefs[chefId].Dish}»");
            }
            catch (Exception ex)
            {
                AppendLog($"⚠️ Errore nel thread di {_chefs[chefId].Name}: {ex.Message}");
            }
        }

        private void UpdateChefUI(int chefId, int progress)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateChefUI(chefId, progress)));
                return;
            }
            _pbChef[chefId].Value = progress;
            _lblPercChef[chefId].Text = $"{progress}%";
        }

        private void UpdateFornelliUI()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateFornelliUI));
                return;
            }
            int inUso = 2 - _semaFornelli.CurrentCount;
            lblFornelli.Text = $"Fornelli in uso: {inUso}/2";
            lblFornelli.ForeColor = inUso > 2 ? Color.Red : Color.Lime;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnReset.Enabled = true;

            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            AppendLog($"▶ La cucina è aperta - {_chefs.Count} cuochi al lavoro!");

            for (int i = 0; i < _chefs.Count; i++)
            {
                int index = i;
                Thread t = new Thread(() => CookDish(index, token));
                t.IsBackground = true;
                t.Start();
                AppendLog($"▶ {_chefs[index].Name} ha iniziato a cucinare {_chefs[index].Dish}");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();

            ResetChefState();
            AggiornaUI();

            _firstFinished = -1;

            btnStart.Enabled = true;
            btnReset.Enabled = false;

            lblFornelli.Text = "Fornelli in uso: 0/2";
            lblExpectedAndTotalSteps.Text = "Reale: 0    Esteso: 0";
            lblWinner.Text = "Il vincitore è...";
            lblWinner.ForeColor = Color.Lime;

            // Ricrea il semaforo per evitare deadlock
            _semaFornelli?.Dispose();
            _semaFornelli = new SemaphoreSlim(2, 2);

            rtbLog.Clear();
            AppendLog("↺ Reset eseguito. La cucina è pronta per un nuovo turno.");
        }

        private void ResetChefState()
        {
            _totalSteps = 0;
            _expectedSteps = 0;
            foreach (Chef chef in _chefs)
            {
                chef.Progress = 0;
                chef.IsFinished = false;
                chef.ElapsedSeconds = 0;
                chef.isUsingFornello = false;
            }
        }

        private void AggiornaUI()
        {
            for (int i = 0; i < _chefs.Count; i++)
            {
                _pbChef[i].Value = _chefs[i].Progress;
                _lblPercChef[i].Text = $"{_chefs[i].Progress}%";
                _lblChef[i].Text = $"👨‍🍳 {_chefs[i].Name} - {_chefs[i].Dish}";
            }
        }

        private void AppendLog(string messaggio)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => AppendLog(messaggio)));
                return;
            }
            rtbLog.AppendText($"\n[{DateTime.Now:HH:mm:ss}] {messaggio}");
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void IncrementaPassi(int step)
        {
            // Simulazione race condition (didattica)
            lock (_lockObj)
            {
                int temp = _totalSteps;
                Thread.Sleep(1); // Amplifica la finestra di vulnerabilità
                _totalSteps = temp + step;
            }

            Interlocked.Add(ref _expectedSteps, step);

            int atteso = _expectedSteps;
            int reale = _totalSteps;

            this.Invoke(new Action(() =>
            {
                lblExpectedAndTotalSteps.Text = $"Reale: {reale}    Esteso: {atteso}";
            }));
        }
    }
}