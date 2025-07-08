using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Vacanze_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci la dimensione N della matrice quadrata NxN: ");
            int N = int.Parse(Console.ReadLine());
            int[,] matrice = new int[N, N];

            Console.WriteLine("\nInserisci gli elementi della matrice:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"Elemento [{i},{j}]: ");
                    matrice[i, j] = int.Parse(Console.ReadLine());
                }
            }

            bool èUnitaria = VerificaUnitaria(matrice);
            if (èUnitaria)
                Console.WriteLine("\nLa matrice è unitaria.");
            else
                Console.WriteLine("\nLa matrice NON è unitaria.");

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }

        static bool VerificaUnitaria(int[,] matrice)
        {
            int N = matrice.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                       if (matrice[i, j] != 1)
                            return false;
                    }
                    else
                    {
                        if (matrice[i, j] != 0)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
