using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_41_Pag_85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserisci la dimensione della matrice quadrata: ", 2);
            int[,] mat = new int[r, r];
            int i = 0, j = 0, nSequenze = 1;
            bool sequenza = true;
            for (int conta = 0; conta < (r * r); conta++)
            {
                Console.WriteLine("La matrice è:");
                Console.Clear();
                StampaMat(mat);
                mat[i, j] = IntroduciNumero($"\n\nInserisci un numero nella posizione [{i}, {j}]: ");
                if (j < r - nSequenze && sequenza) j++;
                else
                {
                    if (i < r - nSequenze && sequenza) i++;
                    else
                    {
                        sequenza = false;
                        if (!sequenza && j > nSequenze - 1) j--;
                        else
                        {
                            if (!sequenza && i > nSequenze) i--;
                            else
                            {
                                j = i;
                                sequenza = true;
                                nSequenze++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("La matrice è:");
            Console.Clear();
            StampaMat(mat);
            Console.ReadKey();
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
