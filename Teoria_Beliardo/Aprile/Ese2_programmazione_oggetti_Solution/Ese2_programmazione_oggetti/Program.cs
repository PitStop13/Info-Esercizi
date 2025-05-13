using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ese2_programmazione_oggetti;

namespace Ese1_programmazione_oggetti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                +-----------------------------------------+
                |                 Persona                 |
                +-----------------------------------------+
                | -nome: string                           |
                | -cognome: string                        |
                | -eta: int                               |
                | -indirizzo: string                      |
                | -EmptyStringException : Exception       |
                | -InvalidStringException : Exception     |
                | -NumBelowZeroException : Exception      |
                +-----------------------------------------+
                | +Persona(nome, cognome, eta)            |
                | +Nome: string { get; set; }             |
                | +Cognome: string { get; set; }          |
                | +Eta: int { get; set; }                 |
                | +Indirizzo: string { get; set; }        |
                +-----------------------------------------+
            */
            ClsPersona persona1 = new ClsPersona("Mario", "Rossi", 32, "Via Roma 34");
            Console.WriteLine($"Nome: {persona1.Nome}, Cognome: {persona1.Cognome}, Età: {persona1.Eta}, Indirizzo: {persona1.Indirizzo}");
            // Setto l'età a -9 per chidere all'utente di inserire un nome valido
            /*Console.WriteLine("Provo a impostare età a -9");
            persona1.Eta = -9;
            Console.WriteLine($"Età correnete: {persona1.Eta}");*/
            ClsPersona persona2 = new ClsPersona("Matteo", "Marino", 14, "Piazza Dante 45");
            // Setto il nome a "" per chidere all'utente di inserire un nome valido
            /*Console.WriteLine("Provo a impostare nome a stringa vuota");
            persona2.Nome = "";
            Console.WriteLine($"Nome: {persona2.Nome}, Cognome: {persona2.Cognome}, Età: {persona2.Eta}, Indirizzo: {persona2.Indirizzo}");*/
            // Esercizio 2.2
            /*
                +------------------------------------+
                |            Calcolatore             |
                +------------------------------------+
                | +Somma(int a, int b): int          |
                | +Somma(double a, double b): double |
                | +Somma(int a, int b, int c): int   |
                +------------------------------------+
            */
            ClsCalcolatore calcolo = new ClsCalcolatore();
            int somma2Int = calcolo.Somma(1, 2);
            Console.WriteLine($"1 + 2 = {somma2Int}");
            double somma2Double = calcolo.Somma(2.3, 3.76);
            Console.WriteLine($"2.3 + 3.76 = {somma2Double}");
            int somma3Int = calcolo.Somma(1, 2, 3);
            Console.WriteLine($"1 + 2 + 3 = {somma3Int}");
            // Esercizio B
            /*
                +-----------------------------------------------+
                |              Prodotto                         |
                +-----------------------------------------------+
                | -nome: string                                 |
                | -prezzo: double                               |
                | -NumBelowZeroException : Exception            |
                +-----------------------------------------------+
                | +AggiornaPrezzo(double prezzo)                |
                | +AggiornaPrezzo(double prezzo, double sconto) |
                +-----------------------------------------------+
            */
            ClsProdotto prodotto1 = new ClsProdotto("Coca Cola", 12.5);
            Console.WriteLine($"Prodotto: {prodotto1.Nome}, Prezzo: {prodotto1.Prezzo}");
            prodotto1.AggiornaPrezzo(13);
            prodotto1.AggiornaPrezzo(13, 3);
            Console.ReadKey();
        }
    }
}
