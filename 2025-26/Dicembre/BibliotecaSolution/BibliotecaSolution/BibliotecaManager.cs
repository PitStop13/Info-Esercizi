using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaSolution
{
    /// <summary>
    /// Classe che gestisce l'intero catalogo della biblioteca e le operazioni sui prestiti
    /// </summary>
    /// <summary>
    /// Classe che gestisce l'intero catalogo della biblioteca e le operazioni sui prestiti
    /// </summary>
    public class BibliotecaManager
    {
        private List<ContenutoMultimediale> _catalogo;
        private Dictionary<string, ContenutoMultimediale> _catalogoDictionary; // per ricerca veloce per codice

        public BibliotecaManager()
        {
            _catalogo = new List<ContenutoMultimediale>();
            _catalogoDictionary = new Dictionary<string, ContenutoMultimediale>();
        }

        /// <summary>
        /// Aggiunge un contenuto al catalogo
        /// </summary>
        public void AggiungiContenuto(ContenutoMultimediale contenuto)
        {
            if (contenuto == null) return;
            
            // Assicura che l'ID sia univoco (anche se Guid è robusto,guid è un codice identificativo unico)
            while (_catalogoDictionary.ContainsKey(contenuto.CodiceIdentificativo))
            {
                contenuto.CodiceIdentificativo = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
            }

            _catalogo.Add(contenuto);
            _catalogoDictionary.Add(contenuto.CodiceIdentificativo, contenuto);
        }

        /// <summary>
        /// Ottiene l'intero catalogo
        /// </summary>
        public List<ContenutoMultimediale> OttieniCatalogo()
        {
            return new List<ContenutoMultimediale>(_catalogo);
        }

        /// <summary>
        /// Cerca contenuti per tipo
        /// </summary>
        public List<ContenutoMultimediale> CercaPerTipo(string tipo)
        {
            return _catalogo.Where(c => c.OttieniTipo().Equals(tipo, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Cerca contenuti per categoria
        /// </summary>
        public List<ContenutoMultimediale> CercaPerCategoria(string categoria)
        {
             return _catalogo.Where(c => c.Categoria.IndexOf(categoria, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        /// <summary>
        /// Cerca contenuti per titolo (anche parziale)
        /// </summary>
        public List<ContenutoMultimediale> CercaPerTitolo(string titolo)
        {
            return _catalogo.Where(c => c.Titolo.IndexOf(titolo, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        /// <summary>
        /// Ottiene tutti i contenuti disponibili (non in prestito)
        /// </summary>
        public List<ContenutoMultimediale> OttieniContenutiDisponibili()
        {
            return _catalogo.Where(c => 
                !(c is IPrestabile prestabile) || !prestabile.InPrestito
            ).ToList();
        }

        /// <summary>
        /// Ottiene tutti i contenuti attualmente in prestito
        /// </summary>
        public List<ContenutoMultimediale> OttieniContenutiInPrestito()
        {
            return _catalogo.Where(c => 
                c is IPrestabile prestabile && prestabile.InPrestito
            ).ToList();
        }

        /// <summary>
        /// Presta un contenuto a un utente
        /// </summary>
        public bool PrestaContenuto(string codiceContenuto, string nomeUtente)
        {
            if (!_catalogoDictionary.ContainsKey(codiceContenuto)) return false;

            var contenuto = _catalogoDictionary[codiceContenuto];

            if (contenuto is IPrestabile prestabile)
            {
                try
                {
                    prestabile.Presta(nomeUtente, DateTime.Now);
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false; // Già in prestito o non prestabile
                }
            }
            
            return false; // Non è un oggetto prestabile
        }

        /// <summary>
        /// Restituisce un contenuto
        /// </summary>
        public bool RestituisciContenuto(string codiceContenuto)
        {
            if (!_catalogoDictionary.ContainsKey(codiceContenuto)) return false;

            var contenuto = _catalogoDictionary[codiceContenuto];

            if (contenuto is IPrestabile prestabile)
            {
                 prestabile.Restituisci();
                 return true;
            }

            return false;
        }

        /// <summary>
        /// Ottiene statistiche sul catalogo
        /// </summary>
        public Dictionary<string, int> OttieniStatisticheTipo()
        {
            return _catalogo.GroupBy(c => c.OttieniTipo())
                            .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Ottiene il valore totale del catalogo
        /// </summary>
        public decimal OttieniValoreTotale()
        {
            return _catalogo.Sum(c => c.ValoreCommerciale);
        }

        /// <summary>
        /// Ottiene il numero totale di contenuti
        /// </summary>
        public int OttieniNumeroContenuti()
        {
            return _catalogo.Count;
        }

        /// <summary>
        /// Ottiene i contenuti con prestito scaduto
        /// </summary>
        public List<ContenutoMultimediale> OttieniPrestitiScaduti()
        {
             return _catalogo.Where(c => 
                c is IPrestabile prestabile && prestabile.IsPrestutoScaduto()
            ).ToList();
        }

        /// <summary>
        /// Cerca un contenuto per codice
        /// </summary>
        public ContenutoMultimediale CercaPerCodice(string codice)
        {
            if (_catalogoDictionary.ContainsKey(codice))
            {
                return _catalogoDictionary[codice];
            }
            return null;
        }
    }
}
