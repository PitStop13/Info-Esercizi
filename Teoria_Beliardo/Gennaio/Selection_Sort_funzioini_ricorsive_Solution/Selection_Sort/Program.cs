using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[10];
            int[] vr = new int[10];
            Random r = new Random();
            Stopwatch sw = new Stopwatch();
            long SsTicks = 0, SsrTicks = 0;

            Console.WriteLine("**Slection sort ricorsivo**");
            CaricaVet(v, r);
            v.CopyTo(vr, 0);
            StampaVet(v);
            Console.WriteLine($"\n\nSlection sort:");
            sw.Start();
            SelectionSort(v);
            sw.Stop();
            SsTicks = sw.ElapsedTicks;
            Console.WriteLine($"\n\nTempo in Ticks: {SsTicks}");
            Console.WriteLine($"\n\nSlection sort ricorsivo:");
            sw.Restart();
            SelectionSortRicorsivo(vr, 0);
            sw.Stop();
            SsrTicks = sw.ElapsedTicks;
            Console.WriteLine($"\n\nTempo in Ticks: {SsrTicks}");
            Console.ReadKey();
        }

        private static void SelectionSortRicorsivo(int[] vr, int i)
        {
            //if (i < vr.Length - 1)
            //{
            //    posMin = i;
            //    for (int j = i + 1; j < vr.Length; j++)
            //    {
            //        if (vr[posMin] > vr[j])
            //            posMin = j;
            //    }
            //    if (posMin != i)
            //    {
            //        int aus = vr[i];
            //        vr[i] = vr[posMin];
            //        vr[posMin] = aus;
            //    }
            //    i++;
            //    SelectionSortRicorsivo(vr, ref i, posMin);
            //}
            //else
            //{
            //    return;
            //}

            if (i == vr.Length - 1)//FINE FUNZIONE
            {
                return;
            }

            int posMin = i;

            for (int j = i + 1; j < vr.Length; j++)
            {
                if (vr[posMin] > vr[j])
                    posMin = j;
            }

            if (posMin != i)
            {
                int aus = vr[i];
                vr[i] = vr[posMin];
                vr[posMin] = aus;
            }

            Console.WriteLine();
            StampaVet(vr);

            //chamata ricorsiva
            SelectionSortRicorsivo(vr, i = i + 1);
        }

        private static void SelectionSort(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
            {
                int posMin = i;
                for (int j = i + 1; j < v.Length; j++)
                {
                    if (v[posMin] > v[j])
                        posMin = j;
                }
                if (posMin != i)
                {
                    int aus = v[i];
                    v[i] = v[posMin];
                    v[posMin] = aus;
                }
                Console.WriteLine();
                StampaVet(v);
            }
        }

        private static void StampaVet(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i].ToString().PadLeft(3));
            }
        }

        private static void CaricaVet(int[] v, Random r)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = r.Next(1, 100);
            }
        }
    }
}
