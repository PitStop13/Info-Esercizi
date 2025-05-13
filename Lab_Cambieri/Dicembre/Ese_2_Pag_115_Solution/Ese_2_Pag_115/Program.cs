using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_2_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Ricerca studente dopo aver inserito la classe **\n");
            string[] cognomi = { "Rossi", "Alighieri", "Da Vinci", "Ravotti", "Cecco", "Il Bavaro", "Boccaccio", "Giusiano", "Abbate", "Mana", "Il Bello", "Barberis" };
            string[] nomi = { "Francesco", "Dante", "Leonardo", "Michel", "Angiolieri", "Ludovico", "Giovanni", "Luca", "Andrea", "Roberto", "Filippo", "Alessandro" };
            string[] classi = { "1E Inf", "1E Inf", "2D Elt", "2G Inf", "3A Mec", "3A Liceo", "3B LSSA", "5A Inf","5B Inf", "5C Inf", "5A TUR", "5B TUR" };
            StampaArray(cognomi, nomi, classi);
            string x = "";

            do
            {
                Console.Write("\nIntroduci la classe (premi q per uscire): ");
                x = Console.ReadLine();
                bool trovato = false;
                bool superato = false;
                Ricerca(cognomi, nomi, classi, x, trovato, superato);
            } while (x != "q");
        }

        private static void Ricerca(string[] cognomi, string[] nomi, string[] classi, string x, bool trovato, bool superato)
        {
            int i = 0;
            while (i < classi.Length && !superato)
            {
                if (classi[i] == x)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nCognome: {cognomi[i]}, nome: {nomi[i]}, classe: {classi[i]}");
                    trovato = true;
                    i++;
                }
                else
                {
                    if (classi[i].CompareTo(x) > 0) superato = true;
                    else i++;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (!trovato) Console.WriteLine("Elemento non trovato");
        }

        private static void StampaArray(string[] cognomi, string[] nomi, string[] classi)
        {
            Console.WriteLine("L'array è: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < cognomi.Length; i++)
            {
                Console.WriteLine($"\n{i}) Cognome: {cognomi[i]}, nome: {nomi[i]}, classe: {classi[i]}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
