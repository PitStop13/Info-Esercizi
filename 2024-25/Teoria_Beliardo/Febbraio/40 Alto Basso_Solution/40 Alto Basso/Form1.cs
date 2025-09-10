using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _40_Alto_Basso
{
    public partial class AltoBasso : Form
    {
        const int NUMEROTENTATIVIBASE = 5;
        const int NUMEROTENTATIVIINTERMEDIO = 10;
        const int NUMEROTENTATIVIAVANZATO = 20;

        const int maxNumBase = 100;
        const int maxNumIntermedio = 500;
        const int maxNumAvanzato = 1000;

        Random rand = new Random();
        int numeroSegreto;
        int tentativiRimasti;
        public AltoBasso()
        {
            InitializeComponent();
            btnIndovina.Enabled = false;
            txtNumero.Enabled = false;
        }

        private void rbtnBase_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnBase.Checked)
            {

            }
        }
    }
}
