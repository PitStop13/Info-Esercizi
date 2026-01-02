using System;

namespace BibliotecaSolution
{
    /// <summary>
    /// Classe che rappresenta un CD musicale
    /// </summary>
    public class CDMusicale : ContenutoMultimediale, IPrestabile
    {
        private string _artista;
        private int _numeroTracce;
        private string _genere;

        // IPrestabile implementation
        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }

        public int DurataPrestito 
        { 
            get { return 7; } 
        }

        public string Artista
        {
            get { return _artista; }
            set { _artista = value; }
        }

        public int NumeroTracce
        {
            get { return _numeroTracce; }
            set { _numeroTracce = value; }
        }

        public string Genere
        {
            get { return _genere; }
            set { _genere = value; }
        }

        // Costruttori
        public CDMusicale(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
                          string artista, int numeroTracce, string genere)
            : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            this.Artista = artista;
            this.NumeroTracce = numeroTracce;
            this.Genere = genere;
            this.InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "CD Musicale";
        }

        public override string OttieniDescrizione()
        {
            return $"{base.OttieniDescrizione()} - Artista: {Artista} - Tracce: {NumeroTracce} - Genere: {Genere}";
        }

        // Implementazione dei metodi dell'interfaccia IPrestabile
        public void Presta(string nomeUtente, DateTime dataPrestito)
        {
            if (InPrestito)
            {
                throw new InvalidOperationException("Il CD è già in prestito.");
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
