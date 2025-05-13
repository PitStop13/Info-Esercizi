using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es7Pag115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cognomi1 = { "Ambrogio", "Bodoaga", "Borbone", "Burdisso", "Cerone", "Dzeljo", "Ferrero", "Fontana", "Hoxha", "Kardash", "Lamberti", "Marino" };
            string[] nomi1 = { "Elia", "Constantin", "Josue", "Erica", "Nicolo", "Silhan", "Simone", "Nicolo", "Brian", "Yegor", "Alessandro", "Matteo" };
            string[] cognomi2 = { "Borbone", "Fontana", "Hoxha", "Lamberti", "Minetti", "Mondino", "Mossello" };
            string[] nomi2 = { "Giosue", "Nicolo", "Brian", "Alessandro", "Nicolo", "Giorgia", "Lorenzo" };

            Console.WriteLine("*** FUSIONE DI ARRAY  ***");
            Console.WriteLine("\nPrimo elenco: ");
            StampaElenco(cognomi1, nomi1);
            Console.WriteLine("\nSecondo elenco: ");
            StampaElenco(cognomi2, nomi2);

            int maxLength = cognomi1.Length + cognomi2.Length;
            String[] cognomi = new string[maxLength];
            string[] nomi = new string[maxLength];

            int finalLength = UnisciElenchi(cognomi1, nomi1, cognomi2, nomi2, cognomi, nomi);
            Array.Resize(ref nomi, finalLength);
            Array.Resize(ref cognomi, finalLength);
            Console.WriteLine("\nElenchi uniti: ");
            StampaElenco(cognomi, nomi);


            Console.ReadKey();
        }

        /// <summary>
        /// Unisce due insiemi ordinati di cognome-nome, rimuovendo i duplicati
        /// </summary>
        /// <param name="cognomi1">Array di stringhe contenete il primo inseme di cognomi</param>
        /// <param name="nomi1">Array di stringhe contenete il primo inseme di nomi</param>
        /// <param name="cognomi2">Array di stringhe contenete il secondo inseme di cognomi</param>
        /// <param name="nomi2">Array di stringhe contenete il secondo inseme di nomi</param>
        /// <param name="cognomi">Array di stringhe di cognomi risultatnti dall'unione</param>
        /// <param name="nomi">Array di stringhe di nomi risultatnti dall'unione</param>
        /// <returns>Il numero totale di elementi uniti</returns>
        private static int UnisciElenchi(string[] cognomi1, string[] nomi1, string[] cognomi2, string[] nomi2, string[] cognomi, string[] nomi)
        {
            int i = 0, j = 0, k = -1;
            do
            {
                k++;
                if (cognomi1[i].CompareTo(cognomi2[j]) > 0)
                {
                    cognomi[k] = cognomi2[j];
                    nomi[k] = nomi2[j];
                    j++;

                }
                else
                {
                    cognomi[k] = cognomi1[i];
                    nomi[k] = nomi1[i];
                    if (cognomi1[i].CompareTo(cognomi2[j]) == 0)
                    {
                         j++;
                    }
                    i++;
                }
            } while ((i <= cognomi1.Length - 1) && (j <= cognomi2.Length - 1));

            if(i >= cognomi1.Length)
            {
                for (int h = j; h < cognomi2.Length; h++)
                {
                    k++;
                    cognomi[k] = cognomi2[h];
                    nomi[k] = nomi2[h];
                }
            }
            else
            {
                for (int h = i; h < cognomi1.Length; h++)
                {
                    k++;
                    cognomi[k] = cognomi1[h];
                    nomi[k] = nomi1[h];
                }
            }
            return k + 1;
        }

        private static void StampaElenco(string[] c, string[] n)
        {
            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine($"{i + 1} {c[i]} {n[i]}  ");
            }
        }
    }
}
