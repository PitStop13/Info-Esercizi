using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valore_Max_Ricorsione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[10];
            Console.WriteLine("**Trova l'indice del numero più grande dell'array**");
            caricaVet(v);
            stampaVet(v);
            int maxIndex = 0;
            trovaMax(v, 0, int.MinValue, ref maxIndex);
            Console.WriteLine($"\n\nL'indice del valore più grande è: {maxIndex}");
            Console.ReadKey();
        }

        private static void trovaMax(int[] v, int i, int max, ref int maxIndex)
        {
            if (i == v.Length - 1)
            {
                return;
            }

            if (v[i] > max)
            {
                max = v[i];
                maxIndex = i;

            }

            trovaMax(v, i  = i+1, max, ref maxIndex);
        }

        private static void stampaVet(int[] v)
        {
            for(int i = 0; i < v.Length; i++)
                Console.Write(v[i].ToString().PadLeft(4));
        }

        private static void caricaVet(int[] v)
        {
            Random rand = new Random();
            for (int i = 0; i < v.Length; i++)
                v[i] = rand.Next(1, 100);
        }
    }
}
