﻿using System;
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

            // Carico dati dgv e combo matricole
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
            MessageBox.Show(msg, "VOTI PER CIASCUN STUDENTE");
        }

        private void btnCercaStudenteMediaMaggiore_Click(object sender, EventArgs e)
        {
            string studMediaMax = ClsStudenti.CercaStudenteMediaMaggiore();
            MessageBox.Show(studMediaMax, "STUDENTI MEDIA MAGGIORE");
        }

        private void btnStudSenzaVoti_Click(object sender, EventArgs e)
        {
            string studSenzaVoti = ClsStudenti.StudentiSenzaVoti();
            MessageBox.Show(studSenzaVoti, "STUDENTI SENZA VOTI");
        }

        private void btnMaterieSenzaVoti_Click(object sender, EventArgs e)
        {
            string[] materie = new string[cmbMateria.Items.Count];
            cmbMateria.Items.CopyTo(materie, 0);
            string materieSenzaVoti = ClsValutazioni.MaterieSenzaVoti(materie);
            MessageBox.Show(materieSenzaVoti, "MATERIE SENZA VOTI");
        }

        private void btnRisClasseMigliorePeggiore_Click(object sender, EventArgs e)
        {
            string classiMediaMaxMin = ClsStudenti.ClasseMigliorePeggiore();
            

            MessageBox.Show(classiMediaMaxMin, "MATERIE MIGLIORI PEGGIORI (media voti)");
        }

        private void btnDgvValutazioniOrdinateMateria_Click(object sender, EventArgs e)
        {

        }

        private void btnDgvStudentiClasseMedie_Click(object sender, EventArgs e)
        {

        }
    }
}