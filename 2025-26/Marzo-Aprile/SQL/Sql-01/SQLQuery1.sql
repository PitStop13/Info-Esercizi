/*
	1) Selezionare il nome, l'età e il salario degli impiegati con più di 50 anni
*/

SELECT nome, eta, salario
FROM Impiegato
WHERE eta > 50;

/*
	2) Estrarre tutte le informazioni riguardanti gli acquisti di tende
*/

SELECT *
FROM Acquisto
WHERE item = 'Tenda';

/*
	3) Di tutti i prodotti comprati dal cliente con id= 10449 mostrare nome, prezzo e idCliente
*/

SELECT prezzo, idCliente, nome, item
FROM Acquisto, Cliente
WHERE idCliente = Cliente.Id AND idCliente = 1;

/*
	4) Dove il titolo inizia con "Ing";
*/

SELECT nome, titolo, dip
FROM Impiegato
WHERE titolo LIKE 'Ing%'; -- Il % è qualsiasi cosa, il _ è qualsiasi carattere al posto

/*
	5) Chi ha titolo programmatore e guadagna >5000
*/

SELECT *
FROM Impiegato
WHERE titolo = 'Programmatore' AND salario >= 5000

/*
	6) Chi lavora a "Vendite" o "Programmazione"
*/

SELECT *
FROM Impiegato
WHERE dip = 'Vendite' OR dip = 'Programmazione';

/*
	7) Tutte le età distinte
*/

SELECT eta, nome -- DISTINCT serve a vedere solo la prima istanza
FROM Impiegato

/*
	8) Stipendio medio
*/

SELECT AVG(salario) AS StipendioMedio
FROM Impiegato

/*
	12) Vendite in ordine ascendente di stipendio
*/

SELECT *
FROM Impiegato
WHERE dip = 'Vendite'
ORDER BY salario ASC

/*
	13) Vendite in ordine ascendente di stipendio e discendente di età (pari stipendio)
*/

SELECT *
FROM Impiegato
WHERE dip = 'Vendite'
ORDER BY salario ASC, eta DESC

-- 14) Dati di impiegati: 'Erica', 'Kim' e 'Benjamin'


SELECT *
FROM Impiegato
WHERE nome IN ('Erica', 'Kim', 'Benjamin')
-- uguale a WHERE nome = 'Erica' OR nome = 'Kim' OR nome = 'Benjamin'


-- 15) Tutti impiegati tranne 'Erica', 'Kim' e 'Benjamin'

SELECT *
FROM Impiegato
WHERE NOT nome IN ('Erica', 'Kim', 'Benjamin')

--  16) Impiegati tra 20 e 70 anni

SELECT *
FROM Impiegato
WHERE eta BETWEEN 20 AND 70

-- 17) Per ogni acquisto nome cliente e prezzo prodotto

SELECT Acquisto.prezzo, Cliente.nome
FROM Acquisto, Cliente
WHERE Acquisto.idCliente = Cliente.Id


