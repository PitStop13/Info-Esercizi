using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Vacanze_4
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

            bool èSimmetrica = VerificaSimmetria(matrice);
            if (èSimmetrica)
                Console.WriteLine("\nLa matrice è simmetrica.");
            else
                Console.WriteLine("\nLa matrice NON è simmetrica.");

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
        
        static bool VerificaSimmetria(int[,] matrice)
        {
            int N = matrice.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j && matrice[i, j] != matrice[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
