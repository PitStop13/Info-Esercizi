-- 1- Il nome di tutte le sale di Pisa
SELECT Nome FROM SALE WHERE Città = 'Pisa';

-- 2- Il titolo dei film di F. Fellini prodotti dopo il 1960.
SELECT Titolo FROM FILM WHERE Regista = 'F. Fellini' AND AnnoProduzione > 1960;

-- 3- Il titolo dei film di fantascienza giapponesi o francesi prodotti dopo il 1990
SELECT Titolo FROM FILM 
WHERE Genere = 'Fantascienza' 
AND (Nazionalità = 'Giapponese' OR Nazionalità = 'Francese') 
AND AnnoProduzione > 1990;

-- 4- Il titolo dei film di fantascienza giapponesi prodotti dopo il 1990 oppure francesi
SELECT Titolo FROM FILM 
WHERE (Genere = 'Fantascienza' AND Nazionalità = 'Giapponese' AND AnnoProduzione > 1990) OR Nazionalità = 'Francese';

-- 5- I titolo dei film dello stesso regista di 'Casablanca'
SELECT Titolo FROM FILM 
WHERE Regista = (SELECT Regista FROM FILM WHERE Titolo = 'Casablanca');

-- 6- Il titolo ed il genere dei film proiettati il giorno di Natale 2004
SELECT F.Titolo, F.Genere FROM FILM F
JOIN PROIEZIONI P ON F.CodFilm = P.CodFilm
WHERE P.DataProiezione = '2004-12-25';

-- 7- Il titolo ed il genere dei film proiettati a Napoli il giorno di Natale 2004
SELECT F.Titolo, F.Genere FROM FILM F
JOIN PROIEZIONI P ON F.CodFilm = P.CodFilm
JOIN SALE S ON P.CodSala = S.CodSala
WHERE S.Città = 'Napoli' AND P.DataProiezione = '2004-12-25';

-- 8- I nomi delle sale di Napoli in cui il giorno di Natale 2004 è stato proiettato un film con R.Williams
SELECT S.Nome FROM SALE S
JOIN PROIEZIONI P ON S.CodSala = P.CodSala
JOIN FILM F ON P.CodFilm = F.CodFilm
JOIN RECITA R ON F.CodFilm = R.CodFilm
JOIN ATTORI A ON R.CodAttore = A.CodAttore
WHERE S.Città = 'Napoli' AND P.DataProiezione = '2004-12-25' AND A.Nome = 'R.Williams';

-- 9- Il titolo dei film in cui recita M. Mastroianni oppure S.Loren
SELECT DISTINCT F.Titolo FROM FILM F
JOIN RECITA R ON F.CodFilm = R.CodFilm
JOIN ATTORI A ON R.CodAttore = A.CodAttore
WHERE A.Nome = 'M. Mastroianni' OR A.Nome = 'S.Loren';

-- (10 Saltata)

-- 11- Per ogni film in cui recita un attore francese, il titolo del film e il nome dell'attore
SELECT F.Titolo, A.Nome FROM FILM F
JOIN RECITA R ON F.CodFilm = R.CodFilm
JOIN ATTORI A ON R.CodAttore = A.CodAttore
WHERE A.Nazionalità = 'Francese';

-- 12- Per ogni film che è stato proiettato a Pisa nel gennaio 2005, il titolo del film e il nome della sala.
SELECT F.Titolo, S.Nome FROM FILM F
JOIN PROIEZIONI P ON F.CodFilm = P.CodFilm
JOIN SALE S ON P.CodSala = S.CodSala
WHERE S.Città = 'Pisa' AND P.DataProiezione BETWEEN '2005-01-01' AND '2005-01-31';

-- 13- Il numero di sale di Pisa con più di 60 posti
SELECT COUNT(*) FROM SALE WHERE Città = 'Pisa' AND Posti > 60;

-- 14- Il numero totale di posti nelle sale di Pisa
SELECT SUM(Posti) FROM SALE WHERE Città = 'Pisa';

-- 15- Per ogni città, il numero di sale
SELECT Città, COUNT(*) FROM SALE GROUP BY Città;

-- 16- Per ogni città, il numero di sale con più di 60 posti
SELECT Città, COUNT(*) FROM SALE WHERE Posti > 60 GROUP BY Città;

-- 17- Per ogni regista, il numero di film diretti dopo il 1990
SELECT Regista, COUNT(*) FROM FILM WHERE AnnoProduzione > 1990 GROUP BY Regista;

-- 18- Per ogni regista, l’incasso totale di tutte le proiezioni dei suoi film
SELECT F.Regista, SUM(P.Incasso) FROM FILM F
JOIN PROIEZIONI P ON F.CodFilm = P.CodFilm
GROUP BY F.Regista;

-- 19- Per ogni film di S.Spielberg, il titolo del film, il numero totale di proiezioni a Pisa e l’incasso totale
SELECT F.Titolo, COUNT(P.CodProiezione), SUM(P.Incasso) FROM FILM F
JOIN PROIEZIONI P ON F.CodFilm = P.CodFilm
JOIN SALE S ON P.CodSala = S.CodSala
WHERE F.Regista = 'S.Spielberg' AND S.Città = 'Pisa'
GROUP BY F.Titolo;

-- 20- Per ogni regista e per ogni attore, il numero di film del regista con l’attore
SELECT F.Regista, A.Nome, COUNT(*) FROM FILM F
JOIN RECITA R ON F.CodFilm = R.CodFilm
JOIN ATTORI A ON R.CodAttore = A.CodAttore
GROUP BY F.Regista, A.Nome;
