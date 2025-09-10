using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//verificare ordinamento crescente vettore
namespace Ese05_Pag84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Numero elementi del vettore: ");
            } while (!int.TryParse(Console.ReadLine(), out n));//se tryparse non funziona restituisce falso, altrimenti inserisci l'input nella variabile
            int[] a = new int[n];
            Random rand = new Random();
            //carico il vettore con numeri casuali compresi tra 1 e n
            for (int i = 0; i < n; i++)
            {
                a[i] = rand.Next(1, n + 1);//perchè se no slata l'ultimo
            }
            //verifico ordinamento
            //int [] a = { 1,2,3,4,5,6,7};
            int index = -1;//indice
            do
            {
                index++;
            } while (a[index] <= a[index+1] && index < a.Length-2);//a.leght= lunghezza del vettore
            if(index == a.Length-2 && a[index] <= a[index + 1])
            {
                Console.WriteLine("vettore ordinato");
            }
            else
            {
                Console.WriteLine("vettore non ordinato");
            }
            Console.ReadKey();
        }
    }
}
