

-- 1) Selezionare il nome, l’età e il salario degli impiegati con più di 50 anni
SELECT nome, eta, salario 
FROM Impiegato 
WHERE eta > 50;

-- 2) Estrarre tutte le informazioni relative agli acquisti di tende (cioè dove item=Tenda)
SELECT * FROM Acquisto 
WHERE item = 'Tenda';

-- 3) Di tutti i prodotti comprati dal cliente con id=10449 mostrare nome, prezzo e id del cliente
-- "item" rappresenta il nome del prodotto nella tabella Acquisto
SELECT item, prezzo, idCliente 
FROM Acquisto 
WHERE idCliente = 10449;

-- 4) Trovare il nome, il titolo e il dipartimento degli impiegati il cui titolo comincia con "Ing"
SELECT nome, titolo, dip 
FROM Impiegato 
WHERE titolo LIKE 'Ing%';

-- 5) Nome, titolo e salario di tutti coloro che hanno il titolo di programmatore e un salario >= 50000
SELECT nome, titolo, salario 
FROM Impiegato 
WHERE titolo = 'Programmatore' AND salario >= 50000;

-- 6) Nome e salario di tutti coloro che lavorano al dipartimento 'Vendite' o 'Programmazione'
SELECT nome, salario 
FROM Impiegato 
WHERE dip IN ('Vendite', 'Programmazione');

/* Oppure:
			SELECT nome, salario 
			FROM Impiegato 
			WHERE dip = 'Vendite' OR dip = 'Programmazione';
*/

-- 7) Selezionare tutte le diverse età degli impiegati
SELECT DISTINCT eta 
FROM Impiegato;

-- 8) Selezionare lo stipendio medio degli impiegati
SELECT AVG(salario) AS StipendioMedio 
FROM Impiegato;

-- 12) Estrarre i dati degli impiegati del dipartimento "Vendite" in ordine (ascendente) di stipendio
SELECT * FROM Impiegato 
WHERE dip = 'Vendite' 
ORDER BY salario ASC;

-- 13) Estrarre i dati degli impiegati del dipartimento "Vendite" in ordine ascendente di stipendio e discendente di età (a pari stipendio)
SELECT * FROM Impiegato 
WHERE dip = 'Vendite' 
ORDER BY salario ASC, eta DESC;

-- 14) Estrarre tutti i dati degli impiegati 'Hernandez', 'Jones', 'Roberts', 'Ruiz'
SELECT * FROM Impiegato 
WHERE nome IN ('Hernandez', 'Jones', 'Roberts', 'Ruiz');

-- 15) Estrarre tutti i dati di tutti gli impiegati tranne 'Hernandez', 'Jones', 'Roberts' e 'Ruiz'
SELECT * FROM Impiegato 
WHERE nome NOT IN ('Hernandez', 'Jones', 'Roberts', 'Ruiz');

-- 16) Estrarre tutti i dati degli impiegati di età compresa tra 30 e 40 anni
SELECT * FROM Impiegato 
WHERE eta BETWEEN 30 AND 40;

-- 17) Estrarre, per ogni acquisto, il nome del cliente e il prezzo del prodotto
SELECT c.nome, a.prezzo FROM Acquisto a
JOIN Cliente c ON a.idCliente = c.id;
