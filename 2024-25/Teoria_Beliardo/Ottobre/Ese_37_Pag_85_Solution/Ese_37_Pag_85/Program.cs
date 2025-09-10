using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_37_Pag_85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Introduci il numero di righe della matrice: ", 2);
            int c = IntroduciNumero("\n\nIntroduci il numero di colonne della matrice: ", 2);
            int[,] mat = new int[r,c];
            CaricaMat(mat);
            bool cond = true;
            int i = 0;
            do
            {
                int j = 0;
                do
                {
                    if (mat[i, j] != mat[i, j + 1] || mat[i, j] != mat[i + 1, j]) cond = false;
                    j++;
                } while (j < mat.GetLength(1) - 1 && cond);
                i++;
            } while (i < mat.GetLength(0) - 1 && cond);
            if (cond)
                Console.WriteLine($"\n\nGli elementi della matrice ({r}x{c}) sono tutti uguali!");
            else
                Console.WriteLine($"\n\nGli elementi della matrice ({r}x{c}) NON sono tutti uguali!");
            Console.ReadKey();
        }

        private static void CaricaMat(int[,] mat)
        {
            Console.Clear();
            StampaMat($"La matrice è:", mat);
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = IntroduciNumero($"Inserisci un numero nella posizione [{i}, {j}]: ");
                    Console.Clear();
                    StampaMat("La matrice è:", mat);
                }
            }
        }

        private static void StampaMat(string messaggio, int[,] mat)
        {
            Console.WriteLine(messaggio);
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(4) + " ");
                }
                Console.Write("\n");
            }
        }

        private static int IntroduciNumero(string messaggio, int min = int.MinValue)
        {
            int n;
            do
            {
                Console.Write(messaggio);
            }while(!int.TryParse(Console.ReadLine(), out n) || n < min);
            return n;
        }
    }
}
