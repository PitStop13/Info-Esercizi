using System;
using System.Collections.Generic;

namespace Es_2_OOP
{
    internal class Program
    {
        static void ProvaRiassegna(Veicolo v)
        {
            v = new Auto("XXX000", 2025);
        }

        static void ProvaRiassegnaRef(ref Veicolo v)
        {
            v = new Auto("ZZ999ZZ", 2025);
        }

        static void Main(string[] args)
        {
            var veicoli = new List<Veicolo>
            {
                new Auto("AB123CD", 2018, 5),
                new Furgone("FG456HI", 2020, 1000, 400),
                new Auto("ASDFGHJ", 2019, 2),
                new Furgone("ZXCVBNM", 2025, 1200, 600)
            };

            int ore = 3;
            double totale = 0;

            foreach (var v in veicoli)
            {
                double tariffa = v.CalcolaTariffa(ore);
                Console.WriteLine($"{v} Tariffa({ore}h)={tariffa:0.0}");
                totale += tariffa;

                if (v is Furgone f)
                {
                    double daCaricare = 300;
                    f.Carica(ref daCaricare);
                    Console.WriteLine($"Carico effettuato, residuo={daCaricare:0.##}kg");
                }
            }

            Console.WriteLine($"Totale tariffa {totale:0.0}");

            Veicolo v1 = new Auto("AA000AA", 2019);
            ProvaRiassegna(v1);
            Console.WriteLine($"Dopo ProvaRiassegna: {v1}");

            Veicolo v2 = new Auto("BB111BB", 2019);
            ProvaRiassegnaRef(ref v2);
            Console.WriteLine($"Dopo ProvaRiassegnaRef: {v2}");

            Console.ReadLine();
        }
    }
}
