using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Vacanze_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Inserisci la dimensione del vettore N: ");
            int N = int.Parse(Console.ReadLine());

           
            int[] vettore = new int[N];

            
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Inserisci l'elemento in posizione {i}: ");
                vettore[i] = int.Parse(Console.ReadLine());
            }

            // Somm prod spec.
            int somma = 0;
            for (int i = 0; i < N / 2; i++)
            {
                somma += vettore[i] * vettore[N - 1 - i];
            }

            //Vett disp -> aggiungo quadrato dell'elemen centr.
            if (N % 2 != 0)
            {
                int centro = vettore[N / 2];
                somma += centro * centro;
            }

           
            Console.WriteLine("\nLa somma dei prodotti speculari è: " + somma);
            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}
