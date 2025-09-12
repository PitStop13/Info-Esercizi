using System;
using System.Collections.Generic;
using System.Linq;

namespace DizionarioVotiStudenti
{
    class Program
    {
        // Dizionario che associa ID studente a voto
        static Dictionary<int, int> votiStudenti = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            // Inserimento voti iniziali
            AggiornaVoto(101, 28);
            AggiornaVoto(102, 25);
            AggiornaVoto(103, 30);

            // Stampa voti iniziali
            Console.WriteLine("Voti iniziali:");
            StampaVoti();

            // Aggiorno voto di uno studente (ID 102)
            AggiornaVoto(102, 27);

            Console.WriteLine("\nDopo aggiornamento voto studente 102:");
            StampaVoti();

            // Calcolo e stampo media voti
            double media = CalcolaMediaVoti();
            Console.WriteLine($"\nMedia voti: {media:F2}");

            // Trovo studente con voto massimo
            int idMax = TrovaStudenteVotoMassimo();
            if (idMax != -1)
            {
                Console.WriteLine($"Studente con voto massimo: ID {idMax}, voto {votiStudenti[idMax]}");
            }
            else
            {
                Console.WriteLine("Nessun voto presente.");
            }
        }

        // Funzione per aggiungere o aggiornare un voto
        static void AggiornaVoto(int idStudente, int voto)
        {
            if (votiStudenti.ContainsKey(idStudente))
            {
                votiStudenti[idStudente] = voto; // Aggiorna voto
            }
            else
            {
                votiStudenti.Add(idStudente, voto); // Aggiunge nuovo record
            }
        }

        // Funzione per stampare tutti i voti
        static void StampaVoti()
        {
            foreach (var record in votiStudenti)
            {
                Console.WriteLine($"ID Studente: {record.Key}, Voto: {record.Value}");
            }
        }

        // Calcola la media dei voti
        static double CalcolaMediaVoti()
        {
            if (votiStudenti.Count == 0) return 0;
            return votiStudenti.Values.Average();
        }

        // Trova l'ID dello studente con voto massimo
        static int TrovaStudenteVotoMassimo()
        {
            if (votiStudenti.Count == 0) return -1;
            int maxVoto = votiStudenti.Values.Max();
            // Trova la prima chiave corrispondente al voto massimo
            return votiStudenti.First(kv => kv.Value == maxVoto).Key;
        }
    }
}
