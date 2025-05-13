using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inverti_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[10];
            Console.WriteLine("**Inverti il vettore**");
            caricaVet(v);
            stampaVet(v);
            invertiVet(v, 0);
            Console.WriteLine("\n\nL'array invertito è:\n");
            stampaVet(v);
            Console.ReadKey();
        }

        private static void invertiVet(int[] v, int i)
        {
            if(i == (v.Length / 2))//fine della funzione ricorsiva
            {
                return;
            }

            //Inverto
            int aus = v[i];
            v[i] = v[(v.Length - 1) - i];
            v[(v.Length - 1) - i] = aus;

            //Richiamo la funzione
            invertiVet(v, i = i + 1);
        }

        private static void stampaVet(int[] v)
        {
            //Stampo il vettore
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i].ToString().PadLeft(4));
        }

        private static void caricaVet(int[] v)
        {
            Random rnd = new Random();
            //Carico il vettore
            for (int i = 0; i < v.Length; i++)
                v[i] = rnd.Next(1, 100);
        }
    }
}
