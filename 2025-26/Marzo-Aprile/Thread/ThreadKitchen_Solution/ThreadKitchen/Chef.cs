using System.Collections.Generic;
using System.Net.Http.Headers;

namespace ThreadKitchen
{
    public class Chef
    {
        /// <summary> Identificativo numerico del cuoco (0, 1, 2, 3) </summary>
        public int Id { get; set; }

        /// <summary> Nome del cuoco </summary>
        public string Name { get; set; }

        /// <summary> Nome del piatto che sta preparando </summary>
        public string Dish { get; set; }

        /// <summary> Avanzamento da 0 a 100 </summary>
        public int Progress { get; set; }

        /// <summary> true quando il piatto è completato </summary>
        public bool IsFinished { get; set; }

        /// <summary> Tempo totale impiegato in secondi </summary>
        public double ElapsedSeconds { get; set; }

        /// <summary> true quando il cuoco sta uitlizzando un fornello </summary>
        public bool isUsingFornello { get; set; }

        /// <summary>
        /// Restitusice 4 cucochi predefiniti con nomi e piatti italiani
        /// </summary>
        /// <returns></returns>
        public static List<Chef> GetDefaultChefs()
        {
            return new List<Chef>
            {
                new Chef { Id = 0, Name = "Mario", Dish = "Lasagna", Progress = 0, IsFinished = false, isUsingFornello = false },
                new Chef { Id = 1, Name = "Giulia", Dish = "Risotto ai funghi", Progress = 0, IsFinished = false, isUsingFornello = false },
                new Chef { Id = 2, Name = "Luca", Dish = "Tiramisu", Progress = 0, IsFinished = false, isUsingFornello = false },
                new Chef { Id = 3, Name = "Federica", Dish = "Ossobuco alla milanese", Progress = 0, IsFinished = false, isUsingFornello = false },
            };
        }
    }
}