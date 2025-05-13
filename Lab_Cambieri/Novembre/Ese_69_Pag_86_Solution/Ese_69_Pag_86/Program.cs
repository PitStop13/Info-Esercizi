using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_69_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Eserczio 68 pag 86 **");
            string S1 = isChar("\nIntroduci una stringa di caratteri alfabetici: ");
            for (int i = 0; i < S1.Length; i++)
            {
                if (S1[i] == 'a' || S1[i] == 'e' || S1[i] == 'i' || S1[i] == 'o' || S1[i] == 'u' ||
                    S1[i] == 'A' || S1[i] == 'E' || S1[i] == 'I' || S1[i] == 'O' || S1[i] == 'U')
                {
                    char[] a = new char[S1.Length + 1];
                    for (int j = 0; j <= i; j++)
                        a[j] = S1[j];
                    a[i + 1] = S1[i];
                    for (int j = i + 2; j < S1.Length; j++)
                        a[j] = S1[j];
                    S1 = "";
                    for (int j = 0; j < a.Length; j++)
                        S1 += a[j];
                }
            }
            Console.WriteLine($"La stringa finale è {S1}");
            Console.ReadKey();
        }

        private static string isChar(string message)
        {
            string S1;
            bool isChar = true;
            do
            {
                Console.Write(message);
                S1 = Console.ReadLine();
                isChar = true;
                for (int i = 0; i < S1.Length; i++)
                {
                    if (char.IsNumber(S1[i])) isChar = false;
                }
            } while (!isChar);
            return S1;
        }
    }
}
