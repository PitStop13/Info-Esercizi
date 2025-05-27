using System;
using System.Collections.Generic;

namespace Esercizio62
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
        static void Main(string[] args)
        {
            // Creo un Dictionary con chiave int (ID) e valore Studente
            Dictionary<int, Studente> rubrica = new Dictionary<int, Studente>();

            // Aggiungo 3 studenti con ID univoci
            rubrica.Add(101, new Studente("Luca", "Rossi", 20));
            rubrica.Add(102, new Studente("Maria", "Bianchi", 22));
            rubrica.Add(103, new Studente("Anna", "Neri", 21));

            // Ricerca sicura con TryGetValue per ID 102
            if (rubrica.TryGetValue(102, out Studente trovato))
            {
                Console.WriteLine("Studente trovato con ID 102:");
                trovato.StampaInfo();
            }
            else
            {
                Console.WriteLine("Studente con ID 102 non trovato.");
            }

            // Rimuovo lo studente con ID 101
            bool rimosso = rubrica.Remove(101);

            // Stampo messaggio di conferma rimozione
            if (rimosso)
            {
                Console.WriteLine("Studente con ID 101 rimosso correttamente.");
            }
            else
            {
                Console.WriteLine("Studente con ID 101 non trovato, impossibile rimuovere.");
            }

            // Stampo tutti gli studenti rimasti
            Console.WriteLine("\nRubrica aggiornata:");
            foreach (var kvp in rubrica)
            {
                Console.Write($"ID: {kvp.Key} - ");
                kvp.Value.StampaInfo();
            }
        }
    }
}
