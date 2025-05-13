using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ese_64_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S1 = InserisciStringa("Inserisci una stringa: ");
            string S2 = CopiaS1InvertitaInS2(S1);
            Console.WriteLine($"1° stringa: {S1}\n2° stringa: {S2}");
            Console.ReadKey();
        }

        private static string CopiaS1InvertitaInS2(string S1)
        {
            string S2 = "";
            for (int i = S1.Length - 1; i >= 0; i--)
            {
                S2 += S1[i];
            }
            return S2;
        }

        private static string InserisciStringa(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
