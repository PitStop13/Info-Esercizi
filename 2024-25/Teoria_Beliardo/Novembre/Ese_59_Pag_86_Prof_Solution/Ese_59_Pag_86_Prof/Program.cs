using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_59_Pag_86_Prof
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il numero di righe della matrice: ");
            int r = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il numero di colonne della matrice: ");
            int c = int.Parse(Console.ReadLine());
            int[,] mat = new int[r, c];
            inserisciDati(mat);
            ordinaMatrice(mat);
            Console.WriteLine("\n\nLa matrice ordinata è :");
            StampaMat(mat);
            Console.ReadKey();
        }

        private static void ordinaMatrice(int[,] mat)
        {
            int min, posMinI, posMinJ;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    min = trovaMin(mat, i, j, out posMinI, out posMinJ);//con out passo una variabile per riferimento (ref) senza un valore
                    mat[posMinI, posMinJ] = mat[i, j];
                    mat[i, j] = min;
                }
            }
        }

        private static int trovaMin(int[,] mat, int i, int j, out int posMinI, out int posMinj )
        {
            int minVal = mat[i, j];
            posMinI = i;posMinj = j;//devo dare un valore prima di uscire dalla funzione
            for (int i1 = i; i1 < mat.GetLength(0); i1++)
            {
                for (int j1 = j; j1 < mat.GetLength(1); j1++) //for (int j1 = j; j1 < mat.GetLength(1); j1++)
                {
                    if (mat[i1, j1] < minVal)
                    {
                        minVal = mat[i1, j1];
                        posMinI = i1;
                        posMinj = j1;
                    }
                }
                j = 0;
            }
            return minVal;
        }

        private static void inserisciDati(int[,] mat)
        {
            Random rnd = new Random();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = rnd.Next(100);
                }
            }
            Console.Clear();
            StampaMat(mat);
        }

        private static void StampaMat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
