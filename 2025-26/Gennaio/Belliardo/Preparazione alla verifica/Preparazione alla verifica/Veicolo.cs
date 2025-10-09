using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla_verifica
{
    public abstract class Veicolo
    {
        protected string targa;
        private int anno;
        public double Peso { get; protected set; }

        public string Targa => targa;
        public int Anno => anno;

        protected Veicolo(string targa,int anno)
        {
            this.targa = targa;
            this.anno = anno;

        }
        protected Veicolo(string targa, int anno,int peso): this(targa,anno)
        {
            this.Peso = peso;
        }

        public virtual double CalcolaTariffa(int giorni)
        {
            //30euro al giorno
            return 30.0 * giorni;
        }

        public override string ToString()
        {
            return $"Targa={targa} Anno={anno} Peso={Peso:0.##}kg";
        }
    }
}
