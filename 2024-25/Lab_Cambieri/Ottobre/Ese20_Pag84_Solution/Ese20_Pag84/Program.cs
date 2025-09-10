using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ese20_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Random random = new Random();
            do
            {
                Console.Write($"Introduci il num di elementi (n > 0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            int[] a = new int[n];
            //bool cond = true;
            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(1, 21);
            }
            Console.WriteLine("Vettore A: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            //for (int i=1; i < n; i++)
            //{
            //    for (int j = 1; j < n; j++)
            //        if (a[i-1] == a[j])
            //            cond = false;
            //}
            //string message = "";
            //if (cond)
            //    message = "I valori dell'array sono tutti diversi";
            //else
            //    message = "I valori dell'array non sono tutti diversi";
            /*bool tuttiDiversi =true;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (a[i] == a[j])
                    {
                        tuttiDiversi = false;
                        break;
                    }
                }
                if (!tuttiDiversi) break;
            }*/
            bool tuttiDiversi = true;
            int ii = 0;
            while(tuttiDiversi && ii<n-1)
            {
                int j = ii + 1;
                while(tuttiDiversi && j<n)
                {
                    if (a[ii] == a[j])
                    {
                        tuttiDiversi = false;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            string message = "";
            if (tuttiDiversi)
                message = "I valori dell'array sono tutti diversi";
            else
                message = "I valori dell'array non sono tutti diversi";
            Console.WriteLine("\n" + message);
            Console.ReadKey();
        }
    }
}
