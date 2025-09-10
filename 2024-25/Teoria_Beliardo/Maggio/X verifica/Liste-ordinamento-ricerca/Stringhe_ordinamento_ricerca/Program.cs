using System;
using System.Collections.Generic;

public class Studente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Eta { get; set; }

    public override string ToString()
    {
        return $"{Nome} {Cognome}, Età: {Eta}";
    }
}

class Program
{
    static void Main()
    {
        // Lista iniziale di studenti
        List<Studente> studenti = new List<Studente>()
        {
            new Studente { Nome = "Luca", Cognome = "Rossi", Eta = 20 },
            new Studente { Nome = "Anna", Cognome = "Bianchi", Eta = 22 },
            new Studente { Nome = "Marco", Cognome = "Verdi", Eta = 19 },
            new Studente { Nome = "Sara", Cognome = "Neri", Eta = 21 },
            new Studente { Nome = "Elena", Cognome = "Gialli", Eta = 23 }
        };

        // Ordinamento per cognome (in ordine alfabetico crescente)
        studenti.Sort((s1, s2) => string.Compare(s1.Cognome, s2.Cognome));

        Console.WriteLine("Studenti ordinati per cognome:");
        foreach (var s in studenti)
        {
            Console.WriteLine(s);
        }

        // Filtraggio: prendo solo gli studenti con età maggiore di 20
        List<Studente> studentiFiltrati = studenti.FindAll(s => s.Eta > 20);

        Console.WriteLine("\nStudenti con età superiore a 20:");
        foreach (var s in studentiFiltrati)
        {
            Console.WriteLine(s);
        }
    }
}
