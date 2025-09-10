using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static GestioneStudenti.ClsValutazioni;

namespace GestioneStudenti
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SettaDgv(DgvStudenti, "MATRICOLA COGNOME NOME CLASSE");
            VisualizzaDatiStudentiClassiMatricole();
            SettaDgv(DgvValutazioni, "MATERIA VOTO TIPO MATRICOLA");

            ClsValutazioni.CaricaDatiValutazioni();
            VisualizzaDatiValutazioni();

            rdbScritto.Checked = true;
            cmbMateria.SelectedIndex = 0;
        }

        private void SettaDgv(DataGridView dgv, string intestazioni)
        {
            string[] intestazioniArray = intestazioni.Split(' ');
            dgv.ColumnCount = intestazioniArray.Length;

            for(int i = 0; i < intestazioniArray.Length; i++) 
                dgv.Columns[i].HeaderText = intestazioniArray[i];
            dgv.RowHeadersVisible = false;
            dgv.ClearSelection();
        }

        private void VisualizzaDatiStudentiClassiMatricole()
        {
            // Carico combo classi
            List<string> listClassi = ClsStudenti.CaricaDatiStudenti();
            cmbClasse.DataSource = listClassi;

            // Crico dati dgv e combo matricole
            for(int i = 0; i < ClsStudenti.Studenti.Length; i++)
            {
                ClsStudenti.Studente s = ClsStudenti.Studenti[i];
                cmbMatricole.Items.Add(s.matricola);
                DgvStudenti.Rows.Add(s.matricola, s.cognome, s.nome, s.classe);
            }
            cmbMatricole.SelectedIndex = 0;
        }

        private void VisualizzaDatiValutazioni()
        {
            DgvValutazioni.Rows.Clear();
            for (int i = 0; i < ClsValutazioni.Valutazioni.Length; i++)
            {
                ClsValutazioni.Valutazione v = ClsValutazioni.Valutazioni[i];
                DgvValutazioni.Rows.Add(v.materia, v.voto, v.tipo, v.matricola);
            }
        }

        private void btnInserisciStudente_Click(object sender, EventArgs e)
        {
            if(txtCognome.Text != "" && txtNome.Text != "" && cmbClasse.Text != "")
            {
                ClsStudenti.Studente stud = ClsStudenti.InserisciStudente(txtCognome.Text, txtNome.Text, cmbClasse.Text);
                DgvStudenti.Rows.Add(stud.matricola, stud.cognome, stud.nome, stud.classe);
                cmbMatricole.Items.Add(stud.matricola);
                txtCognome.Text = txtNome.Text = cmbClasse.Text = "";
            }
            else
            {
                MessageBox.Show("Inserisci tutti i dati", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRicStudMat_Click(object sender, EventArgs e)
        {
            int matricola = 0;

            if(int.TryParse(Interaction.InputBox("Inserisci la matricola:"), out matricola) || matricola != 0)
            {
                int pos = ClsStudenti.RicercaStudentePerMatricola(matricola);
                if (pos != -1)
                {
                    ClsStudenti.Studente stud = ClsStudenti.Studenti[pos];
                    MessageBox.Show(stud.cognome + " " + stud.nome);
                }
                else
                    MessageBox.Show("Matricola non trovata!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Inserisci una matricola valida", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRicStudCongNom_Click(object sender, EventArgs e)
        {
            string cognome = Interaction.InputBox("Inserisci il cognome:");
            string nome = Interaction.InputBox("Inserisci il nome:");

            int pos = ClsStudenti.RicercaStudentePerCognomeNome(cognome, nome);
            if (pos != -1)
                    MessageBox.Show("Trovato con matricola: " + ClsStudenti.Studenti[pos].matricola);
            else
                MessageBox.Show("Studente non trovato!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnOrdinaStudNominativo_Click(object sender, EventArgs e)
        {
            ClsStudenti.OrdinaPerNominativo();

            DgvStudenti.Rows.Clear();
            for (int i = 0; i < ClsStudenti.Studenti.Length; i++)
            {
                ClsStudenti.Studente stud = ClsStudenti.Studenti[i];
                DgvStudenti.Rows.Add(stud.matricola, stud.cognome, stud.nome, stud.classe);
            }
        }

        private void btnContaStudClasse_Click(object sender, EventArgs e)
        {
            if(cmbClasse.Text != string.Empty)
            {
                int nStudentiClasse = 0;
                for (int i = 0; i < ClsStudenti.Studenti.Length; i++)
                {
                    if (ClsStudenti.Studenti[i].classe == cmbClasse.Text)
                    {
                        nStudentiClasse++;
                    }
                }
                if (nStudentiClasse == 0)
                {
                    MessageBox.Show("Classe non trovata!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"La classe {cmbClasse.Text} ha {nStudentiClasse} studenti");
                }
            }
            else
            {
                MessageBox.Show("Seleziona una classe!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnContaVotiStudClasse_Click(object sender, EventArgs e)
        {
            if (cmbClasse.Text != string.Empty)
            {
                int nVotiStudClasse = 0;
                for (int i = 0; i < ClsStudenti.Studenti.Length; i++)
                {
                    if (ClsStudenti.Studenti[i].classe == cmbClasse.Text)
                    {
                        int matricolaStud = ClsStudenti.Studenti[i].matricola;
                        for (int j = 0; j < ClsValutazioni.Valutazioni.Length; j++)
                        {
                            if (ClsValutazioni.Valutazioni[j].matricola == matricolaStud)
                            {
                                nVotiStudClasse++;
                            }
                        }
                    }
                }

                if (nVotiStudClasse == 0)
                {
                    MessageBox.Show("Classe non trovata!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"La classe {cmbClasse.Text} ha {nVotiStudClasse} voti");
                }
            }
            else
            {
                MessageBox.Show("Seleziona una classe!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInserisciVoto_Click(object sender, EventArgs e)
        {
            string tipo = "";
            if(cmbMatricole.Text != "" && cmbMateria.Text != "")
            {
                // Possiamo farlo così o con else if, non cambia nulla
                if (rdbOrale.Checked) tipo = "O";
                if (rdbScritto.Checked) tipo = "S";
                if(rdbLaboratorio.Checked) tipo = "L";
                ClsValutazioni.Valutazione v = ClsValutazioni.InserisciVoto(cmbMateria.Text, tipo, Convert.ToInt32(nupVoto.Value), Convert.ToInt32(cmbMatricole.Text));
                VisualizzaVoti(DgvValutazioni, v);
            }
            else
            {
                MessageBox.Show("Seleziona una matricola e una classe!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VisualizzaVoti(DataGridView dgvValutazioni, ClsValutazioni.Valutazione valutazione)
        {
            dgvValutazioni.Rows.Add(valutazione.materia, valutazione.voto, valutazione.tipo, valutazione.matricola);
        }

        private void btnMediaPerMateria_Click(object sender, EventArgs e)
        {
            if(cmbMateria.Text != "")
            {
                double media = ClsValutazioni.MediaPerMateria(cmbMateria.Text);
                if(media == -1)
                    MessageBox.Show("La materia non ha voti");
                else
                    MessageBox.Show($"La media di {cmbMateria.Text} è {media}");
            }
            else
            {
                MessageBox.Show("Seleziona una materia!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnContaVotiPerTipoPerStudente_Click(object sender, EventArgs e)
        {
            string cognome, nome;
            while ((cognome = Interaction.InputBox("Inserisci il cognome:")) == "");
            while ((nome = Interaction.InputBox("Inserisci il nome:")) == "");

            string tipo = "";
            if (rdbOrale.Checked) tipo = "O";
            if (rdbScritto.Checked) tipo = "S";
            if (rdbLaboratorio.Checked) tipo = "L";

            int matricola = ClsStudenti.CercaMatricola( cognome, nome);
            if(matricola != -1)
            {
                int nVoti = ClsValutazioni.ContaVotiPerTipoPerStudente(matricola, tipo);

                MessageBox.Show($"lo studente {cognome} {nome} ha {nVoti} voti di tipo {tipo}");
            }
            else
            {
                MessageBox.Show("Studente non trovato!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNumVotiPerStudente_Click(object sender, EventArgs e)
        {
            ClsValutazioni.OrdinaPerMatricola();
            VisualizzaDatiValutazioni();
            string msg = ClsValutazioni.RotturaMatricolaValutazioni();
            /*for(int i = 0;i < ClsStudenti.Studenti.Length;i++)
            {
                int nVoti = ClsValutazioni.ContaVotiPerOgniStudente(ClsStudenti.Studenti[i]);

                if(nVoti == 0)
                {
                    MessageBox.Show($"{ClsStudenti.Studenti[i].cognome} {ClsStudenti.Studenti[i].nome} non ha voti");
                }
                else if(nVoti == 1)
                {
                    MessageBox.Show($"{ClsStudenti.Studenti[i].cognome} {ClsStudenti.Studenti[i].nome} ha {nVoti} voto");
                }
                else
                {
                    MessageBox.Show($"{ClsStudenti.Studenti[i].cognome} {ClsStudenti.Studenti[i].nome} ha {nVoti} voti");
                }
                

            }*/
        }

        private void btnCercaStudenteMediaMaggiore_Click(object sender, EventArgs e)
        {
            string[] studMediaMax = ClsStudenti.CercaStudenteMediaMaggiore();
            string stud = "";
            if (studMediaMax.Length > 2)
            {
                for (int i = 1; i < studMediaMax.Length; i++)
                {
                    if (i != (studMediaMax.Length - 1))
                    {
                        stud += studMediaMax[i] + ", ";
                    }
                }
            }
            stud += studMediaMax[studMediaMax.Length - 1];
            MessageBox.Show($"{stud} media {studMediaMax[0]}");
        }

        private void btnStudSenzaVoti_Click(object sender, EventArgs e)
        {
            string[] studVet = new string[ClsStudenti.Studenti.Length];
            int pos = 0;
            ClsStudenti.StudentiSenzaVoti(studVet, ref pos);

            string stud = "";
            if(pos == 0)
            {
                stud = "Non ci sono studenti senza voti";
            }
            else
            {
                for(int i = 0; i < pos - 1;i++)
                {
                    stud +=($"{studVet[i]} , ");
                }
                stud += ($"{studVet[pos - 1]}");
            }
            MessageBox.Show(stud, "STUDENTI SENZA VOTI");
        }

        private void btnMaterieSenzaVoti_Click(object sender, EventArgs e)
        {
            string[] materieCodice = { "Italiano", "Informatica", "Inglese", "Sistemi", "Storia", "TPSIT", "Telecomunicazioni", "Matematica", "Motoria" };
            string[] materieVet = new string[materieCodice.Length];
            int pos = 0;
            for (int i = 0; i < materieCodice.Length; i++)
            {
                bool senzaVoti = ClsValutazioni.MaterieSenzaVoti(materieCodice[i]);
                if (senzaVoti)
                {
                    materieVet[pos] = materieCodice[i];
                    pos++;
                }
            }

            string materie = "";
            if (pos == 0)
            {
                materie = "Non ci sono materie senza voti";
            }
            else
            {
                for (int i = 0; i < pos - 1; i++)
                {
                    materie += ($"{materieVet[i]} , ");
                }
                materie += ($"{materieVet[pos - 1]}");
            }
            MessageBox.Show(materie, "MATERIE SENZA VOTI");
        }

        private void btnRisClasseMigliorePeggiore_Click(object sender, EventArgs e)
        {
            string[] classiMediaMaxMin = ClsStudenti.ClasseMigliorePeggiore();
            string[] vetClassiMediaMax = classiMediaMaxMin[0].Split(' ');
            string[] vetClassiMediaMin = classiMediaMaxMin[1].Split(' ');

            string materieMediaMax = "";
            if(vetClassiMediaMax.Length > 2)
            {
                for (int i = 1; i < vetClassiMediaMax.Length - 1; i++)
                {
                    materieMediaMax += ($"{vetClassiMediaMax[i]} , ");
                }
            }
            materieMediaMax += ($"{vetClassiMediaMax[vetClassiMediaMax.Length - 1]}");

            string materieMediaMin = "";
            if (vetClassiMediaMin.Length > 2)
            {
                for (int i = 1; i < vetClassiMediaMin.Length - 1; i++)
                {
                    materieMediaMin += ($"{vetClassiMediaMin[i]} , ");
                }
            }
            materieMediaMin += $"{vetClassiMediaMin[vetClassiMediaMin.Length - 1]}";

            string messaggio = "";

            if(vetClassiMediaMin.Length > 2)
            {
                if (vetClassiMediaMax.Length > 2)
                    messaggio = $"Le classi miglori sono {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLe classi peggiori sono {materieMediaMin} con media: {vetClassiMediaMin[0]}";
                else
                    messaggio = $"La classe miglore è {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLe classi peggiori sono {materieMediaMin} con media: {vetClassiMediaMin[0]}";
            }
            else
            {
                if (vetClassiMediaMax.Length > 2)
                    messaggio = $"Le classi miglori sono {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLa classe peggiore è {materieMediaMin} con media: {vetClassiMediaMin[0]}";
                else
                    messaggio = $"La classe miglore è {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLa classe peggiore è {materieMediaMin} con media: {vetClassiMediaMin[0]}";
            }

            MessageBox.Show(messaggio, "MATERIE MIGLIORI PEGGIORI (media voti)");
        }
    }
}