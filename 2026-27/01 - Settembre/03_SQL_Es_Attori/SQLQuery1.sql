-- 1- Il nome di tutte le sale di Pisa
SELECT Sale.Nome
FROM Sale
WHERE Sale.Citta = 'Pisa'

-- 2 - Il titolo dei film di F. Fellini prodotti dopo il 1960
SELECT Film.Titolo
FROM Film
WHERE Film.Regista = 'F. Fellini'
  AND Film.AnnoProduzione > 1960

-- 3- Il titolo e la durata dei film di fantascienza giapponesi o francesi prodotti dopo il 1990
select f.Titolo
from Film f
where f.Genere = 'Fantascienza' and f.Nazionalita='Giappone' or f.Nazionalita='Francia' and f.AnnoProduzione>1990

-- 4 - Il titolo dei film di fantascienza giapponesi prodotti dopo il 1990 oppure francesi
SELECT Film.Titolo
FROM Film
WHERE (Film.Nazionalita = 'Giapponese' AND Film.Genere = 'Fantascienza' AND Film.AnnoProduzione > 1990)   OR Film.Nazionalita = 'Francese'
-- 5 - I titoli dei film dello stesso regista di "Casablanca"
SELECT Film.Titolo
FROM Film
WHERE Film.Regista = (
    SELECT Film.Regista
    FROM Film
    WHERE Film.Titolo = 'Casablanca'
)
AND Film.Titolo <> 'Casablanca'

-- 6 - Il titolo ed il genere dei film proiettati il giorno di Natale 2004
SELECT Film.Titolo, Film.Genere
FROM Film, Proiezioni
WHERE Film.CodFilm = Proiezioni.CodFilm
  AND Proiezioni.DataProiezione = '2004-12-25'

-- 7 - Il titolo ed il genere dei film proiettati a Napoli il giorno di Natale 2004
SELECT Film.Titolo, Film.Genere
FROM Film, Proiezioni, Sale
WHERE Film.CodFilm = Proiezioni.CodFilm
  AND Sale.CodSala = Proiezioni.CodSala
  AND Proiezioni.DataProiezione = '2004-12-25'
  AND Sale.Citta = 'Napoli'

-- 8 - I nomi delle sale di Napoli in cui il giorno di Natale 2004 è stato proiettato un film con R. Williams
SELECT Sale.Nome
FROM Film, Proiezioni, Sale, Attori, Recita
WHERE Film.CodFilm = Proiezioni.CodFilm
  AND Sale.CodSala = Proiezioni.CodSala
  AND Film.CodFilm = Recita.CodFilm
  AND Attori.CodAttore = Recita.CodAttore
  AND Proiezioni.DataProiezione = '2004-12-25'
  AND Sale.Citta = 'Napoli'
  AND Attori.Nome = 'R. Williams'
 
-- 9 - Il titolo dei film in cui recita M. Mastroianni oppure S. Loren
SELECT Film.Titolo
FROM Attori, Film, Recita
WHERE Film.CodFilm = Recita.CodFilm
  AND Attori.CodAttore = Recita.CodAttore
  AND (Attori.Nome = 'M. Mastroianni'
       OR Attori.Nome = 'S. Loren')

-- 10- Il titolo dei film in cui recitano M. Mastroianni e S.Loren
SELECT Film.Titolo
FROM Film
WHERE 'M. Mastroianni' IN (
    SELECT Attori.Nome
    FROM Attori, Recita
    WHERE Attori.CodAttore = Recita.CodAttore
      AND Film.CodFilm = Recita.CodFilm
)
AND 'S. Loren' IN (
    SELECT Attori.Nome
    FROM Attori, Recita
    WHERE Attori.CodAttore = Recita.CodAttore
      AND Film.CodFilm = Recita.CodFilm
)

