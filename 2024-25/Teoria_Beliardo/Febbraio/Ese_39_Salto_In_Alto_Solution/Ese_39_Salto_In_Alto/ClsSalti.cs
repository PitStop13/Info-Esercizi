using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese_39_Salto_In_Alto
{
    internal class ClsSalti
    {
        static Random rnd = new Random();
        const int LARGHEZZATABTOT = 40;
        internal static void CaricaNazioni(string[] nazione)
        {
            string[] stati = { "Italia", "Kossovo", "Jamaica", "Francia" };
            for(int i = 0; i < nazione.Length; i++)
            {
                int index = rnd.Next(stati.Length);
                nazione[i] = stati[index];
            }
        }

        internal static void CaricaSalti(int[] salti)
        {
            for(int i = 0; i < salti.Length; i++)
            {
                int misura = rnd.Next(190, 240);
                salti[i] = misura;
            }
        }

        internal static void CaricaSesso(string[] sesso)
        {
            for(int i = 0; i < sesso.Length; i++)
            {
                int sex = rnd.Next(2);
                sesso[i] = sex == 0 ? "M" : "F";
            }
        }

        internal static void VisualizzaDati(string[] atleti, string[] sesso, string[] nazione, int[] salti)
        {
            IntestaTabella();
            for(int i = 0; i < atleti.Length; i++)
            {
                StampaRiga(atleti[i], sesso[i], nazione[i], salti[i]);
            }
            ChiudiTabella();
        }

        private static void ChiudiTabella()
        {
            Console.WriteLine("".PadLeft(LARGHEZZATABTOT, '-'));//mette n trattini (-)
        }

        private static void StampaRiga(string v1, string v2, string v3, int v4)
        {
            string st1 = v1.PadLeft(10);
            string st2 = v2.PadLeft(4);
            string st3 = v3.PadLeft(10);
            string st4 = v4.ToString().PadLeft(3);
            Console.WriteLine($"| {st1} | {st2} | {st3} | {st4} |");
        }

        private static void IntestaTabella()
        {
            Console.WriteLine("".PadLeft(LARGHEZZATABTOT, '-'));
            string st1 = "Atleta".PadLeft(10);
            string st2 = "Sex".PadLeft(4);
            string st3 = "Nazione".PadLeft(10);
            string st4 = "Ris".PadLeft(3);
            Console.WriteLine($"| {st1} | {st2} | {st3} | {st4} |");
        }

        internal static void ClassificaGenerale(string[] atleti, string[] sesso, string[] nazione, int[] salti)
        {
            for(int i = 0; i < atleti.Length - 1; i++)
            {
                int posMin = i;
                for(int j = i + 1; j < sesso.Length; j++)
                {
                    if (salti[posMin] < salti[j])
                    {
                        posMin = j;
                    }
                }
                if(posMin != i)
                {
                    ScambiaStringhe(ref sesso[i], ref sesso[posMin]);
                    ScambiaStringhe(ref atleti[i], ref atleti[posMin]);
                    ScambiaStringhe(ref nazione[i], ref nazione[posMin]);
                    ScambiaInteri(ref salti[i], ref salti[posMin]);
                }
            }
        }

        private static void ScambiaInteri(ref int v1, ref int v2)
        {
            int aus = v1;
            v1 = v2;
            v2 = aus;
        }

        private static void ScambiaStringhe(ref string v1, ref string v2)
        {
            string aus = v1;
            v1 = v2;
            v2 = aus;
        }

        internal static double MediaSaltiNazione(string[] atleti, string[] sesso, string[] nazione, int[] salti, string naz)
        {
            OrdinaPerNazione(atleti, sesso, nazione, salti);
            VisualizzaDati(atleti, sesso, nazione, salti);

            int somma = 0, conta = 0, i = 0;
            bool superato = false, trovato = false;

            while(!superato && i < (nazione.Length - 1))//Programma a rottura di codice, cioè finchè la nazione non cambia
            {
                if (nazione[i].ToLower() == naz.ToLower())
                {
                    somma += salti[i];
                    conta++;
                    trovato = true;
                }
                if (nazione[i].ToLower().CompareTo(naz.ToLower()) > 0)
                {
                    superato = true;
                }
                i++;
            }

            double media = trovato ? (double) somma / conta : -1;//variabili con virgola in doppia precisione
            return media;
        }

        private static void OrdinaPerNazione(string[] atleti, string[] sesso, string[] nazione, int[] salti)
        {
            for(int i = 0; i < nazione.Length - 1; i++)
            {
                int posMin = i;
                for (int j = i + 1; j < nazione.Length; j++)
                {
                    if (nazione[posMin].ToLower().CompareTo(nazione[j].ToLower()) > 0)
                    {
                        posMin = j;
                    }
                }
                if (posMin != i)
                {
                    ScambiaStringhe(ref sesso[i], ref sesso[posMin]);
                    ScambiaStringhe(ref atleti[i], ref atleti[posMin]);
                    ScambiaStringhe(ref nazione[i], ref nazione[posMin]);
                    ScambiaInteri(ref salti[i], ref salti[posMin]);
                }
            }
        }

        internal static void MediaSaltiOgniNazione(string[] atleti, string[] sesso, string[] nazione, int[] salti)
        {
            OrdinaPerNazione(atleti, sesso, nazione, salti);
            VisualizzaDati(atleti, sesso, nazione, salti);

            double somma = salti[0], media;
            int conta = 1;

            for(int i = 0; i < nazione.Length - 1; i++)
            {
                if (nazione[i] == nazione[i + 1])
                {
                    somma += salti[i + 1];
                    conta++;
                }
                else
                {
                    media = somma / conta;
                    Console.WriteLine($"La media per la nazione {nazione[i]} è "+ media.ToString("N2"));
                    somma = salti[i + 1];
                    conta = 1;
                }
            }
            media = somma / conta;
            Console.WriteLine($"La media per la nazione {nazione[nazione.Length - 1]} è " + media.ToString("N2"));
        }

        internal static void ClassificaPerNazioni(string[] atleti, string[] sesso, string[] nazione, int[] salti)
        {
            OrdinaPerNazione(atleti, sesso, nazione, salti);
            VisualizzaDati(atleti, sesso, nazione, salti);

            //Variabili di appoggio
            string[]  naz = new string[nazione.Length];
            double[] medie = new double[nazione.Length];
            int j = 0;

            int somma = salti[0], conta = 1;
            double media = 0;

            for(int i= 0; i < nazione.Length - 1; i++)
            {
                if (nazione[i] == nazione[i + 1])
                {
                    somma += salti[i + 1];
                    conta++;
                }
                else
                {
                    media = (double)somma / conta;
                    naz[j] = nazione[i];
                    medie[j] = media;
                    j++;
                    somma = salti[i + 1];
                    conta = 1;
                }
            }
            media = (double)somma / conta;
            naz[j] = nazione[nazione.Length - 1];
            medie[j] = media;

            OrdinaPerMedia(naz, medie);
        }

        private static void OrdinaPerMedia(string[] nazione, double[] medie)
        {
            for (int i = 0; i < nazione.Length - 1; i++)
            {
                int posMin = i;
                for (int j = i + 1; j < nazione.Length; j++)
                {
                    if (medie[posMin] < medie[j])
                    {
                        posMin = j;
                    }
                }
                if (posMin != i)
                {
                    ScambiaStringhe(ref nazione[i], ref nazione[posMin]);
                    ScambiaDouble(ref medie[i], ref medie[posMin]);
                }
            }
        }

        private static void ScambiaDouble(ref double v1, ref double v2)
        {
            v1 = v1 + v2;
            v2 = v1 - v2;
            v1 = v1 - v2;

            /*
             * v1 = 10; v2 = 20;
             * v1 = 30;
             * v2 = 10;
             * v1 = 20;
             **/
        }

        internal static void MediaSaltiUominiDonne(string[] sesso, int[] salti)
        {
            double sommaF = 0, sommaM = 0;
            int cont = 0;

            for(int i = 0; i < salti.Length; i++)
            {
                if (sesso[i] == "M")
                {
                    sommaM += salti[i];
                    cont++;
                }
                else
                {
                    sommaF += salti[i];
                }
            }
            Console.WriteLine($"Media salti uomini: {(sommaM / cont).ToString("N2")}\n" + $"Media salti donne: {(sommaF / (salti.Length - cont)).ToString("N2")}\n");
        }

        internal static void VincitoriNazionePrimaClassificata(string[] atleti, string[] sesso, string[] nazione, int[] salti)
        {
            ClassificaPerNazioni(atleti, sesso, nazione, salti);
            int i = 0;
            Console.WriteLine($"\nLa nazione prima classificata è: {nazione[0]}\nGli atleti della nazione {nazione[0]} sono:");
            do
            {
                Console.WriteLine($"Atleta: {atleti[i]}, sesso: {sesso[i]}, salto (in cm):{salti[i]}");
                i++;
            } while (nazione[i] == nazione[0]);
        }
    }
}
