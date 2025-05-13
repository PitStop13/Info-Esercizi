using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese9_Pag84
{
    //Contare il numero di elementi positivi e negativi presenti in un vettore A di lunghezza n.
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("Inserisci il numero di elementi dell'array (>=2):");
            }while(!int.TryParse(Console.ReadLine(), out n) || n<=2);
            int[] A = new int[n];
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"{i+1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            int cpositivi = 0, cnegativi = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                    cpositivi++;
                else if (A[i] < 0)
                    cnegativi++;

            }
            Console.WriteLine($"I numeri positivi sono: {cpositivi}");
            Console.WriteLine($"I numeri negativi sono: {cnegativi}");
            Console.ReadKey();
        }
    }
}
