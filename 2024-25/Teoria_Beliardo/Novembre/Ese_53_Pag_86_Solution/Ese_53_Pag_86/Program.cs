using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_53_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] mat;
            int r;
            Console.Write("Inserisci dimensione matrice rxr: ");
            r = int.Parse(Console.ReadLine());
            mat = new int[r, r];
            InserisciDati(mat);
            Console.Clear();
            Stampamat(mat);
            Console.WriteLine();
            int somma = sommaVal1(mat);
            Console.WriteLine("La somma degli elementi al di sotto della diagonale è: " + somma);
            somma = sommaVal2(mat);
            Console.WriteLine("La somma degli elementi al di sotto della diagonale è: " + somma);
            Console.ReadKey();
        }

        private static int sommaVal2(int[,] mat)
        {
            int somma = 0, j;
            for (int i = 1; i < mat.GetLength(0); i++)
            {
                j = mat.GetLength(1)-1;
                while (i + j >= mat.GetLength(1))
                {
                    somma += mat[i, j];
                    j--;
                }
            }
            return somma;
        }

        private static int sommaVal1(int[,] mat)
        {
            int i = 1, j, posPrimoElem = mat.GetLength(1)-1, somma = 0;
            while (i < mat.GetLength(0))
            {
                j = mat.GetLength(1)-1;
                while (j >= posPrimoElem)
                {
                    somma += mat[i, j];
                    j--;
                }
                posPrimoElem--;
                i++;
            }
            return somma;
        }

        /*
         * 0 0 0 0
         * 0 0 0 1
         * 0 0 2 3
         * 0 4 5 6
         * 
         * cord: 1,3 - 2,2 - 2,3 - 3,1 - 3,2 - 3,3
         * 
         * 0,0 - 0,1 - 0,2 - 1,0 - 1,1 - 1,2
         * 2,0 - 2,1 - 3,0
         * 
         * j >= i
         */
        private static void InserisciDati(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Clear();
                    Stampamat(mat);
                    Console.WriteLine();
                    Console.Write($"Inserisci l'elemento mat [{i}, {j}]: ");
                    mat[i, j] = int.Parse(Console.ReadLine());
                }
            }
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
