using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro_Verifica
{
    internal class Hotel:Prenotazioni
    {
        public int Notti { get; set; }
        private double CostoBaseHotel = 85;

        public Hotel(string nome, int notti) : base(nome)
        {
            this.Notti = notti;
        }
        public Hotel(string nome) : base(nome)
        {
            this.Notti = 1;
        }

        public override double CalcolaCostoPrenotazione()
        {
            double costoTot = CostoBaseHotel *Notti;
            double costoNotti = 3.50 * Notti;
            return Math.Round(costoNotti+costoTot, 2);
        }

        public override string ToString()
        {
           return $"Costo base: {CostoBaseHotel.ToString("F2")} Notti: {Notti}";
        }
    }
}
