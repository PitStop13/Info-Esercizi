using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void cambia( Oggetto v)
            {
                Console.WriteLine(  v);
            }
            void cambiaRef(ref v)
            {

                Console.WriteLine(v);
            }

            var O = new List<Oggetto> {

               new Abbigliamento("Giacca", "Gucci", 24.90,3),
               new Elettronico("Hard Disk", "SanDisk", 1,59.99,2),
               new Libro("Ciao", 20.50,2002 ,"Luca",12),
            };

           
            foreach (var o in O)
            {
                //stampo tutti i dati dei vari oggetti cmpreso prezzo unitFinal
                Console.WriteLine(o);
                if (o is Abbigliamento)
                {
                    Abbigliamento a = o as  Abbigliamento;
                    a.calcolaPrezzo();
                }
                else if(o is Elettronico)
                {
                    Elettronico e = o as Elettronico;
                    e.calcolaPrezzo();
                }
                else if (o is Libro)
                {
                    Libro l = o as Libro;
                    l.calcolaPrezzo();
                }
            }

            Oggetto v = new Abbigliamento("Maglia", "Polo", 24.90, 3);
            cambia(v);
            Oggetto v1 = new Abbigliamento("Gonna", "Gucci", 24.90, 3);
            cambiaRef(ref v1);
            Console.ReadLine();
            

        }
    }
}
