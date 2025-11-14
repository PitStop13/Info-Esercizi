using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla_verifica
{
    internal class Auto:Veicolo
    {
        private int posti;

        public Auto(string targa, int anno, int posti) : base(targa, anno)
        {
            this.posti = posti;

        }
        public Auto(string targa, int anno) : this(targa, anno,5)
        {
           

        }

        public override double CalcolaTariffa(int giorni)
        {
            double tariffaBase = base.CalcolaTariffa(giorni);
            if (giorni > 7)
            {
                tariffaBase *= 0.9; // 10% di sconto
            }
            return tariffaBase;
        }

        public double CalcolaTariffa(int giorni,bool vip)
        {
            double tariffaBase = CalcolaTariffa(giorni);
            if (vip) tariffaBase *= 0.85; // 15% di sconto aggiuntivo
            return tariffaBase;
        }

        public override string ToString()
        {
            return $"Auto {base.ToString()} Posti = {posti}";
        }
    }
}
