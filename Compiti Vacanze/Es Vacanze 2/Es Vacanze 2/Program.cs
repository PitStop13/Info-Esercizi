using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Vacanze_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il numero di righe (M): ");
            int M = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il numero di colonne (N): ");
            int N = int.Parse(Console.ReadLine());

            int[,] matrice = new int[M, N];

            // Lista per valori
            List<int> valoriUsati = new List<int>();

            Console.WriteLine("\nInserisci i valori della matrice (tutti diversi tra loro):");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int valore;
                    bool valido;

                    do
                    {
                        Console.Write($"Elemento [{i},{j}]: ");
                        valido = int.TryParse(Console.ReadLine(), out valore);

                        if (!valido)
                        {
                            Console.WriteLine("Valore non valido. Inserisci un numero intero.");
                        }
                        else if (valoriUsati.Contains(valore))
                        {
                            Console.WriteLine("Valore già inserito. Inserisci un numero diverso.");
                            valido = false;
                        }

                    } while (!valido);

                    matrice[i, j] = valore;
                    valoriUsati.Add(valore);
                }
            }

            int minimo = matrice[0, 0];
            int massimo = matrice[0, 0];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrice[i, j] < minimo)
                        minimo = matrice[i, j];

                    if (matrice[i, j] > massimo)
                        massimo = matrice[i, j];
                }
            }

            Console.WriteLine($"\nValore minimo assoluto: {minimo}");
            Console.WriteLine($"Valore massimo assoluto: {massimo}");

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}
