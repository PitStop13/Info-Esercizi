using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro
{
    internal class Oggetto
    {

        protected string nome;

        private double prezzo;
        public int quantità {  get; set; }


        

        public string Tipo => nome;
        public double Prezzo => prezzo;
         
        public Oggetto(string nome, double prezzo, int quantità)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.quantità = quantità;
        }

        public override string ToString()
        {
            return $"  {nome}, prezzo: {prezzo}";
        }

    }
}
