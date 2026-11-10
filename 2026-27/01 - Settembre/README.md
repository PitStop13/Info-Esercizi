# 📘 GUIDA DEFINITIVA SQL PER LA VERIFICA
> **Focus:** Risoluzione intuitiva, pattern ricorrenti delle verifiche, sintassi con `WHERE` (senza `JOIN` espliciti) e analisi completa di tutti gli esercizi.

---

## 📑 INDICE RAPIDO
1. [La Struttura Mentale di una Query (I 5 Passi)](#1-la-struttura-mentale-di-una-query-i-5-passi)
2. [Collegare le Tabelle con il `WHERE` (Il tuo metodo preferito)](#2-collegare-le-tabelle-con-il-where)
3. [Funzioni di Aggregazione e Calcoli](#3-funzioni-di-aggregazione-e-calcoli)
4. [`GROUP BY` e `HAVING` spiegati semplice](#4-group-by-e-having-spiegati-semplice)
5. [I 7 Pattern "Killer" della Verifica (Le Formule Pronte)](#5-i-7-pattern-killer-della-verifica)
   - [Pattern 1: "Nessuno / Non ha mai..."](#pattern-1-nessuno--non-ha-mai)
   - [Pattern 2: "Per ogni X il conteggio/somma di Y"](#pattern-2-per-ogni-x-il-conteggiosomma-di-y)
   - [Pattern 3: Filtro su aggregati ("con più di 5...")](#pattern-3-filtro-su-aggregati-con-più-di-5)
   - [Pattern 4: "SOLO..." (Il trucco della doppia condizione)](#pattern-4-solo-il-trucco-della-doppia-condizione)
   - [Pattern 5: "TUTTI..." (La Divisione Relazionale)](#pattern-5-tutti-la-divisione-relazionale)
   - [Pattern 6: "Il primo / L'ultimo"](#pattern-6-il-primo--lultimo)
   - [Pattern 7: Date, Età e Valori Nulli (`IS NULL`)](#pattern-7-date-età-e-valori-nulli-is-null)
6. [Analisi e Soluzioni: 05 - Romanzi Ripasso (Query 1 - 10)](#6-analisi-e-soluzioni-05---romanzi-ripasso)
7. [Analisi e Soluzioni: 06 - Scuola Ripasso (Query 1 - 13)](#7-analisi-e-soluzioni-06---scuola-ripasso)
8. [Check-list anti-errore prima di consegnare](#8-check-list-anti-errore-prima-di-consegnare)

---

## 1. La Struttura Mentale di una Query (I 5 Passi)

Quando leggi il testo di un esercizio, **non iniziare a scrivere a caso**. Segui sempre questo ordine:

```
Testo: "Il titolo dei romanzi di autori russi pubblicati dopo il 1900"
```

1. **Passo 1: Da dove prendo i dati? (`FROM`)**
   - Quali tabelle contengono i dati richiesti e i filtri?
   - Qui servono i titoli (stanno in `ROMANZI`) e la nazionalità dell'autore (sta in `AUTORI`).
   - Quindi: `FROM ROMANZI r, AUTORI a`

2. **Passo 2: Come collego le tabelle? (`WHERE` - condizioni di Join)**
   - Qual è la chiave che unisce le tabelle?
   - `r.NomeAut = a.NomeAut`

3. **Passo 3: Quali filtri applicare alle singole righe? (`WHERE` - filtri)**
   - Autori russi: `a.Nazione = 'Russa'`
   - Pubblicati dopo il 1900: `r.Anno > 1900`

4. **Passo 4: Devo raggruppare o calcolare totali? (`GROUP BY` / `HAVING`)**
   - Nel testo c'è scritto "per ogni...", "numero di...", "totale..."?
   - No? Allora niente `GROUP BY`.

5. **Passo 5: Cosa vuole vedere il professore? (`SELECT`)**
   - Il titolo dei romanzi: `SELECT r.Titolo`

---

## 2. Collegare le Tabelle con il `WHERE`

Poiché preferisci non usare `INNER JOIN ... ON ...`, la sintassi naturale è:

```sql
SELECT Colonne
FROM Tabella1 t1, Tabella2 t2, Tabella3 t3
WHERE t1.ChiaveEsterna = t2.ChiavePrimaria
  AND t2.ChiaveEsterna = t3.ChiavePrimaria
  AND CondizioniDiFiltro;
```

### ⚠️ Regola Fondamentale del Prodotto Cartesiano:
Se metti **N tabelle** nel `FROM`, devi avere **almeno N - 1 condizioni di collegamento** nel `WHERE`.
- 2 tabelle ➡️ **1** collegamento (`t1.id = t2.id_t1`)
- 3 tabelle ➡️ **2** collegamenti
- 4 tabelle ➡️ **3** collegamenti
Se dimentichi un collegamento, il database fa un prodotto cartesiano totale e ti restituisce dati moltiplicati e sballati!

---

## 3. Funzioni di Aggregazione e Calcoli

Le 5 funzioni base operano su insiemi di righe:

| Funzione | Cosa fa | Esempio |
| :--- | :--- | :--- |
| `COUNT(*)` | Conta tutte le righe (anche con campi nulli) | `COUNT(*)` |
| `COUNT(colonna)` | Conta le righe in cui `colonna` non è NULL | `COUNT(f.Matricola)` |
| `COUNT(DISTINCT col)` | Conta i valori diversi, senza duplicati | `COUNT(DISTINCT CodiceR)` |
| `SUM(colonna)` | Somma i valori numerici | `SUM(Incasso)` |
| `AVG(colonna)` | Calcola la media aritmetica | `AVG(AnnoN)` |
| `MIN(colonna)` | Trova il valore minimo (il più vecchio/piccolo) | `MIN(Anno)` |
| `MAX(colonna)` | Trova il valore massimo (il più recente/grande) | `MAX(Anno)` |

---

## 4. `GROUP BY` e `HAVING` spiegati semplice

Questo è il punto in cui molti studenti si bloccano. Ecco la regola definitiva.

### Quando serve il `GROUP BY`?
Ogni volta che la domanda dice:
- **"Per ogni autore..."** ➡️ `GROUP BY NomeAut`
- **"Per ogni corso..."** ➡️ `GROUP BY CodCorso`
- **"Per ciascuna città..."** ➡️ `GROUP BY Citta`

### 👑 La Regola d'Oro del `GROUP BY`:
> **Tutto ciò che metti nella `SELECT` che NON è dentro una funzione di aggregazione (`COUNT`, `SUM`, `AVG`, `MIN`, `MAX`), DEVE comparire OBBLIGATORIAMENTE nella clausola `GROUP BY`!**

```sql
-- CORRETTO:
SELECT a.NomeAut, COUNT(r.CodiceR)
FROM AUTORI a, ROMANZI r
WHERE a.NomeAut = r.NomeAut
GROUP BY a.NomeAut;

-- SBAGLIATO (Dà errore di compilazione SQL Server):
SELECT a.NomeAut, a.Nazione, COUNT(r.CodiceR)
FROM AUTORI a, ROMANZI r
WHERE a.NomeAut = r.NomeAut
GROUP BY a.NomeAut; -- ERRORE: manca a.Nazione nel GROUP BY!
```

### Differenza tra `WHERE` e `HAVING`
- `WHERE`: Filtra le **singole righe PRIMA** che vengano raggruppate.
  - *Non può MAI contenere funzioni come `COUNT(*) > 2`!*
- `HAVING`: Filtra i **gruppi DOPO** che sono stati calcolati.
  - *Si usa per condizioni sui risultati delle funzioni aggregate: `HAVING COUNT(*) > 2`.*

---

## 5. I 7 Pattern "Killer" della Verifica

I professori costruiscono le verifiche su questi 7 schemi. Memorizza queste formule!

---

### Pattern 1: "Nessuno / Non ha mai..."
*Esempio: "I romanzi dai quali NON è stato tratto un film" oppure "Gli studenti che non frequentano nessun corso".*

#### Formula con `NOT IN`:
```sql
SELECT r.Titolo
FROM ROMANZI r
WHERE r.CodiceR NOT IN (
    SELECT f.CodiceR
    FROM FILM f
);
```

#### Formula con `NOT EXISTS`:
```sql
SELECT r.Titolo
FROM ROMANZI r
WHERE NOT EXISTS (
    SELECT *
    FROM FILM f
    WHERE f.CodiceR = r.CodiceR
);
```
💡 **Consiglio:** `NOT IN` è più veloce da scrivere e più intuitivo: "Prendi i romanzi il cui codice NON sta nella lista dei codici presenti nei film".

---

### Pattern 2: "Per ogni X il conteggio/somma di Y"
*Esempio: "Per ogni autore italiano, il numero di romanzi scritti".*

```sql
SELECT a.NomeAut, COUNT(r.CodiceR) AS NumeroRomanzi
FROM AUTORI a, ROMANZI r
WHERE a.NomeAut = r.NomeAut
  AND a.Nazione = 'Italiana'
GROUP BY a.NomeAut;
```

---

### Pattern 3: Filtro su aggregati ("con più di 5...")
*Esempio: "I corsi frequentati da più di 5 studenti".*

```sql
SELECT f.CodCorso, COUNT(f.Matricola) AS NumStudenti
FROM FREQUENTA f
GROUP BY f.CodCorso
HAVING COUNT(f.Matricola) > 5;
```

---

### Pattern 4: "SOLO..." (Il trucco della doppia condizione)
*Esempio: "Gli studenti che seguono SOLO corsi di Storia" oppure "I corsi frequentati SOLO da studenti di SBC".*

In logica, dire che uno studente segue **SOLO** corsi di Storia significa due cose:
1. Deve seguire **almeno un corso** (altrimenti non segue nulla!).
2. **NON deve esistere** alcun corso seguito da lui che **NON** sia di Storia!

#### Formula Pronta con `IN` e `NOT IN`:
```sql
SELECT s.Matricola, s.NomeS
FROM STUDENTI s
WHERE s.Matricola IN (
    -- 1. Segue almeno un corso
    SELECT f.Matricola 
    FROM FREQUENTA f
)
AND s.Matricola NOT IN (
    -- 2. Non segue NESSUN corso che NON sia di Storia
    SELECT f.Matricola
    FROM FREQUENTA f, CORSI c, DOCENTI d
    WHERE f.CodCorso = c.CodCorso
      AND c.CodDocente = d.CodDocente
      AND d.Dipartimento <> 'Storia'
);
```

#### Alternativa con `EXISTS` e `NOT EXISTS`:
```sql
SELECT s.Matricola, s.NomeS
FROM STUDENTI s
WHERE EXISTS (
    SELECT *
    FROM FREQUENTA f, CORSI c, DOCENTI d
    WHERE f.Matricola = s.Matricola
      AND f.CodCorso = c.CodCorso
      AND c.CodDocente = d.CodDocente
      AND d.Dipartimento = 'Storia'
)
AND NOT EXISTS (
    SELECT *
    FROM FREQUENTA f, CORSI c, DOCENTI d
    WHERE f.Matricola = s.Matricola
      AND f.CodCorso = c.CodCorso
      AND c.CodDocente = d.CodDocente
      AND d.Dipartimento <> 'Storia'
);
```

---

### Pattern 5: "TUTTI..." (La Divisione Relazionale)
*Esempio: "I corsi che sono frequentati da TUTTI gli studenti del corso di laurea SBC".*

Ci sono due modi per farlo:

#### Metodo A: Il Trucco del Conteggio (CONSIGLIATO - Intuitivo e semplice)
Se gli studenti di SBC sono 3, un corso è frequentato da "tutti gli studenti di SBC" se il numero di studenti distinti di SBC che lo frequentano è uguale a 3!
```sql
SELECT f.CodCorso
FROM FREQUENTA f, STUDENTI s
WHERE f.Matricola = s.Matricola
  AND s.CorsoLaurea = 'SBC'
GROUP BY f.CodCorso
HAVING COUNT(DISTINCT f.Matricola) = (
    SELECT COUNT(*)
    FROM STUDENTI
    WHERE CorsoLaurea = 'SBC'
);
```

#### Metodo B: Doppio `NOT EXISTS` (Metodo teorico accademico)
"Seleziona i corsi per i quali NON esiste alcuno studente di SBC per cui NON esista la frequenza":
```sql
SELECT c.CodCorso
FROM CORSI c
WHERE NOT EXISTS (
    SELECT *
    FROM STUDENTI s
    WHERE s.CorsoLaurea = 'SBC'
      AND NOT EXISTS (
          SELECT *
          FROM FREQUENTA f
          WHERE f.CodCorso = c.CodCorso
            AND f.Matricola = s.Matricola
      )
);
```

---

### Pattern 6: "Il primo / L'ultimo"
*Esempio: "L'anno del primo e dell'ultimo romanzo di ogni autore".*
- Primo anno ➡️ `MIN(Anno)`
- Ultimo anno ➡️ `MAX(Anno)`

```sql
SELECT a.NomeAut, MIN(r.Anno) AS PrimoAnno, MAX(r.Anno) AS UltimoAnno
FROM AUTORI a, ROMANZI r
WHERE a.NomeAut = r.NomeAut
GROUP BY a.NomeAut;
```

---

### Pattern 7: Date, Età e Valori Nulli (`IS NULL`)
- Autori viventi: `WHERE AnnoM IS NULL` (MAI fare `= NULL`, in SQL si usa sempre `IS NULL` o `IS NOT NULL`).
- Calcolo età studente in base all'anno di nascita: `YEAR(GETDATE()) - s.AnnoN`.
- Intervallo di anni: `WHERE r.Anno BETWEEN 1801 AND 1900`.
- Ricerca parziale testo:
  - Inizia per 'Tokyo': `Titolo LIKE 'Tokyo%'`
  - Contiene 'Sposi': `Titolo LIKE '%Sposi%'`
  - Finisce con 'blues': `Titolo LIKE '%blues'`
  - Penultima lettera 'i': `Titolo LIKE '%i_'` (`_` indica esattamente 1 carattere).

---

## 6. Analisi e Soluzioni: 05 - Romanzi Ripasso

### Schema:
- `ROMANZI(CodiceR, Titolo, NomeAut*, Anno)`
- `PERSONAGGI(NomeP, CodiceR*, sesso, ruolo)`
- `AUTORI(NomeAut, AnnoN, AnnoM:optional, Nazione)`
- `FILM(CodiceF, Titolo, Regista, Produttore, Anno, CodiceR*)`

---

#### 1. Il titolo dei romanzi del 19° secolo
```sql
SELECT Titolo
FROM ROMANZI
WHERE Anno BETWEEN 1801 AND 1900;
```

#### 2. Il titolo, l’autore e l’anno di pubblicazione dei romanzi di autori russi, ordinati per autore e, per lo stesso autore, ordinati per anno di pubblicazione
```sql
SELECT r.Titolo, r.NomeAut, r.Anno
FROM ROMANZI r, AUTORI a
WHERE r.NomeAut = a.NomeAut
  AND a.Nazione = 'Russa'
ORDER BY r.NomeAut ASC, r.Anno ASC;
```

#### 3. I personaggi principali (ruolo = 'P') dei romanzi di autori viventi
```sql
SELECT DISTINCT p.NomeP
FROM PERSONAGGI p, ROMANZI r, AUTORI a
WHERE p.CodiceR = r.CodiceR
  AND r.NomeAut = a.NomeAut
  AND p.Ruolo = 'P'
  AND a.AnnoM IS NULL;
```

#### 4. I romanzi dai quali è stato tratto un film con lo stesso titolo del romanzo
```sql
SELECT r.Titolo
FROM ROMANZI r, FILM f
WHERE r.CodiceR = f.CodiceR
  AND r.Titolo = f.Titolo;
```

#### 5. Il titolo, il regista e l’anno dei film tratti dal romanzo “Robin Hood”
```sql
SELECT f.Titolo, f.Regista, f.Anno
FROM FILM f, ROMANZI r
WHERE f.CodiceR = r.CodiceR
  AND r.Titolo = 'Robin Hood';
```

#### 6. Per ogni autore italiano, l’anno del primo e dell’ultimo romanzo
```sql
SELECT a.NomeAut, MIN(r.Anno) AS AnnoPrimoRomanzo, MAX(r.Anno) AS AnnoUltimoRomanzo
FROM AUTORI a, ROMANZI r
WHERE a.NomeAut = r.NomeAut
  AND a.Nazione = 'Italiana'
GROUP BY a.NomeAut;
```

#### 7. I nomi dei personaggi che compaiono in più di un romanzo, ed il numero dei romanzi nei quali compaiono
```sql
SELECT p.NomeP, COUNT(p.CodiceR) AS NumeroRomanzi
FROM PERSONAGGI p
GROUP BY p.NomeP
HAVING COUNT(p.CodiceR) > 1;
```

#### 8. I romanzi di autori italiani dai quali è stato tratto più di un film
```sql
SELECT r.CodiceR, r.Titolo
FROM ROMANZI r, AUTORI a, FILM f
WHERE r.NomeAut = a.NomeAut
  AND r.CodiceR = f.CodiceR
  AND a.Nazione = 'Italiana'
GROUP BY r.CodiceR, r.Titolo
HAVING COUNT(f.CodiceF) > 1;
```

#### 9. Il titolo dei romanzi dai quali non è stato tratto un film
```sql
SELECT r.Titolo
FROM ROMANZI r
WHERE r.CodiceR NOT IN (
    SELECT f.CodiceR
    FROM FILM f
);
```

#### 10. Il titolo dei romanzi i cui personaggi principali son tutti femminili
```sql
SELECT r.Titolo
FROM ROMANZI r
WHERE EXISTS (
    SELECT *
    FROM PERSONAGGI p
    WHERE p.CodiceR = r.CodiceR
      AND p.Ruolo = 'P'
)
AND NOT EXISTS (
    SELECT *
    FROM PERSONAGGI p
    WHERE p.CodiceR = r.CodiceR
      AND p.Ruolo = 'P'
      AND p.Sesso <> 'F'
);
```

---

## 7. Analisi e Soluzioni: 06 - Scuola Ripasso

### Schema:
- `CORSIDILAUREA(CorsoLaurea, TipoLaurea, Facoltà)`
- `DOCENTI(CodDocente, NomeD, Dipartimento)`
- `CORSI(CodCorso, NomeCorso, CodDocente)`
- `STUDENTI(Matricola, NomeS, CorsoLaurea, AnnoN)`
- `FREQUENTA(Matricola, CodCorso)`

---

#### 1. Il nome e l’anno di nascita degli studenti iscritti a SBC, in ordine rispetto al nome
```sql
SELECT s.NomeS, s.AnnoN
FROM STUDENTI s
WHERE s.CorsoLaurea = 'SBC'
ORDER BY s.NomeS ASC;
```

#### 2. Il nome ed il Dipartimento dei docenti di “Basi di Dati e Sistemi Informativi” o di “Informatica Generale”
```sql
SELECT d.NomeD, d.Dipartimento
FROM DOCENTI d, CORSI c
WHERE d.CodDocente = c.CodDocente
  AND (c.NomeCorso = 'Basi di Dati e Sistemi Informativi' OR c.NomeCorso = 'Informatica Generale');
```

#### 3. Matricola e nome degli studenti di un corso di laurea triennale (tipoLaurea = 'L') che seguono un corso di un docente di nome Felice
```sql
SELECT DISTINCT s.Matricola, s.NomeS
FROM STUDENTI s, CORSIDILAUREA cl, FREQUENTA f, CORSI c, DOCENTI d
WHERE s.CorsoLaurea = cl.CorsoLaurea
  AND s.Matricola = f.Matricola
  AND f.CodCorso = c.CodCorso
  AND c.CodDocente = d.CodDocente
  AND cl.TipoLaurea = 'L'
  AND d.NomeD = 'Felice';
```

#### 4. Per ogni tipo di laurea, il tipoLaurea e l’età media degli studenti
```sql
SELECT cl.TipoLaurea, AVG(YEAR(GETDATE()) - s.AnnoN) AS EtaMedia
FROM CORSIDILAUREA cl, STUDENTI s
WHERE cl.CorsoLaurea = s.CorsoLaurea
GROUP BY cl.TipoLaurea;
```

#### 5. Di ogni corso di un docente di nome Leoni, il CodCorso e il numero degli studenti che lo frequentano
```sql
SELECT c.CodCorso, COUNT(f.Matricola) AS NumeroStudenti
FROM CORSI c, DOCENTI d, FREQUENTA f
WHERE c.CodDocente = d.CodDocente
  AND c.CodCorso = f.CodCorso
  AND d.NomeD = 'Leoni'
GROUP BY c.CodCorso;
```

#### 6. Il codice dei corsi frequentati da più di 5 studenti e tenuti da docenti del Dipartimento di Informatica
```sql
SELECT c.CodCorso
FROM CORSI c, DOCENTI d, FREQUENTA f
WHERE c.CodDocente = d.CodDocente
  AND c.CodCorso = f.CodCorso
  AND d.Dipartimento = 'Informatica'
GROUP BY c.CodCorso
HAVING COUNT(f.Matricola) > 5;
```

#### 7. Per ogni studente della Facoltà di Lettere e Filosofia, la matricola ed il numero di corsi seguiti
```sql
SELECT s.Matricola, COUNT(f.CodCorso) AS NumeroCorsi
FROM STUDENTI s, CORSIDILAUREA cl, FREQUENTA f
WHERE s.CorsoLaurea = cl.CorsoLaurea
  AND s.Matricola = f.Matricola
  AND cl.Facoltà = 'Lettere e Filosofia'
GROUP BY s.Matricola;
```

#### 8. Matricola e nome degli studenti che non frequentano nessun corso
```sql
SELECT s.Matricola, s.NomeS
FROM STUDENTI s
WHERE s.Matricola NOT IN (
    SELECT f.Matricola
    FROM FREQUENTA f
);
```

#### 9. Il Codice ed il Nome dei docenti dei Corsi che non sono frequentati da nessuno studente
```sql
SELECT d.CodDocente, d.NomeD
FROM DOCENTI d, CORSI c
WHERE d.CodDocente = c.CodDocente
  AND c.CodCorso NOT IN (
      SELECT f.CodCorso
      FROM FREQUENTA f
  );
```

#### 10. Matricola e nome degli studenti che seguono solo corsi di docenti del dipartimento di Storia
```sql
SELECT s.Matricola, s.NomeS
FROM STUDENTI s
WHERE s.Matricola IN (
    SELECT f.Matricola 
    FROM FREQUENTA f
)
AND s.Matricola NOT IN (
    SELECT f.Matricola
    FROM FREQUENTA f, CORSI c, DOCENTI d
    WHERE f.CodCorso = c.CodCorso
      AND c.CodDocente = d.CodDocente
      AND d.Dipartimento <> 'Storia'
);
```

#### 11. Il CodCorso dei corsi seguiti solo da studenti che appartengono al Corso di Laurea Triennale in SBC
```sql
SELECT c.CodCorso
FROM CORSI c
WHERE c.CodCorso IN (
    SELECT f.CodCorso 
    FROM FREQUENTA f
)
AND c.CodCorso NOT IN (
    SELECT f.CodCorso
    FROM FREQUENTA f, STUDENTI s
    WHERE f.Matricola = s.Matricola
      AND s.CorsoLaurea <> 'SBC'
);
```

#### 12. Nome e CodDocente dei docenti che insegnano qualche corso seguito da più di 5 studenti
```sql
SELECT DISTINCT d.NomeD, d.CodDocente
FROM DOCENTI d, CORSI c, FREQUENTA f
WHERE d.CodDocente = c.CodDocente
  AND c.CodCorso = f.CodCorso
GROUP BY d.CodDocente, d.NomeD, c.CodCorso
HAVING COUNT(f.Matricola) > 5;
```

#### 13. Codice dei corsi che sono frequentati da tutti gli studenti del CorsoLaurea SBC
```sql
SELECT f.CodCorso
FROM FREQUENTA f, STUDENTI s
WHERE f.Matricola = s.Matricola
  AND s.CorsoLaurea = 'SBC'
GROUP BY f.CodCorso
HAVING COUNT(DISTINCT f.Matricola) = (
    SELECT COUNT(*)
    FROM STUDENTI
    WHERE CorsoLaurea = 'SBC'
);
```

---

## 8. Check-list anti-errore prima di consegnare

Prima di chiudere o consegnare una query, fai questi 5 controlli:

1. **Ho collegato tutte le tabelle nel `WHERE`?**  
   Conta le tabelle nel `FROM`: se sono 3, ci devono essere almeno 2 uguaglianze di chiavi (es. `A.id = B.id AND B.cod = C.cod`).
2. **Ho messo un `COUNT` o `SUM` nel `WHERE`?**  
   Se sì, **CANCELLALO SUBITO**! Le funzioni aggregate vanno o nella `SELECT` o nell'`HAVING`.
3. **C'è un `GROUP BY`? Ho controllato la `SELECT`?**  
   Ogni campo nella `SELECT` che non ha `COUNT`/`SUM`/`AVG`/`MIN`/`MAX` deve essere scritto identico nel `GROUP BY`.
4. **Ho usato `= NULL` invece di `IS NULL`?**  
   Correggi in `IS NULL` o `IS NOT NULL`.
5. **Se la domanda dice "TUTTI" o "SOLO", ho gestito chi non ha elementi?**  
   Ricorda sempre la clausola per verificare che ci sia almeno 1 elemento (`EXISTS` o `IN`) oltre a escludere quelli contrari (`NOT EXISTS` o `NOT IN`).
