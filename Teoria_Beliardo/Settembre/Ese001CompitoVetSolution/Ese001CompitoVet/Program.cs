using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese001CompitoVet
{
    //Dati due Vettori A e B ottenere un vettore C dato  dall’Unione dei due precedenti.
    internal class Program
    {
        static void Main(string[] args)
        {
            int nA, nB, i = 0;
            do
            {
                Console.Write("Inserisci la gradezza dell'array A: ");
                nA = Convert.ToInt32(Console.ReadLine());
            }while(nA <= 0);
            do
            {
                Console.Write("Inserisci la gradezza dell'array B: ");
                nB = Convert.ToInt32(Console.ReadLine());
            } while (nB <= 0);
            int[] A = new int[nA], B = new int[nB], C = new int[nA + nB];
            for(i=0; i<nA; i++)
            {
                Console.WriteLine("Inserisci un elemento dell'array A: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < nB; i++)
            {
                Console.WriteLine("Inserisci un elemento dell'array B: ");
                B[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < (nA + nB); i++)
            {
                if(i<nA)
                {
                    C[i] = A[i];
                }
                else
                {
                    C[i] = B[i-nA];
                }
            }
            Console.Write("L'array C, dato dall'unione di A e B, è: ");
            for (i = 0; i < (nA + nB); i++)
            {
                Console.Write(C[i]+" ");
            }
            Console.ReadKey();
        }
    }
}
