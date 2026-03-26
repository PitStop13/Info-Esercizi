# 🍳 ThreadKitchen: Multithreading in C# (Windows Forms)

[cite_start]**ThreadKitchen** è un'applicazione didattica progettata per esplorare i concetti fondamentali della programmazione concorrente in C#[cite: 3, 6]. [cite_start]Attraverso la metafora di una cucina di un ristorante, impareremo come gestire più operazioni in parallelo senza bloccare l'interfaccia utente[cite: 7, 8].

---

## 📖 Introduzione al Progetto
[cite_start]In questo laboratorio, ogni cuoco è rappresentato da un **thread separato** che lavora in modo indipendente sugli ingredienti (dati) per completare un piatto[cite: 7, 8]. [cite_start]Il progetto si sviluppa attraverso **5 commit progressivi**, ognuno dei quali introduce un nuovo concetto tecnico o risolve un problema tipico del multithreading[cite: 9].

### 🎯 Obiettivi Formativi
* [cite_start]**Gestione Thread**: Creare e avviare thread con la classe `Thread`[cite: 12].
* [cite_start]**Simulazione**: Utilizzare `Thread.Sleep` per simulare carichi di lavoro variabili[cite: 13].
* [cite_start]**Thread Safety**: Comprendere il problema del *Cross-thread UI* e usare `Control.Invoke`[cite: 14, 15].
* [cite_start]**Sincronizzazione**: Identificare le *Race Condition* e proteggere le sezioni critiche con `lock`[cite: 16, 17].

---

## 🚀 Roadmap dello Sviluppo

| Commit | Titolo | Concetto Introdotto |
| :--- | :--- | :--- |
| **1** | **Setup UI e classe Chef** | [cite_start]Struttura base e separazione tra dati e visualizzazione[cite: 19]. |
| **2** | **Primo thread, primo crash** | [cite_start]Introduzione di `Thread.Sleep` ed errore di accesso cross-thread[cite: 19]. |
| **3** | **Invoke e log sicuro** | [cite_start]Marshalling verso il thread UI per aggiornamenti sicuri[cite: 19]. |
| **4** | **Tutti i cuochi + race condition** | [cite_start]Stato condiviso e bug intenzionale da accesso concorrente[cite: 19]. |
| **5** | **lock e gestione eccezioni** | [cite_start]Risoluzione dei bug con `lock` e pulizia dello stato[cite: 19]. |

---

## 🛠️ Focus: Commit 1 - Setup e Architettura
[cite_start]Il primo step si concentra sulla creazione di una solida base di partenza senza l'uso di thread[cite: 20, 23].

### La Classe `Chef`
[cite_start]Per mantenere una corretta separazione tra logica e interfaccia, abbiamo definito una classe `Chef` che contiene lo stato del cuoco[cite: 24, 25]:
* [cite_start]**Dati**: ID, Nome, Piatto in preparazione[cite: 33, 35, 36].
* [cite_start]**Stato**: Percentuale di avanzamento (`Progress`) e flag di completamento[cite: 38, 41].

### L'Interfaccia Utente (UI)
[cite_start]La `FormMain` è stata progettata per visualizzare in tempo reale l'attività della cucina[cite: 25, 60]:
* [cite_start]**Monitoraggio**: 4 ProgressBar con etichette dinamiche per ogni cuoco[cite: 60, 63].
* [cite_start]**Log della Cucina**: Una `RichTextBox` con stile terminale (sfondo scuro, testo verde) per tracciare le operazioni[cite: 60, 63].
* [cite_start]**Comandi**: Pulsanti per avviare la simulazione e resettare lo stato[cite: 60, 63].

---

## 💡 Riflessione Architetturale
[cite_start]Perché abbiamo creato una classe `Chef` invece di usare direttamente le proprietà dei controlli grafici? [cite: 72]
> [cite_start]**Risposta**: I thread secondari non possono accedere direttamente ai controlli della UI (come le ProgressBar)[cite: 73]. [cite_start]Devono lavorare su oggetti dati normali; sarà poi compito del thread principale leggere questi dati e aggiornare la visualizzazione[cite: 73].

---
[cite_start]*Progetto realizzato per la classe 4ª - Laboratorio di Informatica*[cite: 1].