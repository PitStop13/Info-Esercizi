using System;
using System.Collections.Generic;

namespace Olivero_Pietro
{
    internal class Program
    {
        static void ModificaPerValore(Oggetto obj)
        {
            obj.AggiungiStock(10);
            Console.WriteLine($"Dentro ModificaPerValore: quantità = {obj.Quantità}");
        }

        static void ModificaPerRiferimento(ref Oggetto obj)
        {
            obj = new Abbigliamento("Nuovo Oggetto", "NuovaMarca", 99.99, 5);
            Console.WriteLine($"Dentro ModificaPerRiferimento: {obj.Nome}");
        }
        static void CalcolaTotaleRiga(out double totale, Oggetto obj)
        {
            totale = Math.Round(obj.CalcolaPrezzoUnitario() * obj.Quantità, 2);
        }

        static void ApplicaStockAdjustmentUsingAs(Oggetto obj, int quantitaDaAggiungere)
        {
            Abbigliamento abb = obj as Abbigliamento;
            if (abb != null)
            {
                Console.WriteLine($"Prima ({abb.Nome}) quantità = {abb.Quantità}");
                abb.AggiungiStock(quantitaDaAggiungere);
                Console.WriteLine($"Dopo ApplyStockAdjustmentUsingAs(...) quantità = {abb.Quantità}");
            }
            else
            {
                Console.WriteLine("L'oggetto non è un Abbigliamento, cast fallito.");
            }
        }

        static void Main(string[] args)
        {
            var O = new List<Oggetto>
            {
                new Libro("Il C# Essenziale", 24.90, 2020, "Mario Rossi", 3),
                new Elettronico("HardDisk 1TB", "SanDisk", 1, 59.99, 2, 2),
                new Abbigliamento("Giacca", "Gucci", 49.50, 2),
                new Abbigliamento("Maglietta", "Nike", 19.90, 5),
                new Libro("Impara Python", 29.50, "Luca Bianchi", 1),
                new Elettronico("Mouse Wireless", "Logitech", 0, 15.90, 4)
            };

            double totaleComplessivo = 0;

            foreach (var o in O)
            {
                Console.WriteLine($"Prodotto: {o.Nome} ({o.GetType().Name})");
                Console.WriteLine($"Prezzo base: {o.Prezzo.ToString("F2")} Quantità: {o.Quantità}");

                double prezzoUnit = o.CalcolaPrezzoUnitario();
                double totaleRiga = Math.Round(prezzoUnit * o.Quantità, 2);

                Console.WriteLine($"Prezzo unitario (con IVA/sconti): {prezzoUnit.ToString("F2")} Totale riga: {totaleRiga.ToString("C2")}");
                Console.WriteLine();

                totaleComplessivo += totaleRiga;
            }

            Console.WriteLine($"TOTALE COMPLESSIVO: {totaleComplessivo.ToString("F2")}");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("DIMOSTRAZIONE 'AS' E MODIFICA STATO");
            ApplicaStockAdjustmentUsingAs(O[3], 2);
            
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("PASSAGGIO PER VALORE");
            Oggetto testVal = new Abbigliamento("Test Valore", "TestMarca", 20, 10);
            Console.WriteLine($"Prima di ModificaPerValore: quantità = {testVal.Quantità}");
            ModificaPerValore(testVal);
            Console.WriteLine($"Dopo ModificaPerValore: quantità = {testVal.Quantità}");
            
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("PASSAGGIO PER RIFERIMENTO");
            Oggetto testRef = new Abbigliamento("Test Ref", "TestMarca", 30, 5);
            Console.WriteLine($"Prima di ModificaPerRiferimento: {testRef.Nome}");
            ModificaPerRiferimento(ref testRef);
            Console.WriteLine($"Dopo ModificaPerRiferimento: {testRef.Nome}");
            
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("USO DI OUT");
            double totaleCalcolato;
            CalcolaTotaleRiga(out totaleCalcolato, O[0]);
            Console.WriteLine($"Totale riga calcolato con 'out' per {O[0].Nome}: {totaleCalcolato.ToString("F2")}");
           
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("DIMOSTRAZIONE OVERLOAD");
            Oggetto testOverload = new Libro("Test Overload", 50, "Autore Test", 2);
            Console.WriteLine($"Prezzo normale: {testOverload.CalcolaPrezzoUnitario().ToString("F2")}");
            Console.WriteLine($"Prezzo con sconto 20%: {testOverload.CalcolaPrezzoUnitario(20).ToString("F2")}");

            Console.ReadLine();
        }
    }
}
