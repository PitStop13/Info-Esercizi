using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestioneVeicoli
{
    internal class Furgone : Veicolo
    {
        public int Posti { get; set; }
        private int costoFurgone = 80;

        public Furgone(string targa, string modello, int anno, int posti, int giorni) : base(targa , modello, anno,giorni)
        {
            this.Posti = posti;
        }
        public Furgone(string targa, string modello, int anno,  int giorni) : base(targa, modello, anno, giorni)
        {
        }

        public override double CalcolaCosto()
        {
            double costoBase = costoFurgone;
            if (Giorni >= 3)
            {
                costoBase = costoBase * 0.80;
            } 
            return Math.Round(costoBase*1.10,2);
        }
        public override string ToString()
        {
            return "Furgone" + base.ToString() + $" ,Posti = {Posti},Costo base : {costoFurgone}";
        }
    }
}
