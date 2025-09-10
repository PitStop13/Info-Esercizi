using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese16_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Random rnd = new Random();
            int[] A = new int[n], max = { int.MinValue, int.MinValue, int.MinValue };
            for (int i = 0; i < n; i++)
            {
                A[i] = rnd.Next(1, 31);
            }
            Console.WriteLine("Il vettore A è: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}: {A[i]}");
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[j] >= max[i] && A[j] != max[0] && A[j] != max[1])
                    {
                        max[i] = A[j];
                    }
                }
            }
            Console.WriteLine("\nI tre numeri più grandi dell'array sono:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1}: {max[i]}");
            }
            Console.ReadKey();
        }
    }
}
