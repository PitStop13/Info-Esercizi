using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Contare occorrenze x in input
namespace Ese07_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 2, 4, 2, 7, 2, 10, 7, 2, 4 };
            int x;
            do
            {
                Console.Write("Numero da controllare: ");
            } while (!int.TryParse(Console.ReadLine(), out x) || x<=0);
            int conta = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                    conta++;
            }
            string message;
            if(conta == 0)
                message = $"Il numero {x} non è presente";
            else
                message = $"Il numero {x} è presente {conta} volte";
            Console.WriteLine(message);
            //Console.WriteLine($"Il numero {x} è presente {conta} volte");
            Console.ReadKey();
        }
    }
}
