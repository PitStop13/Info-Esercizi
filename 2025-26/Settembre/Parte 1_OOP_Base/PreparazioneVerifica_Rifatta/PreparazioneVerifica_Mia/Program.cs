using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparazioneVerifica_Mia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ListaOggetti = new List<Oggetto>
            {
                new Libro("Libro 1","IO",12,12),
                new Elettronico("HDD","SanDisk",1000,120,3),
                new Abbigliamento("Felpa",20,12),
                new Libro("Libro 2","IO",2025,13,10),
                new Elettronico("SSD","SanDisk",1000,120,2,3),
                new Abbigliamento("Maglietta","Gucci",20,12)
            };

            double prezzoTotale = 0;
            foreach (var o in ListaOggetti)
            {
                Console.WriteLine($"Prodotto: {o.Nome} ({o.GetType().Name})");
                Console.WriteLine(o.ToString());

                double prezzoUnitario = o.CalcolaPrezzoUnitario();
                double prezzoTotaleOggetto = Math.Round(prezzoUnitario * o.Quantità, 2);
                Console.WriteLine($"Prezzo unitario (Con iva/sconti): {prezzoUnitario.ToString("F2")} Totale riga: {prezzoTotaleOggetto.ToString("F2")}\n");

                prezzoTotale += prezzoTotaleOggetto;

            }

            Console.WriteLine("totale complessivo: \n" + prezzoTotale.ToString("F2"));
            //as
            ApplicaAumentoStock(ListaOggetti[2], 3);
            //valore
            Oggetto modificaValore = new Abbigliamento("Pantaloni", "Gucci", 20, 12);
            Console.WriteLine($"Prima passaggio per valore: quantità = {modificaValore.Quantità}");
            ModificaPerValore(modificaValore);
            Console.WriteLine($"Dopo passaggio per valore: quantità = {modificaValore.Quantità}");
            //ref
            Oggetto modificaRef = new Abbigliamento("Jeans", "Gucci", 20, 12);
            Console.WriteLine($"Prima passaggio per ref: quantità = {modificaRef.Quantità}");
            ModificaPerRef(ref modificaRef);
            Console.WriteLine($"Dopo passaggio per ref: quantità = {modificaRef.Quantità}");
            //out
            double totaleCalcolato;
            CalcolaTotRigaOUT(out totaleCalcolato, ListaOggetti[1]);
            Console.WriteLine($"Totale riga calcolato con 'out' per {ListaOggetti[1].Nome}: {totaleCalcolato.ToString("F2")}");


        }

        private static void CalcolaTotRigaOUT(out double totaleCalcolato, Oggetto oggetto)
        {
            totaleCalcolato = Math.Round(oggetto.CalcolaPrezzoUnitario() * oggetto.Quantità, 2); 
        }

        private static void ModificaPerRef(ref Oggetto modificaRef)
        {
            modificaRef = new Abbigliamento("Pigjama", "Gucci", 2000, 20);
            Console.WriteLine(modificaRef.ToString());
        }

        private static void ModificaPerValore(Oggetto modificaValore)
        {
            modificaValore = new Abbigliamento("TUTA", "Gucci", 2000, 20);
            Console.WriteLine(modificaValore.ToString());
        }

        private static void ApplicaAumentoStock(Oggetto oggetto, int incremento)
        {
            Abbigliamento provaAs = oggetto as Abbigliamento;
            if (provaAs != null)
            {
                Console.WriteLine($"Prima ({provaAs.Nome}) quantità = {provaAs.Quantità}");
                provaAs.Quantità += incremento;

                Console.WriteLine($"Dopo ApplyStockAdjustmentUsingAs(...) quantità = {provaAs.Quantità}");
            }
            else
            {
                Console.WriteLine($"L'oggetto {oggetto.Nome} non è di tipo Abbigliamento, cast fallito.");
            }
        }
    }
}
