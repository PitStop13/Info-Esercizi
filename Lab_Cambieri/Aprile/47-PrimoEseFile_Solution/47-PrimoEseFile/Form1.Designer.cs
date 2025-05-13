namespace _47_PrimoEseFile
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
            this.btnLeggi = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnCopia = new System.Windows.Forms.Button();
            this.btnContaLineeParole = new System.Windows.Forms.Button();
            this.btnSostitureNuovoFile = new System.Windows.Forms.Button();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.btnSostituireStessoFile = new System.Windows.Forms.Button();
            this.btnContaOccorrenze = new System.Windows.Forms.Button();
            this.btnLunghezzaMediaParole = new System.Windows.Forms.Button();
            this.cmbParole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnLeggi
            // 
            this.btnLeggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeggi.Location = new System.Drawing.Point(16, 15);
            this.btnLeggi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLeggi.Name = "btnLeggi";
            this.btnLeggi.Size = new System.Drawing.Size(272, 55);
            this.btnLeggi.TabIndex = 0;
            this.btnLeggi.Text = "LEGGI DAL FILE";
            this.btnLeggi.UseVisualStyleBackColor = true;
            this.btnLeggi.Click += new System.EventHandler(this.btnLeggi_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifica.Location = new System.Drawing.Point(16, 78);
            this.btnModifica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(272, 55);
            this.btnModifica.TabIndex = 1;
            this.btnModifica.Text = "MODIFICA FILE";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnCopia
            // 
            this.btnCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopia.Location = new System.Drawing.Point(16, 140);
            this.btnCopia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopia.Name = "btnCopia";
            this.btnCopia.Size = new System.Drawing.Size(272, 55);
            this.btnCopia.TabIndex = 2;
            this.btnCopia.Text = "COPIA FILE";
            this.btnCopia.UseVisualStyleBackColor = true;
            this.btnCopia.Click += new System.EventHandler(this.btnCopia_Click);
            // 
            // btnContaLineeParole
            // 
            this.btnContaLineeParole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContaLineeParole.Location = new System.Drawing.Point(16, 203);
            this.btnContaLineeParole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContaLineeParole.Name = "btnContaLineeParole";
            this.btnContaLineeParole.Size = new System.Drawing.Size(272, 55);
            this.btnContaLineeParole.TabIndex = 3;
            this.btnContaLineeParole.Text = "CONTA N° LINEE E PAROLE FILE";
            this.btnContaLineeParole.UseVisualStyleBackColor = true;
            this.btnContaLineeParole.Click += new System.EventHandler(this.btnContaLineeParole_Click);
            // 
            // btnSostitureNuovoFile
            // 
            this.btnSostitureNuovoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSostitureNuovoFile.Location = new System.Drawing.Point(16, 266);
            this.btnSostitureNuovoFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSostitureNuovoFile.Name = "btnSostitureNuovoFile";
            this.btnSostitureNuovoFile.Size = new System.Drawing.Size(272, 55);
            this.btnSostitureNuovoFile.TabIndex = 4;
            this.btnSostitureNuovoFile.Text = "SOSTITUIRE UNA PAROLA IN NUOVO FILE";
            this.btnSostitureNuovoFile.UseVisualStyleBackColor = true;
            this.btnSostitureNuovoFile.Click += new System.EventHandler(this.btnSostitureNuovoFile_Click);
            // 
            // rtb1
            // 
            this.rtb1.Location = new System.Drawing.Point(296, 15);
            this.rtb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(357, 180);
            this.rtb1.TabIndex = 5;
            this.rtb1.Text = "";
            // 
            // rtb2
            // 
            this.rtb2.Location = new System.Drawing.Point(663, 15);
            this.rtb2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtb2.Name = "rtb2";
            this.rtb2.Size = new System.Drawing.Size(357, 180);
            this.rtb2.TabIndex = 6;
            this.rtb2.Text = "";
            // 
            // btnSostituireStessoFile
            // 
            this.btnSostituireStessoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSostituireStessoFile.Location = new System.Drawing.Point(296, 203);
            this.btnSostituireStessoFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSostituireStessoFile.Name = "btnSostituireStessoFile";
            this.btnSostituireStessoFile.Size = new System.Drawing.Size(359, 55);
            this.btnSostituireStessoFile.TabIndex = 7;
            this.btnSostituireStessoFile.Text = "SOSTITUIRE NELLO STESSO FILE UNA PAROLA";
            this.btnSostituireStessoFile.UseVisualStyleBackColor = true;
            this.btnSostituireStessoFile.Click += new System.EventHandler(this.btnSostituireStessoFile_Click);
            // 
            // btnContaOccorrenze
            // 
            this.btnContaOccorrenze.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContaOccorrenze.Location = new System.Drawing.Point(296, 266);
            this.btnContaOccorrenze.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContaOccorrenze.Name = "btnContaOccorrenze";
            this.btnContaOccorrenze.Size = new System.Drawing.Size(359, 55);
            this.btnContaOccorrenze.TabIndex = 8;
            this.btnContaOccorrenze.Text = "CONTARE LE OCCORRENZE DELLE PAROLE NEL TESTO";
            this.btnContaOccorrenze.UseVisualStyleBackColor = true;
            this.btnContaOccorrenze.Click += new System.EventHandler(this.btnContaOccorrenze_Click);
            // 
            // btnLunghezzaMediaParole
            // 
            this.btnLunghezzaMediaParole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLunghezzaMediaParole.Location = new System.Drawing.Point(663, 203);
            this.btnLunghezzaMediaParole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLunghezzaMediaParole.Name = "btnLunghezzaMediaParole";
            this.btnLunghezzaMediaParole.Size = new System.Drawing.Size(359, 55);
            this.btnLunghezzaMediaParole.TabIndex = 9;
            this.btnLunghezzaMediaParole.Text = "CALCOLARE LA LUNGHEZZA MEDIA DELLE PAROLE";
            this.btnLunghezzaMediaParole.UseVisualStyleBackColor = true;
            this.btnLunghezzaMediaParole.Click += new System.EventHandler(this.btnLunghezzaMediaParole_Click);
            // 
            // cmbParole
            // 
            this.cmbParole.FormattingEnabled = true;
            this.cmbParole.Location = new System.Drawing.Point(663, 282);
            this.cmbParole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbParole.Name = "cmbParole";
            this.cmbParole.Size = new System.Drawing.Size(357, 24);
            this.cmbParole.TabIndex = 10;
            this.cmbParole.SelectedIndexChanged += new System.EventHandler(this.cmbParole_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 334);
            this.Controls.Add(this.cmbParole);
            this.Controls.Add(this.btnLunghezzaMediaParole);
            this.Controls.Add(this.btnContaOccorrenze);
            this.Controls.Add(this.btnSostituireStessoFile);
            this.Controls.Add(this.rtb2);
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.btnSostitureNuovoFile);
            this.Controls.Add(this.btnContaLineeParole);
            this.Controls.Add(this.btnCopia);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnLeggi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Gestine files di testo";
            this.Load += new System.EventHandler(this.Formmain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLeggi;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnCopia;
        private System.Windows.Forms.Button btnContaLineeParole;
        private System.Windows.Forms.Button btnSostitureNuovoFile;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.Button btnSostituireStessoFile;
        private System.Windows.Forms.Button btnContaOccorrenze;
        private System.Windows.Forms.Button btnLunghezzaMediaParole;
        private System.Windows.Forms.ComboBox cmbParole;
    }
}

