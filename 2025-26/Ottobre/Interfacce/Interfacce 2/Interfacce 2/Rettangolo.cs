using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_2
{
    internal class Rettangolo : IFormaGeometrica
    {
        private double lBase, lAltezza;
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

        public Rettangolo(double lBase, double lAltezza)
        {
            Base = lBase;
            Altezza = lAltezza;
        }
        public double CalcolaArea()
        {
            return Base * Altezza;
        }
        public double CalcolaPerimetro()
        {
            return (Base * 2) + (Altezza * 2);
        }
    }
}
