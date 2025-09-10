using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ese24_Pag85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            do
            {
                Console.Write("Insersici il numero di elementi del vettore A (>0): ");
            }while(!int.TryParse(Console.ReadLine(), out n) || n<=0);
            do
            {
                Console.Write("\nInsersici il numero di elementi del vettore B (>0): ");
            } while (!int.TryParse(Console.ReadLine(), out m) || n <= 0);
            int[] A = new int[n], B = new int[m], C = new int [n + m];
            Console.WriteLine("\nInserisci gli elementi del vettore A:");
            for(int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ": " );
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("\nInserisci gli elementi del vettore B:");
            for (int i = 0; i < m; i++)
            {
                Console.Write((i + 1) + ": ");
                B[i] = Convert.ToInt32(Console.ReadLine());
            }
            //int cont = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        int conting = cont;
            //        while (cont < n+m && conting == cont)
            //        {
            //            if (A[i] != B[j])
            //            {
            //                C[cont] = A[i];
            //                C[cont] = B[i + j];
            //                cont++;
            //            }
            //            else
            //            {
            //                if (cont < n)
            //                    C[cont] = A[i];
            //                else
            //                    C[cont] = B[i + j];
            //                cont++;
            //            }
            //        }
            //    }
            //}
            //for(int i = 0; i < n + m; i++)
            //{
            //    if (i < n)
            //        C[i] = A[i];
            //    else
            //        C[i] = B[i - n];
            //}
            //int cont = n + m;
            //for(int i = 0; i < cont; i++)
            //{
            //    for(int j = i+1; j < cont; j++)
            //    {
            //        if (C[i] == C[j])
            //        {
            //            cont--;
            //            int z = i + 1;
            //            for (int k = i; k < cont; k++)
            //            {
            //                int[] C = new int[cont];
            //                C[j] = C[k];
            //                z++;
            //            }
            //        }
            //    }
            //}
            for (int i = 0; i < n + m; i++)
            {
                if (i < n)
                    C[i] = A[i];
                else
                    C[i] = B[i - n];
            }
            int cont = n + m;
            for (int i = 0; i < cont; i++)
            {
                for (int j = i + 1; j < cont; j++)
                {
                    if (C[j] == C[i])
                    {
                        cont--;
                        int z = i;
                        for (int k = j; k < cont; k++)
                        {
                            C[z] = C[k];
                            z++;
                        }
                    }
                }
            }
            Console.WriteLine("\nIl vettore C, dato dall'unione di A e B, è:");
            for (int i = 0; i < n+m; i++)
            {
                Console.WriteLine((i + 1) + ": " + C[i]);
            }
            Console.ReadKey();
        }
    }
}
