using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_58_pag_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int centro,offset;
            int r = InserisciN("Inserisci R (dispari): ");
            int[,] mat = new int[r, r];
            //centro = (int)Math.Ceiling((decimal)(r / 2.0)); Non necesario
            centro = r / 2;
            offset = 0;
            for(int i = 0; i < mat.GetLength(0)/2+1; i++)
            {
                for(int j=0;j<mat.GetLength(1); j++)
                {
                    if (centro - offset == j || centro+offset==j)
                    {                    
                        mat[i,j] = 1;
                    }
                    if(i>1 && j>1 && j < mat.GetLength(1)-1 && mat[i-1,j-1]!=0 && mat[i - 1, j + 1] != 0)
                    {
                        mat[i, j] = mat[i - 1, j - 1] + mat[i-1, j+1];
                    }
                }
                offset++;
            }
            StampaMat(mat);
            Console.ReadKey();
        }
        private static int InserisciN(string messaggio)
        {
            int n;
            do
            {
                Console.Write(messaggio);
            } while (!int.TryParse(Console.ReadLine(), out n) || n%2==0);
            return n;
        }
        private static void StampaMat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == 0)
                        Console.Write(" ".PadLeft(4));
                    else
                        Console.Write(mat[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}
