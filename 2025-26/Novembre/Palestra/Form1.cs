using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palestra
{
    public partial class Form1 : Form
    {
        private GestorePalestra gestore;

        public Form1()
        {
            InitializeComponent();
            gestore = new GestorePalestra();
            cmbTipo.SelectedIndex = 0; // Default selection
            AggiornaStatistiche();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Abilita/Disabilita campi in base al tipo selezionato
            string tipo = cmbTipo.SelectedItem.ToString();
            
            bool isCorso = tipo == "CorsoGruppo";
            bool isPT = tipo == "PersonalTraining";
            bool isSala = tipo == "SalaPesi";
            bool isPiscina = tipo == "Piscina";

            txtIstruttore.Enabled = isCorso || isPT;
            txtMaxPartecipanti.Enabled = isCorso || isPiscina;
            chkAccesso24h.Enabled = isSala;
            txtFasciaOraria.Enabled = isPiscina;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                // Lettura dati comuni
                string codice = txtCodice.Text;
                string nome = txtNome.Text;
                decimal costo = decimal.Parse(txtCosto.Text);
                int durata = int.Parse(txtDurata.Text);
                string tipo = cmbTipo.SelectedItem.ToString();

                ServizioPalestra nuovoServizio = null;

                switch (tipo)
                {
                    case "CorsoGruppo":
                        string istruttore = txtIstruttore.Text;
                        int max = int.Parse(txtMaxPartecipanti.Text);
                        nuovoServizio = new CorsoGruppo(codice, nome, costo, durata, istruttore, max);
                        break;
                    case "PersonalTraining":
                        string istruttorePT = txtIstruttore.Text;
                        nuovoServizio = new PersonalTraining(codice, nome, costo, durata, istruttorePT);
                        break;
                    case "SalaPesi":
                        bool accesso24h = chkAccesso24h.Checked;
                        nuovoServizio = new SalaPesi(codice, nome, costo, durata, accesso24h);
                        break;
                    case "Piscina":
                        string fasciaOraria = txtFasciaOraria.Text;
                        int maxPiscina = int.Parse(txtMaxPartecipanti.Text);
                        nuovoServizio = new Piscina(codice, nome, costo, durata, fasciaOraria, maxPiscina);
                        break;
                }

                if (nuovoServizio != null)
                {
                    gestore.AggiungiServizio(nuovoServizio);
                    MessageBox.Show("Servizio aggiunto con successo!");
                    PulisciCampi();
                    AggiornaLista();
                    AggiornaStatistiche();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }

        private void PulisciCampi()
        {
            txtCodice.Clear();
            txtNome.Clear();
            txtCosto.Clear();
            txtDurata.Clear();
            txtIstruttore.Clear();
            txtMaxPartecipanti.Clear();
            txtFasciaOraria.Clear();
            chkAccesso24h.Checked = false;
        }

        private void AggiornaLista(List<ServizioPalestra> lista = null)
        {
            lstServizi.Items.Clear();
            var elenco = lista ?? gestore.GetTuttiServizi();
            
            foreach (var s in elenco)
            {
                lstServizi.Items.Add(s); // Chiama automaticamente ToString()
            }
        }

        private void btnMostraTutti_Click(object sender, EventArgs e)
        {
            AggiornaLista();
        }

        private void btnCercaIstruttore_Click(object sender, EventArgs e)
        {
            string cerca = txtCercaIstruttore.Text;
            if (!string.IsNullOrWhiteSpace(cerca))
            {
                var risultati = gestore.CercaPerIstruttore(cerca);
                AggiornaLista(risultati);
            }
        }

        private void lstServizi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServizi.SelectedItem is ServizioPalestra servizio)
            {
                string info = servizio.DescrizioneServizio(); // Polimorfismo
                if (servizio is IPrenotabile prenotabile)
                {
                    info += $"\nPosti Disponibili: {prenotabile.PostiDisponibili}";
                    btnPrenota.Enabled = true;
                    btnAnnulla.Enabled = true;
                }
                else
                {
                    info += "\nNon richiede prenotazione.";
                    btnPrenota.Enabled = false;
                    btnAnnulla.Enabled = false;
                }
                lblInfo.Text = info;
            }
        }

        private void btnPrenota_Click(object sender, EventArgs e)
        {
            if (lstServizi.SelectedItem is IPrenotabile prenotabile)
            {
                string cliente = txtNomeCliente.Text;
                if (string.IsNullOrWhiteSpace(cliente))
                {
                    MessageBox.Show("Inserisci il nome del cliente.");
                    return;
                }

                if (prenotabile.Prenota(cliente))
                {
                    MessageBox.Show("Prenotazione effettuata!");
                    // Aggiorna la vista per mostrare i nuovi posti disponibili
                    lstServizi_SelectedIndexChanged(null, null);
                    // Ridisegna l'elemento nella lista (trick per aggiornare il testo se cambia ToString)
                    int index = lstServizi.SelectedIndex;
                    lstServizi.Items[index] = lstServizi.Items[index]; 
                    
                    AggiornaStatistiche();
                }
                else
                {
                    MessageBox.Show("Impossibile prenotare (posti esauriti o altro errore).");
                }
            }
        }

        private void AggiornaStatistiche()
        {
            var corsoMigliore = gestore.CorsoMigliore();
            string nomeMigliore = corsoMigliore != null ? corsoMigliore.Nome : "N/A";
            lblStatistiche.Text = $"Prenotazioni Attive: {gestore.TotalePrenotazioniAttive()} | Fatturato Previsto: {gestore.CalcolaFatturatoAtteso():C} | Corso Più Richiesto: {nomeMigliore}";
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            if (lstServizi.SelectedItem is IPrenotabile prenotabile)
            {
                string cliente = txtNomeCliente.Text;
                if (string.IsNullOrWhiteSpace(cliente))
                {
                    MessageBox.Show("Inserisci il nome del cliente da annullare.");
                    return;
                }

                if (prenotabile.AnnullaPrenotazione(cliente))
                {
                    MessageBox.Show("Prenotazione annullata!");
                    lstServizi_SelectedIndexChanged(null, null);
                    int index = lstServizi.SelectedIndex;
                    lstServizi.Items[index] = lstServizi.Items[index];
                    AggiornaStatistiche();
                    txtNomeCliente.Clear();
                }
                else
                {
                    MessageBox.Show("Impossibile annullare (cliente non trovato).");
                }
            }
        }

        private void btnCorsiQuasiPieni_Click(object sender, EventArgs e)
        {
            var risultati = gestore.CercaCorsiQuasiPieni(3);
            AggiornaLista(risultati);
            if(risultati.Count == 0)
            {
                MessageBox.Show("Nessun corso con meno di 3 posti liberi.");
            }
        }
    }
}
