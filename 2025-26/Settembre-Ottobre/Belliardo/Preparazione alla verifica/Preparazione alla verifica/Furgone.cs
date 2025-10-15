using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla_verifica
{
    internal class Furgone:Veicolo
    {
        private int caricoMax;

        public Furgone(string targa, int anno, int caricoMassimo) : base(targa, anno)
        {
            this.caricoMax = caricoMassimo;

        }
        public Furgone(string targa, int anno,int caricoMassimo,int peso) : base(targa, anno, peso)
        {
            this.caricoMax = caricoMassimo;

        }
        public override double CalcolaTariffa(int giorni)
        {
            double tariffaBase = base.CalcolaTariffa(giorni);
            double coeffPeso = 1.0 + Math.Min(Peso / 1000.0, 1.0) * 0.5; // fino a +50 % in base al peso
            return tariffaBase * coeffPeso;
        }
        public void Carica(ref double pesoCaricato)
        {
            double spazioDisponibile = Math.Max(0, caricoMax - Peso);
            double trasferito = Math.Min(spazioDisponibile, Math.Max(0, pesoCaricato));
            Peso += trasferito;
            pesoCaricato -= trasferito;
        }
        public override string ToString()
        {
            return $"Furgone {base.ToString()} CaricoMax={caricoMax} Peso={Peso:0.##}kg";
        }
    }
}
