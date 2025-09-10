using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_66_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Eserczio 66 pag 86 **");
            string S1 = "";
            do
            {
                Console.Write("Introduci la stringa da invertire su se stessa: ");
                S1 = Console.ReadLine();
                //copio la stringa in un array char
                char[] S1Array = new char[S1.Length];

                for(int i = 0; i < S1.Length; i++)
                    S1Array[i] = S1[i];

                int min = 0; int max = S1.Length - 1;

                while(min < max)
                {
                    char c = S1Array[min];
                    S1Array[min] = S1[max];
                    S1Array[max] = c;
                    min++; max--;
                }

                //copio l'array nella stringa
                S1 = "";

                for (int i = 0; i < S1Array.Length; i++)
                    S1 += S1Array[i];

                Console.WriteLine($"La stringa finale è {S1}\n\n");
            } while (S1 != "");
        }
    }
}
