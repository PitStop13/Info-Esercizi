namespace CampoMinato_44
{
    partial class CampoMinato
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
            this.DgvCampoMinato = new System.Windows.Forms.DataGridView();
            this.btnInizia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCampoMinato)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvCampoMinato
            // 
            this.DgvCampoMinato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCampoMinato.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvCampoMinato.Location = new System.Drawing.Point(0, 0);
            this.DgvCampoMinato.Name = "DgvCampoMinato";
            this.DgvCampoMinato.Size = new System.Drawing.Size(414, 365);
            this.DgvCampoMinato.TabIndex = 0;
            this.DgvCampoMinato.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCampoMinato_CellClick);
            // 
            // btnInizia
            // 
            this.btnInizia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInizia.Location = new System.Drawing.Point(0, 362);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(414, 82);
            this.btnInizia.TabIndex = 1;
            this.btnInizia.Text = "Inizia";
            this.btnInizia.UseVisualStyleBackColor = true;
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // CampoMinato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 441);
            this.Controls.Add(this.btnInizia);
            this.Controls.Add(this.DgvCampoMinato);
            this.Name = "CampoMinato";
            this.Text = "Campo minato";
            this.Load += new System.EventHandler(this.CampoMinato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCampoMinato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvCampoMinato;
        private System.Windows.Forms.Button btnInizia;
    }
}

