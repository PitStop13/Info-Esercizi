using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese25_Pag85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            const int MAX = 20;
            Random rnd = new Random();
            do
            {
                Console.Write("Insersici il numero di elementi del vettore A (n > 0 & n < MAX): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > MAX);
            do
            {
                Console.Write("\nInsersici il numero di elementi del vettore B (m > 0 & m < MAX): ");
            } while (!int.TryParse(Console.ReadLine(), out m) || m <= 0 || m > MAX);
            int[] A = new int[n], B = new int[m];
            Console.WriteLine("\nVettore A:");
            int i = 0;
            while (i < n)
            {
                int num = rnd.Next(1, MAX + 1);
                bool trovato = false; int j = 0;
                while(!trovato && j < i)
                {
                    if (A[j] == num) trovato = true;
                    else j++;
                }
                if (!trovato) A[i] = num;
                {
                    Console.Write(A[i] + "  ");
                    i++;
                }
            }
            Console.WriteLine("\nVettore B:");
            i = 0;
            while (i < m)
            {
                int num = rnd.Next(1, MAX + 1);
                bool trovato = false; int j = 0;
                while (!trovato && j < i)
                {
                    if (A[j] == num) trovato = true;
                    else j++;
                }
                if (!trovato) B[i] = num;
                {
                    Console.Write(B[i] + "  ");
                    i++;
                }
            }
            //int maxElemVetC;
            //if(n < m)
            //{
            //    maxElemVetC = n;
            //}
            //else
            //{
            //    maxElemVetC = m;
            //}
            int maxElemVetC = n < m ? n : m; //Il numero massimo di elementi di c, che è dato dal più piccolo dei 2. Assegno alla varibale maxElemVetC, n se è verificato, m se non è verificato
            int[] C = new int[maxElemVetC];
            int cnt = 0;
            //for(int z = 0; z < n; z++)
            //{
            //    bool trovato = false;
            //    for(int j = 0; j < m; j++)
            //    {
            //        if (A[z] == B[j]) { trovato = true; break; } // break ci fa uscire dal for
            //    }
            //    if(trovato) { C[cnt++] = A[z]; }
            //}
            for (int z = 0; z < n; z++)
            {
                bool trovato = false;
                int j = 0;
                while (!trovato && j < m) // per sostituire break
                {
                    if (A[z] == B[j]) { trovato = true; }
                    else j++;
                }
                if (trovato) { C[cnt++] = A[z]; }
            }
            Console.WriteLine("\nIl vettore C, dato dall'unione di A e B, è:");
            for (int z = 0; z < cnt; z++)
            {
                Console.Write(C[z] + "  ");
            }
            Console.ReadKey();
        }
    }
}
