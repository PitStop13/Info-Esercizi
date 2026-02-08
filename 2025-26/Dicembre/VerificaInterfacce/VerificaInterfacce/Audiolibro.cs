using BibliotecaSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaInterfacce
{
    internal class Audiolibro : ContenutoMultimediale, IPrestabile
    {
        private string _narratore;
        private int _durata; // in minuti
        private string _autore;

        // Proprietà interfaccia
        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }

        public int DurataPrestito { get { return 21; } } // 21 giorni per gli audiolibri

        public string Narratore { get => _narratore; set => _narratore = value; }
        public int Durata { get => _durata; set => _durata = value; }
        public string Autore { get => _autore; set => _autore = value; }

        public Audiolibro(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
            string narratore, int durata, string autore)
            : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            Narratore = narratore;
            Durata = durata;
            Autore = autore;
            InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "Audiolibro";
        }

        public override string OttieniDescrizione()
        {
            string stato = InPrestito ? $" [IN PRESTITO a {UtenteInPrestito}]" : " [DISPONIBILE]";
            return base.OttieniDescrizione() + $" | Autore: {Autore} | Narratore: {Narratore} | Durata: {Durata} min" + stato;
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
