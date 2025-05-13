using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_57_pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = InserisciN("Inserisci R: ");
            int c = InserisciN("Inserisci C: ");
            int[,]mat =new int[r,c];
            InserisciDatiFibonacci(mat);
        }

        private static int InserisciN(string messaggio)
        {
            int n;
            do
            {
                Console.Write(messaggio);
            } while (!int.TryParse(Console.ReadLine(), out n));
            return n;
        }
        private static void InserisciDatiFibonacci(int[,] mat)
        {
            int elemnto = 1,val1=1;
            for (int i = 0; i < mat.GetLength(0); i++)
            {

                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (elemnto <= 2) mat[i, j] = 1;
                    else
                    {

                    }
                    Console.Clear();
                    StampaMat(mat);
                    
                }
            }
            Console.Clear();
            StampaMat(mat);
        }
        private static void StampaMat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}
