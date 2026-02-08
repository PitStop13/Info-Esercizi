using BibliotecaSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaInterfacce
{
    internal class DVD : ContenutoMultimediale, IPrestabile
    {
        private string _regista;
        private int _durata; // in minuti
        private string _genere;

        // Proprietà interfaccia
        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }

        public int DurataPrestito { get { return 7; } } // 7 giorni per i DVD

        public string Regista { get => _regista; set => _regista = value; }
        public int Durata { get => _durata; set => _durata = value; }
        public string Genere { get => _genere; set => _genere = value; }

        public DVD(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
            string regista, int durata, string genere)
            : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            Regista = regista;
            Durata = durata;
            Genere = genere;
            InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "DVD";
        }

        public override string OttieniDescrizione()
        {
            string stato = InPrestito ? $" [IN PRESTITO a {UtenteInPrestito}]" : " [DISPONIBILE]";
            return base.OttieniDescrizione() + $" | Regista: {Regista} | Durata: {Durata} min | Genere: {Genere}" + stato;
        }

        // Metodi dell'Interfaccia
        public void Presta(string nomeUtente, DateTime dataPrestito)
        {
            if (!InPrestito)
            {
                InPrestito = true;
                UtenteInPrestito = nomeUtente;
                DataPrestito = dataPrestito;
            }
        }

        public void Restituisci()
        {
            InPrestito = false;
            UtenteInPrestito = null;
            DataPrestito = null;
        }

        public bool IsPrestutoScaduto()
        {
            if (!InPrestito || DataPrestito is null)
                return false;

            return (DateTime.Now - DataPrestito.Value).Days > DurataPrestito;
        }
    }
}
