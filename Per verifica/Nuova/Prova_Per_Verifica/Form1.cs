using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Prova_Per_Verifica
{
    public partial class Form1 : Form
    {
        // Campi della classe
        private RichTextBox rtbEditor;
        private ToolStripMenuItem copiaToolStripMenuItem;
        private ToolStripMenuItem apriToolStripMenuItem;
        private ToolStripMenuItem salvaToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripStatusLabel lblInfo;

        public Form1()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────
        // CARICAMENTO FORM
        // ─────────────────────────────────────────────
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Mia-preparazione-verifica";
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // ── MENU ──────────────────────────────────
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem azioniMenu = new ToolStripMenuItem("Azioni");

            apriToolStripMenuItem = new ToolStripMenuItem("Apri");
            salvaToolStripMenuItem = new ToolStripMenuItem("Salva");
            aboutToolStripMenuItem = new ToolStripMenuItem("About");
            copiaToolStripMenuItem = new ToolStripMenuItem("Copia");

            apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            copiaToolStripMenuItem.Name = "copiaToolStripMenuItem";
            copiaToolStripMenuItem.Enabled = false; // disabilitato all'avvio

            apriToolStripMenuItem.Click += AzioniMenu_Click;
            salvaToolStripMenuItem.Click += AzioniMenu_Click;
            aboutToolStripMenuItem.Click += AzioniMenu_Click;
            copiaToolStripMenuItem.Click += AzioniMenu_Click;

            azioniMenu.DropDownItems.Add(apriToolStripMenuItem);
            azioniMenu.DropDownItems.Add(salvaToolStripMenuItem);
            azioniMenu.DropDownItems.Add(copiaToolStripMenuItem);
            azioniMenu.DropDownItems.Add(aboutToolStripMenuItem);

            menuStrip.Items.Add(azioniMenu);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // ── STATUS BAR ────────────────────────────
            StatusStrip statusStrip = new StatusStrip();
            lblInfo = new ToolStripStatusLabel("Riga: 1, Colonna: 1");
            statusStrip.Items.Add(lblInfo);
            this.Controls.Add(statusStrip);

            // ── RICH TEXT BOX ─────────────────────────
            rtbEditor = new RichTextBox();
            rtbEditor.Multiline = true;
            rtbEditor.Font = new Font("Consolas", 11);
            rtbEditor.Location = new Point(0, menuStrip.Height);
            rtbEditor.Size = new Size(this.ClientSize.Width, 300 - menuStrip.Height);

            // Collego l'evento SelectionChanged
            rtbEditor.SelectionChanged += rtbEditor_SelectionChanged;

            this.Controls.Add(rtbEditor);
        }

        // ─────────────────────────────────────────────
        // AGGIORNAMENTO RIGA/COLONNA E COPIA
        // ─────────────────────────────────────────────
        private void rtbEditor_SelectionChanged(object sender, EventArgs e)
        {
            int rigaInizio = rtbEditor.GetFirstCharIndexOfCurrentLine();
            int colonna = rtbEditor.SelectionStart - rigaInizio + 1;
            int riga = rtbEditor.GetLineFromCharIndex(rtbEditor.SelectionStart) + 1;

            lblInfo.Text = $"Riga: {riga}, Colonna: {colonna}";

            // Abilita "Copia" solo se c'è testo selezionato
            copiaToolStripMenuItem.Enabled = rtbEditor.SelectionLength > 0;
        }

        // ─────────────────────────────────────────────
        // HANDLER CLICK MENU
        // ─────────────────────────────────────────────
        private void AzioniMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null) return;

            switch (menuItem.Name)
            {
                case "apriToolStripMenuItem":
                    ApriFile();
                    break;
                case "salvaToolStripMenuItem":
                    SalvaFile();
                    break;
                case "copiaToolStripMenuItem":
                    rtbEditor.Copy();
                    break;
                case "aboutToolStripMenuItem":
                    MostraFinestraInfo();
                    break;
            }
        }

        // ─────────────────────────────────────────────
        // APRI FILE
        // ─────────────────────────────────────────────
        private void ApriFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Apri File";
            dialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rtbEditor.Text = File.ReadAllText(dialog.FileName);
                    this.Text = Path.GetFileName(dialog.FileName) + " - Mio Editor";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'apertura:\n" + ex.Message,
                                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ─────────────────────────────────────────────
        // SALVA FILE
        // ─────────────────────────────────────────────
        private void SalvaFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Salva File Con Nome";
            dialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(dialog.FileName, rtbEditor.Text);
                    this.Text = Path.GetFileName(dialog.FileName) + " - Mio Editor";
                    MessageBox.Show("File salvato con successo!", "Salvataggio",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante il salvataggio: " + ex.Message,
                                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ─────────────────────────────────────────────
        // APERTURA FORM FIGLIA
        // ─────────────────────────────────────────────
        private void MostraFinestraInfo()
        {
            Form infoForm = new Form();
            infoForm.Text = "Informazioni su";
            infoForm.Size = new Size(350, 200);
            infoForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            infoForm.StartPosition = FormStartPosition.CenterParent;
            infoForm.MaximizeBox = false;
            infoForm.MinimizeBox = false;

            Label infoLabel = new Label();
            infoLabel.Text = $"Mio Programma v1.0\nCreato da Pietro Olivero\nData: {DateTime.Now:dd/MM/yyyy}\nOre: {DateTime.Now:T}";
            infoLabel.Font = new Font("Arial", 10);
            infoLabel.Dock = DockStyle.Fill;
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;

            infoForm.Controls.Add(infoLabel);
            infoForm.ShowDialog();
        }
    }
}
