using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese1_programmazione_oggetti
{
    internal class ClsPersona
    {
        private string nome;
        private string cognome;
        private int eta;
        // Esercizio A
        private string indirizzo;

        /// <summary>
        /// Costruttore, assegna alla variabili private il valore passato al costruttore
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <param name="cognome">Cognome</param>
        /// <param name="eta">Età</param>
        /// <param name="indirizzo">Indirzzo</param>
        public ClsPersona (string nome, string cognome, int eta, string indirizzo)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.eta = eta;
            // Esercizio A
            this.indirizzo = indirizzo;
        }

        /// <summary>
        /// Nome, ritorna la variabile private "nome" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value != "" || value != null)
        /// </summary>
        public string Nome
        {
            get { return nome; }
            //set { nome = value; }
            // Esercizio C
            set {
                while (value == "" || value == null)
                {
                    Console.WriteLine("Inserisci un nome valido:");
                    value = Console.ReadLine();
                }
                nome = value;                   
            }
        }

        /// <summary>
        /// Cognome, ritorna la variabile private "cognome" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value != "" || value != null)
        /// </summary>
        public string Cognome
        {
            get { return cognome; }
            //set { cognome = value; }
            // Esercizio C
            set
            {
                while (value == "" || value == null)
                {
                    Console.WriteLine("Inserisci un cognome valido:");
                    value = Console.ReadLine();
                }
                cognome = value;
            }
        }

        /// <summary>
        /// Eta, ritorna la variabile private "eta" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value > 0)
        /// </summary>
        public int Eta
        {
            get { return eta; }
            /*set { 
                if (value > 0)
                    eta = value;
                else 
                    Console.WriteLine("Errore: l'età deve essere maggiore di 0.");
            }*/
            // Esercizio C
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Inserisci un'età valida:");
                    value = Convert.ToInt32(Console.ReadLine());
                }
                eta = value;
            }
        }

        // Esercizio A
        /// <summary>
        /// Indirizzo, ritorna la variabile private "indirizzo" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value != "" || value != null)
        /// </summary>
        public string Indirizzo
        {
            get { return indirizzo; }
            /*set
            {
                if (value != null || value != "")
                    indirizzo = value;
                else
                    Console.WriteLine("Errore: l'indirizzo deve essere diverso da null o da stringa vuota");
            }*/
            // Esercizio C
            set
            {
                while (value == "" || value == null)
                {
                    Console.WriteLine("Inserisci un'indirizzo valido:");
                    value = Console.ReadLine();
                }
                indirizzo = value;
            }
        }
    }
}
