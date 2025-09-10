using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese02_Pag84
{
    /*Copiare gli elementi di un vettore A di lunghezza n invertendoli in un vettore B dello stesso tipo,
     * anch'esso di lughezza n*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("inserisci La dimensione dell'array A: ");
                n = Convert.ToInt32(Console.ReadLine());
            }while (n <= 0);
            int[] A = new int[n], B = new int[n];
            Console.WriteLine("Inserisci gli elementi dell'array A:");
            for(int i = 0; i < n; i++)
            {
                //Console.WriteLine((i + 1) + ": ");
                Console.Write($"{i+1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = n-1; i >= 0; i--)
            {
                B[(n-1)-i] = A[i];
            }
            Console.WriteLine("L'array B, che è la copia invertita dell'array A, è:");
            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine((i + 1) + ": " + B[i]);
                Console.WriteLine($"{i + 1}: {B[i]}");
            }
            Console.ReadKey();
        }
    }
}
