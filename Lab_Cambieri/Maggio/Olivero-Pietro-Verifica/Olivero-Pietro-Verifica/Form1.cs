using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Olivero_Pietro_Verifica
{
    public partial class Verifica : Form
    {
        struct Film
        {
            public string Titolo;
            public string Regista;
            public int Anno;
            public double Voto;
        }
        public Verifica()
        {
            InitializeComponent();
        }
        private void Verifica_Load(object sender, EventArgs e)
        {
            SettaDgv();
        }

        private void SettaDgv()
        {
            dgv.AllowUserToAddRows = false; dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false; dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = false; dgv.RowHeadersVisible = false;
            
            dgv.ColumnCount = 4;
            dgv.Columns[0].Name = "Titolo";
            dgv.Columns[1].Name = "Regista";
            dgv.Columns[2].Name = "Anno";
            dgv.Columns[3].Name = "Voto";

            dgv.Columns[0].Width = 150;
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].Width = 50;
            dgv.Columns[3].Width = 50;


            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnCarica_Click(object sender, EventArgs e)
        {
            
            if (!File.Exists("filmoteca.csv"))
            {
                MessageBox.Show("Il file filmoteca.csv non esiste", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dgv.Rows.Clear();
                StreamReader sr = new StreamReader("filmoteca.csv");
                string[] righe = File.ReadAllLines("filmoteca.csv");
                for (int i = 0; i < righe.Length; i++)
                {
                    string[] dati = righe[i].Split(',');
                    Film film = new Film();
                    film.Titolo = dati[0];
                    film.Regista = dati[1];
                    film.Anno = int.Parse(dati[2]);
                    film.Voto = double.Parse(dati[3].Replace('.', ','));
                    dgv.Rows.Add(film.Titolo, film.Regista, film.Anno, film.Voto);
                }
                sr.Close();
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("filmoteca.csv");

            foreach (DataGridViewRow riga in dgv.Rows)
            {
                if (riga.IsNewRow) continue;

                string titolo = riga.Cells["Titolo"].Value?.ToString() ?? "";
                string regista = riga.Cells["Regista"].Value?.ToString() ?? "";
                string anno = riga.Cells["Anno"].Value?.ToString() ?? "";
                string voto = riga.Cells["Voto"].Value?.ToString()?.Replace(',', '.') ?? "";

                sw.WriteLine($"{titolo},{regista},{anno},{voto}");
            }

            sw.Close();

            MessageBox.Show("File salvato correttamente.", "Salvataggio completato", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCercaPerRegistra_Click(object sender, EventArgs e)
        {
            
            string registaDaCercare = txtRegista.Text.Trim();

            if (registaDaCercare == "")
            {
                MessageBox.Show("Inserisci un nome di regista da cercare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string[]> filmTrovati = new List<string[]>();

            foreach (DataGridViewRow riga in dgv.Rows)
            {
                if (riga.IsNewRow) continue;

                string regista = riga.Cells["Regista"].Value?.ToString() ?? "";

                if (regista.ToLower().Contains(registaDaCercare.ToLower()))
                {
                    string titolo = "";
                    if (riga.Cells["Titolo"].Value != null)
                        titolo = riga.Cells["Titolo"].Value.ToString();

                    string anno = "";
                    if (riga.Cells["Anno"].Value != null)
                        anno = riga.Cells["Anno"].Value.ToString();

                    string voto = "";
                    if (riga.Cells["Voto"].Value != null)
                        voto = riga.Cells["Voto"].Value.ToString();

                    filmTrovati.Add(new string[] { titolo, regista, anno, voto });
                }
            }

            dgv.Rows.Clear();

            foreach (var film in filmTrovati)
            {
                dgv.Rows.Add(film[0], film[1], film[2], film[3]);
            }

            if (filmTrovati.Count == 0)
            {
                MessageBox.Show("Nessun film trovato per il regista inserito.", "Risultato", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFiltraPerAnno_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAnnoMinimo.Text.Trim(), out int annoMin) ||
                !int.TryParse(txtAnnoMassimo.Text.Trim(), out int annoMax))
            {
                MessageBox.Show("Inserisci anni validi.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (annoMin > annoMax)
            {
                MessageBox.Show("L'anno minimo deve essere minore o uguale all'anno massimo.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool trovatoAlmenoUno = false;

            
            int righeTotali = dgv.Rows.Count;
            string[,] dati = new string[righeTotali, 4];
            int indice = 0;

            foreach (DataGridViewRow riga in dgv.Rows)
            {
                if (riga.IsNewRow) continue;

                if (int.TryParse(riga.Cells["Anno"].Value?.ToString(), out int anno) &&
                    anno >= annoMin && anno <= annoMax)
                {
                    if (riga.Cells["Titolo"].Value != null)
                        dati[indice, 0] = riga.Cells["Titolo"].Value.ToString();
                    else
                        dati[indice, 0] = "";

                    if (riga.Cells["Regista"].Value != null)
                        dati[indice, 1] = riga.Cells["Regista"].Value.ToString();
                    else
                        dati[indice, 1] = "";

                    if (riga.Cells["Anno"].Value != null)
                        dati[indice, 2] = riga.Cells["Anno"].Value.ToString();
                    else
                        dati[indice, 2] = "";

                    if (riga.Cells["Voto"].Value != null)
                        dati[indice, 3] = riga.Cells["Voto"].Value.ToString();
                    else
                        dati[indice, 3] = "";

                    indice++;
                    trovatoAlmenoUno = true;
                }
            }

            
            dgv.Rows.Clear();

            for (int i = 0; i < indice; i++)
            {
                dgv.Rows.Add(dati[i, 0], dati[i, 1], dati[i, 2], dati[i, 3]);
            }

            if (!trovatoAlmenoUno)
            {
                MessageBox.Show("Nessun film trovato per gli anni inseriti.", "Risultato", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCalcolaMedia_Click(object sender, EventArgs e)
        {
            
            double sommaVoti = 0;

            int numerodiFilm = 0;

            foreach (DataGridViewRow riga in dgv.Rows)
            {
                if (!riga.IsNewRow && double.TryParse(riga.Cells["Voto"].Value?.ToString(), out double voto))
                {
                    sommaVoti += voto;
                    numerodiFilm++;
                }

            }

            if (numerodiFilm > 0)
            {
                double media = sommaVoti / numerodiFilm;
                MessageBox.Show($"La media dei voti è: {media:F2}", "Media Voti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nessun voto trovato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
