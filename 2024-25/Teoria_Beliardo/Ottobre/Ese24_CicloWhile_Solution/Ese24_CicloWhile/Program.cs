using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese24_CicloWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            Random random = new Random();
            Console.Write("Inserisci il numero di elementi del vettore A (n > 0): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Inserisci il numero di elementi del vettore A (n > 0): ");
            }
            int[] a = new int[n];
            Console.WriteLine("\nVettore A: ");
            int i = 0;
            while (i < n)
            {
                a[i] = random.Next(1, 21);
                Console.Write(a[i] + " ");
                i++;
            }
            Console.Write("\nInserisci il numero di elementi del vettore B (n > 0): ");
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            {
                Console.Write("Inserisci il numero di elementi del vettore B (n > 0): ");
            }
            int[] b = new int[m];
            Console.WriteLine("\nVettore B: ");
            i = 0;
            while (i < m)
            {
                b[i] = random.Next(1, 21);
                Console.Write(b[i] + " ");
                i++;
            }
            int[] c = new int[n + m];
            int cnt = 0;
            i = 0;
            while (i < n)
            {
                bool cond = true;
                int j = -1;
                while (j < m-1 && cond)
                {
                    j++;
                    if (a[i] == b[j])
                    {
                        cond = false;
                    }
                }
                if (cond == true)
                {
                    c[cnt] = a[i];
                    cnt++;
                }
                i++;
            }
            i = 0;
            while (i < m)
            {
                bool cond = true;
                int j = -1;
                while (j < n-1 && cond)
                {
                    j++;
                    if (b[i] == a[j])
                    {
                        cond = false;
                    }
                }
                if (cond == true)
                {
                    c[cnt] = b[i];
                    cnt++;
                }
                i++;
            }
            Console.WriteLine("\nVettore C: ");
            i = 0;
            while (i < cnt)
            {
                Console.Write(c[i] + " ");
                i++;
            }
            Console.ReadKey();
        }
    }
}
