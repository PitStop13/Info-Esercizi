using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_passaggio_di_valori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //passaggio per valore
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n**Passaggio per valore di un intero**\n");
            Console.ResetColor();
            int val1 = 0;
            Console.WriteLine($"Nel main prima del sottoprogramma(val: {val1})");
            Console.ForegroundColor = ConsoleColor.Blue;
            passaggioPerValore(val1);
            Console.ResetColor();
            Console.WriteLine($"Nel main dopo il sottoprogramma (val: {val1})");

            //passaggio per riferimento
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n**Passaggio per riferimento di un intero**\n");
            Console.ResetColor();
            int val2 = 0;
            Console.WriteLine($"Nel main prima del sottoprogramma(val: {val2})");
            Console.ForegroundColor = ConsoleColor.Blue;
            passaggioPerRiferimento(ref val2);
            Console.ResetColor();
            Console.WriteLine($"Nel main dopo il sottoprogramma (val: {val2})");

            //passaggio per valore di un array
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n**Passaggio per valore di un array**\n");
            Console.ResetColor();
            int[] val = {0, 0, 0, 0, 0};
            Console.Write($"Nel main prima del sottoprogramma (val:");
            for (int i = 0; i < val.Length; i++)
            {
                Console.Write(" " + val[i]);
            }
            Console.Write(")\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            passaggioPerValoreArray(val);
            Console.ResetColor();
            Console.Write($"Nel main dopo il sottoprogramma (val:");
            for (int i = 0; i < val.Length; i++)
            {
                Console.Write(" " + val[i]);
            }
            Console.Write(")");

            Console.ReadKey();
        }

        private static void passaggioPerValoreArray(int[] val)
        {
            Console.Write($"Nel sottoprogramma (val: ");
            for (int i = 0; i < val.Length; i++)
            {
                val[i] = 1;
                Console.Write(" " + val[i]);
            }
            Console.Write(")\n");
        }

        private static void passaggioPerRiferimento(ref int val2)
        {
            val2++;
            Console.WriteLine($"Nel sottoprogramma (val: {val2})");
        }

        private static void passaggioPerValore(int val1)
        {
            val1++;
            Console.WriteLine($"Nel sottoprogramma (val: {val1})");
        }
    }
}
