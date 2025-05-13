using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese12_Pag84
{
    /*Dopo aver caricato due vettori di interi A e B entrambi di lunghezza n,
      verifica se le medie dei loro elementi sono uguali*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int n,i;
            do
            {
                Console.Write("Inserisci il numero di elementi degli array, che sarà uguale per  A e B (n>=2): ");
            }while(!int.TryParse(Console.ReadLine(), out n) || n<2);
            int[] A = new int[n], B = new int[n];
            Console.WriteLine("Vet A:");
            for(i = 0; i < A.Length; i++)
            {
                Console.Write($"{i+1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Vet B:");
            for (i = 0; i < B.Length; i++)
            {
                Console.Write($"{i+1}: ");
                B[i] = Convert.ToInt32(Console.ReadLine());
            }
            double mediaA = 0, mediaB = 0;
            for (i = 0; i < A.Length; i++)
            {
                mediaA += A[i];
                mediaB += B[i];
            }
            mediaA = mediaA / n;
            mediaB = mediaB / n;
            string message = "";
            if (mediaA == mediaB)
                message = $"La media degli elementi dell'array A è ({mediaA}), quella dell'array B è ({mediaB}), quindi sono uguali";
            else
                message = $"La media degli elementi dell'array A è ({mediaA}), quella dell'array B è ({mediaB}), quindi non sono uguali";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
