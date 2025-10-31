using System;

namespace Olivero_Pietro
{
    internal class Abbigliamento : Oggetto
    {
        private string marca;
        public string Marca => marca;

        // Costruttore base
        public Abbigliamento(string nome, string marca, double prezzo, int quantità): base(nome, prezzo, quantità)
        {
            this.marca = marca;
        }

        // Overload costruttore (senza marca)
        public Abbigliamento(string nome, double prezzo, int quantità): base(nome, prezzo, quantità)
        {
            this.marca = "Senza Marca";
        }

        public override double CalcolaPrezzoUnitario()
        {
            double prezzoBase = Prezzo;

            // Sconto 15% se quantità >= 2
            if (Quantità >= 2)
            {
                prezzoBase = prezzoBase * 0.85;
            }

            // IVA 12%
            double prezzoFinale = prezzoBase * 1.12;
            return Math.Round(prezzoFinale, 2);
        }

        public override string ToString()
        {
            string sconto = Quantità >= 2 ? " (sconto 15%)" : "";
            return $"Abbigliamento: {base.ToString()}, Marca: {marca}{sconto}";
        }
    }
}
