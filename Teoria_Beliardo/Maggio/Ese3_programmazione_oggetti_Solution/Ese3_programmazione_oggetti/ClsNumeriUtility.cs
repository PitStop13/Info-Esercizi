using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese3_programmazione_oggetti
{
    internal static class ClsNumeriUtility
    {
        /// <summary>
        /// QuadratoNum calcola il quadrato di un numero
        /// </summary>
        /// <param name="num">Il numero passato alla funzione da elevare al quadrato</param>
        /// <returns>Ritorna il quadrato del numero</returns>
        public static double QuadratoNum(double num)
        {
            return Math.Pow(num, 2);
        }

        /// <summary>
        /// PariODispari ci dice se un numero è pari o dispari
        /// </summary>
        /// <param name="num">Il numero passato alla funzione da controllare</param>
        /// <returns>Ritorna "Pari" se il resto della divisione tra il numero e 2 è 0, 
        /// altrimenti ritorna "Dispari"</returns>
        public static string PariODispari(double num)
        {
            return num % 2 == 0 ? "Pari" : "Dispari";
        }

        /// <summary>
        /// MaxDueNum trova il numero maggiore tra 2 numeri
        /// </summary>
        /// <param name="a">Il primo numero passato alla funzione</param>
        /// <param name="b">Il secondo numero passato alla funzione</param>
        /// <returns>Ritorna una stringa dove che contiene il numero maggiore oppure entrambi se sono uguali</returns>
        public static string MaxDueNum(int a, int b)
        {
            return a > b ? $"Il numero {a} è maggiore" : a == b ? $"I numeri {a} e {b} sono uguali" : $"Il numero {b} è maggiore";
        }
    }
}
