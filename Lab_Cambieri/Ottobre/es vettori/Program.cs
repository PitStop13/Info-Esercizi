using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Schema;

namespace es_28_pag_85
{
    internal class Program
    {
        static Random rnd = new Random();//static se no da errore
        static void Main(string[] args)
        {
            char scelta = ' ';
            do
            {
                ScriviMenu();
                scelta = Console.ReadKey(true).KeyChar; //true non fa vedere quello che abbiamo schiacciato
                switch (scelta)
                {
                    case '1': //Esercizio 28 pag 85
                        Console.Clear();
                        CancellaCompatta();
                        Console.ReadKey(true);
                        break;
                    case '2': // Esercizio 29 pag 85
                        Console.Clear();
                        FrequenzaGenerazione();
                        Console.ReadKey(true);
                        break;
                    case '3': // Esercizio 30 pag 85
                        Console.Clear();
                        DecimaleBinario();
                        Console.ReadKey(true);
                        break;
                    case '4':
                        Console.Clear();
                        SommaElementiCorniceEsterna();
                        Console.ReadKey(true);
                        break;
                    case '5':
                        Console.Clear();
                        SommaElemtiRiga();
                        Console.ReadKey(true);
                        break;
                    case '6':
                        Console.Clear();
                        SommaElementiColonna();
                        Console.ReadKey(true);
                        break;
                    case '7':
                        Console.Clear();
                        ContaElementoInInput();
                        Console.ReadKey(true);
                        break;
                    case '8':
                        Console.Clear();
                        SommaRigaColonna();
                        Console.ReadKey(true);
                        break;
                }
                //} while (scelta != 'q' && scelta != 'Q');
            } while (scelta.ToString().ToLower() != "q");
        }

        private static void SommaRigaColonna()
        {
            int r = IntroduciNumero("Inserisci il numero di righe della matrice: ");
            int c = IntroduciNumero("Inserisci il numero di colonne della matrice: ");
            int[,] mat = new int[r, c];
            CaricaMatriceCasuale(mat, 1, 11);
            StampaMatrice(mat, "Matrice iniziale: ");
            int i = IntroduciNumero("Inserisci il valore della riga i che vuoi sommare: ", 0, r - 1);
            int j = IntroduciNumero("Inserisci il valore della colonna i che vuoi sommare: ", 0, c - 1);
            int somriga = 0;
            for (int k = 0; k < c; k++)
            {
                somriga += mat[i, k];
            }
            Console.WriteLine($"\nLa somma degli elemnti della riga {i} è: {somriga}");
            int somcolonna = 0;
            for (int k = 0; k < r; k++)
            {
                somcolonna += mat[k, j];
            }
            Console.WriteLine($"La somma degli elemnti della colonna {j} è: {somcolonna}");
            if (somriga == somcolonna)
                Console.WriteLine($"\nLa somma della riga {i} e della colonna {j} sono uguali");
            else
                Console.WriteLine($"La somma della riga {i} e della colonna {j} non sono uguali");
        }

        private static void SommaElementiColonna()
        {
            int r = IntroduciNumero("Inserisci il numero di righe della matrice: ");
            int c = IntroduciNumero("Inserisci il numero di colonne della matrice: ", 2, 8);
            int[,] mat = new int[r, c];
            CaricaMatriceCasuale(mat, 1, 301);
            StampaMatrice(mat, "Matrice iniziale: ");
            int j = IntroduciNumero("Colonna j in cui sommare gli elementi: ", 0, c - 1);
            int s = 0;
            for (int i = 0; i < r; i++)
            {
                s += mat[i, j];
            }
            Console.WriteLine($"La somma degli elementi della riga {j} è: {s}");
        }

