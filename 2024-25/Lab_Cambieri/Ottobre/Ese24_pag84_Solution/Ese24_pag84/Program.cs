using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese24_pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n,m;
            Random random = new Random();
            do
            {
                Console.Write("\nIntroduci il num di elementi del vettore A (n > 0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(1,21);
            }
            Console.WriteLine("\nVettore A: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            do
            {
                Console.Write("\nIntroduci il num di elementi del vettore B (n > 0): ");
            } while (!int.TryParse(Console.ReadLine(), out m) || m <= 0);
            int[] b = new int[m];
            for (int i = 0; i < m; i++)
            {
                b[i] = random.Next(1, 21);
            }
            Console.WriteLine("\nVettore B: ");
            for (int i = 0; i < m; i++)
            {
                Console.Write(b[i] + " ");
            }
            int[] c = new int[n+m];
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                bool cond = true;
                for(int j = 0; j <m; j++)
                {
                    if (a[i] == b[j])
                    {
                        cond = false;
                        break;
                    }
                }
                if (cond == true)
                {
                    if (i < n)
                    {
                        c[cnt] = a[i];
                        cnt++;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                bool cond = true;
                for (int j = 0; j < n; j++)
                {
                    if (b[i] == a[j])
                    {
                        cond = false;
                        break;
                    }
                }
                if (cond == true)
                {
                    if (i < n)
                    {
                        c[cnt] = b[i];
                        cnt++;
                    }
                }
            }
            Console.WriteLine("\nVettore C: ");
            for (int i = 0; i < cnt; i++)
            {
                Console.Write(c[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
