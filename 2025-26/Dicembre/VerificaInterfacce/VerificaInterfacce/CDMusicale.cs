using BibliotecaSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaInterfacce
{
    internal class CDMusicale : ContenutoMultimediale, IPrestabile
    {
        private string _artista;
        private int _numeroTracce;
        private string _genere;

        // Proprietà interfaccia
        public bool InPrestito { get; set; }
        public string UtenteInPrestito { get; set; }
        public DateTime? DataPrestito { get; set; }

        public int DurataPrestito { get { return 7; } } // 7 giorni per i CD

        public string Artista { get => _artista; set => _artista = value; }
        public int NumeroTracce { get => _numeroTracce; set => _numeroTracce = value; }
        public string Genere { get => _genere; set => _genere = value; }

        public CDMusicale(string titolo, int annoPubblicazione, string categoria, decimal valoreCommerciale,
            string artista, int numeroTracce, string genere)
            : base(titolo, annoPubblicazione, categoria, valoreCommerciale)
        {
            Artista = artista;
            NumeroTracce = numeroTracce;
            Genere = genere;
            InPrestito = false;
        }

        public override string OttieniTipo()
        {
            return "CD Musicale";
        }

        public override string OttieniDescrizione()
        {
            string stato = InPrestito ? $" [IN PRESTITO a {UtenteInPrestito}]" : " [DISPONIBILE]";
            return base.OttieniDescrizione() + $" | Artista: {Artista} | Tracce: {NumeroTracce} | Genere: {Genere}" + stato;
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
