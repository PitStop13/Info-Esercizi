using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Es_Libri
{
    public partial class FormMain : Form
    {

        public struct Libro
        {
            public string Titolo;
            public string Autore;
            public int Anno;
            public double Prezzo;
            
        }
        List<Libro> Libri;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Libri = new List<Libro>();
            SettaDgv();
        }

        private void SettaDgv()
        {
            dgvDati.ColumnCount = 4;
            dgvDati.Columns[0].HeaderText = "Titolo";
            dgvDati.Columns[0].Width = 120;
            dgvDati.Columns[1].HeaderText = "Autore";
            dgvDati.Columns[1].Width = 100;
            dgvDati.Columns[2].HeaderText = "Anno";
            dgvDati.Columns[2].Width = 50;
            dgvDati.Columns[3].HeaderText = "Prezzo";
            dgvDati.Columns[3].Width = 50;

            dgvDati.AllowUserToAddRows = false;
            dgvDati.RowHeadersVisible = false;
            dgvDati.ScrollBars = ScrollBars.Vertical;
            dgvDati.ClearSelection();
            

        }

        private void btnLeggi_Click(object sender, EventArgs e)
        {
            LeggiFile("libri.csv");
            
            int i = 0;
            dgvDati.Rows.Clear();
            foreach(var libro in Libri)
            {
                dgvDati.Rows.Add();
                
                dgvDati.Rows[i].Cells[0].Value = libro.Titolo;
                dgvDati.Rows[i].Cells[1].Value = libro.Autore;
                dgvDati.Rows[i].Cells[2].Value = libro.Anno;
                dgvDati.Rows[i].Cells[3].Value = libro.Prezzo;
                i++;
            }
            
        }

        private void LeggiFile(string filePath)
        {
            Libri.Clear();
            string[] campi;
            string riga;
            using (StreamReader sr = new StreamReader(filePath))
            {
                
                while (!sr.EndOfStream)
                {
                    riga = sr.ReadLine();
                    campi = riga.Split(',');
                    Libro libro = new Libro()
                    {
                        Titolo = campi[0],
                        Autore = campi[1],
                        Anno = int.Parse(campi[2]),
                        Prezzo = double.Parse(campi[3])
                    };
                    Libri.Add(libro);
                }
            }
            
        }
    }
}
