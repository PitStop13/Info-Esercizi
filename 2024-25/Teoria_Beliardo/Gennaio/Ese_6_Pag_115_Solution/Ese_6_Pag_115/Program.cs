using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ese_6_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Cognomi = { "Marino", "Bumbux", "Popuz", "Peano", "Ambrogio", "Mossello", "Bodoaga", "Fontana", "Olivero", "Borbone", "Cerone", "Negro", "Parola", "Singh", "Minetti", "Tortone", "Dzeljo", "Bonavia", "Hoxa", "Rrhozzani" };
            string[] Nomi = { "Matteo", "Simone Pietro", "Miner", "Gabriele", "Elia", "Lorenzo", "Denis", "Nicolò", "Pietro", "Giosuè", "Nicolò", "Andrea", "Roberto", "Jas", "Nicolò", "Roberto", "Shilan", "Luca", "Brian", "Mateo" };
            string[] Squadre = { "Juventus", "Parma", "Nazionale Rumena", "Juventus", "Juventus", "Hellas Verona", "Nazionale Rumena", "Atalanta", "Monza", "Juventus", "Lecce", "Napoli", "Nazionale Tedesca", "Napoli", "Hellas Verona", "Juventus", "Kosovo", "Roma", "Milan", "Milan" };
            Console.WriteLine("**Numero giocatori per squadra in ordine decrescente**");
            StampaVet(Cognomi, Nomi, Squadre);
            string[] ausSquadre = new string[Squadre.Length];
            int length = 0;
            trovaSquadre(Squadre, ausSquadre, ref length);
            Array.Resize(ref ausSquadre, length);
            int[] numGiocatori = new int[ausSquadre.Length];
            numGiocatoriSquadra(Squadre, ausSquadre, numGiocatori);
            ordinaSquadreDecrescente(ausSquadre, numGiocatori);
            Console.WriteLine("\n\nIl numero di giocatori per squadra in ordine decrescente è:");
            StampaVetSquadre(ausSquadre, numGiocatori);
            Console.ReadKey();
        }

        private static void StampaVetSquadre(string[] squadre, int[] numGiocatori)
        {
            for (int i = 0; i < squadre.Length; i++)
            {
                Console.WriteLine($"\n{i + 1}) Squadra: {squadre[i]}, Numero di giocatori: {numGiocatori[i]}");
            }
        }

        private static void ordinaSquadreDecrescente(string[] Squadre, int[] numGiocatori)
        {
            int i = -1;
            bool scambio;
            do
            {
                i++;
                scambio = false;
                for (int j = numGiocatori.Length - 2; j >= i; j--)
                {
                    if (numGiocatori[j + 1].CompareTo(numGiocatori[j]) > 0)
                    {
                        string ausSquadre = Squadre[j];
                        int ausNumGiocatori = numGiocatori[j];
                        Squadre[j] = Squadre[j + 1];
                        numGiocatori[j] = numGiocatori[j + 1];
                        Squadre[j + 1] = ausSquadre;
                        numGiocatori[j + 1] = ausNumGiocatori;
                        scambio = true;
                    }
                }
            } while (i <= numGiocatori.Length - 2 && scambio);
        }

        private static void numGiocatoriSquadra(string[] squadre, string[] ausSquadre, int[] numGiocatori)
        {
            for (int i = 0; i < ausSquadre.Length; i++)
            {
                numGiocatori[i] = 0;//Inizializzo l'array
                for (int j = 0; j < squadre.Length; j++)
                {
                    if (ausSquadre[i].Contains(squadre[j]))
                    {
                        numGiocatori[i]++;
                    }
                }
            }
        }

        private static void trovaSquadre(string[] squadre, string[] ausSquadre, ref int length)
        {

            for (int i = 0; i < squadre.Length; i++)
            {
                if (!ausSquadre.Contains(squadre[i]))
                {
                    ausSquadre[length] = squadre[i];
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
                Console.WriteLine($"\n{i + 1}) Cognome: {Cognomi[i]}, Nome: {Nomi[i]}, Squadra: {Squadre[i]}");
            }
        }
    }
}
