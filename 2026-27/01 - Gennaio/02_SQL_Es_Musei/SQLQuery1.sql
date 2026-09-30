-- 8- Per ciascun museo di Londra, il numero di opere di artisti italiani ivi conservate.
SELECT m.NomeM, COUNt(*) as NumeroOpere
FROM Opere o , Musei m , Artisti a
WHERE o.NomeA = a.NomeA 
AND o.NomeM = m.NomeM
AND a.Nazionalita = 'Italiana' 
AND m.Citta = 'Londra'
group by m.NomeM

-- 9- Il nome dei musei di Londra che non conservano opere di Tiziano.
SELECT m.NomeM 
FROM Musei m
WHERE m.Citta = 'Londra' 
AND NOT EXISTS(
      SELECT * 
      FROM Opere o
      WHERE o.NomeA = 'Tiziano' AND o.NomeM = m.NomeM --faccio l'and per collegare le due tabelle e verificare che non esista un'opera di Tiziano in quel museo
)
-- Oppure...
SELECT m.NomeM
FROM Musei m
WHERE m.Citta = 'Londra'
AND 'Tiziano' NOT IN(
      SELECT o.NomeA
      FROM Opere o
      WHERE o.NomeM = m.NomeM)

-- 10- Il nome dei musei di Londra che conservano solo opere di Tiziano.
SelECT m.NomeM
FROM Musei m
WHERE m.Citta = 'Londra'
AND NOT EXISTS (
      SELECT * 
      FROM Opere o
      WHERE o.NomeA <>'Tiziano ' 
      AND o.NomeM = m.NomeM --faccio l'and per collegare le due tabelle e verificare che non esista un'opera di Tiziano in quel museo
)

-- Oppure... con l'operatore ALL
SELECT m.NomeM
FROM Musei m
WHERE m.Citta = 'Londra'
AND 'Tiziano' = ALL( --all significa che tutti i valori della sottoquery devono essere uguali a Tiziano
      SELECT o.NomeA
      FROM Opere o
      WHERE o.NomeM = m.NomeM)

-- 11- Per ciascun artista, il nome dell’artista ed il numero di sue opere conservate alla "Galleria degli Uffizi".
Select a.NomeA as NomeArtista, COUNT(*) as NumeroOpere
from Artisti a, Opere o
where a.NomeA = o.NomeA
AND o.NomeM = 'Galleria degli Uffizi'
group by a.NomeA

-- 12- I musei che conservano almeno 20 opere di artisti italiani.
SELECT o.NomeM 
FROM Opere o, Artisti a
WHERE o.NomeA = a.NomeA 
AND a.Nazionalita = 'Italiana' 
GROUP BY o.NomeM 
HAVING COUNT(*) >= 20;

--oppure...

SELECT *
FROM Musei m
WHERE 20 <= (
      SELECT COUNT(*) 
      FROM Opere o, Artisti a
      WHERE o.NomeA = a.NomeA 
      AND a.Nazionalita = 'Italiana'
      AND o.NomeM = m.NomeM
)

-- 13- Per le opere di artisti italiani che non hanno personaggi, il titolo dell’opera ed il nome dell’artista.
SELECT a.NomeA , o.Titolo
FROM Opere o, Artisti a
WHERE o.NomeA = a.NomeA
AND a.Nazionalita = 'Italiana'
AND NOT EXISTS (
      SELECT * 
      FROM Personaggi p
      WHERE p.Codice = o.Codice
)

-- 14- Il nome dei musei di Londra che non conservano opere di artisti italiani, eccettuato Tiziano.
SELECT m.NomeM 
FROM Musei m 
WHERE m.Citta = 'Londra' 
AND m.NomeM NOT IN (
      SELECT o.NomeM 
      FROM Opere o, Artisti a
      WHERE o.NomeA = a.NomeA
      AND a.Nazionalita = 'Italiana' AND o.NomeA <> 'Tiziano'
  );

-- 15- Per ogni museo, il numero di opere divise per la nazionalità dell’artista.
SELECT M.NomeM, A.Nazionalita, COUNT(O.Codice) AS NumOpere 
FROM Musei M, Opere O, Artisti A
WHERE M.NomeM = O.NomeM 
  AND O.NomeA = A.NomeA
GROUP BY M.NomeM, A.Nazionalita;