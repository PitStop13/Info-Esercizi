using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_61_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S;
            Console.Write("Inserisci una stringa: ");
            S = Console.ReadLine().ToLower();
            int sommaVocali = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'a' || S[i] == 'e' || S[i] == 'i' || S[i] == 'o' || S[i] == 'u')
                    sommaVocali++;
            }
            Console.Write($"la somma delle vocali della stringa {S} è {sommaVocali}");
            Console.ReadKey();
        }
    }
}
