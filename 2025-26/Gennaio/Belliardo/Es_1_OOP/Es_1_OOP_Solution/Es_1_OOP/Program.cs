using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_1_OOP
{
    internal class Program
    {
        // Passaggio per valore: NON modifica la variabile originale
        static void SpostaArnia(Arnia a)
        {
            a = new Arnia(999, "NuovaPosizione");
            Console.WriteLine($"Dentro SpostaArnia: riferimento cambiato a id={a.GetId()}");
        }

        // Passaggio per ref: MODIFICA la variabile originale
        static void SostituisciArniaRef(ref Arnia a)
        {
            a = new Arnia(99, "PosizioneConRef");
            Console.WriteLine($"Dentro SostituisciArniaRef: riferimento cambiato a id={a.GetId()}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== GESTIONE ARNIE - ESERCIZIO EREDITARIETÀ ===\n");

            List<Arnia> arnie = new List<Arnia>();

            Arnia arnia1 = new Arnia(1, "SitoA");
            ArniaIntelligente arnia2 = new ArniaIntelligente(2, "SitoB", 85);

            arnie.Add(arnia1);
            arnie.Add(arnia2);

            Console.WriteLine("\n=== TEST AGGIUNTA MIELE E OVERLOAD ===");

            arnia1.AggiungiMiele(2.5);
            arnia2.AggiungiMiele(1.0);
            arnia2.AggiungiMiele(3, true);

            Console.WriteLine("\n=== TEST OPERATORI is E as ===");

            foreach (Arnia arnia in arnie)
            {
                // is: verifica il tipo
                if (arnia is ArniaIntelligente)
                {
                    // as: cast sicuro
                    ArniaIntelligente arniaInt = arnia as ArniaIntelligente;

                    double consumo = 5;
                    arniaInt.DecrementaBatteria(ref consumo);

                    double nuovaBatteria;
                    arniaInt.ResetBatteria(out nuovaBatteria);
                }
            }

            Console.WriteLine("\n=== TEST PASSAGGIO PARAMETRI ===");

            Arnia arniaTest = new Arnia(1, "PosizioneOriginale");
            Console.WriteLine($"Prima di SpostaArnia: id={arniaTest.GetId()}");
            SpostaArnia(arniaTest);
            Console.WriteLine($"Tentativo di sostituire senza ref: la variabile originale rimane id={arniaTest.GetId()}");

            Console.WriteLine();

            Console.WriteLine($"Prima di SostituisciArniaRef: id={arniaTest.GetId()}");
            SostituisciArniaRef(ref arniaTest);
            Console.WriteLine($"Sostituzione con ref: la variabile originale ora è id={arniaTest.GetId()}");

            Console.WriteLine("\n=== FINE ESERCIZIO ===");
            Console.ReadKey();
        }
    }
}

