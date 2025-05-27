using System;

namespace Esercizio_3_1_Contatore
{
    class Contatore
    {
        // Membro statico: conta il totale delle istanze create
        public static int TotaleIstanza = 0;

        // Membro di istanza: conta quante volte è stato creato questo oggetto
        public int Conteggio;

        // Costruttore: inizializza Conteggio e incrementa TotaleIstanza statico
        public Contatore()
        {
            Conteggio = 1;        // Ogni nuova istanza inizia con conteggio 1
            TotaleIstanza++;      // Incrementa il conteggio globale delle istanze
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creo 3 istanze di Contatore
            Contatore c1 = new Contatore();
            Contatore c2 = new Contatore();
            Contatore c3 = new Contatore();

            // Stampo i conteggi di ogni istanza
            Console.WriteLine($"Conteggio istanza c1: {c1.Conteggio}");
            Console.WriteLine($"Conteggio istanza c2: {c2.Conteggio}");
            Console.WriteLine($"Conteggio istanza c3: {c3.Conteggio}");

            // Stampo il conteggio totale statico (globale)
            Console.WriteLine($"Totale istanze create: {Contatore.TotaleIstanza}");

            Console.ReadLine(); // Per bloccare la console
        }
    }
}
