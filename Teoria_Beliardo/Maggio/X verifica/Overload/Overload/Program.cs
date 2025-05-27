using System;

namespace Esercizio_2_2_Calcolatore
{
    class Program
    {
        static void Main(string[] args)
        {
            Calcolatore calcola = new Calcolatore();

            // Somma di due interi
            int somma1 = calcola.Somma(5, 3);
            Console.WriteLine($"Somma (int, int): 5 + 3 = {somma1}");

            // Somma di tre numeri interi
            int somma2 = calcola.Somma(2, 4, 6);
            Console.WriteLine($"Somma (int, int, int): 2 + 4 + 6 = {somma2}");

            // Somma di due numeri double
            double somma3 = calcola.Somma(2.5, 3.7);
            Console.WriteLine($"Somma (double, double): 2.5 + 3.7 = {somma3}");

            Console.ReadLine(); // Blocca la console
        }
    }

    class Calcolatore
    {
        // Somma di due interi
        public int Somma(int a, int b)
        {
            return a + b;
        }

        // Somma di tre interi
        public int Somma(int a, int b, int c)
        {
            return a + b + c;
        }

        // Somma di due double
        public double Somma(double a, double b)
        {
            return a + b;
        }
    }
}
