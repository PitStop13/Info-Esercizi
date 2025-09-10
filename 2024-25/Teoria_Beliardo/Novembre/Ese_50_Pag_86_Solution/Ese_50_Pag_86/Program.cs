using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_50_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] mat;
            int[] colonna;
            int r, c;
            Console.Write("Inserisci dimensione matrice rxc\nr: ");
            r = int.Parse(Console.ReadLine());
            Console.Write("c: ");
            c= int.Parse(Console.ReadLine());
            mat = new int[r, c];
            colonna = new int[r];
            InserisciDati(mat);
            Console.Clear();
            Stampamat(mat);
            Console.WriteLine();
            for (int i = 0; i < r; i++)
            {
                colonna[i] = sommaRiga(mat,i);
            }
            stampaVet(colonna);
            Console.ReadKey();
        }

        private static void stampaVet(int[] colonna)
        {
            Console.WriteLine("Vettore somma delle righe");
            for(int i = 0; i < colonna.Length; i++)
            {
                Console.WriteLine(colonna[i]);
            }
        }

        private static int sommaRiga(int[,] mat, int i)
        {
            int somma = 0;
            for(int j = 0; j < mat.GetLength(1); j++)
            {
                somma += mat[i, j];
            }
            return somma;
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
