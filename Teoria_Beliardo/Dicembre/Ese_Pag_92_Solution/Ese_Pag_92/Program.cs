using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_Pag_92
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] v = { "Bianchi", "Devirgilio", "Gallo", "Melandri", "Fabbri", "Varese", "Bianchi" };
            string nome = "";
            int i = 0;
            bool trovato = false;

            Console.Write("inserisci il nome da cercare: ");
            nome = Console.ReadLine();

            for (i = 0; i < v.Length; i++)
            {
                if (v[i] == nome)
                {
                    Console.Write($"\nElemento trovato in posizione {i}");
                    trovato = true;
                }
            }
            if (!trovato) Console.WriteLine("Elemento NON trovato");
            Console.ReadKey();
        }
    }
}
