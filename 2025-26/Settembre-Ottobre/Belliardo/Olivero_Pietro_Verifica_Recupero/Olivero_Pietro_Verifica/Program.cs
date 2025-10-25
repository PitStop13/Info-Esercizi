using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro_Verifica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ListaOggetti = new List<Prenotazioni>
            {
                new Hotel("Hotel paradiso",3),
                new Volo("Volo Milano-Parigi",1),
                new NoleggioAuto("Noleggio Fiat 500",10),
                new Hotel("Hotel inferno"),
                new Volo("Volo Milano-Tokyo",2),
                new NoleggioAuto("Noleggio Ferrari 488",1),
            };

            double prezzoTotale = 0;
            foreach (var o in ListaOggetti)
            {
                Console.WriteLine($" Prenotazione:{o.Nome} ({o.GetType().Name})");
                Console.WriteLine(o.ToString());
                Console.WriteLine($"Tassa soggiorno totale:$");
                Console.WriteLine($"Costo totale: {o.CalcolaCostoPrenotazione().ToString("F2")}");
                prezzoTotale += o.CalcolaCostoPrenotazione();

            }
            Console.WriteLine("TOTALE GENERALE: \n" + prezzoTotale.ToString("F2"));

            //as
            AggiungiNotteAs(ListaOggetti[0], 3);
            //valore
            Prenotazioni modificaValore = new NoleggioAuto("Noleggio Lambo", 10);
            Console.WriteLine("Prima modifica valore,NOme:" + modificaValore.Nome);
            ModificaPerValore(modificaValore);
            Console.WriteLine("Dopo modifica valore,NOme:" + modificaValore.Nome);
            //ref
            Prenotazioni modificaRef = new NoleggioAuto("Noleggio Lambo", 10);
            Console.WriteLine("Prima modifica ref,NOme:" + modificaRef.Nome);
            ModificaPerRef(ref modificaRef);
            Console.WriteLine("Dopo modifica ref,NOme:" + modificaRef.Nome);
            //out
            Hotel temp;
            CalcolaTotRigaOUT(out temp);
            Console.WriteLine($"Dimostrazione out:{temp.ToString()}");
            Console.ReadKey();

        }

        private static void CalcolaTotRigaOUT(out Hotel temp)
        {
            temp = new Hotel("Hotel 1", 3);
        }

        private static void ModificaPerRef(ref Prenotazioni modificaRef)
        {
            modificaRef = new Hotel("Hotel 1");
            Console.WriteLine("Dentro modifica valore,NOme:" + modificaRef.Nome);
        }

        private static void ModificaPerValore(Prenotazioni modificaValore)
        {
            modificaValore = new Hotel("Hotel 1");
            Console.WriteLine("Dentro modifica valore,NOme:" + modificaValore.Nome);
        }
        private static void AggiungiNotteAs(Prenotazioni prenotazioni, int v)
        {
            Hotel modificaAs = prenotazioni as Hotel;
            if(modificaAs != null)
            {
                Console.WriteLine("notti prima: "+modificaAs.Notti);
                modificaAs.Notti = modificaAs.Notti+v;
                Console.WriteLine("notti dopo: " + modificaAs.Notti);
            }
            else
            {
                Console.WriteLine("Cast fallito");
            }
        }
    }
}
