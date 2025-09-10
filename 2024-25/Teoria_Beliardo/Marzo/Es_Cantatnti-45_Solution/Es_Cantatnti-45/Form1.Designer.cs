namespace Es_Cantatnti_45
{
    partial class FormCantanti
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
            this.lblCantanti = new System.Windows.Forms.Label();
            this.DgvCantanti = new System.Windows.Forms.DataGridView();
            this.DgvCanzoni = new System.Windows.Forms.DataGridView();
            this.lblCanzoni = new System.Windows.Forms.Label();
            this.btnCanzoniVendute = new System.Windows.Forms.Button();
            this.btnClassificaCantanti = new System.Windows.Forms.Button();
            this.DgvCanzoniRis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCantanti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCanzoni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCanzoniRis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantanti
            // 
            this.lblCantanti.AutoSize = true;
            this.lblCantanti.Location = new System.Drawing.Point(9, 13);
            this.lblCantanti.Name = "lblCantanti";
            this.lblCantanti.Size = new System.Drawing.Size(64, 13);
            this.lblCantanti.TabIndex = 0;
            this.lblCantanti.Text = "CANTANTI:";
            // 
            // DgvCantanti
            // 
            this.DgvCantanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCantanti.Location = new System.Drawing.Point(2, 47);
            this.DgvCantanti.Name = "DgvCantanti";
            this.DgvCantanti.Size = new System.Drawing.Size(312, 251);
            this.DgvCantanti.TabIndex = 1;
            // 
            // DgvCanzoni
            // 
            this.DgvCanzoni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCanzoni.Location = new System.Drawing.Point(354, 47);
            this.DgvCanzoni.Name = "DgvCanzoni";
            this.DgvCanzoni.Size = new System.Drawing.Size(312, 251);
            this.DgvCanzoni.TabIndex = 2;
            // 
            // lblCanzoni
            // 
            this.lblCanzoni.AutoSize = true;
            this.lblCanzoni.Location = new System.Drawing.Point(364, 13);
            this.lblCanzoni.Name = "lblCanzoni";
            this.lblCanzoni.Size = new System.Drawing.Size(58, 13);
            this.lblCanzoni.TabIndex = 3;
            this.lblCanzoni.Text = "CANZONI:";
            // 
            // btnCanzoniVendute
            // 
            this.btnCanzoniVendute.Location = new System.Drawing.Point(2, 304);
            this.btnCanzoniVendute.Name = "btnCanzoniVendute";
            this.btnCanzoniVendute.Size = new System.Drawing.Size(312, 44);
            this.btnCanzoniVendute.TabIndex = 5;
            this.btnCanzoniVendute.Text = "Ricevuto in ingresso il nome del cantante contare il numero totale di canzoni ven" +
    "dute visualizzandole in un dataGridView";
            this.btnCanzoniVendute.UseVisualStyleBackColor = true;
            this.btnCanzoniVendute.Click += new System.EventHandler(this.btnCanzoniVendute_Click);
            // 
            // btnClassificaCantanti
            // 
            this.btnClassificaCantanti.Location = new System.Drawing.Point(354, 304);
            this.btnClassificaCantanti.Name = "btnClassificaCantanti";
            this.btnClassificaCantanti.Size = new System.Drawing.Size(312, 44);
            this.btnClassificaCantanti.TabIndex = 6;
            this.btnClassificaCantanti.Text = "Dopo aver calcolato per ogni cantante il totale venduto delle loro canzoni, visua" +
    "lizzarne la classifica";
            this.btnClassificaCantanti.UseVisualStyleBackColor = true;
            this.btnClassificaCantanti.Click += new System.EventHandler(this.btnClassificaCantanti_Click);
            // 
            // DgvCanzoniRis
            // 
            this.DgvCanzoniRis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCanzoniRis.Location = new System.Drawing.Point(2, 354);
            this.DgvCanzoniRis.Name = "DgvCanzoniRis";
            this.DgvCanzoniRis.Size = new System.Drawing.Size(312, 251);
            this.DgvCanzoniRis.TabIndex = 8;
            // 
            // FormCantanti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 631);
            this.Controls.Add(this.DgvCanzoniRis);
            this.Controls.Add(this.btnClassificaCantanti);
            this.Controls.Add(this.btnCanzoniVendute);
            this.Controls.Add(this.lblCanzoni);
            this.Controls.Add(this.DgvCanzoni);
            this.Controls.Add(this.DgvCantanti);
            this.Controls.Add(this.lblCantanti);
            this.Name = "FormCantanti";
            this.Text = "Cantanti";
            this.Load += new System.EventHandler(this.FormCantanti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCantanti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCanzoni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCanzoniRis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantanti;
        private System.Windows.Forms.DataGridView DgvCantanti;
        private System.Windows.Forms.DataGridView DgvCanzoni;
        private System.Windows.Forms.Label lblCanzoni;
        private System.Windows.Forms.Button btnCanzoniVendute;
        private System.Windows.Forms.Button btnClassificaCantanti;
        private System.Windows.Forms.DataGridView DgvCanzoniRis;
    }
}

