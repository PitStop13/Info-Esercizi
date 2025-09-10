using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_49_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserici il numero di righe delle matrici A e B: ", 2);
            int c = IntroduciNumero("Inserici il numero di colonne delle matrici A e B: ", 2);
            int[,] matA = new int[r, c];
            int[,] matB = new int[r, c];
            CaricaMat(matA, matB);
            bool uguali = true;
            int i = 0;
            do
            {
                int j = 0;
                do
                {
                    if (matA[i, j] != matB[i, j]) uguali = false;
                    j++;
                } while (j < c && uguali);
                    i++;
            } while (i < r && uguali);
            if (uguali)
                Console.WriteLine("Le matrici A e B sono uguali!");
            else
                Console.WriteLine("Le matrici A e B NON sono uguali!");
            Console.ReadKey();
        }

        private static void CaricaMat(int[,] matA, int[,] matB)
        {
            Console.Clear();
            Stampamat(matA);
            Stampamat(matB, 'B');
            for (int i = 0; i < matA.GetLength(0); i++)
            {
                for (int j = 0; j < matA.GetLength(1); j++)
                {
                    matA[i, j] = IntroduciNumero($"\n\nInserisci un numero nella matrice A in posizione [{i}, {j}]: ");
                    matB[i, j] = IntroduciNumero($"\nInserisci un numero nella matrice B in posizione [{i}, {j}]: ");
                    Console.Clear();
                    Stampamat(matA);
                    Stampamat(matB, 'B');
                }
            }
        }

        private static void Stampamat(int[,] mat, char c = 'A')
        {
            Console.WriteLine($"\n\nLa matrice {c} è:\n");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine();
            }
        }

        private static int IntroduciNumero(string messaggio, int min = int.MinValue)
        {
            int n;
            do
            {
                Console.Write(messaggio);
            } while (!int.TryParse(Console.ReadLine(), out n) || n < min);
            return n;
        }
    }
}
