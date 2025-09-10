using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindForm01
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();//è una funzione che sta dentro al desginer
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Prova apertura message box (analoga a alaert di java script)");
            string tuoNome = txtNominativo.Text;
            if (tuoNome.Length == 0)
            {
                MessageBox.Show("Devi inserire un nominativo", "ATTENZIONE!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);//testo, titolo, bottone, icon
            }
            else
            {
                string message = $"Il tuo nominativo è: {tuoNome}";
                MessageBox.Show(message);
            }

        }
    }
}
