-- ==============================================================================
-- DATABASE: SCUOLA RIPASSO (Esercizio 06)
-- SCHEMA:
--   CORSIDILAUREA(CorsoLaurea, TipoLaurea, Facoltà)
--   DOCENTI(CodDocente, NomeD, Dipartimento)
--   CORSI(CodCorso, NomeCorso, CodDocente)
--   STUDENTI(Matricola, NomeS, CorsoLaurea, AnnoN)
--   FREQUENTA(Matricola, CodCorso)
-- ==============================================================================

-- 1. Il nome e l’anno di nascita degli studenti iscritti a SBC, in ordine rispetto al nome
SELECT s.NomeS, s.AnnoN
FROM STUDENTI s
WHERE s.CorsoLaurea = 'SBC'
ORDER BY s.NomeS ASC;


-- 2. Il nome ed il Dipartimento dei docenti di “Basi di Dati e Sistemi Informativi” o di “Informatica Generale”
SELECT d.NomeD, d.Dipartimento
FROM DOCENTI d, CORSI c
WHERE d.CodDocente = c.CodDocente
  AND (c.NomeCorso = 'Basi di Dati e Sistemi Informativi' OR c.NomeCorso = 'Informatica Generale');


-- 3. Matricola e nome degli studenti di un corso di laurea triennale (tipoLaurea = 'L')
--    che seguono un corso di un docente di nome Felice.
SELECT DISTINCT s.Matricola, s.NomeS
FROM STUDENTI s, CORSIDILAUREA cl, FREQUENTA f, CORSI c, DOCENTI d
WHERE s.CorsoLaurea = cl.CorsoLaurea
  AND s.Matricola = f.Matricola
  AND f.CodCorso = c.CodCorso
  AND c.CodDocente = d.CodDocente
  AND cl.TipoLaurea = 'L'
  AND d.NomeD = 'Felice';


-- 4. Per ogni tipo di laurea, il tipoLaurea e l’età media degli studenti
-- Nota: L'età si calcola come anno corrente meno AnnoNascita
SELECT cl.TipoLaurea, AVG(YEAR(GETDATE()) - s.AnnoN) AS EtaMedia
FROM CORSIDILAUREA cl, STUDENTI s
WHERE cl.CorsoLaurea = s.CorsoLaurea
GROUP BY cl.TipoLaurea;


-- 5. Di ogni corso di un docente di nome Leoni, il CodCorso e il numero degli studenti che lo frequentano
SELECT c.CodCorso, COUNT(f.Matricola) AS NumeroStudenti
FROM CORSI c, DOCENTI d, FREQUENTA f
WHERE c.CodDocente = d.CodDocente
  AND c.CodCorso = f.CodCorso
  AND d.NomeD = 'Leoni'
GROUP BY c.CodCorso;

-- Se si vuole mostrare anche 0 se non ci fossero studenti (con subquery):
-- SELECT c.CodCorso, 
--        (SELECT COUNT(*) FROM FREQUENTA f WHERE f.CodCorso = c.CodCorso) AS NumeroStudenti
-- FROM CORSI c, DOCENTI d
-- WHERE c.CodDocente = d.CodDocente
--   AND d.NomeD = 'Leoni';


-- 6. Il codice dei corsi frequentati da più di 5 studenti e tenuti da docenti del Dipartimento di Informatica
SELECT c.CodCorso
FROM CORSI c, DOCENTI d, FREQUENTA f
WHERE c.CodDocente = d.CodDocente
  AND c.CodCorso = f.CodCorso
  AND d.Dipartimento = 'Informatica'
GROUP BY c.CodCorso
HAVING COUNT(f.Matricola) > 5;


-- 7. Per ogni studente della Facoltà di Lettere e Filosofia, la matricola ed il numero di corsi seguiti
-- Versione A (classica con WHERE e GROUP BY, per studenti con almeno un corso seguito):
SELECT s.Matricola, COUNT(f.CodCorso) AS NumeroCorsi
FROM STUDENTI s, CORSIDILAUREA cl, FREQUENTA f
WHERE s.CorsoLaurea = cl.CorsoLaurea
  AND s.Matricola = f.Matricola
  AND cl.Facoltà = 'Lettere e Filosofia'
GROUP BY s.Matricola;

-- Versione B (mostra anche 0 per studenti che non seguono nessun corso, usando sottoquery):
-- SELECT s.Matricola, 
--        (SELECT COUNT(*) FROM FREQUENTA f WHERE f.Matricola = s.Matricola) AS NumeroCorsi
-- FROM STUDENTI s, CORSIDILAUREA cl
-- WHERE s.CorsoLaurea = cl.CorsoLaurea
--   AND cl.Facoltà = 'Lettere e Filosofia';


-- 8. Matricola e nome degli studenti che non frequentano nessun corso
SELECT s.Matricola, s.NomeS
FROM STUDENTI s
WHERE s.Matricola NOT IN (
    SELECT f.Matricola
    FROM FREQUENTA f
);

