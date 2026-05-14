-- ============================================
-- DIZIONARIO SQL - Verifica di domani
-- Pietro - Promemoria rapido
-- ============================================


-- ============================================================
-- SELECT
-- ============================================================
SELECT nome, eta, salario
FROM Impiegato;
-- Specifica quali colonne restituire.
-- Usa * per selezionare tutto: SELECT * FROM tabella


-- ============================================================
-- AS  (alias)
-- ============================================================
SELECT nome, prezzo, nome AS nome_cliente
FROM Ordini;
-- Rinomina una colonna nel risultato.
-- Non cambia il nome reale nella tabella


-- ============================================================
-- DISTINCT
-- ============================================================
SELECT DISTINCT eta
FROM Impiegato;
-- Elimina i duplicati: restituisce solo valori unici.
-- Utile quando una colonna ha molti valori ripetuti


-- ============================================================
-- Funzioni aggregate: AVG, MIN, MAX, COUNT, SUM
-- ============================================================
SELECT AVG(salario), MIN(altezza), MAX(altezza), COUNT(*), SUM(salario)
FROM Impiegato;
-- AVG=media, MIN=minimo, MAX=massimo, COUNT=numero righe, SUM=somma.
-- COUNT(*) conta tutte le righe; COUNT(col) ignora i NULL


-- ============================================================
-- FROM
-- ============================================================
SELECT *
FROM Impiegato;
-- Specifica da quale tabella estrarre i dati.
-- Obbligatorio in ogni query di selezione


-- ============================================================
-- WHERE
-- ============================================================
SELECT *
FROM Impiegato
WHERE eta > 50;
-- Filtra le righe in base a una condizione.
-- Viene eseguito PRIMA del raggruppamento (GROUP BY)


-- ============================================================
-- AND / OR
-- ============================================================
SELECT *
FROM Impiegato
WHERE titolo = 'programmatore' AND salario >= 50000;
-- AND: entrambe le condizioni devono essere vere.
-- OR: basta che una delle due sia vera


-- ============================================================
-- LIKE
-- ============================================================
SELECT *
FROM Impiegato
WHERE titolo LIKE 'Ing%';
-- Filtra stringhe con pattern: % = qualsiasi sequenza di caratteri.
-- Esempio: 'Ing%' trova Ingegnere, Ing. Rossi, ecc.


-- ============================================================
-- IN / NOT IN
-- ============================================================
SELECT *
FROM Impiegato
WHERE nome IN ('Rossi', 'Bianchi', 'Verdi');
-- Verifica se il valore è presente nell'elenco.
-- NOT IN esclude i valori nell'elenco


-- ============================================================
-- BETWEEN
-- ============================================================
SELECT *
FROM Impiegato
WHERE eta BETWEEN 30 AND 40;
-- Filtra valori in un intervallo (estremi 30 e 40 inclusi).
-- Equivalente a: eta >= 30 AND eta <= 40


-- ============================================================
-- Funzioni sulle DATE: MONTH, YEAR, DAY
-- ============================================================
SELECT *
FROM Impiegato
WHERE MONTH(DataNascita) = 12;

SELECT *
FROM Proiezioni
WHERE DataProiezioni = '2004-12-25';
-- MONTH() estrae il mese, YEAR() l'anno, DAY() il giorno.
-- Le date si scrivono nel formato 'AAAA-MM-GG'


-- ============================================================
-- ORDER BY
-- ============================================================
SELECT *
FROM Impiegato
ORDER BY salario ASC, eta DESC;
-- Ordina il risultato: ASC = crescente (default), DESC = decrescente.
-- Con più colonne, il secondo criterio si applica a parità del primo


-- ============================================================
-- JOIN
-- ============================================================
SELECT f.Titolo, p.DataProiezione
FROM Film f
JOIN Proiezioni p ON f.CodFilm = p.CodFilm;
-- Unisce due tabelle tramite una colonna in comune (chiave esterna).
-- f e p sono alias delle tabelle per scrivere meno


-- ============================================================
-- GROUP BY
-- ============================================================
SELECT dataNascita, COUNT(*) AS Numero
FROM Alunni
GROUP BY dataNascita;
-- Raggruppa le righe con lo stesso valore nella colonna.
-- Nella SELECT puoi usare SOLO colonne nel GROUP BY o funzioni aggregate


-- ============================================================
-- HAVING
-- ============================================================
SELECT dataNascita, COUNT(*) AS Numero
FROM Alunni
GROUP BY dataNascita
HAVING COUNT(*) > 1;
-- Filtra i gruppi DOPO il GROUP BY (come WHERE ma per i gruppi).
-- Non puoi usare WHERE con funzioni aggregate: usa HAVING


-- ============================================================
-- Subquery (query annidata)
-- ============================================================
SELECT *
FROM Alunni
WHERE dataNascita = (SELECT MAX(dataNascita) FROM Alunni);
-- Una query dentro un'altra query, tra parentesi.
-- Qui trova gli alunni con la data di nascita più recente