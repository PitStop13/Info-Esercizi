using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Es_1_OOP
{
    public class Program
    {
        // Metodo statico che dimostra il passaggio per valore
        public static void SpostaArnia(Arnia a)
        {
            Console.WriteLine("Tentativo di sostituire senza ref: la variabile originale rimane invariata.");
            a = new Arnia(999, "Nuovo Sito"); // Assegna un nuovo oggetto, ma solo alla copia locale
        }

        // Metodo statico che dimostra il passaggio per riferimento con 'ref'
        public static void SostituisciArniaRef(ref Arnia a)
        {
            Console.WriteLine("Sostituzione con ref: la variabile originale ora è id=99.");
            a = new Arnia(99, "Sito Modificato"); // Sostituisce l'oggetto a cui punta il riferimento originale
        }

        public static void Main(string[] args)
        {
            // Parte 1: Creazione e gestione di una lista di arnie
            List<Arnia> apiario = new List<Arnia>();

            // Creazione e aggiunta di oggetti Arnia e ArniaIntelligente
            Arnia arnia1 = new Arnia(1, "SitoA");
            ArniaIntelligente arnia2 = new ArniaIntelligente(2, "SitoB", 85);
            apiario.Add(arnia1);
            apiario.Add(arnia2);

            // Chiamata ai metodi di aggiunta miele
            apiario[0].AggiungiMiele(2.5);
            apiario[1].AggiungiMiele(1.0);
            (apiario[1] as ArniaIntelligente).AggiungiMiele(3, true);

            // Iterazione della lista con 'is' e 'as'
            foreach (Arnia arnia in apiario)
            {
                if (arnia is ArniaIntelligente)
                {
                    Console.WriteLine($"Arnia id={arnia.GetId()} è ArniaIntelligente -> decremento batteria con ref:");
                    ArniaIntelligente arniaIntelligente = arnia as ArniaIntelligente;
                    double consumo = 5.0; // Valore iniziale per il parametro ref
                    Console.WriteLine($"consumo iniziale {consumo}");

                    arniaIntelligente.DecrementaBatteria(ref consumo);
                    Console.WriteLine($"consumo dopo chiamata {consumo}");

                    arniaIntelligente.ResetBatteria(out double nuovaBatteria);
                    Console.WriteLine($"Reset batteria effettuato: nuovaBatteria={nuovaBatteria}");
                }
            }

            // Parte 2: Dimostrazione del passaggio di parametri
            Arnia arniaSpostare = new Arnia(1, "Sito Originale");
            SpostaArnia(arniaSpostare); // Passaggio per valore
            Console.WriteLine($"Dopo SpostaArnia: la variabile originale ha id={arniaSpostare.GetId()}");

            SostituisciArniaRef(ref arniaSpostare); // Passaggio per riferimento
            Console.WriteLine($"Dopo SostituisciArniaRef: la variabile originale ha id={arniaSpostare.GetId()}");
        }
    }
}
