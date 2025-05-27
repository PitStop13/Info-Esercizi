using System;

namespace PersonaValidazioneSemplice
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

            Console.WriteLine("\nDati validi:");
            p.StampaInfo();
            Console.ReadLine();
        }
    }

    class Persona
    {
        private string nome;
        private string cognome;
        private int eta;

        public Persona(string nome, string cognome, int eta)
        {
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }

        public string Nome  
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || ContieneNumeriOSimboli(value))
                    throw new Exception("Il nome deve contenere solo lettere.");
                nome = value;
            }
        }

        public string Cognome
        {
            get { return cognome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || ContieneNumeriOSimboli(value))
                    throw new Exception("Il cognome deve contenere solo lettere.");
                cognome = value;
            }
        }

        public int Eta
        {
            get { return eta; }
            set
            {
                if (value <= 0)
                    throw new Exception("L'età deve essere maggiore di 0.");
                eta = value;
            }
        }

        public void StampaInfo()
        {
            Console.WriteLine($"{nome} {cognome}, {eta} anni.");
        }

        private bool ContieneNumeriOSimboli(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return true;
            }
            return false;
        }
    }
}
