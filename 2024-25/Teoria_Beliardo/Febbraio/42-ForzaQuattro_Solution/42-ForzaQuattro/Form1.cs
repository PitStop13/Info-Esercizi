using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _42_ForzaQuattro
{
   
    public partial class ForzaQuattro : Form
    {
        private const int NUM_ROW = 6;
        private const int NUM_COL = 7;
        char[,] f4 = new char[NUM_ROW, NUM_COL];
        private int turno = 0;
        private string ris;
        public ForzaQuattro()
        {
            InitializeComponent();
        }

        private void ForzaQuattro_Load(object sender, EventArgs e)
        {
            setDgv();
        }

        private void setDgv()
        {
            DgvGioco.RowCount = NUM_ROW; DgvGioco.ColumnCount = NUM_COL;

            for (int i = 0; i < NUM_ROW; i++)
            {
                DgvGioco.Rows[i].Height = DgvGioco.Size.Height / NUM_ROW;
                DgvGioco.Columns[i].Width = DgvGioco.Size.Width / NUM_COL;
            }

            // nascondo intestazioni di riga e colonna
            DgvGioco.RowHeadersVisible = false;
            DgvGioco.ColumnHeadersVisible = false;
            // nascondo le scrollBars
            DgvGioco.ScrollBars = ScrollBars.None;
            // tolgo il resize a riga e colonna
            DgvGioco.AllowUserToResizeColumns = false;
            DgvGioco.AllowUserToResizeRows = false;
            // metto readonly al dgv
            DgvGioco.ReadOnly = true;
            svuotaF4();
            visualizzaF4();
        }

        private void visualizzaF4()
        {
            for (int i = 0; i < NUM_ROW; i++)
            {
                for (int j = 0; j < NUM_COL; j++)
                {
                    DgvGioco.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        private void svuotaF4()
        {
            for (int i = 0; i < NUM_ROW; i++)
            {
                for (int j = 0; j < NUM_COL; j++)
                {
                    f4[i, j] = ' ';
                }
            }
        }

        private void DgvGioco_SelectionChanged(object sender, EventArgs e)
        {
                DgvGioco.ClearSelection();//toglie la selezione
        }

        private void DgvGioco_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblRisultato.Text = "";
            //individuare colonna della cella cliccata e la prima riga libera
            int i = NUM_ROW - 1;
            int j = DgvGioco.CurrentCell.ColumnIndex;

            while (i > 0 && f4[i, j] != ' ')
            {
                i--;
            }

            if(i == 0 && f4[i, j] != ' ')
            {
                lblRisultato.Text = "Non puoi metterti in questa colonna perchè è piena";
            }
            else
            {
                if (f4[i, j] == ' ')
                {
                    turno++;
                    if (turno % 2 != 0) f4[i, j] = 'R';
                    else f4[i, j] = 'G';
                    DgvGioco.Rows[i].Cells[j].Style.BackColor = f4[i, j] == 'R' ? Color.Red : Color.Yellow;

                    if (turno >= 7)
                    {
                        ris = chiVince(turno, i, j);
                        if (ris == "-" && turno == 42)
                        {
                            lblRisultato.Text = "Pareggio";
                            DgvGioco.Enabled = false;
                        }
                        else if(ris != "-")
                        {
                            lblRisultato.Text = $"{ris} ha vinto!!";
                            DgvGioco.Enabled = false;
                        }
                    }
                }
            }
        }

        private string chiVince(int turno, int row, int col)
        {
            string str = turno % 2 != 0 ? "Rosso" : "Giallo";
            int cont = 0;

            //controllo se hai vinto sulla colonna
            int i = 0;
            while (cont < 4 && i < NUM_ROW)
            {
                if (f4[row, col] == f4[i, col])
                {
                    cont++;
                }
                else
                {
                    cont = 0;
                }
                i++;
            }

            if(cont == 4)
            {
                return str;
            }

            //controllo se hai vinto sulla riga
            cont = 0;
            i = 0;
            while (cont < 4 && i < NUM_COL)
            {
                if (f4[row, col] == f4[row, i])
                {
                    cont++;
                }
                else
                {
                    cont = 0;
                }
                i++;
            }

            if (cont == 4)
            {
                return str;
            }

            //controllo se hai vinto in diagonale principale
            cont = 0;
            i = 0;
            int[] start = { row, col };

            while(start[0] > 0 && start[1] > 0)
            {
                start[0]--;
                start[1]--;
            }

            int contRow = start[0];
            int contCol = start[1];
            while (cont < 4 && contRow < NUM_ROW && contCol < NUM_COL)
            {
                if (f4[row, col] == f4[contRow, contCol])
                {
                    cont++;
                }
                else
                {
                    cont = 0;
                }
                contRow++;
                contCol++;
            }

            if (cont == 4)
            {
                return str;
            }

            //controllo se hai vinto in diagonale secondaria
            cont = 0;
            i = 0;
            start[0] = row;
            start[1] = col;

            while (start[0] > 0 && start[1] < NUM_COL - 1)
            {
                start[0]--;
                start[1]++;
            }

            contRow = start[0];
            contCol = start[1];
            while (cont < 4 && contRow < NUM_ROW && contCol >= 0)
            {
                if (f4[row, col] == f4[contRow, contCol])
                {
                    cont++;
                }
                else
                {
                    cont = 0;
                }
                contRow++;
                contCol--;
            }

            if (cont == 4)
            {
                return str;
            }
            else
            {
                return "-";
            }
        }

        private void btnInizia_Click(object sender, EventArgs e)
        {
            DgvGioco.Enabled = true;
            setDgv();
            lblRisultato.Text = "";
            turno = 0;
        }
    }
}
