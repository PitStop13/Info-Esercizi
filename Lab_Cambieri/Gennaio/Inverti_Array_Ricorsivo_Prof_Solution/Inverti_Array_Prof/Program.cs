using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inverti_Array_Prof
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("**INVERTI VETTORE IN MODO RICORSIVO **");
            StampaVet(a, "\nVettore originale: ");
            Console.WriteLine("\n\nPremi un tasto per continuare...");
            Console.ReadKey();
            InvertiRicorsivo(a, 0);
            StampaVet(a, "\n\nVettore invertito: ");
            InvertiRicorsivoBis(a, 0, a.Length - 1);
            StampaVet(a, "\n\nVettore invertito bis: ");
            Console.WriteLine("\n\nPremi un tasto per terminare...");
            Console.ReadKey();
        }

        private static void InvertiRicorsivoBis(int[] vet, int first, int last)
        {
            if (first < last)
            {
                int aus = vet[last];
                vet[last] = vet[first];
                vet[first] = aus;
                InvertiRicorsivoBis(vet, first + 1, last - 1);
            }
        }

        private static void InvertiRicorsivo(int[] vet, int i)
        {
            if(i == vet.Length/2)
                return;
            int aus = vet[vet.Length - i - 1];
            vet[vet.Length - i - 1] = vet[i];
            vet[i] = aus;
            i++;
            InvertiRicorsivo(vet, i);
        }

        private static void StampaVet(int[] vet, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < vet.Length; i++)
            {
                Console.Write(vet[i] + "  ");
            }
        }
    }
}
