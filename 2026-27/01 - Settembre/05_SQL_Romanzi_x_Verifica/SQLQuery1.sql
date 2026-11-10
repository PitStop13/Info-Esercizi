-- ==============================================================================
-- DATABASE: ROMANZI RIPASSO (Esercizio 05)
-- SCHEMA:
--   ROMANZI(CodiceR, Titolo, NomeAut*, Anno)
--   PERSONAGGI(NomeP, CodiceR*, sesso, ruolo)
--   AUTORI(NomeAut, AnnoN, AnnoM:optional, Nazione)
--   FILM(CodiceF, Titolo, Regista, Produttore, Anno, CodiceR*)
-- ==============================================================================

-- 1. Il titolo dei romanzi del 19° secolo (tra il 1801 e il 1900)
SELECT Titolo
FROM ROMANZI
WHERE Anno BETWEEN 1801 AND 1900;


-- 2. Il titolo, l’autore e l’anno di pubblicazione dei romanzi di autori russi,
--    ordinati per autore e, per lo stesso autore, ordinati per anno di pubblicazione
SELECT r.Titolo, r.NomeAut, r.Anno
FROM ROMANZI r, AUTORI a
WHERE r.NomeAut = a.NomeAut
  AND a.Nazione = 'Russa'
ORDER BY r.NomeAut ASC, r.Anno ASC;


-- 3. I personaggi principali (ruolo = 'P') dei romanzi di autori viventi (AnnoM è NULL)
SELECT DISTINCT p.NomeP
FROM PERSONAGGI p, ROMANZI r, AUTORI a
WHERE p.CodiceR = r.CodiceR
  AND r.NomeAut = a.NomeAut
  AND p.Ruolo = 'P'
  AND a.AnnoM IS NULL;


-- 4. I romanzi dai quali è stato tratto un film con lo stesso titolo del romanzo
SELECT r.Titolo
FROM ROMANZI r, FILM f
WHERE r.CodiceR = f.CodiceR
  AND r.Titolo = f.Titolo;


-- 5. Il titolo, il regista e l’anno dei film tratti dal romanzo "Robin Hood"
SELECT f.Titolo, f.Regista, f.Anno
FROM FILM f, ROMANZI r
WHERE f.CodiceR = r.CodiceR
  AND r.Titolo = 'Robin Hood';


-- 6. Per ogni autore italiano, l’anno del primo e dell’ultimo romanzo.
-- Spiegazione: "Per ogni autore" significa GROUP BY sull'autore.
-- Il primo romanzo è il MIN(Anno), l'ultimo è il MAX(Anno).
SELECT a.NomeAut, MIN(r.Anno) AS AnnoPrimoRomanzo, MAX(r.Anno) AS AnnoUltimoRomanzo
FROM AUTORI a, ROMANZI r
WHERE a.NomeAut = r.NomeAut
  AND a.Nazione = 'Italiana'
GROUP BY a.NomeAut;


-- 7. I nomi dei personaggi che compaiono in più di un romanzo, ed il numero dei romanzi nei quali compaiono
-- Spiegazione: raggruppiamo per NomeP e usiamo HAVING COUNT(...) > 1
SELECT p.NomeP, COUNT(p.CodiceR) AS NumeroRomanzi
FROM PERSONAGGI p
GROUP BY p.NomeP
HAVING COUNT(p.CodiceR) > 1;


-- 8. I romanzi di autori italiani dai quali è stato tratto più di un film
-- Spiegazione: colleghiamo ROMANZI, AUTORI e FILM, raggruppiamo per romanzo e contiamo i film > 1
SELECT r.CodiceR, r.Titolo
FROM ROMANZI r, AUTORI a, FILM f
WHERE r.NomeAut = a.NomeAut
  AND r.CodiceR = f.CodiceR
  AND a.Nazione = 'Italiana'
GROUP BY r.CodiceR, r.Titolo
HAVING COUNT(f.CodiceF) > 1;

-- Oppure con sottoquery (senza GROUP BY):
-- SELECT r.Titolo
-- FROM ROMANZI r, AUTORI a
-- WHERE r.NomeAut = a.NomeAut
--   AND a.Nazione = 'Italiana'
--   AND (SELECT COUNT(*) FROM FILM f WHERE f.CodiceR = r.CodiceR) > 1;


-- 9. Il titolo dei romanzi dai quali non è stato tratto un film
-- Spiegazione: cerchiamo i romanzi il cui CodiceR NON compare tra i CodiceR della tabella FILM
SELECT r.Titolo
FROM ROMANZI r
WHERE r.CodiceR NOT IN (
    SELECT f.CodiceR
    FROM FILM f
);

-- Oppure con NOT EXISTS:
-- SELECT r.Titolo
-- FROM ROMANZI r
-- WHERE NOT EXISTS (
--     SELECT *
--     FROM FILM f
--     WHERE f.CodiceR = r.CodiceR
-- );


-- 10. Il titolo dei romanzi i cui personaggi principali son tutti femminili.
-- Spiegazione logica ("TUTTI"):
-- Un romanzo soddisfa la richiesta se:
-- 1) Ha almeno un personaggio principale (EXISTS)
-- 2) NON ha nessun personaggio principale maschio / diverso da 'F' (NOT EXISTS)
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

-- Oppure con NOT IN:
-- SELECT r.Titolo
-- FROM ROMANZI r
-- WHERE r.CodiceR IN (SELECT CodiceR FROM PERSONAGGI WHERE Ruolo = 'P')
--   AND r.CodiceR NOT IN (
--       SELECT CodiceR FROM PERSONAGGI WHERE Ruolo = 'P' AND Sesso = 'M'
--   );
