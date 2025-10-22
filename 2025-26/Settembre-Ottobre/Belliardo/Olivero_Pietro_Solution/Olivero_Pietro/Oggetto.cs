using System;

namespace Olivero_Pietro
{
    internal class Oggetto
    {
        protected string nome;
        private double prezzo;
        private int quantità;

        public string Nome => nome;
        public double Prezzo => prezzo;
        public int Quantità => quantità;

        public Oggetto(string nome, double prezzo, int quantità)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.quantità = quantità;
        }

        public virtual double CalcolaPrezzoUnitario()
        {
            return Math.Round(Prezzo * 1.22, 2);
        }

        // Overload: calcola prezzo con sconto personalizzato
        public virtual double CalcolaPrezzoUnitario(double percentualeSconto)
        {
            double prezzoScontato = Prezzo * (1 - percentualeSconto / 100);
            return Math.Round(prezzoScontato * 1.22, 2);
        }

        public override string ToString()
        {
            return $"{Nome}, prezzo base: {Prezzo.ToString("F2")}, quantità: {Quantità}";
        }
    }
}
