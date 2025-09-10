using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestioneStudenti.ClsStudenti;

namespace GestioneStudenti
{
    public class ClsStudenti
    {
        static string[] _datiStudenti =
        {
            "1 Barberis Giovanni 1A",
            "2 Gotta Luigino 2B",
            "3 Mori Mario 2A",
            "4 Pio Mimmo 3A",
            "5 Liberale Patrizia 3B",
            "6 Gotta Maria 3A",
            "7 Mora Marco 1A",
            "8 Pio Mimma 2B",
        };

        public struct Studente
        {
            public int matricola; // chiave primaria
            public string cognome;
            public string nome;
            public string classe;
        }

        public static Studente[] Studenti;
        static int _nStudenti = 0;

        public static List<string> CaricaDatiStudenti()
        {
            List<string> listClassi = new List<string>();
            string[] dati = new string[3];

            for (int i = 0; i < _datiStudenti.Length; i++)
            {
                _nStudenti++;
                Array.Resize(ref Studenti, _nStudenti);
                dati = _datiStudenti[i].Split(' ');
                Studenti[_nStudenti - 1].matricola = Convert.ToInt32(dati[0]);
                Studenti[_nStudenti - 1].cognome = dati[1];
                Studenti[_nStudenti - 1].nome = dati[2];
                Studenti[_nStudenti - 1].classe = dati[3];
                if (!listClassi.Contains(dati[3]))
                    listClassi.Add(dati[3]);
            }
            listClassi.Sort();
            return listClassi;
        }

        public static Studente InserisciStudente(string cogn, string nome, string classe)
        {
            _nStudenti++;
            Array.Resize(ref Studenti, _nStudenti);
            Studente stud = new Studente
            {
                matricola = _nStudenti,
                cognome = cogn,
                nome = nome,
                classe = classe
            };
            Studenti[_nStudenti - 1] = stud;
            return stud;
        }

        public static int RicercaStudentePerMatricola(int matricola)
        {
            for(int i = 0; i < Studenti.Length; i++)
            {
                if (Studenti[i].matricola == matricola) 
                    return i;
            }
            return -1;
        }

        public static int RicercaStudentePerCognomeNome(string cognome, string nome)
        {
            for (int i = 0; i < Studenti.Length; i++)
            {
                if (Studenti[i].cognome == cognome && Studenti[i].nome == nome)
                    return i;
            }
            return -1;
        }

        public static void OrdinaPerNominativo()
        {
            Studente temp;
            int posMin = 0;
            string nominativo1, nominativo2;

            for (int i = 0; i < _nStudenti; i++)
            {
                posMin = i;
                for (int j = i + 1; j < _nStudenti; j++)
                {
                    nominativo2 = Studenti[j].cognome + Studenti[j].nome;
                    nominativo1 = Studenti[posMin].cognome + Studenti[posMin].nome;

                    if (nominativo2.CompareTo(nominativo1) < 0)
                        posMin = j;
                }
                if (posMin != i)
                {
                    temp = Studenti[i];
                    Studenti[i] =Studenti[posMin];
                    Studenti[posMin] = temp;
                }
            }
        }


        public static int CercaMatricola(string cognome, string nome)
        {
            for (int i = 0; i < _nStudenti; i++)
            {
                if (Studenti[i].cognome == cognome && Studenti[i].nome == nome)
                {
                    return Studenti[i].matricola;
                }
            }
            return -1;
        }

