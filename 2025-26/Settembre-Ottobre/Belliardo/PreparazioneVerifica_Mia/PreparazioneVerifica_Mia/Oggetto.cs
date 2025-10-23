using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparazioneVerifica_Mia
{
    internal class Oggetto
    {
        protected string nome;
        private double prezzo;
       

        public string Nome => nome;
        public double Prezzo => prezzo;
        public int Quantità { get;set; }

        public Oggetto(string nome, double prezzo, int quantità)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.Quantità = quantità;
        }
        public virtual double CalcolaPrezzoUnitario()
        {
            return Math.Round(Prezzo * 1.22, 2);//iva 22%
        }

        public virtual double CalcolaPrezzoUnitario(double percSconto)
        {
            double PrezzoScontato = Prezzo * (1 - percSconto / 100);
            return Math.Round(PrezzoScontato * 1.22, 2);//iva 22% con sconto di tot
        }

        public override string ToString() {

            return $"Nome: {Nome},prezzo base: {Prezzo.ToString("F2")}, quantità: {Quantità}";

        }




    }
}
