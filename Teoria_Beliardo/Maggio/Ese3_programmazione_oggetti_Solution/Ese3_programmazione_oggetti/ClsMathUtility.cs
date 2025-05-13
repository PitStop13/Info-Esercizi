using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese3_programmazione_oggetti
{
    internal static class ClsMathUtility
    {
        /// <summary>
        /// Somma calcola la somma tra due valori
        /// </summary>
        /// <param name="a">Il primo valore passato alla funzione da sommare</param>
        /// <param name="b">Il secondo valore passato alla funzione da sommare</param>
        /// <returns>Ritorna la somma tra a e b</returns>
        public static int Somma(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Media calcola la media dei voti
        /// </summary>
        /// <param name="voti">L'array di double passato alla funzione che contiene tutti i voti</param>
        /// <returns>Ritorna la media dei voti</returns>
        public static double Media(double[] voti)
        {
            double somma = 0;
            for (int i = 0; i < voti.Length; i++)
            {
                somma += voti[i];
            }
            return somma / voti.Length;
        }
    }
}
