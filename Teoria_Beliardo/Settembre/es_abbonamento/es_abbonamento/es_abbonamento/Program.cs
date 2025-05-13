using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_abbonamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Double costo = 0,prezzoScontato;
            int giorni;
            Console.Write("Inserisci il costo dell'abbonamento: ");
            costo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Inserisci il numero di giorni prima che l'abbonamento scada: ");
            giorni = Convert.ToInt32(Console.ReadLine());
            if(giorni>=20)
            {
                prezzoScontato = costo * 0.8;
            }
            else
            {

            }
            Console.ReadKey();
        }
    }
}
