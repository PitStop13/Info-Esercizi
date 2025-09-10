using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro
{
    class Persona
    {
        private string nome;
        private string cognome;
        private int eta;

        public Persona(string nome, string cognome, int eta)
        {
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }

        public string Nome
        {
            get; set;
        }

        public string Cognome
        {
            get; set;
        }

        public int Eta
        {
            get { return eta; }
            set
            {
                if (value <= 0)
                    throw new Exception("L'età deve essere maggiore di 0.");
                eta = value;
            }
        }

        public void StampaInfo()
        {
            Console.WriteLine($"{Nome} {Cognome}, {Eta} anni.");
        }


    }
}
