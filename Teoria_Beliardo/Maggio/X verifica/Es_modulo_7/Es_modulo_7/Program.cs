using System;
using System.Collections.Generic;

namespace RubricaStudenti
{
    class Studente
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public int Eta { get; private set; }

        public Studente(string nome, string cognome, int eta)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cognome) || eta <= 0)
                throw new ArgumentException("Dati non validi");
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }

        public void Modifica(string nome, string cognome, int eta)
        {
            if (!string.IsNullOrWhiteSpace(nome)) Nome = nome;
            if (!string.IsNullOrWhiteSpace(cognome)) Cognome = cognome;
            if (eta > 0) Eta = eta;
        }

        public override string ToString() => $"{Nome} {Cognome}, Età: {Eta}";
    }

    class Program
    {
        static List<Studente> elencoStudenti = new List<Studente>();
        static Dictionary<int, Studente> mappaStudenti = new Dictionary<int, Studente>();
        static int ultimoId = 0;

        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n--- MENU RUBRICA STUDENTI ---");
                Console.WriteLine("1. Aggiungi studente");
                Console.WriteLine("2. Rimuovi studente");
                Console.WriteLine("3. Cerca studente");
                Console.WriteLine("4. Modifica studente");
                Console.WriteLine("5. Mostra tutti gli studenti");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": AggiungiStudente(); break;
                    case "2": RimuoviStudente(); break;
                    case "3": CercaStudente(); break;
                    case "4": ModificaStudente(); break;
                    case "5": MostraStudenti(); break;
                    case "0": continua = false; break;
                    default: Console.WriteLine("Scelta non valida"); break;
                }
            }
        }

        static void AggiungiStudente()
        {
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Cognome: ");
                string cognome = Console.ReadLine();
                Console.Write("Età: ");
                int eta = int.Parse(Console.ReadLine());

                Studente s = new Studente(nome, cognome, eta);
                elencoStudenti.Add(s);
                mappaStudenti[++ultimoId] = s;
                Console.WriteLine($"Studente aggiunto con ID {ultimoId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
        }

        static void RimuoviStudente()
        {
            Console.Write("Inserisci ID dello studente da rimuovere: ");
            if (int.TryParse(Console.ReadLine(), out int id) && mappaStudenti.ContainsKey(id))
            {
                Studente s = mappaStudenti[id];
                elencoStudenti.Remove(s);
                mappaStudenti.Remove(id);
                Console.WriteLine("Studente rimosso.");
            }
            else
            {
                Console.WriteLine("ID non trovato.");
            }
        }

        static void CercaStudente()
        {
            Console.Write("Inserisci ID da cercare: ");
            if (int.TryParse(Console.ReadLine(), out int id) && mappaStudenti.TryGetValue(id, out Studente s))
            {
                Console.WriteLine($"Trovato: {s}");
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }
        }

        static void ModificaStudente()
        {
            Console.Write("Inserisci ID dello studente da modificare: ");
            if (int.TryParse(Console.ReadLine(), out int id) && mappaStudenti.TryGetValue(id, out Studente s))
            {
                Console.Write("Nuovo nome (lascia vuoto per non modificare): ");
                string nome = Console.ReadLine();
                Console.Write("Nuovo cognome (lascia vuoto per non modificare): ");
                string cognome = Console.ReadLine();
                Console.Write("Nuova età (0 per non modificare): ");
                int eta = int.Parse(Console.ReadLine());

                s.Modifica(nome, cognome, eta);
                Console.WriteLine("Studente modificato.");
            }
            else
            {
                Console.WriteLine("ID non trovato.");
            }
        }

        static void MostraStudenti()
        {
            if (mappaStudenti.Count == 0)
            {
                Console.WriteLine("Nessuno studente presente.");
                return;
            }

            foreach (var kvp in mappaStudenti)
            {
                Console.WriteLine($"ID {kvp.Key}: {kvp.Value}");
            }
        }
    }
}
