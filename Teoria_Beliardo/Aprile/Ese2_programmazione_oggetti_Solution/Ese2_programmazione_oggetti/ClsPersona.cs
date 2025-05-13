using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ese1_programmazione_oggetti
{
    internal class ClsPersona
    {
        private string nome;
        private string cognome;
        private int eta;
        private string indirizzo;

        /// <summary>
        /// Costruttore, assegna alla variabili private il valore passato al costruttore
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <param name="cognome">Cognome</param>
        /// <param name="eta">Età</param>
        /// <param name="indirizzo">Indirzzo</param>
        public ClsPersona(string nome, string cognome, int eta, string indirizzo)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.eta = eta;
            this.indirizzo = indirizzo;
        }

        /// <summary>
        /// Nome, ritorna la variabile private "nome" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value != "" || value != null)
        /// </summary>
        public string Nome
        {
            get { return nome; }
            // Esercizio 2.1
            set
            {
                // Esercizio A
                for (int i = 0; i < value.Length; i++)
                {
                    if (Convert.ToInt32(value[i]) < 65 || Convert.ToInt32(value[i]) > 90 || Convert.ToInt32(value[i]) < 97 || Convert.ToInt32(value[i]) > 122 || Convert.ToInt32(value[i]) < 128 || Convert.ToInt32(value[i]) > 154 || Convert.ToInt32(value[i]) < 160 || Convert.ToInt32(value[i]) > 165 || Convert.ToInt32(value[i]) < 181 || Convert.ToInt32(value[i]) > 183 || Convert.ToInt32(value[i]) < 198 || Convert.ToInt32(value[i]) > 199 || Convert.ToInt32(value[i]) < 208 || Convert.ToInt32(value[i]) > 212 || Convert.ToInt32(value[i]) < 214 || Convert.ToInt32(value[i]) > 216 || Convert.ToInt32(value[i]) != 222 || Convert.ToInt32(value[i]) < 224 || Convert.ToInt32(value[i]) > 237)
                    {
                        throw new InvalidStringException("Il nome può cotenere solo lettere!");
                    }
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new EmptyStringException("Il nome non può essere vuoto o nullo!");
                }
                try
                {
                    nome = value;
                }
                // Esercizio A
                catch (Exception)
                {
                    Console.WriteLine("Errore: un eccezzione di tipo generico è stata lanciata!");
                }
                finally
                {
                    Console.WriteLine("Blocco finally eseguito.");
                }
            }
        }
        private class EmptyStringException : Exception
        {
            public EmptyStringException(string message) : base(message) { }
        }

        private class InvalidStringException : Exception
        {
            public InvalidStringException(string message) : base(message) { }
        }

        /// <summary>
        /// Cognome, ritorna la variabile private "cognome" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value != "" || value != null)
        /// </summary>
        public string Cognome
        {
            get { return cognome; }
            // Esercizio 2.1
            set
            {
                // Esercizio A
                for (int i = 0; i < value.Length; i++)
                {
                    if ( Convert.ToInt32(value[i]) < 65 || Convert.ToInt32(value[i]) > 90 || Convert.ToInt32(value[i]) < 97 || Convert.ToInt32(value[i]) > 122 || Convert.ToInt32(value[i]) < 128 || Convert.ToInt32(value[i]) > 154 || Convert.ToInt32(value[i]) < 160 || Convert.ToInt32(value[i]) > 165 || Convert.ToInt32(value[i]) < 181 || Convert.ToInt32(value[i]) > 183 || Convert.ToInt32(value[i]) < 198 || Convert.ToInt32(value[i]) > 199 || Convert.ToInt32(value[i]) < 208 || Convert.ToInt32(value[i]) > 212 || Convert.ToInt32(value[i]) < 214 || Convert.ToInt32(value[i]) > 216 || Convert.ToInt32(value[i]) != 222 || Convert.ToInt32(value[i]) < 224 || Convert.ToInt32(value[i]) > 237)
                    {
                        throw new InvalidStringException("Il cognome può cotenere solo lettere!");
                    }
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new EmptyStringException("Il cognome non può essere vuoto o nullo!");
                }
                try
                {
                    cognome = value;
                }
                // Esercizio A
                catch (Exception)
                {
                    Console.WriteLine("Errore: un eccezzione di tipo generico è stata lanciata!");
                }
                finally
                {
                    Console.WriteLine("Blocco finally eseguito.");
                }
            }
        }

        /// <summary>
        /// Eta, ritorna la variabile private "eta" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value > 0)
        /// </summary>
        public int Eta
        {
            get { return eta; }
            // Esercizio 2.1
            set
            {
                if (value <= 0)
                {
                    throw new NumBelowZeroException("L'età deve essere maggiore di zero!");
                }
                try
                {
                    eta = value;
                }
                // Esercizio A
                catch (FormatException) 
                {
                    Console.WriteLine("Errore: l'età deve essere un valore intero!");
                }
                // Esercizio A
                catch (Exception)
                {
                    Console.WriteLine("Errore: un eccezzione di tipo generico è stata lanciata!");
                }
                finally
                {
                    Console.WriteLine("Blocco finally eseguito.");
                }
            }
        }
        private class NumBelowZeroException : Exception
        {
            public NumBelowZeroException(string message) : base(message) { }
        }

        /// <summary>
        /// Indirizzo, ritorna la variabile private "indirizzo" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value != "" || value != null)
        /// </summary>
        public string Indirizzo
        {
            get { return indirizzo; }
            // Esercizio 2.1
            set
            {
                // Esercizio A
                for (int i = 0; i < value.Length; i++)
                {
                    if (Convert.ToInt32(value[i]) < 48 || Convert.ToInt32(value[i]) > 57 || Convert.ToInt32(value[i]) < 65 || Convert.ToInt32(value[i]) > 90 || Convert.ToInt32(value[i]) < 97 || Convert.ToInt32(value[i]) > 122 || Convert.ToInt32(value[i]) < 128 || Convert.ToInt32(value[i]) > 154 || Convert.ToInt32(value[i]) < 160 || Convert.ToInt32(value[i]) > 165 || Convert.ToInt32(value[i]) < 181 || Convert.ToInt32(value[i]) > 183 || Convert.ToInt32(value[i]) < 198 || Convert.ToInt32(value[i]) > 199 || Convert.ToInt32(value[i]) < 208 || Convert.ToInt32(value[i]) > 212 || Convert.ToInt32(value[i]) < 214 || Convert.ToInt32(value[i]) > 216 || Convert.ToInt32(value[i]) != 222 || Convert.ToInt32(value[i]) < 224 || Convert.ToInt32(value[i]) > 237)
                    {
                        throw new InvalidStringException("L'indirizzo può cotenere solo lettere o numeri!");
                    }
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new EmptyStringException("L'indirizzo non può essere vuoto o nullo!");
                }
                try
                {
                    indirizzo = value;
                }
                // Esercizio A
                catch (Exception)
                {
                    Console.WriteLine("Errore: un eccezzione di tipo generico è stata lanciata!");
                }
                finally
                {
                    Console.WriteLine("Blocco finally eseguito.");
                }
            }
        }
    }
}
