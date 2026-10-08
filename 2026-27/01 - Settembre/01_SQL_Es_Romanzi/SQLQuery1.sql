	-- 1. Romanzi pubblicati nel 2009
	SELECT Titolo
	FROM Romanzo
	WHERE Romanzo.AnnoPubblicazione=2009

	-- 2. Romanzi pubblicati a partire dal 1990
	SELECT Titolo
	FROM Romanzo
	WHERE Romanzo.AnnoPubblicazione>=1990

	-- 3. Romanzi del ventesimo secolo
	SELECT Titolo
	FROM Romanzo
	WHERE Romanzo.AnnoPubblicazione BETWEEN 1900 AND 2000

	-- 4. Autore (cioè Nome e Cognome) e Titolo di tutti i romanzi
	SELECT Autore.Nome, Autore.Cognome, Romanzo.Titolo
	FROM Autore, Romanzo
	WHERE Romanzo.Autore=Autore.Id

	-- 5. Autore (cioè Nome e Cognome) e Titolo di tutti i romanzi, ordinati per cognome e nome dell’autore
	SELECT Autore.Nome, Autore.Cognome, Romanzo.Titolo
	FROM Autore, Romanzo
	WHERE Romanzo.Autore=Autore.Id
	ORDER BY Cognome ASC, Nome ASC
	
	-- 6. Autore (cioè Nome e Cognome) e Titolo dei romanzi di autori russi, ordinati per cognome e nome dell’autore
	SELECT Autore.Nome, Autore.Cognome, Romanzo.Titolo
	FROM Autore, Romanzo
	WHERE Romanzo.Autore=Autore.Id AND Autore.Nazionalita LIKE '%russa%'
	ORDER BY Cognome ASC, Nome ASC
	
	-- 7. Titolo dei romanzi di autori nati nel ventesimo secolo, ordinati per cognome e nome dell’autore e – a parità di autore – di data di pubblicazione
	SELECT Titolo
	FROM Romanzo, Autore
	WHERE Romanzo.Autore=Autore.Id AND YEAR(Autore.DataNascita) BETWEEN 1900 AND 2000
	ORDER BY Autore.Cognome ASC, Autore.Nome ASC, Romanzo.AnnoPubblicazione ASC
	
	-- 8. Titolo e anno di pubblicazione di romanzi di autori viventi
	SELECT Titolo, AnnoPubblicazione
	FROM Romanzo, Autore
	WHERE Romanzo.Autore=Autore.Id AND Autore.DataMorte IS NULL
	
	-- 9. Romanzi di scrittori viventi, oppure morti ma non a Torino
	SELECT Titolo, AnnoPubblicazione
	FROM Romanzo, Autore
	WHERE Romanzo.Autore=Autore.Id AND (Autore.DataMorte IS NULL OR Autore.LuogoMorte != 'Torino')
	
	-- 10. Titolo e anno di pubblicazione dei romanzi di scrittori nati a Roma
	SELECT Titolo, AnnoPubblicazione
	FROM Romanzo, Autore
	WHERE Romanzo.AnnoPubblicazione=Autore.Id AND Autore.LuogoNascita = 'ROMA'
	
	-- 11. Romanzi con titolo che inizia per “Tokyo”
	SELECT Titolo
	FROM Romanzo
	WHERE Titolo LIKE 'Tokyo%'
	
	-- 12. Romanzi con la parola “Sposi” nel titolo
	SELECT Titolo
	FROM Romanzo
	WHERE Titolo LIKE '%Sposi%'
	
	-- 13. Romanzi con penultima lettera “i” nel titolo
	SELECT Titolo
	FROM Romanzo
	WHERE Titolo LIKE '%i_'
	
	-- 14. Romanzi il cui titolo termina per “blues”
	SELECT Titolo
	FROM Romanzo
	WHERE Titolo LIKE '%blues'
	
	-- 15. Romanzi pubblicati del ventesimo secolo e con la parola “Zeno” nel titolo
	SELECT Titolo
	FROM Romanzo
	WHERE Titolo LIKE '%Zeno%' AND AnnoPubblicazione BETWEEN 1900 AND 2000
	
	-- 16. Romanzi pubblicati prima del 1900 e con la parola “Sposi” nel titolo, scritta l’iniziale maiuscola o minuscola
	SELECT Titolo
	FROM Romanzo
	WHERE Titolo LIKE '%Sposi%' AND AnnoPubblicazione < 1900
	
	-- 17. Romanzi di Alessandro Manzoni
	SELECT Titolo
	FROM Romanzo, Autore
	WHERE Romanzo.Autore=Autore.Id AND Autore.Nome = 'Alessandro' AND Autore.Cognome = 'Manzoni' 
	
	-- 18. Titoli dei romanzi scritti da Don DeLillo, escludendo eventuali duplicati
	SELECT DISTINCT Titolo
	FROM Romanzo, Autore
	WHERE Romanzo.Autore=Autore.Id AND Autore.Nome = 'Don' AND Autore.Cognome = 'DeLillo' 
	
	-- 19. Romanzi con il personaggio di Benjamin Malaussène
	SELECT Titolo
	FROM Romanzo, Personaggio,PersonaggioRomanzo
	WHERE PersonaggioRomanzo.Romanzo=Romanzo.Id AND PersonaggioRomanzo.Personaggio=Personaggio.Id AND Personaggio.Nome = 'Benjamin' AND Personaggio.Cognome = 'Malaussène' 
	
	-- 20. Romanzi il cui autore non è presente nel database
	SELECT DISTINCT Titolo
	FROM Romanzo
	WHERE Romanzo.Autore IS NULL

