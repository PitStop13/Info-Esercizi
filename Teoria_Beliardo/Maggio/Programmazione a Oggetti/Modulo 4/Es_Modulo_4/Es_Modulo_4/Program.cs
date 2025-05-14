using System;

namespace Es_Modulo_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMO SINGLETON CONFIGURAZIONE ===\n");

            // Ottengo la prima (e unica) istanza
            ClsConfigurazione conf1 = ClsConfigurazione.Instance;

            // Imposto i dati
            conf1.Ambiente = "Sviluppo";
            conf1.Versione = "1.0";

            Console.WriteLine("\nRichiamo la configurazione da un altro oggetto...");

            // Ottengo di nuovo l'istanza (è sempre la stessa!)
            ClsConfigurazione conf2 = ClsConfigurazione.Instance;

            // Stampo i dati: devono essere quelli già impostati prima
            conf2.Stampa();

            // Verifica che siano proprio la stessa istanza (per conferma)
            Console.WriteLine($"\nÈ la stessa istanza? {object.ReferenceEquals(conf1, conf2)}");

            Console.WriteLine("\n=== FINE PROGRAMMA ===");
        }
    }
}
