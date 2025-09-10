using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese03_Pag84
{
    //Invertire gli elementi di un vettore A di lunghezza n su se stesso, senza utilizzare alcun vettore ausiliario
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Inserisci la dimensione dell'array A: ");
                n = Convert.ToInt32(Console.ReadLine());
            }while(n <= 0);
            int[] A = new int[n];
            for(int i = 0; i < n; i++)
            {
                //Console.WriteLine((i + 1) + ": ");
                Console.Write($"{i + 1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n / 2; i++)
            {
                int memoria = A[i];//memorizza l'elemeto di A che andrebbe perso
                A[i] = A[(n-1)-i];
                A[(n-1)-i] = memoria;
            }
            Console.WriteLine("L'array A invertito è:");
            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine((i + 1) + ": " + A[i]);
                Console.WriteLine($"{i + 1}: {A[i]}");
            }
            Console.ReadKey();
        }
    }
}
