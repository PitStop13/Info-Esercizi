using System.Collections.Generic;
using System.Net.Http.Headers;

namespace ThreadKitchen
{
    public class Chef
    {
        // Identificativo numerico del cuoco (0, 1, 2, 3)
        public int Id { get; set; }
        // Nome del cuoco
        public string Name { get; set; }
        // Nome del piatto che sta preparando
        public string Dish { get; set; }
        // Avanzamento da 0 a 100
        public int Progress { get; set; }
        // true quando il piatto e&#39; completato
        public bool IsFinished { get; set; }
        // Tempo totale impiegato in secondi
        public double ElapsedSeconds { get; set; }

        public static List<Chef> GetDefaultChefs()
        {
            return new List<Chef>
            {
                new Chef { Id = 0, Name = "Mario", Dish = "Lasagna" },
            new Chef { Id = 1, Name = "Giulia", Dish = "Risotto ai funghi" },
            new Chef { Id = 2, Name = "Luca", Dish = "Tiramisu" },
            new Chef { Id = 3, Name = "Federica", Dish = "Ossobuco alla milanese" },
            };
        }
    }
}