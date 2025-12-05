using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.CompilerServices;

namespace MockTest
{
    public class DatabaseMock : IDatabaseMock
    {
        // Studente
        public void AddStudente(Studente studente)
        {
            List<Studente> studenti = GetStudenti();

            studenti.Add(studente);
            SaveStudentFile(studenti);
        }
        // Metodo per recuperare la lista di studenti dal file di testo
        public List<Studente> GetStudenti()
        {
            List<Studente> studenti = new List<Studente>();
            // Apre il file "studenti.txt" in lettura
            StreamReader sr = new StreamReader("studenti.txt");
            string[] s;

            // Legge il file riga per riga fino alla fine
            while (!sr.EndOfStream)
            {
                Studente studente = new Studente();

                // Legge una riga e la divide in base al carattere ';'
                // Esempio riga: "1;Mario;Rossi;2005-01-01;1"
                s = sr.ReadLine().Split(';');

                // Converte le stringhe nei tipi corretti (int, DateTime)
                studente.Id = int.Parse(s[0]);
                studente.Nome = s[1];
                studente.Cognome = s[2];
                studente.DataNascita = DateTime.Parse(s[3]);
                studente.ClasseId = int.Parse(s[4]);

                // Aggiunge lo studente alla lista
                studenti.Add(studente);
            }
            // Chiude il file per liberare le risorse
            sr.Close();

            return studenti;
        }
        public void UpdateStudente(int id, Studente studenteAggiornato)
        {
            List<Studente> studenti = GetStudenti();
            int index = studenti.FindIndex(st => st.Id == id);

            studenti[index] = studenteAggiornato;
            SaveStudentFile(studenti);
        }

        // Metodo per salvare la lista di studenti su file
        private void SaveStudentFile(List<Studente> studenti)
        {
            // Apre il file "studenti.txt" in scrittura (sovrascrive il contenuto esistente)
            StreamWriter sw = new StreamWriter("studenti.txt");

            foreach (Studente studente in studenti)
            {
                // Crea la stringa formattata con i dati dello studente separati da ';'
                string s = $"{studente.Id};{studente.Nome};{studente.Cognome};{studente.DataNascita};{studente.ClasseId}";
                // Scrive la riga nel file
                sw.WriteLine(s);
            }
            // Chiude il file
            sw.Close();
        }

        // AnniScolastici
        public void AddAnnoScolastico(AnnoScolastico anno)
        {
            List<AnnoScolastico> anni = GetAnniScolastici();

            anni.Add(anno);
            SaveYearFile(anni);
        }
        public List<AnnoScolastico> GetAnniScolastici()
        {
            List<AnnoScolastico> anni = new List<AnnoScolastico>();
            StreamReader sr = new StreamReader("anni_scolastici.txt");
            string[] s;

            while (!sr.EndOfStream)
            {
                AnnoScolastico anno = new AnnoScolastico();

                s = sr.ReadLine().Split(';');
                anno.Id = int.Parse(s[0]);
                anno.Anno = int.Parse(s[1]);
                anni.Add(anno);
            }
            sr.Close();

            return anni;
        }
        public void UpdateAnnoScolastico(int id, AnnoScolastico annoAggiornato)
        {
            List<AnnoScolastico> anni = GetAnniScolastici();
            int index = anni.FindIndex(anno => anno.Id == id);

            anni[index] = annoAggiornato;
            SaveYearFile(anni);
        }

        private void SaveYearFile(List<AnnoScolastico> anni)
        {
            StreamWriter sw = new StreamWriter("anni_scolastici.txt");

            foreach (AnnoScolastico anno in anni)
            {
                string s = $"{anno.Id};{anno.Anno}";
                sw.WriteLine(s);
            }
            sw.Close();
        }

        // Sezioni
        public void AddSezione(Sezione sezione)
        {
            List<Sezione> sezioni = GetSezioni();

            sezioni.Add(sezione);
            SaveSectionFile(sezioni);
        }
        public List<Sezione> GetSezioni()
        {
            List<Sezione> sezioni = new List<Sezione>();
            StreamReader sr = new StreamReader("sezioni.txt");
            string[] s;

            while (!sr.EndOfStream)
            {
                Sezione sezione = new Sezione();

                s = sr.ReadLine().Split(';');
                sezione.Id = int.Parse(s[0]);
                sezione.NomeSezione = s[1];
                sezioni.Add(sezione);
            }
            sr.Close();

            return sezioni;
        }
        public void UpdateSezione(int id, Sezione sezioneAggiornata)
        {
            List<Sezione> sezioni = GetSezioni();
            int index = sezioni.FindIndex(sezione => sezione.Id == id);

            sezioni[index] = sezioneAggiornata;
            SaveSectionFile(sezioni);
        }

        private void SaveSectionFile(List<Sezione> sezioni)
        {
            StreamWriter sw = new StreamWriter("sezioni.txt");

            foreach (Sezione sezione in sezioni)
            {
                string s = $"{sezione.Id};{sezione.NomeSezione}";
                sw.WriteLine(s);
            }
            sw.Close();
        }

