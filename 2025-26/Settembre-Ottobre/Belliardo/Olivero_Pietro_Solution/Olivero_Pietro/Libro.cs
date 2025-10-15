using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro
{
    internal class Libro:Oggetto
    {
        protected int anno;
        protected string autore;

        public int Anno => anno;
        public string Autore => autore;

        public Libro(string nome, double prezzo, string autore, int quantità) : base(nome, prezzo, quantità)
        {
            this.anno = 0;
            this.autore = autore;
        }
        public Libro(string nome, double prezzo, int anno, string autore, int quantità) : base(nome, prezzo, quantità)
        {
            this.anno = anno;
            this.autore = autore;
        }
        public void calcolaPrezzo()
        {
            //iva 22%
            double prezzoIniz = Prezzo;
            double prezzoIvato = (prezzoIniz + (prezzoIniz / 100) * 22);
            Console.WriteLine($"Prezzo ivato:{prezzoIvato} \n Prezzo totale per n prodotti: {prezzoIvato * quantità}");

        }
        public override string ToString()
        {
            return "Libro:" + base.ToString() + $", Anno: {anno} , autore: {Autore}";
        }

    }
}
