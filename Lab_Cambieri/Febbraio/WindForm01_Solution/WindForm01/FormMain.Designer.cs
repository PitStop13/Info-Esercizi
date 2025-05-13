namespace WindForm01
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
            this.btnTest = new System.Windows.Forms.Button();
            this.lblNominativo = new System.Windows.Forms.Label();
            this.txtNominativo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.AutoSize = true;
            this.btnTest.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTest.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(0, 0);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(171, 41);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Provami!";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblNominativo
            // 
            this.lblNominativo.AutoSize = true;
            this.lblNominativo.Location = new System.Drawing.Point(81, 107);
            this.lblNominativo.Name = "lblNominativo";
            this.lblNominativo.Size = new System.Drawing.Size(63, 13);
            this.lblNominativo.TabIndex = 1;
            this.lblNominativo.Text = "Nominativo:";
            // 
            // txtNominativo
            // 
            this.txtNominativo.Location = new System.Drawing.Point(150, 107);
            this.txtNominativo.Name = "txtNominativo";
            this.txtNominativo.Size = new System.Drawing.Size(251, 20);
            this.txtNominativo.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(507, 446);
            this.Controls.Add(this.txtNominativo);
            this.Controls.Add(this.lblNominativo);
            this.Controls.Add(this.btnTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Uso controlli principali";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblNominativo;
        private System.Windows.Forms.TextBox txtNominativo;
    }
}

