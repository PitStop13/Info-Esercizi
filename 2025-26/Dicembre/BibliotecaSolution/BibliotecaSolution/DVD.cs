using System;

namespace BibliotecaSolution
{
    /// <summary>
    /// Classe che rappresenta un DVD
    /// </summary>
    public class DVD : ContenutoMultimediale, IPrestabile
    {
        private string _regista;
        private int _durata; // in minuti
        private string _genere;

        // IPrestabile implementation
        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }
        
        public int DurataPrestito 
        { 
            get { return 7; } // 7 giorni per i DVD
        }
        
        public string Regista
        {
            get { return _regista; }
            set { _regista = value; }
        }

        public int Durata
        {
            get { return _durata; }
            set { _durata = value; }
        }

        public string Genere
        {
            get { return _genere; }
            set { _genere = value; }
        }

        // Costruttori
        public DVD(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
                   string regista, int durata, string genere)
            : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            this.Regista = regista;
            this.Durata = durata;
            this.Genere = genere;
            this.InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "DVD";
        }

        public override string OttieniDescrizione()
        {
            return $"{base.OttieniDescrizione()} - Regista: {Regista} - Durata: {Durata} min - Genere: {Genere}";
        }

        // Implementazione dei metodi dell'interfaccia IPrestabile
        public void Presta(string nomeUtente, DateTime dataPrestito)
        {
            if (InPrestito)
            {
                throw new InvalidOperationException("Il DVD è già in prestito.");
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
