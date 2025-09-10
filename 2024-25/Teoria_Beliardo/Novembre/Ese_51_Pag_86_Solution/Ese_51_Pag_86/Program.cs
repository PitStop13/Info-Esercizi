using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_51_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserisci il numero di righe della matrice: ", 2);
            int c = IntroduciNumero("Inserisci il numero di colonne della matrice: ", 2);
            int[,] mat = new int[r, c];
            int[] riga = new int[c];
            CaricaMat(mat);
            Console.Clear();
            Stampamat(mat);
            Console.WriteLine();
            for (int j = 0; j < c; j++)
            {
                riga[j] = sommaColonna(mat, j);
            }
            stampaVet(riga);
            Console.ReadKey();
        }

        private static void stampaVet(int[] riga)
        {
            Console.WriteLine("Vettore somma degli elementi delle colonne: ");
            for (int i = 0; i < riga.Length; i++)
            {
                Console.Write(riga[i].ToString().PadLeft(3));
            }
        }

        private static int sommaColonna(int[,] mat, int j)
        {
            int somma = 0;
            for (int i= 0; i < mat.GetLength(0); i++)
            {
                somma += mat[i, j];
            }
            return somma;
        }

        private static void CaricaMat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Clear();
                    Stampamat(mat);
                    Console.WriteLine();
                    mat[i, j] = IntroduciNumero($"Inserisci un numero nella posizione [{i}, {j}]: ");
                }
            }
        }

        private static int IntroduciNumero(string messaggio, int min = int.MinValue)
        {
            int n;
            do
            {
                Console.Write(messaggio);
            } while(!int.TryParse(Console.ReadLine(), out n) || n < min);
            return n;
        }

        private static void Stampamat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }
    }
}
