using System;

namespace Es_Modulo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Chiediamo i dati per creare un nuovo conto bancario
            Console.Write("Inserisci il numero del conto: ");
            string numeroConto = Console.ReadLine();

            double saldoIniziale = 0;
            bool saldoValido = false;

            while (!saldoValido)
            {
                Console.Write("Inserisci il saldo iniziale: ");
                if (double.TryParse(Console.ReadLine(), out saldoIniziale) && saldoIniziale >= 0)
                {
                    saldoValido = true;
                }
                else
                {
                    Console.WriteLine("Errore: inserisci un valore numerico valido e non negativo.");
                }
            }

            // Creiamo un nuovo conto bancario con i dati inseriti
            ClsEs1.ContoBancario conto1 = new ClsEs1.ContoBancario(numeroConto, saldoIniziale);
            Console.WriteLine($"Conto creato! Numero conto: {conto1.NumeroConto}, Saldo iniziale: {conto1.Saldo} €");

            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\nOperazioni disponibili:");
                Console.WriteLine("1 - Effettua un deposito");
                Console.WriteLine("2 - Effettua un prelievo");
                Console.WriteLine("3 - Visualizza saldo");
                Console.WriteLine("0 - Esci");
                Console.Write("Seleziona un'operazione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": // Deposito
                        Console.Write("Inserisci l'importo da depositare: ");
                        if (double.TryParse(Console.ReadLine(), out double importoDeposito))
                        {
                            conto1.Deposita(importoDeposito);
                            if (importoDeposito > 0)
                            {
                                Console.WriteLine($"Deposito effettuato. Nuovo saldo: {conto1.Saldo} €");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Importo non valido.");
                        }
                        break;

                    case "2": // Prelievo
                        Console.Write("Inserisci l'importo da prelevare: ");
                        if (double.TryParse(Console.ReadLine(), out double importoPrelievo))
                        {
                            double saldoPrecedente = conto1.Saldo;
                            conto1.Preleva(importoPrelievo);
                            if (importoPrelievo > 0 && saldoPrecedente >= importoPrelievo)
                            {
                                Console.WriteLine($"Prelievo effettuato. Nuovo saldo: {conto1.Saldo} €");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Importo non valido.");
                        }
                        break;

                    case "3": // Visualizza saldo
                        Console.WriteLine($"Saldo attuale: {conto1.Saldo} €");
                        break;

                    case "0": // Esci
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }

            // Fine del programma
            Console.WriteLine("\nProgramma terminato. Premi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}