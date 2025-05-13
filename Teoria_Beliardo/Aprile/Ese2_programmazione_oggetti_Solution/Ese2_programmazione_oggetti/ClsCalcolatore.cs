using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese2_programmazione_oggetti
{
    internal class ClsCalcolatore
    {
        /// <summary>
        /// Somma, fa la somma due numeri di tipo intero
        /// </summary>
        /// <param name="a">Il primo intero da sommare</param>
        /// <param name="b">Il secondo intero da sommare</param>
        /// <returns>Ritorna la somma tra a e b</returns>
        public int Somma (int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Somma, fa la somma due numeri di tipo double
        /// </summary>
        /// <param name="a">Il primo double da sommare</param>
        /// <param name="b">Il secondo double da sommare</param>
        /// <returns>Ritorna la somma tra a e b</returns>
        public double Somma(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Somma, fa la somma di tre numeri di tipo intero
        /// </summary>
        /// <param name="a">Il primo intero da sommare</param>
        /// <param name="b">Il secondo intero da sommare</param>
        /// <param name="c">Il terzo intero da sommare</param>
        /// <returns>Ritorna la somma tra a, b e c</returns>
        public int Somma(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
