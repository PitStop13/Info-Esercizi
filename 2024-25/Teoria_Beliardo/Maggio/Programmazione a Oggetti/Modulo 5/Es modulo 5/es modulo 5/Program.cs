using System;
using System.Collections.Generic;

namespace es_modulo_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inizializzazione delle strutture dati
            List<Studente> listaStudenti = new List<Studente>();  // Lista di tutti gli studenti
            Dictionary<int, Studente> rubrica = new Dictionary<int, Studente>();  // Dizionario per accesso rapido
            Queue<string> listaAttesa = new Queue<string>();  // Lista d'attesa per l'aggiunta degli studenti
            Stack<Action> operazioniUndo = new Stack<Action>();  // Stack per le operazioni di undo

            bool continua = true;
            while (continua)
            {
                // Menu per l'interazione con l'utente
                Console.Clear();
                Console.WriteLine("Rubrica Studenti");
                Console.WriteLine("1. Aggiungi studente");
                Console.WriteLine("2. Rimuovi studente");
                Console.WriteLine("3. Cerca studente");
                Console.WriteLine("4. Visualizza tutti gli studenti");
                Console.WriteLine("5. Visualizza lista d'attesa");
                Console.WriteLine("6. Undo ultima operazione");
                Console.WriteLine("7. Esci");
                Console.Write("Scegli un'operazione: ");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": // Aggiungi studente
                        Console.WriteLine("\nAggiungi Studente");

                        // Inserimento sicuro dell'ID
                        int id;
                        while (true)
                        {
                            Console.Write("Inserisci ID: ");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ID non valido. Per favore inserisci un numero intero.");
                            }
                        }

                        Console.Write("Inserisci Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Inserisci Cognome: ");
                        string cognome = Console.ReadLine();

                        // Creazione dello studente
                        Studente studente = new Studente(id, nome, cognome);
                        listaStudenti.Add(studente);  // Aggiungi alla lista
                        rubrica[id] = studente;  // Aggiungi al dizionario
                        listaAttesa.Enqueue($"Aggiunto studente {nome} {cognome}");  // Aggiungi alla lista d'attesa

                        // Memorizza l'operazione di undo (rimuovere lo studente)
                        operazioniUndo.Push(() =>
                        {
                            listaStudenti.Remove(studente);  // Rimuovi dalla lista
                            rubrica.Remove(id);  // Rimuovi dal dizionario
                            Console.WriteLine($"Studente {nome} {cognome} rimosso (Undo).");
                        });

                        Console.WriteLine("\nStudente aggiunto con successo.");
                        Console.ReadLine();
                        break;

                    case "2": // Rimuovi studente
                        Console.WriteLine("\nRimuovi Studente");

                        // Inserimento sicuro dell'ID
                        int idRimuovere;
                        while (true)
                        {
                            Console.Write("Inserisci ID studente da rimuovere: ");
                            if (int.TryParse(Console.ReadLine(), out idRimuovere))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ID non valido. Per favore inserisci un numero intero.");
                            }
                        }

                        if (rubrica.ContainsKey(idRimuovere))
                        {
                            Studente studenteDaRimuovere = rubrica[idRimuovere];
                            listaStudenti.Remove(studenteDaRimuovere);  // Rimuovi dalla lista
                            rubrica.Remove(idRimuovere);  // Rimuovi dal dizionario
                            operazioniUndo.Push(() =>
                            {
                                listaStudenti.Add(studenteDaRimuovere);  // Aggiungi di nuovo alla lista
                                rubrica[idRimuovere] = studenteDaRimuovere;  // Aggiungi di nuovo al dizionario
                                Console.WriteLine($"Studente {studenteDaRimuovere.Nome} {studenteDaRimuovere.Cognome} ripristinato (Undo).");
                            });

                            Console.WriteLine("\nStudente rimosso con successo.");
                        }
                        else
                        {
                            Console.WriteLine("\nStudente non trovato.");
                        }
                        Console.ReadLine();
                        break;

                    case "3": // Cerca studente
                        Console.WriteLine("\nCerca Studente");

                        // Inserimento sicuro dell'ID
                        int idCercare;
                        while (true)
                        {
                            Console.Write("Inserisci ID studente da cercare: ");
                            if (int.TryParse(Console.ReadLine(), out idCercare))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ID non valido. Per favore inserisci un numero intero.");
                            }
                        }

                        if (rubrica.ContainsKey(idCercare))
                        {
                            Studente studenteTrovato = rubrica[idCercare];
                            Console.WriteLine($"\nStudente trovato: {studenteTrovato}");
                        }
                        else
                        {
                            Console.WriteLine("\nStudente non trovato.");
                        }
                        Console.ReadLine();
                        break;

                    case "4": // Visualizza tutti gli studenti
                        Console.WriteLine("\nElenco Studenti:");
                        foreach (var stud in listaStudenti)
                        {
                            Console.WriteLine(stud);
                        }
                        Console.ReadLine();
                        break;

                    case "5": // Visualizza lista d'attesa
                        Console.WriteLine("\nLista d'attesa:");
                        foreach (var operazione in listaAttesa)
                        {
                            Console.WriteLine(operazione);
                        }
                        Console.ReadLine();
                        break;

                    case "6": // Undo ultima operazione
                        if (operazioniUndo.Count > 0)
                        {
                            Action ultimaOperazione = operazioniUndo.Pop();
                            ultimaOperazione();  // Esegui l'azione di undo
                            Console.WriteLine("\nUltima operazione annullata.");
                        }
                        else
                        {
                            Console.WriteLine("\nNessuna operazione da annullare.");
                        }
                        Console.ReadLine();
                        break;

                    case "7": // Esci
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("\nOpzione non valida.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}