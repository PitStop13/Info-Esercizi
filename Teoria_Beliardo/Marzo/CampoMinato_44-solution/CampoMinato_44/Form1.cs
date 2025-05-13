using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato_44
{
    public partial class CampoMinato : Form
    {
        const int DIM_CAMPO = 9;
        const int NUM_BOMB = 10;
        Random rnd= new Random();
        int[,] campo = new int[DIM_CAMPO + 2, DIM_CAMPO + 2];
        int mosse;

        public CampoMinato()
        {
            InitializeComponent();
            SettaDgv();
        }

        private void SettaDgv()
        {
            // Imposto num righe e colonne
            DgvCampoMinato.ColumnCount = DIM_CAMPO;
            DgvCampoMinato.RowCount = DIM_CAMPO;

            // Imposto la griglia in sola lettura
            DgvCampoMinato.ReadOnly = true;

            // Nascondo header di riga e colonna
            DgvCampoMinato.RowHeadersVisible = false;
            DgvCampoMinato.ColumnHeadersVisible = false;

            // Evitare il ridimensianmento delle celle
            DgvCampoMinato.AllowUserToResizeRows = false;
            DgvCampoMinato.AllowUserToResizeColumns = false;

            // Disabilito le scroll bars
            DgvCampoMinato.ScrollBars = ScrollBars.None;


            DgvCampoMinato.Width = 360;
            DgvCampoMinato.Height = 360;

            // Imposto la dimensione delle celle
            for (int i = 0; i < DIM_CAMPO; i++)
            {
                DgvCampoMinato.Columns[i].Width = DgvCampoMinato.Height / DIM_CAMPO;
                DgvCampoMinato.Rows[i].Height = DgvCampoMinato.Width / DIM_CAMPO;
            }

            DgvCampoMinato.ClearSelection();
        }

        private void CampoMinato_Load(object sender, EventArgs e)
        {
            SettaDgv();
            InizializzaCampo();
            //MostraDgv();
            ResetValueDgv();
        }

        private void ResetValueDgv()
        {
            for (int i = 0; i < DIM_CAMPO; i++)
            {
                for (int j = 0; j < DIM_CAMPO; j++)
                {
                    DgvCampoMinato.Rows[i].Cells[j].Value = "";
                    DgvCampoMinato.Rows[i].Cells[j].Tag = null;
                }
            }
        }

        private void InizializzaCampo()
        {
            // Posizionamento delle bombe
            // 0 = no bombe in torno
            // -1 = bomba
            // 1->8 = bombe intorno

            int x, y;

            ResetCampo();
            mosse = 0;
            for (int i = 0; i < NUM_BOMB; i++)
            {
                do
                {
                    x = rnd.Next(1, DIM_CAMPO + 1);
                    y = rnd.Next(1, DIM_CAMPO + 1);
                } while (campo[x,y] == -1);
                campo[x,y] = -1;
            }

            for(int i = 1; i <= DIM_CAMPO; i++)
            {
                for (int j = 1; j <= DIM_CAMPO; j++)
                {
                    if (campo[i, j] != -1)
                    {
                        campo[i, j] = ContaBombeVicino(i, j);
                    }
                }
            }
        }

        private void ResetCampo()
        {
            for (int i = 0; i < DIM_CAMPO; i++)
            {
                for (int j = 0; j < DIM_CAMPO; j++)
                {
                    campo[i, j] = 0;
                    if(i < DIM_CAMPO && j < DIM_CAMPO)
                    {
                        DgvCampoMinato.Rows[i].Cells[j].Style.BackColor = Color.Empty;
                    }
                }
            }
        }

        private int ContaBombeVicino(int i, int j)
        {
            int contatore = 0;
            for(int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; j++)
                {
                    if (campo[x,y] == -1)
                    {
                        contatore++;
                    }
                }
            }
            return contatore;
        }

        private void btnInizia_Click(object sender, EventArgs e)
        {
            InizializzaCampo();
            //MostraDgv();
            DgvCampoMinato.Enabled = true;
        }

        private void MostraDgv()
        {
            for (int i = 1; i <= DIM_CAMPO; i++)
            {
                for (int j = 1; j <= DIM_CAMPO; j++)
                {
                    DgvCampoMinato.Rows[i].Cells[j].Value = campo[i + 1, j + 1];
                }
            }
        }

        private void DgvCampoMinato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvCampoMinato.ClearSelection();
            int riga = e.RowIndex;
            int colonna = e.ColumnIndex;
            int contenutoCella = campo[riga + 1, colonna + 1];

            switch(contenutoCella)
            {
                case -1:
                    DgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Red;
                    MessageBox.Show("Hai perso!");
                    MostraDgv();
                    DgvCampoMinato.Enabled = false;
                    break;
                case 0:
                    // Per capire quando incrementare mosse posso:
                    // 1) fare un test su  BackColor = Color.Empty
                    // OPPURE 
                    // 2) Utilizzare il campo Tag dell'oggetto DgvCampoMinato, che serve per assegare un valore alla cella, ci serve a capire se l'utente ha già fatto click sulla cella o meno
                    if (DgvCampoMinato.Rows[riga].Cells[colonna].Tag == null)
                    {
                        mosse++;
                        DgvCampoMinato.Rows[riga].Cells[colonna].Tag = "1";
                        DgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Green;
                    }
                    break;
                default:
                    DgvCampoMinato.Rows[riga].Cells[colonna].Value = campo[riga + 1, colonna + 1];
                    if (DgvCampoMinato.Rows[riga].Cells[colonna].Tag == null)
                    {
                        mosse++;
                        DgvCampoMinato.Rows[riga].Cells[colonna].Tag = "1";
                        DgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Yellow;
                    }
                    break;
            }

            if(mosse == DIM_CAMPO * DIM_CAMPO - NUM_BOMB)
            {
                MessageBox.Show("Hai vinto!!");
                MostraDgv();
                DgvCampoMinato.Enabled = false;
            }
        }
    }
}
