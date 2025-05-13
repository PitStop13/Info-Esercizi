using System;
using System.Windows.Forms;

namespace Scrutinio
{
    public class ClsScrutinio
    {
        static Random rnd = new Random();
        public static string[] Studenti = { "Ambrogio", "Bodoaga", "Borbone", "Burdisso", "Cerone", 
            "Dzeljo", "Fontana", "Hoxa", "Kardash", "Lamberti", "Marino", "Minetti", "Mondino", 
            "Mossello", "Negro", "Olivero", "Parola", "Pasquero", "Peano", "Poputoaia", "Rrozhani", 
            "Singh", "Tesio"};

        public static string[] Materie = { "ITALIANO", "STORIA", "INGLESE", "MATEMATICA", "INFORMATICA", 
            "SISTEMI", "TPSIT", "TELECOMUNICAZIONI" };

        public static int[,] Voti = new int[Studenti.Length, Materie.Length];

        public static void CaricaVoti(int min, int max)
        {
            for (int i = 0; i < Studenti.Length; i++)
            {
                for (int j = 0; j < Materie.Length; j++)
                {
                    Voti[i, j] = rnd.Next(min, max);
                }
            }

        }

        internal static void ContaEsiti(ref int nPromossi, ref int nBocciati, ref int nRimandati)
        {
            for (int i = 0; i < Voti.GetLength(0); i++)
            {
                int contaInsufficienze = 0;
                for ( int j = 0;j < Voti.GetLength(1); j++)
                {
                    if(Voti[i, j] < 6) contaInsufficienze++;
                }
                if(contaInsufficienze == 0) nPromossi++;
                else if(contaInsufficienze > 3) nBocciati++;
                else nRimandati++;
            }
        }

        internal static void MateriaBalorda()
        {
            double min =  double.MaxValue;
            int somma;
            string materia = "";

            for(int i = 0; i < Voti.GetLength(1); i++)
            {
                somma = 0;
                for(int j = 0; j < Voti.GetLength(0); j++)
                {
                    somma += Voti[j, i];
                }
                if(((double)somma / Voti.GetLength(0)) < min)
                {
                    materia = Materie[i];
                    min = somma / Voti.GetLength(0);
                }
            }

            MessageBox.Show("La materia balorda è: " + materia.ToString());
        }
    }
}
