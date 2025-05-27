using System;
using System.Collections.Generic;

namespace RubricaStudentiApp
{
    class Studente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        public Studente(string nome, string cognome, int eta)
        {
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }

        public void StampaInfo()
        {
            Console.WriteLine($"Nome: {Nome}, Cognome: {Cognome}, Età: {Eta}");
        }
    }

    class Program
    {
        // Lista per memorizzare studenti
        static List<Studente> listaStudenti = new List<Studente>();

        // Dizionario per accesso rapido per ID
        static Dictionary<int, Studente> rubrica = new Dictionary<int, Studente>();

        // Contatore ID (semplice auto-incremento)
        static int prossimoID = 1;

        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\nMenu Rubrica Studenti:");
                Console.WriteLine("1 - Aggiungi studente");
                Console.WriteLine("2 - Rimuovi studente");
                Console.WriteLine("3 - Cerca studente");
                Console.WriteLine("4 - Visualizza tutti");
                Console.WriteLine("5 - Esci");
                Console.Write("Scegli un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiStudente();
                        break;
                    case "2":
                        RimuoviStudente();
                        break;
                    case "3":
                        CercaStudente();
                        break;
                    case "4":
                        VisualizzaTutti();
                        break;
                    case "5":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }

        // Metodo per aggiungere studente
        static void AggiungiStudente()
        {
            Console.Write("Inserisci Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Inserisci Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Inserisci Età: ");
            int eta = int.Parse(Console.ReadLine());

            Studente s = new Studente(nome, cognome, eta);

            // Aggiungo a lista e a dizionario con ID unico
            listaStudenti.Add(s);
            rubrica.Add(prossimoID, s);

            Console.WriteLine($"Studente aggiunto con ID: {prossimoID}");

            prossimoID++;
        }

        // Metodo per rimuovere studente
        static void RimuoviStudente()
        {
            Console.Write("Inserisci ID studente da rimuovere: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (rubrica.ContainsKey(id))
                {
                    // Rimuovo da dizionario
                    Studente s = rubrica[id];
                    rubrica.Remove(id);

                    // Rimuovo dalla lista
                    listaStudenti.Remove(s);

                    Console.WriteLine($"Studente con ID {id} rimosso.");
                }
                else
                {
                    Console.WriteLine("ID non trovato.");
                }
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
        }

        // Metodo per cercare studente
        static void CercaStudente()
        {
            Console.Write("Inserisci ID studente da cercare: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (rubrica.TryGetValue(id, out Studente s))
                {
                    Console.WriteLine("Studente trovato:");
                    s.StampaInfo();
                }
                else
                {
                    Console.WriteLine("Studente non trovato.");
                }
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
        }

        // Metodo per visualizzare tutti gli studenti
        static void VisualizzaTutti()
        {
            Console.WriteLine("\nElenco studenti:");

            foreach (var kvp in rubrica)
            {
                Console.Write($"ID: {kvp.Key} - ");
                kvp.Value.StampaInfo();
            }
        }
    }
}
