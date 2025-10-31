using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparazioneVerifica_Mia
{
    internal class Abbigliamento : Oggetto
    {
        private string marca;

        public string Marca => marca;

        public Abbigliamento(string nome, string marca, double prezzo, int quantita) : base(nome, prezzo, quantita)
        {
            this.marca = marca;
        }
        public Abbigliamento(string nome, double prezzo, int quantita) : base(nome, prezzo, quantita)
        {
            this.marca = "Senza marca";
        }

        public override double CalcolaPrezzoUnitario()
        {
            double prezzobase = Prezzo;
            if (Quantità >= 2)
            {
                //sconto 15%
                prezzobase = prezzobase * 0.85;
            }
            return Math.Round(prezzobase * 1.12, 2);
        }

        public override string ToString()
        {
            string sconto = "";
            if (Quantità >= 2)
            {
                sconto = "Sconto: 15%";

            }
            else
            {
                sconto = "No sconto";
            }
            return "Abbigliamento:" + base.ToString() + $", Marca: {Marca}, {sconto}";
        }


    }
}
