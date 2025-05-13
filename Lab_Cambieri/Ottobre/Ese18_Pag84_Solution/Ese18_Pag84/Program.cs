using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese18_Pag84
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
            int max = 11;
            a[0] = random.Next(1,max);
            //for(int i = 1; i < n; i++)
            //{
            //    max += 5;
            //    do
            //    {
            //        a[i] = random.Next(1, max);
            //    } while (a[i] < a[i-1]);
            //}
            for (int i = 1; i < n; i++)
            {
                max += 5;
                a[i] = random.Next(a[i - 1] +1, max);
            }
            Console.WriteLine("Vettore A: ");
            for(int i=0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
