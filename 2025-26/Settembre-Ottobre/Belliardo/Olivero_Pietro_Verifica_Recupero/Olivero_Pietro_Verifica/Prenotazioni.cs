using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro_Verifica
{
    internal class Prenotazioni
    {
        public string Nome { get; set; }
        public Prenotazioni(string nome)
        {
            this.Nome = nome;
        }
        public virtual double CalcolaCostoPrenotazione()
        {
            double costoPrenotazione = 100;
            return costoPrenotazione;
        }
        public override string ToString()
        {
            return $"{Nome}";
        }

    }
}
