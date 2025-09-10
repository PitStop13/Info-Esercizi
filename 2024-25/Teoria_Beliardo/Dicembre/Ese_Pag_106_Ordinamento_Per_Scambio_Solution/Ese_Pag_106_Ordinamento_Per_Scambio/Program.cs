using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ese_Pag_106_Ordinamento_Per_Scambio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] v = { "Barbara", "Alberto", "Paola", "Domenico", "Vincezo", "Beatrice" };
            int[] v = new int[10];
            int i = - 1;
            bool scambio;
            Random rnd = new Random();
            for(int k = 0; k < v.Length; k++)
            {
                v[k] = rnd.Next(50);
            }
            do
            {
                i++;
                scambio = false;
                for (int j = (v.Length - 2); j >= i; j--)
                {
                    Console.Clear();
                    Console.WriteLine("Passo " + i + ": \n");
                    StampaVet(v);
                    Thread.Sleep(1500);//fa una pausa
                    if (v[j] > v[j + 1])
                    {
                        int aus = v[j];
                        v[j] = v[j + 1];
                        v[j + 1] = aus;
                        scambio = true;
                    }
                }
            } while (scambio && i < v.Length - 2);
            Console.ReadLine();
        }

        private static void StampaVet(int[] v)
        {
            for(int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i].ToString().PadLeft(3));
            }
        }
    }
}
