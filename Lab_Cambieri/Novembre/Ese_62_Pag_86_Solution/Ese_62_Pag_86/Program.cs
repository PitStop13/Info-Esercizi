using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_62_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S1 = InserisciStringa("Inserisci la 1° stringa: ");
            string S2 = InserisciStringa("Inserisci la 2° stringa: ");
            int sommaVocaliS1 = 0;
            for (int i = 0; i < S1.Length; i++)
            {
                if (S1[i] == 'a' || S1[i] == 'e' || S1[i] == 'i' || S1[i] == 'o' || S1[i] == 'u')
                    sommaVocaliS1++;
            }
            int sommaVocaliS2 = 0, j = 0;
            do
            {
                if (S2[j] == 'a' || S2[j] == 'e' || S2[j] == 'i' || S2[j] == 'o' || S2[j] == 'u')
                    sommaVocaliS2++;
                j++;
            } while (j < S2.Length && sommaVocaliS2 <= sommaVocaliS1);
            string message = sommaVocaliS1 > sommaVocaliS2 ? 
                "La 1° stringa contiene più vocali della 2° stringa" : 
                sommaVocaliS1 == sommaVocaliS2 ? 
                "La 1° stringa e la 2° stringa hanno lo stesso numero di vocali" : 
                "La 2° stringa contiene più vocali della 1° stringa";
            Console.WriteLine(message);
            Console.ReadKey(); 
        }

        private static string InserisciStringa(string message)
        {
            Console.Write(message);
            return Console.ReadLine().ToLower();
        }
    }
}
