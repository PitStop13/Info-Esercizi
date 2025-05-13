using System;
using System.IO;

namespace _47_PrimoEseFile
{
    internal class ClsFile
    {
        internal static string[] LeggiParoleNonRipetute(string inputFile)
        {
            StreamReader sr = new StreamReader(inputFile);
            string riga = "";
            string[] parole;
            string[] paroleDistinte = new string[100];
            int pos, i = 0, posDiPartenza = 0;

            while(!sr.EndOfStream)
            {
                riga = sr.ReadLine();
                parole = riga.Split(' ');
                posDiPartenza = 0;
                for (int j = 0; j < parole.Length; j++)
                {
                    pos = CercaParolaNonDuplicata(parole, posDiPartenza);
                    if (pos != -1)
                    {
                        paroleDistinte[i] = parole[pos];
                        i++;
                    }
                }
            }
            return paroleDistinte;
        }

        private static int CercaParolaNonDuplicata(string[] parole, int posDiPartenza)
        {
            int retVal = -1;
            return retVal;
        }
    }
}