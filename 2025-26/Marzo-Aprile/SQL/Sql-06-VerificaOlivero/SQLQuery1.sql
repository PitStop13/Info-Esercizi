--1
SELECT * FROM Romanzo
WHERE YEAR(AnnoPubblicazione) >= 1990;

--2
SELECT * FROM Romanzo
WHERE YEAR(AnnoPubblicazione) BETWEEN 1900 AND 1999;

--3
SELECT a.Nome, a.Cognome,r.Titolo FROM Autore AS a, Romanzo as r
WHERE a.id = r.Autore
ORDER BY a.Cognome, a.Nome;

--4
SELECT a.Nome,a.Cognome,r.Titolo FROM Autore AS a, Romanzo as r
WHERE a.id = r.Autore AND a.Nazionalità = 'Russa'
ORDER BY a.Nome, a.Cognome;

--5
SELECT r.Titolo FROM Autore AS a,Romanzo AS r
WHERE a.id = r.Autore AND YEAR(a.DataNascita) BETWEEN 1900 AND 1999
ORDER BY a.Nome, a.Cognome;

--6 (NON FUNZIONA)
SELECT r.Titolo, r.AnnoPubblicazione FROM Autore AS a,Romanzo AS r
WHERE a.id = r.Autore AND a.DataMorte != NULL;

--7


--8
SELECT r.Titolo FROM Romanzo AS r
WHERE r.Titolo LIKE '%Sposi%';

--9
SELECT r.Titolo FROM Romanzo AS r
WHERE YEAR(r.AnnoPubblicazione) < 1990 AND (r.Titolo LIKE '%Sposi%' OR  r.Titolo LIKE '%sposi%');

--10
SELECT DISTINCT r.Titolo FROM Autore AS a,Romanzo AS r
WHERE a.id = r.Autore AND a.Nome = 'Don DeLillo';

--11
SELECT DISTINCT r.Titolo FROM Romanzo AS r,Personaggio as p, PersonaggioRomanzo as pr
WHERE r.Id = pr.Romanzo AND  pr.Personaggio = p.Id AND p.Nome = 'Benjamin Malaussène';