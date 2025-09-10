using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_67_Pag_86_Prof
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1, s2;
            Console.Write("inserisci la prima stringa: ");
            s1 = Console.ReadLine();
            Console.Write("inserisci la stringa da ricercare: ");
            s2 = Console.ReadLine();

            Console.WriteLine($"La stringa è stata trovata {Ricerca(s1, s2)} volte");
            Console.ReadKey();
        }

        private static int Ricerca(string s1, string s2)
        {
            int cont = 0, pos = 0;

            do
            {
                pos = s1.IndexOf(s2);//trova la posizione dalla quale inizia s2
                if (pos != -1)
                {
                    cont++;
                    s1 = s1.Substring(pos + s2.Length);//baypassa la stringa s2 precedente dalla stringa s1
                }
            } while (pos != -1);

            return cont;
        }
    }
}
