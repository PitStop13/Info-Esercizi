using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesio_Federico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scelta = Menu();
            do
            {
                switch (scelta)
                {
                    case 0:
                        Console.WriteLine("Ciao ciao..");
                        break;
                    case 1:
                        Console.Clear();
                        Esercizio1();
                        break;
                    case 2:
                        Console.Clear();
                        Esercizio2();
                        break;
                    case 3:
                        Console.Clear();
                        Esercizio3();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Errore");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
                scelta = Menu();
            } while (scelta != 0);
        }

        private static void Esercizio3()
        {
            int[] Array = { 5, 2, 9, 1, 7 };
            Console.WriteLine("L'array è:");
            stampaVet(Array);
            int somma = 0;
            Somma(Array, 0, ref somma);
            Console.Write($"\nLa somma è {somma}");
        }

        private static void Somma(int[] array, int i, ref int somma)
        {
            if(i >= array.Length)
            {
                return;
            }
            somma += array[i];
            Somma(array, ++i, ref somma);
        }

        private static void Esercizio2()
        {
            int[] Array = { 5, 2, 9, 1, 7 };
            Console.WriteLine("L'array iniziale è:");
            stampaVet(Array);
            BubbleSort(Array);
            Console.WriteLine("\nL'array finale è:");
            stampaVet(Array);
        }

        private static void BubbleSort(int[] array)
        {
            int i = -1;
            bool scambio;
            do
            {
                scambio = false;
                i++;
                for (int j = array.Length - 1; j >= i; j--)
                {
                    if (array[j] > array[j + 1])
                    {
                        int aus = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = aus;
                        scambio = true;
                    }
                }
            } while (i < array.Length && scambio);
        }

        private static void Esercizio1()
        {
            int[] Array = { 3, 8, 15, 23, 42 };
            Console.WriteLine("L'array è:");
            stampaVet(Array);
            int scelta = InserisciNumero();
            RicercaBinaria(Array, scelta);
        }

        private static int InserisciNumero()
        {
            int scelta;
            do
            {
                Console.WriteLine("\nInserisci un numero da cercare nell'array: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta));
            return scelta;
        }

        private static void RicercaBinaria(int[] array, int scelta)
        {
            int destra = 0, sinistra = array.Length, meta;
            do
            {
                meta = (destra + sinistra) / 2;
                if(array[meta] != scelta)
                {
                    if(array[meta] > scelta)
                    {
                        sinistra = meta - 1;
                    }
                    else
                    {
                        destra = meta + 1;
                    }
                }
            }while(array[meta] != scelta && destra < sinistra);

            if(array[meta] == scelta)
            {
                Console.WriteLine($"Elemento trovato in posizione {meta}");
            }
            else
            {
                Console.WriteLine("Elemento NON trovato");
            }
        }

        private static void stampaVet(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i].ToString().PadLeft(4));
        }

        private static int Menu()
        {
            int scelta;
            do
            {
                Console.Write("\n1) Esercizio 1\n2) Esercizio 2\n3) Esercizio 3\n0) Esci\n\nScelta: ");
            }while(!int.TryParse(Console.ReadLine(), out scelta));
            return scelta;
        }
    }
}
