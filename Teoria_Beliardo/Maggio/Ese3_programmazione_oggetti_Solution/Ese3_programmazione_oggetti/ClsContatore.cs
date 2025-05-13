using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ese3_programmazione_oggetti
{
    internal class ClsContatore
    {
        // conteggio, variabile di istanza
        public int conteggio;

        // totataleIstanza, variabile statica
        public static int totaleIstanza = 0;

        /// <summary>
        /// Costruttore, inizializza conteggio a 0 e incrementa totaleIstanza
        /// </summary>
        public ClsContatore()
        {
            conteggio = 0;
            totaleIstanza++;
        }

        /// <summary>
        /// ResetTotale, resetta totaleIstanza portandola a 0
        /// </summary>
        public static void ResetTotale()
        {
            totaleIstanza = 0;
        }
    }
}
