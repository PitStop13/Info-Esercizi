using System;

namespace Esercizio_2_1_Persona
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il nome: ");
            string nome = Console.ReadLine();

            Console.Write("Inserisci il cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Inserisci l'età: ");
            int eta;
            if (!int.TryParse(Console.ReadLine(), out eta))
            {
                Console.WriteLine("Inserisci un numero valido per l'età.");
                eta = -1; // così fallisce la validazione
            }

            Persona p1 = new Persona(nome, cognome, eta);
            Console.WriteLine();
            p1.StampaInfo();

            Console.ReadLine(); // per bloccare la console
        }
    }

    class Persona
    {
        private string nome;
        private string cognome;
        private int eta;

        public Persona(string nome,string cognome,int eta)
        {
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }

        public string Nome
        {
            get { return nome; }
            set {
                if (string.IsNullOrEmpty(value)) 
                {
                    Console.WriteLine("Il nome non può essere vuoto."); 
                }
                else { nome = value; }
                
                }
        }
        public string Cognome
        {
            get { return cognome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                { 
                    Console.WriteLine("Il cognome non può essere vuoto.");
                }
                else
                {
                    cognome = value;
                }
                
            }
        }
        public int Eta
        {
            get { return eta; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("L'età non può essere negativa.");
                }
                else { eta = value; }
                
            }
        }

        public void StampaInfo()
        {
            if(!string.IsNullOrEmpty(nome)&& !string.IsNullOrEmpty(cognome)&&eta>0)
            Console.WriteLine($"{nome} {cognome} {eta} anni.");
        }

    }


}
