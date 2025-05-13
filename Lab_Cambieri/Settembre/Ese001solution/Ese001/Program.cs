using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random generatoreNumCasuali = new Random();
            //int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0;
            int[] A = new int[5];
            Console.WriteLine("Il programma crea 100 nuemri random tra 1 e 5 e ne calcola la frequenza");
            for (int i = 0; i < 100; i++)
            {
                int n = generatoreNumCasuali.Next(1, 6);
                //if(n == 1)
                //{
                //    c1++;
                //}
                //else if(n == 2)
                //{
                //    c2++;
                //}
                //else if (n == 3)
                //{
                //    c3++;
                //}
                //else if (n == 4)
                //{
                //    c4++;
                //}
                //else if (n == 5)
                //{
                //    c5++;
                //}
                switch (n)
                {
                    case 1:
                        //c1++;
                        A[0]++;
                        break;
                    case 2:
                        //c2++;
                        A[1]++;
                        break;
                    case 3:
                        //c3++;
                        A[2]++;
                        break;
                    case 4:
                        //c4++;
                        A[3]++;
                        break;
                    case 5:
                        //c5++;
                        A[4]++;
                        break;
                    default:
                        break;
                }
            }
            //Console.WriteLine("Il numero 1 è uscito " + c1 + " volte");
            //Console.WriteLine("Il numero 2 è uscito " + c2 + " volte");
            //Console.WriteLine("Il numero 3 è uscito " + c3 + " volte");
            //Console.WriteLine("Il numero 4 è uscito " + c4 + " volte");
            //Console.WriteLine("Il numero 5 è uscito " + c5 + "  volte");
            //Console.WriteLine($"Il numero 1 è uscito {c1} volte");
            //Console.WriteLine($"Il numero 2 è uscito {c2} volte");
            //Console.WriteLine($"Il numero 3 è uscito {c3} volte");
            //Console.WriteLine($"Il numero 4 è uscito {c4} volte");
            //Console.WriteLine($"Il numero 5 è uscito {c5} volte");
            Console.WriteLine($"Il numero 1 è uscito {A[0]} volte");
            Console.WriteLine($"Il numero 2 è uscito {A[1]} volte");
            Console.WriteLine($"Il numero 3 è uscito {A[2]} volte");
            Console.WriteLine($"Il numero 4 è uscito {A[3]} volte");
            Console.WriteLine($"Il numero 5 è uscito {A[4]} volte");
            Console.ReadKey();
        }
    }
}
