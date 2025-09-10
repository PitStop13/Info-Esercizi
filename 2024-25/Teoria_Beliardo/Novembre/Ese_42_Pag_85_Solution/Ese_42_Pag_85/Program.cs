using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_42_Pag_85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserisci la dimensione della matrice quadrata: ", 2);
            int[,] mat = new int[r, r];
            Caricamat(mat);
            int maxCol = r - 1, maxRow = r - 1, minRow = 0, minCol = 0, n = 1;
            bool spirale = true;
            do
            {
                int j = minCol;
                while (j <= maxCol && spirale)
                {
                    if (mat[minRow, j] != n) spirale = false; 
                    n++;
                    j++;
                }
                minRow++;
                int i = minRow;
                while (i <= maxRow && spirale)
                {
                    if (mat[i, maxCol] != n) spirale = false;
                    n++;
                    i++;
                }
                maxCol--;
                j = maxCol;
                while (j >= minCol && spirale)
                {
                    if (mat[maxRow, j] != n) spirale = false;
                    n++;
                    j--;
                }
                maxRow--;
                i = maxRow;
                while (i >= minRow && spirale)
                {
                    if (mat[i, minCol] != n) spirale = false;
                    n++;
                    i--;
                }
                minCol++;
            } while (n < r*r && spirale);
            if (spirale)
                Console.WriteLine($"La matrice quadrata di lunghezza ({r}x{r}) è a spirale");
            else
                Console.WriteLine($"La matrice quadrata di lunghezza ({r}x{r}) NON è a spirale");
            Console.ReadKey();
        }

        private static void Caricamat(int[,] mat)
        {
            Console.WriteLine("La matrice è:");
            Console.Clear();
            StampaMat(mat);
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = IntroduciNumero($"\n\nInserisci un numero nella posizione [{i}, {j}]: ", 1);
                    Console.WriteLine("La matrice è:");
                    Console.Clear();
                    StampaMat(mat);
                }
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

        private static void StampaMat(int[,] mat)
        {
            Console.WriteLine("La matrice è: ");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(4) + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
