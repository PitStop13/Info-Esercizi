using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_Pag_103_Ordinamento_Per_Selezione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Ordinamento per selezione di un array **");
            string[] v = { "Barbara", "Alberto", "Domenico", "Beatrice", "Paola", "Vincenzo" };
            StampaVet(v, "\nL'array è: \n");

            for(int i = 0; i < v.Length - 2; i++)
            {
                int Posmin = i;
                for (int j = i + 1; j < v.Length - 1; j++)
                {
                    if (v[Posmin].CompareTo(v[j])  > 0) Posmin++;
                }

                if(Posmin != i)
                {
                    string aus = v[i];
                    v[i] = v[Posmin];
                    v[Posmin] = aus;
                }
            }

            StampaVet(v, "\n\nL'array ordinato è: \n");

            Console.ReadKey();
        }

        private static void StampaVet(string[] v, string mess)
        { 
            Console.WriteLine(mess);
            for(int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + "  ");
            }
        }
    }
}
