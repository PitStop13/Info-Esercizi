using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_Pag_98_99_Ricerca_Blocchi_Prof
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cognomi = { "Barberis", "Barbero", "Bruno", "Calleri", "Costantino", "Dadone", "Ferrero", "Giaccone", "Giachello", "Musso", "Napoli", "Operti", "Pansa", "Pensa", "Rossi", "Rosso", "Viglietti" };
            Console.WriteLine("** RICERCA A BLOCCHI **\n");

            Console.WriteLine("Array di ricerca: \n");
            StampaArray(cognomi);
            string x = "";

            do
            {
                Console.Write("\n\nIntroduci il cognome da cercare (q per uscire): ");
                x = Console.ReadLine();

                bool trovato = false, esci = false;
                int lb = (int)Math.Sqrt(cognomi.Length);//convertiamo in int
                int i = lb - 1;

                do
                {
                    if (cognomi[i] == x)
                    {
                        trovato = true;
                    }
                    else
                    {
                        if (cognomi[i].CompareTo(x) > 0)
                        {
                            EsaminaBloccho(ref i, lb, ref trovato, ref esci, x, cognomi);
                        }
                        else
                        {
                            i += lb;
                        }
                    }
                } while (!trovato && !esci && (i <= cognomi.Length - 1));

                if (trovato)
                {
                    Console.WriteLine($"Elemento trovato in posizione {i}");
                }
                else
                {
                    if (esci)
                    {
                        Console.WriteLine("Elemento non trovato");
                    }
                    else
                    {
                        UltimoBlocco(cognomi, i, x, lb);
                    }
                }
            } while (x != "q");
        }

        private static void UltimoBlocco(string[] v, int i, string x, int lb)
        {
            i = i - lb + 1;

            while (v[i].CompareTo(x) < 0 && i < v.Length - 1)
            {
                i++;
            }

            if (v[i] == x)
            {
                Console.WriteLine($"Elemento trovato in posizione {i}");
            }
            else
            {
                Console.WriteLine("Elemento non trovato");
            }
        }

        private static void EsaminaBloccho(ref int i, int lb, ref bool trovato, ref bool esci, string x, string[] v)
        {
            int j = i - lb + 1;

            while (v[j].CompareTo(x) < 0 && j < i - 1)
            {
                j++;
            }

            if (v[j] == x)
            {
                trovato = true;
                i = j;
            }
            else
            {
                esci = true;
            }
        }

        private static void StampaArray(string[] v)
        {
            for(int i = 0; i < v.Length; i++)
            {
                Console.Write($"{i}){v[i]}   ");
                if((i + 1)%4 == 0) Console.WriteLine();//va a capo ogni 4
            }
        }
    }
}
