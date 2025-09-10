using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese011_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Random random = new Random();
            do
            {
                Console.Write("Introduci il num di elementi (n > 0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            int[] a = new int[n];
            Console.WriteLine("\nVet A: ");
            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(1, 5);
                Console.Write(a[i] + "  ");
            }
            int[] b = new int[n];
            Console.WriteLine("\nVet B: ");
            for (int i = 0; i < n; i++)
            {
                b[i] = random.Next(1, 5);
                Console.Write(b[i] + "  ");
            }
            int[] c= new int[n];
            int j = 0;
            int cont = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] == b[i])
                {
                    for(cont = 0; cont < j; cont++)
                        if (a[i] != c[j])
                        {
                            c[j] = a[i];
                            j++;
                        }
                }
            }
            Console.WriteLine("\nVet C:");
            for (int i = 0; i < j; i++)
            {
                Console.Write(c[i] + "  ");
            }
            Console.ReadKey();
        }
    }
}
