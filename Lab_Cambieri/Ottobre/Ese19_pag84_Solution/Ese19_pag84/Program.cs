using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ese19_pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            const int MAX_ELEM = 20;
            Random random = new Random();
            do
            {
                Console.Write($"Introduci il num di elementi (n > 0 e <={MAX_ELEM}): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > MAX_ELEM);
            int[] a = new int[n];
            int cont = 0;
            while(cont < n)
            {
                int num = random.Next(1, MAX_ELEM+1);
                bool isPresent = false;
                for (int i=0; i < cont; i++)
                {
                    if (a[i] == num)
                    {
                        isPresent = true;
                        break;
                    }
                }
                if(!isPresent)
                {
                    a[cont] = num;
                    cont++;
                }
            }
            /*for (int i = 0; i < n; i++)
            {
                bool cond;
                do
                {
                    cond = true;
                    a[i] = random.Next(1, MAX_ELEM + 1);
                    for (int j = 0; j < i; j++)
                    {
                        if (a[i] == a[j])
                        {
                            cond = false;
                            break;
                        }
                    }
                } while (cond == false);
            }*/
            Console.WriteLine("Vettore A: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
