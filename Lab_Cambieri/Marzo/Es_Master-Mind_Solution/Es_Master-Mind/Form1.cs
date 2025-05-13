using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Es_Master_Mind
{
    public partial class Form_MasterMind : Form
    {
        const int DIM_ROW = 7, DIM_COL = 4;
        string[] sequenza = new string[4];
        Random rand = new Random();
        bool vinto = false;
        bool[] controlledRow = {false, false, false, false, false, false, false};
        public Form_MasterMind()
        {
            InitializeComponent();
        }

        private void DgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvInput.ClearSelection();
            if (!vinto && !controlledRow[DgvInput.CurrentCell.RowIndex])
            {
                if (DgvInput.CurrentCell.Style.BackColor == Color.Empty)
                {
                    DgvInput.CurrentCell.Style.BackColor = Color.Red;
                }
                else if (DgvInput.CurrentCell.Style.BackColor == Color.Red)
                {
                    DgvInput.CurrentCell.Style.BackColor = Color.Yellow;
                }
                else if (DgvInput.CurrentCell.Style.BackColor == Color.Yellow)
                {
                    DgvInput.CurrentCell.Style.BackColor = Color.Green;
                }
                else if (DgvInput.CurrentCell.Style.BackColor == Color.Green)
                {
                    DgvInput.CurrentCell.Style.BackColor = Color.Blue;
                }
                else if (DgvInput.CurrentCell.Style.BackColor == Color.Blue)
                {
                    DgvInput.CurrentCell.Style.BackColor = Color.Red;
                }
            }
        }

        private void Form_MasterMind_Load(object sender, EventArgs e)
        {
            SettaDgv();
        }

        private void btnRow1_Click(object sender, EventArgs e)
        {
            ControllaRowDgv(0);
            btnRow1.Enabled = false;
        }

        private void ControllaRowDgv(int row)
        {
            int firstEmptyCell = 0;
            for (int i = 0; i < DIM_COL; i++)
            {
                if (DgvInput.Rows[row].Cells[i].Style.BackColor == Color.Red && sequenza[i] == "Red")
                {
                    DgvRisultato.Rows[row].Cells[firstEmptyCell].Style.BackColor = Color.Black;
                    firstEmptyCell++;
                }
                else if (DgvInput.Rows[row].Cells[i].Style.BackColor == Color.Yellow && sequenza[i] == "Yellow")
                {
                    DgvRisultato.Rows[row].Cells[firstEmptyCell].Style.BackColor = Color.Black;
                    firstEmptyCell++;
                }
                else if (DgvInput.Rows[row].Cells[i].Style.BackColor == Color.Green && sequenza[i] == "Green")
                {
                    DgvRisultato.Rows[row].Cells[firstEmptyCell].Style.BackColor = Color.Black;
                    firstEmptyCell++;
                }
                else if (DgvInput.Rows[row].Cells[i].Style.BackColor == Color.Blue && sequenza[i] == "Blue")
                {
                    DgvRisultato.Rows[row].Cells[firstEmptyCell].Style.BackColor = Color.Black;
                    firstEmptyCell++;
                }
            }

            controlledRow[row] = true;

            if (firstEmptyCell == 4)
            {
                MessageBox.Show($"Hai vinto la sequenza era: {sequenza[0]}, {sequenza[1]}, {sequenza[2]}, {sequenza[3]}");
                btnRow1.Enabled = btnRow2.Enabled = btnRow3.Enabled = btnRow4.Enabled = btnRow5.Enabled = btnRow6.Enabled = btnRow7.Enabled = false;
                vinto = true;
                return;
            }
            else if(row == 6)
            {
                MessageBox.Show($"Hai perso la sequenza era: {sequenza[0]}, {sequenza[1]}, {sequenza[2]}, {sequenza[3]}");
                return;
            }
        }

        private void btnRow2_Click(object sender, EventArgs e)
        {
            ControllaRowDgv(1);
            btnRow2.Enabled = false;
        }

        private void btnRow3_Click(object sender, EventArgs e)
        {
            ControllaRowDgv(2);
            btnRow3.Enabled = false;
        }

        private void btnRow4_Click(object sender, EventArgs e)
        {
            ControllaRowDgv(3);
            btnRow4.Enabled = false;
        }

        private void btnRow5_Click(object sender, EventArgs e)
        {
            ControllaRowDgv(4);
            btnRow5.Enabled = false;
        }

        private void btnRow6_Click(object sender, EventArgs e)
        {
            ControllaRowDgv(5);
            btnRow6.Enabled = false;
        }

        private void btnRow7_Click(object sender, EventArgs e)
        {
            ControllaRowDgv(6);
            btnRow7.Enabled = false;
        }

        private void SettaDgv()
        {
            // Imposto grandezza righe e colonne
            DgvInput.RowCount = DIM_ROW;
            DgvInput.ColumnCount = DIM_COL;
            DgvRisultato.RowCount = DIM_ROW;
            DgvRisultato.ColumnCount = DIM_COL;

            for (int i = 0; i < DIM_ROW; i++)
            {
                DgvInput.Rows[i].Height = (DgvInput.Height - 1) / DIM_ROW;
                DgvRisultato.Rows[i].Height = (DgvInput.Height - 1) / DIM_ROW;
            }

            for (int i = 0; i < DIM_COL; i++)
            {
                DgvInput.Columns[i].Width = (DgvInput.Width - 1) / DIM_COL;
                DgvRisultato.Columns[i].Width = (DgvInput.Width - 1) / DIM_COL;
            }

            // Genero una sequenza
            for (int i = 0; i < DIM_COL; i++)
            {
                int val = rand.Next(0, 4);
                switch(val)
                {
                    case 0:
                        sequenza[i] = "Red";
                        break;
                    case 1:
                        sequenza[i] = "Yellow";
                        break;
                    case 2:
                        sequenza[i] = "Green";
                        break;
                    case 3:
                        sequenza[i] = "Blue";
                        break;
                }
            }

            DgvInput.ClearSelection();
            DgvRisultato.ClearSelection();
        }
    }
}
