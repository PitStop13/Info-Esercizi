using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using BibliotecaSolution;

namespace VerificaInterfacce
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
            cmbTipoContenuto.SelectedIndex = 0;

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
                "Mondadori", 12, "Mensile", DateTime.Now.AddDays(-10)
            ));

            _biblioteca.AggiungiContenuto(new Rivista(
                "National Geographic", 2020, "Divulgazione scientifica", 5.00m,
                "National Geographic Society", 8, "Mensile", new DateTime(2020, 5, 1)
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
            lblSpec1.Visible = true;
            lblSpec2.Visible = true;
            lblSpec3.Visible = true;
            txtSpec1.Visible = true;
            txtSpec2.Visible = true;
            txtSpec3.Visible = true;

            switch (tipo)
            {
                case "Libro":
                    lblSpec1.Text = "Autore:";
                    lblSpec2.Text = "Pagine:";
                    lblSpec3.Text = "Casa Editrice:";
                    break;
                case "DVD":
                    lblSpec1.Text = "Regista:";
                    lblSpec2.Text = "Durata (min):";
                    lblSpec3.Text = "Genere:";
                    break;
                case "Rivista":
                    lblSpec1.Text = "Editore:";
                    lblSpec2.Text = "N° Edizione:";
                    lblSpec3.Text = "Periodicità:";
                    break;
                case "Audiolibro":
                    lblSpec1.Text = "Narratore:";
                    lblSpec2.Text = "Durata (min):";
                    lblSpec3.Text = "Autore:";
                    break;
                case "CD Musicale":
                    lblSpec1.Text = "Artista:";
                    lblSpec2.Text = "N° Tracce:";
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
                        if (!int.TryParse(txtSpec2.Text, out int pagine)) throw new Exception("Numero pagine non valido");
                        nuovoContenuto = new Libro(txtTitolo.Text, anno, txtCategoria.Text, valore, txtSpec1.Text, pagine, txtSpec3.Text);
                        break;

                    case "DVD":
                        if (!int.TryParse(txtSpec2.Text, out int durataDvd)) throw new Exception("Durata non valida");
                        nuovoContenuto = new DVD(txtTitolo.Text, anno, txtCategoria.Text, valore, txtSpec1.Text, durataDvd, txtSpec3.Text);
                        break;

                    case "Rivista":
                        if (!int.TryParse(txtSpec2.Text, out int numEd)) throw new Exception("Numero edizione non valido");
                        // Per semplicità, assumiamo data emissione oggi per le nuove riviste inserite manualmente, o gestibile diversamente
                        nuovoContenuto = new Rivista(txtTitolo.Text, anno, txtCategoria.Text, valore, txtSpec1.Text, numEd, txtSpec3.Text, DateTime.Now);
                        break;

                    case "Audiolibro":
                        if (!int.TryParse(txtSpec2.Text, out int durataAudio)) throw new Exception("Durata non valida");
                        nuovoContenuto = new Audiolibro(txtTitolo.Text, anno, txtCategoria.Text, valore, txtSpec1.Text, durataAudio, txtSpec3.Text);
                        break;

                    case "CD Musicale":
                        if (!int.TryParse(txtSpec2.Text, out int tracce)) throw new Exception("Numero tracce non valido");
                        nuovoContenuto = new CDMusicale(txtTitolo.Text, anno, txtCategoria.Text, valore, txtSpec1.Text, tracce, txtSpec3.Text);
                        break;
                }

                if (nuovoContenuto != null)
                {
                    // Genera codice univoco (semplificato)
                    nuovoContenuto.CodiceIdentificativo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                    _biblioteca.AggiungiContenuto(nuovoContenuto);
                    AggiornaCatalogo();
                    AggiornaListaPrestiti();
                    PulisciCampiInserimento();
                    MessageBox.Show("Contenuto inserito correttamente!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            foreach (var item in _biblioteca.OttieniCatalogo())
            {
                lstCatalogo.Items.Add(item.OttieniDescrizione());
            }
        }

        private void btnMostraTutto_Click(object sender, EventArgs e)
        {
            AggiornaCatalogo();
        }

        private void btnFiltraTipo_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipoContenuto.SelectedItem.ToString();
            var filtrati = _biblioteca.CercaPerTipo(tipo);
            lstCatalogo.Items.Clear();
            foreach (var item in filtrati)
            {
                lstCatalogo.Items.Add(item.OttieniDescrizione());
            }
        }

        private void btnFiltraCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("Inserire una categoria per filtrare", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var filtrati = _biblioteca.CercaPerCategoria(txtCategoria.Text);
            lstCatalogo.Items.Clear();
            foreach (var item in filtrati)
            {
                lstCatalogo.Items.Add(item.OttieniDescrizione());
            }
        }

        private void AggiornaListaPrestiti()
        {
            // Aggiorna lista contenuti disponibili
            lstContenutiDisponibili.Items.Clear();
            foreach (var item in _biblioteca.OttieniContenutiDisponibili())
            {
                lstContenutiDisponibili.Items.Add(item.OttieniDescrizione());
            }

            // Aggiorna lista contenuti in prestito
            lstContenutiInPrestito.Items.Clear();
            foreach (var item in _biblioteca.OttieniCatalogo())
            {
                if (item is IPrestabile prestabile && prestabile.InPrestito)
                {
                    lstContenutiInPrestito.Items.Add(item.OttieniDescrizione());
                }
            }
        }

        private void btnPresta_Click(object sender, EventArgs e)
        {
            if (lstContenutiDisponibili.SelectedIndex == -1)
            {
                MessageBox.Show("Selezionare un contenuto disponibile", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNomeUtente.Text))
            {
                MessageBox.Show("Inserire il nome dell'utente", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItemString = lstContenutiDisponibili.SelectedItem.ToString();
            // Estrai codice (assumendo formato "[CODICE] ...")
            string codice = selectedItemString.Substring(1, selectedItemString.IndexOf(']') - 1);

            var contenuto = _biblioteca.OttieniCatalogo().FirstOrDefault(c => c.CodiceIdentificativo == codice);
            if (contenuto is IPrestabile prestabile)
            {
                try
                {
                    prestabile.Presta(txtNomeUtente.Text, DateTime.Now);
                    AggiornaListaPrestiti();
                    AggiornaCatalogo();
                    txtNomeUtente.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRestituisci_Click(object sender, EventArgs e)
        {
            if (lstContenutiInPrestito.SelectedIndex == -1)
            {
                MessageBox.Show("Selezionare un contenuto da restituire", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItemString = lstContenutiInPrestito.SelectedItem.ToString();
            string codice = selectedItemString.Substring(1, selectedItemString.IndexOf(']') - 1);

            var contenuto = _biblioteca.OttieniCatalogo().FirstOrDefault(c => c.CodiceIdentificativo == codice);
            if (contenuto is IPrestabile prestabile)
            {
                try
                {
                    prestabile.Restituisci();
                    AggiornaListaPrestiti();
                    AggiornaCatalogo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstContenutiDisponibili_DoubleClick(object sender, EventArgs e)
        {
            // Doppio click su un contenuto disponibile per copiarne il codice
            if (lstContenutiDisponibili.SelectedItem != null)
            {
                // Opzionale: implementazione per facilitare test
            }
        }

        private void lstContenutiInPrestito_DoubleClick(object sender, EventArgs e)
        {
            // Doppio click su un contenuto in prestito per copiarne il codice
        }

        private void btnAggiorna_Click(object sender, EventArgs e)
        {
            // Genera e mostra le statistiche
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("╔═══════════════════════════════════════════════════════════════╗");
            sb.AppendLine("║         STATISTICHE BIBLIOTECA COMUNALE                       ║");
            sb.AppendLine("╚═══════════════════════════════════════════════════════════════╝");
            sb.AppendLine();

            var catalogo = _biblioteca.OttieniCatalogo();

            // Statistiche generali
            sb.AppendLine("STATISTICHE GENERALI");
            sb.AppendLine("────────────────────────────────────────────────────────────────");
            sb.AppendLine($"Totale contenuti: {catalogo.Count}");
            sb.AppendLine($"Valore totale patrimonio: €{catalogo.Sum(c => c.ValoreCommerciale):F2}");
            sb.AppendLine();

            // Statistiche per tipo
            sb.AppendLine("DISTRIBUZIONE PER TIPO");
            sb.AppendLine("────────────────────────────────────────────────────────────────");
            var perTipo = catalogo.GroupBy(c => c.OttieniTipo());
            foreach (var gruppo in perTipo)
            {
                sb.AppendLine($"{gruppo.Key}: {gruppo.Count()}");
            }
            sb.AppendLine();

            // Statistiche prestiti
            sb.AppendLine("STATO PRESTITI");
            sb.AppendLine("────────────────────────────────────────────────────────────────");
            int inPrestito = catalogo.OfType<IPrestabile>().Count(p => p.InPrestito);
            sb.AppendLine($"Contenuti attualmente in prestito: {inPrestito}");
            sb.AppendLine();

            // Lista prestiti scaduti
            sb.AppendLine("PRESTITI SCADUTI");
            sb.AppendLine("────────────────────────────────────────────────────────────────");
            var scaduti = catalogo.OfType<IPrestabile>().Where(p => p.IsPrestutoScaduto());
            if (scaduti.Any())
            {
                foreach (var s in scaduti)
                {
                    var c = s as ContenutoMultimediale;
                    sb.AppendLine($"- {c.Titolo} (Scaduto da {(DateTime.Now - s.DataPrestito.Value).Days - s.DurataPrestito} giorni)");
                }
            }
            else
            {
                sb.AppendLine("Nessun prestito scaduto.");
            }

            txtStatistiche.Text = sb.ToString();
        }
    }
}
