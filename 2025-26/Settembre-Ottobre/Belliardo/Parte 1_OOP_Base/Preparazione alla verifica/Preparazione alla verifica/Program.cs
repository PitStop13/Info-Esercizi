using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla_verifica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Veicoli = new List<Veicolo>() {
                new Auto("AA111BB", 2020),
                new Auto("CC222DD", 2018, 4),
                new Furgone("EE333FF", 2017, 2000),
                new Furgone("GG444HH", 2019, 3000, 1500)

            };
            int giorniNoleggio = 10;
            double Totalesomma = 0;

            foreach (var v in Veicoli) {
                double tariffa = v.CalcolaTariffa(giorniNoleggio);
                Console.WriteLine($"{v} Tariffa({giorniNoleggio} giorni) = {tariffa:0.00} €");
                Totalesomma += tariffa;
                if(v is Furgone)
                {
                    Furgone f = v as Furgone;
                    double pesodacaricare = 500;
                    f.Carica(ref pesodacaricare);
                    Console.WriteLine("Carico effetuato,residuo= "+ pesodacaricare + "kg");
                }

            }
            Console.WriteLine("Totale: "+Totalesomma);
        }
    }
}
