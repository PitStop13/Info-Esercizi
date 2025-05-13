using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char scelta = ' ';
            do
            {
                ScriviMenu();
                scelta = Console.ReadKey().KeyChar;//scelta diventa il carattere che ho premuto
                switch (scelta)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Fibonacci eseguito");
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Fattoriale eseguito");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Unione di insiemi eseguito");
                        Console.ReadKey();
                        break;
                }
                //while (scelta != 'q' && scelta != 'Q')
            } while (scelta.ToString().ToLower() != "q");//trasforma la scelta in un carattere minuscolo(Lower = minuscolo, Upper = maiuscolo).
        }

        private static void ScriviMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Fibonacci");
            Console.WriteLine("2 - Fattoriale");
            Console.WriteLine("3 - Unione di insiemi");
            Console.WriteLine("------------------");
            Console.WriteLine("Q - ESCI");
        }
    }
}
