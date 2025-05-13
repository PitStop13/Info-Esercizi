using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_Pag_94
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] v = { "Barbero", "Chiera", "Chiera", "Chiera", "Fabbri", "Vaschetto" };
            string nome = "";
            int i = 0;
            bool trovato = false, superato = false;

            Console.Write("inserisci il nome da cercare: ");
            nome = Console.ReadLine();

            while (i < v.Length && !superato)
            {
                if (v[i] == nome)
                {
                    Console.Write($"\nElemento trovato in posizione {i}");
                    trovato = true;
                    i++;
                }
                else
                {
                    if (v[i].CompareTo(nome) < 0) i++;
                    else superato = true;
                }
            }
            if (!trovato) Console.WriteLine("Elemento NON trovato");
            Console.ReadKey();
        }
    }
}
