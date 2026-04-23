/* 1) Selezionare il nome, l'età e il salario degli impiegati con più di 50 anni */
SELECT nome, eta, salario  -- Estrae solo le tre colonne specificate, ignorando le altre (es. titolo, dip)
FROM Impiegato             -- Specifica la tabella di origine dei dati
WHERE eta > 50;            -- Applica il filtro per mostrare solo chi ha un'età strettamente maggiore di 50

---

/* 2) Estrarre tutte le informazioni relative agli acquisti di tende */
SELECT * -- L'asterisco (*) è un comando rapido per dire "seleziona tutte le colonne della tabella"
FROM Acquisto              -- Specifica la tabella di origine
WHERE item = 'Tenda';      -- Filtra i record escludendo qualsiasi item che non sia esattamente la stringa 'Tenda'

---

/* 3) Di tutti i prodotti comprati dal cliente con id=1 mostrare nome prodotto, prezzo e id del cliente con nome del relativo cliente */
SELECT 
    Cliente.nome AS NomeCliente,        -- Prende il nome da 'Cliente' e rinomina la colonna in 'NomeCliente'
    Acquisto.item AS NomeProdotto,      -- Prende l'item da 'Acquisto' e rinomina la colonna in 'NomeProdotto'
    Acquisto.prezzo AS Prezzo,          -- Prende il prezzo e usa l'alias 'Prezzo' (con la maiuscola)
    Acquisto.idCliente AS CodiceCliente -- Mostra l'ID e lo rinomina in 'CodiceCliente'
FROM 
    Acquisto, Cliente                   -- Dichiara che la query ha bisogno di leggere dati da entrambe le tabelle
WHERE 
    Acquisto.idCliente = Cliente.Id     -- CONDIZIONE DI JOIN: Definisce la relazione tra le tabelle, abbinando gli acquisti al giusto cliente
    AND Acquisto.idCliente = 1;         -- CONDIZIONE DI FILTRO: Restringe l'intero risultato al solo cliente con ID 1

/* 4) Trovare il nome, il titolo e il dipartimento degli impiegati il cui titolo comincia per "ing"*/
SELECT nome, titolo, dip         -- Seleziona solo le colonne di interesse
FROM Impiegato                   -- Specifica la tabella da cui estrarre i dati
WHERE titolo LIKE 'ing%';        -- Usa l'operatore LIKE per filtrare i titoli che iniziano con 'ing' (il simbolo % rappresenta qualsiasi sequenza di caratteri)


/*5) Nome, titolo e salario di tutti coloro che hanno il titolo di programmatore e un salario >= 50000*/
SELECT nome, titolo, salario     -- Seleziona solo le colonne di interesse
FROM Impiegato                   -- Specifica la tabella da cui estrarre i dati
WHERE titolo = 'programmatore' AND salario >= 50000; -- Applica due condizioni: il titolo deve essere esattamente 'Programmatore' e il salario deve essere almeno 50000

/*6) Nome e salario di tutti coloro che lavorano al dipartimento ‘Vendite' o 'Programmazione' */
SELECT nome, salario
FROM Impiegato
WHERE dip = 'Vendite' OR dip = 'Programmazione'; -- Usa l'operatore OR per includere impiegati che lavorano in uno dei due dipartimenti specificati

/*7) Selezionare tutte le diverse età degli impiegati */
SELECT eta,nome -- L'uso di DISTINCT garantisce che vengano restituite solo età uniche, eliminando i duplicati
FROM Impiegato

/*8) Selezionare lo stipendio medio degli impiegati*/
SELECT AVG(salario) AS StipendioMedio -- La funzione AVG calcola la media dei valori nella colonna 'salario' e l'alias 'StipendioMedio' rende il risultato più leggibile
FROM Impiegato

/*12) Estrarre i dati degli impiegati del dipartimento “Vendite” in ordine (ascendente) di stipendio*/
SELECT * -- Seleziona tutte le colonne per avere una visione completa dei dati degli impiegati
FROM Impiegato
WHERE dip = 'Vendite' --Filtra per includere solo gli impiegati del dipartimento 'Vendite'
ORDER BY salario ASC; -- Ordina i risultati in ordine crescente (ascendente) in base alla colonna 'salario'

/*13) Estrarre i dati degli impiegati del dipartimento “Vendite” in ordine ascendente di stipendio e discendente di età (a pari stipendio)*/
SELECT * -- Seleziona tutte le colonne per avere una visione completa dei dati degli impiegati
FROM Impiegato
WHERE dip = 'Vendite' --Filtra per includere solo gli impiegati del dipartimento 'Vendite'
ORDER BY salario ASC, eta DESC; /*Ordina i risultati prima in ordine crescente di salario e, in caso di parità, in ordine decrescente di età (basta mettere la virgla poer far
si che diventi una specie di secondo paramtro)*/

-- 14) Estrarre tutti i dati degli impiegati 'Bibi', 'Mossello', 'Parola', 'Cerone'
SELECT * -- Seleziona tutte le colonne per avere una visione completa dei dati degli impiegati
FROM Impiegato
WHERE nome IN ('Bibi', 'Mossello', 'Parola', 'Cerone'); -- Usa l'operatore IN per filtrare i record che corrispondono a uno qualsiasi dei nomi specificati nella lista tra parentesi

--15) Estrarre tutti i dati di tutti gli impiegati tranne 'Bibi', 'Mossello', 'Parola', 'Cerone'
SELECT * -- Seleziona tutte le colonne per avere una visione completa dei dati degli impiegati
FROM Impiegato
WHERE NOT nome IN('Bibi', 'Mossello', 'Parola', 'Cerone'); -- Usa l'operatore NOT IN per escludere i record che corrispondono a uno qualsiasi dei nomi specificati nella lista tra parentesi

--16) Estrarre tutti i dati degli impiegati di età compresa tra 30 e 40 anni
SELECT *
FROM Impiegato
WHERE eta BETWEEN 30 AND 40; -- Usa l'operatore BETWEEN per filtrare i record che hanno un'età compresa tra 30 e 40 anni, inclusi entrambi i valori estremi

--17) Estrarre, per ogni acquisto, il nome del cliente e il prezzo del prodotto
SELECT Cliente.nome AS NomeCliente, Acquisto.prezzo AS Prezzo
FROM Acquisto, Cliente
WHERE Acquisto.idCliente = Cliente.Id; -- Applica una condizione di join per abbinare ogni acquisto al cliente corrispondente, permettendo di estrarre il nome del cliente e il prezzo del prodotto acquistato