using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneVeicoli
{
    internal class Veicolo
    {
        public string Targa {get;set;}
        public string Modello {get;set;}

        public int Anno { get; set; }

        public int Giorni { get; set; }


        public Veicolo(string targa, string modello, int anno)
        {
            this.Targa = targa;
            this.Modello = modello;
            this.Anno = anno;
            this.Giorni = 0;
        }
        public Veicolo(string targa, string modello, int anno,int giorni)
        {
            this.Targa = targa;
            this.Modello = modello;
            this.Anno = anno;
            this.Giorni = giorni;
        }

        public virtual double CalcolaCosto()
        {
            double costoTotale = Giorni * 100;
            return Math.Round(costoTotale,2);
        }
        public virtual double CalcolaCosto(double sconto)
        {
            double costoTotale = Giorni * 100;
            return Math.Round(costoTotale * (1 - sconto / 100), 2);
        }

        public override string ToString()
        {
            return $"Targa: {Targa}, Modello: {Modello}, Anno: {Anno}, Durata giori del noleggio: {Giorni}";
        }
    }
}
