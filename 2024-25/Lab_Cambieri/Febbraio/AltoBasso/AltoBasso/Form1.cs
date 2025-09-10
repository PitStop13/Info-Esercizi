using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltoBasso
{
    public partial class AltoBasso : Form
    {
        const int NUMEROTENTATIVIBASE = 5;
        const int NUMEROTENTATIVIINTERMEDIO = 10;
        const int NUMEROTENTATIVIAVANZATO = 20;
        const int MAXNUMBASE = 100;
        const int MAXNUMINTERMEDIO = 500;
        const int MAXNUMAVANZATO = 1000;

        Random rand = new Random();
        int numeroSegreto;
        int tentativiRimasiti = 0;
        string indicazioneTentativi;
        int conta = 0;
        public AltoBasso()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
            indicazioneTentativi = lblTentativi.Text;
        }

        private void rbd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBase.Checked)
            {
                setParametri(rand.Next(1, MAXNUMBASE + 1), NUMEROTENTATIVIBASE);
            }
            else if (rdbIntermedio.Checked)
            {
                setParametri(rand.Next(1, MAXNUMINTERMEDIO + 1), NUMEROTENTATIVIINTERMEDIO);
            }
            else if (rdbAvanzato.Checked)
            {
                setParametri(rand.Next(1, MAXNUMAVANZATO + 1), NUMEROTENTATIVIAVANZATO);
            }
        }

        private void setParametri(int nSegr, int tRimast)
        {
            numeroSegreto = nSegr;
            tentativiRimasiti = tRimast;
            btnIndovina.Enabled = true;
            txtNumero.Enabled = true;
            lblTentativi.Text = indicazioneTentativi + tentativiRimasiti;
            rdbBase.Enabled = rdbIntermedio.Enabled = rdbAvanzato.Enabled = false;
            lblRisultato.Text = "";
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIndovina_Click(object sender, EventArgs e)
        {
            int num;
            if(int.TryParse(txtNumero.Text, out num))
            {
                conta++;
                if (num == numeroSegreto)
                {
                    //MessageBox.Show($"Hai vinto in {conta} tentativi!");
                    btnIndovina.Enabled = true;
                    lblRisultato.Text = $"Hai vinto in {conta} tentativi!";
                    reset();
                }
                else
                {
                    tentativiRimasiti--;
                    if(tentativiRimasiti == 0)
                    {
                        //MessageBox.Show($"Hai perso, il numero segreto era {numeroSegreto}!");
                        btnIndovina.Enabled = true;
                        lblRisultato.Text = $"Hai perso, il numero segreto era {numeroSegreto}!";
                        reset();
                        return;
                    }
                    if(num< numeroSegreto)
                    {
                        //MessageBox.Show("Il numero segreto è più alto!");
                        pictureBoxSu.Visible = true;
                        pictureBoxGiu.Visible = false;
                    }
                    else
                    {
                        //MessageBox.Show("Il numero segreto è più basso!");
                        pictureBoxSu.Visible = false;
                        pictureBoxGiu.Visible = true;
                    }
                    lblTentativi.Text = indicazioneTentativi + tentativiRimasiti;
                }
            }
            else
            {
                MessageBox.Show("Devi inserire un numero!");
            }
        }

        private void reset()
        {
            rdbBase.Enabled = rdbIntermedio.Enabled = rdbAvanzato.Enabled = true;
            rdbAvanzato.Checked = rdbIntermedio.Checked = rdbBase.Checked = false;
            btnIndovina.Enabled = false;
            txtNumero.Enabled = false;
            txtNumero.Text = "";
            lblTentativi.Text = indicazioneTentativi;
            conta = 0;
            pictureBoxGiu.Visible = pictureBoxSu.Visible = false;
        }
    }
}
