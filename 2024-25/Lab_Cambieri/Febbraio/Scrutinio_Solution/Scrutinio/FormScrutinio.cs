using System;
using System.Drawing;
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

        private void RiempiCombo(ComboBox cmb, string[] valori)
        {
            foreach (string valore in valori)
            {
                cmb.Items.Add(valore);
            }
        }

        private void RidimensionaDgv(DataGridView dgv)
        {
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
                    if (i == 0)
                        dgv.Columns[j].HeaderCell.Value = materie[j];

                    dgv.Rows[i].Cells[j].Value = voti[i, j];

                    if (voti[i, j] >= 6)
                        dgv.Rows[i].Cells[j].Style.ForeColor = Color.Green;
                    else if (voti[i, j] < 5)
                        dgv.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                    else
                        dgv.Rows[i].Cells[j].Style.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void SettaDgv(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = true;
            dgv.ColumnHeadersVisible = true;
            dgv.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ClearSelection();
        }

        private void btnContaEsiti_Click(object sender, EventArgs e)
        {
            int nPromossi = 0, nBocciati = 0, nRimandati = 0;
            ClsScrutinio.ContaEsiti(ref nPromossi, ref nBocciati, ref nRimandati);

            if (rdbBocciati.Checked)
                MessageBox.Show($"Ci sono {nBocciati} bocciati");
            else if (rdbRimandati.Checked)
                MessageBox.Show($"Ci sono {nRimandati} rimandati");
            else
                MessageBox.Show($"Ci sono {nPromossi} promossi");
        }

        private void cmbStudente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studenteSelezionato = cmbStudente.SelectedItem.ToString();
            int sommaVoti = 0, contaInsufficienze = 0;
            string elencoMatInsufficienti = "";

            for (int i = 0; i < ClsScrutinio.Materie.Length; i++)
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
            if (contaInsufficienze > 3)
                risultato = "BOCCIATO";
            else if (contaInsufficienze == 0)
                risultato = "PROMOSSO";
            else
                risultato = "RIMANDATO";

            double mediaVoti = (double)sommaVoti / ClsScrutinio.Materie.Length;

            MessageBox.Show(
                $"Studente: {studenteSelezionato}\n" +
                $"Media voti: {mediaVoti:F2}\n" +
                $"Insufficienze: {contaInsufficienze}\n" +
                $"Materie insufficienti: {elencoMatInsufficienti}\n" +
                $"Esito: {risultato}",
                "Dettaglio studente");
        }
    }
}
