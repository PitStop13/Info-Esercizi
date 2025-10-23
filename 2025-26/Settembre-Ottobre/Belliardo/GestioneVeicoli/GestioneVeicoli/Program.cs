using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneVeicoli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var veicoli = new List<Veicolo>
            {
                new Auto("ABCD","ferrari",2025,5000,10),
                new Furgone("ABCDE","daily",2024,2,5),
                new Moto("ABCDEF","ducati",2023,true,12),
                new Auto("1234","lambo",2020,5000,9),
                new Furgone("12345","fiat",2019,2,6),
                new Moto("123456","aprilia",2018,false,2),
            };

            double totaleComplessivo = 0;
            foreach (var v in veicoli)
            {
                Console.WriteLine("Veicolo: "+ v.Modello + $" ({v.GetType().Name})");
                Console.WriteLine(v.ToString());

                double totaleRiga = v.CalcolaCosto() * v.Giorni;
                Console.WriteLine($"Costo giornaliero (con tasse/sconti): {v.CalcolaCosto().ToString("F2")} Totale riga: {totaleRiga.ToString("F2")}");

                totaleComplessivo += totaleRiga;

            }

            Console.WriteLine($"Totale complessivo: {totaleComplessivo.ToString("F2")}");
            //as
            AumentaGioriMoto(veicoli[2],3);
            //valore
            Veicolo v1 = new Moto("1234", "ducati", 2023, true, 12);
            Console.WriteLine($"Prima della modifica per valore: {v1.ToString()}");
            ModificaPerValore(v1);
            Console.WriteLine($"Dopo della modifica per valore: {v1.ToString()}");

            //ref
            Veicolo v2 = new Moto("1234", "ducati", 2023, true, 12);
            Console.WriteLine($"Prima della modifica per ref: {v2.ToString()}");
            ModificaPerRef(ref v2);
            Console.WriteLine($"Dopo della modifica per ref: {v2.ToString()}");
            //out
            double totRiga =0;
            CalcolaTotRiga(veicoli[1],out totRiga);
            Console.WriteLine($"Totale riga per furgone daily = {totRiga.ToString("F2")}");

        }

        private static void CalcolaTotRiga(Veicolo veicolo,out double totRiga)
        {
            totRiga = Math.Round(veicolo.CalcolaCosto() * veicolo.Giorni,2) ;
        }

        private static void ModificaPerRef(ref Veicolo v2)
        {
            v2 = new Auto("123", "ferrari", 2025, 5000, 10);
            Console.WriteLine("Dentro la modifica per ref: " + v2.ToString());
        }

        private static void ModificaPerValore(Veicolo v1)
        {
            v1 = new Auto("123", "ferrari", 2025, 5000, 10);
            Console.WriteLine("Dentro la modifica per valore: "+v1.ToString());
        }

        private static void AumentaGioriMoto(Veicolo veicolo, int giorni)
        {
            Moto AumentaGorniMoto = veicolo as Moto;
            if (AumentaGorniMoto != null)
            {

                Console.WriteLine($"Da aumentare giorni moto: {veicolo.Giorni}");
                AumentaGorniMoto.Giorni += giorni;
                Console.WriteLine($"Aumentati giorni moto: {veicolo.Giorni}");
            }
            else Console.WriteLine("Cast fallito");
        }


    }
}
