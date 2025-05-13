using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese23_CicloWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Random rand = new Random();
            Console.Write("Inserisci il numero di elementi dei vettori A e B (n > 0): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Inserisci il numero di elementi dei vettori A e B (n > 0): ");
            }
            int[] a = new int[n], b = new int[n], c = new int[n+1];
            int i =0;
            Console.WriteLine("\nIl vettore A +");
            Console.WriteLine("Il vettore B =");
            Console.WriteLine("Il vettore C ");
            Console.Write(" \n  ");
            while (i < n)
            {
                a[i] = rand.Next(1, 10);
                Console.Write(a[i] + " ");
                i++;
            }
            Console.WriteLine(" + ");
            i = 0;
            Console.Write("  ");
            while (i < n)
            {
                b[i] = rand.Next(1, 10);
                Console.Write(b[i] + " ");
                i++;
            }
            Console.WriteLine(" =");
            i = n-1;
            int r = 0, s = 0, cont = n;
            while(i >= 0)
            {
                s = a[i] + b[i] + r;
                r = 0;
                if (s > 9)
                {
                    if (i == 0)
                    {
                        c[cont] = s - 10;
                        cont--;
                        c[cont] = r = s / s;
                    }
                    else
                    {
                        c[cont] = s - 10;
                        r = s / s;
                    }
                }
                else
                    c[cont] = s;
                i--;
                cont--;
            }
            i = 0;
            while(i < n*2+4)
            {
                Console.Write("-");
                i++;
            }
            Console.Write("\n");
            if (r == 0)
            {
                i = 1;
                Console.Write("  ");
            }
            else
                i=0;
            while (i < n+1)
            {
                Console.Write(c[i] + " ");
                i++;
            }
            Console.ReadKey();
        }
    }
}
