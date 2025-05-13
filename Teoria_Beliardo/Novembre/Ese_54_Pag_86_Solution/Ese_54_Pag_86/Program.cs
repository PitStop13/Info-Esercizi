using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_54_Pag_86
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
            if (elementiUguali(mat))
                Console.WriteLine("1)Gli elementi al disotto della diagonale principale sono uguali");
            else
                Console.WriteLine("1)Gli elementi al disotto della diagonale principale NON sono uguali");
            if (elementiUguali2(mat))
                Console.WriteLine("2)Gli elementi al disotto della diagonale principale sono uguali");
            else
                Console.WriteLine("2)Gli elementi al disotto della diagonale principale NON sono uguali");
            Console.ReadKey();
        }

        private static bool elementiUguali2(int[,] mat)
        {
            int j, val = mat[1, 0];
            bool uguali = true;
            for (int i = 1; i < mat.GetLength(0); i++)
            {
                j = 0;
                while (j < i && uguali)
                {
                    if (mat[i, j] != val) uguali = false;
                    j++;
                }
            }
            return uguali;
        }

        private static bool elementiUguali(int[,] mat)
        {
            int i = 1, j, nElem = 1, val = mat[1, 0];
            bool uguali = true;
            while (i < mat.GetLength(0))
            {
                j = 0;
                while (j < nElem && uguali)
                {
                    if(mat[i, j] != val) uguali = false;
                    j++;
                }
                nElem++;
                i++;
            }
            return uguali;
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
