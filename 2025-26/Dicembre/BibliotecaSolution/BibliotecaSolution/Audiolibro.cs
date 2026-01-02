using System;

namespace BibliotecaSolution
{
    /// <summary>
    /// Classe che rappresenta un audiolibro
    /// </summary>
    public class Audiolibro : ContenutoMultimediale, IPrestabile
    {
        private string _narratore;
        private int _durataMinuti;
        private string _autoreOriginale;

        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }
        
        public int DurataPrestito 
        { 
            get { return 7; } 
        }

        public string Narratore
        {
            get { return _narratore; }
            set { _narratore = value; }
        }

        public int DurataMinuti
        {
            get { return _durataMinuti; }
            set { _durataMinuti = value; }
        }

        public string AutoreOriginale
        {
            get { return _autoreOriginale; }
            set { _autoreOriginale = value; }
        }

        public Audiolibro(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
                          string narratore, int durataMinuti, string autoreOriginale)
             : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            this.Narratore = narratore;
            this.DurataMinuti = durataMinuti;
            this.AutoreOriginale = autoreOriginale;
            this.InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "Audiolibro";
        }

        public override string OttieniDescrizione()
        {
            return $"{base.OttieniDescrizione()} - Narratore: {Narratore} - Durata: {DurataMinuti} min - Autore: {AutoreOriginale}";
        }

        public void Presta(string nomeUtente, DateTime dataPrestito)
        {
            if (InPrestito)
            {
                throw new InvalidOperationException("L'audiolibro è già in prestito.");
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
