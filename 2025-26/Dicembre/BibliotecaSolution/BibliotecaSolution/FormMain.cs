using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BibliotecaSolution
{
    public partial class FormMain : Form
    {
        private BibliotecaManager _biblioteca;

        public FormMain()
        {
            InitializeComponent();
            _biblioteca = new BibliotecaManager();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Inizializza i ComboBox per i tipi di contenuto
            cmbTipoContenuto.Items.AddRange(new string[] { "Libro", "DVD", "Rivista", "Audiolibro", "CD Musicale" });
            cmbFiltroTipo.Items.AddRange(new string[] { "Libro", "DVD", "Rivista", "Audiolibro", "CD Musicale" });
            
            cmbTipoContenuto.SelectedIndex = 0;
            cmbFiltroTipo.SelectedIndex = 0;

            // Inserisci alcuni dati di esempio
            InserisciDatiEsempio();
            
            // Aggiorna le visualizzazioni
            AggiornaCatalogo();
            AggiornaListaPrestiti();
        }

        private void InserisciDatiEsempio()
        {
            // Inserisci alcuni contenuti di esempio
            _biblioteca.AggiungiContenuto(new Libro(
                "Il nome della rosa", 1980, "Narrativa", 18.50m,
                "Umberto Eco", 503, "Bompiani"
            ));

            _biblioteca.AggiungiContenuto(new Libro(
                "1984", 1949, "Narrativa", 15.00m,
                "George Orwell", 328, "Mondadori"
            ));

            _biblioteca.AggiungiContenuto(new DVD(
                "Inception", 2010, "Film", 12.99m,
                "Christopher Nolan", 148, "Fantascienza"
            ));

            _biblioteca.AggiungiContenuto(new DVD(
                "Il Padrino", 1972, "Film", 14.99m,
                "Francis Ford Coppola", 175, "Drammatico"
            ));

            _biblioteca.AggiungiContenuto(new Rivista(
                "Focus", 2024, "Divulgazione scientifica", 4.50m,
                "Mondadori", 12, "Mensile"
            ));

            _biblioteca.AggiungiContenuto(new Rivista(
                "National Geographic", 2020, "Divulgazione scientifica", 5.00m,
                "National Geographic Society", 8, "Mensile"
            ));

            _biblioteca.AggiungiContenuto(new Audiolibro(
                "Sapiens: Da animali a dèi", 2014, "Saggistica", 19.90m,
                "Luigi Marangoni", 960, "Yuval Noah Harari"
            ));

            _biblioteca.AggiungiContenuto(new CDMusicale(
                "The Dark Side of the Moon", 1973, "Musica", 16.99m,
                "Pink Floyd", 10, "Rock progressivo"
            ));

            _biblioteca.AggiungiContenuto(new CDMusicale(
                "Abbey Road", 1969, "Musica", 15.99m,
                "The Beatles", 17, "Rock"
            ));
        }

        private void cmbTipoContenuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aggiorna le etichette dei campi specifici in base al tipo selezionato
            string tipo = cmbTipoContenuto.SelectedItem.ToString();

            switch (tipo)
            {
                case "Libro":
                    lblSpec1.Text = "Autore:";
                    lblSpec2.Text = "Numero Pagine:";
                    lblSpec3.Text = "Casa Editrice:";
                    break;
                case "DVD":
                    lblSpec1.Text = "Regista:";
                    lblSpec2.Text = "Durata (min):";
                    lblSpec3.Text = "Genere:";
                    break;
                case "Rivista":
                    lblSpec1.Text = "Editore:";
                    lblSpec2.Text = "Numero Edizione:";
                    lblSpec3.Text = "Periodicità:";
                    break;
                case "Audiolibro":
                    lblSpec1.Text = "Narratore:";
                    lblSpec2.Text = "Durata (min):";
                    lblSpec3.Text = "Autore Originale:";
                    break;
                case "CD Musicale":
                    lblSpec1.Text = "Artista:";
                    lblSpec2.Text = "Numero Tracce:";
                    lblSpec3.Text = "Genere:";
                    break;
            }
        }

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            try
            {
                // Validazione dati comuni
                if (string.IsNullOrWhiteSpace(txtTitolo.Text))
                {
                    MessageBox.Show("Inserire il titolo", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtAnno.Text, out int anno) || anno < 1000 || anno > DateTime.Now.Year + 1)
                {
                    MessageBox.Show("Anno non valido", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtValore.Text, out decimal valore) || valore < 0)
                {
                    MessageBox.Show("Valore commerciale non valido", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = cmbTipoContenuto.SelectedItem.ToString();
                ContenutoMultimediale nuovoContenuto = null;

                switch (tipo)
                {
                    case "Libro":
                        if (!int.TryParse(txtSpec2.Text, out int nPagine)) throw new Exception("Numero pagine non valido");
                        nuovoContenuto = new Libro(txtTitolo.Text, anno, txtCategoria.Text, valore,
                                                   txtSpec1.Text, nPagine, txtSpec3.Text);
                        break;

                    case "DVD":
                        if (!int.TryParse(txtSpec2.Text, out int durataDvd)) throw new Exception("Durata non valida");
                        nuovoContenuto = new DVD(txtTitolo.Text, anno, txtCategoria.Text, valore,
                                                 txtSpec1.Text, durataDvd, txtSpec3.Text);
                        break;

                    case "Rivista":
                        if (!int.TryParse(txtSpec2.Text, out int nEdizione)) throw new Exception("Numero edizione non valido");
                        nuovoContenuto = new Rivista(txtTitolo.Text, anno, txtCategoria.Text, valore,
                                                     txtSpec1.Text, nEdizione, txtSpec3.Text);
                        break;

                    case "Audiolibro":
                        if (!int.TryParse(txtSpec2.Text, out int durataAudio)) throw new Exception("Durata non valida");
                        nuovoContenuto = new Audiolibro(txtTitolo.Text, anno, txtCategoria.Text, valore,
                                                        txtSpec1.Text, durataAudio, txtSpec3.Text);
                        break;

                    case "CD Musicale":
                        if (!int.TryParse(txtSpec2.Text, out int nTracce)) throw new Exception("Numero tracce non valido");
                        nuovoContenuto = new CDMusicale(txtTitolo.Text, anno, txtCategoria.Text, valore,
                                                        txtSpec1.Text, nTracce, txtSpec3.Text);
                        break;
                }

                if (nuovoContenuto != null)
                {
                    _biblioteca.AggiungiContenuto(nuovoContenuto);
                    MessageBox.Show($"Contenuto inserito con successo!\nCodice: {nuovoContenuto.CodiceIdentificativo}",
                                    "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Pulisci i campi
                    PulisciCampiInserimento();
                    
                    // Aggiorna la visualizzazione
                    AggiornaCatalogo();
                    AggiornaListaPrestiti();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'inserimento: {ex.Message}", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PulisciCampiInserimento()
        {
            txtTitolo.Clear();
            txtAnno.Clear();
            txtCategoria.Clear();
            txtValore.Clear();
            txtSpec1.Clear();
            txtSpec2.Clear();
            txtSpec3.Clear();
        }

        private void AggiornaCatalogo()
        {
            lstCatalogo.Items.Clear();
            
            var catalogo = _biblioteca.OttieniCatalogo();
            
            foreach (var contenuto in catalogo)
            {
                lstCatalogo.Items.Add(contenuto.OttieniDescrizione());
            }
        }

        private void btnMostraTutto_Click(object sender, EventArgs e)
        {
            AggiornaCatalogo();
        }

        private void btnFiltraTipo_Click(object sender, EventArgs e)
        {
            string tipoSelezionato = cmbFiltroTipo.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tipoSelezionato)) return;

            lstCatalogo.Items.Clear();
            
            var contenutiFiltrati = _biblioteca.CercaPerTipo(tipoSelezionato);
            
            foreach (var contenuto in contenutiFiltrati)
            {
                lstCatalogo.Items.Add(contenuto.OttieniDescrizione());
            }
        }

        private void btnFiltraCategoria_Click(object sender, EventArgs e)
        {
            string categoria = txtFiltroCategoria.Text;
            if (string.IsNullOrWhiteSpace(categoria)) return;

            lstCatalogo.Items.Clear();
            
            var contenutiFiltrati = _biblioteca.CercaPerCategoria(categoria);
            
            foreach (var contenuto in contenutiFiltrati)
            {
                lstCatalogo.Items.Add(contenuto.OttieniDescrizione());
            }
        }

        private void AggiornaListaPrestiti()
        {
            // Aggiorna lista contenuti disponibili
            lstContenutiDisponibili.Items.Clear();
            var disponibili = _biblioteca.OttieniContenutiDisponibili();
            foreach (var contenuto in disponibili)
            {
                lstContenutiDisponibili.Items.Add(contenuto.OttieniDescrizione());
            }

            // Aggiorna lista contenuti in prestito
            lstContenutiInPrestito.Items.Clear();
            var inPrestito = _biblioteca.OttieniContenutiInPrestito();
            foreach (var contenuto in inPrestito)
            {
                lstContenutiInPrestito.Items.Add(contenuto.OttieniDescrizione());
            }
        }

        private void btnPresta_Click(object sender, EventArgs e)
        {
            string codice = txtCodicePrestito.Text.Trim();
            string nomeUtente = txtNomeUtente.Text.Trim();

            if (string.IsNullOrEmpty(codice) || string.IsNullOrEmpty(nomeUtente))
            {
                MessageBox.Show("Inserire sia il codice del contenuto che il nome dell'utente",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_biblioteca.PrestaContenuto(codice, nomeUtente))
            {
                MessageBox.Show($"Contenuto prestato con successo a {nomeUtente}",
                                "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodicePrestito.Clear();
                txtNomeUtente.Clear();
                AggiornaListaPrestiti();
                AggiornaCatalogo();
            }
            else
            {
                MessageBox.Show("Impossibile prestare il contenuto. Verificare il codice o che il contenuto sia disponibile.",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestituisci_Click(object sender, EventArgs e)
        {
            string codice = txtCodiceRestituzione.Text.Trim();

            if (string.IsNullOrEmpty(codice))
            {
                MessageBox.Show("Inserire il codice del contenuto da restituire",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_biblioteca.RestituisciContenuto(codice))
            {
                MessageBox.Show("Contenuto restituito con successo",
                                "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodiceRestituzione.Clear();
                AggiornaListaPrestiti();
                AggiornaCatalogo();
            }
            else
            {
                MessageBox.Show("Impossibile restituire il contenuto. Verificare il codice.",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstContenutiDisponibili_DoubleClick(object sender, EventArgs e)
        {
            // Doppio click su un contenuto disponibile per copiarne il codice
            if (lstContenutiDisponibili.SelectedItem != null)
            {
                string descrizione = lstContenutiDisponibili.SelectedItem.ToString();
                // Estrai il codice dalla descrizione (è tra [ e ])
                int start = descrizione.IndexOf('[') + 1;
                int end = descrizione.IndexOf(']');
                if (start > 0 && end > start)
                {
                    string codice = descrizione.Substring(start, end - start);
                    txtCodicePrestito.Text = codice;
                }
            }
        }

        private void lstContenutiInPrestito_DoubleClick(object sender, EventArgs e)
        {
            // Doppio click su un contenuto in prestito per copiarne il codice
            if (lstContenutiInPrestito.SelectedItem != null)
            {
                string descrizione = lstContenutiInPrestito.SelectedItem.ToString();
                // Estrai il codice dalla descrizione (è tra [ e ])
                int start = descrizione.IndexOf('[') + 1;
                int end = descrizione.IndexOf(']');
                if (start > 0 && end > start)
                {
                    string codice = descrizione.Substring(start, end - start);
                    txtCodiceRestituzione.Text = codice;
                }
            }
        }

        private void btnAggiorna_Click(object sender, EventArgs e)
        {
            // Genera e mostra le statistiche
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.AppendLine("╔═══════════════════════════════════════════════════════════════╗");
            sb.AppendLine("║         STATISTICHE BIBLIOTECA COMUNALE                       ║");
            sb.AppendLine("╚═══════════════════════════════════════════════════════════════╝");
            sb.AppendLine();
            
            // Statistiche generali
            sb.AppendLine("STATISTICHE GENERALI");
            sb.AppendLine("────────────────────────────────────────────────────────────────");
            sb.AppendLine($"Numero totale contenuti:           {_biblioteca.OttieniNumeroContenuti()}");
            sb.AppendLine($"Valore totale catalogo:            €{_biblioteca.OttieniValoreTotale():F2}");
            sb.AppendLine();
            
            // Statistiche per tipo
            sb.AppendLine("DISTRIBUZIONE PER TIPO");
            sb.AppendLine("────────────────────────────────────────────────────────────────");
            var statisticheTipo = _biblioteca.OttieniStatisticheTipo();
            foreach (var kvp in statisticheTipo)
            {
                sb.AppendLine($"{kvp.Key,-20} {kvp.Value,10} contenuti");
            }
            sb.AppendLine();
            
            // Statistiche prestiti
            sb.AppendLine("STATO PRESTITI");
            sb.AppendLine("────────────────────────────────────────────────────────────────");
            int disponibili = _biblioteca.OttieniContenutiDisponibili().Count;
            int inPrestito = _biblioteca.OttieniContenutiInPrestito().Count;
            int prestitiScaduti = _biblioteca.OttieniPrestitiScaduti().Count;
            
            sb.AppendLine($"Contenuti disponibili:             {disponibili}");
            sb.AppendLine($"Contenuti in prestito:             {inPrestito}");
            sb.AppendLine($"Prestiti scaduti:                  {prestitiScaduti}");
            sb.AppendLine();
            
            // Lista prestiti scaduti
            if (prestitiScaduti > 0)
            {
                sb.AppendLine("PRESTITI SCADUTI - RICHIAMO NECESSARIO");
                sb.AppendLine("────────────────────────────────────────────────────────────────");
                foreach (var contenuto in _biblioteca.OttieniPrestitiScaduti())
                {
                    if (contenuto is IPrestabile prestabile)
                    {
                        int giorniRitardo = (DateTime.Now - prestabile.DataPrestito.Value).Days - prestabile.DurataPrestito;
                        sb.AppendLine($"• {contenuto.Titolo}");
                        sb.AppendLine($"  Utente: {prestabile.UtenteInPrestito}");
                        sb.AppendLine($"  Ritardo: {giorniRitardo} giorni");
                        sb.AppendLine();
                    }
                }
            }
            
            txtStatistiche.Text = sb.ToString();
        }
    }
}
