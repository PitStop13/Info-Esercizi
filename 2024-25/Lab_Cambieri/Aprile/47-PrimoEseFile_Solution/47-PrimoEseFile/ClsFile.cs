using System;
using System.Collections.Generic;
using System.IO;

namespace _47_PrimoEseFile
{
    internal class ClsFile
    {
        public static string[] LeggiParoleNonRipetute(string inputFile)
        {
            StreamReader sr = new StreamReader(inputFile);
            string riga = "";
            string[] parole;
            string[] paroleDistinte = new string[100];
            int pos, i = 0, posDiPartenza;

            while(!sr.EndOfStream)
            {
                riga = sr.ReadLine();
                parole = riga.Split(' ');
                posDiPartenza = 0;
                for (int j = 0; j < parole.Length; j++)
                {
                    pos = CercaParolaNonDuplicata(parole[j], paroleDistinte, posDiPartenza);
                    if (pos == -1) // pos è -1 se non ho trovato la parola
                    {
                        paroleDistinte[i] = parole[j];
                        i++;
                    }
                }
            }
            sr.Close();
            return paroleDistinte;
        }

        public static string LeggiTutto(string inputFile)
        {
            return File.ReadAllText(inputFile);
        }

        public static void ModificaFile(string outputFile, string content)
        {
            File.WriteAllText(outputFile, content);
        }

        public static void ContaLineeParole(string inputFile, ref int nLinee, ref int nParole)
        {
            StreamReader sr = new StreamReader(inputFile);
            string riga = "";

            while (!sr.EndOfStream)
            {
                riga = sr.ReadLine();
                nLinee++;
                /*string[] parole = riga.Split(' ');
                nParole += parole.Length;*/
                nParole += riga.Split(' ').Length;
            }
            sr.Close();
        }

        private static int CercaParolaNonDuplicata(string robertoParola, string[] paroleDistinte, int posDiPartenza)
        {
            int retVal = -1;
            int i = 0;
            while (paroleDistinte[i] != null && i < paroleDistinte.Length)
            {
                if (paroleDistinte[i] == robertoParola)
                    return i;
                i++;
            }
            return retVal;
        }

        public static int ContaOccorrenzeRobertoParola(string inputFile, string robertoParola)
        {
            int retVal = 0;
            StreamReader sr = new StreamReader(inputFile);

            while (!sr.EndOfStream)
            {
                string riga = sr.ReadLine();
                string[] paroleRiga = riga.Split(' ');
                for (int j = 0; j < paroleRiga.Length; j++)
                {
                    if (paroleRiga[j] == robertoParola)
                        retVal++;
                }
            }
            sr.Close();
            return retVal;
        }

        public static void SostituisciRobertoParolaInNuovoFile(string inputFile, string outputFile, string robertoParolaDaSostituire, string robertoParolaNuova)
        {
            string inputFileText = File.ReadAllText(inputFile);
            string outputFileText = inputFileText.Replace(robertoParolaDaSostituire, robertoParolaNuova);
            File.WriteAllText(outputFile, outputFileText);
        }

        public static void SostituisciRobertoParolaInStessoFile(string inputFile, string robertoParolaDaSostituire, string robertoParolaNuova)
        {
            StreamWriter sw = new StreamWriter("out.txt");
            StreamReader sr = new StreamReader(inputFile);

            while (!sr.EndOfStream)
            {
                string riga = sr.ReadLine();
                string newRiga = riga.Replace(robertoParolaDaSostituire, robertoParolaNuova);
                sw.WriteLine(newRiga);
            }
            sr.Close();
            sw.Close();
            File.Copy("out.txt", inputFile, true);
            File.Delete("out.txt");
        }

