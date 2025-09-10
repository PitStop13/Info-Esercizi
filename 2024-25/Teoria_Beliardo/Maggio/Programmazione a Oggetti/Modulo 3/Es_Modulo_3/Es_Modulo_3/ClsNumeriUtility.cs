using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Modulo_3
{
    public static class ClsNumeriUtility
    {
        // Metodo per calcolare il quadrato di un numero
        public static int CalcolaQuadrato(int numero)
        {
            return numero * numero;
        }

        // Metodo per verificare se un numero è pari
        public static bool ÈPari(int numero)
        {
            return numero % 2 == 0;
        }

        // Metodo per verificare se un numero è dispari
        public static bool ÈDispari(int numero)
        {
            return numero % 2 != 0;
        }

        // Metodo per trovare il massimo tra due numeri
        public static int TrovaMassimo(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}
