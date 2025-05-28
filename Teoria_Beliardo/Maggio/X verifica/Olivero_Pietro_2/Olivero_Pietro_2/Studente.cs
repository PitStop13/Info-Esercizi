using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro_2
{
    public class Studente
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public int Eta { get; private set; }

        public Studente(string nome, string cognome, int eta)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cognome) || eta <= 0)
                throw new ArgumentException("Dati non validi");
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }

        public void Modifica(string nome, string cognome, int eta)
        {
            if (!string.IsNullOrWhiteSpace(nome)) Nome = nome;
            if (!string.IsNullOrWhiteSpace(cognome)) Cognome = cognome;
            if (eta > 0) Eta = eta;
        }

        public override string ToString() => $"{Nome} {Cognome}, Età: {Eta}";
    }
}
