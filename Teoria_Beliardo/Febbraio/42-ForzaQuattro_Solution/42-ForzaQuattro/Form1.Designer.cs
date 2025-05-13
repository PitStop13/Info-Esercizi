namespace _42_ForzaQuattro
{
    partial class ForzaQuattro
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
            this.DgvGioco = new System.Windows.Forms.DataGridView();
            this.btnInizia = new System.Windows.Forms.Button();
            this.lblRisultato = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGioco)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvGioco
            // 
            this.DgvGioco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGioco.Location = new System.Drawing.Point(17, 16);
            this.DgvGioco.Margin = new System.Windows.Forms.Padding(4);
            this.DgvGioco.Name = "DgvGioco";
            this.DgvGioco.RowHeadersWidth = 51;
            this.DgvGioco.Size = new System.Drawing.Size(320, 185);
            this.DgvGioco.TabIndex = 0;
            this.DgvGioco.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvGioco_CellClick);
            this.DgvGioco.SelectionChanged += new System.EventHandler(this.DgvGioco_SelectionChanged);
            // 
            // btnInizia
            // 
            this.btnInizia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInizia.Location = new System.Drawing.Point(17, 224);
            this.btnInizia.Margin = new System.Windows.Forms.Padding(4);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(320, 42);
            this.btnInizia.TabIndex = 1;
            this.btnInizia.Text = "Inizia";
            this.btnInizia.UseVisualStyleBackColor = true;
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // lblRisultato
            // 
            this.lblRisultato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRisultato.Location = new System.Drawing.Point(17, 300);
            this.lblRisultato.Name = "lblRisultato";
            this.lblRisultato.Size = new System.Drawing.Size(320, 100);
            this.lblRisultato.TabIndex = 2;
            this.lblRisultato.Text = "     ";
            this.lblRisultato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForzaQuattro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 554);
            this.Controls.Add(this.lblRisultato);
            this.Controls.Add(this.btnInizia);
            this.Controls.Add(this.DgvGioco);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ForzaQuattro";
            this.Text = "Forza quattro";
            this.Load += new System.EventHandler(this.ForzaQuattro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGioco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvGioco;
        private System.Windows.Forms.Button btnInizia;
        private System.Windows.Forms.Label lblRisultato;
    }
}

