namespace Olivero_Pietro_Verifica
{
    partial class Verifica
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
            this.btnCarica = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnCercaPerRegistra = new System.Windows.Forms.Button();
            this.btnFiltraPerAnno = new System.Windows.Forms.Button();
            this.btnCalcolaMedia = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtRegista = new System.Windows.Forms.TextBox();
            this.txtAnnoMassimo = new System.Windows.Forms.TextBox();
            this.txtAnnoMinimo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAnnoMIn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCarica
            // 
            this.btnCarica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarica.Location = new System.Drawing.Point(12, 12);
            this.btnCarica.Name = "btnCarica";
            this.btnCarica.Size = new System.Drawing.Size(167, 38);
            this.btnCarica.TabIndex = 0;
            this.btnCarica.Text = "Carica File";
            this.btnCarica.UseVisualStyleBackColor = true;
            this.btnCarica.Click += new System.EventHandler(this.btnCarica_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalva.Location = new System.Drawing.Point(12, 87);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(167, 38);
            this.btnSalva.TabIndex = 1;
            this.btnSalva.Text = "Salva File";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnCercaPerRegistra
            // 
            this.btnCercaPerRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCercaPerRegistra.Location = new System.Drawing.Point(12, 162);
            this.btnCercaPerRegistra.Name = "btnCercaPerRegistra";
            this.btnCercaPerRegistra.Size = new System.Drawing.Size(167, 38);
            this.btnCercaPerRegistra.TabIndex = 2;
            this.btnCercaPerRegistra.Text = "Cerca per Regista";
            this.btnCercaPerRegistra.UseVisualStyleBackColor = true;
            this.btnCercaPerRegistra.Click += new System.EventHandler(this.btnCercaPerRegistra_Click);
            // 
            // btnFiltraPerAnno
            // 
            this.btnFiltraPerAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltraPerAnno.Location = new System.Drawing.Point(12, 237);
            this.btnFiltraPerAnno.Name = "btnFiltraPerAnno";
            this.btnFiltraPerAnno.Size = new System.Drawing.Size(167, 38);
            this.btnFiltraPerAnno.TabIndex = 3;
            this.btnFiltraPerAnno.Text = "Fitra per anno";
            this.btnFiltraPerAnno.UseVisualStyleBackColor = true;
            this.btnFiltraPerAnno.Click += new System.EventHandler(this.btnFiltraPerAnno_Click);
            // 
            // btnCalcolaMedia
            // 
            this.btnCalcolaMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcolaMedia.Location = new System.Drawing.Point(12, 312);
            this.btnCalcolaMedia.Name = "btnCalcolaMedia";
            this.btnCalcolaMedia.Size = new System.Drawing.Size(167, 38);
            this.btnCalcolaMedia.TabIndex = 4;
            this.btnCalcolaMedia.Text = "Calcola media voti";
            this.btnCalcolaMedia.UseVisualStyleBackColor = true;
            this.btnCalcolaMedia.Click += new System.EventHandler(this.btnCalcolaMedia_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(217, 12);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(560, 338);
            this.dgv.TabIndex = 5;
            // 
            // txtRegista
            // 
            this.txtRegista.Location = new System.Drawing.Point(37, 402);
            this.txtRegista.Name = "txtRegista";
            this.txtRegista.Size = new System.Drawing.Size(166, 20);
            this.txtRegista.TabIndex = 6;
            // 
            // txtAnnoMassimo
            // 
            this.txtAnnoMassimo.Location = new System.Drawing.Point(611, 402);
            this.txtAnnoMassimo.Name = "txtAnnoMassimo";
            this.txtAnnoMassimo.Size = new System.Drawing.Size(166, 20);
            this.txtAnnoMassimo.TabIndex = 7;
            // 
            // txtAnnoMinimo
            // 
            this.txtAnnoMinimo.Location = new System.Drawing.Point(412, 402);
            this.txtAnnoMinimo.Name = "txtAnnoMinimo";
            this.txtAnnoMinimo.Size = new System.Drawing.Size(166, 20);
            this.txtAnnoMinimo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Inserire il nome del regista (CASE SENSITIVE)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(660, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Anno massimo";
            // 
            // labelAnnoMIn
            // 
            this.labelAnnoMIn.AutoSize = true;
            this.labelAnnoMIn.Location = new System.Drawing.Point(464, 378);
            this.labelAnnoMIn.Name = "labelAnnoMIn";
            this.labelAnnoMIn.Size = new System.Drawing.Size(70, 13);
            this.labelAnnoMIn.TabIndex = 11;
            this.labelAnnoMIn.Text = "Anno minimo:";
            // 
            // Verifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(800, 434);
            this.Controls.Add(this.labelAnnoMIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAnnoMinimo);
            this.Controls.Add(this.txtAnnoMassimo);
            this.Controls.Add(this.txtRegista);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnCalcolaMedia);
            this.Controls.Add(this.btnFiltraPerAnno);
            this.Controls.Add(this.btnCercaPerRegistra);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnCarica);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Verifica";
            this.Text = "Verifica Olivero";
            this.Load += new System.EventHandler(this.Verifica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCarica;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCercaPerRegistra;
        private System.Windows.Forms.Button btnFiltraPerAnno;
        private System.Windows.Forms.Button btnCalcolaMedia;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtRegista;
        private System.Windows.Forms.TextBox txtAnnoMassimo;
        private System.Windows.Forms.TextBox txtAnnoMinimo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAnnoMIn;
    }
}

