using System;
using System.Collections.Generic;

public class Studente
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Eta { get; set; }

    public override string ToString() => $"ID: {ID} - {Nome} {Cognome}, Età: {Eta}";
}

class Program
{
    static List<Studente> studenti = new List<Studente>();
    static Dictionary<int, Studente> rubrica = new Dictionary<int, Studente>();
    static Queue<int> listaAttesa = new Queue<int>();
    static Stack<int> operazioniUndo = new Stack<int>(); // salviamo gli ID rimossi

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Aggiungi studente");
            Console.WriteLine("2. Rimuovi studente");
            Console.WriteLine("3. Cerca studente per ID");
            Console.WriteLine("4. Mostra lista studenti");
            Console.WriteLine("5. Undo ultima rimozione");
            Console.WriteLine("6. Esci");
            Console.Write("Scelta: ");

            switch (Console.ReadLine())
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
                    MostraStudenti();
                    break;
                case "5":
                    UndoRimozione();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }

    static void AggiungiStudente()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Cognome: ");
        string cognome = Console.ReadLine();
        Console.Write("Età: ");
        int eta = int.Parse(Console.ReadLine());

        Studente s = new Studente { ID = id, Nome = nome, Cognome = cognome, Eta = eta };

        studenti.Add(s);
        rubrica[id] = s;
        listaAttesa.Enqueue(id);

        Console.WriteLine("Studente aggiunto e inserito in lista d'attesa.");
    }

    static void RimuoviStudente()
    {
        if (listaAttesa.Count == 0)
        {
            Console.WriteLine("Lista d'attesa vuota.");
            return;
        }

        int id = listaAttesa.Dequeue();

        if (rubrica.Remove(id))
        {
            studenti.RemoveAll(s => s.ID == id);
            operazioniUndo.Push(id);
            Console.WriteLine($"Studente con ID {id} rimosso.");
        }
        else
        {
            Console.WriteLine("Studente non trovato.");
        }
    }

    static void CercaStudente()
    {
        Console.Write("Inserisci ID da cercare: ");
        int id = int.Parse(Console.ReadLine());

        if (rubrica.TryGetValue(id, out Studente s))
        {
            Console.WriteLine("Studente trovato:");
            Console.WriteLine(s);
        }
        else
        {
            Console.WriteLine("Studente non trovato.");
        }
    }

    static void MostraStudenti()
    {
        Console.WriteLine("Lista Studenti:");
        foreach (var s in studenti)
        {
            Console.WriteLine(s);
        }
    }

    static void UndoRimozione()
    {
        if (operazioniUndo.Count == 0)
        {
            Console.WriteLine("Nessuna operazione da annullare.");
            return;
        }

        int id = operazioniUndo.Pop();

        Console.WriteLine("Reinserisci i dati dello studente rimosso:");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Cognome: ");
        string cognome = Console.ReadLine();
        Console.Write("Età: ");
        int eta = int.Parse(Console.ReadLine());

        Studente s = new Studente { ID = id, Nome = nome, Cognome = cognome, Eta = eta };

        studenti.Add(s);
        rubrica[id] = s;
        listaAttesa.Enqueue(id);

        Console.WriteLine("Studente reinserito con successo.");
    }
}
