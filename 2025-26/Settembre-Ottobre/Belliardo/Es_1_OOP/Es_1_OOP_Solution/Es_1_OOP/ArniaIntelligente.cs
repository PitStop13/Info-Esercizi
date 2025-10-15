using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_1_OOP
{
    public class ArniaIntelligente : Arnia
    {
        private double batteria;

        public ArniaIntelligente(int id) : base(id)
        {
            this.batteria = 100;
        }

        public ArniaIntelligente(int id, string posizione, double batteria) : base(id, posizione)
        {
            this.batteria = batteria;
            Console.WriteLine($"Creata ArniaIntelligente id={id} posizione={posizione} batteria={batteria}");
        }

        // Override: chiama base e aggiunge logging
        public override void AggiungiMiele(double kg)
        {
            base.AggiungiMiele(kg);
            Console.WriteLine($"[LOG] ArniaIntelligente id={GetId()}: operazione registrata nel sistema");
        }

        // Overload: stesso nome, parametri diversi
        public void AggiungiMiele(int kg, bool urgente)
        {
            Console.WriteLine($"Aggiunto {kg} kg (int, urgente={urgente}) a ArniaIntelligente id={GetId()}");
            AggiungiMiele((double)kg);
        }

        protected void RiportaStatoBatteria()
        {
            Console.WriteLine($"Stato batteria ArniaIntelligente id={GetId()}: {batteria}%");
        }

        // Parametro ref: modifica la variabile originale
        public void DecrementaBatteria(ref double consumo)
        {
            Console.WriteLine($"Arnia id={GetId()} è ArniaIntelligente -> decremento batteria con ref: consumo iniziale {consumo}");
            batteria -= consumo;
            consumo = consumo - 2;
            Console.WriteLine($"Batteria dopo decremento: {batteria}%, consumo dopo chiamata {consumo}");
        }

        // Parametro out: restituisce un valore
        public void ResetBatteria(out double nuovaBatteria)
        {
            batteria = 100;
            nuovaBatteria = batteria;
            Console.WriteLine($"Reset batteria effettuato: nuovaBatteria={nuovaBatteria}");
        }
    }
}
