using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_vacanze_7
{
    internal class Program
    {
        struct Contatto
        {
            public string nome;
            public string indirizzo;
            public string telefono;

            public override string ToString()
            {
                return $"{nome}, {indirizzo}, {telefono}";
            }
        }

        static void Main(string[] args)
        {
            Contatto[] rubrica = new Contatto[100];
            int numeroContatti = 0;
            
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu rubrica:");
                Console.WriteLine("1. Esci");
                Console.WriteLine("2. Visualizza un nominativo");
                Console.WriteLine("3. Modifica dati di un nominativo");
                Console.WriteLine("4. Visualizza l’intera rubrica in ordine alfabetico");
                Console.WriteLine("5. Inserisci nuovo nominativo");
                Console.Write("\nScegli un'opzione: ");

                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    scelta = 0;
                }

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Uscita dal programma...");
                        break;

                    case 2: // visualizza nominativo
                        Console.Write("Inserisci il nome da cercare: ");
                        string nomeCercato = Console.ReadLine();

                        bool trovato = false;
                        for (int i = 0; i < numeroContatti; i++)
                        {
                            if (rubrica[i].nome.Equals(nomeCercato, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(rubrica[i]);
                                trovato = true;
                                break;
                            }
                        }
                        if (!trovato)
                            Console.WriteLine("Nominativo non trovato.");
                        break;

                    case 3: // modifica nominativo
                        Console.Write("Inserisci il nome da modificare: ");
                        string nomeModifica = Console.ReadLine();

                        bool modificato = false;
                        for (int i = 0; i < numeroContatti; i++)
                        {
                            if (rubrica[i].nome.Equals(nomeModifica, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Nuovo indirizzo: ");
                                rubrica[i].indirizzo = Console.ReadLine();

                                Console.Write("Nuovo telefono: ");
                                rubrica[i].telefono = Console.ReadLine();

                                Console.WriteLine("Contatto aggiornato!");
                                modificato = true;
                                break;
                            }
                        }
                        if (!modificato)
                            Console.WriteLine("Nominativo non trovato.");
                        break;

                    case 4: // ordina e visualizza rubrica
                        if (numeroContatti == 0)
                        {
                            Console.WriteLine("Rubrica vuota!");
                            break;
                        }

                        Contatto[] ordinata = new Contatto[numeroContatti];
                        for (int i = 0; i < numeroContatti; i++)
                            ordinata[i] = rubrica[i];

                        for (int i = 0; i < numeroContatti - 1; i++)
                        {
                            for (int j = i + 1; j < numeroContatti; j++)
                            {
                                if (string.Compare(ordinata[i].nome, ordinata[j].nome, true) > 0)
                                {
                                    Contatto temp = ordinata[i];
                                    ordinata[i] = ordinata[j];
                                    ordinata[j] = temp;
                                }
                            }
                        }

                        Console.WriteLine("\nRubrica in ordine alfabetico:");
                        for (int i = 0; i < numeroContatti; i++)
                        {
                            Console.WriteLine(ordinata[i]);
                        }
                        break;

                    case 5: // inserisci nuovo nominativo
                        if (numeroContatti >= rubrica.Length)
                        {
                            Console.WriteLine("Rubrica piena!");
                            break;
                        }

                        Console.Write("Nome: ");
                        rubrica[numeroContatti].nome = Console.ReadLine();

                        Console.Write("Indirizzo: ");
                        rubrica[numeroContatti].indirizzo = Console.ReadLine();

                        Console.Write("Telefono: ");
                        rubrica[numeroContatti].telefono = Console.ReadLine();

                        numeroContatti++;
                        Console.WriteLine("Contatto inserito!");
                        break;

                    default:
                        Console.WriteLine("Scelta non valida!");
                        break;
                }

                if (scelta != 1)
                {
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey();
                }

            } while (scelta != 1);
        }
    }
}
