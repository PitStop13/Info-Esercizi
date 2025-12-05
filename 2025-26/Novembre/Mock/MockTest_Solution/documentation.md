# Manuale Approfondito dello Sviluppatore - MockTest Application

Questa guida è pensata per portarti da zero alla completa comprensione del codice. Non daremo nulla per scontato. Analizzeremo **perché** il codice è scritto in questo modo e **come** ogni pezzo si incastra con gli altri.

---

## Indice
1.  [Concetti Fondamentali](#1-concetti-fondamentali)
2.  [Analisi Dettagliata: Le Entità](#2-analisi-dettagliata-le-entità)
3.  [Analisi Dettagliata: Il Database (File System)](#3-analisi-dettagliata-il-database-file-system)
4.  [Analisi Dettagliata: L'Interfaccia (Windows Forms)](#4-analisi-dettagliata-linterfaccia-windows-forms)
5.  [Analisi Dettagliata: Algoritmi e Statistiche](#5-analisi-dettagliata-algoritmi-e-statistiche)
6.  [Tutorial: Ricostruire il Progetto da Zero](#6-tutorial-ricostruire-il-progetto-da-zero)

---

## 1. Concetti Fondamentali

Prima di guardare il codice, capiamo l'architettura.
Il programma segue il pattern **Separation of Concerns** (Separazione delle Responsabilità), anche se in modo semplificato:

*   **Dati (Model)**: Le classi come `Studente`, `Voto`. Non sanno nulla della grafica o del salvataggio. Sono solo contenitori.
*   **Logica Dati (Data Access Layer)**: La classe `DatabaseMock`. Si occupa SOLO di leggere e scrivere file. Non sa nulla di bottoni o finestre.
*   **Interfaccia (UI)**: Il `FormMain`. Si occupa di mostrare i dati e prendere l'input dell'utente. Chiama la Logica Dati per salvare.

---

## 2. Analisi Dettagliata: Le Entità

Prendiamo `Studente.cs` come esempio. È la base di tutto.

```csharp
public class Studente
{
    // PROPRIETÀ (Properties)
    // get; set; permette di leggere e scrivere il valore.
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime DataNascita { get; set; }
    
    // FOREIGN KEY (Chiave Esterna)
    // Questo ID collega lo studente a una Classe specifica.
    // Non salviamo l'oggetto "Classe" intero qui, ma solo il suo ID.
    public int ClasseId { get; set; }

    // OVERRIDE DI TOSTRING
    // Quando metti un oggetto in una ListBox, C# chiama automaticamente questo metodo
    // per decidere cosa scrivere a schermo.
    public override string ToString()
    {
        // $"" è la String Interpolation: permette di inserire variabili direttamente nella stringa.
        return $"{Id} - {Nome} - {Cognome} - {DataNascita.ToString("yyyy-MM-dd")} - {ClasseId}";
    }
}
```

**Perché è fatto così?**
Usare classi semplici (POCO - Plain Old CLR Objects) rende facile passare i dati in giro. Se dovessimo aggiungere un campo "Email", lo aggiungeremmo qui e poi aggiorneremmo il DatabaseMock.

---

## 3. Analisi Dettagliata: Il Database (File System)

Il file `DatabaseMock.cs` simula un database SQL usando file di testo CSV (Comma Separated Values).

### La Lettura (`GetStudenti`)
Analizziamo riga per riga cosa succede quando leggi i dati.

```csharp
public List<Studente> GetStudenti()
{
    // 1. Creiamo una lista vuota pronta ad accogliere i dati.
    List<Studente> studenti = new List<Studente>();
    
    // 2. Apriamo il file. StreamReader è la classe .NET per leggere testo.
    // NOTA: Se il file non esiste, questo codice darà errore! (Andrebbe gestito con File.Exists)
    StreamReader sr = new StreamReader("studenti.txt");
    string[] s; // Variabile temporanea per i pezzi della riga

    // 3. Ciclo While: "Finché non sono arrivato alla fine del file..."
    while (!sr.EndOfStream)
    {
        // 4. Istanziamo un nuovo studente vuoto per ogni riga.
        Studente studente = new Studente();

        // 5. Leggiamo la riga e la "spacchiamo" (Split).
        // Riga nel file: "1;Mario;Rossi;2005-01-01;1"
        // Diventa array s: ["1", "Mario", "Rossi", "2005-01-01", "1"]
        s = sr.ReadLine().Split(';');

        // 6. Assegnazione e Conversione (Parsing)
        // I file di testo contengono solo stringhe. Dobbiamo convertirle in numeri (int) o date (DateTime).
        studente.Id = int.Parse(s[0]);          // "1" -> 1
        studente.Nome = s[1];                   // "Mario" -> "Mario"
        studente.Cognome = s[2];                // "Rossi" -> "Rossi"
        studente.DataNascita = DateTime.Parse(s[3]); // "2005-01-01" -> Oggetto Data
        studente.ClasseId = int.Parse(s[4]);    // "1" -> 1

        // 7. Aggiungiamo lo studente completo alla lista.
        studenti.Add(studente);
    }
    
    // 8. CHIUDERE SEMPRE IL FILE. Se non lo fai, il file rimane bloccato e non puoi scriverci sopra.
    sr.Close();

    return studenti;
}
```

### La Scrittura (`AddStudente` e `SaveStudentFile`)
Per aggiungere un dato, usiamo una tecnica semplice ma poco efficiente:
1.  Leggiamo TUTTO il file in memoria (`GetStudenti`).
2.  Aggiungiamo il nuovo elemento alla lista in memoria.
3.  Sovrascriviamo TUTTO il file con la nuova lista.

```csharp
private void SaveStudentFile(List<Studente> studenti)
{
    // StreamWriter apre il file in scrittura.
    // Senza parametri aggiuntivi, cancella il contenuto precedente e parte da zero.
    StreamWriter sw = new StreamWriter("studenti.txt");

    foreach (Studente studente in studenti)
    {
        // Ricostruiamo la stringa CSV con i punti e virgola.
        string s = $"{studente.Id};{studente.Nome};{studente.Cognome};{studente.DataNascita};{studente.ClasseId}";
        
        // Scriviamo la riga.
        sw.WriteLine(s);
    }
    sw.Close(); // Fondamentale per salvare effettivamente i dati su disco.
}
```

---

## 4. Analisi Dettagliata: L'Interfaccia (Windows Forms)

In `FormMain.cs`, tutto è guidato dagli **Eventi**. Il programma sta fermo finché l'utente non fa qualcosa (clicca, scrive).

### Validazione dell'Input (`CheckStudentValidation`)
Prima di salvare, dobbiamo essere sicuri che l'utente non abbia scritto sciocchezze (es. lettere al posto dell'ID).

```csharp
private bool CheckStudentValidation()
{
    // Controllo 1: I campi non devono essere vuoti
    if (txtIdStudente.Text != "" && txtNomeStudente.Text != "" ...)
    {
        // Controllo 2: I tipi devono essere giusti.
        // int.TryParse prova a convertire. Se riesce, restituisce true e mette il valore in 'testInt1'.
        // Se fallisce (es. utente scrive "ciao" nel campo ID), restituisce false.
        if (int.TryParse(txtIdStudente.Text, out int testInt1) && 
            DateTime.TryParse(txtDataNascitaStudente.Text, out DateTime dateTest))
        {
            return true; // Tutto ok!
        }
    }
    return false; // Qualcosa non va.
}
```

### Gestione dello Stato (Abilitare/Disabilitare)
Noterai che spesso si abilita/disabilita (`Enabled = true/false`) o si nasconde (`Visible = true/false`) parti della UI.
Questo serve a guidare l'utente.
*   Se sto aggiungendo uno studente, l'ID deve essere scrivibile.
*   Se sto modificando uno studente esistente, l'ID **non** deve cambiare (è la chiave primaria!), quindi lo disabilito (`txtIdStudente.Enabled = false`).

---

## 5. Analisi Dettagliata: Algoritmi e Statistiche

Il metodo `CalcolaMediaVotiPerClasseEMateria` è interessante perché fa una **JOIN** manuale. Immagina di avere due fogli Excel: Studenti e Voti.

1.  **Filtro Studenti**: "Dammi tutti gli ID degli studenti della classe 3A".
    ```csharp
    List<int> ids = new List<int>();
    foreach (Studente s in studenti) {
        if (s.ClasseId == classeId) ids.Add(s.Id);
    }
    ```
    Risultato: `ids = [1, 2, 5]`

2.  **Filtro Voti e Calcolo**: "Scorri tutti i voti. Se il voto è di Matematica E l'ID dello studente è nella lista [1, 2, 5], allora contalo."
    ```csharp
    foreach (Voto v in voti) {
        if (v.MateriaId == materiaId) { // È Matematica?
            if (ids.Contains(v.StudenteId)) { // È uno studente della 3A?
                somma += v.Valore;
                cont++;
            }
        }
    }
    ```

---

## 6. Tutorial: Ricostruire il Progetto da Zero

Vuoi rifarlo? Ecco la roadmap esatta.

### Fase 1: Setup
1.  Apri Visual Studio -> Nuovo Progetto -> **Windows Forms App (.NET Framework)**.
2.  Chiamalo "GestioneScuola".

### Fase 2: Le Entità
1.  Tasto destro sul progetto -> Aggiungi -> Classe. Chiamala `Studente.cs`.
2.  Copia il codice della classe `Studente` (vedi capitolo 2).
3.  Ripeti per `Classe.cs`, `Materia.cs`, `Voto.cs`.

### Fase 3: Il Database
1.  Aggiungi classe `DatabaseMock.cs`.
2.  Aggiungi `using System.IO;` in cima.
3.  Scrivi il metodo `GetStudenti()` e `SaveStudentFile()`.
4.  Crea manualmente un file `studenti.txt` nella cartella `bin/Debug` del progetto per fare i primi test, oppure gestisci il caso in cui il file non esiste (creandolo vuoto).

### Fase 4: La UI (Design)
1.  Apri `Form1.cs` (Design).
2.  Trascina una `ListBox` (`lstStudenti`).
3.  Trascina un `Button` (`btnLeggi`).
4.  Trascina TextBox per Nome, Cognome, ecc.
5.  Trascina un `Button` (`btnAggiungi`).

### Fase 5: Il Codice UI
1.  Doppio click su `btnLeggi`.
    ```csharp
    DatabaseMock db = new DatabaseMock();
    var lista = db.GetStudenti();
    lstStudenti.Items.Clear();
    foreach(var s in lista) lstStudenti.Items.Add(s);
    ```
2.  Doppio click su `btnAggiungi`.
    ```csharp
    // ... leggi textbox ...
    Studente s = new Studente { Id = ..., Nome = ... };
    db.AddStudente(s);
    // ... ricarica lista ...
    ```

### Fase 6: Debug
1.  Avvia con F5.
2.  Metti dei **Breakpoint** (pallino rosso a sinistra del codice) dentro `GetStudenti` per vedere passo-passo se legge il file correttamente.