        private static void SommaElemtiRiga()
        {
            int r = IntroduciNumero("Inserisci il numero di righe della matrice: ");
            int c = IntroduciNumero("Inserisci il numero di colonne della matrice: ", 2, 8);
            int[,] mat = new int[r, c];
            CaricaMatriceCasuale(mat, 1, 301);
            StampaMatrice(mat, "Matrice iniziale: ");
            int i = IntroduciNumero("Riga i in cui sommare gli elementi: ", 0, r-1);
            int s = 0;
            for(int j = 0; j < c; j++)
            {
                s += mat[i, j];
            }
            Console.WriteLine($"La somma degli elementi della riga {i} è: {s}");
        }

        private static void ContaElementoInInput()
        {
            int r = IntroduciNumero("Numero righe della matrice: ");//usa il default min=1, max=10
            int c = IntroduciNumero("Numero colonne della matrice: ", 2, 8);//passo io min e max
            int[,] mat = new int[r, c];
            CaricaMatriceCasuale(mat);
            StampaMatrice(mat, "Matrice iniziale");
            int x = IntroduciNumero("Valore x da cercare: ");
            int conta = 0;
            int i = 0;
            while(i < r)
            {
                int j = 0;
                while(j < c)
                {
                    if (mat[i, j] == x) conta++;
                    j++;
                }
                i++;
            }
            Console.WriteLine($"L'elemento {x} è contenuto {conta} volte nella matrice");
        }

        private static void SommaElementiCorniceEsterna()
        {
            int r = IntroduciNumero("Numero righe della matrice: ");//usa il default min=1, max=10
            int c = IntroduciNumero("Numero colonne della matrice: ", 2, 8);//passo io min e max
            int[,] mat = new int[r, c];
            CaricaMatriceCasuale(mat, 1, 301);
            StampaMatrice(mat, "Matrice iniziale", true);
            int result = 0;
            for (int j = 0; j < c; j++) // riga in alto
                result += mat[0, j];
            for (int j = 0; j < c; j++) // riga in basso
                result += mat[j, c - 1];
            for (int i = 1; i < r - 1; i++) // semi colonna di sinistra
                result += mat[i, 0];
            for (int i = 0; i < r - 1; i++) // semi colonna di destra
                result += mat[r - 1, i];
            Console.WriteLine($"la somma degli elementi della cornice esterna è: {result}");
        }

        private static void CaricaMatriceCasuale(int[,] mat, int min = 1, int max = 10)
        {
            int i = 0;
            while(i  < mat.GetLength(0)) //get legnht,0=numero di righe della matrice
            {
                int j = 0;
                while(j < mat.GetLength(1)) //get legnht, 1=numero di colonne della matrice
                {
                    mat[i,j] = rnd.Next(1, 301);
                    j++;
                }
                i++;
            }
        }
        private static void StampaMatrice(int[,] mat, string messaggio, bool evidenziaCorniceEsterna = false)
        {
            Console.WriteLine(messaggio);
            int i = 0;
            while (i < mat.GetLength(0))
            {
                int j = 0;
                while (j < mat.GetLength(1))
                {
                    if(evidenziaCorniceEsterna && (i == 0 || j == 0 || i == mat.GetLength(0)-1 || j == mat.GetLength(1)-1))
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ResetColor();
                    Console.Write(mat[i,j].ToString().PadLeft(3) + " ");//padleft(3) fa in modo che tutti gli lementi hanno una lunghezza minima di 3 caratteri
                    j++;
                }
                Console.WriteLine($"\n");
                i++;
            }
            Console.ResetColor();
        }

        private static void DecimaleBinario()
        {
            int x = IntroduciValore("Introduci un numero intero positivo: ");
            int [] bit = Convertitore(x);
            StampaVetbit(bit, $"\n\nIl Numero {x} in binario è: ");
        }
        private static int IntroduciValore(string messaggio)
        {
            int x;
            Console.Write(messaggio);
            while (!int.TryParse(Console.ReadLine(), out x) || x < 0)
            {
                Console.Write(messaggio);
            }
            return x;
        }
        private static int[] Convertitore(int x)
        {
            int j = 0;
            int cont = x;
            while (cont > 0 || j == 0)
            {
                if (cont % 2 == 0)
                {
                    cont = cont / 2;
                }
                else
                {
                    cont = (cont - 1) / 2;
                }
                j++;
            }
            int[] bit = new int[j];
            int k = 0;
            while (x > 0 || k == 0)
            {
                if (x % 2 == 0)
                {
                    x = x / 2;
                    bit[k] = 0;
                }
                else
                {
                    x = (x - 1) / 2;
                    bit[k] = 1;
                }
                k++;
            }
            return bit;
        }

