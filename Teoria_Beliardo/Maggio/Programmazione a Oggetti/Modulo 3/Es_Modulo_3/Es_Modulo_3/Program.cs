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
            Console.WriteLine($"Il quadrato di {numero} è: {NumeriUtility.CalcolaQuadrato(numero)}");

            // Test 2: Verifica pari/dispari
            int n = 10;
            Console.WriteLine($"{n} è pari? {NumeriUtility.ÈPari(n)}");
            Console.WriteLine($"{n} è dispari? {NumeriUtility.ÈDispari(n)}");

            // Test 3: Trova il massimo tra due numeri
            int a = 12, b = 20;
            Console.WriteLine($"Il massimo tra {a} e {b} è: {NumeriUtility.TrovaMassimo(a, b)}");

            Console.WriteLine("\n*****************************************");
            Console.WriteLine("*                                       *");
            Console.WriteLine("*               Fine test               *");
            Console.WriteLine("*                                       *");
            Console.WriteLine("*****************************************");
            Console.ReadLine();
        }
    }

    public static class NumeriUtility
    {
        // Metodo per calcolare il quadrato di un numero
        public static int CalcolaQuadrato(int numero)
        {
            return numero * numero;
        }

        // Metodo per verificare se un numero è pari
        public static bool ÈPari(int numero)
        {
            return numero % 2 == 0;
        }

        // Metodo per verificare se un numero è dispari
        public static bool ÈDispari(int numero)
        {
            return numero % 2 != 0;
        }

        // Metodo per trovare il massimo tra due numeri
        public static int TrovaMassimo(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}

