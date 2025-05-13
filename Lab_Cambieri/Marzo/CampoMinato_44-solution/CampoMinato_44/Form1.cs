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
        static int DIM_CAMPO = 9;
        static int NUM_BOMB = 10;
        static int tentativi = 0;
        Random rnd= new Random();
        int[,] campo;
        int mosse=0; 


        public CampoMinato()
        {
            InitializeComponent();
        }

        private void CampoMinato_Load(object sender, EventArgs e)
        {
            /*SettaDgv();
            InizailizzaCampo();
            //MostraDgv();
            dgvCampoMinato.Enabled = true;*/
        }

        private void SettaDgv()
        {
            // imposto numero righe e colonne
            dgvCampoMinato.RowCount = DIM_CAMPO;
            dgvCampoMinato.ColumnCount = DIM_CAMPO;
            dgvCampoMinato.ReadOnly = true;
            dgvCampoMinato.RowHeadersVisible = false;
            dgvCampoMinato.ColumnHeadersVisible = false;
            dgvCampoMinato.AllowUserToResizeColumns=false;
            dgvCampoMinato.AllowUserToResizeRows = false;
            dgvCampoMinato.ScrollBars = ScrollBars.None;
            dgvCampoMinato.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            for(int i = 0; i < DIM_CAMPO; i++)
            {
                dgvCampoMinato.Columns[i].Width = dgvCampoMinato.Height / DIM_CAMPO;
                dgvCampoMinato.Rows[i].Height = dgvCampoMinato.Width / DIM_CAMPO;
            }
            dgvCampoMinato.ClearSelection();
        }

        private void InizailizzaCampo()
        {
            // Posizionamento delle bombe
            // 0 = no bombe in torno
            // -1 = bomba
            // 1->8 = bombe intorno
            int x, y;
            if (tentativi != 0)
            {
                RestCampo();
            }
                mosse = 0;
                for (int i = 0; i < NUM_BOMB; i++)
                {
                    do
                    {
                        x = rnd.Next(1, DIM_CAMPO + 1);
                        y = rnd.Next(1, DIM_CAMPO + 1);
                    } while (campo[x, y] == -1);
                    campo[x, y] = -1;
                }
                for (int i = 1; i <= DIM_CAMPO; i++)
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
        private void ResetValueDGV()
        {
            for (int i = 0; i < DIM_CAMPO; i++)
            {
                for (int j = 0; j < DIM_CAMPO; j++)
                {
                  dgvCampoMinato.Rows[i].Cells[j].Value= "";
                  dgvCampoMinato.Rows[i].Cells[j].Tag = null;
                }
            }
        }
        private void RestCampo()
        {
           for(int i = 0; i < DIM_CAMPO; i++)
            {
                for(int j = 0; j < DIM_CAMPO; j++)
                {
                    campo[i, j] = 0;
                    if(i < DIM_CAMPO && j < DIM_CAMPO)
                    {
                        dgvCampoMinato.Rows[i].Cells[j].Style.BackColor = Color.Empty;
                    }                   
                }
            }
        }

        private int ContaBombeVicino(int i, int j)
        {
            int cont = 0;
            for(int x=i-1; x<=i+1; x++)
            {
                for (int y = j-1; y <= j+1; y++)
                {
                    if(campo[x,y] == -1)
                    {
                        cont++;
                    }
                }
            }
            return cont;
        }

        private void btnInizia_Click(object sender, EventArgs e)
        {
            if(rdbEasy.Checked)
            {
                DIM_CAMPO = 10;
                NUM_BOMB = 10;
            }
            else if(rdbMedium.Checked)
            {
                DIM_CAMPO = 20;
                NUM_BOMB = 20;
            }
            else if(rdbHard.Checked)
            {
                DIM_CAMPO = 30;
                NUM_BOMB = 30;
            }
            else
            {
                MessageBox.Show("Seleziona un livello!!!");
                return;
            }
            campo = new int[DIM_CAMPO + 2, DIM_CAMPO + 2];
            SettaDgv();
            InizailizzaCampo();
            // MostraDgv();
            if(tentativi != 0)
            {
                dgvCampoMinato.Enabled = true;
                ResetValueDGV();
            }
            tentativi++;
        }

        private void MostraDgv()
        {
            for(int i=0; i<DIM_CAMPO; i++)
            {
                for(int j = 0; j < DIM_CAMPO; j++)
                {
                    dgvCampoMinato.Rows[i].Cells[j].Value = campo[i+1,j+1];
                }
            }
            
        }

        private void dgvCampoMinato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int riga = e.RowIndex;
            int colonna = e.ColumnIndex;
            int contenutoCella = campo[riga + 1, colonna + 1];
            //if(conenutoCella == -1)
            //{
            //    MessageBox.Show("Hai perso");
            //}
            switch (contenutoCella)
            {
                case -1:
                    dgvCampoMinato.ClearSelection();
                    dgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor= Color.Red;
                    MessageBox.Show("Hai perso");
                    MostraDgv();
                    dgvCampoMinato.Enabled= false;
                    break;
                case 0:
                    // per capire quando incrementare mosse posso:
                    // 1) test su back color = color.empty
                    // 2) usare il campo tag del dgv campo tag che serve per assegnare un valore alla cella
                    if (dgvCampoMinato.Rows[riga].Cells[colonna].Tag == null)
                    {
                        mosse++;
                        dgvCampoMinato.Rows[riga].Cells[colonna].Tag = "1";
                        dgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Green;
                        ControllaCelleLibereVicine(riga, colonna);
                    }                 
                    break;
                default:
                    dgvCampoMinato.Rows[riga].Cells[colonna].Value = campo[riga + 1, colonna + 1];
                    if (dgvCampoMinato.Rows[riga].Cells[colonna].Tag == null)
                    {
                        mosse++;
                        dgvCampoMinato.Rows[riga].Cells[colonna].Tag = "1";
                        dgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Yellow;
                    }
                    break;
            }

            dgvCampoMinato.ClearSelection();
            if(mosse == DIM_CAMPO*DIM_CAMPO - NUM_BOMB)
            {
                MessageBox.Show("Hai vinto");
                MostraDgv();
                dgvCampoMinato.Enabled = true;
            }
        }

        private void ControllaCelleLibereVicine(int riga, int colonna)
        {
            // Controllo in su
            int i = riga;
            do
            {
                for(int j = colonna; j < DIM_CAMPO; j++)
                {
                    int z = i;
                    do
                    {
                        if (dgvCampoMinato.Rows[riga].Cells[colonna].Tag == null)
                        {
                            mosse++;
                            dgvCampoMinato.Rows[riga].Cells[colonna].Tag = "1";
                            dgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Green;
                            ControllaCelleLibereVicine(riga, colonna);
                        }
                        z++;
                    } while (campo[z, j] != -1 || z < DIM_CAMPO);
                    int z = j;
                    do
                    {
                        if (dgvCampoMinato.Rows[riga].Cells[colonna].Tag == null)
                        {
                            mosse++;
                            dgvCampoMinato.Rows[riga].Cells[colonna].Tag = "1";
                            dgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Green;
                            ControllaCelleLibereVicine(riga, colonna);
                        }
                        z--;
                    } while (campo[z, j] != -1 || z < DIM_CAMPO);
                }
            }while (i < DIM_CAMPO);
        }
    }
}
