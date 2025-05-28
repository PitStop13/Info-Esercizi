using System;
using System.Collections.Generic;

namespace Olivero_Pietro_2
{
   class Program
    {
        static List<Studente> Elenco_Studenti = new List<Studente>();
        static Dictionary<int, Studente> Studenti_Dictionary = new Dictionary<int, Studente>();
        static int id = 0;
        static int cont = 0;

        static void Main(string[] args)
        {
            AggiungiStudente();
            AggiungiStudente();
            AggiungiStudente();
            cont = 0;
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n--- RUBRICA STUDENTI ---");
                Console.WriteLine("1. Rimuovi studente");
                Console.WriteLine("2. Cerca studente");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": RimuoviStudente(); break;
                    case "2": CercaStudente(); break;
                    case "0": continua = false; break;
                    default: Console.WriteLine("Scelta non valida"); break;
                }
            }
        }

        static void AggiungiStudente()
        {
            cont++;
            Studente s = null;
            while (s == null)
            try
            {
                Console.Write($"Nome {cont}o studente: ");
                string nome = Console.ReadLine();
                Console.Write($"Cognome {cont}o studente: ");
                string cognome = Console.ReadLine();
                Console.Write($"Età {cont}o studente: ");
                int eta = int.Parse(Console.ReadLine());

                s = new Studente(nome, cognome, eta);
                Elenco_Studenti.Add(s);
                Studenti_Dictionary[++id] = s;
                Console.WriteLine($"Studente {cont} aggiunto con ID {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
        }

        static void RimuoviStudente()
        {
            Console.Write("Inserisci ID dello studente da rimuovere: ");
            if (int.TryParse(Console.ReadLine(), out int id) && Studenti_Dictionary.ContainsKey(id))
            {
                Studente s = Studenti_Dictionary[id];
                Elenco_Studenti.Remove(s);
                Studenti_Dictionary.Remove(id);
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
            if (int.TryParse(Console.ReadLine(), out int id) && Studenti_Dictionary.TryGetValue(id, out Studente s))
            {
                Console.WriteLine($"Trovato: {s}");
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }
        }

        
    }
}