-- 11 - Per ogni film in cui recita un attore francese, il titolo del film e il nome dell'attore
SELECT Film.Titolo, Attori.Nome
FROM Attori, Film, Recita
WHERE Film.CodFilm = Recita.CodFilm
  AND Attori.CodAttore = Recita.CodAttore
  AND Attori.Nazionalita = 'Francese'

-- 12 - Per ogni film che è stato proiettato a Pisa nel gennaio 2005, il titolo del film e il nome della sala
SELECT Film.Titolo, Sale.Nome
FROM Film, Proiezioni, Sale
WHERE Film.CodFilm = Proiezioni.CodFilm
  AND Sale.CodSala = Proiezioni.CodSala
  AND Proiezioni.DataProiezione >= '2005-01-01'
  AND Proiezioni.DataProiezione < '2005-02-01'
  AND Sale.Citta = 'Pisa'

-- 13 - Il numero di sale di Pisa con più di 60 posti
SELECT COUNT(*)
FROM Sale
WHERE Sale.Citta = 'Pisa'
  AND Sale.Posti > 60

-- 14- Il numero totale di posti nelle sale di Pisa
SELECT SUM(Posti)
FROM Sale
WHERE Sale.Citta='Pisa'
-- 15 - Per ogni citta, il numero di sale
SELECT Sale.Citta, COUNT(*)
FROM Sale
GROUP BY Sale.Citta

-- 16 - Per ogni citta, il numero di sale con più di 60 posti
SELECT Sale.Citta, COUNT(*) AS Numero
FROM Sale
WHERE Sale.Posti > 60
GROUP BY Sale.Citta

-- 17 - Per ogni regista, il numero di film diretti dopo il 1990
SELECT Film.Regista, COUNT(*)
FROM Film
WHERE Film.AnnoProduzione > 1990
GROUP BY Film.Regista

-- 18- Per ogni regista, l’incasso totale di tutte le proiezioni dei suoi film
SELECT Film.registra, SUM(Proiezioni.Incasso)
FROM Film, Proiezioni
WHERE Film.CodFilm=Proiezioni.CodFilm
GROUP BY (Film.registra)
-- 19 - Per ogni film di S. Spielberg, il titolo del film, il numero totale di proiezioni a Pisa e l'incasso totale
SELECT Film.Titolo, COUNT(*), SUM(Proiezioni.Incasso)
FROM Film, Proiezioni, Sale
WHERE Film.CodFilm = Proiezioni.CodFilm
  AND Sale.CodSala = Proiezioni.CodSala
  AND Film.Regista = 'S. Spielberg'
  AND Sale.Citta = 'Pisa'
GROUP BY Film.CodFilm, Film.Titolo

-- 20- Per ogni regista e per ogni attore, il numero di film del regista con l’attore
SELECT f.Regista, a.Nome, COUNT(*) as NumeroFilm
FROM Film f, Attori a, Recita r
WHERE f.CodFilm = r.CodFilm
  AND a.CodAttore = r.CodAttore
  GROUP BY f.Regista, a.CodAttore, a.Nome

-- 21 - Il regista ed il titolo dei film in cui recitano meno di 6 attori
-- NON restituisce i film senza attori
SELECT f.Regista, f.Titolo
FROM FILM f, RECITA r
WHERE f.CodFilm = r.CodFilm
GROUP BY f.CodFilm, f.Titolo, f.Regista
HAVING COUNT(r.CodAttore) < 6;

-- Questa query restituisce anche i film senza attori
SELECT f.Titolo, f.Regista 
FROM Film f
WHERE (SELECT COUNT(*) 
       FROM Recita r
       WHERE f.CodFilm = r.CodFilm) < 6

-- 22- Per ogni film prodotto dopo il 2000, il codice, il titolo e l’incasso totale di tutte le sue proiezioni
SELECT f.CodFilm, f.Titolo, SUM(p.Incasso) AS IncassoTotale
FROM FILM f, PROIEZIONI p
WHERE f.CodFilm = p.CodFilm
  AND f.AnnoProduzione > 2000
