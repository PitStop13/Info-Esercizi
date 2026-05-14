-- 1. Tutti i dati degli alunni di FOSSANO, BRA e MONDOVI
SELECT * FROM ALUNNI 
WHERE CittaResidenza IN ('FOSSANO', 'BRA', 'MONDOVI');

-- 2. Cognome e nome degli alunni alti tra 180 e 190 (ordinati)
SELECT Cognome, Nome 
FROM ALUNNI 
WHERE Altezza BETWEEN 180 AND 190 
ORDER BY Altezza DESC, Cognome ASC, Nome ASC;

-- 3. Cognome e nome degli alunni nati nel mese di dicembre
SELECT Cognome, Nome 
FROM ALUNNI 
WHERE MONTH(DataNascita) = 12;

-- 4. Cognome e nome degli alunni che non hanno l’ecdl
SELECT Cognome, Nome 
FROM ALUNNI 
WHERE Ecdl = 0;

--5. (MANCA)

-- 6. Alunni con cognome che inizia per Pa
SELECT * FROM ALUNNI 
WHERE Cognome LIKE 'Pa%';

-- 6.a. Visualizzare l'altezza dell'alunno più alto (MAX ignora i NULL)
SELECT MAX(Altezza) AS AltezzaMassima 
FROM ALUNNI;

-- 6.b. Visualizzare l'altezza dell'alunno più basso (MIN ignora i NULL)
SELECT MIN(Altezza) AS AltezzaMinima 
FROM ALUNNI;

-- 6.c. Visualizzare l'altezza media 
SELECT AVG(CAST(Altezza AS FLOAT)) AS AltezzaMedia 
FROM ALUNNI;

-- 6.d. Visualizzare il numero totale degli alunni
SELECT COUNT(*) AS TotaleAlunni 
FROM ALUNNI;

-- 7. Per ogni mese visualizzare quanti sono gli alunni
SELECT MONTH(DataNascita) AS Mese, COUNT(*) AS TotaleAlunni
FROM ALUNNI
GROUP BY MONTH(DataNascita);

-- 8. Conteggio per altezza (escludendo le altezze singole e i dati mancanti)
SELECT a.Altezza, COUNT(*) AS NumeroAlunni
FROM ALUNNI a
WHERE a.Altezza IS NOT NULL
GROUP BY a.Altezza
HAVING COUNT(*) > 1;

-- 9. Dati dell’alunno più giovane
SELECT * FROM ALUNNI AS a
WHERE a.DataNascita = (SELECT MAX(a.DataNascita) FROM Alunni as a);

/*Oppure: 

SELECT TOP 1 * FROM ALUNNI 
ORDER BY DataNascita DESC;

*/
