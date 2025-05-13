using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
                    case '1':
                        Console.Clear();
                        CancellaCompatta();
                        Console.ReadKey(true);
                        break;
                }
                //} while (scelta != 'q' && scelta != 'Q');
            } while (scelta.ToString().ToLower() != "q");
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

        private static int IntroduciNumero(string messaggio, int min, int max)// int o altri = funzione
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
            Console.WriteLine("--------------");
            Console.WriteLine("Q - ESCI");
        }
    }
    
}
