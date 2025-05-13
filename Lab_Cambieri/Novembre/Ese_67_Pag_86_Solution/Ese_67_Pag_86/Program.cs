using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_67_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci la stringa 1: ");
            string s1 = Console.ReadLine();
            Console.Write("Inserisci la sotto stringa 2: ");
            string s2 = Console.ReadLine();
            int contS2InS1 = Ricerca(s1, s2);
            Console.WriteLine($"La stringa * {s2} * compare {contS2InS1} volte nella stringa * {s1} *");
            Console.ReadKey();
        }

        private static int Ricerca(string s1, string s2)
        {
            int i = 0;
            int contS2inS1 = 0;
            while( i < s1.Length)
            {
                int j = 0;
                int caratteri = 0;
                while (j < s2.Length && i < s1.Length)
                {
                    if (s1[i] >= 65 && s1[i] <= 90 || s1[i] >= 97 && s1[i] <= 122)
                    {
                        if (s1[i] == s2[j]) caratteri++;
                        i++;
                        j++;
                    }
  
                }
                if (caratteri == s2.Length) contS2inS1++;
            }
            return contS2inS1;
        }
    }
}
