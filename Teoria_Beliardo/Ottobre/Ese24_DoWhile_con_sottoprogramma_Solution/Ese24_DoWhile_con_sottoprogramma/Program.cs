using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese24_DoWhile_con_sottoprogramma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            Random rand = new Random();
            Console.Write("Inserisci il numero di elementi del vettore A (n > 0): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Inserisci il numero di elementi del vettore A (n > 0): ");
            }
            int[] a = new int[n];
            Console.WriteLine("\nVettore A: ");
            a[0] = rand.Next(1, 21);
            Console.Write(a[0] + " ");
            int i = 1;
            while (i < n)
            {
                do
                {
                    a[i] = rand.Next(1, 21);
                    Console.Write(a[i] + " ");
                } while (a[i] == a[i - 1]);
                i++;
            }
            Console.Write("\nInserisci il numero di elementi del vettore B (n > 0): ");
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            {
                Console.Write("Inserisci il numero di elementi del vettore B (n > 0): ");
            }
            int[] b = new int[m];
            b[0] = rand.Next(1, 21);
            Console.Write(b[0] + " ");
            i = 1;
            while (i < m)
            {
                do
                {
                    b[i] = rand.Next(1, 21);
                    Console.Write(b[i] + " ");
                } while (b[i] == b[i - 1]);
                i++;
            }
            int[] c = new int[n + m];
            i = 0;
            while (i < n)
            {
                c[i] = a[i];
                i++;
            }
            int j = 0;
            while(j < m)
            {
                bool presente = Presente(i, j, b, c);
                if (!presente)
                {
                    c[i] = b[j];
                    i++;
                }
                j++;
            }
            Console.Write("\nIl vettore C, dato dall'unione di A e B, è: \n");
            j = 0;
            while (j < i)
            {
                Console.Write(c[j] + " ");
                j++;
            }
            Console.ReadKey();
        }
        private static bool Presente(int i, int j, int[] b, int[] c)
        {
            int k = 0;
            bool trovato = false;
            while(k < i)
            {
                if (b[j] == c[k])
                {
                    trovato = true;
                }
                k++;
            }
            return trovato;
        }
    }
}