        public static string CercaStudenteMediaMaggiore()
        {
            string[] studMediaMax = new string[ClsStudenti.Studenti.Length + 1];
            double mediaMax = double.MinValue;
            int posLibera = 0;
            for (int i = 0; i < ClsStudenti.Studenti.Length; i++)
            {
                double mediaStud = ClsValutazioni.CalcolaMediaPerStudente(ClsStudenti.Studenti[i]);
                if (mediaStud >= mediaMax)
                {
                    if (mediaStud > mediaMax)
                    {
                        mediaMax = mediaStud;
                        posLibera = 0;
                        studMediaMax[posLibera] = $"{mediaMax:0.00}";
                        posLibera++;
                    }
                    studMediaMax[posLibera] = $"{ClsStudenti.Studenti[i].cognome} {ClsStudenti.Studenti[i].nome}";
                    posLibera++;
                }
            }

            Array.Resize(ref studMediaMax, posLibera);
            string stud = "";
            if (studMediaMax.Length > 2)
            {
                for (int i = 1; i < studMediaMax.Length; i++)
                {
                    if (i != (studMediaMax.Length - 1))
                    {
                        stud += studMediaMax[i] + ", ";
                    }
                }
            }
            stud += studMediaMax[studMediaMax.Length - 1];

            string ris = $"{stud} media {studMediaMax[0]}";

            return ris;
        }

        public static string StudentiSenzaVoti()
        {
            string[] studVet = new string[ClsStudenti.Studenti.Length];
            int pos = 0;
            for (int i = 0; i < _nStudenti; i++)
            {
                int nVoti = ClsValutazioni.CalcolaNumValutazioni(Studenti[i]);
                if(nVoti == 0)
                {
                    studVet[pos] = $"{Studenti[i].cognome} {Studenti[i].nome}";
                    pos++;
                }
            }

            string stud = "";
            if (pos == 0)
            {
                stud = "Non ci sono studenti senza voti";
            }
            else
            {
                for (int i = 0; i < pos - 1; i++)
                {
                    stud += ($"{studVet[i]}, ");
                }
                stud += ($"{studVet[pos - 1]}");
            }

            return stud;
        }

        public static string ClasseMigliorePeggiore()
        {
            string[] classi = new string[ClsStudenti.Studenti.Length];
            int pos = 0;

            for (int i = 0; i < _nStudenti; i++)
            {
                if (!classi.Contains(Studenti[i].classe))
                {
                    classi[pos] = Studenti[i].classe;
                    pos++;
                }
            }

            Array.Resize(ref classi, pos);

            double[] mediaClassi = new double[classi.Length];
            string[] classiMediaMax = new string[classi.Length];
            string[] classiMediaMin = new string[classi.Length];
            int posClassiMediaMax = 0;
            int posClassiMediaMin = 0;
            double mediaMax = int.MinValue;
            double mediaMin = int.MaxValue;

            for (int i = 0; i < classi.Length; i++)
            {
                int contatore = 0;
                for (int j = 0; j < ClsStudenti.Studenti.Length; j++)
                {
                    if (Studenti[j].classe == classi[i])
                    {
                        double mediaStud = ClsValutazioni.CalcolaMediaPerStudente(ClsStudenti.Studenti[j]);
                        mediaClassi[i] += mediaStud;
                        contatore++;
                    }
                }
                mediaClassi[i] = mediaClassi[i] / contatore;

                if (mediaClassi[i] >= mediaMax)
                {
                    if(mediaClassi[i] > mediaMax)
                    {
                        mediaMax = mediaClassi[i];
                        posClassiMediaMax = 0;
                        classiMediaMax[posClassiMediaMax] = $"{mediaMax:0.00}";
                        posClassiMediaMax++;
                    }
                    classiMediaMax[posClassiMediaMax] = classi[i];
                    posClassiMediaMax++;
                }

                if(mediaClassi[i] <= mediaMin)
                {
                    if (mediaClassi[i] < mediaMin)
                    {
                        mediaMin = mediaClassi[i];
                        posClassiMediaMin = 0;
                        classiMediaMin[posClassiMediaMin] = $"{mediaMin:0.00}";
                        posClassiMediaMin++;
                    }
                    classiMediaMin[posClassiMediaMin] = classi[i];
                    posClassiMediaMin++; 
                }
            }

            Array.Resize(ref classiMediaMax, posClassiMediaMax);
            Array.Resize(ref classiMediaMin, posClassiMediaMin);

            string[] classiMediaMaxMin = new string[2];
            for(int j = 0; j <  classiMediaMax.Length; j++)
            {
                if(j == classiMediaMax.Length - 1)
                    classiMediaMaxMin[0] += classiMediaMax[j];
                else
                    classiMediaMaxMin[0] += classiMediaMax[j] + " ";
            }
            for (int j = 0; j < classiMediaMin.Length; j++)
            {
                if (j == classiMediaMin.Length - 1)
                    classiMediaMaxMin[1] += classiMediaMin[j];
                else
                    classiMediaMaxMin[1] += classiMediaMin[j] + " ";
            }

            string[] vetClassiMediaMax = classiMediaMaxMin[0].Split(' ');
            string[] vetClassiMediaMin = classiMediaMaxMin[1].Split(' ');

            string materieMediaMax = "";
            if (vetClassiMediaMax.Length > 2)
            {
                for (int i = 1; i < vetClassiMediaMax.Length - 1; i++)
                {
                    materieMediaMax += ($"{vetClassiMediaMax[i]} , ");
                }
            }
            materieMediaMax += ($"{vetClassiMediaMax[vetClassiMediaMax.Length - 1]}");

            string materieMediaMin = "";
            if (vetClassiMediaMin.Length > 2)
            {
                for (int i = 1; i < vetClassiMediaMin.Length - 1; i++)
                {
                    materieMediaMin += ($"{vetClassiMediaMin[i]} , ");
                }
            }
            materieMediaMin += $"{vetClassiMediaMin[vetClassiMediaMin.Length - 1]}";

            string messaggio = "";

            if (vetClassiMediaMin.Length > 2)
            {
                if (vetClassiMediaMax.Length > 2)
                    messaggio = $"Le classi miglori sono {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLe classi peggiori sono {materieMediaMin} con media: {vetClassiMediaMin[0]}";
                else
                    messaggio = $"La classe miglore è {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLe classi peggiori sono {materieMediaMin} con media: {vetClassiMediaMin[0]}";
            }
            else
            {
                if (vetClassiMediaMax.Length > 2)
                    messaggio = $"Le classi miglori sono {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLa classe peggiore è {materieMediaMin} con media: {vetClassiMediaMin[0]}";
                else
                    messaggio = $"La classe miglore è {materieMediaMax} con media: {vetClassiMediaMax[0]}\nLa classe peggiore è {materieMediaMin} con media: {vetClassiMediaMin[0]}";
            }

            return messaggio;
        }

