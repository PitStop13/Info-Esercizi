using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ese_65_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S1 = InserisciStringa("Inserisci una stringa con valore numerico (x >= 0): ");
            string S2 = S1DuplicaCaratteriInS2(S1);
            Console.WriteLine($"1° stringa: {S1}\n2° stringa: {S2}");
            Console.ReadKey();
        }

        private static string S1DuplicaCaratteriInS2(string S1)
        {
            string S2 = "";
            for (int i = 0; i < S1.Length; i++)
            {
                for (int j = 48; j < S1[i]; j++)//j parte da 48 parchè nelle stringhe 0 = 48
                {
                    S2 += S1[i];
                }
            }
            return S2;
        }

        private static string InserisciStringa(string message)
        {
            bool numeri = true;
            string S = "";
            do
            {
                Console.Write(message);
                S = Console.ReadLine();
                numeri = true;
                int i = 0;
                do
                {
                    if (S[i] < 48 || S[i] > 57) numeri = false;//nelle stringhe 48 = 0 e 57 = 9
                    i++;
                } while (i < S.Length && numeri);
            } while (!numeri);
            return S;
        }
    }
}
