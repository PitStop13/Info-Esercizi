using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro
{
    internal class Abbigliamento:Oggetto
    {
        protected string marca;
        public string Marca => marca;

        public Abbigliamento(string nome, double prezzo,int quantità) : base(nome, prezzo, quantità)
        {
            
        }
        public Abbigliamento(string nome, string marca, double prezzo, int quantità) : base(nome, prezzo, quantità)
        {
            this.marca = marca;
        }

       
            public void calcolaPrezzo()
            {
                //iva 22% + sconto 15%
                double prezzoIniz = Prezzo;
                double prezzoIvato = (prezzoIniz + (prezzoIniz / 100) * 22);
                double prezzoScont = prezzoIvato-(prezzoIvato / 100)*15 ;
                Console.WriteLine($"Prezzo ivato:{prezzoScont} \n Prezzo totale per n prodotti: {prezzoIvato * quantità}");

            }

        

        public override string ToString()
        {
            return "Abbigliamento:" + base.ToString() + $", Marca: {marca}";
        }
    }
}
