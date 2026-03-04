using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimulazioneCompleta
{
    public partial class Form1 : Form
    {
        private List<Button> bottoniDinamici = new List<Button>();
        private List<Button> tastierino = new List<Button>();
        private List<string> numeriMemorizzati = new List<string>();
        private Random random = new Random();
        private RichTextBox richTextBoxNumeri;
        private Button btnMemorizza;

        public Form1()
        {
            InitializeComponent();

            //Parte 1
            this.Size = new Size(600, 800);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Simulazione verifica";

            GeneraBottoniDinamici();
        }

        // PARTE 2
        private void GeneraBottoniDinamici()
        {
            string[] etichette = { "Parte 3", "Parte 4", "Parte 5", "Parte 6", "Parte 7", "FAC" };
            foreach (var item in etichette)
            {
                Button btn = new Button();
                btn.Text = item;
                btn.Size = new Size(80, 30);
                btn.Click += BottoneDinamico_Click;

                btn.Location = new Point(random.Next(0, this.ClientSize.Width - btn.Width), random.Next(400, this.ClientSize.Height - btn.Height));
                bottoniDinamici.Add(btn);
                this.Controls.Add(btn);
            }
        }

        // Gestore bottoni
        private void BottoneDinamico_Click(object sender, EventArgs e)
        {
            Button btncliccato = (Button)sender;
            switch (btncliccato.Text)
            {
                case "Parte 3":
                    RiposizionaBottoniSenzaSovrapposizione();
                    break;
                case "Parte 4":
                    CreaTastierino();
                    break;
                case "Parte 5":
                    RimuoviTastierino();
                    break;
                case "Parte 6":
                    CreaRichTextBox();
                    break;
                case "Parte 7":
                    CreaBottoneMemorizza();
                    break;
                case "FAC":
                    VisualizzaNumeriMemorizzati();
                    break;

            }
        }

        // PARTE 3
        private void RiposizionaBottoniSenzaSovrapposizione()
        {
            do
            {
                foreach (Button btn in bottoniDinamici)
                {
                    btn.Location = new Point(random.Next(0, this.ClientSize.Width - btn.Width), random.Next(400, this.ClientSize.Height - btn.Height));
                }
            }
            while (BottoniSovrapposti());
        }

        // Verifica se ci sono bottoni sovrapposti
        private bool BottoniSovrapposti()
        {
            for (int i = 0; i < bottoniDinamici.Count; i++)
            {
                for (int j = i + 1; j < bottoniDinamici.Count; j++)
                {
                    if (bottoniDinamici[i].Bounds.IntersectsWith(bottoniDinamici[j].Bounds))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // PARTE 4
        private void CreaTastierino()
        {
            if (tastierino.Count > 0)
            {
                return;
            }
            string[] tasti = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "0", "#" };
            int startX = 200;
            int startY = 150;
            int buttonSize = 50;
            int spacing = 10;

            for (int i = 0; i < tasti.Length; i++)
            {
                Button btn = new Button();
                btn.Text = tasti[i];
                btn.Size = new Size(buttonSize, buttonSize);
                btn.Click += TastieraTasto_Click;

                int row = i / 3;
                int col = i % 3;

                btn.Location = new Point(startX + col * (buttonSize + spacing), startY + row * (buttonSize + spacing));

                this.Controls.Add(btn);
                tastierino.Add(btn);
            }
        }

        // PARTE 5
        private void RimuoviTastierino()
        {
            foreach (Button btn in tastierino)
            {
                this.Controls.Remove(btn);
            }
            tastierino.Clear();
        }

        // PARTE 6
        private void CreaRichTextBox()
        {
            if (richTextBoxNumeri != null && this.Controls.Contains(richTextBoxNumeri))
            {
                return;
            }

            if (tastierino.Count == 0)
            {
                MessageBox.Show("Devi prima creare il tastierino");
                return;
            }
            richTextBoxNumeri = new RichTextBox();
            richTextBoxNumeri.Size = new Size(200, 50);

            int tastierino_Y = tastierino.Min(b => b.Location.Y);
            richTextBoxNumeri.Location = new Point(200, tastierino_Y - 60);
            richTextBoxNumeri.Font = new Font("Arial", 16);
            this.Controls.Add(richTextBoxNumeri);
        }

        // Gestore click sui tasti del tastierino
        private void TastieraTasto_Click(object sender, EventArgs e)
        {
            if (richTextBoxNumeri == null || !this.Controls.Contains(richTextBoxNumeri))
            {
                return;
            }

            Button btn = (Button)sender;
            string testo = btn.Text;

            if (testo == "+")
            {
                if (richTextBoxNumeri.Text == "")
                {
                    richTextBoxNumeri.AppendText(testo);
                }
            }
            else if (testo == "#")
            {
                richTextBoxNumeri.Text = richTextBoxNumeri.Text.Replace("#", "");
                richTextBoxNumeri.AppendText(testo);
            }
            else
            {
                string testoCorrente = richTextBoxNumeri.Text;
                if (testoCorrente.EndsWith("#"))
                {
                    string testoSenzaCanc = richTextBoxNumeri.Text.Replace("#", "");
                    richTextBoxNumeri.Text = testoSenzaCanc + testo + "#";
                }
                else
                {
                    richTextBoxNumeri.AppendText(testo);
                }
            }
        }

        // PARTE 7
        private void CreaBottoneMemorizza()
        {
            if (btnMemorizza != null && this.Controls.Contains(btnMemorizza))
            {
                return;
            }
            if (tastierino.Count == 0)
            {
                MessageBox.Show("Devi prima creare il tastierino (Parte 4)!");
                return;
            }

            btnMemorizza = new Button();
            btnMemorizza.Size = new Size(200, 40);
            btnMemorizza.Text = "MEMORIZZA";

            int tastierinoY = tastierino.Max(y => y.Location.Y + y.Height);
            btnMemorizza.Location = new Point(200, tastierinoY + 10);
            btnMemorizza.Click += BtnMemorizza_Click;

            this.Controls.Add(btnMemorizza);

        }

        // Gestore click bottone MEMORIZZA
        private void BtnMemorizza_Click(object sender, EventArgs e)
        {
            if (richTextBoxNumeri != null && !string.IsNullOrEmpty(richTextBoxNumeri.Text))
            {
                numeriMemorizzati.Add(richTextBoxNumeri.Text);
                richTextBoxNumeri.Clear();
            }
        }

        // FAC
       	private void VisualizzaNumeriMemorizzati()
	    {
    	    if (numeriMemorizzati.Count == 0)
    	    {
        	    MessageBox.Show("Nessun numero memorizzato!", "Info");
        	    return;
    	    }

	        string messaggio = "Numeri memorizzati:\n" + string.Join("\n", numeriMemorizzati);
    	    MessageBox.Show(messaggio, "Info");
        }
    }
}
