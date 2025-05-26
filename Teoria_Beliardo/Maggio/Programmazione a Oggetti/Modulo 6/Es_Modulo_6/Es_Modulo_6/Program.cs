using System;
using System.Collections.Generic;

namespace Es_Modulo_6
{
    class Program
    {
        // Classe che rappresenta uno studente
        class Studente
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public int Eta { get; set; }

            public override string ToString()
            {
                return $"ID: {ID}, Nome: {Nome}, Cognome: {Cognome}, Età: {Eta}";
            }
        }

        // Collezioni principali
        static List<Studente> elencoStudenti = new List<Studente>();
        static Dictionary<int, Studente> rubricaStudenti = new Dictionary<int, Studente>();

        static void Main(string[] args)
        {
            int scelta;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Rubrica Studenti ===");
                Console.WriteLine("1. Aggiungi Studente");
                Console.WriteLine("2. Rimuovi Studente");
                Console.WriteLine("3. Cerca Studente");
                Console.WriteLine("4. Modifica Studente");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");
                if (!int.TryParse(Console.ReadLine(), out scelta)) scelta = -1;

                switch (scelta)
                {
                    case 1:
                        AggiungiStudente();
                        break;
                    case 2:
                        RimuoviStudente();
                        break;
                    case 3:
                        CercaStudente();
                        break;
                    case 4:
                        ModificaStudente();
                        break;
                    case 0:
                        Console.WriteLine("Chiusura programma...");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }

                if (scelta != 0)
                {
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey();
                }

            } while (scelta != 0);
        }

        // Funzione per aggiungere uno studente
        static void AggiungiStudente()
        {
            Console.WriteLine("\n--- Aggiungi Studente ---");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            if (rubricaStudenti.ContainsKey(id))
            {
                Console.WriteLine("Errore: ID già esistente.");
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Età: ");
            int eta = int.Parse(Console.ReadLine());

            Studente s = new Studente { ID = id, Nome = nome, Cognome = cognome, Eta = eta };
            elencoStudenti.Add(s);
            rubricaStudenti.Add(id, s);

            Console.WriteLine("Studente aggiunto con successo.");
        }

        // Funzione per rimuovere uno studente
        static void RimuoviStudente()
        {
            Console.WriteLine("\n--- Rimuovi Studente ---");

            Console.Write("Inserisci ID dello studente da rimuovere: ");
            int id = int.Parse(Console.ReadLine());

            if (rubricaStudenti.TryGetValue(id, out Studente studente))
            {
                rubricaStudenti.Remove(id);
                elencoStudenti.Remove(studente);
                Console.WriteLine("Studente rimosso.");
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }
        }

        // Funzione per cercare uno studente
        static void CercaStudente()
        {
            Console.WriteLine("\n--- Cerca Studente ---");

            Console.Write("Inserisci ID dello studente da cercare: ");
            int id = int.Parse(Console.ReadLine());

            if (rubricaStudenti.TryGetValue(id, out Studente studente))
            {
                Console.WriteLine("Studente trovato:");
                Console.WriteLine(studente);
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }
        }

        // Funzione per modificare uno studente
        static void ModificaStudente()
        {
            Console.WriteLine("\n--- Modifica Studente ---");

            Console.Write("Inserisci ID dello studente da modificare: ");
            int id = int.Parse(Console.ReadLine());

            if (rubricaStudenti.TryGetValue(id, out Studente studente))
            {
                Console.Write("Nuovo Nome (attuale: " + studente.Nome + "): ");
                studente.Nome = Console.ReadLine();

                Console.Write("Nuovo Cognome (attuale: " + studente.Cognome + "): ");
                studente.Cognome = Console.ReadLine();

                Console.Write("Nuova Età (attuale: " + studente.Eta + "): ");
                studente.Eta = int.Parse(Console.ReadLine());

                Console.WriteLine("Studente modificato con successo.");
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }
        }
    }
}
