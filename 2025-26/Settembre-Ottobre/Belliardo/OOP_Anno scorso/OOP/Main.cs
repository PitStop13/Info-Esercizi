using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var persone = new List<Persona> {
                new Studente("luca","rossi","4a"),
                new Insegnante("anna","neri","storia")
            };

            foreach(Persona persona in persone)
            {
                persona.saluta();
            }
*/

            Insegnante insegnante1 = new Insegnante("luca", "neri", "matematica");
            Persona insegnante2 = new Insegnante("marco", "neri", "matematica");
            insegnante1.saluta();
            insegnante2.saluta();

        }
    }
}
