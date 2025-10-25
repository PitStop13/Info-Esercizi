using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro_Verifica
{
    internal class Volo:Prenotazioni
    {
        public int Bagagli { get; set; }
        private double CostoBaseVolo = 120;
        
        public Volo(string nome, int bagagli) : base(nome)
        {
            this.Bagagli = bagagli;
        }
        public Volo(string nome) : base(nome)
        {
            this.Bagagli = 0;
        }

        public override double CalcolaCostoPrenotazione()
        {
            double costoTot = CostoBaseVolo;
            double costoBagagli=0;
            if (Bagagli > 0)
            {
                //aumento 25euro a bagaglio
                costoBagagli = 25;
                costoBagagli = costoBagagli * Bagagli;
            }
            return Math.Round((costoTot+costoBagagli)*1.08,2);
        }

        public override string ToString()
        {
            if (Bagagli >= 1)
            {
            return $"Costo base: {CostoBaseVolo.ToString("F2")} Bagagli: {Bagagli} Supplemento bagaglio: {(25.00*Bagagli).ToString("F2")}$ Tassa aereoportuale: {CostoBaseVolo*0.20}";

            }
            else
            {
                return $"Costo base: {CostoBaseVolo.ToString("F2")} Bagagli: {Bagagli} Supplemento bagaglio: 00.00$ Tassa aereoportuale: {CostoBaseVolo * 0.20}";

            }
        }
    }
}
