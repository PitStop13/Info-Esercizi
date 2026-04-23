using System.Collections.Generic;

namespace ThreadKitchen
{
    /// <summary>
    /// Rappresenta un cuoco con il suo stato di avanzamento nella preparazione del piatto.
    /// </summary>
    public class Chef
    {
        /// <summary>Identificativo univoco del cuoco (0-3).</summary>
        public int Id { get; set; }

        /// <summary>Nome del cuoco.</summary>
        public string Name { get; set; }

        /// <summary>Nome del piatto che il cuoco sta preparando.</summary>
        public string Dish { get; set; }

        /// <summary>Avanzamento della preparazione (0-100).</summary>
        public int Progress { get; set; }

        /// <summary>Indica se il cuoco ha terminato la preparazione.</summary>
        public bool IsFinished { get; set; }

        /// <summary>Secondi trascorsi dall'inizio della preparazione.</summary>
        public double ElapsedSeconds { get; set; }

        /// <summary>
        /// Restituisce la lista dei 4 cuochi predefiniti con nomi e piatti italiani.
        /// </summary>
        public static List<Chef> GetDefaultChefs()
        {
            return new List<Chef>
            {
                new Chef { Id = 0, Name = "Mario",     Dish = "Lasagna",           Progress = 0, IsFinished = false, ElapsedSeconds = 0 },
                new Chef { Id = 1, Name = "Giulia",    Dish = "Risotto ai funghi", Progress = 0, IsFinished = false, ElapsedSeconds = 0 },
                new Chef { Id = 2, Name = "Lorenzo",   Dish = "Ossobuco",          Progress = 0, IsFinished = false, ElapsedSeconds = 0 },
                new Chef { Id = 3, Name = "Francesca", Dish = "Tiramisù",          Progress = 0, IsFinished = false, ElapsedSeconds = 0 },
            };
        }
    }
}