using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinatoBottoni
{
    public partial class FromMain : Form
    {

        Random rnd = new Random();
        const int righe = 10;
        const int colonne = 10;
        const int nBombe = 10;

        // Matrice per gestire le regole del gioco
        int[,] campo;

        // Matrice di bottoni speculare a quella del campo
        Button[,] bottoni;

        public FromMain()
        {
            InitializeComponent();
        }

        private void FromMain_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            campo = new int[righe, colonne];
            bottoni = new Button[righe, colonne];
            CreaBottoniCampo();
        }

        private void CreaBottoniCampo()
        {
            int size = 40;
            int offset = 6;
            int x = offset;
            int y = panelTop.Height + offset;
            for(int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    Button btn = new Button();
                    btn.Text = "";
                    btn.Tag = $"{i}, {j}"; // Pos i, j del bottone
                    btn.Size = new Size(size, size);
                    btn.Location = new Point(x, y);
                    btn.Font = new Font("calibri", 14, FontStyle.Bold);
                    btn.Enabled = false;
                    btn.Click += Btn_Click; // Qaundo clicco sul btn entro nella funzione Btn_Click
                    Controls.Add(btn); // Aggiungo il bottone alla form
                    bottoni[i, j] = btn; // Aggiungo il bottone alla matrice
                    x += size + offset;
                }
                x = offset;
                y += size + offset;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            // Sender è il mittente dell'evento (pulsante cliccato)
            // EventArgs è
            Button premuto = (Button)sender;
            string[] splitted = new string[2];
            splitted = premuto.Tag.ToString().Split(','); // uso la , come separatore
            int x = int.Parse(splitted[0]);
            int y = int.Parse(splitted[1]);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AzzeraCampo();
            MettiBombe();
            MettiNumeri();
        }

        private void AzzeraCampo()
        {
            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    campo[i, j] = 0;
                    bottoni[i, j].Text = "";
                }
            }
        }

        private void MettiBombe()
        {
            for (int i = 0; i < nBombe; i++)
            {
                int x = 0, y = 0;
                do
                {
                    x = rnd.Next(0, righe);
                    y = rnd.Next(0, colonne);
                } while (campo[x, y] != 0);
                campo[x, y] = -1;
            }
        }

        private void MettiNumeri()
        {
            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    if(campo[i, j] != -1)
                    {
                        int nBombeIntorno = 0;
                        CheckBordo(i - 1, j - 1, ref nBombeIntorno);
                        CheckBordo(i - 1, j, ref nBombeIntorno);
                        CheckBordo(i - 1, j + 1, ref nBombeIntorno);
                        CheckBordo(i, j - 1, ref nBombeIntorno);
                        CheckBordo(i, j + 1, ref nBombeIntorno);
                        CheckBordo(i + 1, j - 1, ref nBombeIntorno);
                        CheckBordo(i + 1, j, ref nBombeIntorno);
                        CheckBordo(i + 1, j + 1, ref nBombeIntorno);
                        campo[i, j] = nBombeIntorno;
                    }
                    bottoni[i, j].Enabled = true;
                    bottoni[i, j].ForeColor = Color.Empty;
                    bottoni[i, j].BackColor = Color.Empty;
                }
            }
        }

        private void CheckBordo(int i, int j, ref int nBombeIntorno)
        {
            // Try catch al posto che mandare in errore il programma svolge quello che c'è nel catch
            try
            {
                if (campo[i, j] == -1) nBombeIntorno++;
            }
            catch (Exception)
            { }
        }
    }
}
