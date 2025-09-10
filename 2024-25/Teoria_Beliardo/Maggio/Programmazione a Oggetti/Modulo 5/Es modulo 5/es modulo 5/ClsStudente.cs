using System;

namespace es_modulo_5
{
    // Classe Studente che rappresenta un singolo studente
    public class Studente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Studente(int id, string nome, string cognome)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Cognome: {Cognome}";
        }
    }
}
