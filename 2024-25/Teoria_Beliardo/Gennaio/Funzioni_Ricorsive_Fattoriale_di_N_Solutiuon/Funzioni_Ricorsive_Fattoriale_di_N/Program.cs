using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funzioni_Ricorsive_Fattoriale_di_N
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, ris;
            Console.WriteLine("Calcolo del fattoriale");
            Console.Write("\n\nInserisci il numero: ");
            n = Convert.ToInt32(Console.ReadLine());

            ris = Fattoriale(n);
            Console.WriteLine("\n\nRisultato: " + ris);

            Console.ReadKey();
        }

        private static int Fattoriale(int n)
        {
            if (n == 0)
            {
                return 1;//n arriva a 0
            }
            else
            {
                return n * Fattoriale(n-1);//una volta che n è arrivata a 0, ritorna indetro fino al valore precedente di n
            }
        }
    }
}
