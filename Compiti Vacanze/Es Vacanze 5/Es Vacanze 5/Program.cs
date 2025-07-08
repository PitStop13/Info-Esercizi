using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Vacanze_5
{
    internal class Program
    {
        struct Materia
        {
            public string nome;
            public int orale;
            public int scritto;
            public int pratico;

            public double Media()
            {
                return (orale + scritto + pratico) / 3.0;
            }
        }

        static void Main(string[] args)
        {
            Materia[] materie = new Materia[8];
            bool materieInserite = false;
            bool votiInseriti = false;

            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Esci");
                Console.WriteLine("2. Carica le materie");
                Console.WriteLine("3. Carica i voti");
                Console.WriteLine("4. Visualizza la media della materia X");
                Console.WriteLine("5. Visualizza la media totale");
                Console.WriteLine("6. Visualizza le medie in ordine crescente, il minimo e il massimo");
                Console.Write("\nScegli un'opzione: ");

                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Scelta non valida. Premi un tasto per continuare...");
                    Console.ReadKey();
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Uscita dal programma...");
                        break;

                    case 2:
                        Console.WriteLine("\nInserisci i nomi delle 8 materie:");
                        for (int i = 0; i < materie.Length; i++)
                        {
                            Console.Write($"Materia {i + 1}: ");
                            materie[i].nome = Console.ReadLine();
                        }
                        materieInserite = true;
                        votiInseriti = false;
                        break;

                    case 3:
                        if (!materieInserite)
                        {
                            Console.WriteLine("Devi prima caricare le materie! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("\nInserisci i voti (orale, scritto, pratico) per ogni materia:");
                        for (int i = 0; i < materie.Length; i++)
                        {
                            Console.WriteLine($"\nMateria: {materie[i].nome}");

                            materie[i].orale = LeggiVoto("Orale");
                            materie[i].scritto = LeggiVoto("Scritto");
                            materie[i].pratico = LeggiVoto("Pratico");
                        }
                        votiInseriti = true;
                        break;

                    case 4:
                        if (!materieInserite || !votiInseriti)
                        {
                            Console.WriteLine("Devi prima caricare materie e voti! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("\nInserisci il nome della materia di cui vuoi la media: ");
                        string materiaCercata = Console.ReadLine();
                        bool trovata = false;

                        foreach (var m in materie)
                        {
                            if (m.nome.Equals(materiaCercata, StringComparison.OrdinalIgnoreCase)) //StringComparison.OrdinalIgnoreCase -> annulla il case-sensitivity
                            {
                                Console.WriteLine($"Media di {m.nome}: {m.Media():F2}");
                                trovata = true;
                                break;
                            }
                        }

                        if (!trovata)
                            Console.WriteLine("Materia non trovata.");

                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;

                    case 5:
                        if (!materieInserite || !votiInseriti)
                        {
                            Console.WriteLine("Devi prima caricare materie e voti! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        double sommaTot = 0;
                        foreach (var m in materie)
                        {
                            sommaTot += m.Media();
                        }

                        double mediaTotale = sommaTot / materie.Length;
                        Console.WriteLine($"\nMedia totale dello studente: {mediaTotale:F2}");

                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;

                    case 6:
                        if (!materieInserite || !votiInseriti)
                        {
                            Console.WriteLine("Devi prima caricare materie e voti! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        Materia[] ordinate = (Materia[])materie.Clone();
                        Array.Sort(ordinate, (a, b) => a.Media().CompareTo(b.Media()));

                        Console.WriteLine("\nMedie in ordine crescente:");
                        foreach (var m in ordinate)
                        {
                            Console.WriteLine($"{m.nome}: {m.Media():F2}");
                        }

                        Console.WriteLine($"\nMateria con media più bassa: {ordinate[0].nome} ({ordinate[0].Media():F2})");
                        Console.WriteLine($"Materia con media più alta: {ordinate[7].nome} ({ordinate[7].Media():F2})");

                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Scelta non valida. Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }

            } while (scelta != 1);
        }
        static int LeggiVoto(string tipo)
        {
            int voto;
            do
            {
                Console.Write($"Voto {tipo} (1-10): ");
            } while (!int.TryParse(Console.ReadLine(), out voto) || voto < 1 || voto > 10);

            return voto;
        }
    }
}
