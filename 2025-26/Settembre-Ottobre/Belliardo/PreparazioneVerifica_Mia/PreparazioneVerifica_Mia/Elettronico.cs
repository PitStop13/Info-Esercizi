using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PreparazioneVerifica_Mia
{
    internal class Elettronico : Oggetto
    {
        private int capacità;
        private string marca;

        public int Capacità => capacità;
        public string Marca => marca;
        public int GaranziaAnni { get; private set; }

        public Elettronico(string nome,string marca,int capacita,double prezzo,int anniGaranzia,int quantita) : base(nome,prezzo,quantita)
        {
            this.marca = marca;
            this.capacità = capacita;
            this.GaranziaAnni = anniGaranzia;
        }

        public Elettronico(string nome, string marca, int capacita, double prezzo,  int quantita) : base(nome, prezzo, quantita)
        {
            this.marca = marca;
            this.capacità = capacita;
            this.GaranziaAnni = 0;
        }


        public override double CalcolaPrezzoUnitario()
        {
            //+10% prima iva
            double prezzoPartenza = Prezzo;
            if (GaranziaAnni > 0)
            {
                prezzoPartenza = prezzoPartenza * 1.10;
            }
            double prezzoConIva = prezzoPartenza * 1.22;
            return Math.Round(prezzoConIva,2);
            
        }
        public override string ToString()
        {
            return "Elettronico: " + base.ToString() + $"Marca:{Marca}, Capacità: {Capacità}GB {GaranziaAnni}" ;
        }



    }
}
