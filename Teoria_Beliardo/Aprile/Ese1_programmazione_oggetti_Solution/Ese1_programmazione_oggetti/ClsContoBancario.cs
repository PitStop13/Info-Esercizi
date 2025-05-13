using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese1_programmazione_oggetti
{
    internal class ClsContoBancario
    {
        // Esercizio B
        private string numeroConto;
        private double saldo;

        /// <summary>
        /// Costruttore, assegna alla variabili private il valore passato al costruttore
        /// </summary>
        /// <param name="numeroConto">Numero conto</param>
        /// <param name="saldo">Saldo del conto</param>
        public ClsContoBancario (string numeroConto, double saldo)
        {
            this.numeroConto = numeroConto;
            this.saldo = saldo;
        }

        /// <summary>
        /// NumeroConto, ritorna la variabile private "numeroConto" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value != "" || value != null)
        /// </summary>
        public string NumeroConto
        {
            get { return numeroConto; }
            //set { numeroConto = value; }
            // Esercizio C
            set
            {
                while (value != "" || value != null)
                {
                    Console.WriteLine("Inserisci un numero conto valido:");
                    value = Console.ReadLine();
                }
                numeroConto = value;
            }
        }
        
        /// <summary>
        /// Saldo, ritorna la variabile private "saldoo" dopo che essa è stata validata 
        /// secondo i criteri di validazione impostati (value >= 0)
        /// </summary>
        public double Saldo
        {
            get { return saldo; }
            /*set {
                if (value >= 0)
                    saldo = value;
                else
                    Console.WriteLine("Errore: il saldo deve essere maggiore di 0.");
            }*/
            // Esercizio C
            set
            {
                while (value < 0)
                {
                    Console.WriteLine("Inserisci un saldo valido:");
                    value = Convert.ToDouble(Console.ReadLine());
                }
                saldo = value;
            }
        }

        /// <summary>
        /// Deposita, aggiunge al saldo un importo, dopo che esso è stato validato 
        /// secondo i criteri di validazione impostati (importo > 0)
        /// </summary>
        /// <param name="importo">L'importo da aggiungere al saldo</param>
        public void Deposita (double importo)
        {
            /*if(importo > 0)
                saldo += importo;
            else
                Console.WriteLine("Errore: il saldo e l'importo devono essere maggiori di 0.");*/
            // Esercizio C
            while (importo <= 0)
            {
                Console.WriteLine("Inserisci un'importo valido:");
                importo = Convert.ToDouble(Console.ReadLine());
            }
            saldo += importo;
        }

        /// <summary>
        /// Preleva, sottrae al saldo un importo, dopo che esso è stato validato 
        /// secondo i criteri di validazione impostati (importo > 0 || (saldo - importo) >= 0)
        /// </summary>
        /// <param name="importo">L'importo da sottrarre al saldo</param>
        public void Preleva (double importo)
        {
            /*if((saldo - importo) >= 0 || importo > 0)
                saldo -= importo;
            else
                Console.WriteLine("Errore: il saldo e l'importo devono essere maggiori di 0.");*/
            // Esercizio C
            while ((saldo - importo) < 0 || importo <= 0)
            {
                Console.WriteLine("Inserisci un'importo valido:");
                importo = Convert.ToDouble(Console.ReadLine());
            }
            saldo -= importo;
        }
    }
}
