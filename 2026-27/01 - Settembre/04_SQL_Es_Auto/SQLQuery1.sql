/* 
    5. Per ciascuna Assicurazione, il nome, la sede ed il numero di auto assicurate
    Usiamo la LEFT JOIN per includere anche le assicurazioni senza auto.
*/

SELECT ass.Nome, ass.Sede, COUNT(a.CodAss) AS NumeroAutoAssicurate
FROM Assicurazioni ass
LEFT JOIN [Auto] a ON ass.CodAss = a.CodAss
GROUP BY ass.CodAss, ass.Nome, ass.Sede

-- 5. Ma che non prende la compagnia con 0 auto.
SELECT ass.Nome, ass.Sede, COUNT(a.Targa) AS NumeroAutoAssicurate
FROM Assicurazioni ass, [Auto] a
WHERE ass.CodAss = a.CodAss
GROUP BY ass.CodAss, ass.Nome, ass.Sede


/*
    6. Per ciascuna auto "Fiat", la targa dell'auto ed il numero di sinistri in cui è stata coinvolta.
    Usiamo la LEFT JOIN per includere anche le auto senza sinistri.
*/

SELECT a.Targa, COUNT(ac.CodS) AS NumeroSinistri
FROM [Auto] a LEFT JOIN Autocoinvolte ac ON a.Targa = ac.Targa
WHERE a.Marca = 'Fiat'
GROUP BY a.Targa

-- 6. Fatta con il prof che ignora tutte le auto che non hanno sinistri.
SELECT a.Targa, COUNT(*) AS NumeroSinistri
FROM [Auto] a, Autocoinvolte ac
WHERE a.Targa = ac.Targa
  AND a.Marca = 'Fiat'
GROUP BY a.Targa

/*
    7. Per ciascuna auto coinvolta in più di un sinistro,
    la targa dell'auto,il nome dell'Assicurazione ed il totale dei danni riportati.
    
*/

SELECT a.Targa, ass.Nome AS NomeAssicurazione, SUM(ac.ImportoDelDanno) AS TotaleDanni
FROM Auto a, Assicurazioni ass, Autocoinvolte ac
WHERE a.CodAss = ass.CodAss
  AND a.Targa = ac.Targa
GROUP BY a.Targa, ass.Nome
HAVING COUNT(*) > 1;

/* 
    8. CodF e Nome di coloro che possiedono più di un'auto.
*/
SELECT p.CodF, p.Nome
FROM Proprietari p, Auto a
WHERE p.CodF = a.CodF
GROUP BY p.CodF, p.Nome
HAVING COUNT(*) > 1;

--oppure
SELECT p.CodF, p.Nome
FROM Proprietari p
WHERE 1 < (
    SELECT COUNT(*) FROM Auto a WHERE a.CodF = p.CodF
);

/* 9. 

    La targa delle auto che NON sono state coinvolte in sinistri dopo il 20/01/01

*/

SELECT a.Targa
FROM Auto a
WHERE NOT EXISTS (
    SELECT *
    FROM Autocoinvolte ac, Sinistro s
    WHERE ac.CodS = s.CodS
      AND s.Data > '2001-01-20'
      AND ac.Targa = a.Targa
);

--oppure con il NOT IN

SELECT *
FROM Auto a
WHERE a.Targa NOT IN (
    SELECT ac.Targa
    FROM Autocoinvolte ac, Sinistro s
    WHERE ac.CodS = s.CodS
      AND s.Data > '2001-01-20'
);

/*
    10. Il codice dei sinistri in cui non sono state coinvolte auto con cilindrata inferiore a 2000 cc
*/

SELECT s.CodS
FROM Sinistro s
WHERE s.CodS NOT IN (
    SELECT ac.CodS
    FROM Autocoinvolte ac, Auto a
    WHERE ac.Targa = a.Targa
      AND a.Cilindrata < 2000
);

-- oppure con il NOT EXISTS

SELECT s.CodS
FROM Sinistro s
WHERE NOT EXISTS (
    SELECT *
    FROM Autocoinvolte ac, Auto a
    WHERE ac.CodS = s.CodS
      AND ac.Targa = a.Targa
      AND a.Cilindrata < 2000
);