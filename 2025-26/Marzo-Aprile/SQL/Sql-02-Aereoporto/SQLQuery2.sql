-- Trovare le città da cui partono voli diretti a Milano, ordinate alfabeticamente- 

SELECT Volo.CittaPart as Partenza
FROM Volo
WHERE Volo.CittaArr = 'Milano'
ORDER BY Volo.CittaPart ASC

-- Trovare le città con un aeroporto di cui non è noto il numero di piste

SELECT Aeroporto.Citta
FROM Aeroporto
WHERE Aeroporto.NumPiste IS NULL

-- Di ogni volo misto (merci e passeggeri) estrarre il codice e i dati relativi al trasporto

SELECT Volo.Id, Aereo.NumPasseggeri, Aereo.QtaMerci
FROM Aereo, Volo
WHERE Volo.TipoAereo = Aereo.TipoAereo AND (Aereo.NumPasseggeri = 0 OR Aereo.QtaMerci = 0)