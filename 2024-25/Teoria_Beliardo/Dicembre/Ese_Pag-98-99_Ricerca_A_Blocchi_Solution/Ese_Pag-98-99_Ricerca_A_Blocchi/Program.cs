using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_Pag_98_99_Ricerca_A_Blocchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] v = { "Barberis", "Barbero", "Bruno", "Calleri", "Costantino", "Dadone", "Ferrero", "Giaccone", "Giachello", "Musso", "Napoli", "Operti", "Pansa", "Pensa", "Rossi", "Rosso", "Viglietti"};
            Console.Write("Inerisci l'elemento da cercare: ");
            string x = Console.ReadLine();
            bool trovato = false, esci = false;
            int lb = Convert.ToInt32(Math.Sqrt(v.Length));
            int i = (lb - 1);

            do
            {
                if (v[i] == x) trovato = true;
                else
                {
                    if (v[i].CompareTo(x) > 0) EsaminaBlocco(lb, ref i, v, x, ref trovato, ref esci);
                    else i += lb;
                }
            } while (!trovato && !esci && i < v.Length);

            if (trovato) Console.WriteLine($"Elemento trovato in posizione {i}");
            else
            {
                if (esci) Console.WriteLine("Elemento NON trovato");
                else UltimoBlocco(lb, ref i, v, x);
            }
            Console.ReadKey();
        }

        private static void UltimoBlocco(int lb, ref int i, string[] v, string x)
        {
            i -= lb + 1;

            while (v[i].CompareTo(x) < 0 && i < v.Length - 1)
            {
                i += 1;
            }

            if (v[i] == x) Console.WriteLine($"Elemento trovato in posizione {i}");
            else Console.WriteLine("Elemento NON trovato");
        }

        private static object EsaminaBlocco(int lb, ref int i, string[] v, string x, ref bool trovato, ref bool esci)
        {
            int j = (i - lb) + 1;

            while (v[j].CompareTo(x) < 0 && j < i - 1)
            {
                j = j + 1;
            }

            if (v[j] == x)
            {
                return (trovato = true, i = j);
            }
            else return esci = true;
        }
    }
}
