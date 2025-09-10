using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_63_Pag_86_Prof_Stringhe_Generali
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Ciao", s2 = "Cane", s3 = "Carta";
            string[] elementi = { s1, s2, s3 };

            //s1 la più piccola
            //if (s1.CompareTo(s2) <= 0 && s1.CompareTo(s3) <= 0)
            //{
            //    if (s2.CompareTo(s3) <= 0)
            //    {
            //        //s1 la più piccola e s2 < s3
            //        Console.WriteLine($"1° {s1}\n2° {s2}\n3° {s3}");
            //    }
            //    else
            //    {
            //        //s1 la più piccola e s3 < s2
            //        Console.WriteLine($"1° {s1}\n2° {s3}\n3° {s2}");
            //    }
            //}
            ////s2 è la più piccola
            //if (s2.CompareTo(s3) <= 0 && s1.CompareTo(s3) <= 0)
            //{
            //    if (s3.CompareTo(s1) <= 0)
            //        Console.WriteLine($"1° {s2}\n2° {s3}\n3° {s1}");
            //}
            //else
            //{
            //    Console.WriteLine($"1° {s2}\n2° {s1}\n3° {s3}");
            //}
            ////s3 è la più piccola
            //if (s3.CompareTo(s1) <= 0 && s3.CompareTo(s2) <= 0)
            //{
            //    if (s1.CompareTo(s2) <= 0)
            //    {
            //        Console.WriteLine($"1° {s3}\n2° {s1}\n3° {s2}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"1° {s3}\n2° {s2}\n3° {s1}");
            //    }
            //}
            //Console.ReadKey();
            //for (int i = 1; i < elementi.Length; i++)
            //{
            //    int pos = primaStringa(elementi, i);
            //    string aus = elementi[pos];
            //    elementi[pos] = elementi[i];
            //    elementi[i] = aus;
            //}
            for (int i = 1; i < elementi.Length; i++)
            {
                for(int j = 0; j < elementi.Length; j++)
                {
                    if (elementi[j].CompareTo(elementi[i]) > 0)
                    {
                        string aus = elementi[j];
                        elementi[j] = elementi[i];
                        elementi[i] = aus;
                    }
                }
            }
            for(int i = 0; i < elementi.Length; i++)
            {
                Console.WriteLine(elementi[i]);
            }
            Console.ReadKey();
        }

        //private static int primaStringa(string[] elementi, int i)
        //{
        //    bool trovato = false;
        //    int pos = i;
        //    while (!trovato && i < elementi.Length)
        //    {

        //    }

        //    return pos;
        //}
    }
}