        public static string ContaOccorrenzeParoleNelFile(string inputFile)
        {
            List<string> parole = new List<string>();
            List<int> occorrenze = new List<int>();
            StreamReader sr = new StreamReader(inputFile);

            while (!sr.EndOfStream)
            {
                string riga = sr.ReadLine();
                string[] paroleRiga = riga.Split(' ');
                for (int j = 0; j < paroleRiga.Length; j++)
                {
                    int indiceRobertoParola = parole.IndexOf(paroleRiga[j]);
                    if (indiceRobertoParola == -1){
                        // Prima individuazione della parola
                        parole.Add(paroleRiga[j]);
                        occorrenze.Add(1);
                    }
                    else
                    {
                        // Parola già individuata aumentare di 1 le occorrenze;
                        occorrenze[indiceRobertoParola]++;
                    }
                }
            }
            sr.Close();
            string output = "";
            for(int i = 0; i < parole.Count; i++)
            {
                output += $"{parole[i]}: {occorrenze[i]}\n";
            }

            return output;
        }

        public static string LunghezzaMediaParole(string inputFile)
        {
            StreamReader sr = new StreamReader(inputFile);

            string parolaMax = "";
            int parolaLunghezzaMax = 0;
            bool parolaLunghezzaMaxMagg2 = false;
            string parolaMin = "";
            int parolaLunghezzaMin = int.MaxValue;
            bool parolaLunghezzaMinMagg2 = false;
            int contParole = 0;
            int contLettere = 0;
            while (!sr.EndOfStream)
            {
                string riga = sr.ReadLine();
                string[] paroleRiga = riga.Split(' ');
                contParole += paroleRiga.Length;
                for (int i = 0; i < paroleRiga.Length; i++)
                {
                    contLettere += paroleRiga[i].Length;
                    if (paroleRiga[i].Length > parolaLunghezzaMax)
                    {
                        parolaMax = paroleRiga[i];
                        parolaLunghezzaMax = paroleRiga[i].Length;
                        parolaLunghezzaMaxMagg2 = false;
                    }
                    else if (paroleRiga[i].Length == parolaLunghezzaMax)
                    {
                        parolaMax += " " + paroleRiga[i];
                        parolaLunghezzaMaxMagg2 = true;
                    }
                    if (paroleRiga[i].Length < parolaLunghezzaMin)
                    {
                        parolaMin = paroleRiga[i];
                        parolaLunghezzaMin = paroleRiga[i].Length;
                        parolaLunghezzaMinMagg2 = false;
                    }
                    else if (paroleRiga[i].Length == parolaLunghezzaMin)
                    {
                        parolaMin += " " + paroleRiga[i];
                        parolaLunghezzaMinMagg2 = true;
                    }
                }
            }
            sr.Close();

            string messaggio = "";
            if (parolaLunghezzaMaxMagg2)
            {
                if (parolaLunghezzaMinMagg2)
                {
                    messaggio = $"La lunghezza media delle parole è {((double)contLettere / contParole).ToString("N02")}.\nLe parole più lunghe sono: {parolaMax}, con {parolaLunghezzaMax} caratteri.\nLe parole più corte sono: {parolaMin}, con {parolaLunghezzaMin} caratteri.";
                }
                else
                {
                    messaggio = $"La lunghezza media delle parole è {((double)contLettere / contParole).ToString("N02")}.\nLe parole più lunghe sono: {parolaMax}, con {parolaLunghezzaMax} caratteri.\nLa parola più corta è: {parolaMin}, con {parolaLunghezzaMin} caratteri.";
                }
            }
            else
            {
                if (parolaLunghezzaMinMagg2)
                {
                    messaggio = $"La lunghezza media delle parole è {((double)contLettere / contParole).ToString("N02")}.\nLa parola più lunga è: {parolaMax}, con {parolaLunghezzaMax} caratteri.\nLe parole più corte sono: {parolaMin}, con {parolaLunghezzaMin} caratteri.";
                }
                else
                {
                    messaggio = $"La lunghezza media delle parole è {((double)contLettere / contParole).ToString("N02")}.\nLa parola più lunga è: {parolaMax}, con {parolaLunghezzaMax} caratteri.\nLa parola più corta è: {parolaMin}, con {parolaLunghezzaMin} caratteri.";
                }
            }

            return messaggio;
        }
    }
}