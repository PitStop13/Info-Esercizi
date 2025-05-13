using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsePag70_Matrice
{
    internal class Program
    {
        int[] vet = new int[10]; // dichiarazione vettore di 10 interi
        int[,] m = new int[5,5]; // dichiarazione matrice di 5x5 interi
        static int[,] mat;
        static void Main(string[] args)
        {
            int r, c;
            do
            {
                Console.Write("Inserisci la lunghezza della righa della matrice: ");
                r = int.Parse(Console.ReadLine());
                Console.Write("Inserisci la lunghezza della colonna della matrice: ");
                c = int.Parse(Console.ReadLine());
            }while(! (r > 0 && c > 0)); // (r <= 0 || c <= 0)
            mat = new int[r, c]; 
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    Console.Write($"Inserisci l'elemento {i} , {j} della matrice: ");
                    mat[i,j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("La matrice è: ");
            for (int i = 0; i < r; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < c; j++)
                {
                    Console.Write($" {mat[i,j]} ");
                }
            }
            Console.ReadKey();
        }
    }
}
