using System;

namespace Palestra
{
    // Classe base astratta per tutti i servizi della palestra
    // Ereditarietà: permette di definire attributi e metodi comuni una sola volta
    public abstract class ServizioPalestra
    {
        // Incapsulamento: proprietà pubbliche con set privato o protetto
        public string Codice { get; set; }
        public string Nome { get; set; }
        public decimal Costo { get; set; }
        public int DurataMinuti { get; set; }

        protected ServizioPalestra(string codice, string nome, decimal costo, int durataMinuti)
        {
            Codice = codice;
            Nome = nome;
            Costo = costo;
            DurataMinuti = durataMinuti;
        }

        // Metodo virtuale: può essere sovrascritto dalle classi derivate (Polimorfismo)
        public virtual string DescrizioneServizio()
        {
            return $"[{Codice}] {Nome} - {Costo:C} ({DurataMinuti} min)";
        }

        public override string ToString()
        {
            return DescrizioneServizio();
        }
    }
}
