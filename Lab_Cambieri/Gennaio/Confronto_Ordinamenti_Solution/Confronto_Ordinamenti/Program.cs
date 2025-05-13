using System;
using System.Collections.Generic;
using System.Diagnostics;//serve per Stopwatch
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confronto_Ordinamenti
{
    internal class Program
    {
        const int LUNGHEZZA = 68;//largezza tabella
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();//tiene il tempo

            Titolo("Confronto tra algoritmi di ordinamento", "(su insieme disordinato)", ConsoleColor.Cyan, ConsoleColor.Black);//calsse che ci stampa il titolo
            Titolo("Ordinamento di 500 elementi |  PER SELEZIONE |     PER SCAMBIO", "", ConsoleColor.Magenta, ConsoleColor.Black);

            // CARICO VETTORE DISORDINATO
            int n = 500;
            int[] a = new int[n];
            int[] b = new int[n];
            ClsVettori.CaricaVetDisordinato(a);//creo una funzione in clsvettori che carica a
            a.CopyTo(b, 0);//copia un array su un altro, 0 è l'indice dalla quale vogliamo cominciare
            long selPassi = 0; //numero di passi di selezione
            long selConfronti = 0;
            long selScambi = 0;
            long selTicks = 0;
            sw.Start();
            ClsVettori.OrdinaSelezione(a, ref selPassi, ref selConfronti, ref selScambi);//conta i passi i confronti e gli scambi
            sw.Stop();
            selTicks = sw.ElapsedTicks;

            long scaPassi = 0; //numero di passi di scambi
            long scaConfronti = 0;
            long scaScambi = 0;
            long scaTicks = 0;
            sw.Restart();//se non faccio restart mi parte da dove si era fermato prima
            ClsVettori.OrdinaScambio(b, ref scaPassi, ref scaConfronti, ref scaScambi);
            sw.Stop();
            scaTicks = sw.ElapsedTicks;

            ScriviValori("Numero di passi", selPassi, scaPassi);
            ScriviValori("Numero di confronti", selConfronti, scaConfronti);
            ScriviValori("Numero di scambi", selScambi, scaScambi);
            ScriviValori("Tempo in ticks", selTicks, scaTicks);



            Console.ReadKey();
        }

        private static void ScriviValori(string descr, long selValore, long scaValore)
        {
            Console.WriteLine("|" + descr.PadLeft(31) + "|" + selValore.ToString().PadLeft(16) + "|" + scaValore.ToString().PadLeft(16) + " |");
            DisegnaRiga(LUNGHEZZA);
        }

        private static void Titolo(string titolo, string sottotitolo, ConsoleColor coloreBg, ConsoleColor coloreFg)
        {
            Console.BackgroundColor = coloreBg;//sfondo
            Console.ForegroundColor = coloreFg;//testo
            DisegnaRiga(LUNGHEZZA);
            int numSpazi = (LUNGHEZZA - titolo.Length) / 2;//lunghezza del pad del titolo
            Console.WriteLine("|".PadRight(numSpazi) + titolo + "|".PadLeft(numSpazi));//mette | e poi una serie di spazi che vogliamo noi (24)
            if(sottotitolo.Length > 0)
            {
                numSpazi = (LUNGHEZZA - sottotitolo.Length) / 2;//lunghezza del pad del sottotitolo
                Console.WriteLine("|".PadRight(numSpazi) + sottotitolo + "|".PadLeft(numSpazi));
            }
            DisegnaRiga(LUNGHEZZA);
            Console.ResetColor();//resetta i colori
        }

        private static void DisegnaRiga(int lunghezza)
        {
            for (int i = 0; i < lunghezza; i++)
                Console.Write("-");
            Console.WriteLine();
        }
    }
}
