using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_2_OOP
{
    public abstract class Veicolo
    {
        protected string targa;
        private int anno;
        public double Peso { get; protected set; }

        public string Targa { get { return targa; } }
        public int Anno => anno;

        protected Veicolo(string targa, int anno)
        {
            this.targa = targa;
            this.anno = anno;
            this.Peso = 0;
        }

        protected Veicolo(string targa, int anno, double peso)
        {
            this.targa = targa;
            this.anno = anno;
            this.Peso = peso;
        }

        public virtual double CalcolaTariffa(int ore) => 2.0 * ore;

        public override string ToString() => $"Targa={targa} Anno={anno}";
    }
}