        private static void StampaVetbit(int[] bit, string messaggio)
        {
            int i = bit.Length-1;
            Console.Write(messaggio);
            while(i >= 0)
            {
                Console.Write(bit[i]);
                i--;
            }
        }



        private static void FrequenzaGenerazione()
        {
            int[] f = new int[10];
            RandomMilleNumeri(f);
            StampaVet(f, "Risultato del vettore che genera mille numeri random tra 0 e 9: ");
        }
        private static int[] RandomMilleNumeri(int[] f)
        {
            int i = 0;
            while(i < 1000)
            {
                int x = rnd.Next(0, 10);
                f[x]++;
                i++;
            }
            return f;
        }

        private static void StampaVet(int[] vet, string messaggio)
        {
            Console.WriteLine(messaggio);
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine($"{i} è uscito {vet[i]} volte");
                i++;
            }
        }


        private static void CancellaCompatta()
        { 
            int numElem = IntroduciNumero("Numeri elementi del vettore (tra 1 e 24): ", 1, 25);
            int[] a = new int[numElem];
            //Riempi vettore utilizzando ciclo while
            IntroduciVettoreCasuale(a, 1, 25, "\n\nVettore iniziale: ");
            int x = IntroduciNumero("\n\nPosizione elemento da rimuovere: ", 1, numElem);
            x--;
            while (x < numElem - 1)
            {
                a[x] = a[x + 1];
                x++;
            }
            a[numElem - 1] = 0;
            StampaVettore(a, "\n\nVettore Risultato: ");
        }
        private static void IntroduciVettoreCasuale(int[] vet, int min, int max, string messaggio)
        {
            Console.Write(messaggio);
            int i = 0;
            while (i < vet.Length)
            {
                vet[i] = rnd.Next(min, max + 1);
                Console.Write(vet[i] + " ");
                i++;
            }
        }

        private static void StampaVettore(int[] vet, string messaggio)//parametrizzata perchè riceve messaggio
        //riferimento = richiamo nel main, passate per valore perchè non cè ref
        {
            Console.Write(messaggio);
            int i = 0;
            while (i < vet.Length - 1)
            {
                Console.Write(vet[i] + " ");
                i++;
            }
        }

        private static int IntroduciNumero(string messaggio, int min = 1, int max = 10)// int o altri = funzione, 1 e 10 sono dei default e vanno messi per ultimi
        {
            int n;
            do
            {
                Console.Write(messaggio);
            } while (!int.TryParse(Console.ReadLine(), out n) || n < min || n > max);
            return n;
        }
        private static void ScriviMenu()// void = parametro
        {
            Console.Clear();
            Console.WriteLine("1 - Es 28 pag 85 (Elimina e Compatta) ");
            Console.WriteLine("2 - Es 29 pag 85 (Frequenza Generazione) ");
            Console.WriteLine("3 - Es 30 pag 85 (Convertitore Decimale Binario) ");
            Console.WriteLine("4 - Es 31 pag 85 (Somma elementi con indice esterna) ");
            Console.WriteLine("5 - Es 32 pag 85 (Somma elemeti riga) ");
            Console.WriteLine("6 - Es 33 pag 85 (Somma elemeti colonna) ");
            Console.WriteLine("7 - Es 34 pag 85 (Conta elemeto x in input) ");
            Console.WriteLine("8 - Es 35 pag 85 (Somma elementi riga ugale somma elementi colonna) ");
            Console.WriteLine("--------------");
            Console.WriteLine("Q - ESCI");
        }
    }
    
}
