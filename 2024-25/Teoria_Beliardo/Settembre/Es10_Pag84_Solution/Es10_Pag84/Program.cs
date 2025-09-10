using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es10_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, i = 0;
            do
            {
                Console.Write("Inserisi il nuemro di elementi dell'array A (>1): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 2);
            int[] A = new int[n];
            for (i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            bool array = true;
            i = 0;
            do
            {
                if (A[i] != A[0])
                    array = false;
                i++;
            } while (array && i < n);
            string message = "";
            if (array)
                message = "Gli elementi dell'array sono tutti uguali";
            else
                message = "Gli elementi dell'array non sono tutti uguali";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
