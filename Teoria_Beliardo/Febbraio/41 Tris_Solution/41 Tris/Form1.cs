using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _41_Tris
{
    public partial class FormTris : Form
    {
        char[,] trisT = new char[3, 3];
        const int NUM_RIGHE = 3;
        const int NUM_COLONNE = 3;
        // se turno % 2 == 0 --> X
        // se turno % 2 == 1 --> O
        int turno = 0;
        char ris;
        public FormTris()
        {
            InitializeComponent();
        }


        private void settaDgv()
        {
            dgv.RowCount = NUM_RIGHE; dgv.ColumnCount = NUM_COLONNE;

            for (int i = 0; i < NUM_RIGHE; i++)
            {
                dgv.Rows[i].Height = dgv.Size.Height / NUM_RIGHE;
                dgv.Columns[i].Width = dgv.Size.Width / NUM_COLONNE;
            }

            // nascondo intestazioni di riga e colonna
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;
            // nascondo le scrollBars
            dgv.ScrollBars = ScrollBars.None;
            // tolgo il resize a riga e colonna
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            // metto readonly al dgv
            dgv.ReadOnly = true;
            svuotaTris();
            visualizzaTris();
        }

        private void visualizzaTris()
        {
            for (int i = 0; i < NUM_RIGHE; i++)
            {
                for (int j = 0; j < NUM_COLONNE; j++)
                {
                    dgv.Rows[i].Cells[j].Value = trisT[i, j];
                }
            }
        }

        private void svuotaTris()
        {
            for(int i = 0; i < NUM_RIGHE; i++)
            {
                for (int j = 0; j < NUM_COLONNE; j++)
                {
                    trisT[i, j] = ' ';
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //individuare riga e colonna della cella cliccata
            int i = dgv.CurrentCell.RowIndex;//ci dice qual'è la riga
            int j = dgv.CurrentCell.ColumnIndex;//ci dice qual'è la cella

            if (trisT[i,j] == ' ')
            {
                turno++;
                if (turno % 2 == 0)
                {
                    trisT[i,j] = 'X';
                } 
                else
                {
                    trisT[i,j] = 'O';
                }
                dgv.Rows[i].Cells[j].Value = trisT[i,j];

                //controllo vittoria
                if(turno >= 5)
                {
                    ris = chiVince(turno);
                    if(ris != '-')
                    {
                        lblRisulatato.Text = $"{ris} ha fatto tris, quindi ha vinto";
                        dgv.Enabled = false;
                    }
                    else if(turno == 9)
                    {
                        lblRisulatato.Text = "Pareggio";
                        dgv.Enabled = false;
                    }
                }
            }
        }

        private char chiVince(int turno)
        {
            char ch;
            ch = turno % 2 == 0 ? 'X' : 'O';
            if ((trisT[0,0] == ch && trisT[0,1] == ch && trisT[1,0] == ch) || // tris riga 0
                (trisT[1,0] == ch && trisT[1,1] == ch && trisT[1,2] == ch) || // tris riga 1
                (trisT[2,0] == ch && trisT[2,1] == ch && trisT[2,2] == ch) || // tris riga 2
                (trisT[0,0] == ch && trisT[1,0] == ch && trisT[2,0] == ch) || // tris colonna 0
                (trisT[0,1] == ch && trisT[1,1] == ch && trisT[2,1] == ch) || // tris colonna 1
                (trisT[0,2] == ch && trisT[1,2] == ch && trisT[2,2] == ch) || // tris colonna 2
                (trisT[0,0] == ch && trisT[1,1] == ch && trisT[2,2] == ch) || // tris diagonale principale
                (trisT[0,2] == ch && trisT[1,1] == ch && trisT[2,0] == ch)) // tris diagonale secondaria
            {
                return ch;
            }
            else
            {
                return '-';
            }
        }

        private void btnInizia_Click(object sender, EventArgs e)
        {
            svuotaTris();
            visualizzaTris();
            lblRisulatato.Text = " ";
            turno = 0;
            dgv.Enabled = true;
        }

        private void FormTris_Load(object sender, EventArgs e)
        {
            settaDgv();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv.ClearSelection();//toglie la selezione
        }
    }
}
