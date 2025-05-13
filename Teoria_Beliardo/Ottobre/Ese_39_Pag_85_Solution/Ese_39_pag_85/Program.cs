using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_39_pag_85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Introduci il numero di righe e colonne della matrice quadarta: ", 2);
            int[,] mat = new int[r,r];
            CaicaMat(mat);
            bool cond = true;
            int i = 0;
            do
            {
                int somma = 0;
                for(int j = 0; j < mat.GetLength(0); j++)
                {
                    if (i != j)
                        somma += Math.Abs(mat[i, j]);
                }
                if (somma >= Math.Abs(mat[i, i]))
                    cond = false;
                i++;
            } while(cond && i < mat.GetLength(0));
            if (cond)
                Console.WriteLine($"\n\nLa matrice ({r}x{r}) è diagonalmente dominante!");
            else
                Console.WriteLine($"\n\nLa matrice ({r}x{r}) NON è diagonalmente dominante!");
            Console.ReadKey();
        }

        private static void CaicaMat(int[,] mat)
        {
            Console.Clear();
            Console.WriteLine("La matrice è:");
            StampaMat(mat);
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = IntroduciNumero($"\n\ninserisci un numero nella posizione [{i}, {j}]: ");
                    Console.Clear();
                    Console.WriteLine("La matrice è:");
                    StampaMat(mat);
                }
            }
        }

        private static void StampaMat(int[,] mat)
        {
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
