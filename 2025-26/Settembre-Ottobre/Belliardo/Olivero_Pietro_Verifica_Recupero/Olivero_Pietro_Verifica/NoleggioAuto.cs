using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro_Verifica
{
    internal class NoleggioAuto : Prenotazioni
    {
        public int Giorni {get;set;}
        private double tariffaAuto = 35;

        public NoleggioAuto(string nome,int giorni):base(nome)
        {
            this.Giorni = giorni;
        }
        public NoleggioAuto(string nome) : base(nome)
        {
            this.Giorni = 1;
        }

        public override double CalcolaCostoPrenotazione()
        {
            double costoTot = tariffaAuto;
            if (Giorni > 7)
            {
                //sconto20%
                costoTot = tariffaAuto * 0.80;
            }
            return Math.Round(costoTot,2);
        }
        public override string ToString()
        {
            if (Giorni > 7)
            {
            return $"Costo base/giorno: {tariffaAuto.ToString("F2")} Giorni: {Giorni} Sconto applicato(20%) ";

            }
            return $"Costo base/giorno: {tariffaAuto.ToString("F2")} Giorni: {Giorni} Sconto applicato(0%)";

        }
    }
}
