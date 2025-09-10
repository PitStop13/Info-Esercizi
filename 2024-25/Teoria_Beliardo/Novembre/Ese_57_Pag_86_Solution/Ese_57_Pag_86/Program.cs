using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_57_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] mat;
            int r, c, elemento = 1, val1 = 1, val2 = 1;
            Console.Write("Inserisci dimensione matrice rxc\nr: ");
            r = int.Parse(Console.ReadLine());
            Console.Write("c: ");
            c = int.Parse(Console.ReadLine());
            mat = new int[r, c];
            /* 1 1 3 5 8 13 21
             */
            for(int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if(elemento <= 2) mat[i, j] = 1;
                    else
                    {

                    }
                }
            }
            InserisciDati(mat);
            Console.Clear();
            Stampamat(mat);
            Console.WriteLine();
            Console.ReadKey();
        }

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
        private static void Stampamat(int[,] mat1)
        {
            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                for (int j = 0; j < mat1.GetLength(1); j++)
                {
                    Console.Write(mat1[i, j].ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }
    }
}
