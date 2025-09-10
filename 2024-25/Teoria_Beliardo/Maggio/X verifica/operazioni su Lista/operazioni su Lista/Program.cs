using System;
using System.Collections.Generic;

namespace Esercizio61
{
    // Classe Studente con attributi Nome, Cognome, Età
    class Studente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        // Costruttore per inizializzare facilmente uno studente
        public Studente(string nome, string cognome, int eta)
        {
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }

        // Metodo per stampare i dati dello studente
        public void StampaInfo()
        {
            Console.WriteLine($"Nome: {Nome}, Cognome: {Cognome}, Età: {Eta}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creo una lista di studenti
            List<Studente> studenti = new List<Studente>();

            // Aggiungo 5 studenti alla lista
            studenti.Add(new Studente("Luca", "Rossi", 20));
            studenti.Add(new Studente("Maria", "Bianchi", 22));
            studenti.Add(new Studente("Marco", "Verdi", 19));
            studenti.Add(new Studente("Anna", "Neri", 21));
            studenti.Add(new Studente("Paolo", "Gialli", 23));

            // Rimuovo uno studente per nome (ad esempio "Marco")
            studenti.RemoveAll(s => s.Nome == "Marco");

            // Cerco uno studente usando Find (ad esempio "Anna")
            Studente trovato = studenti.Find(s => s.Nome == "Anna");

            // Stampo i dati dello studente trovato
            if (trovato != null)
            {
                Console.WriteLine("Studente trovato:");
                trovato.StampaInfo();
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }

            // Stampo tutti gli studenti rimasti nella lista
            Console.WriteLine("\nLista studenti aggiornata:");
            foreach (var studente in studenti)
            {
                studente.StampaInfo();
            }
        }
    }
}
