using System;
using System.Collections.Generic;

namespace OrdinamentoFiltraggioStudenti
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
            // Creo una lista con studenti di esempio
            List<Studente> studenti = new List<Studente>
            {
                new Studente("Mario", "Rossi", 20),
                new Studente("Luca", "Bianchi", 22),
                new Studente("Anna", "Verdi", 19),
                new Studente("Sara", "Neri", 23),
                new Studente("Paolo", "Gialli", 21)
            };

            // Ordinamento per cognome (alfabetico)
            studenti.Sort((s1, s2) => s1.Cognome.CompareTo(s2.Cognome));

            Console.WriteLine("Studenti ordinati per cognome:");
            foreach (var studente in studenti)
            {
                studente.StampaInfo();
            }

            // Filtro studenti con età > valore dato
            Console.Write("\nInserisci età minima per filtro: ");
            if (int.TryParse(Console.ReadLine(), out int etaMinima))
            {
                List<Studente> filtrati = studenti.FindAll(s => s.Eta > etaMinima);

                Console.WriteLine($"\nStudenti con età superiore a {etaMinima}:");
                foreach (var studente in filtrati)
                {
                    studente.StampaInfo();
                }

                if (filtrati.Count == 0)
                {
                    Console.WriteLine("Nessuno studente soddisfa il criterio.");
                }
            }
            else
            {
                Console.WriteLine("Input non valido.");
            }
        }
    }
}
