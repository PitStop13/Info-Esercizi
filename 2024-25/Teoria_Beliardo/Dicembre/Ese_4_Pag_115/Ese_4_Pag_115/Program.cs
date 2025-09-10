using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_4_Pag_115
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n;

            do
            {
                Console.WriteLine("Inserire il numero di studenti presenti nella scuola");
            } while (!int.TryParse(Console.ReadLine(), out n));

            string[] cognomi = new string[n], nomi = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Inserire il cognome dello studente numero {i + 1}: ");
                cognomi[i] = Console.ReadLine();
                Console.WriteLine($"Inserire il nome dello studente numero {i + 1}: ");
                nomi[i] = Console.ReadLine();
            }
            Console.WriteLine("Gli alunni ordinati per cognome sono: ");
            for (int i = 0; i < n - 1; i++)
            {
                int posMin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (String.Compare(cognomi[j], cognomi[i]) < 0)
                    {
                        posMin = j;
                    }
                }
                if (posMin != i)
                {
                    string aus = cognomi[i];
                    cognomi[i] = cognomi[posMin];
                    cognomi[posMin] = aus;

                    aus = nomi[i];
                    nomi[i] = nomi[posMin];
                    nomi[posMin] = aus;
                }
                Console.Write($"{cognomi[i]} {nomi[i]} ");
            }
            Console.Write($"{cognomi[n - 1]} {nomi[n - 1]}");

            Console.WriteLine("\n\nInserisci il cognome da cercare: ");
            string x = Console.ReadLine();

            int inf = n - 1, meta, sup = 0;

            do
            {
                meta = (inf + sup) / 2;
                if (cognomi[meta] != x)
                {
                    if (String.Compare(cognomi[meta], x) > 0)
                    {
                        inf = meta - 1;
                    }
                    else
                    {
                        sup = meta + 1;
                    }
                }
            } while (!(cognomi[meta] == x || sup > inf));

            if (cognomi[meta] != x)
            {
                Console.WriteLine("Elemento non trovato");
            }
            else
            {
                Console.WriteLine($"{cognomi[meta]} {nomi[meta]} trovato in posizione {meta}");
            }
            Console.ReadKey();
        }
    }
}
