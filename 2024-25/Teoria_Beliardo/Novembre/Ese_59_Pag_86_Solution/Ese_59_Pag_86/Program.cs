using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_59_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserisci la grandezza della matrice quadrata (rxr): ", 2);
            int[,] mat = new int[r,r];
            Caricamat(mat);
            int val = int.MinValue;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i,j] >= val)
                    {
                        val = mat[i,j];
                    }
                    else
                    {
                        int contRow1 = i, contCol1 = j, contRow2 = i, contCol2 = j - 1;
                        do
                        {
                            while (contCol2 >= 0 && mat[contRow2, contCol2] >= mat[contRow1, contCol1])
                            {
                                int aus = mat[contRow2, contCol2];
                                mat[contRow2,contCol2] = mat[contRow1, contCol1];
                                mat[contRow1, contCol1] = aus;
                                contRow1 = contRow2;
                                contCol1 = contCol2;
                                contCol2--;
                            }
                            contRow2--;
                            contCol2 = r - 1;
                        } while (contRow1 > 0 && mat[contRow2, contCol2] >= mat[contRow1, contCol1]);
                    }
                }
            }
            StampaMat("\n\nLa matrice in ordine crescente è:", mat);
            Console.ReadKey();
        }

        private static void Caricamat(int[,] mat)
        {
            Console.Clear();
            StampaMat("La matrice è:", mat);
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = IntroduciNumero($"\ninserisci un numero nella posizione [{i}, {j}]: ");
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
                Console.WriteLine();
            }
        }

        private static int IntroduciNumero(string messaggio, int min = int.MinValue)
        {
            int n;
            do
            {
                Console.Write(messaggio);
            }while (!int.TryParse(Console.ReadLine(), out n) || n < min);
            return n;
        }
    }
}
