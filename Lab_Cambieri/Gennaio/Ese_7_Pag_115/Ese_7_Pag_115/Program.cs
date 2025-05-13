using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_7_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Cognomi1 = { "Ambrogio", "Bodoaga", 
                "Burdiso", "Dzeljo", "Ferrero", "Fontana",
                "Hoxha", "Kardash",  "Marino" };
            string[] Nomi1 = { "Elia", "Constantin", 
                "Erica", "Silhan", "Simone", "Nicolo", 
                "Brian", "Yehor", "Matteo" };
            string[] Cognomi2 = { "Borbone", "Fontana", 
                "Hoxha", "Lamberti", "Minetti", "Mondino", "Mossello"};
            string[] Nomi2 = { "Giosue", "Nicolo", 
                "Brian", "Alessandro", "Nicolo", "Giorgia", "Lorenzo"};

            Console.WriteLine("*** FUSIONE DI ARRAY ***");
            Console.WriteLine("\nPrimo elenco: ");
            StampaElenco(Cognomi1, Nomi1);
            Console.WriteLine("\nSecondo elenco: ");
            StampaElenco(Cognomi2, Nomi2);

            int maxLength = Cognomi1.Length + Cognomi2.Length;
            string[] Cognomi = new string[maxLength];
            string[] Nomi = new string[maxLength];

            UnisciElenchi(Cognomi1, Nomi1, Cognomi2, Nomi2, Cognomi, Nomi);
            Console.WriteLine("\nElenchi uniti: ");
            StampaElenco(Cognomi, Nomi);
            Console.ReadKey();
        }

        private static void UnisciElenchi(string[] cognomi1, string[] nomi1, string[] cognomi2, string[] nomi2, string[] cognomi, string[] nomi)
        {
            int i = 0, j = 0, k = -1;
            do
            {
                k++;
                if (cognomi1[i].CompareTo(cognomi2[j]) > 0)
                {
                    cognomi[k] = cognomi2[j];
                    j++;
                }
                else
                {
                    if (cognomi1[i].CompareTo(cognomi2[j]) == 0)
                    {
                        cognomi[k] = cognomi1[i];
                        i++; j++;
                    }
                    else
                    {
                        cognomi[k] = cognomi1[i];
                        i++;
                    }
                }
            } while (i < cognomi1.Length - 1 && j < cognomi2.Length - 1);
            if(i > cognomi1.Length - 1)
            {
                for(int h = j; h < cognomi2.Length; h++)
                {
                    k++;
                    cognomi[k] = cognomi2[h];
                }
            }
            else
            {
                for (int h = i; h < cognomi1.Length; h++)
                {
                    k++;
                    cognomi[k] = cognomi1[h];
                }
            }
            Array.Resize(ref cognomi, k);
            i = 0; j = 0; k = -1;
            do
            {
                k++;
                if (nomi1[i].CompareTo(nomi2[j]) > 0)
                {
                    nomi[k] = nomi2[j];
                    j++;
                }
                else
                {
                    if (nomi1[i].CompareTo(nomi2[j]) == 0)
                    {
                        nomi[k] = nomi1[i];
                        i++; j++;
                    }
                    else
                    {
                        nomi[k] = nomi1[i];
                        i++;
                    }
                }
            } while (i < nomi1.Length - 1 && j < nomi2.Length - 1);
            if (i > nomi1.Length - 1)
            {
                for (int h = j; h < nomi2.Length; h++)
                {
                    k++;
                    nomi[k] = nomi2[h];
                }
            }
            else
            {
                for (int h = i; h < nomi1.Length; h++)
                {
                    k++;
                    nomi[k] = nomi1[h];
                }
            }
            Array.Resize(ref nomi, k);
        }

        private static void StampaElenco(string[] c, string[] n)
        {
            for(int i = 0; i < c.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {c[i]} {n[i]}");
            }
        }
    }
}
