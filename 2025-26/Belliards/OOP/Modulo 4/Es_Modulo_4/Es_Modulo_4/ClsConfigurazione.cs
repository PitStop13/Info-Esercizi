using System;

namespace Es_Modulo_4
{
    // Classe Singleton che rappresenta una configurazione generale dell'app
    public class ClsConfigurazione
    {
        // Campo privato statico che contiene l'unica istanza (inizialmente null)
        private static ClsConfigurazione istanza = null;

        // Campo privato statico per il blocco (thread-safe, opzionale qui)
        private static readonly object _lock = new object();

        // Costruttore privato: nessuno dall'esterno può creare nuove istanze
        private ClsConfigurazione()
        {
            Console.WriteLine("Costruttore chiamato: configurazione creata.");
        }

        // Proprietà statica per accedere all'unica istanza (Singleton)
        public static ClsConfigurazione Instance
        {
            get
            {
                if (istanza == null)
                {
                    Console.WriteLine("Prima richiesta: creo la configurazione...");
                    istanza = new ClsConfigurazione();
                }
                else
                {
                    Console.WriteLine("Configurazione già esistente, la riuso.");
                }
                return istanza;
            }
        }

        // Proprietà pubbliche per salvare dati di configurazione
        public string Ambiente { get; set; }
        public string Versione { get; set; }

        // Metodo per stampare la configurazione a schermo
        public void Stampa()
        {
            Console.WriteLine($"Ambiente: {Ambiente}");
            Console.WriteLine($"Versione: {Versione}");
        }
    }
}
