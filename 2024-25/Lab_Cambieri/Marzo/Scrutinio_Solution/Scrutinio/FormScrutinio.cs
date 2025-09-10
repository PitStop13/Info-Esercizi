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
                    if (i == 0) dgv.Columns[j].HeaderCell.Value = materie[j];
                    dgv.Rows[i].Cells[j].Value = voti[i, j];
                    if (voti[i, j] >= 6)
                    {
                        dgv.Rows[i].Cells[j].Style.ForeColor = Color.Green;
                    }
                    else if (voti[i, j] < 5)
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
            if (contaInsufficienze > 3) risultato = "BOCCIATO";
            else if (contaInsufficienze == 0) risultato = "PROMOSSO";
            else risultato = "RIMANDATO";

            double mediaVoti = (double)sommaVoti / ClsScrutinio.Materie.Length;

            if (contaInsufficienze == 0)
            {
                MessageBox.Show($"L'alunno {cmbStudente.SelectedItem.ToString()} è {risultato}\nLa sua media è {mediaVoti.ToString("N2")}");
            }
            else if (contaInsufficienze == 1)
            {
                MessageBox.Show($"L'alunno {cmbStudente.SelectedItem.ToString()} è {risultato}\nLa sua media è {mediaVoti.ToString("N2")}\nLa sua materia insufficiente è {elencoMatInsufficienti}");
            }
            else
            {
                MessageBox.Show($"L'alunno {cmbStudente.SelectedItem.ToString()} è {risultato}\nLa sua media è {mediaVoti.ToString("N2")}\nLe sue materie insufficienti sono: {elencoMatInsufficienti}");
            }
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string materia = cmbMateria.SelectedItem.ToString();
            int sommaVoti = 0, contaInsufficienze = 0;
            string elencoStudInsufficienti = "";

            for (int i = 0; i < ClsScrutinio.Studenti.Length; i++)
            {
                int voto = ClsScrutinio.Voti[i, cmbMateria.SelectedIndex];
                sommaVoti += voto;
                if (voto < 6)
                {
                    contaInsufficienze++;
                    elencoStudInsufficienti += ClsScrutinio.Studenti[i] + " ";
                }
            }

            double mediaVoti = (double)sommaVoti / ClsScrutinio.Studenti.Length;

            if (contaInsufficienze == 0)
            {
                MessageBox.Show($"La materia {cmbMateria.SelectedItem.ToString()} non ha insufficienze\nLa sua media è {mediaVoti.ToString("N2")}");
            }
            else if (contaInsufficienze == 1)
            {
                MessageBox.Show($"La materia {cmbMateria.SelectedItem.ToString()} ha {contaInsufficienze} insufficienze\nLa sua media è {mediaVoti.ToString("N2")}\nL'alunno insufficiente è {elencoStudInsufficienti}");
            }
            else
            {
                MessageBox.Show($"La materia {cmbMateria.SelectedItem.ToString()} ha {contaInsufficienze} insufficienze\nLa sua media è {mediaVoti.ToString("N2")}\nGli alunni insufficienti sono: {elencoStudInsufficienti}");
            }
        }

        private void btnMateriaBalorda_Click(object sender, EventArgs e)
        {
            int maxStudInsufficienti = int.MinValue, contaMatInsufficienti = 0;
            string elencoMatBalorda = "";
            for (int i = 0; i < ClsScrutinio.Materie.Length; i++)
            {
                int studInsufficienti = 0;
                for (int j = 0; j < ClsScrutinio.Studenti.Length; j++)
                {
                    if (ClsScrutinio.Voti[j, i] < 6) studInsufficienti++;
                }

                if (studInsufficienti > maxStudInsufficienti)
                {
                    elencoMatBalorda = ClsScrutinio.Materie[i] + " ";
                    maxStudInsufficienti = studInsufficienti;
                    contaMatInsufficienti = 1;
                }
                else if (studInsufficienti == maxStudInsufficienti)
                {
                    elencoMatBalorda += ClsScrutinio.Materie[i] + " ";
                    contaMatInsufficienti++;
                }
            }

            if (contaMatInsufficienti == ClsScrutinio.Materie.Length)
            {
                MessageBox.Show($"Le materie sono tutte sufficienti, quindi non c'è una materia balorda");
            }
            else if (contaMatInsufficienti == 1)
            {
                MessageBox.Show($"La materia Balorda è {elencoMatBalorda}\nIl suo numero di insufficienti è {maxStudInsufficienti}");
            }
            else
            {
                MessageBox.Show($"Le materie Balorde sono: {elencoMatBalorda}\nIl loro numero di insufficienti è {maxStudInsufficienti}");
            }
        }

        private void btnVotoTraDue_Click(object sender, EventArgs e)
        {
            int selectedCellsCount = DgvScrutinio.GetCellCount(DataGridViewElementStates.Selected);

            if (selectedCellsCount != 16)
            {
                MessageBox.Show("Devi selezionare due studenti da confrontare!!!");
                return;
            }

            int index2 = DgvScrutinio.SelectedRows[0].Index;
            int index1 = DgvScrutinio.SelectedRows[1].Index;
            double media1 = 0;
            double media2 = 0;

            for (int i = 0; i < ClsScrutinio.Materie.Length; i++)
            {
                media1 += ClsScrutinio.Voti[index1, i];
                media2 += ClsScrutinio.Voti[index2, i];
            }

            media1 = media1 / ClsScrutinio.Materie.Length;
            media2 = media2 / ClsScrutinio.Materie.Length;

            if (media1 > media2)
            {
                MessageBox.Show($"{ClsScrutinio.Studenti[index1]} ha la media superiore a quella di {ClsScrutinio.Studenti[index2]}.\nLa media di {ClsScrutinio.Studenti[index1]} è: {media1}\nLa media di {ClsScrutinio.Studenti[index2]} è: {media2}");
            }
            else
            {
                if (media1 == media2)
                {
                    MessageBox.Show($"{ClsScrutinio.Studenti[index1]} e di {ClsScrutinio.Studenti[index2]} è uguale.\nLa media di {ClsScrutinio.Studenti[index1]} è: {media1}\nLa media di {ClsScrutinio.Studenti[index2]} è: {media2}");
                }
                else
                {
                    MessageBox.Show($"{ClsScrutinio.Studenti[index2]} ha la media superiore a quella di {ClsScrutinio.Studenti[index1]}.\nLa media di {ClsScrutinio.Studenti[index1]} è: {media1}\nLa media di {ClsScrutinio.Studenti[index2]} è: {media2}");
                }
            }
        }

        private void btnStudSuGiu_Click(object sender, EventArgs e)
        {
            double[] mediaVotiStud = new double[ClsScrutinio.Studenti.Length];
            double maxMediaStud = int.MinValue, minMediaStud = int.MaxValue;
            string elencoStudMediaMax = "", elencoStudMediaMin = "", mediaMax = "", mediaMin = "";
            int contaStudMediaMax = 0, contaStudMediaMin = 0;

            for (int i = 0; i < ClsScrutinio.Studenti.Length; i++)
            {
                for (int j = 0; j < ClsScrutinio.Materie.Length; j++)
                {
                    mediaVotiStud[i] += ClsScrutinio.Voti[i, j];
                }
                mediaVotiStud[i] = mediaVotiStud[i] / ClsScrutinio.Materie.Length;
                if (mediaVotiStud[i] > maxMediaStud)
                {
                    elencoStudMediaMax = ClsScrutinio.Studenti[i] + " ";
                    mediaMax = mediaVotiStud[i].ToString("N2") + " ";
                    contaStudMediaMax = 1;
                    maxMediaStud = mediaVotiStud[i];
                }
                else if (mediaVotiStud[i] == maxMediaStud)
                {
                    elencoStudMediaMax += ClsScrutinio.Studenti[i] + " ";
                    contaStudMediaMax++;
                }

                if (mediaVotiStud[i] < minMediaStud)
                {
                    elencoStudMediaMin = ClsScrutinio.Studenti[i] + " ";
                    mediaMin = mediaVotiStud[i].ToString("N2") + " ";
                    contaStudMediaMin = 1;
                    minMediaStud = mediaVotiStud[i];
                }
                else if (mediaVotiStud[i] == minMediaStud)
                {
                    elencoStudMediaMin += ClsScrutinio.Studenti[i] + " ";
                    contaStudMediaMin++;
                }
            }

            if (contaStudMediaMax == 1)
            {
                if (contaStudMediaMin == 1) MessageBox.Show($"L'alunno con la media totale più alta è {elencoStudMediaMax}\nLa sua media è {mediaMax}\nL'alunno con la media totale più bassa è {elencoStudMediaMin}\nLa sua media è {mediaMin}");
                else MessageBox.Show($"L'alunno con la media totale più alta è {elencoStudMediaMax}\nLa sua media è {mediaMax}\nGli alunni con la media totale più bassa sono: {elencoStudMediaMin}\nLa loro media è {mediaMin}");
            }
            else
            {
                if (contaStudMediaMin == 1) MessageBox.Show($"Gli alunni con la media totale più alta sono: {elencoStudMediaMax}\nLa loro media è {mediaMax}\nL'alunno con la media totale più bassa è {elencoStudMediaMin}\nLa sua media è {mediaMin}");
                else MessageBox.Show($"Gli alunni con la media totale più alta sono: {elencoStudMediaMax}\nLa loro media è {mediaMax}\nGli alunni con la media totale più bassa sono: {elencoStudMediaMin}\nLa loro media è {mediaMin}");
            }
        }
    }
}
