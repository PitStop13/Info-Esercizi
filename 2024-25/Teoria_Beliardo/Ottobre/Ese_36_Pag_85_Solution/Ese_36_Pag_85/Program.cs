using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_36_Pag_85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = IntroduciNumero("Inserisci la grandezza della metarice quadrata (r x r): ", 1);
            int[,] mat = new int[r, r];
            caricaMat(mat);
            stampaMat(mat);
            if(sommaDiagonale1(mat) == sommaDiagonale2(mat))
                Console.WriteLine("La somma della diagonale principale è uguale alla somma della diagonale secondaria!");
            else
                Console.WriteLine("La somma della diagonale principale NON è uguale alla somma della diagonale secondaria!");
            Console.ReadKey();
        }

        private static int sommaDiagonale2(int[,] mat)
        {
            int somma = 0;
            int i = 0, j = mat.GetLength(1) - 1;
            do
            {
                somma += mat[i, j];
                i++;
                j--;
            } while (i < mat.GetLength(0) && j >= 0);
            Console.WriteLine("la somma della diagonale secondaria è: " + somma);
            return somma;
        }

        private static int sommaDiagonale1(int[,] mat)
        {
            int somma = 0;
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                somma += mat[i, i];
            }
            Console.WriteLine("la somma della diagonale 1 principale è: " + somma);
            return somma;
        }

        private static void stampaMat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(3) + " ");
                }
                Console.Write("\n");
            }
        }

        private static void caricaMat(int[,] mat)
        {
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = IntroduciNumero($"Inserisci un numero nella posizione [{i}, {j}]: ");
                }
            }
        }

        private static int IntroduciNumero(string messaggio, int min = int.MinValue)
        {
            int n;
            do
            {
                Console.Write(messaggio);
            }while (!int.TryParse(Console.ReadLine(), out n) || n < min);
            return n;
        }
    }
}
