using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Modulo_2
{
    public class Prodotto
    {
        private string nome;
        private double prezzo;

        // Proprietà Nome
        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Il nome del prodotto non può essere vuoto.");
                else
                {
                    bool nomeValido = true;

                    // Verifica se il nome contiene solo lettere e spazi
                    foreach (char c in value)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            nomeValido = false;
                            break;
                        }
                    }

                    if (!nomeValido)
                        Console.WriteLine("Il nome del prodotto non può contenere numeri o caratteri speciali.");
                    else
                        nome = value;
                }
            }
        }

        // Proprietà Prezzo con validazione
        public double Prezzo
        {
            get { return prezzo; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Il prezzo non può essere negativo.");
                else
                    prezzo = value;
            }
        }

        // Costruttore
        public Prodotto(string nome, double prezzo)
        {
            Nome = nome;   // Imposta il nome
            Prezzo = prezzo; // Imposta il prezzo
        }

        // Metodo per visualizzare i dettagli del prodotto
        public void VisualizzaDettagli()
        {
            Console.WriteLine($"\nDettagli Prodotto:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Prezzo: {Prezzo}$");
        }

        // Metodo per aggiornare il prezzo senza sconto
        public void AggiornaPrezzo(double nuovoPrezzo)
        {
            if (nuovoPrezzo >= 0)
            {
                Prezzo = nuovoPrezzo;
                Console.WriteLine($"Il prezzo è stato aggiornato a: {Prezzo}$");
            }
            else
            {
                Console.WriteLine("Errore: il prezzo non può essere negativo.");
            }
        }

        // Metodo per aggiornare il prezzo con uno sconto
        public void AggiornaPrezzo(double nuovoPrezzo, double scontoPercentuale)
        {
            if (nuovoPrezzo >= 0 && scontoPercentuale >= 0 && scontoPercentuale <= 100)
            {
                double sconto = nuovoPrezzo * (scontoPercentuale / 100);
                Prezzo = nuovoPrezzo - sconto;
                Console.WriteLine($"Il nuovo prezzo con uno sconto del {scontoPercentuale}% è: {Prezzo}$");
            }
            else
            {
                Console.WriteLine("Errore: il prezzo o la percentuale di sconto non sono validi.");
            }
        }
    }
}
