using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese3_programmazione_oggetti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Esercizio 3.1
            /* UML classe Contatore
             * +--------------------------------+
             * |         ClsContatore           |
             * +--------------------------------+
             * | + conteggio: int               |
             * | + totaleIstanza: int {static}  |
             * +--------------------------------+
             * | + ClsContatore()               |
             * | + ResetTotale(): void {static} |
             * +--------------------------------+
             */
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("| Esercizio 3.1 (ClsContatore + aggiunta Reset in esercizio A) |");
            Console.WriteLine("----------------------------------------------------------------\n");
            ClsContatore cont1 = new ClsContatore();
            Console.WriteLine($"Aumento il conteggio di totaleIstanza, creando una nuova istanza\nConteggio globale: {ClsContatore.totaleIstanza}\nConteggio locale dell'istanza: {cont1.conteggio}");
            ClsContatore cont2 = new ClsContatore();
            Console.WriteLine($"Aumento il conteggio di totaleIstanza, creando una nuova istanza\nConteggio globale: {ClsContatore.totaleIstanza}\nConteggio locale dell'istanza: {cont1.conteggio}");
            ClsContatore cont3 = new ClsContatore();
            Console.WriteLine($"Aumento il conteggio di totaleIstanza, creando una nuova istanza\nConteggio globale: {ClsContatore.totaleIstanza}\nConteggio locale dell'istanza: {cont1.conteggio}");
            // Esercizio A
            Console.WriteLine("\nEse A)Faccio un reset della variabile totaleIstanza, quindi la riporto a 0");
            ClsContatore.ResetTotale();
            ClsContatore cont4 = new ClsContatore();
            Console.WriteLine($"Aumento il conteggio di totaleIstanza, creando una nuova istanza\nConteggio globale: {ClsContatore.totaleIstanza}\nConteggio locale dell'istanza: {cont1.conteggio}");
            ClsContatore cont5 = new ClsContatore();
            Console.WriteLine($"Aumento il conteggio di totaleIstanza, creando una nuova istanza\nConteggio globale: {ClsContatore.totaleIstanza}\nConteggio locale dell'istanza: {cont1.conteggio}");
            // Esercizio 3.2
            // Esercizio C
            /* UML classe Configurazione
             * +---------------------------------+
             * |         ClsConfigurazione       |
             * +---------------------------------+
             * | + impostazioni: string {static} |
             * +---------------------------------+
             * | ClsConfigurazioni(): {static}   |
             * +---------------------------------+
             */
            Console.WriteLine("\n-----------------------------------------------------");
            Console.WriteLine("| Esercizio 3.2 (ClsConfigurazione, ClsMathUtility) |");
            Console.WriteLine("-----------------------------------------------------\n");
            Console.WriteLine(ClsConfigurazione.impostazioni);
            // Esercizio C
            /* UML classe MathUtility
             * +-----------------------------------------+
             * |               ClsMathUtility            |
             * +-----------------------------------------+
             * | + Somma(int a, int b): int {static}     |
             * | + Media(double[] voti): double {static} |
             * +-----------------------------------------+
             */
            Console.WriteLine($"somma1: 5 + 8 = {ClsMathUtility.Somma(5, 8)}");
            double[] voti1 = { 5, 6, 7, 4, 2, 8, 10 };
            Console.WriteLine($"media1: ({voti1[0]} + {voti1[1]} + {voti1[2]} + {voti1[3]} + {voti1[4]} + {voti1[5]} + {voti1[6]}) / {voti1.Length} = {ClsMathUtility.Media(voti1)}");
            Console.WriteLine($"somma1: 100 + 56784 = {ClsMathUtility.Somma(100, 56784)}");
            double[] voti2 = { 4, 5, 6, 3.33, 5.5, 6.7, 3.2, 6, 5, 10 };
            Console.WriteLine($"media1: ({voti2[0]} + {voti2[1]} + {voti2[2]} + {voti2[3]} + {voti2[4]} + {voti2[5]} + {voti2[6]} + {voti2[7]} + {voti2[8]} + {voti2[9]}) / {voti2.Length} = {ClsMathUtility.Media(voti2).ToString("N02")}");
            // Esercizio B
            /* UML classe NumeriUtility
             * +---------------------------------------------+
             * |              ClsNumeriUtility               |
             * +---------------------------------------------+
             * | + QuadratoNum(double num): double {static}  |
             * | + PariODispari(double num): string {static} |
             * | + MaxDueNum(int a, int b): string {static}  |
             * +---------------------------------------------+
             */
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("| Esercizio B (ClsNumeriUtility) |");
            Console.WriteLine("----------------------------------\n");
            Console.WriteLine($"Quadrato di 2 (2 * 2): {ClsNumeriUtility.QuadratoNum(2)}");
            Console.WriteLine($"Quadrato di 4,56 (4,56 * 4,56): {ClsNumeriUtility.QuadratoNum(4.56).ToString("N02")}");
            Console.WriteLine($"Pari o dispari numero 200: {ClsNumeriUtility.PariODispari(200)}");
            Console.WriteLine($"Pari o dispari numero 20,5: {ClsNumeriUtility.PariODispari(20.5)}");
            Console.WriteLine($"Numero maggiore tra 2 e 200: {ClsNumeriUtility.MaxDueNum(2, 200)}");
            Console.WriteLine($"Numero maggiore tra 13 e 11: {ClsNumeriUtility.MaxDueNum(13, 11)}");
            Console.WriteLine($"Numero maggiore tra 0 e 0: {ClsNumeriUtility.MaxDueNum(0, 0)}");
            Console.WriteLine($"Numero maggiore tra -4 e -36: {ClsNumeriUtility.MaxDueNum(-4, -36)}");
            Console.ReadKey();
        }
    }
}
