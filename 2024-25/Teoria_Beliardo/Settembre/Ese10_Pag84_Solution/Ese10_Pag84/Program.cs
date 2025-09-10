using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese10_Pag84
{
    //Verificare se gli elementi di un vettore A di lunghezza n sono tutti uguali tra loro
    internal class Program
    {
        static void Main(string[] args)
        {
            int n,i;
            do
            {
                Console.Write("Inserisci il numero di elementi dell'array (>=2): ");
            }while(!int.TryParse(Console.ReadLine(), out n) || n<2);
            int[] A = new int[n];
            for(i = 0; i < A.Length; i++)
            {
                Console.Write($"{i+1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            int cont = 0;
            for (i = 0; i < A.Length; i++)
            {
                if(A[i] == A[0])
                    cont++;
            }
            string message = "";
            if (cont == i)
                message = "Tutti gli elementi dell'array sono uguali";
            else
                message = "Non tutti gli elementi dell'array sono uguali";
            Console.WriteLine(message);
            Console.ReadKey();

        }
    }
}
