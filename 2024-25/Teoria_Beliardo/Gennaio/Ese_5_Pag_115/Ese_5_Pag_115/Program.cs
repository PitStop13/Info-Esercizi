using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_5_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Cognomi = { "Marino", "Bumbux", "Popuz", "Peano", "Ambrogio", "Mossello", "Bodoaga", "Fontana", "Olivero", "Borbone"};
            string[] Nomi = { "Matteo", "Simone Pietro", "Miner", "Gabriele", "Elia", "Lorenzo", "Denis", "Nicolò", "Pietro", "Giosuè"};
            string[] Squadre = { "Juventus", "Parma", "Nazionale Rumena", "Napoli", "Juventus", "Hellas Verona", "Nazionale Rumena", "Atalanta", "Monza", "Juventus"};
            Console.WriteLine("**Ricerca e ordina i giocatori**");
            StampaVet(Cognomi, Nomi, Squadre);
            string scelta = SquadraValida("\n\nInserisci il Nome di una squadra: ", Squadre);
            string[] ausCognomi = new string[Cognomi.Length];
            string[] ausNomi = new string[Nomi.Length];
            int length = 0;
            TrovaGiocatori(Squadre, Cognomi, Nomi, scelta, ausCognomi, ausNomi, ref length);
            Array.Resize(ref ausNomi, length);
            Array.Resize(ref ausCognomi, length);
            OrdinaGiocatoriBubbleSort(ausCognomi, ausNomi);
            Console.WriteLine("\n\nI calciatori della tua squadra sono:");
            StampaVetOrdinato(ausCognomi, ausNomi);
            Console.ReadKey();
        }

        private static void StampaVetOrdinato(string[] Cognomi, string[] Nomi)
        {
            for (int i = 0; i < Cognomi.Length; i++)
            {
                Console.WriteLine($"\nGiocatore {i + 1}) Cognome: {Cognomi[i]}, Nome: {Nomi[i]}");
            }
        }

        private static void OrdinaGiocatoriBubbleSort(string[] Cognomi, string[] Nomi)
        {
            int i = -1;
            bool scambio;
            do
            {
                i++;
                scambio = false;
                for (int j = Cognomi.Length - 2; j >= i; j--)
                {
                    string sPrecedente = Cognomi[j] + Nomi[j];
                    string sSuccessiva = Cognomi[j + 1] + Nomi[j + 1];
                    if (sSuccessiva.CompareTo(sPrecedente) < 0)
                    {
                        string ausCognomi = Cognomi[j], ausNomi = Nomi[j];
                        Cognomi[j] = Cognomi[j + 1];
                        Nomi[j] = Nomi[j + 1];
                        Cognomi[j + 1] = ausCognomi;
                        Nomi[j + 1] = ausNomi;
                        scambio = true;
                    }
                }
            }while (i <= Cognomi.Length - 2 && scambio);
        }

        private static void TrovaGiocatori(string[] Squadre, string[] Cognomi, string[] Nomi, string scelta, string[] ausCognomi, string[] ausNomi, ref int length)
        {
            for (int i = 0; i < Squadre.Length; i++)
            {
                if (scelta.CompareTo(Squadre[i]) == 0)
                {
                    ausCognomi[length] = Cognomi[i];
                    ausNomi[length] = Nomi[i];
                    length++;
                }
            }
        }

        private static string SquadraValida(string message, string[] Squadre)
        {
            string scelta;
            bool isValid;
            do
            {
                Console.Write(message);
                isValid = false;
                scelta = Console.ReadLine();
            } while (!Squadre.Contains(scelta));
            return scelta;
        }

        private static void StampaVet(string[] Cognomi, string[] Nomi, string[] Squadre)
        {
            for (int i = 0; i < Cognomi.Length; i++)
            {
                Console.WriteLine($"\nGiocatore {i + 1}) Cognome: {Cognomi[i]}, Nome: {Nomi[i]}, Squadra: {Squadre[i]}");
            }
        }
    }
}
