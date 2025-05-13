namespace Es_Libri
{
    partial class FormMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSommaPrezzi = new System.Windows.Forms.Button();
            this.btnCercaAutore = new System.Windows.Forms.Button();
            this.btnScrivi = new System.Windows.Forms.Button();
            this.btnCercaTitolo = new System.Windows.Forms.Button();
            this.btnLeggi = new System.Windows.Forms.Button();
            this.dgvDati = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDati)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSommaPrezzi);
            this.panel1.Controls.Add(this.btnCercaAutore);
            this.panel1.Controls.Add(this.btnScrivi);
            this.panel1.Controls.Add(this.btnCercaTitolo);
            this.panel1.Controls.Add(this.btnLeggi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 0;
            // 
            // btnSommaPrezzi
            // 
            this.btnSommaPrezzi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnSommaPrezzi.Location = new System.Drawing.Point(14, 378);
            this.btnSommaPrezzi.Name = "btnSommaPrezzi";
            this.btnSommaPrezzi.Size = new System.Drawing.Size(173, 48);
            this.btnSommaPrezzi.TabIndex = 4;
            this.btnSommaPrezzi.Text = "Somma Prezzi";
            this.btnSommaPrezzi.UseVisualStyleBackColor = true;
            // 
            // btnCercaAutore
            // 
            this.btnCercaAutore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnCercaAutore.Location = new System.Drawing.Point(14, 288);
            this.btnCercaAutore.Name = "btnCercaAutore";
            this.btnCercaAutore.Size = new System.Drawing.Size(173, 48);
            this.btnCercaAutore.TabIndex = 3;
            this.btnCercaAutore.Text = "Cerca per Autore";
            this.btnCercaAutore.UseVisualStyleBackColor = true;
            // 
            // btnScrivi
            // 
            this.btnScrivi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnScrivi.Location = new System.Drawing.Point(14, 108);
            this.btnScrivi.Name = "btnScrivi";
            this.btnScrivi.Size = new System.Drawing.Size(173, 48);
            this.btnScrivi.TabIndex = 2;
            this.btnScrivi.Text = "Scrivi File";
            this.btnScrivi.UseVisualStyleBackColor = true;
            // 
            // btnCercaTitolo
            // 
            this.btnCercaTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnCercaTitolo.Location = new System.Drawing.Point(14, 198);
            this.btnCercaTitolo.Name = "btnCercaTitolo";
            this.btnCercaTitolo.Size = new System.Drawing.Size(173, 48);
            this.btnCercaTitolo.TabIndex = 1;
            this.btnCercaTitolo.Text = "Cerca per Titolo";
            this.btnCercaTitolo.UseVisualStyleBackColor = true;
            // 
            // btnLeggi
            // 
            this.btnLeggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnLeggi.Location = new System.Drawing.Point(14, 18);
            this.btnLeggi.Name = "btnLeggi";
            this.btnLeggi.Size = new System.Drawing.Size(173, 48);
            this.btnLeggi.TabIndex = 0;
            this.btnLeggi.Text = "Leggi File";
            this.btnLeggi.UseVisualStyleBackColor = true;
            this.btnLeggi.Click += new System.EventHandler(this.btnLeggi_Click);
            // 
            // dgvDati
            // 
            this.dgvDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDati.Location = new System.Drawing.Point(200, 0);
            this.dgvDati.Name = "dgvDati";
            this.dgvDati.Size = new System.Drawing.Size(600, 450);
            this.dgvDati.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDati);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Lettura e scrittura di file ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSommaPrezzi;
        private System.Windows.Forms.Button btnCercaAutore;
        private System.Windows.Forms.Button btnScrivi;
        private System.Windows.Forms.Button btnCercaTitolo;
        private System.Windows.Forms.Button btnLeggi;
        private System.Windows.Forms.DataGridView dgvDati;
    }
}

