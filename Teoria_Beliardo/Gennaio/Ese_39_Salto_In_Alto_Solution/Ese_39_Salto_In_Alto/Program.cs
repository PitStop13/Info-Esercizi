﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ese_39_Salto_In_Alto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] atleti = { "Ambrogio", "Bodoaga", "Borbone", "Burdisso", "Cerone", "Dzeljo", "Ferrero", "Fontana", "Hoxha", "Kardash" };
            string[] nazione = new string[atleti.Length];
            string[] sesso = new string[atleti.Length];
            int[] salti = new int [atleti.Length];

            ClsSalti.CaricaNazioni(nazione);
            ClsSalti.CaricaSesso(sesso);
            ClsSalti.CaricaSalti(salti);

            int scelta;
            do
            {
                scelta = visualizzaMenu();

                switch(scelta)
                {
                    case 1:
                        Console.WriteLine(scelta);
                        break;
                    case 2:
                        Console.WriteLine(scelta);
                        break;
                    case 3:
                        Console.WriteLine(scelta);
                        break;
                    case 4:
                        Console.WriteLine(scelta);
                        break;
                    case 5:
                        Console.WriteLine(scelta);
                        break;
                    case 6:
                        Console.WriteLine(scelta);
                        break;
                    case 7:
                        Console.WriteLine(scelta);
                        break;
                    default:
                        Console.WriteLine(scelta);
                        break;
                }
                Console.ReadKey();

            } while (scelta != 0);
        }

        private static int visualizzaMenu()
        {
            int sc;
            Console.Clear();
            Console.WriteLine("--- SALTO IN ALTO ---");
            Console.WriteLine("1: Visualizza Dati");
            Console.WriteLine("2: Classifica Generale");
            Console.WriteLine("3: Media Salti Nazione in Input");
            Console.WriteLine("4: Media Salti di ogni Nazione");
            Console.WriteLine("5: Classifica per Nazioni");
            Console.WriteLine("6: Media Salti uomini e donne");
            Console.WriteLine("7: Cercare i vinctori M e F della nazione prima classificata");
            Console.WriteLine("0: Esci");
            while (!int.TryParse(Console.ReadLine(), out sc) && sc <= 7 && sc >= 0) ;
            return sc;
        }
    }
}