        // Classi
        public void AddClasse(Classe classe)
        {
            List<Classe> classi = GetClassi();

            classi.Add(classe);
            SaveClassFile(classi);
        }
        public List<Classe> GetClassi()
        {
            List<Classe> classi = new List<Classe>();
            StreamReader sr = new StreamReader("classi.txt");
            string[] s;

            while (!sr.EndOfStream)
            {
                Classe classe = new Classe();

                s = sr.ReadLine().Split(';');
                classe.Id = int.Parse(s[0]);
                classe.AnnoId = int.Parse(s[1]);
                classe.SezioneId = int.Parse(s[2]);
                classi.Add(classe);
            }
            sr.Close();

            return classi;
        }
        public void UpdateClasse(int id, Classe classeAggiornata)
        {
            List<Classe> classi = GetClassi();
            int index = classi.FindIndex(classe => classe.Id == id);

            classi[index] = classeAggiornata;
            SaveClassFile(classi);
        }

        private void SaveClassFile(List<Classe> classi)
        {
            StreamWriter sw = new StreamWriter("classi.txt");

            foreach (Classe classe in classi)
            {
                string s = $"{classe.Id};{classe.AnnoId};{classe.SezioneId}";
                sw.WriteLine(s);
            }
            sw.Close();
        }

        // Materie
        public void AddMateria(Materia materia)
        {
            List<Materia> materie = GetMaterie();

            materie.Add(materia);
            SaveSubjectFile(materie);
        }
        public List<Materia> GetMaterie()
        {
            List<Materia> materie = new List<Materia>();
            StreamReader sr = new StreamReader("materie.txt");
            string[] s;

            while (!sr.EndOfStream)
            {
                Materia materia = new Materia();

                s = sr.ReadLine().Split(';');
                materia.Id = int.Parse(s[0]);
                materia.NomeMateria = s[1];
                materie.Add(materia);
            }
            sr.Close();

            return materie;
        }
        public void UpdateMateria(int id, Materia materiaAggiornata)
        {
            List<Materia> materie = GetMaterie();
            int index = materie.FindIndex(materia => materia.Id == id);

            materie[index] = materiaAggiornata;
            SaveSubjectFile(materie);
        }

        private void SaveSubjectFile(List<Materia> materie)
        {
            StreamWriter sw = new StreamWriter("materie.txt");

            foreach (Materia materia in materie)
            {
                string s = $"{materia.Id};{materia.NomeMateria}";
                sw.WriteLine(s);
            }
            sw.Close();
        }

        // Voti
        public void AddVoto(Voto voto)
        {
            List<Voto> voti = GetVoti();

            voti.Add(voto);
            SaveVoteFile(voti);
        }
        public List<Voto> GetVoti()
        {
            List<Voto> voti = new List<Voto>();
            StreamReader sr = new StreamReader("voti.txt");
            string[] s;

            while (!sr.EndOfStream)
            {
                Voto voto = new Voto();

                s = sr.ReadLine().Split(';');
                voto.Id = int.Parse(s[0]);
                voto.StudenteId = int.Parse(s[1]);
                voto.MateriaId = int.Parse(s[2]);
                voto.Valore = int.Parse(s[3]);
                voto.DataVoto = DateTime.Parse(s[4]);
                voti.Add(voto);
            }
            sr.Close();

            return voti;
        }

        public void UpdateVoto(int id, Voto votoAggiornato)
        {
            List<Voto> voti = GetVoti();
            int index = voti.FindIndex(voto => voto.Id == id);

            voti[index] = votoAggiornato;
            SaveVoteFile(voti);
        }

        private void SaveVoteFile(List<Voto> voti)
        {
            StreamWriter sw = new StreamWriter("voti.txt");

            foreach (Voto voto in voti)
            {
                string s = $"{voto.Id};{voto.StudenteId};{voto.MateriaId};{voto.Valore};{voto.DataVoto}";
                sw.WriteLine(s);
            }
            sw.Close();
        }

        // Operazioni specifiche
        public List<Studente> GetStudentiPerClasse(int classeId)
        {
            List<Studente> studenti = GetStudenti();
            List<Studente> studentiClasse = new List<Studente>();

            foreach (Studente studente in studenti)
            {
                if (studente.ClasseId == classeId)
                    studentiClasse.Add(studente);
            }

            return studentiClasse;
        }

        public List<Voto> GetVotiPerStudente(int studenteId)
        {
            List<Voto> voti = GetVoti();
            List<Voto> votiStudente = new List<Voto>();

            foreach (Voto voto in voti)
            {
                if (voto.StudenteId == studenteId)
                    votiStudente.Add(voto);
            }

            return votiStudente;
        }

        // Calcola la media dei voti per una specifica classe e materia
        public double CalcolaMediaVotiPerClasseEMateria(int classeId, int materiaId)
        {
            // Recupera tutti gli studenti e tutti i voti
            List<Studente> studenti = GetStudenti();
            List<Studente> studentiSelezionati = new List<Studente>();

            List<int> ids = new List<int>();

            List<Voto> voti = GetVoti();
            List<Voto> votiSelezionati = new List<Voto>();

            double somma = 0;
            int cont = 0;

            // 1. Trova gli ID degli studenti che appartengono alla classe specificata
            foreach (Studente studente in studenti)
            {
                if (studente.ClasseId == classeId)
                    ids.Add(studente.Id);
            }

            // 2. Itera su tutti i voti per trovare quelli rilevanti
            foreach (Voto voto in voti)
            {
                // Controlla se il voto è della materia richiesta
                if (voto.MateriaId == materiaId)
                {
                    // Controlla se il voto appartiene a uno degli studenti della classe
                    if (ids.Contains(voto.StudenteId))
                    {
                        somma += voto.Valore;
                        cont++;
                    }
                }
            }

            // Calcola la media (gestire divisione per zero se necessario, qui si assume cont > 0 o restituisce NaN/Infinito)
            return (double)somma / cont;
        }
    }
}
