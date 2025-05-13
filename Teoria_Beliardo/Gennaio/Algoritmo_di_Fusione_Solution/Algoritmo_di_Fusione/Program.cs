using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_di_Fusione
{
    internal class Program
    {
        static string[] a = { "Marino", "Bumbux", "Popuz", "Peano", "Ambrogio", "Mossello", "Bodoaga", "Fontana", "Olivero", "Borbone", "Cerone", "Negro", "Parola", "Singh", "Minetti", "Tortone", "Dzeljo", "Bonavia", "Hoxa", "Rrhozzani", "Miner" };
        static string[] b = { "Matteo", "Simone", "Miner", "Gabriele", "Elia", "Lorenzo", "Denis", "Nicolò", "Pietro", "Giosuè", "Nicolò", "Andrea", "Roberto", "Jas", "Nicolò", "Roberto", "Shilan", "Luca", "Brian", "Mateo", "Popuz" };
        static void Main(string[] args)
        {
            //ordino i vettori perchè non lo sono
            Array.Sort(a);
            Array.Sort(b);
            int scelta;
            do
            {
                scelta = visualizzaMenu();
                switch (scelta)
                {
                    case 0:
                        Console.WriteLine("Ciao ciao...");
                        break;
                    case 1:
                        Console.WriteLine("Caso 1");
                        FusioneBase();
                        break;
                    case 2:
                        Console.WriteLine("Caso 2");
                        FusioneTappo();
                        break;
                    default:
                        Console.WriteLine("Scelta non disponibile");
                        break;
                }
                Console.ReadKey();
            } while (scelta != 0);
        }

        private static void FusioneTappo()
        {
            StampaVet(a, "Vettore a:");
            StampaVet(b, "Vettore b:");

            const string TAPPO = "zzz";//Le costanti vanno scritte tutte maiuscole

            string[] c = new string[a.Length + b.Length];

            Array.Resize(ref a, a.Length + 1);
            Array.Resize(ref b, b.Length + 1);

            a[a.Length - 1] = b[b.Length - 1] = TAPPO;//Mette TAPPO in b e poi lo mette in a

            int i = 0, j = 0;

            for(int k = 0; k < c.Length; k++)
            {
                if (a[i].CompareTo(b[j]) > 0)
                {
                    c[k] = b[j];
                    j++;
                }
                else
                {
                    c[k] = a[i];
                    i++;
                }
            }

            StampaVet(c, "Vettore c:");
        }

        private static void FusioneBase()//Le funzioni vanno scritte con laprima lettera maiuscola
        {
            StampaVet(a,"Vettore a:");
            StampaVet(b, "Vettore b:");

            string[] c = new string[a.Length + b.Length];

            int i = 0, j = 0, k = 0;
            do
            {
                if (a[i].CompareTo(b[j]) > 0)//A > B
                {
                    c[k] = b[j];
                    j++;
                }
                else
                {
                    if(a[i].CompareTo(b[j]) == 0)//SONO UGUALI
                    {
                        c[k] = a[i];
                        i++; j++;
                    }
                    else//B > A
                    {
                        c[k] = a[i];
                        i++;
                    } 
                }
                k++;
            } while((i < a.Length) && (j < b.Length));
            //while (k < a.Length + b.Length); NON FUNZIONA CON ELEMNTI UGUALI NEI VETTORI a E b

            if(i >= a.Length)
            {
                for (int h = j; h < b.Length; h++)//RIEMPIO c CON IL VETTORE b
                {
                    c[k] = b[h];
                    k++;
                }
            }
            else
            {
                for (int h = i; h < a.Length; h++)//RIEMPIO c CON IL VETTORE a
                {
                    c[k] = a[h];
                    k++;
                }
            }

            Array.Resize(ref c, k);
            StampaVet(c, "\nVettore c: ");
        }

        private static void StampaVet(string[] a, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i].ToString().PadLeft(12));
                if ((i + 1) % 6 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine(); 
        }

        private static int visualizzaMenu()
        {
            int scelta;
            Console.Clear();
            Console.WriteLine("**** FUSIONE DI VETTORI ****");
            Console.WriteLine("1) Metodo Base");
            Console.WriteLine("2) Merge con Tappo");
            Console.WriteLine("0) Esci");
            Console.WriteLine("\nScelta > ");
            while(!int.TryParse(Console.ReadLine(), out scelta));
            return scelta;
        }
    }
}