GROUP BY f.CodFilm, f.Titolo;

--per estrarre anche i film senza proiezioni
SELECT f.CodFilm, f.Titolo, SUM(p.Incasso) AS IncassoTotale
FROM FILM f
LEFT JOIN PROIEZIONI p ON f.CodFilm = p.CodFilm
WHERE f.AnnoProduzione > 2000
GROUP BY f.CodFilm, f.Titolo;

-- 23 - Il numero di attori dei film in cui appaiono solo attori nati prima del 1970
SELECT f.Titolo, COUNT(a.CodAttore) AS NumeroAttori
From Film f, Attori a, Recita r
Where f.CodFilm = r.CodFilm
AND a.CodAttore = r.CodAttore
GROUP BY f.CodFilm, f.Titolo
HAVING MAX(a.AnnoNascita) <1970

-- 24- Per ogni film di fantascienza, il titolo e l’incasso totale di tutte le sue proiezioni 
SELECT f.Titolo, SUM(p.Incasso) AS IncassoTotale
FROM FILM f, PROIEZIONI p
WHERE f.CodFilm = p.CodFilm
  AND f.Genere = 'Fantascienza'
GROUP BY f.CodFilm, f.Titolo;

-- 25- Per ogni film di fantascienza il titolo e l’incasso totale di tutte le sue proiezioni successive al 1/1/01
SELECT f.Titolo, SUM(p.Incasso) AS IncassoTotale
FROM FILM f, PROIEZIONI p
WHERE f.CodFilm = p.CodFilm
  AND f.Genere = 'Fantascienza'
  AND p.DataProiezione > '2001-01-01'
GROUP BY f.CodFilm, f.Titolo;

-- 26- Per ogni film di fantascienza che non è mai stato proiettato prima del 1/1/01 il titolo e l’incasso totale di tutte le sue proiezioni
SELECT f.Titolo, SUM(p.Incasso) AS IncassoTotale
FROM FILM f, PROIEZIONI p
WHERE f.CodFilm = p.CodFilm
  AND f.Genere = 'Fantascienza'
GROUP BY f.CodFilm, f.Titolo
HAVING (MIN(p.DataProiezione) >= '2001-01-01');

-- 27- Per ogni sala di Pisa, che nel mese di gennaio 2005 ha incassato più di 2000 €, il nome della sala e l’incasso totale (sempre del mese di gennaio 2005)
SELECT s.Nome, SUM(p.Incasso) AS IncassoTotale
FROM Sale s, Proiezioni p
WHERE s.CodSala = p.CodSala
  AND s.Citta = 'Pisa'
  AND p.DataProiezione BETWEEN '2005-01-01' AND '2005-01-31'
GROUP BY s.CodSala, s.Nome
HAVING SUM(p.Incasso) > 2000;

-- 28- I titoli dei film che non sono mai stati proiettati a Pisa
SELECT *
FROm film f
WHERE NOT EXISTS (
    SELECT *
    FROM Proiezioni p, Sale s
    WHERE f.CodFilm = p.CodFilm
      AND p.CodSala = s.CodSala
      AND s.Citta = 'Pisa'
)

--oppure
SELECT *
From film f
WHERE 'Pisa' NOT IN
(
    SELECT s.Citta
    FROM Proiezioni p, Sale s
    WHERE f.CodFilm = p.CodFilm
      AND p.CodSala = s.CodSala
)

-- 29- I titoli dei film che sono stati proiettati solo a Pisa
SELECT f.Titolo
FROM film f
WHERE NOT EXISTS (
    SELECT *
    FROM Proiezioni p, Sale s
    WHERE f.CodFilm = p.CodFilm
      AND p.CodSala = s.CodSala
      AND s.Citta <> 'Pisa'
)

