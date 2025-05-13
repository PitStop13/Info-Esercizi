using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_20_pag247
{
    internal class Program
    {
        /*Un abbonamento a una rivista diminuisce del 5% se rinnovato 10 giorni prima della scadenza,
        del 15% se rinnovato 20 giorni prima della scadenza. Ricevuti in ingresso il costo dell'abbonamento
        e il numero di giorni trascorsi prima che l'abbonamento scada, calcola il costo finale.*/
        static void Main(string[] args)
        {
            Double costo = 0, prezzoScontato;
            int giorni;
            Console.Write("Inserisci il costo dell'abbonamento: ");
            costo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Inserisci il numero di giorni prima che l'abbonamento scada: ");
            giorni = Convert.ToInt32(Console.ReadLine());
            if (giorni >= 20)
            {
                prezzoScontato = costo * 0.85;
            }
            else
            {
                if (giorni >= 10)
                {
                    prezzoScontato = costo * 0.95;
                }
                else
                {
                    prezzoScontato = costo;
                }
            }
            Console.WriteLine("Il prezzo finale e': " + prezzoScontato);
            Console.ReadKey();
        }
    }
}
