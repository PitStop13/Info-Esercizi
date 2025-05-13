using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_8_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cognomi1 = { "Ambrogio", "Bodoaga", "Borbone", "Burdisso", "Cerone", "Dzeljo", "Ferrero", "Fontana", "Hoxha", "Kardash", "Lamberti", "Marino" };
            string[] nomi1 = { "Elia", "Constantin", "Josue", "Erica", "Nicolo", "Silhan", "Simone", "Nicolo", "Brian", "Yegor", "Alessandro", "Matteo" };
            string[] cognomi2 = { "Minetti", "Mondino", "Mossello" };
            string[] nomi2 = { "Nicolo", "Giorgia", "Lorenzo" };

            Console.WriteLine("*** FUSIONE DI ARRAY  ***");
            Console.WriteLine("\nPrimo elenco: ");
            StampaElenco(cognomi1, nomi1);
            Console.WriteLine("\nSecondo elenco: ");
            StampaElenco(cognomi2, nomi2);

            int maxLength = cognomi1.Length + cognomi2.Length;
            String[] cognomi = new string[maxLength];
            string[] nomi = new string[maxLength];

            UnisciElenchi(cognomi1, nomi1, cognomi2, nomi2, cognomi, nomi);
            Console.WriteLine("\nElenchi uniti: ");
            StampaElenco(cognomi, nomi);


            Console.ReadKey();
        }

        /// <summary>
        /// Unisce due insiemi ordinati e distinti di cognome-nome
        /// </summary>
        /// <param name="cognomi1">Array di stringhe contenete il primo inseme di cognomi</param>
        /// <param name="nomi1">Array di stringhe contenete il primo inseme di nomi</param>
        /// <param name="cognomi2">Array di stringhe contenete il secondo inseme di cognomi</param>
        /// <param name="nomi2">Array di stringhe contenete il secondo inseme di nomi</param>
        /// <param name="cognomi">Array di stringhe di cognomi risultatnti dall'unione</param>
        /// <param name="nomi">Array di stringhe di nomi risultatnti dall'unione</param>
        /// <returns>Due insiemi ordinati e distinti di cognome-nome</returns>
        private static void UnisciElenchi(string[] cognomi1, string[] nomi1, string[] cognomi2, string[] nomi2, string[] cognomi, string[] nomi)
        {
            Array.Resize(ref cognomi1, cognomi1.Length + 1);
            Array.Resize(ref nomi1, nomi1.Length + 1);
            Array.Resize(ref cognomi2, cognomi2.Length + 1);
            Array.Resize(ref nomi2, nomi2.Length + 1);
            cognomi1[cognomi1.Length - 1] = "zz";
            nomi1[nomi1.Length - 1] = "zz";
            cognomi2[cognomi2.Length - 1] = "zz";
            nomi2[nomi2.Length - 1] = "zz";

            int i = 0, j = 0;
            for(int k = 0; k < cognomi1.Length + cognomi2.Length - 1; k++)
            {
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
                    i++;
                }
            }
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
