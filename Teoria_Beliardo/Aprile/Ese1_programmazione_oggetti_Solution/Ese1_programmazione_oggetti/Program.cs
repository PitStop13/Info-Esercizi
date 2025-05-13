using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ese1_programmazione_oggetti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                +---------------------------------+
                |           Persona               |
                +---------------------------------+
                | -nome: string                   |
                | -cognome: string                |
                | -eta: int                       |
                | -indirizzo: string              |
                +---------------------------------+
                | +Persona(nome, cognome, eta)    |
                | +Nome: string { get; set; }     |
                | +Cognome: string { get; set; }  |
                | +Eta: int { get; set; }         |
                | +Indirizzo: string { get; set; }|
                +---------------------------------+
            */
            ClsPersona persona1 = new ClsPersona("Mario", "Rossi", 32, "Via Roma 34");
            Console.WriteLine($"Nome: {persona1.Nome}, Cognome: {persona1.Cognome}, Età: {persona1.Eta}, Indirizzo: {persona1.Indirizzo}");
            // Setto l'età a -9 per chidere all'utente di inserire un nome valido
            Console.WriteLine("Provo a impostare età a -9");
            persona1.Eta = -9;
            Console.WriteLine($"Età correnete: {persona1.Eta}");
            ClsPersona persona2 = new ClsPersona("Matteo", "Marino", 14, "Piazza Dante 45");
            // Setto il nome a "" per chidere all'utente di inserire un nome valido
            Console.WriteLine("Provo a impostare nome a stringa vuota");
            persona2.Nome = "";
            Console.WriteLine($"Nome: {persona2.Nome}, Cognome: {persona2.Cognome}, Età: {persona2.Eta}, Indirizzo: {persona2.Indirizzo}");
            /*
                +---------------------------------------+
                |           ContoBancario               |
                +---------------------------------------+
                | -numeroConto: string                  |
                | -saldo: double                        |
                +---------------------------------------+
                | +ContoBancario(numeroConto, saldo)    |
                | +NumeroConto: string { get; set; }    |
                | +Saldo: string { get; set; }          |
                | +Deposita(importo): saldo += importo; |
                | +Preleva(importo): saldo -= importo;  |
                +---------------------------------------+
            */
            ClsContoBancario conto1 = new ClsContoBancario("1A6O3VCD6HE40", 100);
            Console.WriteLine($"Numero conto: {conto1.NumeroConto}, Saldo: {conto1.Saldo}");
            // Aggiungo 75 al conto1
            Console.WriteLine("Deposito 75.5");
            conto1.Deposita(75.5);
            Console.WriteLine($"Saldo correnete: {conto1.Saldo}");
            // Toglo 176 per chidere all'utente di inserire un importo da prelevare valido
            Console.WriteLine("Provo a prelevare 176");
            conto1.Preleva(176);
            Console.WriteLine($"Saldo correnete: {conto1.Saldo}");
            Console.ReadKey();
            
        }
    }
}
