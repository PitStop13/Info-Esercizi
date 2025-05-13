using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static GestioneStudenti.ClsStudenti;
using static GestioneStudenti.ClsValutazioni;

namespace GestioneStudenti
{
    public class ClsValutazioni
    {
        static string[] _datiValutazioni =
        {
            "Inglese 7 O 1",
            "Informatica 8 L 2",
            "Informatica 4 S 3",
            "Sistemi 3 O 4",
            "Inglese 5 S 5",
            "Sistemi 3 L 6",
            "Sistemi 7 O 7",
            "Italiano 6 S 8",
            "Sistemi 8 O 8",
            "Italiano 8 O 1",
            "Sistemi 8 S 2",
            "Inglese 9 O 2"
        };

        public struct Valutazione
        {
            public string materia;
            public int voto;
            public string tipo;
            public int matricola;
        }

        public static Valutazione[] Valutazioni;
        static int _nValutazioni = 0;

        public static List<string> CaricaDatiValutazioni()
        {
            List<string> listMaterie = new List<string>();
            string[] dati = new string[3];

            for (int i = 0; i < _datiValutazioni.Length; i++)
            {
                _nValutazioni++;
                Array.Resize(ref Valutazioni, _nValutazioni);
                dati = _datiValutazioni[i].Split(' ');
                Valutazioni[_nValutazioni - 1].materia = dati[0];
                Valutazioni[_nValutazioni - 1].voto = Convert.ToInt32(dati[1]);
                Valutazioni[_nValutazioni - 1].tipo = dati[2];
                Valutazioni[_nValutazioni - 1].matricola = Convert.ToInt32(dati[3]);
                // Popolo anche listMaterie
                // Meglio farlo fisso da desiner
                if (!listMaterie.Contains(dati[0]))
                    listMaterie.Add(dati[0]);
            }
            return listMaterie;
        }

        public static Valutazione InserisciVoto(string materia, string tipo, int voto, int matricola)
        {
            _nValutazioni++;
            Array.Resize(ref Valutazioni, _nValutazioni);
            Valutazione val = new Valutazione
            {
                materia = materia,
                tipo = tipo,
                voto = voto,
                matricola = matricola
            };
            Valutazioni[_nValutazioni - 1] = val;
            return val;
        }


        public static double MediaPerMateria(string materia)
        {
            int somma = 0, contatore = 0;
            for (int i = 0; i < _nValutazioni; i++)
            {
                if (Valutazioni[i].materia == materia)
                {
                    somma += Valutazioni[i].voto;
                    contatore++;
                }
            }

            if (contatore > 0)
                return somma / contatore;
            else
                return -1;
        }

        public static int ContaVotiPerTipoPerStudente(int matricola, string tipo)
        {
            int contatore = 0;
            for (int i = 0; i < _nValutazioni; i++)
            {
                if (Valutazioni[i].matricola == matricola && Valutazioni[i].tipo == tipo)
                {
                    contatore++;
                }
            }

            /*if (contatore > 0)
                return contatore;
            else
                return -1;*/
            return contatore;
        }

        public static string RotturaMatricolaValutazioni()
        {
            string retVal = "";
            int cont = 1;
            for (int i = 0; i < _nValutazioni - 1; i++)
            {
                if (Valutazioni[i].matricola == Valutazioni[i + 1].matricola)
                    cont++;
                else
                {
                    retVal += ConcatenaDatiStudente(Valutazioni[i].matricola, cont) + "\n";
                    cont = 1;
                }
            }

            retVal += ConcatenaDatiStudente(Valutazioni[Valutazioni.Length - 1].matricola, cont);

            return retVal;
        }

        private static string ConcatenaDatiStudente(int matricola, int nValutazioni)
        {
            int posStudente = ClsStudenti.RicercaStudentePerMatricola(matricola);
            ClsStudenti.Studente stud = ClsStudenti.Studenti[posStudente];
            string nominativo = $"{stud.cognome} {stud.nome}";
            return $"{nominativo}: {nValutazioni}";
        }

        public static double CalcolaMediaPerStudente(ClsStudenti.Studente studente)
        {
            double mediaStud = 0;
            int contatore = 0;
            for (int i = 0; i < _nValutazioni; i++)
            {
                if (studente.matricola == Valutazioni[i].matricola)
                {
                    mediaStud += Valutazioni[i].voto;
                    contatore++;
                }
            }
            return mediaStud / contatore;
        }

        public static int CalcolaNumValutazioni(ClsStudenti.Studente studente)
        {
            int contatore = 0;
            for (int i = 0; i < _nValutazioni; i++)
            {
                if (studente.matricola == Valutazioni[i].matricola)
                {
                    contatore++;
                }
            }
            return contatore;
        }

        public static void OrdinaPerMatricola()
        {
            int posMin;
            Valutazione aus;

            for (int i = 0; i < _nValutazioni; i++)
            {
                posMin = i;
                for (int j = i + 1; j < _nValutazioni; j++)
                {
                    if (Valutazioni[posMin].matricola > Valutazioni[j].matricola)
                        posMin = j;
                }

                if (posMin != i)
                {
                    aus = Valutazioni[posMin];
                    Valutazioni[posMin] = Valutazioni[i];
                    Valutazioni[i] = aus;
                }
            }
        }

        public static string MaterieSenzaVoti(string[] materie)
        {
            string[] materieVet = new string[materie.Length];
            int pos = 0;
            for (int i = 0; i < materie.Length; i++)
            {
                int contatore = 0;
                for (int j = 0; j < _nValutazioni; j++)
                {
                    if (Valutazioni[j].materia == materie[i])
                    {
                        contatore++;
                    }
                }
                if (contatore == 0)
                {
                    materieVet[pos] = materie[i];
                    pos++;
                }
            }

            string materieSenzaVoto = "";
            if (pos == 0)
            {
                materieSenzaVoto = "Non ci sono materieSenzaVoto senza voti";
            }
            else
            {
                for (int i = 0; i < pos - 1; i++)
                {
                    materieSenzaVoto += ($"{materieVet[i]} , ");
                }
                materieSenzaVoto += ($"{materieVet[pos - 1]}");
            }

            return materieSenzaVoto;
        }

        public static Valutazione[] CercaValutazioniMateria(string materia)
        {
            Valutazione[] valutazioni = new Valutazione[Valutazioni.Length];
            int pos = 0;
            for (int i = 0; i < Valutazioni.Length; i++)
            {
                if (Valutazioni[i].materia == materia)
                {
                    valutazioni[pos] = Valutazioni[i];
                    pos++;
                }
            }

            Array.Resize(ref valutazioni, pos);
            OrdinaPerVoto(valutazioni);

            return valutazioni;
        }

        private static void OrdinaPerVoto(Valutazione[] valutazioni)
        {
            Valutazione aus;
            int posMin;
            for (int i = 0; i < valutazioni.Length; i++)
            {
                posMin = i;
                for (int j = i + 1; j < valutazioni.Length; j++)
                {
                    if (valutazioni[posMin].voto > valutazioni[j].voto)
                        posMin = j;
                }

                if (posMin != i)
                {
                    aus = valutazioni[posMin];
                    valutazioni[posMin] = valutazioni[i];
                    valutazioni[i] = aus;
                }
            }
        }
    }
}
