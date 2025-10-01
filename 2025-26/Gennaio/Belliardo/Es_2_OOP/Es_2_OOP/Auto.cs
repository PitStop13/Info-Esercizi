using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_2_OOP
{
    public class Auto : Veicolo
    {
        private int posti;

        public Auto(string targa, int anno, int posti) : base(targa, anno)
        {
            this.posti = posti;
        }

        public Auto(string targa, int anno) : this(targa, anno, 5) { }

        public override double CalcolaTariffa(int ore)
        {
            double basePart = base.CalcolaTariffa(ore);
            if (ore > 3)
            {
                double extraOre = ore - 3;
                double scontata = 2.0 * extraOre * 0.8;
                return (2.0 * 3) + scontata;
            }
            return basePart;
        }

        // overload di metodo
        public double CalcolaTariffa(int ore, bool vip)
        {
            double tariffa = CalcolaTariffa(ore);
            if (vip) tariffa *= 0.9;
            return tariffa;
        }

        public override string ToString() => $"Auto {base.ToString()} Posti={posti}";
    }
}
