using System;

namespace BibliotecaSolution
{
    /// <summary>
    /// Classe base astratta che rappresenta un contenuto multimediale generico
    /// </summary>
    public abstract class ContenutoMultimediale
    {
        // Proprietà comuni a tutti i contenuti
        private string _titolo;
        private int _annoPubblicazione;
        private string _categoria;
        private decimal _valoreCommerciale;
        private string _codiceIdentificativo;

        public string Titolo
        {
            get { return _titolo; }
            set { _titolo = value; }
        }

        public int AnnoPubblicazione
        {
            get { return _annoPubblicazione; }
            set { _annoPubblicazione = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public decimal ValoreCommerciale
        {
            get { return _valoreCommerciale; }
            set { _valoreCommerciale = value; }
        }

        public string CodiceIdentificativo
        {
            get { return _codiceIdentificativo; }
            set { _codiceIdentificativo = value; }
        }

        // Costruttore
        protected ContenutoMultimediale(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale)
        {
            this.Titolo = titolo;
            this.AnnoPubblicazione = annoPubblicazione;
            this.Categoria = categoria;
            this.ValoreCommerciale = valoreCommerciale;
            this.CodiceIdentificativo = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
        }

        // Metodo virtuale per ottenere informazioni sul contenuto
        public virtual string OttieniDescrizione()
        {
            return $"[{CodiceIdentificativo}] {Titolo} ({AnnoPubblicazione}) - {Categoria} - €{ValoreCommerciale:F2}";
        }

        // Metodo astratto che deve essere implementato dalle classi derivate
        public abstract string OttieniTipo();
    }
}
