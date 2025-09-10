using System;
using System.Linq;

namespace Ese5Pag115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Primo array: 6 squadre ripetute casualmente per un totale di 60 elementi
            string[] squadreBase = { "Juventus", "Milan", "Inter", "Napoli", "Roma", "Lazio" };
            string[] squadre = new string[60];
            Random random = new Random();

            for (int i = 0; i < 60; i++)
            {
                squadre[i] = squadreBase[random.Next(squadreBase.Length)];
            }

            // Secondo array: cognomi dei calciatori (60 elementi unici)
            string[] cognomi = new string[]
            {
            "Buffon", "Totti", "Pirlo", "Maldini", "Baggio", "Del Piero",
            "Cannavaro", "Chiellini", "De Rossi", "Vieri", "Insigne", "Immobile",
            "Chiesa", "Verratti", "Bonucci", "Sirigu", "El Shaarawy", "Marchisio",
            "Inzaghi", "Gattuso", "Nesta", "Zambrotta", "Materazzi", "Toni",
            "Cassano", "Baresi", "Montolivo", "Giaccherini", "Perin", "Palmieri",
            "Jorginho", "Barella", "Locatelli", "Berardi", "Acerbi", "Romagnoli",
            "Sensi", "Bonaventura", "Politano", "Cutrone", "Kean", "Calabria",
            "Belotti", "Bernardeschi", "Tonali", "Zaniolo", "Caputo", "Biraghi",
            "Pessina", "Toloi", "Castrovilli", "Cristante", "Vicario", "Cragno",
            "Gollini", "Mandragora", "Luperto", "Izzo", "Rossi", "Gentile"
            };

            // Terzo array: nomi dei calciatori (60 elementi paralleli ai cognomi)
            string[] nomi = new string[]
            {
            "Gianluigi", "Francesco", "Andrea", "Paolo", "Roberto", "Alessandro",
            "Fabio", "Giorgio", "Daniele", "Christian", "Lorenzo", "Ciro",
            "Federico", "Marco", "Leonardo", "Salvatore", "Stephan", "Claudio",
            "Simone", "Gennaro", "Alessandro", "Gianluca", "Marco", "Luca",
            "Antonio", "Franco", "Riccardo", "Emanuele", "Mattia", "Emerson",
            "Jorge", "Nicolo", "Manuel", "Domenico", "Francesco", "Alessio",
            "Stefano", "Giacomo", "Matteo", "Patrick", "Moise", "Davide",
            "Andrea", "Federico", "Sandro", "Nicolo", "Ciro", "Cristiano",
            "Matteo", "Rafael", "Gaetano", "Bryan", "Guglielmo", "Alessio",
            "Pierluigi", "Rolando", "Sebastiano", "Armando", "Paolo", "Claudio"
            };

            Stampa(squadre, cognomi, nomi, "Dati iniziali (60 elementi):\n");

            string squadra = "";
            do
            {
                Console.Write("\n\nInserisci la squadra: ");
                squadra = Console.ReadLine();
            } while (!squadre.Contains(squadra));

            string[] squadre2 = new string[squadre.Length];
            string[] cognomi2 = new string[cognomi.Length];
            string[] nomi2 = new string[nomi.Length];

            int j = 0;
            for (int i = 0; i < squadre.Length; i++)
            {
                if (squadre[i] == squadra)
                {
                    squadre2[j] = squadre[i];
                    cognomi2[j] = cognomi[i];
                    nomi2[j] = nomi[i];
                    j++;
                }
            }
            Array.Resize(ref squadre2, j);
            Array.Resize(ref cognomi2, j);
            Array.Resize(ref nomi2, j);

            Stampa(squadre2, cognomi2, nomi2, "\nPrima dell'ordinamento:\n");

            Ordina(cognomi2, nomi2);

            Stampa(squadre2, cognomi2, nomi2, "\nDopo l'ordinamento:\n");

            Console.ReadKey();
        }

        private static void Ordina(string[] c, string[] n)
        {
            int i = -1;
            bool scambio;
            do
            {
                i++;
                scambio = false;
                for (int j = c.Length - 2; j >= i; j--)
                {
                    string sPrecedente = c[j] + n[j];
                    string sSuccessiva = c[j + 1] + n[j + 1];
                    if (sSuccessiva.CompareTo(sPrecedente) < 0)
                    {
                        string ausC = c[j];
                        string ausN = n[j];
                        c[j] = c[j + 1];
                        n[j] = n[j + 1];
                        c[j + 1] = ausC;
                        n[j + 1] = ausN;
                        scambio = true;
                    }
                }
            } while (i < c.Length - 2 && scambio);
        }

        private static void Stampa(string[] s, string[] c, string[] n, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {c[i]} {n[i]} - {s[i]}");
            }
        }
    }
}
