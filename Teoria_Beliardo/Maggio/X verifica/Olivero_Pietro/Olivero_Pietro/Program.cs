using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Olivero_Pietro
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = null;

            while (p == null)
            {
                try
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Cognome: ");
                    string cognome = Console.ReadLine();

                    Console.Write("Età: ");
                    int eta = int.Parse(Console.ReadLine());

                    p = new Persona(nome, cognome, eta);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errore: " + ex.Message);
                    Console.WriteLine("Riprova.\n");
                }
            }

            Console.WriteLine("Dati validi:");
            p.StampaInfo();
            Console.ReadLine();
        }
        
    }

        
}
