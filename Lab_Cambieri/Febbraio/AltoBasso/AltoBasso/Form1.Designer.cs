namespace AltoBasso
{
    partial class AltoBasso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltoBasso));
            this.rdbBase = new System.Windows.Forms.RadioButton();
            this.rdbIntermedio = new System.Windows.Forms.RadioButton();
            this.rdbAvanzato = new System.Windows.Forms.RadioButton();
            this.Text = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblTentativirimasti = new System.Windows.Forms.Label();
            this.lblTRimasti = new System.Windows.Forms.Label();
            this.btnIndovina = new System.Windows.Forms.Button();
            this.lblTentativi = new System.Windows.Forms.Label();
            this.pictureBoxSu = new System.Windows.Forms.PictureBox();
            this.pictureBoxGiu = new System.Windows.Forms.PictureBox();
            this.lblRisultato = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGiu)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbBase
            // 
            this.rdbBase.AutoSize = true;
            this.rdbBase.Location = new System.Drawing.Point(16, 15);
            this.rdbBase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbBase.Name = "rdbBase";
            this.rdbBase.Size = new System.Drawing.Size(60, 20);
            this.rdbBase.TabIndex = 0;
            this.rdbBase.Text = "Base";
            this.rdbBase.UseVisualStyleBackColor = true;
            this.rdbBase.CheckedChanged += new System.EventHandler(this.rbd_CheckedChanged);
            // 
            // rdbIntermedio
            // 
            this.rdbIntermedio.AutoSize = true;
            this.rdbIntermedio.Location = new System.Drawing.Point(105, 15);
            this.rdbIntermedio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbIntermedio.Name = "rdbIntermedio";
            this.rdbIntermedio.Size = new System.Drawing.Size(91, 20);
            this.rdbIntermedio.TabIndex = 1;
            this.rdbIntermedio.Text = "Intermedio";
            this.rdbIntermedio.UseVisualStyleBackColor = true;
            this.rdbIntermedio.CheckedChanged += new System.EventHandler(this.rbd_CheckedChanged);
            // 
            // rdbAvanzato
            // 
            this.rdbAvanzato.AutoSize = true;
            this.rdbAvanzato.Location = new System.Drawing.Point(225, 15);
            this.rdbAvanzato.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbAvanzato.Name = "rdbAvanzato";
            this.rdbAvanzato.Size = new System.Drawing.Size(84, 20);
            this.rdbAvanzato.TabIndex = 2;
            this.rdbAvanzato.Text = "Avanzato";
            this.rdbAvanzato.UseVisualStyleBackColor = true;
            this.rdbAvanzato.CheckedChanged += new System.EventHandler(this.rbd_CheckedChanged);
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text.Location = new System.Drawing.Point(16, 50);
            this.Text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(132, 17);
            this.Text.TabIndex = 3;
            this.Text.Text = "Inserisci numero:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(156, 47);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(172, 22);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // lblTentativirimasti
            // 
            this.lblTentativirimasti.AutoSize = true;
            this.lblTentativirimasti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTentativirimasti.Location = new System.Drawing.Point(19, 87);
            this.lblTentativirimasti.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTentativirimasti.Name = "lblTentativirimasti";
            this.lblTentativirimasti.Size = new System.Drawing.Size(129, 17);
            this.lblTentativirimasti.TabIndex = 5;
            this.lblTentativirimasti.Text = "Tentativi rimasti:";
            // 
            // lblTRimasti
            // 
            this.lblTRimasti.AutoSize = true;
            this.lblTRimasti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTRimasti.Location = new System.Drawing.Point(153, 87);
            this.lblTRimasti.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTRimasti.Name = "lblTRimasti";
            this.lblTRimasti.Size = new System.Drawing.Size(0, 17);
            this.lblTRimasti.TabIndex = 6;
            // 
            // btnIndovina
            // 
            this.btnIndovina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndovina.Location = new System.Drawing.Point(105, 122);
            this.btnIndovina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIndovina.Name = "btnIndovina";
            this.btnIndovina.Size = new System.Drawing.Size(135, 41);
            this.btnIndovina.TabIndex = 7;
            this.btnIndovina.Text = "Indovina";
            this.btnIndovina.UseVisualStyleBackColor = true;
            this.btnIndovina.Click += new System.EventHandler(this.btnIndovina_Click);
            // 
            // lblTentativi
            // 
            this.lblTentativi.AutoSize = true;
            this.lblTentativi.Location = new System.Drawing.Point(163, 87);
            this.lblTentativi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTentativi.Name = "lblTentativi";
            this.lblTentativi.Size = new System.Drawing.Size(28, 16);
            this.lblTentativi.TabIndex = 8;
            this.lblTentativi.Text = "       ";
            // 
            // pictureBoxSu
            // 
            this.pictureBoxSu.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSu.Image")));
            this.pictureBoxSu.Location = new System.Drawing.Point(225, 74);
            this.pictureBoxSu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxSu.Name = "pictureBoxSu";
            this.pictureBoxSu.Size = new System.Drawing.Size(48, 30);
            this.pictureBoxSu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSu.TabIndex = 9;
            this.pictureBoxSu.TabStop = false;
            // 
            // pictureBoxGiu
            // 
            this.pictureBoxGiu.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGiu.Image")));
            this.pictureBoxGiu.Location = new System.Drawing.Point(281, 74);
            this.pictureBoxGiu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxGiu.Name = "pictureBoxGiu";
            this.pictureBoxGiu.Size = new System.Drawing.Size(48, 30);
            this.pictureBoxGiu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGiu.TabIndex = 10;
            this.pictureBoxGiu.TabStop = false;
            // 
            // lblRisultato
            // 
            this.lblRisultato.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRisultato.Location = new System.Drawing.Point(17, 167);
            this.lblRisultato.Name = "lblRisultato";
            this.lblRisultato.Size = new System.Drawing.Size(311, 23);
            this.lblRisultato.TabIndex = 12;
            this.lblRisultato.Text = "        ";
            this.lblRisultato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AltoBasso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(585, 404);
            this.Controls.Add(this.lblRisultato);
            this.Controls.Add(this.pictureBoxGiu);
            this.Controls.Add(this.pictureBoxSu);
            this.Controls.Add(this.lblTentativi);
            this.Controls.Add(this.btnIndovina);
            this.Controls.Add(this.lblTRimasti);
            this.Controls.Add(this.lblTentativirimasti);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.Text);
            this.Controls.Add(this.rdbAvanzato);
            this.Controls.Add(this.rdbIntermedio);
            this.Controls.Add(this.rdbBase);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AltoBasso";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGiu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbBase;
        private System.Windows.Forms.RadioButton rdbIntermedio;
        private System.Windows.Forms.RadioButton rdbAvanzato;
        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblTentativirimasti;
        private System.Windows.Forms.Label lblTRimasti;
        private System.Windows.Forms.Button btnIndovina;
        private System.Windows.Forms.Label lblTentativi;
        private System.Windows.Forms.PictureBox pictureBoxSu;
        private System.Windows.Forms.PictureBox pictureBoxGiu;
        private System.Windows.Forms.Label lblRisultato;
    }
}

