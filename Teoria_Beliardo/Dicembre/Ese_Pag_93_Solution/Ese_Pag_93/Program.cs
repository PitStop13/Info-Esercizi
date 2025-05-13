using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_Pag_93
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] v = { "Bianchi", "Devirgilio", "Fabbri", "Gallo", "Melandri", "Varese" };
            string nome = "";
            int i = 0;

            Console.Write("inserisci il nome da cercare: ");
            nome = Console.ReadLine();

            while(i < v.Length && v[i].CompareTo(nome) < 0)
            {
                i++;
            }
            if (v[i] == nome) Console.Write($"\nElemento trovato in posizione {i}");
            else Console.WriteLine("Elemento NON trovato");
            Console.ReadKey();
        }
    }
}
