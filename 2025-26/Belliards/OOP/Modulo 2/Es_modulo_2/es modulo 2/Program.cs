using System;

namespace Es_Modulo_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Richiediamo all'utente di inserire i dati del prodotto
            Console.WriteLine("Benvenuto nel sistema di gestione dei prodotti!");

            string nome = RichiediNome();
            double prezzo = RichiediPrezzo();

            // Creazione di un prodotto con i dati inseriti dall'utente
            Prodotto prodotto = new Prodotto(nome, prezzo);

            // Visualizza i dettagli del prodotto
            prodotto.VisualizzaDettagli();

            // Permetti all'utente di aggiornare il prezzo
            Console.WriteLine("\nDesideri aggiornare il prezzo del prodotto?");
            Console.WriteLine("1. Aggiorna il prezzo direttamente.");
            Console.WriteLine("2. Aggiorna il prezzo applicando uno sconto.");
            int scelta = Convert.ToInt32(Console.ReadLine());

            if (scelta == 1)
            {
                double nuovoPrezzo = RichiediPrezzo();
                prodotto.AggiornaPrezzo(nuovoPrezzo);
            }
            else if (scelta == 2)
            {
                double nuovoPrezzo = RichiediPrezzo();
                double sconto = RichiediSconto();
                prodotto.AggiornaPrezzo(nuovoPrezzo, sconto);
            }

            // Visualizza di nuovo i dettagli aggiornati del prodotto
            prodotto.VisualizzaDettagli();

            Console.ReadLine();
        }

        // Metodo per richiedere il nome e verificarlo
        static string RichiediNome()
        {
            string nome;
            while (true)
            {
                Console.Write("Inserisci il nome del prodotto: ");
                nome = Console.ReadLine();

                // Controllo che il nome non contenga numeri o caratteri speciali
                if (string.IsNullOrEmpty(nome))
                {
                    Console.WriteLine("Il nome del prodotto non può essere vuoto. Riprova.");
                }
                else
                {
                    bool nomeValido = true;

                    // Verifica se il nome contiene solo lettere e spazi
                    foreach (char c in nome)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            nomeValido = false;
                            break;
                        }
                    }

                    if (!nomeValido)
                    {
                        Console.WriteLine("Il nome del prodotto non può contenere numeri o caratteri speciali. Riprova.");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return nome;
        }

        // Metodo per richiedere il prezzo e verificarlo
        static double RichiediPrezzo()
        {
            double prezzo;
            while (true)
            {
                Console.Write("Inserisci il prezzo del prodotto: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out prezzo) && prezzo >= 0)
                {
                    break;  // Il prezzo è valido
                }
                else
                {
                    Console.WriteLine("Errore: il prezzo deve essere un numero positivo. Riprova.");
                }
            }
            return prezzo;
        }

        // Metodo per richiedere il valore di uno sconto
        static double RichiediSconto()
        {
            double sconto;
            while (true)
            {
                Console.Write("Inserisci la percentuale di sconto (0-100): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out sconto) && sconto >= 0 && sconto <= 100)
                {
                    break;  // Il sconto è valido
                }
                else
                {
                    Console.WriteLine("Errore: la percentuale di sconto deve essere tra 0 e 100. Riprova.");
                }
            }
            return sconto;
        }
    }
}
