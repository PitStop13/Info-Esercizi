using System;
using System.Collections.Generic;
using System.Linq;

namespace Palestra
{
    public class GestorePalestra
    {
        // Collezione Generica: Lista principale di tutti i servizi
        private List<ServizioPalestra> listaServizi;
        
        // Collezione Generica: Dizionario per ricerca veloce tramite Codice
        private Dictionary<string, ServizioPalestra> mappaServizi;

        public GestorePalestra()
        {
            listaServizi = new List<ServizioPalestra>();
            mappaServizi = new Dictionary<string, ServizioPalestra>();
        }

        public void AggiungiServizio(ServizioPalestra servizio)
        {
            if (mappaServizi.ContainsKey(servizio.Codice))
            {
                throw new Exception("Esiste già un servizio con questo codice!");
            }

            listaServizi.Add(servizio);
            mappaServizi.Add(servizio.Codice, servizio);
        }

        public List<ServizioPalestra> GetTuttiServizi()
        {
            // Restituisce una copia o la lista stessa
            return listaServizi;
        }

        public ServizioPalestra CercaPerCodice(string codice)
        {
            if (mappaServizi.ContainsKey(codice))
            {
                return mappaServizi[codice];
            }
            return null;
        }

        // Esempio di metodo che sfrutta il polimorfismo per filtrare o cercare
        public List<ServizioPalestra> CercaPerIstruttore(string nomeIstruttore)
        {
            List<ServizioPalestra> risultati = new List<ServizioPalestra>();
            
            foreach (var servizio in listaServizi)
            {
                // Controllo se il servizio è di un tipo che ha un istruttore
                if (servizio is CorsoGruppo corso)
                {
                    if (corso.Istruttore.ToLower().Contains(nomeIstruttore.ToLower()))
                        risultati.Add(servizio);
                }
                else if (servizio is PersonalTraining pt)
                {
                    if (pt.Istruttore.ToLower().Contains(nomeIstruttore.ToLower()))
                        risultati.Add(servizio);
                }
            }
            return risultati;
        }

        public List<ServizioPalestra> CercaPrenotabili()
        {
             // Usa LINQ o un ciclo foreach per trovare chi implementa IPrenotabile
             return listaServizi.Where(s => s is IPrenotabile).ToList();
        }

        public decimal CalcolaFatturatoAtteso()
        {
            decimal totale = 0;
            foreach (var servizio in listaServizi)
            {
                // Logica semplificata: se è prenotabile conta i prenotati, altrimenti conta il costo fisso (es. abbonamento mensile)
                if (servizio is IPrenotabile prenotabile)
                {
                    int prenotati = 0;
                    if (servizio is CorsoGruppo cg) prenotati = cg.MaxPartecipanti - cg.PostiDisponibili;
                    else if (servizio is PersonalTraining pt) prenotati = pt.PostiDisponibili == 0 ? 1 : 0;
                    else if (servizio is Piscina piscina) prenotati = piscina.MaxPartecipanti - piscina.PostiDisponibili;
                    
                    totale += prenotati * servizio.Costo;
                }
                else
                {
                     // Es. se è SalaPesi immaginiamo sia una quota mensile, la contiamo una volta per semplicità
                     // o potremmo avere una logica più complessa. Per ora sommiamo il costo base.
                     totale += servizio.Costo;
                }
            }
            return totale;
        }
        
        public int TotalePrenotazioniAttive()
        {
            int count = 0;
            foreach(var s in listaServizi)
            {
                if (s is IPrenotabile p)
                {
                    if (s is CorsoGruppo cg) count += (cg.MaxPartecipanti - cg.PostiDisponibili);
                    else if (s is PersonalTraining pt) count += (pt.PostiDisponibili == 0 ? 1 : 0);
                    else if (s is Piscina piscina) count += (piscina.MaxPartecipanti - piscina.PostiDisponibili);
                }
            }
            return count;
        }

        // Cerca servizi prenotabili con pochi posti liberi (sotto una certa soglia)
        public List<ServizioPalestra> CercaCorsiQuasiPieni(int sogliaPostiLiberi = 3)
        {
            List<ServizioPalestra> risultati = new List<ServizioPalestra>();
            foreach (var s in listaServizi)
            {
                if (s is IPrenotabile p && p.PostiDisponibili < sogliaPostiLiberi && p.PostiDisponibili >= 0)
                {
                    risultati.Add(s);
                }
            }
            return risultati;
        }

        // Trova il corso più prenotato/frequentato
        public ServizioPalestra CorsoMigliore()
        {
            ServizioPalestra piuPopolare = null;
            int maxPrenotazioni = 0;

            foreach (var s in listaServizi)
            {
                int prenotazioni = 0;
                if (s is CorsoGruppo cg) prenotazioni = cg.MaxPartecipanti - cg.PostiDisponibili;
                else if (s is PersonalTraining pt) prenotazioni = pt.PostiDisponibili == 0 ? 1 : 0;
                else if (s is Piscina piscina) prenotazioni = piscina.MaxPartecipanti - piscina.PostiDisponibili;

                if (prenotazioni > maxPrenotazioni)
                {
                    maxPrenotazioni = prenotazioni;
                    piuPopolare = s;
                }
            }
            return piuPopolare;
        }
    }
}
