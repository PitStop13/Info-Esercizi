namespace Palestra
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        private void InitializeComponent()
        {
            this.grpNuovoServizio = new System.Windows.Forms.GroupBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblCodice = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblDurata = new System.Windows.Forms.Label();
            this.txtDurata = new System.Windows.Forms.TextBox();
            this.lblIstruttore = new System.Windows.Forms.Label();
            this.txtIstruttore = new System.Windows.Forms.TextBox();
            this.lblMaxPartecipanti = new System.Windows.Forms.Label();
            this.txtMaxPartecipanti = new System.Windows.Forms.TextBox();
            this.lblFasciaOraria = new System.Windows.Forms.Label();
            this.txtFasciaOraria = new System.Windows.Forms.TextBox();
            this.chkAccesso24h = new System.Windows.Forms.CheckBox();
            this.btnAggiungi = new System.Windows.Forms.Button();
            
            this.grpElenco = new System.Windows.Forms.GroupBox();
            this.lstServizi = new System.Windows.Forms.ListBox();
            this.btnMostraTutti = new System.Windows.Forms.Button();
            this.txtCercaIstruttore = new System.Windows.Forms.TextBox();
            this.btnCercaIstruttore = new System.Windows.Forms.Button();
            
            this.grpPrenotazioni = new System.Windows.Forms.GroupBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.btnPrenota = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            
            this.lblStatistiche = new System.Windows.Forms.Label();
            this.btnCorsiQuasiPieni = new System.Windows.Forms.Button();

            this.grpNuovoServizio.SuspendLayout();
            this.grpElenco.SuspendLayout();
            this.grpPrenotazioni.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpNuovoServizio
            // 
            this.grpNuovoServizio.Controls.Add(this.btnAggiungi);
            this.grpNuovoServizio.Controls.Add(this.chkAccesso24h);
            this.grpNuovoServizio.Controls.Add(this.txtMaxPartecipanti);
            this.grpNuovoServizio.Controls.Add(this.lblMaxPartecipanti);
            this.grpNuovoServizio.Controls.Add(this.txtIstruttore);
            this.grpNuovoServizio.Controls.Add(this.lblIstruttore);
            this.grpNuovoServizio.Controls.Add(this.txtDurata);
            this.grpNuovoServizio.Controls.Add(this.lblDurata);
            this.grpNuovoServizio.Controls.Add(this.txtCosto);
            this.grpNuovoServizio.Controls.Add(this.lblCosto);
            this.grpNuovoServizio.Controls.Add(this.txtNome);
            this.grpNuovoServizio.Controls.Add(this.lblNome);
            this.grpNuovoServizio.Controls.Add(this.txtCodice);
            this.grpNuovoServizio.Controls.Add(this.lblCodice);
            this.grpNuovoServizio.Controls.Add(this.cmbTipo);
            this.grpNuovoServizio.Controls.Add(this.lblTipo);
            this.grpNuovoServizio.Controls.Add(this.lblFasciaOraria);
            this.grpNuovoServizio.Controls.Add(this.txtFasciaOraria);
            this.grpNuovoServizio.Location = new System.Drawing.Point(12, 12);
            this.grpNuovoServizio.Name = "grpNuovoServizio";
            this.grpNuovoServizio.Size = new System.Drawing.Size(300, 400);
            this.grpNuovoServizio.TabIndex = 0;
            this.grpNuovoServizio.TabStop = false;
            this.grpNuovoServizio.Text = "Nuovo Servizio";

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(6, 25);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo:";

            // cmbTipo
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] { "CorsoGruppo", "PersonalTraining", "SalaPesi", "Piscina" });
            this.cmbTipo.Location = new System.Drawing.Point(9, 41);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(280, 21);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);

            // lblCodice
            this.lblCodice.AutoSize = true;
            this.lblCodice.Location = new System.Drawing.Point(6, 70);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Text = "Codice:";
            
            // txtCodice
            this.txtCodice.Location = new System.Drawing.Point(9, 86);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(280, 20);

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 110);
            this.lblNome.Name = "lblNome";
            this.lblNome.Text = "Nome:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(9, 126);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(280, 20);

            // lblCosto
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(6, 150);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Text = "Costo:";

            // txtCosto
            this.txtCosto.Location = new System.Drawing.Point(9, 166);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(280, 20);

            // lblDurata
            this.lblDurata.AutoSize = true;
            this.lblDurata.Location = new System.Drawing.Point(6, 190);
            this.lblDurata.Name = "lblDurata";
            this.lblDurata.Text = "Durata (min):";

            // txtDurata
            this.txtDurata.Location = new System.Drawing.Point(9, 206);
            this.txtDurata.Name = "txtDurata";
            this.txtDurata.Size = new System.Drawing.Size(280, 20);

            // lblIstruttore
            this.lblIstruttore.AutoSize = true;
            this.lblIstruttore.Location = new System.Drawing.Point(6, 230);
            this.lblIstruttore.Name = "lblIstruttore";
            this.lblIstruttore.Text = "Istruttore:";

            // txtIstruttore
            this.txtIstruttore.Location = new System.Drawing.Point(9, 246);
            this.txtIstruttore.Name = "txtIstruttore";
            this.txtIstruttore.Size = new System.Drawing.Size(280, 20);

            // lblMaxPartecipanti
            this.lblMaxPartecipanti.AutoSize = true;
            this.lblMaxPartecipanti.Location = new System.Drawing.Point(6, 270);
            this.lblMaxPartecipanti.Name = "lblMaxPartecipanti";
            this.lblMaxPartecipanti.Text = "Max Partecipanti:";

            // txtMaxPartecipanti
            this.txtMaxPartecipanti.Location = new System.Drawing.Point(9, 286);
            this.txtMaxPartecipanti.Name = "txtMaxPartecipanti";
            this.txtMaxPartecipanti.Size = new System.Drawing.Size(280, 20);

            // chkAccesso24h
            this.chkAccesso24h.AutoSize = true;
            this.chkAccesso24h.Location = new System.Drawing.Point(9, 315);
            this.chkAccesso24h.Name = "chkAccesso24h";
            this.chkAccesso24h.Text = "Accesso 24h";
            this.chkAccesso24h.UseVisualStyleBackColor = true;

            // lblFasciaOraria
            this.lblFasciaOraria.AutoSize = true;
            this.lblFasciaOraria.Location = new System.Drawing.Point(6, 270);
            this.lblFasciaOraria.Name = "lblFasciaOraria";
            this.lblFasciaOraria.Text = "Fascia Oraria (es. 08:00-10:00):";

            // txtFasciaOraria
            this.txtFasciaOraria.Location = new System.Drawing.Point(9, 286);
            this.txtFasciaOraria.Name = "txtFasciaOraria";
            this.txtFasciaOraria.Size = new System.Drawing.Size(280, 20);
            this.txtFasciaOraria.Enabled = false;

            // btnAggiungi
            this.btnAggiungi.Location = new System.Drawing.Point(9, 340);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(280, 40);
            this.btnAggiungi.Text = "Aggiungi Servizio";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);

            // 
            // grpElenco
            // 
            this.grpElenco.Controls.Add(this.btnCercaIstruttore);
            this.grpElenco.Controls.Add(this.txtCercaIstruttore);
            this.grpElenco.Controls.Add(this.btnMostraTutti);
            this.grpElenco.Controls.Add(this.lstServizi);
            this.grpElenco.Location = new System.Drawing.Point(330, 12);
            this.grpElenco.Name = "grpElenco";
            this.grpElenco.Size = new System.Drawing.Size(440, 300);
            this.grpElenco.Text = "Elenco Servizi";

            // lstServizi
            this.lstServizi.FormattingEnabled = true;
            this.lstServizi.Location = new System.Drawing.Point(6, 19);
            this.lstServizi.Name = "lstServizi";
            this.lstServizi.Size = new System.Drawing.Size(420, 230);
            this.lstServizi.SelectedIndexChanged += new System.EventHandler(this.lstServizi_SelectedIndexChanged);

            // btnMostraTutti
            this.btnMostraTutti.Location = new System.Drawing.Point(6, 260);
            this.btnMostraTutti.Name = "btnMostraTutti";
            this.btnMostraTutti.Size = new System.Drawing.Size(100, 23);
            this.btnMostraTutti.Text = "Mostra Tutti";
            this.btnMostraTutti.Click += new System.EventHandler(this.btnMostraTutti_Click);

            // txtCercaIstruttore
            this.txtCercaIstruttore.Location = new System.Drawing.Point(120, 262);
            this.txtCercaIstruttore.Name = "txtCercaIstruttore";
            this.txtCercaIstruttore.Size = new System.Drawing.Size(150, 20);
            
            // btnCercaIstruttore
            this.btnCercaIstruttore.Location = new System.Drawing.Point(280, 260);
            this.btnCercaIstruttore.Name = "btnCercaIstruttore";
            this.btnCercaIstruttore.Size = new System.Drawing.Size(100, 23);
            this.btnCercaIstruttore.Text = "Cerca Istruttore";
            this.btnCercaIstruttore.Click += new System.EventHandler(this.btnCercaIstruttore_Click);

            //
            // grpPrenotazioni
            //
            this.grpPrenotazioni.Controls.Add(this.lblInfo);
            this.grpPrenotazioni.Controls.Add(this.btnAnnulla);
            this.grpPrenotazioni.Controls.Add(this.btnPrenota);
            this.grpPrenotazioni.Controls.Add(this.txtNomeCliente);
            this.grpPrenotazioni.Controls.Add(this.lblNomeCliente);
            this.grpPrenotazioni.Location = new System.Drawing.Point(330, 320);
            this.grpPrenotazioni.Name = "grpPrenotazioni";
            this.grpPrenotazioni.Size = new System.Drawing.Size(440, 120);
            this.grpPrenotazioni.Text = "Prenotazione";

            // lblNomeCliente
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Location = new System.Drawing.Point(6, 25);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Text = "Nome Cliente:";

            // txtNomeCliente
            this.txtNomeCliente.Location = new System.Drawing.Point(80, 22);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(200, 20);

            // btnPrenota
            this.btnPrenota.Location = new System.Drawing.Point(290, 20);
            this.btnPrenota.Name = "btnPrenota";
            this.btnPrenota.Size = new System.Drawing.Size(100, 23);
            this.btnPrenota.Text = "Prenota";
            this.btnPrenota.Click += new System.EventHandler(this.btnPrenota_Click);

            // lblInfo
            this.lblInfo.Location = new System.Drawing.Point(6, 50);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(420, 60);
            this.lblInfo.Text = "Seleziona un servizio dalla lista per prenotare o visualizzare dettagli.";

            // btnAnnulla
            this.btnAnnulla.Location = new System.Drawing.Point(10, 20);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(60, 23);
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            this.btnAnnulla.Enabled = false;

            // lblStatistiche
            this.lblStatistiche.AutoSize = true;
            this.lblStatistiche.Location = new System.Drawing.Point(12, 420);
            this.lblStatistiche.Name = "lblStatistiche";
            this.lblStatistiche.Text = "Statistiche: -";

            // btnCorsiQuasiPieni
            this.btnCorsiQuasiPieni.Location = new System.Drawing.Point(12, 445);
            this.btnCorsiQuasiPieni.Name = "btnCorsiQuasiPieni";
            this.btnCorsiQuasiPieni.Size = new System.Drawing.Size(150, 30);
            this.btnCorsiQuasiPieni.Text = "Corsi Quasi Pieni (<3 posti)";
            this.btnCorsiQuasiPieni.Click += new System.EventHandler(this.btnCorsiQuasiPieni_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.btnCorsiQuasiPieni);
            this.Controls.Add(this.lblStatistiche);
            this.Controls.Add(this.grpPrenotazioni);
            this.Controls.Add(this.grpElenco);
            this.Controls.Add(this.grpNuovoServizio);
            this.Name = "Form1";
            this.Text = "Gestione Palestra";
            this.grpNuovoServizio.ResumeLayout(false);
            this.grpNuovoServizio.PerformLayout();
            this.grpElenco.ResumeLayout(false);
            this.grpElenco.PerformLayout();
            this.grpPrenotazioni.ResumeLayout(false);
            this.grpPrenotazioni.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuovoServizio;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblCodice;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblDurata;
        private System.Windows.Forms.TextBox txtDurata;
        private System.Windows.Forms.Label lblIstruttore;
        private System.Windows.Forms.TextBox txtIstruttore;
        private System.Windows.Forms.Label lblMaxPartecipanti;
        private System.Windows.Forms.TextBox txtMaxPartecipanti;
        private System.Windows.Forms.Label lblFasciaOraria;
        private System.Windows.Forms.TextBox txtFasciaOraria;
        private System.Windows.Forms.CheckBox chkAccesso24h;
        private System.Windows.Forms.Button btnAggiungi;
        
        private System.Windows.Forms.GroupBox grpElenco;
        private System.Windows.Forms.ListBox lstServizi;
        private System.Windows.Forms.Button btnMostraTutti;
        private System.Windows.Forms.TextBox txtCercaIstruttore;
        private System.Windows.Forms.Button btnCercaIstruttore;
        
        private System.Windows.Forms.GroupBox grpPrenotazioni;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Button btnPrenota;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Label lblInfo;
        
        private System.Windows.Forms.Label lblStatistiche;
        private System.Windows.Forms.Button btnCorsiQuasiPieni;
    }
}
