using System;
using System.Collections.Generic;

namespace Palestra
{
    // Ereditarietà: CorsoGruppo estende ServizioPalestra
    // Interfacce: CorsoGruppo implementa IPrenotabile
    public class CorsoGruppo : ServizioPalestra, IPrenotabile
    {
        public string Istruttore { get; set; }
        public int MaxPartecipanti { get; set; }
        
        // Lista privata per gestire le prenotazioni di questo corso specifico
        private List<string> prenotazioni;

        public CorsoGruppo(string codice, string nome, decimal costo, int durata, string istruttore, int maxPartecipanti) 
            : base(codice, nome, costo, durata) // Chiamata al costruttore della classe base
        {
            Istruttore = istruttore;
            MaxPartecipanti = maxPartecipanti;
            prenotazioni = new List<string>();
        }

        // Implementazione proprietà Interfaccia
        public int PostiDisponibili => MaxPartecipanti - prenotazioni.Count;

        // Implementazione metodi Interfaccia
        public bool Prenota(string nomeCliente)
        {
            if (prenotazioni.Count < MaxPartecipanti)
            {
                prenotazioni.Add(nomeCliente);
                return true;
            }
            return false;
        }

        public bool AnnullaPrenotazione(string nomeCliente)
        {
            return prenotazioni.Remove(nomeCliente);
        }

        public string GetInfoPrenotazioni()
        {
            return $"Prenotati: {prenotazioni.Count}/{MaxPartecipanti}. Posti liberi: {PostiDisponibili}.";
        }

        // Override del metodo base (Polimorfismo)
        public override string DescrizioneServizio()
        {
            return base.DescrizioneServizio() + $" [Corso con {Istruttore}] - {GetInfoPrenotazioni()}";
        }
    }

    public class PersonalTraining : ServizioPalestra, IPrenotabile
    {
        public string Istruttore { get; set; }
        private string clientePrenotato = null;

        public PersonalTraining(string codice, string nome, decimal costo, int durata, string istruttore) 
            : base(codice, nome, costo, durata)
        {
            Istruttore = istruttore;
        }

        public int PostiDisponibili => clientePrenotato == null ? 1 : 0;

        public bool Prenota(string nomeCliente)
        {
            if (clientePrenotato == null)
            {
                clientePrenotato = nomeCliente;
                return true;
            }
            return false;
        }

        public bool AnnullaPrenotazione(string nomeCliente)
        {
            if (clientePrenotato == nomeCliente)
            {
                clientePrenotato = null;
                return true;
            }
            return false;
        }

        public string GetInfoPrenotazioni()
        {
            return clientePrenotato == null ? "Disponibile" : $"Prenotato da {clientePrenotato}";
        }

        public override string DescrizioneServizio()
        {
            return base.DescrizioneServizio() + $" [PT con {Istruttore}] - {GetInfoPrenotazioni()}";
        }
    }

    public class SalaPesi : ServizioPalestra
    {
        public bool Accesso24h { get; set; }

        public SalaPesi(string codice, string nome, decimal costo, int durata, bool accesso24h) 
            : base(codice, nome, costo, durata)
        {
            Accesso24h = accesso24h;
        }

        public override string DescrizioneServizio()
        {
            string orario = Accesso24h ? "Accesso 24h" : "Orari standard";
            return base.DescrizioneServizio() + $" [Sala Pesi] - {orario} - Accesso Libero";
        }
    }

    // Quarta classe derivata: Piscina con fasce orarie prenotabili
    public class Piscina : ServizioPalestra, IPrenotabile
    {
        public string FasciaOraria { get; set; } // Es: "08:00-10:00", "14:00-16:00"
        public int MaxPartecipanti { get; set; }
        private List<string> prenotazioni;

        public Piscina(string codice, string nome, decimal costo, int durata, string fasciaOraria, int maxPartecipanti)
            : base(codice, nome, costo, durata)
        {
            FasciaOraria = fasciaOraria;
            MaxPartecipanti = maxPartecipanti;
            prenotazioni = new List<string>();
        }

        public int PostiDisponibili => MaxPartecipanti - prenotazioni.Count;

        public bool Prenota(string nomeCliente)
        {
            if (prenotazioni.Count < MaxPartecipanti)
            {
                prenotazioni.Add(nomeCliente);
                return true;
            }
            return false;
        }

        public bool AnnullaPrenotazione(string nomeCliente)
        {
            return prenotazioni.Remove(nomeCliente);
        }

        public string GetInfoPrenotazioni()
        {
            return $"Prenotati: {prenotazioni.Count}/{MaxPartecipanti}. Posti liberi: {PostiDisponibili}.";
        }

        public override string DescrizioneServizio()
        {
            return base.DescrizioneServizio() + $" [Piscina {FasciaOraria}] - {GetInfoPrenotazioni()}";
        }
    }
}
