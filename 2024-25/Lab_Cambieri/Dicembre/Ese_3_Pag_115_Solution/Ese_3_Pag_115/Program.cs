using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_3_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Ricerca studente dopo aver inserito la classe **\n");
            string[] cognomi = { "Rossi", "Alighieri", "Alighieri", "Da Vinci", "Ravotti", "Costa", "Cecco", "Il Bavaro", "Boccaccio", "Giusiano", "Abbate", "Mana", "Il Bello", "Barberis" };
            string[] nomi = { "Francesco", "Paolo", "Dante", "Leonardo", "Michel", "Simone", "Angiolieri", "Ludovico", "Giovanni", "Luca", "Andrea", "Roberto", "Filippo", "Alessandro" };
            string[] classi = { "1E Inf", "1E Inf", "1E Inf", "2D Elt", "2G Inf", "2G Inf", "3A Mec", "3A Liceo", "3B LSSA", "5A Inf", "5B Inf", "5C Inf", "5A TUR", "5B TUR" };
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
            string[] ausCognomi = new string[cognomi.Length];
            string[] ausNomi = new string[nomi.Length];
            int i = 0;
            int Length = 0;
            while (i < classi.Length && !superato)
            {
                if (classi[i] == x)
                {
                    ausCognomi[Length] = cognomi[i];
                    ausNomi[Length] = nomi[i];
                    Length++;
                    trovato = true;
                    i++;
                }
                else
                {
                    if (classi[i].CompareTo(x) > 0) superato = true;
                    else i++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            if (!trovato) Console.WriteLine("Elemento non trovato");
            else
            {
                if(Length < 2)
                {
                    Console.WriteLine($"\nCognome: {ausCognomi[0]}, nome: {ausNomi[0]}, classe: {classi[i - 1]}");
                }
                else OrdinamentoTrovati(ausCognomi, ausNomi, classi, i - 1, Length);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void OrdinamentoTrovati(string[] ausCognomi, string[] ausNomi, string[] ausClassi, int i,  int Length)
        {
            int j = 0;
            int invertiti = 0;
            do
            {
                if (ausCognomi[j].CompareTo(ausCognomi[j + 1]) > 0)
                {
                    string ausCognome = ausCognomi[j];
                    ausCognomi[j] = ausCognomi[j + 1];
                    ausCognomi[j + 1] = ausCognome;
                    string ausNome = ausNomi[j];
                    ausNomi[j] = ausNomi[j + 1];
                    ausNomi[j + 1] = ausNome;
                    invertiti++;
                }
                j++;
            } while(j < Length - 1);

            if (invertiti != Length - 1)
            {
                int z = 0;
                do
                {
                    if (ausNomi[z].CompareTo(ausNomi[z + 1]) > 0)
                    {
                        string ausNome = ausNomi[z];
                        ausNomi[z] = ausNomi[z + 1];
                        ausNomi[z + 1] = ausNome;
                        string ausCognome = ausCognomi[z];
                        ausCognomi[z] = ausCognomi[z + 1];
                        ausCognomi[z + 1] = ausCognome;
                    }
                    z++;
                } while (z < Length - 1);
            }

            for(int z = 0; z < Length; z++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nCognome: {ausCognomi[z]}, nome: {ausNomi[z]}, classe: {ausClassi[i]}");
            }

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
