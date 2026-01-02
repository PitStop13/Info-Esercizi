using System;

namespace BibliotecaSolution
{
    /// <summary>
    /// Classe che rappresenta una rivista
    /// Le riviste dell'ultimo mese NON sono prestabili (solo consultabili in sede)
    /// </summary>
    public class Rivista : ContenutoMultimediale, IPrestabile
    {
        private string _editore;
        private int _numeroEdizione;
        private string _periodicita; // Mensile, Settimanale, etc.

        // IPrestabile implementation
        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }

        public int DurataPrestito 
        { 
            get { return 7; } 
        }

        public string Editore
        {
            get { return _editore; }
            set { _editore = value; }
        }

        public int NumeroEdizione
        {
            get { return _numeroEdizione; }
            set { _numeroEdizione = value; }
        }

        public string Periodicita
        {
            get { return _periodicita; }
            set { _periodicita = value; }
        }

        // Costruttori
        public Rivista(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
                       string editore, int numeroEdizione, string periodicita)
            : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            this.Editore = editore;
            this.NumeroEdizione = numeroEdizione;
            this.Periodicita = periodicita;
            this.InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "Rivista";
        }

        public override string OttieniDescrizione()
        {
            return $"{base.OttieniDescrizione()} - Editore: {Editore} - Edizione: {NumeroEdizione} - Periodicità: {Periodicita}";
        }

        // Verifica se la rivista è prestabile (solo se non è dell'ultimo mese)
        public bool IsPrestabile()
        {
            return true; 
        }

        // Implementazione dei metodi dell'interfaccia IPrestabile
        public void Presta(string nomeUtente, DateTime dataPrestito)
        {
            if (!IsPrestabile())
            {
                throw new InvalidOperationException("Questa rivista non è prestabile.");
            }

            if (InPrestito)
            {
                throw new InvalidOperationException("La rivista è già in prestito.");
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
