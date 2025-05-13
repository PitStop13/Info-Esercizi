using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RandomVet
{
    /*Caricare ogni volta un vettore di elementi random (di dimensione n) fino a quando,
     *la somma degli elementi in posizione pari è maggiore o uguale a quella degli elementi
     *in posizione dispari.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v;//vettore vuoto
            int i = 0, j = 0, n,sp=0, sd=0;
            Random rnd=new Random();
            Console.WriteLine("Inserisci la dimensione dell'Array: ");
            n=Convert.ToInt32(Console.ReadLine());
            v=new int[n];
            do
            {
                v[i] = rnd.Next(100);
                if ((i+1) % 2 == 0)
                {
                    sp = sp + v[i];
                }
                else sd = sd + v[i];
                i++;
            } while (sp < sd && i < n);
            if(sp>=sd)
            {
                Console.WriteLine("La somma degli elementi pari è maggiore di quella degli elementi dispari");
            }
            else
                Console.WriteLine("Vettore pieno!!!");
            for(j=0;j<i;j++)//uso i perchè conta le posizioni dell'array
            {
                Console.Write(v[j] + " ");
            }
            Console.ReadKey();
        }
    }
}
