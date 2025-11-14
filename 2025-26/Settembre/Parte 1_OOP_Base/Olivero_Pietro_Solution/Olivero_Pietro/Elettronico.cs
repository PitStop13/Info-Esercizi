using System;

namespace Olivero_Pietro
{
    internal class Elettronico : Oggetto
    {
        private string marca;
        private int capacità;

        public int GaranziaAnni { get; private set; }
        public string Marca => marca;
        public int Capacità => capacità;

        // Costruttore con garanzia
        public Elettronico(string nome, string marca, int capacità, double prezzo, int quantità, int garanziaAnni)
            : base(nome, prezzo, quantità)
        {
            this.marca = marca;
            this.capacità = capacità;
            this.GaranziaAnni = garanziaAnni;
        }

        // Overload costruttore (senza garanzia)
        public Elettronico(string nome, string marca, int capacità, double prezzo, int quantità)
            : base(nome, prezzo, quantità)
        {
            this.marca = marca;
            this.capacità = capacità;
            this.GaranziaAnni = 0;
        }

        public override double CalcolaPrezzoUnitario()
        {
            double costoGaranzia = GaranziaAnni > 0 ? Prezzo * 0.10 : 0;
            double prezzoConGaranzia = Prezzo + costoGaranzia;

            // IVA 22%
            return Math.Round(prezzoConGaranzia * 1.22, 2);
        }

        public override string ToString()
        {
            string garanzia = GaranziaAnni > 0 ? " (garanzia estesa)" : "";
            return $"Elettronico: {base.ToString()}, Marca: {marca}, Capacità: {capacità} GB{garanzia}";
        }
    }
}