        public static Studente[] CercaStudentiInsufficienti()
        {
            Studente[] studenti = new Studente[Studenti.Length];
            int pos = 0;
            for (int i = 0; i < ClsStudenti.Studenti.Length; i++)
            {
                double mediaStud = ClsValutazioni.CalcolaMediaPerStudente(ClsStudenti.Studenti[i]);
                if(mediaStud < 6)
                {
                    studenti[pos] = Studenti[i];
                    pos++;
                }
            }

            Array.Resize(ref studenti, pos);
            return studenti;
        }

        public static Studente[] CercaStudentiPerClasse(string classe)
        {
            Studente[] studenti = new Studente[Studenti.Length];
            int pos = 0;
            for (int i = 0; i < ClsStudenti.Studenti.Length; i++)
            {
                if (Studenti[i].classe == classe)
                {
                    studenti[pos] = Studenti[i];
                    pos++;
                }
            }

            Array.Resize(ref studenti, pos);
            return studenti;
        }

        internal static string[] CercaStudentiMediePerClasse(string classe)
        {
            ClsStudenti.Studente[] studentiClasse = ClsStudenti.CercaStudentiPerClasse(classe);
            string[] studentiMedieClasse = new string[studentiClasse.Length];
            for(int i = 0; i < studentiClasse.Length; i++)
            {
                studentiMedieClasse[i] = $"{studentiClasse[i].matricola} {studentiClasse[i].cognome} {studentiClasse[i].nome} {studentiClasse[i].classe}";
                studentiMedieClasse[i] += $" {ClsValutazioni.CalcolaMediaPerStudente(studentiClasse[i]):0.00}";
            }

            return studentiMedieClasse;
        }
    }
}
