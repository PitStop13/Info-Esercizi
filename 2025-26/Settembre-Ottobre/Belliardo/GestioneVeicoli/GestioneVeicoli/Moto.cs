using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneVeicoli
{
    internal class Moto:Veicolo
    {
        public bool Bagagliaio { get; set; }
        private int costoMoto = 50;

        public Moto(string targa, string modello, int anno, bool bagagliaio, int giorni) : base(targa, modello, anno, giorni)
        {
            this.Bagagliaio = bagagliaio;
        }
        public Moto(string targa, string modello, int anno, int giorni) : base(targa, modello, anno, giorni)
        {
            
        }

        public override double CalcolaCosto()
        {
            double costoBase = costoMoto;
            if (Bagagliaio == true)
            {
                costoBase = costoBase +10;
            }
            return Math.Round(costoBase * 1.05, 2);
        }

        public override string ToString()
        {
            return "Moto" + base.ToString() + $" Bagagliaio = {Bagagliaio},Costo base : {costoMoto}";
        }
    }
}
