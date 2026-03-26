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
        // Lista cuochi (struttura dati
        private List<Chef> _chefs = new List<Chef>();

        private Label[] _lblChef;
        private ProgressBar[] _pbChef;
        private Label[] _lblPrecChef;

        private readonly Random _rnd = new Random();

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

            // Avviamo il cronometro
            Stopwatch sw = Stopwatch.StartNew();

            // Simuliamo preparzione piatto (ciclo fino al 100%)
            while (chef.Progress < 100)
            {
                // Simulo il tempo di una fase di lavorazione del piatto
                Thread.Sleep(_rnd.Next(100, 501)); // Tra 1 decimo e mezzo secondo

                // Incremento il progresso del piatto in modo casuale
                // (non tutte le lavorazioni sono ugualmente impegnative/importanti)
                int incremento = _rnd.Next(1, 9);
                //chef.Progress += incremento;
                chef.Progress = Math.Min(100, chef.Progress + incremento); // Per evitare di superare 100

                // Aggiorniamo i dati nella form
                // ATTENZIONE: probabilmente andrà in errore!
                //_pbChef[chefId].Value = chef.Progress;
                //_lblPrecChef[chefId].Text = chef.Progress + "%";
            }

            // Preparazione piatto completata (stop cronometro e set dati chef)
            sw.Stop();
            chef.ElapsedSeconds = sw.Elapsed.TotalSeconds;
            chef.IsFinished = true;

            // Preparazione terminata, scrivo il log
            // ATTENZIONE: anche qui va in errore per cross-thread!
            AppendLog($"{chef.Name} ha finito in {chef.ElapsedSeconds} secondi");
        }

        // --- Pulsante Avvia
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Disabilito start e abilito reset
            btnStart.Enabled = false;
            btnReset.Enabled = true;

            AppendLog($"▶ Avvio preparazione di {_chefs[0].Name}...");

            // Creo il thread che eseguirà la preparazione del primo cuoco (cuoco 0 - Mario)
            Thread threadMario = new Thread(() => CookDish(0));

            // Imposto il thread come "background thread" in modo che venga terminato se chiudiamo la form
            threadMario.IsBackground = true;

            // Avvio la preparazione - il thread di Mario viaggia in parallelo al thread principale della form
            threadMario.Start();

            //AppendLog("▶ Avvia premuto — logica thread non ancora implementata.");
        }

        // --- Pulsante Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            _chefs = Chef.GetDefaultChefs();
            AggiornaCuochi();
            rtbLog.Clear();
            AppendLog("↺ Reset eseguito. La cucina è pronta per un nuovo turno.");

            // Disabilito reset e abilito start
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
            for(int i = 0; i < _chefs.Count; i++)
            {
                _pbChef[i].Value = _chefs[i].Progress;
                _lblPrecChef[i].Text = _chefs[i].Progress + "%";
            }
        }

        /// <summary>
        /// Aggiunge una riga con stamptime all'attività
        /// </summary>
        /// <param name="messaggio"></param>
        private void AppendLog(string messaggio)
        {
            rtbLog.AppendText($"\n[{DateTime.Now.ToString("hh:mm:ss")}]; {messaggio}");
            rtbLog.ScrollToCaret();
        }
    }
}