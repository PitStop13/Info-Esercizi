namespace Scrutinio
{
    partial class FormScrutinio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvScrutinio = new System.Windows.Forms.DataGridView();
            this.lblStatistiche = new System.Windows.Forms.Label();
            this.lblStud = new System.Windows.Forms.Label();
            this.cmbStudente = new System.Windows.Forms.ComboBox();
            this.gbContaEsiti = new System.Windows.Forms.GroupBox();
            this.btnContaEsiti = new System.Windows.Forms.Button();
            this.rdbRimandati = new System.Windows.Forms.RadioButton();
            this.rdbBocciati = new System.Windows.Forms.RadioButton();
            this.rdbPromossi = new System.Windows.Forms.RadioButton();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnMateriaBalorda = new System.Windows.Forms.Button();
            this.btnVotoTraDue = new System.Windows.Forms.Button();
            this.btnStudSuGiu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvScrutinio)).BeginInit();
            this.gbContaEsiti.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvScrutinio
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvScrutinio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvScrutinio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvScrutinio.Dock = System.Windows.Forms.DockStyle.Left;
            this.DgvScrutinio.Location = new System.Drawing.Point(0, 0);
            this.DgvScrutinio.Name = "DgvScrutinio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvScrutinio.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvScrutinio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvScrutinio.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvScrutinio.Size = new System.Drawing.Size(851, 378);
            this.DgvScrutinio.TabIndex = 0;
            // 
            // lblStatistiche
            // 
            this.lblStatistiche.AutoSize = true;
            this.lblStatistiche.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistiche.Location = new System.Drawing.Point(914, 1);
            this.lblStatistiche.Name = "lblStatistiche";
            this.lblStatistiche.Size = new System.Drawing.Size(158, 25);
            this.lblStatistiche.TabIndex = 1;
            this.lblStatistiche.Text = "STATISTICHE";
            // 
            // lblStud
            // 
            this.lblStud.AutoSize = true;
            this.lblStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStud.Location = new System.Drawing.Point(871, 32);
            this.lblStud.Name = "lblStud";
            this.lblStud.Size = new System.Drawing.Size(79, 20);
            this.lblStud.TabIndex = 2;
            this.lblStud.Text = "Studente:";
            // 
            // cmbStudente
            // 
            this.cmbStudente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudente.FormattingEnabled = true;
            this.cmbStudente.Location = new System.Drawing.Point(959, 29);
            this.cmbStudente.Name = "cmbStudente";
            this.cmbStudente.Size = new System.Drawing.Size(161, 28);
            this.cmbStudente.TabIndex = 3;
            this.cmbStudente.SelectedIndexChanged += new System.EventHandler(this.cmbStudente_SelectedIndexChanged);
            // 
            // gbContaEsiti
            // 
            this.gbContaEsiti.Controls.Add(this.btnContaEsiti);
            this.gbContaEsiti.Controls.Add(this.rdbRimandati);
            this.gbContaEsiti.Controls.Add(this.rdbBocciati);
            this.gbContaEsiti.Controls.Add(this.rdbPromossi);
            this.gbContaEsiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContaEsiti.Location = new System.Drawing.Point(874, 62);
            this.gbContaEsiti.Name = "gbContaEsiti";
            this.gbContaEsiti.Size = new System.Drawing.Size(246, 142);
            this.gbContaEsiti.TabIndex = 4;
            this.gbContaEsiti.TabStop = false;
            this.gbContaEsiti.Text = "CONTA ESITI";
            // 
            // btnContaEsiti
            // 
            this.btnContaEsiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContaEsiti.Location = new System.Drawing.Point(119, 51);
            this.btnContaEsiti.Name = "btnContaEsiti";
            this.btnContaEsiti.Size = new System.Drawing.Size(121, 36);
            this.btnContaEsiti.TabIndex = 3;
            this.btnContaEsiti.Text = "CONTA ESITI";
            this.btnContaEsiti.UseVisualStyleBackColor = true;
            this.btnContaEsiti.Click += new System.EventHandler(this.btnContaEsiti_Click);
            // 
            // rdbRimandati
            // 
            this.rdbRimandati.AutoSize = true;
            this.rdbRimandati.Location = new System.Drawing.Point(12, 102);
            this.rdbRimandati.Name = "rdbRimandati";
            this.rdbRimandati.Size = new System.Drawing.Size(89, 21);
            this.rdbRimandati.TabIndex = 2;
            this.rdbRimandati.TabStop = true;
            this.rdbRimandati.Text = "Rimandati";
            this.rdbRimandati.UseVisualStyleBackColor = true;
            // 
            // rdbBocciati
            // 
            this.rdbBocciati.AutoSize = true;
            this.rdbBocciati.Location = new System.Drawing.Point(12, 59);
            this.rdbBocciati.Name = "rdbBocciati";
            this.rdbBocciati.Size = new System.Drawing.Size(75, 21);
            this.rdbBocciati.TabIndex = 1;
            this.rdbBocciati.TabStop = true;
            this.rdbBocciati.Text = "Bocciati";
            this.rdbBocciati.UseVisualStyleBackColor = true;
            // 
            // rdbPromossi
            // 
            this.rdbPromossi.AutoSize = true;
            this.rdbPromossi.Location = new System.Drawing.Point(12, 23);
            this.rdbPromossi.Name = "rdbPromossi";
            this.rdbPromossi.Size = new System.Drawing.Size(84, 21);
            this.rdbPromossi.TabIndex = 0;
            this.rdbPromossi.TabStop = true;
            this.rdbPromossi.Text = "Promossi";
            this.rdbPromossi.UseVisualStyleBackColor = true;
            // 
            // cmbMateria
            // 
            this.cmbMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(958, 213);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(161, 28);
            this.cmbMateria.TabIndex = 6;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateria.Location = new System.Drawing.Point(870, 216);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(66, 20);
            this.lblMateria.TabIndex = 5;
            this.lblMateria.Text = "Materia:";
            // 
            // btnMateriaBalorda
            // 
            this.btnMateriaBalorda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMateriaBalorda.Location = new System.Drawing.Point(874, 247);
            this.btnMateriaBalorda.Name = "btnMateriaBalorda";
            this.btnMateriaBalorda.Size = new System.Drawing.Size(246, 36);
            this.btnMateriaBalorda.TabIndex = 7;
            this.btnMateriaBalorda.Text = "MATERIA BALORDA";
            this.btnMateriaBalorda.UseVisualStyleBackColor = true;
            this.btnMateriaBalorda.Click += new System.EventHandler(this.btnMateriaBalorda_Click);
            // 
            // btnVotoTraDue
            // 
            this.btnVotoTraDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVotoTraDue.Location = new System.Drawing.Point(874, 289);
            this.btnVotoTraDue.Name = "btnVotoTraDue";
            this.btnVotoTraDue.Size = new System.Drawing.Size(246, 36);
            this.btnVotoTraDue.TabIndex = 8;
            this.btnVotoTraDue.Text = "VOTO TRA DUE VALORI";
            this.btnVotoTraDue.UseVisualStyleBackColor = true;
            this.btnVotoTraDue.Click += new System.EventHandler(this.btnVotoTraDue_Click);
            // 
            // btnStudSuGiu
            // 
            this.btnStudSuGiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudSuGiu.Location = new System.Drawing.Point(874, 332);
            this.btnStudSuGiu.Name = "btnStudSuGiu";
            this.btnStudSuGiu.Size = new System.Drawing.Size(246, 36);
            this.btnStudSuGiu.TabIndex = 9;
            this.btnStudSuGiu.Text = "STUDENTI SU E GIU";
            this.btnStudSuGiu.UseVisualStyleBackColor = true;
            this.btnStudSuGiu.Click += new System.EventHandler(this.btnStudSuGiu_Click);
            // 
            // FormScrutinio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 378);
            this.Controls.Add(this.btnStudSuGiu);
            this.Controls.Add(this.btnVotoTraDue);
            this.Controls.Add(this.btnMateriaBalorda);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.gbContaEsiti);
            this.Controls.Add(this.cmbStudente);
            this.Controls.Add(this.lblStud);
            this.Controls.Add(this.lblStatistiche);
            this.Controls.Add(this.DgvScrutinio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormScrutinio";
            this.Text = "Scrutinio";
            this.Load += new System.EventHandler(this.FormScrutinio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvScrutinio)).EndInit();
            this.gbContaEsiti.ResumeLayout(false);
            this.gbContaEsiti.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvScrutinio;
        private System.Windows.Forms.Label lblStatistiche;
        private System.Windows.Forms.Label lblStud;
        private System.Windows.Forms.ComboBox cmbStudente;
        private System.Windows.Forms.GroupBox gbContaEsiti;
        private System.Windows.Forms.Button btnContaEsiti;
        private System.Windows.Forms.RadioButton rdbRimandati;
        private System.Windows.Forms.RadioButton rdbBocciati;
        private System.Windows.Forms.RadioButton rdbPromossi;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label lblMateria;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnMateriaBalorda;
        private System.Windows.Forms.Button btnVotoTraDue;
        private System.Windows.Forms.Button btnStudSuGiu;
    }
}

