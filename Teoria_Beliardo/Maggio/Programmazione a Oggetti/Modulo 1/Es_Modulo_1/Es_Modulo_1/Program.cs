using System;

namespace Es_Modulo_1
{
    public class ContoBancario
    {
        // Campi privati
        private string numeroConto;
        private double saldo;

        // Costruttore
        public ContoBancario(string numeroConto, double saldoIniziale)
        {
            this.NumeroConto = numeroConto;
            this.Saldo = saldoIniziale;
        }

        // Proprietà per NumeroConto
        public string NumeroConto
        {
            get { return numeroConto; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    numeroConto = value;
                else
                    Console.WriteLine("Errore: il numero di conto non può essere vuoto.");
            }
        }

        // Proprietà per Saldo
        public double Saldo
        {
            get { return saldo; }
            set
            {
                if (value >= 0)
                    saldo = value;
                else
                    Console.WriteLine("Errore: il saldo non può essere negativo.");
            }
        }

        // Metodo per depositare denaro
        public void Deposita(double importo)
        {
            if (importo > 0)
                saldo += importo;
            else
                Console.WriteLine("Errore: l'importo da depositare deve essere positivo.");
        }

        // Metodo per prelevare denaro
        public void Preleva(double importo)
        {
            if (importo > 0)
            {
                if (saldo - importo >= 0)
                    saldo -= importo;
                else
                    Console.WriteLine("Errore: saldo insufficiente per effettuare il prelievo.");
            }
            else
            {
                Console.WriteLine("Errore: l'importo da prelevare deve essere positivo.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crea un nuovo conto bancario con saldo iniziale
            ContoBancario conto1 = new ContoBancario("IT1234567890", 500);
            Console.WriteLine($"Conto creato! Numero conto: {conto1.NumeroConto}, Saldo iniziale: {conto1.Saldo} $");

            // Deposito di denaro
            Console.WriteLine("\nEffettuando un deposito di 250 $...");
            conto1.Deposita(250);
            Console.WriteLine($"Saldo dopo il deposito: {conto1.Saldo} $");

            // Prelievo di denaro
            Console.WriteLine("\nEffettuando un prelievo di 100 $...");
            conto1.Preleva(100);
            Console.WriteLine($"Saldo dopo il prelievo: {conto1.Saldo} $");

            // Test con importi errati
            Console.WriteLine("\nProviamo a depositare un importo negativo...");
            conto1.Deposita(-50);   // Errore

            Console.WriteLine("\nProviamo a prelevare più di quanto disponibile...");
            conto1.Preleva(1000);   // Errore

            Console.WriteLine("\nProviamo a impostare un saldo negativo...");
            conto1.Saldo = -20;     // Errore

            // Fine del programma
            Console.WriteLine("\nProgramma terminato. Premi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}
