using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_55_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserisci la grandezza della matrice quadrata: ", 2);
            int [,] mat = new int[r, r];
            CaricaMat(mat);
            Console.Clear();
            Stampamat(mat);
            Console.WriteLine();
            int i = 0;
            bool maggiori = true;
            do
            {
                int j = i + 1;
                while (j > i && j < mat.GetLength(1) && maggiori)
                {
                    if (mat[i, j] <= 0) maggiori = false;
                    j++;
                }
                i++;
            } while (i < mat.GetLength(0) - 1 && maggiori);
            if (maggiori)
                Console.WriteLine("Gli elementi al disopra della diagonale principale sono tutti maggiori di zero!");
            else
                Console.WriteLine("Gli elementi al disopra della diagonale principale NON sono tutti maggiori di zero!");
            Console.ReadKey();
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
                    mat[i, j] = IntroduciNumero($"Inserisci l'elemento mat [{i}, {j}]: ");
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
