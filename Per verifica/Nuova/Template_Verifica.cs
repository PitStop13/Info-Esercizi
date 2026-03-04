// ============================================================
//  TEMPLATE VERIFICA — Form1.cs
//  Decommenta i blocchi che ti servono, adatta i nomi.
//  Using minimi necessari già inclusi.
// ============================================================
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NomeProgetto   // <-- cambia con il nome della tua soluzione
{
    public partial class Form1 : Form
    {
        // ── Campi di classe (aggiungi qui i controlli che usi in più metodi) ──
        private RichTextBox rtbEditor;
        private ToolStripStatusLabel lblInfo;

        public Form1() { InitializeComponent(); }

        // ============================================================
        //  FORM LOAD — setup finestra
        // ============================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            // -- Impostazioni di base --
            this.Text = "Titolo Programma";
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // no resize
            this.MaximizeBox = false;   // no fullscreen
            this.MinimizeBox = true;    // sì icona
            this.StartPosition = FormStartPosition.CenterScreen;

            // ── Bottoni dinamici randomizzati nella metà inferiore ──────────
            // (decommmenta se richiesto)
            //CreaBotoniDinamici();

            // ── Menu dinamico ────────────────────────────────────────────────
            // (decommenta se richiesto)
            //CreaMenu();

            // ── RichTextBox editor ───────────────────────────────────────────
            // (decommenta se richiesto)
            //CreaEditor();

            // ── Status bar riga/colonna ──────────────────────────────────────
            // (decommenta se richiesto, richiede CreaEditor() prima)
            //CreaStatusBar();
        }

        // ============================================================
        //  BOTTONI DINAMICI RANDOMIZZATI
        // ============================================================
        private void CreaBotoniDinamici()
        {
            Random rng = new Random();
            string[] etichette = { "Parte 3", "Parte 4", "Parte 5", "Parte 6", "Parte 7", "FAC" };
            const int btnW = 80, btnH = 30;

            foreach (string testo in etichette)
            {
                Button b = new Button();
                b.Text = testo;
                b.Size = new Size(btnW, btnH);
                b.Name = "btn_" + testo.Replace(" ", ""); // "btn_Parte3", "btn_FAC" ...
                b.Location = new Point(
                    rng.Next(0, this.ClientSize.Width - btnW),
                    rng.Next(300, this.ClientSize.Height - btnH)  // metà inferiore
                );
                b.Click += GestisciClick;
                this.Controls.Add(b);
            }
        }

        // Handler centralizzato per i bottoni dinamici
        private void GestisciClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            switch (btn.Name)
            {
                case "btn_Parte3": Parte3_EsciConConferma(); break;
                case "btn_Parte4": Parte4_ApriMostraPercorso(); break;
                case "btn_Parte5": Parte5_RtbESalvaDialog(); break;
                case "btn_Parte6": Parte6_SalvaSuDisco(); break;
                case "btn_Parte7": Parte7_LeggiMostraMsg(); break;
                case "btn_FAC": Fac_LeggiInFormDinamica(); break;
            }
        }

        // ============================================================
        //  PARTE 3 — MessageBox YES/NO → esci
        // ============================================================
        private void Parte3_EsciConConferma()
        {
            DialogResult r = MessageBox.Show(
                "Sei sicuro di voler uscire?",
                "Conferma uscita",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        // ============================================================
        //  PARTE 4 — OpenFileDialog → mostra percorso in MessageBox
        // ============================================================
        private void Parte4_ApriMostraPercorso()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName, "File selezionato",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ============================================================
        //  PARTE 5 — RichTextBox dinamico (metà superiore) + SaveFileDialog
        // ============================================================
        private void Parte5_RtbESalvaDialog()
        {
            // Crea il RichTextBox che occupa la metà superiore
            RichTextBox rtb = new RichTextBox();
            rtb.Multiline = true;
            rtb.Location = new Point(0, 0);
            rtb.Size = new Size(this.ClientSize.Width, 300);
            this.Controls.Add(rtb);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rtb.AppendText(sfd.FileName + Environment.NewLine);
            }
        }

        // ============================================================
        //  PARTE 6 — Salva "salvataggio.txt" in cartella programma
        // ============================================================
        private void Parte6_SalvaSuDisco()
        {
            string path = Path.Combine(Application.StartupPath, "salvataggio.txt");
            string[] righe = {
                "Pietro Olivero",
                DateTime.Now.ToString("dd/MM/yyyy")
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
        }

        // ============================================================
        //  PARTE 7 — Leggi "salvataggio.txt" e mostra in MessageBox
        // ============================================================
        private void Parte7_LeggiMostraMsg()
        {
            string path = Path.Combine(Application.StartupPath, "salvataggio.txt");

            if (File.Exists(path))
            {
                string contenuto = File.ReadAllText(path);
                MessageBox.Show(contenuto, "Contenuto del file",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("File non trovato!", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  FAC — Leggi "salvataggio.txt" in Form dinamica modale
        // ============================================================
        private void Fac_LeggiInFormDinamica()
        {
            string path = Path.Combine(Application.StartupPath, "salvataggio.txt");

            if (!File.Exists(path))
            {
                MessageBox.Show("File non trovato!", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contenuto = File.ReadAllText(path);

            Form f = new Form();
            f.Text = "Visualizza salvataggio.txt";
            f.Size = new Size(400, 300);
            f.StartPosition = FormStartPosition.CenterParent;
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.MaximizeBox = false;
            f.MinimizeBox = false;

            TextBox txt = new TextBox();
            txt.Multiline = true;
            txt.Dock = DockStyle.Fill;
            txt.ScrollBars = ScrollBars.Vertical;
            txt.ReadOnly = true;
            txt.Text = contenuto;

            f.Controls.Add(txt);
            f.ShowDialog();  // modale: blocca la form padre
        }

        // ============================================================
        //  MENU DINAMICO (decommmenta CreaMenu() nel Form_Load)
        // ============================================================
        private void CreaMenu()
        {
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");

            ToolStripMenuItem apriItem = new ToolStripMenuItem("Apri") { Name = "apriItem" };
            ToolStripMenuItem salvaItem = new ToolStripMenuItem("Salva") { Name = "salvaItem" };
            ToolStripMenuItem esciItem = new ToolStripMenuItem("Esci") { Name = "esciItem" };

            apriItem.Click += MenuClick;
            salvaItem.Click += MenuClick;
            esciItem.Click += MenuClick;

            fileMenu.DropDownItems.Add(apriItem);
            fileMenu.DropDownItems.Add(salvaItem);
            fileMenu.DropDownItems.Add(esciItem);

            ms.Items.Add(fileMenu);
            this.Controls.Add(ms);
            this.MainMenuStrip = ms;
        }

        private void MenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;
            switch (item.Name)
            {
                case "apriItem": ApriFile(); break;
                case "salvaItem": SalvaFile(); break;
                case "esciItem": Application.Exit(); break;
            }
        }

        // ============================================================
        //  EDITOR RICHTEXTBOX (decommenta CreaEditor() nel Form_Load)
        // ============================================================
        private void CreaEditor()
        {
            rtbEditor = new RichTextBox();
            rtbEditor.Multiline = true;
            rtbEditor.Font = new Font("Consolas", 11);
            rtbEditor.Dock = DockStyle.Fill;
            rtbEditor.SelectionChanged += (s, ev) => AggiornaPosizione();
            this.Controls.Add(rtbEditor);
        }

        // ============================================================
        //  STATUS BAR riga/colonna
        // ============================================================
        private void CreaStatusBar()
        {
            StatusStrip ss = new StatusStrip();
            lblInfo = new ToolStripStatusLabel("Riga: 1, Col: 1");
            ss.Items.Add(lblInfo);
            this.Controls.Add(ss);
        }

        private void AggiornaPosizione()
        {
            int idx = rtbEditor.GetFirstCharIndexOfCurrentLine();
            int col = rtbEditor.SelectionStart - idx + 1;
            int riga = rtbEditor.GetLineFromCharIndex(rtbEditor.SelectionStart) + 1;
            lblInfo.Text = $"Riga: {riga}, Col: {col}";
        }

        // ============================================================
        //  APRI FILE → carica in rtbEditor
        // ============================================================
        private void ApriFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rtbEditor.Text = File.ReadAllText(ofd.FileName);
                    this.Text = Path.GetFileName(ofd.FileName) + " - Editor";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message, "Errore",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        //  SALVA FILE da rtbEditor
        // ============================================================
        private void SalvaFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(sfd.FileName, rtbEditor.Text);
                    this.Text = Path.GetFileName(sfd.FileName) + " - Editor";
                    MessageBox.Show("Salvato!", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message, "Errore",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        //  FORM ABOUT dinamica
        // ============================================================
        private void MostraAbout()
        {
            Form f = new Form();
            f.Text = "Informazioni";
            f.Size = new Size(350, 200);
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.StartPosition = FormStartPosition.CenterParent;
            f.MaximizeBox = false;
            f.MinimizeBox = false;

            Label lbl = new Label();
            lbl.Text = $"Programma v1.0\nPietro Olivero\n{DateTime.Now:dd/MM/yyyy}";
            lbl.Font = new Font("Arial", 10);
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            f.Controls.Add(lbl);
            f.ShowDialog();
        }
    }
}
