using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Ese_63_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S1 = InserisciStringa("Inserisci la 1° stringa: ");
            string S2 = InserisciStringa("Inserisci la 2° stringa: ");
            string S3 = InserisciStringa("Inserisci la 3° stringa: ");
            int i = 0, cont = 0;
            string[] a = new string[3];
            while (i < S1.Length && i < S2.Length && i < S3.Length)
            {
                if(S1[i] != S2[i] || S1[i] != S3[i] || S2[i] != S3[i])
                {
                    if (S1[i] <= S2[i])
                    {
                        if (S1[i] <= S3[i])
                        {
                            a[cont++] = S1;
                            if (S2[i] < S3[i])
                            {
                                a[cont++] = S2;
                                a[cont] = S3;
                            }
                            else
                            {
                                a[cont++] = S3;
                                a[cont] = S2;
                            }
                        }
                        else
                        {
                            if (S2[i] < S3[i])
                            {
                                a[cont++] = S2;
                                a[cont++] = S3;
                                a[cont] = S1;
                            }
                            else
                            {
                                a[cont++] = S3;
                                a[cont++] = S1;
                                a[cont] = S2;
                            }
                        }
                    }
                    else
                    {
                        if (S2[i] <= S3[i])
                        {
                            a[cont++] = S2;
                            a[cont++] = S3;
                            a[cont] = S1;

                        }
                        else
                        {
                            a[cont++] = S3;
                            a[cont++] = S2;
                            a[cont] = S1;
                        }
                    }
                }
                i++;
            }
            if(cont == 0)
            {
                a[cont++] = S1;
                a[cont++] = S2;
                a[cont++] = S3;
            }
            StampaStringhe("\nLe stringhe, ora, sono in ordine crescente: ", a);
            Console.ReadKey();
        }

        private static void StampaStringhe(string message, string[] a)
        {
            Console.WriteLine(message);
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        private static string InserisciStringa(string message)
        {
            Console.Write(message);
            return Console.ReadLine().ToLower();
        }
    }
}
