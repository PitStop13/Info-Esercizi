using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tris
{
    public partial class Form1 : Form
    {
        private Button[,] griglia = new Button[3, 3];
        private bool turnoX = true; // true = X, false = O
        private int mosse = 0;
        private Label lblTurno;
        private Button btnNuovaPartita;
        private bool giocoFinito = false;

        public Form1()
        {
            InitializeComponent();
            ImpostaForm();
            CreaGriglia();
            CreaControlli();
        }

        // Impostazioni del Form
        private void ImpostaForm()
        {
            this.Size = new Size(450, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Tris - Pietro";
        }

        // Crea la griglia 3x3
        private void CreaGriglia()
        {
            int buttonSize = 100;
            int spacing = 10;
            int startX = 75;
            int startY = 80;

            for (int riga = 0; riga < 3; riga++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Location = new Point(
                        startX + col * (buttonSize + spacing),
                        startY + riga * (buttonSize + spacing)
                    );
                    btn.Font = new Font("Arial", 36, FontStyle.Bold);
                    btn.Text = "";
                    btn.Tag = new Point(riga, col); // Salva posizione
                    btn.Click += CellaTris_Click;

                    griglia[riga, col] = btn;
                    this.Controls.Add(btn);
                }
            }
        }

        // Crea label e bottone nuova partita
        private void CreaControlli()
        {
            // Label turno
            lblTurno = new Label();
            lblTurno.Text = "Turno di: X";
            lblTurno.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTurno.AutoSize = true;
            lblTurno.Location = new Point(140, 20);
            this.Controls.Add(lblTurno);

            // Bottone nuova partita
            btnNuovaPartita = new Button();
            btnNuovaPartita.Text = "NUOVA PARTITA";
            btnNuovaPartita.Size = new Size(200, 50);
            btnNuovaPartita.Location = new Point(125, 430);
            btnNuovaPartita.Font = new Font("Arial", 12, FontStyle.Bold);
            btnNuovaPartita.Click += BtnNuovaPartita_Click;
            this.Controls.Add(btnNuovaPartita);
        }

        // Click su una cella della griglia
        private void CellaTris_Click(object sender, EventArgs e)
        {
            if (giocoFinito)
                return;

            Button btn = (Button)sender;

            // Se la cella è già occupata, esci
            if (btn.Text != "")
                return;

            // Metti X o O
            if (turnoX)
            {
                btn.Text = "X";
                btn.ForeColor = Color.Blue;
            }
            else
            {
                btn.Text = "O";
                btn.ForeColor = Color.Red;
            }

            mosse++;

            // Controlla se qualcuno ha vinto
            if (ControllaVincitore())
            {
                giocoFinito = true;
                string vincitore = turnoX ? "X" : "O";
                lblTurno.Text = "Ha vinto: " + vincitore + "!";
                lblTurno.ForeColor = Color.Green;
                MessageBox.Show("Ha vinto il giocatore " + vincitore + "!", "Vittoria!");
                return;
            }

            // Controlla pareggio (9 mosse senza vincitore)
            if (mosse == 9)
            {
                giocoFinito = true;
                lblTurno.Text = "Pareggio!";
                lblTurno.ForeColor = Color.Orange;
                MessageBox.Show("Pareggio! Nessun vincitore.", "Fine partita");
                return;
            }

            // Cambia turno
            turnoX = !turnoX;
            lblTurno.Text = "Turno di: " + (turnoX ? "X" : "O");
        }

        // Controlla se c'è un vincitore
        private bool ControllaVincitore()
        {
            // Controlla righe
            for (int riga = 0; riga < 3; riga++)
            {
                if (griglia[riga, 0].Text != "" &&
                    griglia[riga, 0].Text == griglia[riga, 1].Text &&
                    griglia[riga, 1].Text == griglia[riga, 2].Text)
                {
                    EvidenziaVincita(griglia[riga, 0], griglia[riga, 1], griglia[riga, 2]);
                    return true;
                }
            }

            // Controlla colonne
            for (int col = 0; col < 3; col++)
            {
                if (griglia[0, col].Text != "" &&
                    griglia[0, col].Text == griglia[1, col].Text &&
                    griglia[1, col].Text == griglia[2, col].Text)
                {
                    EvidenziaVincita(griglia[0, col], griglia[1, col], griglia[2, col]);
                    return true;
                }
            }

            // Controlla diagonale principale (\)
            if (griglia[0, 0].Text != "" &&
                griglia[0, 0].Text == griglia[1, 1].Text &&
                griglia[1, 1].Text == griglia[2, 2].Text)
            {
                EvidenziaVincita(griglia[0, 0], griglia[1, 1], griglia[2, 2]);
                return true;
            }

            // Controlla diagonale secondaria (/)
            if (griglia[0, 2].Text != "" &&
                griglia[0, 2].Text == griglia[1, 1].Text &&
                griglia[1, 1].Text == griglia[2, 0].Text)
            {
                EvidenziaVincita(griglia[0, 2], griglia[1, 1], griglia[2, 0]);
                return true;
            }

            return false;
        }

        // Evidenzia le celle vincenti
        private void EvidenziaVincita(Button btn1, Button btn2, Button btn3)
        {
            btn1.BackColor = Color.LightGreen;
            btn2.BackColor = Color.LightGreen;
            btn3.BackColor = Color.LightGreen;
        }

        // Nuova partita
        private void BtnNuovaPartita_Click(object sender, EventArgs e)
        {
            // Reset griglia
            for (int riga = 0; riga < 3; riga++)
            {
                for (int col = 0; col < 3; col++)
                {
                    griglia[riga, col].Text = "";
                    griglia[riga, col].BackColor = SystemColors.Control;
                    griglia[riga, col].ForeColor = Color.Black;
                }
            }

            // Reset variabili
            turnoX = true;
            mosse = 0;
            giocoFinito = false;
            lblTurno.Text = "Turno di: X";
            lblTurno.ForeColor = Color.Black;
        }
    }
}
