using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confronto_Ordinamenti
{
    public class ClsVettori
    {
        static Random rnd = new Random();
        public static void CaricaVetDisordinato(int[] vet)
        {
            for (int i = 0; i < vet.Length; i++)
                vet[i] = rnd.Next(1, 100000);//riempiamo il vettore
        }

        public static void OrdinaSelezione(int[] vet, ref long passi, ref long confronti, ref long scambi)
        {
            int posMin;
            int aus;

            for(int i = 0; i < vet.Length - 1; i++)
            {
                passi++;
                posMin = i;
                for(int j = i + 1; j < vet.Length; j++)
                {
                    confronti++;
                    if (vet[j] < vet[posMin])
                        posMin = j;
                }
                if(posMin != i)
                {
                    scambi++;
                    aus = vet[i];
                    vet[i] = vet[posMin];
                    vet[posMin] = aus;
                }
            }
        }

        public static void OrdinaScambio(int[] vet, ref long passi, ref long confronti, ref long scambi)
        {
            int i = -1;
            bool scambio;
            int aus;

            do
            {
                passi++;
                i++;
                scambio = false;
                for(int j = vet.Length - 2; j >= i; j--)
                {
                    confronti++;
                    if(vet[j + 1] < vet[j])
                    {
                        scambi++;
                        aus = vet[j];
                        vet[j] = vet[j + 1];
                        vet[j + 1] = aus;
                        scambio = true;
                    }
                }
            } while (i < vet.Length - 2 && scambio);
        }
    }
}
