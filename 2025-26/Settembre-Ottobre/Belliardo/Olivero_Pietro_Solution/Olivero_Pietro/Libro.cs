using System;

namespace Olivero_Pietro
{
    internal class Libro : Oggetto
    {
        private int anno;
        private string autore;

        public int Anno => anno;
        public string Autore => autore;

        // Costruttore completo
        public Libro(string nome, double prezzo, int anno, string autore, int quantità)
            : base(nome, prezzo, quantità)
        {
            this.anno = anno;
            this.autore = autore;
        }

        // Overload costruttore (senza anno)
        public Libro(string nome, double prezzo, string autore, int quantità)
            : base(nome, prezzo, quantità)
        {
            this.anno = 0;
            this.autore = autore;
        }

        public override double CalcolaPrezzoUnitario()
        {
            // IVA 4%
            return Math.Round(Prezzo * 1.04, 2);
        }

        public override string ToString()
        {
            return $"Libro: {base.ToString()}, Anno: {anno}, Autore: {Autore}";
        }
    }
}
