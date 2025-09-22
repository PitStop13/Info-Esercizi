using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_1_OOP
{
    public class Arnia
    {
        private int id;
        protected string posizione;
        public double quantitaMiele { get; private set; }

        public Arnia(int id)
        {
            this.id = id;
            this.posizione = "Sconosciuta";
            this.quantitaMiele = 0;
            Console.WriteLine($"Creata Arnia id={id} posizione={posizione} miele={quantitaMiele}");
        }

        public Arnia(int id, string posizione)
        {
            this.id = id;
            this.posizione = posizione;
            this.quantitaMiele = 0;
            Console.WriteLine($"Creata Arnia id={id} posizione={posizione} miele={quantitaMiele}");
        }

        public virtual void AggiungiMiele(double kg)
        {
            if (kg < 0)
                throw new ArgumentException("Il miele non può essere negativo");

            quantitaMiele += kg;
            Console.WriteLine($"Aggiunto {kg} kg a Arnia id={id} -> totale {quantitaMiele}");
        }

        public string GetPosizione()
        {
            return posizione;
        }

        public int GetId()
        {
            return id;
        }
    }
}
