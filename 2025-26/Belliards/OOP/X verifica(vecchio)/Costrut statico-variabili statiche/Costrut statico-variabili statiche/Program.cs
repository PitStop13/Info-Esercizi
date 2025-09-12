using System;

namespace Esercizio_3_2_Statico
{
    // Classe con costruttore statico
    class Configurazione
    {
        // Proprietà statica
        public static string Impostazioni { get; private set; }

        // Costruttore statico: viene eseguito una sola volta prima del primo accesso alla classe
        static Configurazione()
        {
            Impostazioni = "Configurazione iniziale impostata";
            Console.WriteLine("Costruttore statico Configurazione eseguito.");
        }
    }

    // Classe statica per metodi di utilità matematici
    static class MathUtility
    {
        public static int Somma(int a, int b)
        {
            return a + b;
        }

        public static double Media(int a, int b)
        {
            return (a + b) / 2.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Accesso alla proprietà statica senza creare istanza
            Console.WriteLine(Configurazione.Impostazioni);

            // Uso dei metodi della classe statica MathUtility
            int somma = MathUtility.Somma(10, 20);
            double media = MathUtility.Media(10, 20);

            Console.WriteLine($"Somma di 10 e 20: {somma}");
            Console.WriteLine($"Media di 10 e 20: {media}");

            Console.ReadLine(); // Blocca la console
        }
    }
}
