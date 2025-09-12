using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Es_Modulo_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("*                                       *");
            Console.WriteLine("*    Test della classe NumeriUtility    *");
            Console.WriteLine("*                                       *");
            Console.WriteLine("*****************************************\n");

            // Test 1: Calcolo del quadrato
            int numero = 7;
            Console.WriteLine($"Il quadrato di {numero} è: {ClsNumeriUtility.CalcolaQuadrato(numero)}");

            // Test 2: Verifica pari/dispari
            int n = 10;
            Console.WriteLine($"{n} è pari? {ClsNumeriUtility.ÈPari(n)}");
            Console.WriteLine($"{n} è dispari? {ClsNumeriUtility.ÈDispari(n)}");

            // Test 3: Trova il massimo tra due numeri
            int a = 12, b = 20;
            Console.WriteLine($"Il massimo tra {a} e {b} è: {ClsNumeriUtility.TrovaMassimo(a, b)}");

            Console.WriteLine("\n*****************************************");
            Console.WriteLine("*                                       *");
            Console.WriteLine("*               Fine test               *");
            Console.WriteLine("*                                       *");
            Console.WriteLine("*****************************************");
            Console.ReadLine();
        }
    }
}

