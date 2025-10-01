using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_2_OOP
{
    public class Furgone : Veicolo
    {
        private double caricoMax;

        public Furgone(string targa, int anno, double caricoMax) : base(targa, anno)
        {
            this.caricoMax = caricoMax;
        }

        public Furgone(string targa, int anno, double caricoMax, double peso)
            : base(targa, anno, peso)
        {
            this.caricoMax = caricoMax;
        }

        public override double CalcolaTariffa(int ore)
        {
            double baseTariffa = base.CalcolaTariffa(ore);
            double coeffPeso = 1.0 + Math.Min(Peso / 1000.0, 1.0) * 0.5;
            return baseTariffa * coeffPeso;
        }

        // passaggio per ref
        public void Carica(ref double pesoCaricato)
        {
            double spazioDisponibile = Math.Max(0, caricoMax - Peso);
            double trasferito = Math.Min(spazioDisponibile, Math.Max(0, pesoCaricato));
            Peso += trasferito;
            pesoCaricato -= trasferito;
        }

        public override string ToString() => $"Furgone {base.ToString()} CaricoMax={caricoMax} Peso={Peso:0.##}kg";
    }
}

