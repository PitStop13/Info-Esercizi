using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese002Compito
{
    /*Al bar sulla spiaggia la granita costa 5.20 euro, il frappe' 7.10 euro e la coppa gelato 6.50 euro.
      Ricevuta in ingresso una ordinazione, calcola la spesa totatle.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int granita = 0, frappe = 0, coppaGelato = 0, ordine = 0;
            double costoGranita = 0, costoFrappe = 0, costoCoppaGelato = 0, totale = 0;
            char risposta;
            do
            {
                do
                {
                    Console.WriteLine("Cosa vuoi ordinare ? (premere 1= granita, 2= frappè, 3= coppa gelato)");
                    ordine = Convert.ToInt32(Console.ReadLine());
                } while (ordine != 1 && ordine != 2 && ordine != 3);
                switch (ordine)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("La granita costa 5.20 euro, quante ne vuoi ?");
                            granita = Convert.ToInt32(Console.ReadLine());
                            costoGranita = costoGranita + (granita * 5.20);
                        } while (granita <= 0);
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine("Il frappè costa 7.10 euro, quante ne vuoi ?");
                            frappe = Convert.ToInt32(Console.ReadLine());
                            costoFrappe = costoFrappe + (frappe * 7.10);
                        } while (frappe <= 0);
                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine("La coppa gelato costa 6.50 euro, quante ne vuoi ?");
                            coppaGelato = Convert.ToInt32(Console.ReadLine());
                            costoCoppaGelato = costoCoppaGelato + coppaGelato * 6.50;
                        } while (coppaGelato <= 0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Vuoi ordinare altro ? (premere s=si, n=no)");
                risposta = Convert.ToChar(Console.ReadLine());
            } while (risposta == 's');
            totale = costoGranita + costoFrappe + costoCoppaGelato;
            Console.Write("Il totale è di " + totale + " euro");
            Console.ReadKey();
        }
    }
}
