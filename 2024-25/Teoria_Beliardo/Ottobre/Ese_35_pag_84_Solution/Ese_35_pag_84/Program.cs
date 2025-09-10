using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_35_pag_84
{
    internal class Program
    {
        static int[,] mat=new int[5, 5];
        static void Main(string[] args)
        {
            int i, j;
            caricaMat(mat);
            stampaMat(mat);
            i = leggiNumero($"Inserisci la riga: ", 1, 5);
            j = leggiNumero($"Inserisci la colonna: ", 1, 5);
            if (sommaNumeri(mat,i-1, "r") == sommaNumeri(mat,j-1, "c"))
                Console.WriteLine("La somma dei numeri sulla riga inserita è uguale alla somma dei numeri sulla colonna!");
            else
                Console.WriteLine("La somma dei numeri su riga e colonna è diversi!");
            Console.ReadKey();
        }

        private static int sommaNumeri(int[,] mat, int n, string direzione)
        {
            int somma = 0;
            if(direzione.ToUpper() == "R") //(direzione == "R" || direzione == "r")
            {
                for(int i = 0; i < mat.GetLength(1); i++)
                {
                    somma += mat[n, i];
                }
            }
            else
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    somma += mat[i, n];
                }
            }
            return somma;
        }

        private static void stampaMat(int[,] mat)
        {
            Console.Clear();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine("\n");
            }
        }

        private static void caricaMat(int[,] mat)
        {
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = leggiNumero($"Inserisci l'elemento [{i}, {j}]: ");
                }
            }
        }

        private static int leggiNumero(string v, int min = int.MinValue, int max = int.MaxValue)
        {
            int n;
            string s = "";
            do
            {
                Console.Write(v);
                s = Console.ReadLine();
            } while (!int.TryParse(s, out n) || n < min || n > max);
            return n;
        }
    }
}
