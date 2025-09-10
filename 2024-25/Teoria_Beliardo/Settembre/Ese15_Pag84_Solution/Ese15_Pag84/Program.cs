using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese15_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10, x = 0, y = n-1;
            int[] A = new int[n], B = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                A[i] = rnd.Next(1, 100);
            }
            for (int i = 0; i < n; i++)
            {
                if(A[i]%2 == 0)
                {
                    B[x++] = A[i];
                }
                else
                {
                    B[y--] = A[i];
                }
            }
            Console.WriteLine("\nElementi di A:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(A[i]+" ");
            }
            Console.WriteLine("\nElementi di B:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(B[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
