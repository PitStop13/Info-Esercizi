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
            this.dgvCampoMinato = new System.Windows.Forms.DataGridView();
            this.btnInizia = new System.Windows.Forms.Button();
            this.rdbEasy = new System.Windows.Forms.RadioButton();
            this.rdbMedium = new System.Windows.Forms.RadioButton();
            this.rdbHard = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampoMinato)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCampoMinato
            // 
            this.dgvCampoMinato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampoMinato.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCampoMinato.Location = new System.Drawing.Point(0, 0);
            this.dgvCampoMinato.Name = "dgvCampoMinato";
            this.dgvCampoMinato.Size = new System.Drawing.Size(414, 414);
            this.dgvCampoMinato.TabIndex = 0;
            this.dgvCampoMinato.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCampoMinato_CellClick);
            // 
            // btnInizia
            // 
            this.btnInizia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInizia.Location = new System.Drawing.Point(231, 420);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(171, 63);
            this.btnInizia.TabIndex = 1;
            this.btnInizia.Text = "Start";
            this.btnInizia.UseVisualStyleBackColor = true;
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // rdbEasy
            // 
            this.rdbEasy.AutoSize = true;
            this.rdbEasy.Font = new System.Drawing.Font("Miriam CLM", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbEasy.Location = new System.Drawing.Point(12, 420);
            this.rdbEasy.Name = "rdbEasy";
            this.rdbEasy.Size = new System.Drawing.Size(87, 19);
            this.rdbEasy.TabIndex = 2;
            this.rdbEasy.TabStop = true;
            this.rdbEasy.Text = "Level easy";
            this.rdbEasy.UseVisualStyleBackColor = true;
            // 
            // rdbMedium
            // 
            this.rdbMedium.AutoSize = true;
            this.rdbMedium.Font = new System.Drawing.Font("Miriam CLM", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbMedium.Location = new System.Drawing.Point(12, 445);
            this.rdbMedium.Name = "rdbMedium";
            this.rdbMedium.Size = new System.Drawing.Size(103, 19);
            this.rdbMedium.TabIndex = 3;
            this.rdbMedium.TabStop = true;
            this.rdbMedium.Text = "Level medium";
            this.rdbMedium.UseVisualStyleBackColor = true;
            // 
            // rdbHard
            // 
            this.rdbHard.AutoSize = true;
            this.rdbHard.Font = new System.Drawing.Font("Miriam CLM", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbHard.Location = new System.Drawing.Point(12, 470);
            this.rdbHard.Name = "rdbHard";
            this.rdbHard.Size = new System.Drawing.Size(86, 19);
            this.rdbHard.TabIndex = 4;
            this.rdbHard.TabStop = true;
            this.rdbHard.Text = "Level hard";
            this.rdbHard.UseVisualStyleBackColor = true;
            // 
            // CampoMinato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 493);
            this.Controls.Add(this.rdbHard);
            this.Controls.Add(this.rdbMedium);
            this.Controls.Add(this.rdbEasy);
            this.Controls.Add(this.btnInizia);
            this.Controls.Add(this.dgvCampoMinato);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "CampoMinato";
            this.Text = "Campo minato";
            this.Load += new System.EventHandler(this.CampoMinato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampoMinato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCampoMinato;
        private System.Windows.Forms.Button btnInizia;
        private System.Windows.Forms.RadioButton rdbEasy;
        private System.Windows.Forms.RadioButton rdbMedium;
        private System.Windows.Forms.RadioButton rdbHard;
    }
}

