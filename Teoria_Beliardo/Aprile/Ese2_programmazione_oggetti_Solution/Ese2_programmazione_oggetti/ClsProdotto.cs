using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese2_programmazione_oggetti
{
    internal class ClsProdotto
    {
        private string nome;
        private double prezzo;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="nome">Nome del prodotto</param>
        /// <param name="prezzo">Prezzo del prodotto</param>
        public ClsProdotto(string nome, double prezzo)
        {
            this.nome = nome;
            this.prezzo = prezzo;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double Prezzo
        {
            get { return prezzo; }
            set { 
                if(prezzo < 0)
                {
                    throw new NumBelowZeroException("Errore: il prezzo deve essere maggiore o uguale a 0!");
                }
                try
                {
                    prezzo = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Errore: un eccezzione di tipo generico è stata lanciata!");
                }
                finally
                {
                    Console.WriteLine("Blocco finally eseguito.");
                }
            }
        }

        private class NumBelowZeroException : Exception
        {
            public NumBelowZeroException(string message) : base(message) { }
        }

        public void AggiornaPrezzo(double nuovoPrezzo)
        {
            if (nuovoPrezzo < 0)
            {
                throw new NumBelowZeroException("Errore: il prezzo deve essere maggiore o uguale a 0!");
            }
            try
            {
                prezzo = nuovoPrezzo;
            }
            catch (Exception)
            {
                Console.WriteLine("Errore: un eccezzione di tipo generico è stata lanciata!");
            }
            finally
            {
                Console.WriteLine($"Il nuovo prezzo è {prezzo}");
            }
        }

        public void AggiornaPrezzo(double nuovoPrezzo, double sconto)
        {
            if (nuovoPrezzo < 0)
            {
                throw new NumBelowZeroException("Errore: il prezzo deve essere maggiore o uguale a 0!");
            }
            if(sconto < 0)
            {
                throw new NumBelowZeroException("Errore: lo sconto deve essere maggiore o uguale a 0!");
            }
            try
            {
                double prezzoFinale = (nuovoPrezzo - (nuovoPrezzo * sconto) / 100);
                prezzo = prezzoFinale;
            }
            catch (Exception)
            {
                Console.WriteLine("Errore: un eccezzione di tipo generico è stata lanciata!");
            }
            finally
            {
                Console.WriteLine($"Il nuovo prezzo con sconto è {prezzo}");
            }
        }
    }
}
