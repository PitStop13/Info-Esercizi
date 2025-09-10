using System;

namespace Ese_Pag_96
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] v = { "Barberis", "Barbero", "Bruno", "Calleri", "Costantino", "Dadone", "Ferrero", "Giaccone", "Giachello", "Musso", "Napoli", "Operti", "Pansa", "Pensa", "Rossi", "Rosso", "Viglietti" };
            string x = "";
            Console.Write("inserisci il nome da cercare: ");
            x = Console.ReadLine();

            int i = 0;
            int sup = v.Length - 1, inf = 0;
            int meta = (inf + sup) / 2;

            do
            {
                meta = (inf + sup) / 2;//Arrotondamento ??
                if (v[meta] != x)
                {
                    if (v[meta].CompareTo(x) > 0) sup = meta - 1;
                    else inf = meta + 1;
                }
            } while (v[meta] != x || sup < inf);

            if (v[meta] != x) 
                Console.WriteLine("Elemento NON trovato");
            else
                Console.Write($"\nElemento trovato in posizione {meta}");
            Console.ReadKey();
        }
    }
}
