using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_40_Pag85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserisci la grandezza della matrice quadrata: ", 2);
            int[,] mat = new int[r, r];
            CaricaMat(mat);
            bool uguali = true;
            int i = 0;
            do
            {
                int j = 0;
                do
                {
                    if (mat[i, j] != mat[j, i]) uguali = false;
                    j++;
                }while(uguali  && j < r);
                i++;
            } while (uguali && i < r);
            if (uguali)
                Console.WriteLine($"La matrice ({r}x{r}) è speculare!");
            else
                Console.WriteLine($"La matrice ({r}x{r}) NON è speculare!");
            Console.ReadKey();
        }

        private static void CaricaMat(int[,] mat)
        {
            Console.Clear();
            StampaMat(mat);
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = IntroduciNumero($"\n\nInserisci un numero nella posizione [{i}, {j}]: ");
                    Console.Clear();
                    StampaMat(mat);
                }
            }
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
