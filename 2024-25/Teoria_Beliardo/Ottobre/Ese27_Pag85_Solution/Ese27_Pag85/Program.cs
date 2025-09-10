using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese27_Pag85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Insersici il numero di elementi della successione di Fibonacci (n > 0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            int[] a = new int[n];
            a[0] = 0;
            if(n > 1) 
            { 
                a[1] = 1; 
                for(int i = 2; i < n; i++) 
                {
                    a[i] = a[i-2] + a[i-1];
                }
            }
            Console.WriteLine("\nSequenza di Fibonacci:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
