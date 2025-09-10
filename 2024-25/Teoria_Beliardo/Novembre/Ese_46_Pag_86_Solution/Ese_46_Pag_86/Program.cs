using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_46_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserici il numero di righe della matrice: ", 2);
            int c = IntroduciNumero("Inserici il numero di colonne della matrice: ", 2);
            int[,] mat = new int[r, c];
            int precedente = int.MinValue;
            Console.Clear();
            Stampamat(mat);
            for(int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    do
                    {
                        mat[i,j] = IntroduciNumero($"Inserisci un numero nella posizione [{i}, {j}]: ");
                    } while (mat[i, j] < precedente);
                    Console.Clear();
                    Stampamat(mat);
                    precedente = mat[i, j];
                }
            }
            Console.ReadKey();
        }

        private static void Stampamat(int[,] mat)
        {
            Console.WriteLine("La matrice è:");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i,j].ToString().PadLeft(4) + " ");
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
            } while(!int.TryParse(Console.ReadLine(), out n) || n < min);
            return n;
        }
    }
}
