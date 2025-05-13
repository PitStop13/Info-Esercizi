using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrutinio
{
    public partial class FormScrutinio : Form
    {
        public FormScrutinio()
        {
            InitializeComponent();
        }

        private void FormScrutinio_Load(object sender, EventArgs e)
        {
            SettaDgv(DgvScrutinio);
            ClsScrutinio.CaricaVoti(4, 11);
            CaricaDgvOttimizzata(DgvScrutinio, ClsScrutinio.Studenti, ClsScrutinio.Materie, ClsScrutinio.Voti);
            RidimensionaDgv(DgvScrutinio);
            RiempiCombo(cmbStudente, ClsScrutinio.Studenti);
            RiempiCombo(cmbMateria, ClsScrutinio.Materie);
        }

        private void RiempiCombo(ComboBox cmbStudente, string[] studenti)
        {
            for (int i = 0; i < studenti.Length; i++)
            {
                cmbStudente.Items.Add(studenti[i]);
            }
        }

        private void RidimensionaDgv(DataGridView dgv)
        {
            // resize di tutto il contenuto della griglia
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void CaricaDgv(DataGridView dgv, string[] studenti, string[] materie, int[,] voti)
        {
            dgv.ColumnCount = materie.Length;

            // intestazioni di riga
            for (int i = 0; i < studenti.Length; i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].HeaderCell.Value = studenti[i];
            }

            // intestazioni di colonna
            for (int i = 0; i < materie.Length; i++)
            {
                dgv.Columns[i].HeaderCell.Value = materie[i];
            }

            // voti
            for (int i = 0; i < voti.GetLength(0); i++)
            {
                for (int j = 0; j < voti.GetLength(1); j++)
                {
                    dgv.Rows[i].Cells[j].Value = voti[i, j];
                    //dgv[j, i].Value = voti[i, j];
                }
            }
        }

        private static void CaricaDgvOttimizzata(DataGridView dgv, string[] studenti, string[] materie, int[,] voti)
        {
            dgv.ColumnCount = materie.Length;

            for (int i = 0; i < studenti.Length; i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].HeaderCell.Value = studenti[i];
                for (int j = 0; j < materie.Length; j++)
                {
                    if(i == 0) dgv.Columns[j].HeaderCell.Value = materie[j];
                    dgv.Rows[i].Cells[j].Value = voti[i, j];
                    if(voti[i, j] >= 6)
                    {
                        dgv.Rows[i].Cells[j].Style.ForeColor = Color.Green;
                    }
                    else if(voti[i, j] < 5)
                    {
                        dgv.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgv.Rows[i].Cells[j].Style.ForeColor = Color.DarkOrange;
                    }
                }
            }
        }

        private void SettaDgv(DataGridView dgv)
        {
            // imposta la griglia in sola lettura
            dgv.ReadOnly = true;

            // setto la visualizzazione degli header
            dgv.RowHeadersVisible = true;
            dgv.ColumnHeadersVisible = true;

            // sfondo righe apri
            dgv.RowsDefaultCellStyle.BackColor = Color.LightGray;

            // sfondo righe dispari
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // evitare selezione iniziale cella
            dgv.ClearSelection();
        }

        private void btnContaEsiti_Click(object sender, EventArgs e)
        {
            int nPromossi = 0, nBocciati = 0, nRimandati = 0;

            ClsScrutinio.ContaEsiti(ref nPromossi, ref nBocciati, ref nRimandati);

            if (rdbBocciati.Checked) MessageBox.Show($"Ci sono {nBocciati} bocciati");
            else if (rdbRimandati.Checked) MessageBox.Show($"Ci sono {nRimandati} rimandati");
            else MessageBox.Show($"Ci sono {nPromossi} promossi");

        }

        private void cmbStudente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studenteSelezionato = cmbStudente.SelectedItem.ToString();
            int sommaVoti = 0, contaInsufficienze = 0;
            string elencoMatInsufficienti = "";

            for(int i = 0; i < ClsScrutinio.Materie.Length; i++)
            {
                int voto = ClsScrutinio.Voti[cmbStudente.SelectedIndex, i];
                sommaVoti += voto;
                if (voto < 6)
                {
                    contaInsufficienze++;
                    elencoMatInsufficienti += ClsScrutinio.Materie[i] + " ";
                }
            }

            string risultato;
            if (contaInsufficienze > 3) risultato = "BOCCIATO";
            else if(contaInsufficienze == 0) risultato = "PROMOSSO";
            else risultato = "RIMANDATO";

            double mediaVoti = (double)sommaVoti / ClsScrutinio.Materie.Length;

            Message box;
        }
    }
}
