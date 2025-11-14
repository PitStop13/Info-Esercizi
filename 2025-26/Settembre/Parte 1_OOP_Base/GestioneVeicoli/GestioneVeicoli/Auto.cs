using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneVeicoli
{
    internal class Auto:Veicolo
    {
        public int Cilindrata { get; set; }
        private int costoAuto = 35;

        public Auto(string targa, string modello, int anno, int cilindrata, int giorni) : base(targa, modello, anno, giorni)
        {
            this.Cilindrata = cilindrata;
        }
        public Auto(string targa, string modello, int anno, int giorni) : base(targa, modello, anno, giorni)
        {
            
        }

        public override double CalcolaCosto()
        {
            double costoBase = costoAuto;
            if (Cilindrata > 2000)
            {
                costoBase = costoBase * 1.15;
            }
            return Math.Round(costoBase*1.08, 2);
        }
        public override string ToString()
        {
            return "Auto" + base.ToString() + $" ,Cilindrata = {Cilindrata},Costo base : {costoAuto}";
        }
    }
}
