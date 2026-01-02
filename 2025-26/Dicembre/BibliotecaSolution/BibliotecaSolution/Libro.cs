using System;

namespace BibliotecaSolution
{
    /// <summary>
    /// Classe che rappresenta un libro
    /// </summary>
    public class Libro : ContenutoMultimediale, IPrestabile
    {
        private string _autore;
        private int _numeroPagine;
        private string _casaEditrice;
        
        // IPrestabile implementation
        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }
        
        public int DurataPrestito 
        { 
            get { return 30; } // 30 giorni per i libri
        }

        public string Autore
        {
            get { return _autore; }
            set { _autore = value; }
        }

        public int NumeroPagine
        {
            get { return _numeroPagine; }
            set { _numeroPagine = value; }
        }

        public string CasaEditrice
        {
            get { return _casaEditrice; }
            set { _casaEditrice = value; }
        }

        // Costruttori
        public Libro(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
                     string autore, int numeroPagine, string casaEditrice)
            : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            this.Autore = autore;
            this.NumeroPagine = numeroPagine;
            this.CasaEditrice = casaEditrice;
            this.InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "Libro";
        }

        public override string OttieniDescrizione()
        {
            return $"{base.OttieniDescrizione()} - Autore: {Autore} - Pagine: {NumeroPagine} - Editore: {CasaEditrice}";
        }

        // Implementazione dei metodi dell'interfaccia IPrestabile
        public void Presta(string nomeUtente, DateTime dataPrestito)
        {
            if (InPrestito)
            {
                throw new InvalidOperationException("Il libro è già in prestito.");
            }
            InPrestito = true;
            UtenteInPrestito = nomeUtente;
            DataPrestito = dataPrestito;
        }

        public void Restituisci()
        {
            InPrestito = false;
            UtenteInPrestito = null;
            DataPrestito = null;
        }

        public bool IsPrestutoScaduto()
        {
            if (!InPrestito || !DataPrestito.HasValue) return false;
            
            return (DateTime.Now - DataPrestito.Value).TotalDays > DurataPrestito;
        }
    }
}
