using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_60_Pag_86
{
    internal class Program
    {
        const int ORDINE = 4;
        static void Main(string[] args)
        {
            int[,] matrice = new int[ORDINE, ORDINE]
            {
                { 16, 2, 3, 13 },
                { 5, 11, 10, 8 },
                { 9, 7, 6, 12 },
                { 4, 14, 15, 1 }
            };
            Console.WriteLine("VERIFICA SE QUADRATO MAGICO");
            StampaMatrice(matrice);
            bool isQuadratoMagico = VerificaQuadaratoMagico(matrice);
            string message = isQuadratoMagico ? "La matrice è un quadrato magico" : "La matrice NON è un quadrato magico"; //è uguale all if che c'è sotto
            Console.WriteLine(message);
            //if (isQuadratoMagico)
            //{
            //    Console.WriteLine("La matrice è un quadrato magico");
            //}
            //else
            //{
            //    Console.WriteLine("La matrice NON è un quadrato magico");
            //}
            Console.ReadKey();
        }

        private static bool VerificaQuadaratoMagico(int[,] matrice)
        {
            int sommaPrimaRiga = 0;
            for (int z = 0; z < ORDINE; z++)
                sommaPrimaRiga += matrice[0, z];
            bool isQuadratoMagico = true;
            int i = 1, j = 0, somma = 0;

            // Verifico le righe
            while(isQuadratoMagico && i < ORDINE)
            {
                for (j = 0; j < ORDINE; j++)
                    somma += matrice[i, j];
                //if(somma == sommaprimaRiga)
                //{
                //    isQuadratoMagico = true;
                //}
                //else
                //{
                //    isQuadratoMagico = false;
                //}
                isQuadratoMagico = (somma == sommaPrimaRiga); //è uguale all if sopra
                i++;
                somma = 0;
            }

            // Verifico le colonne
            j = 0; somma = 0;
            while (isQuadratoMagico && j < ORDINE)
            {
                for (i = 0; i < ORDINE; i++)
                    somma += matrice[i, j];
                isQuadratoMagico = (somma == sommaPrimaRiga);
                j++;
                somma = 0;
            }

            // Verifico la diagonale principale
            if(isQuadratoMagico)
            {
                int sommaDiagonalePrincipale = 0;
                for (int z = 0; z < ORDINE; z++)
                    sommaDiagonalePrincipale += matrice[0, z];
                isQuadratoMagico = (sommaDiagonalePrincipale == sommaPrimaRiga);
            }

            // Verifico la diagonale secondaria
            if (isQuadratoMagico)
            {
                int sommaDiagonaleSecondaria = 0;
                for (int z = 0; z < ORDINE; z++)
                    sommaDiagonaleSecondaria += matrice[0, ORDINE - z -1];
                isQuadratoMagico = (sommaDiagonaleSecondaria == sommaPrimaRiga);
            }

            return isQuadratoMagico;
        }

        private static void StampaMatrice(int[,] m)
        {
            Console.WriteLine();
            for (int i = 0; i < ORDINE; i++)
            {
                for (int j = 0; j < ORDINE; j++)
                {
                    Console.Write(m[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}
