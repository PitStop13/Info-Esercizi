using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_56_Pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] mat;
            int r;
            Console.Write("Inserisci dimensione matrice rxr: ");
            r = int.Parse(Console.ReadLine());
            mat = new int[r, r];
            InserisciDati(mat);
            Console.Clear();
            Stampamat(mat);
            Console.WriteLine();
            if (sommaUpDownUguali(mat))
                Console.WriteLine("la media degli elementi al disopra della diagonale principale è uguale alla media degli elementi al disotto della diagonale principale");
            else
                Console.WriteLine("la media degli elementi al disopra della diagonale principale NON è uguale alla media degli elementi al disotto della diagonale principale");
            Console.ReadKey();

        }

        private static bool sommaUpDownUguali(int[,] mat)
        {
            int sommaUp = 0, sommaDown = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if(i < j) sommaDown += mat[i,j];
                    if (i > j) sommaUp += mat[i, j];
                }
            }
            if (sommaUp == sommaDown) 
                return true;
            else
                return false;
        }

        private static void InserisciDati(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Clear();
                    Stampamat(mat);
                    Console.WriteLine();
                    Console.Write($"Inserisci l'elemento mat [{i}, {j}]: ");
                    mat[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        private static void Stampamat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }
    }
}