-- Oppure con NOT EXISTS:
-- SELECT s.Matricola, s.NomeS
-- FROM STUDENTI s
-- WHERE NOT EXISTS (
--     SELECT *
--     FROM FREQUENTA f
--     WHERE f.Matricola = s.Matricola
-- );


-- 9. Il Codice ed il Nome dei docenti dei Corsi che non sono frequentati da nessuno studente
SELECT d.CodDocente, d.NomeD
FROM DOCENTI d, CORSI c
WHERE d.CodDocente = c.CodDocente
  AND c.CodCorso NOT IN (
      SELECT f.CodCorso
      FROM FREQUENTA f
  );


-- 10. Matricola e nome degli studenti che seguono solo corsi di docenti del dipartimento di Storia
-- Spiegazione logica ("SOLO"):
-- 1) Lo studente deve frequentare almeno un corso (IN FREQUENTA)
-- 2) Lo studente NON deve frequentare nessun corso di docenti che NON appartengono a Storia
SELECT s.Matricola, s.NomeS
FROM STUDENTI s
WHERE s.Matricola IN (
    SELECT f.Matricola 
    FROM FREQUENTA f
)
AND s.Matricola NOT IN (
    SELECT f.Matricola
    FROM FREQUENTA f, CORSI c, DOCENTI d
    WHERE f.CodCorso = c.CodCorso
      AND c.CodDocente = d.CodDocente
      AND d.Dipartimento <> 'Storia'
);

-- Oppure con EXISTS e NOT EXISTS:
-- SELECT s.Matricola, s.NomeS
-- FROM STUDENTI s
-- WHERE EXISTS (
--     SELECT *
--     FROM FREQUENTA f, CORSI c, DOCENTI d
--     WHERE f.Matricola = s.Matricola
--       AND f.CodCorso = c.CodCorso
--       AND c.CodDocente = d.CodDocente
--       AND d.Dipartimento = 'Storia'
-- )
-- AND NOT EXISTS (
--     SELECT *
--     FROM FREQUENTA f, CORSI c, DOCENTI d
--     WHERE f.Matricola = s.Matricola
--       AND f.CodCorso = c.CodCorso
--       AND c.CodDocente = d.CodDocente
--       AND d.Dipartimento <> 'Storia'
-- );


-- 11. Il CodCorso dei corsi seguiti solo da studenti che appartengono al Corso di Laurea Triennale in SBC
-- Spiegazione:
-- 1) Il corso deve essere seguito da almeno uno studente
-- 2) Il corso NON deve essere seguito da nessuno studente con CorsoLaurea diverso da 'SBC'
SELECT c.CodCorso
FROM CORSI c
WHERE c.CodCorso IN (
    SELECT f.CodCorso 
    FROM FREQUENTA f
)
AND c.CodCorso NOT IN (
    SELECT f.CodCorso
    FROM FREQUENTA f, STUDENTI s
    WHERE f.Matricola = s.Matricola
      AND s.CorsoLaurea <> 'SBC'
);


-- 12. Nome e CodDocente dei docenti che insegnano qualche corso seguito da più di 5 studenti
SELECT DISTINCT d.NomeD, d.CodDocente
FROM DOCENTI d, CORSI c, FREQUENTA f
WHERE d.CodDocente = c.CodDocente
  AND c.CodCorso = f.CodCorso
GROUP BY d.CodDocente, d.NomeD, c.CodCorso
HAVING COUNT(f.Matricola) > 5;

-- Oppure con sottoquery semplice:
-- SELECT d.NomeD, d.CodDocente
-- FROM DOCENTI d, CORSI c
-- WHERE d.CodDocente = c.CodDocente
--   AND (
--       SELECT COUNT(*)
--       FROM FREQUENTA f
--       WHERE f.CodCorso = c.CodCorso
--   ) > 5;


-- 13. Codice dei corsi che sono frequentati da tutti gli studenti del CorsoLaurea SBC
-- METODO 1: Conteggio (il più semplice e intuitivo!)
-- Il numero di studenti di SBC che frequentano il corso deve essere uguale al totale studenti di SBC.
SELECT f.CodCorso
FROM FREQUENTA f, STUDENTI s
WHERE f.Matricola = s.Matricola
  AND s.CorsoLaurea = 'SBC'
GROUP BY f.CodCorso
HAVING COUNT(DISTINCT f.Matricola) = (
    SELECT COUNT(*)
    FROM STUDENTI
    WHERE CorsoLaurea = 'SBC'
);

-- METODO 2: Divisione con doppio NOT EXISTS (classico teorico)
-- "Non esiste alcuno studente di SBC per cui non esista una riga di frequenza a questo corso"
-- SELECT c.CodCorso
-- FROM CORSI c
-- WHERE NOT EXISTS (
--     SELECT *
--     FROM STUDENTI s
--     WHERE s.CorsoLaurea = 'SBC'
--       AND NOT EXISTS (
--           SELECT *
--           FROM FREQUENTA f
--           WHERE f.CodCorso = c.CodCorso
--             AND f.Matricola = s.Matricola
--       )
-- );
