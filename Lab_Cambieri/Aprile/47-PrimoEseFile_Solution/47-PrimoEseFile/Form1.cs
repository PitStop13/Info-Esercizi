using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace _47_PrimoEseFile
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Formmain_Load(object sender, EventArgs e)
        {
            rtb1.Font = new Font("Consolas", 12, FontStyle.Regular);
            rtb2.Font = new Font("Consolas", 12, FontStyle.Italic);
            cmbParole.Font = new Font("Consolas", 12, FontStyle.Regular);
            CaricaCombo("input.txt");
        }

        private void CaricaCombo(string inputFile)
        {
            cmbParole.Items.Clear();
            string[] parole = new string[100];

            parole = ClsFile.LeggiParoleNonRipetute(inputFile);

            int i = 0;
            while (parole[i] != null)
            {
                cmbParole.Items.Add(parole[i++]);
            }
        }

        private void btnLeggi_Click(object sender, EventArgs e)
        {
            string contenuto = ClsFile.LeggiTutto("input.txt");
            rtb1.Text = contenuto;
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            ClsFile.ModificaFile("input.txt", rtb1.Text);
            MessageBox.Show("File modificato, ora verrà ricaricato...");
            rtb1.Text = ClsFile.LeggiTutto("input.txt");
            CaricaCombo("input.txt");
        }

        private void btnCopia_Click(object sender, EventArgs e)
        {
            string contenutoPrimoFile = ClsFile.LeggiTutto("input.txt");
            ClsFile.ModificaFile("temp.txt", contenutoPrimoFile);
            rtb2.Text = contenutoPrimoFile;
            MessageBox.Show("Il file input.txt è stato copiato nel file temp.txt");
        }

        private void btnContaLineeParole_Click(object sender, EventArgs e)
        {
            int nLinee = 0, nParole = 0;
            ClsFile.ContaLineeParole("input.txt", ref nLinee, ref nParole);
            string message = $"Linee: {nLinee}\nParole: {nParole}";
            MessageBox.Show(message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbParole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int occorrenze = ClsFile.ContaOccorrenzeRobertoParola("input.txt", cmbParole.SelectedItem.ToString());
            if (occorrenze > 0)
                MessageBox.Show($"Occorrenze: {occorrenze}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"Nessuna occorrenza", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSostitureNuovoFile_Click(object sender, EventArgs e)
        {
            string robertoParolaDaSostituire = "", robertoParolaNuova = "";
            bool continuaCiclo;

            do
            {
                robertoParolaDaSostituire = Interaction.InputBox("Introduci la parola da sostituire:", "Gestione File di testo");
                if (ClsFile.ContaOccorrenzeRobertoParola("input.txt", robertoParolaDaSostituire) == 0)
                {
                    MessageBox.Show("La parola non esiste, inseriscine un altra: (vuoto per uscire)");
                    continuaCiclo = robertoParolaDaSostituire != "";
                }
                else
                {
                    robertoParolaNuova = Interaction.InputBox("Introduci la parola nuova:", "Gestione File di testo");
                    ClsFile.SostituisciRobertoParolaInNuovoFile("input.txt", "temp.txt", robertoParolaDaSostituire, robertoParolaNuova);
                    rtb2.Text = ClsFile.LeggiTutto("temp.txt");
                    MessageBox.Show($"La parola {robertoParolaDaSostituire} è stata sostituita da {robertoParolaNuova}, nel file temp.txt");
                    continuaCiclo = false;
                }
            } while (continuaCiclo);
        }

        private void btnSostituireStessoFile_Click(object sender, EventArgs e)
        {
            string robertoParolaDaSostituire = "", robertoParolaNuova = "";
            bool continuaCiclo;

            do
            {
                robertoParolaDaSostituire = Interaction.InputBox("Introduci la parola da sostituire:", "Gestione File di testo");
                if (ClsFile.ContaOccorrenzeRobertoParola("input.txt", robertoParolaDaSostituire) == 0)
                {
                    MessageBox.Show("La parola non esiste, inseriscine un altra: (vuoto per uscire)");
                    continuaCiclo = robertoParolaDaSostituire != "";
                }
                else
                {
                    robertoParolaNuova = Interaction.InputBox("Introduci la parola nuova:", "Gestione File di testo");
                    ClsFile.SostituisciRobertoParolaInStessoFile("input.txt", robertoParolaDaSostituire, robertoParolaNuova);
                    rtb1.Text = ClsFile.LeggiTutto("input.txt");
                    MessageBox.Show($"La parola {robertoParolaDaSostituire} è stata sostituita da {robertoParolaNuova}, nel file input.txt");
                    continuaCiclo = false;
                }
            } while (continuaCiclo);
        }

        private void btnContaOccorrenze_Click(object sender, EventArgs e)
        {
            string occorrenze = ClsFile.ContaOccorrenzeParoleNelFile("input.txt");
            MessageBox.Show(occorrenze);
        }

        private void btnLunghezzaMediaParole_Click(object sender, EventArgs e)
        {
            string messaggio = ClsFile.LunghezzaMediaParole("input.txt");
            MessageBox.Show(messaggio);
        }
    }
}
