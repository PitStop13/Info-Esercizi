using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_65_Pag_86_Prof
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Eserczio 65 pag 86 **");
            ulong n = 0;//ulong non prende i negativi
            do 
            {
                string S1 = "", S2 = "";
                do
                {
                    Console.Write("\nIntroduci una stringa di caratteri numerici (0 per uscire): ");
                    S1 = Console.ReadLine();
                } while (!ulong.TryParse(S1, out n));
                for (int i = 0; i < S1.Length; i++)
                {
                    //int n = int.Parse(S1[i].ToString());
                    int num = S1[i] - 48; //48 è il codice ASCI dello 0
                    for (int j = 0; j < num; j++)
                    {
                        S2 += S1[i];
                    }
                }
                Console.WriteLine($"La stringa finale è {S2}\n\n");
            } while(n > 0 );
        }
    }
}
