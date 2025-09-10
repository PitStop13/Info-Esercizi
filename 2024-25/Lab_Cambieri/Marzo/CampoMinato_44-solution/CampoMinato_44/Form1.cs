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
        Random rnd = new Random();
        int[,] campo;
        int mosse = 0;

        public CampoMinato()
        {
            InitializeComponent();
        }

        private void CampoMinato_Load(object sender, EventArgs e)
        {
            // L’inizializzazione avviene col pulsante Inizia
        }

        private void SettaDgv()
        {
            dgvCampoMinato.RowCount = DIM_CAMPO;
            dgvCampoMinato.ColumnCount = DIM_CAMPO;
            dgvCampoMinato.ReadOnly = true;
            dgvCampoMinato.RowHeadersVisible = false;
            dgvCampoMinato.ColumnHeadersVisible = false;
            dgvCampoMinato.AllowUserToResizeColumns = false;
            dgvCampoMinato.AllowUserToResizeRows = false;
            dgvCampoMinato.ScrollBars = ScrollBars.None;
            dgvCampoMinato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < DIM_CAMPO; i++)
            {
                dgvCampoMinato.Columns[i].Width = dgvCampoMinato.Width / DIM_CAMPO;
                dgvCampoMinato.Rows[i].Height = dgvCampoMinato.Height / DIM_CAMPO;
            }

            dgvCampoMinato.ClearSelection();
        }

        private void InizailizzaCampo()
        {
            campo = new int[DIM_CAMPO + 2, DIM_CAMPO + 2]; // +2 per i bordi esterni fittizi
            mosse = 0;

            // Posiziona bombe
            int x, y;
            for (int i = 0; i < NUM_BOMB; i++)
            {
                do
                {
                    x = rnd.Next(1, DIM_CAMPO + 1);
                    y = rnd.Next(1, DIM_CAMPO + 1);
                } while (campo[x, y] == -1);
                campo[x, y] = -1;
            }

            // Conta bombe adiacenti
            for (int i = 1; i <= DIM_CAMPO; i++)
            {
                for (int j = 1; j <= DIM_CAMPO; j++)
                {
                    if (campo[i, j] != -1)
                        campo[i, j] = ContaBombeVicino(i, j);
                }
            }
        }

        private int ContaBombeVicino(int i, int j)
        {
            int cont = 0;
            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if (campo[x, y] == -1)
                        cont++;
                }
            }
            return cont;
        }

        private void ResetValueDGV()
        {
            for (int i = 0; i < DIM_CAMPO; i++)
            {
                for (int j = 0; j < DIM_CAMPO; j++)
                {
                    dgvCampoMinato.Rows[i].Cells[j].Value = "";
                    dgvCampoMinato.Rows[i].Cells[j].Tag = null;
                    dgvCampoMinato.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        private void RestCampo()
        {
            for (int i = 0; i < DIM_CAMPO + 2; i++)
            {
                for (int j = 0; j < DIM_CAMPO + 2; j++)
                {
                    campo[i, j] = 0;
                }
            }
        }

        private void btnInizia_Click(object sender, EventArgs e)
        {
            if (rdbEasy.Checked)
            {
                DIM_CAMPO = 10;
                NUM_BOMB = 10;
            }
            else if (rdbMedium.Checked)
            {
                DIM_CAMPO = 20;
                NUM_BOMB = 40;
            }
            else if (rdbHard.Checked)
            {
                DIM_CAMPO = 30;
                NUM_BOMB = 90;
            }
            else
            {
                MessageBox.Show("Seleziona un livello!");
                return;
            }

            campo = new int[DIM_CAMPO + 2, DIM_CAMPO + 2];

            SettaDgv();
            InizailizzaCampo();

            dgvCampoMinato.Enabled = true;
            ResetValueDGV();

            tentativi++;
        }

        private void MostraDgv()
        {
            for (int i = 0; i < DIM_CAMPO; i++)
            {
                for (int j = 0; j < DIM_CAMPO; j++)
                {
                    dgvCampoMinato.Rows[i].Cells[j].Value = campo[i + 1, j + 1];
                }
            }
        }

        private void dgvCampoMinato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int riga = e.RowIndex;
            int colonna = e.ColumnIndex;

            if (riga < 0 || colonna < 0) return;

            int contenutoCella = campo[riga + 1, colonna + 1];

            switch (contenutoCella)
            {
                case -1:
                    dgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Red;
                    MessageBox.Show("Hai perso!");
                    MostraDgv();
                    dgvCampoMinato.Enabled = false;
                    break;

                case 0:
                    ScopriZonaLibera(riga, colonna);
                    break;

                default:
                    if (dgvCampoMinato.Rows[riga].Cells[colonna].Tag == null)
                    {
                        dgvCampoMinato.Rows[riga].Cells[colonna].Value = contenutoCella;
                        dgvCampoMinato.Rows[riga].Cells[colonna].Style.BackColor = Color.Yellow;
                        dgvCampoMinato.Rows[riga].Cells[colonna].Tag = "1";
                        mosse++;
                    }
                    break;
            }

            dgvCampoMinato.ClearSelection();

            if (mosse == DIM_CAMPO * DIM_CAMPO - NUM_BOMB)
            {
                MessageBox.Show("Hai vinto!");
                MostraDgv();
                dgvCampoMinato.Enabled = false;
            }
        }

        private void ScopriZonaLibera(int riga, int colonna)
        {
            Queue<(int, int)> daControllare = new Queue<(int, int)>();
            daControllare.Enqueue((riga, colonna));

            while (daControllare.Count > 0)
            {
                (int x, int y) = daControllare.Dequeue();

                if (x < 0 || x >= DIM_CAMPO || y < 0 || y >= DIM_CAMPO)
                    continue;

                if (dgvCampoMinato.Rows[x].Cells[y].Tag != null)
                    continue;

                int valore = campo[x + 1, y + 1];

                dgvCampoMinato.Rows[x].Cells[y].Tag = "1";
                dgvCampoMinato.Rows[x].Cells[y].Style.BackColor = Color.Green;
                mosse++;

                if (valore > 0)
                {
                    dgvCampoMinato.Rows[x].Cells[y].Value = valore;
                }
                else
                {
                    // espandi se 0
                    daControllare.Enqueue((x - 1, y));
                    daControllare.Enqueue((x + 1, y));
                    daControllare.Enqueue((x, y - 1));
                    daControllare.Enqueue((x, y + 1));
                }
            }
        }
    }
}
