using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_2
{
    internal class Triangolo :IFormaGeometrica
    {
        private double lBase, lAltezza,lato1,lato2;
        public double Base
        {
            get => lBase;
            set
            {
                if (value < 0)
                {
                    lBase = 0;
                }
                else lBase = value;

            }
        }

        public double Altezza
        {
            get => lAltezza; set
            {
                if (value < 0)
                {
                    lAltezza = 0;
                }
                else lAltezza = value;
            }
        }

        public double Lato1 { get => lato1; set => lato1 = value; }
        public double Lato2 { get => lato2; set => lato2 = value; }

        public Triangolo(double lBase, double lAltezza, double lato1, double lato2)
        {
            Base = lBase;
            Altezza = lAltezza;
            Lato1 = lato1;
            Lato2 = lato2;
        }
        public double CalcolaArea()
        {
            return (Base * Altezza)/2;
        }
        public double CalcolaPerimetro()
        {
            return Lato1 + Lato2 + Base;
        }
    }
}
