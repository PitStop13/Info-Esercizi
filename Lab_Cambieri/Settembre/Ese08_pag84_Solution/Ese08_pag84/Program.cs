using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese08_pag84
{
    //Somma pari e somma dispari
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=0;
            Random rand=new Random();
            do
            {
                Console.Write("Inserisci la grandezza del vettore (>2): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n<2);//!=NOT
            int[] a = new int[n];
            Console.WriteLine("\nVet a:");
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(1,101);
                Console.WriteLine($"{i + 1}: {a[i]}");
            }
            int spari = 0, sdispari = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] % 2 == 0)
                    spari+= a[i];
                else
                    sdispari+= a[i];
            }
            Console.WriteLine($"\n\nLa somma dei numeri pari è: {spari}");
            Console.WriteLine($"La somma dei numeri dispari è: {sdispari}");
            Console.ReadKey();
        }
    }
}