--Se il film non ha proiezioni viene restituito lo stesso...risolvo con: 
SELECT f.Titolo
FROM Film f
WHERE EXISTS (
    -- È stato proiettato almeno una volta a Pisa
    SELECT *
    FROM Proiezioni p, Sale s
    WHERE f.CodFilm = p.CodFilm
      AND p.CodSala = s.CodSala
      AND s.Citta = 'Pisa'
)
AND NOT EXISTS (
    -- Non è mai stato proiettato in una città diversa da Pisa
    SELECT *
    FROM Proiezioni p, Sale s
    WHERE f.CodFilm = p.CodFilm
      AND p.CodSala = s.CodSala
      AND s.Citta <> 'Pisa'
);

-- 30- I titoli dei film dei quali non vi è mai stata una proiezione con incasso superiore a 500 €
SELECT f.Titolo
FROM Film f
WHERE NOT EXISTS (
    SELECT *
    FROM Proiezioni p
    WHERE f.CodFilm = p.CodFilm
      AND p.Incasso > 500
);

-- 31- I titoli dei film le cui proiezioni hanno sempre ottenuto un incasso superiore a 500 €
SELECT f.Titolo
FROM Film f
WHERE EXISTS (
    SELECT *
    FROM Proiezioni p
    WHERE f.CodFilm = p.CodFilm
)
AND NOT EXISTS (
    SELECT *
    FROM Proiezioni p
    WHERE f.CodFilm = p.CodFilm
      AND (p.Incasso <= 500 OR p.Incasso IS NULL)
);

-- 32- Il nome degli attori italiani che non hanno mai recitato in film di Fellini
SELECT a.Nome
FROM Attori a
WHERE a.Nazionalita = 'Italiana'
  AND NOT EXISTS (
      SELECT *
      FROM Recita r, Film f
      WHERE a.CodAttore = r.CodAttore
        AND r.CodFilm = f.CodFilm
        AND f.Regista = 'F. Fellini'
  );

-- 33- Il titolo dei film di Fellini in cui non recitano attori italiani
SELECT f.Titolo
FROM Film f
WHERE f.Regista = 'F. Fellini'
  AND NOT EXISTS (
      SELECT *
      FROM Recita r, Attori a
      WHERE f.CodFilm = r.CodFilm
        AND r.CodAttore = a.CodAttore
        AND a.Nazionalita = 'Italiana'
  );

-- 34- Il titolo dei film senza attori
SELECT f.Titolo
FROM Film f
WHERE NOT EXISTS (
    SELECT *
    FROM Recita r
    WHERE f.CodFilm = r.CodFilm
);

-- 35- Gli attori che prima del 1960 hanno recitato solo nei film di Fellini
SELECT a.Nome
FROM Attori a
WHERE EXISTS (
    SELECT *
    FROM Recita r, Film f
    WHERE a.CodAttore = r.CodAttore
      AND r.CodFilm = f.CodFilm
      AND f.AnnoProduzione < 1960
      AND f.Regista = 'F. Fellini'
)
AND NOT EXISTS (
    SELECT *
    FROM Recita r, Film f
    WHERE a.CodAttore = r.CodAttore
      AND r.CodFilm = f.CodFilm
      AND f.AnnoProduzione < 1960
      AND f.Regista <> 'F. Fellini'
);

-- 36- Gli attori che hanno recitato in film di Fellini solo prima del 1960
SELECT a.Nome
FROM Attori a
WHERE EXISTS (
    SELECT *
    FROM Recita r, Film f
    WHERE a.CodAttore = r.CodAttore
      AND r.CodFilm = f.CodFilm
      AND f.Regista = 'F. Fellini'
      AND f.AnnoProduzione < 1960
)
AND NOT EXISTS (
    SELECT *
    FROM Recita r, Film f
    WHERE a.CodAttore = r.CodAttore
      AND r.CodFilm = f.CodFilm
      AND f.Regista = 'F. Fellini'
      AND f.AnnoProduzione >= 1960
);