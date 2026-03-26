using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Olivero_Pietro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Titolo Programma";
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            CreaBotoniDinamici();
        }

        private void CreaBotoniDinamici()
        {
            Random rng = new Random();
            string[] etichette = { "SetUp", "Azioni", "File", "Extra" };
            const int btnW = 80, btnH = 30;

            foreach (string testo in etichette)
            {
                Button b = new Button();
                b.Text = testo;
                b.Size = new Size(btnW, btnH);
                b.Name = "btn_" + testo;
                b.Location = new Point(
                    rng.Next(0, panelDown.ClientSize.Width - btnW),
                    rng.Next(0, panelDown.ClientSize.Height - btnH)
                );
                b.Click += GestisciClick;
                panelDown.Controls.Add(b);
            }
        }

        private void GestisciClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            switch (btn.Name)
            {
                case "btn_SetUp": Parte2_SetUp() ; break;
                case "btn_Azioni": Parte3_Azioni(); break;
                case "btn_File": Parte4_File(); break;
                case "btn_Extra": Parte6_Extra(); break;
            }
        }

        private void Parte6_Extra()
        {
            string path = Path.Combine(Application.StartupPath, "Dati.txt");
            string[] righe = {
                "Pietro Olivero",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            };
            try
            {
                File.WriteAllLines(path, righe);
                MessageBox.Show("Salvato in: " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*------*/
            string path1 = Path.Combine(Application.StartupPath, "Dati.txt");

            if (File.Exists(path))
            {
                string contenuto = File.ReadAllText(path);
                MessageBox.Show(contenuto, "Contenuto Dati.txt",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form f = new Form();
                f.Text = "Visualizzatore";
                f.Size = new Size(350, 200);
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.MaximizeBox = false;
                f.MinimizeBox = false;

                RichTextBox rtbDinamico = new RichTextBox();
                rtbDinamico.Text = contenuto;
                rtbDinamico.Font = new Font("Arial", 10);
                rtbDinamico.Dock = DockStyle.Fill;
                rtbDinamico.ReadOnly = true;

                f.Controls.Add(rtbDinamico);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("File non trovato!", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Parte4_File()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File csv (*.csv)|*.csv|Tutti i file (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                MessageBox.Show(sr.ReadLine(), "Prima riga",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /*-----*/

            TextBox txtBox = new TextBox();
            txtBox.Multiline = true;
            txtBox.Font = new Font("Consolas", 11);
            txtBox.ScrollBars = ScrollBars.Vertical;
            txtBox.Dock = DockStyle.Fill;
            txtBox.BackColor = Color.White;
            panelUp.Controls.Add(txtBox);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "File di log (*.log)|*.log|Tutti i file (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    txtBox.Text = "Percorso scelto: " + sfd.FileName + " | Ora : " + DateTime.Now.ToString("T");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message, "Errore",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void Parte3_Azioni()
        {
            DialogResult r = MessageBox.Show(
                "Vuoi cancellare tutti i controlli creati?",
                "Conferma cancellazione",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );
            if (r == DialogResult.OK)
            {
                panelUp.Controls.Clear();
            }
        }

        private void Parte2_SetUp()
        {
            panelUp.Controls.Clear();
            Random rng = new Random();
            string[] etichette = { "Abaco", "Bambino", "Cane", "Dado", "Elefante" };
            const int lbW = 80, lbH = 30;

            foreach (string testo in etichette)
            {
                Label lb = new Label();
                lb.Text = testo;
                lb.Size = new Size(lbW, lbH);
                lb.Name = "lb_" + testo;
                lb.AutoSize = true;
                lb.ForeColor = Color.Black;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.Location = new Point(
                    rng.Next(0, panelUp.ClientSize.Width - lbW),
                    rng.Next(0, panelUp.ClientSize.Height - lbH)
                );
                panelUp.Controls.Add(lb);
            }
        }
    }
}
