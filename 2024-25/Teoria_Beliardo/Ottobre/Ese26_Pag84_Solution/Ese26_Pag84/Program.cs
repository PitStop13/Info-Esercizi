using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ese26_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            {
                Console.Write("Insersici il numero di elementi del vettore A (>0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0) ;
            do
            {
                Console.Write("\nInsersici il numero di elementi del vettore B (>0): ");
            } while (!int.TryParse(Console.ReadLine(), out m) || n <= 0);
            int[] A = new int[n], B = new int[m], C = new int[n + m];
            Console.WriteLine("\nInserisci gli elementi del vettore A:");
            for (int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ": ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("\nInserisci gli elementi del vettore B:");
            for (int i = 0; i < m; i++)
            {
                Console.Write((i + 1) + ": ");
                B[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n+m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for(int k = 0; k < m; k++)
                    {
                        if (A[j] != B[k])
                        {
                            if (i < n)
                                C[i] = A[j];
                            else
                                C[i] = B[k];
                        }
                    }
                }
            }
            Console.WriteLine("\nIl vettore C, dato dall'unione di A e B, è:");
            for (int i = 0; i < n+m; i++)
            {
                Console.WriteLine((i + 1) + ": " + C[i]);
            }
            Console.ReadKey();
        }
    }
}
