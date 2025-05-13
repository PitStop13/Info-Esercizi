using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ese_1_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Ricerca studente dopo aver inserito la classe **\n");
            string[] cognomi = { "Ferrero", "Bodoaga", "Hoxa", "Marino" };
            string[] nomi = { "Simone", "Denis", "Brian", "Matteo" };
            string[] classi = { "1E Inf", "5A Tur", "1E Inf", "3B Liceo" };
            StampaArray(cognomi, nomi, classi);
            string x = "";

            do
            {
                Console.Write("\nIntroduci la classe (premi q per uscire): ");
                x = Console.ReadLine();
                bool trovato = false;
                for(int i = 0; i < classi.Length; i++)
                {
                    if (classi[i] == x)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nCognome: {cognomi[i]}, nome: {nomi[i]}, classe: {classi[i]}");
                        trovato = true;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                if (!trovato) Console.WriteLine("Elemento non trovato");

            } while (x != "q");
        }

        private static void StampaArray(string[] cognomi, string[] nomi, string[] classi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("L'array è: ");
            for(int i = 0; i < cognomi.Length; i++)
            {
                Console.WriteLine($"\n{i}) Cognome: {cognomi[i]}, nome: {nomi[i]}, classe: {classi[i]}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
