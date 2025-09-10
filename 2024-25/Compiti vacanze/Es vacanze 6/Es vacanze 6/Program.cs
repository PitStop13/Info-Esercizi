using System;
using System.IO;

namespace Es_vacanze_6
{
    internal class Program
    {
        struct Materia
        {
            public string nome;
            public int orale;
            public int scritto;
            public int pratico;

            public double Media()
            {
                return (orale + scritto + pratico) / 3.0;
            }

            public override string ToString()
            {
                return $"{nome};{orale};{scritto};{pratico}";
            }

            public static Materia FromString(string riga)
            {
                string[] campi = riga.Split(';');
                return new Materia
                {
                    nome = campi[0],
                    orale = int.Parse(campi[1]),
                    scritto = int.Parse(campi[2]),
                    pratico = int.Parse(campi[3])
                };
            }
        }

        static string fileMaterie = "materie.txt";
        static string fileVoti = "voti.txt";

        static void Main(string[] args)
        {
            Materia[] materie = new Materia[8];
            bool materieInserite = File.Exists(fileMaterie);
            bool votiInseriti = File.Exists(fileVoti);

            if (materieInserite)
            {
                string[] righe = File.ReadAllLines(fileMaterie);
                for (int i = 0; i < righe.Length && i < materie.Length; i++)
                {
                    materie[i].nome = righe[i];
                }
            }

            if (votiInseriti)
            {
                string[] righe = File.ReadAllLines(fileVoti);
                for (int i = 0; i < righe.Length && i < materie.Length; i++)
                {
                    materie[i] = Materia.FromString(righe[i]);
                }
            }

            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Esci");
                Console.WriteLine("2. Carica le materie");
                Console.WriteLine("3. Carica i voti");
                Console.WriteLine("4. Visualizza la media della materia X");
                Console.WriteLine("5. Visualizza la media totale");
                Console.WriteLine("6. Visualizza le medie in ordine crescente, il minimo e il massimo");
                Console.Write("\nScegli un'opzione: ");

                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Scelta non valida. Premi un tasto per continuare...");
                    Console.ReadKey();
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Uscita dal programma...");
                        break;

                    case 2:
                        Console.WriteLine("\nInserisci i nomi delle 8 materie:");
                        for (int i = 0; i < materie.Length; i++)
                        {
                            Console.Write($"Materia {i + 1}: ");
                            materie[i].nome = Console.ReadLine();
                        }
                        File.WriteAllLines(fileMaterie, Array.ConvertAll(materie, m => m.nome));
                        materieInserite = true;
                        votiInseriti = false;
                        break;

                    case 3:
                        if (!materieInserite)
                        {
                            Console.WriteLine("Devi prima caricare le materie! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("\nInserisci i voti (orale, scritto, pratico) per ogni materia:");
                        for (int i = 0; i < materie.Length; i++)
                        {
                            Console.WriteLine($"\nMateria: {materie[i].nome}");

                            materie[i].orale = LeggiVoto("Orale");
                            materie[i].scritto = LeggiVoto("Scritto");
                            materie[i].pratico = LeggiVoto("Pratico");
                        }
                        File.WriteAllLines(fileVoti, Array.ConvertAll(materie, m => m.ToString()));
                        votiInseriti = true;
                        break;

                    case 4:
                        if (!materieInserite || !votiInseriti)
                        {
                            Console.WriteLine("Devi prima caricare materie e voti! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("\nInserisci il nome della materia di cui vuoi la media: ");
                        string materiaCercata = Console.ReadLine();
                        bool trovata = false;

                        foreach (var m in materie)
                        {
                            if (m.nome.Equals(materiaCercata.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Media di {m.nome}: {m.Media():F2}");
                                trovata = true;
                                break;
                            }
                        }

                        if (!trovata)
                            Console.WriteLine("Materia non trovata.");

                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;

                    case 5:
                        if (!materieInserite || !votiInseriti)
                        {
                            Console.WriteLine("Devi prima caricare materie e voti! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        double sommaTot = 0;
                        foreach (var m in materie)
                        {
                            sommaTot += m.Media();
                        }

                        double mediaTotale = sommaTot / materie.Length;
                        Console.WriteLine($"\nMedia totale dello studente: {mediaTotale:F2}");

                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;

                    case 6:
                        
                        if (!materieInserite || !votiInseriti)
                        {
                            Console.WriteLine("Devi prima caricare materie e voti! Premi un tasto...");
                            Console.ReadKey();
                            break;
                        }

                        Materia[] ordinate = new Materia[materie.Length];
                        for (int i = 0; i < materie.Length; i++)
                            ordinate[i] = materie[i];

                        for (int i = 0; i < ordinate.Length - 1; i++)
                        {
                            for (int j = i + 1; j < ordinate.Length; j++)
                            {
                                if (ordinate[i].Media() > ordinate[j].Media())
                                {
                                    Materia temp = ordinate[i];
                                    ordinate[i] = ordinate[j];
                                    ordinate[j] = temp;
                                }
                            }
                        }

                        Console.WriteLine("\nMedie in ordine crescente:");
                        foreach (var m in ordinate)
                        {
                            Console.WriteLine($"{m.nome}: {m.Media():F2}");
                        }

                        Console.WriteLine($"\nMateria con media più bassa: {ordinate[0].nome} ({ordinate[0].Media():F2})");
                        Console.WriteLine($"Materia con media più alta: {ordinate[ordinate.Length - 1].nome} ({ordinate[ordinate.Length - 1].Media():F2})");

                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }

            } while (scelta != 1);
        }

        static int LeggiVoto(string tipo)
        {
            int voto;
            do
            {
                Console.Write($"Voto {tipo} (1-10): ");
            } while (!int.TryParse(Console.ReadLine(), out voto) || voto < 1 || voto > 10);

            return voto;
        }
    }

}
