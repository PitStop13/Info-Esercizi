using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro
{
    internal class Elettronico:Oggetto
    {
        protected string marca;
        protected int capacità;

        public string Marca => marca;
        public int Capacità => capacità;

        public Elettronico(string nome, string marca, double prezzo,int quantità) : base(nome, prezzo,quantità)
        {
            this.marca = marca;
            this.capacità = 0;
        }
        public Elettronico(string nome, string marca,int capacità , double prezzo, int quantità) : base(nome, prezzo, quantità)
        {
            this.marca = marca;
            this.capacità = capacità;
        }
        public void calcolaPrezzo()
        {
            //iva 22%
            double prezzoIniz = Prezzo;
            double prezzoIvato = (prezzoIniz + (prezzoIniz / 100) * 22);
            Console.WriteLine($"Prezzo ivato:{prezzoIvato} \n Prezzo totale per n prodotti: {prezzoIvato*quantità}");

        }

        public override string ToString()
        {
            return "Elettronico:" + base.ToString() + $", Marca: {marca} , capacità di memoria: {capacità}";
        }
    }
}
