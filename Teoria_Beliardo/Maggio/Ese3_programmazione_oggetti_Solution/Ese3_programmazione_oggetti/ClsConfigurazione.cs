using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese3_programmazione_oggetti
{
    internal class ClsConfigurazione
    {
        //impostazioni, variabile statica
        public static string impostazioni { get; private set; }

        /// <summary>
        /// Costruttore statico, dove viene inizializzata la variabile impostazioni
        /// </summary>
        static ClsConfigurazione()
        {
            impostazioni = "Configurazione iniziale";
        }
    }
}
