using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese17_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Inserisci il numero di elementi del vettore A ( >3): ");
            }while(!int.TryParse(Console.ReadLine(), out n) || n <= 3);
            int[] A = new int[n], max = {int.MinValue, int.MinValue, int.MinValue};
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i+1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            int pos1 = -1; int pos2 = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[j] >= max[i] && pos1 != j && pos2 != j)
                    {
                        max[i] = A[j];
                        if (i == 0)
                            pos1 = j;
                        else
                        {
                            if (i == 1)
                                pos2 = j;
                        }
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
