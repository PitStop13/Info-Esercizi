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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvScrutinio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvScrutinio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvScrutinio.Dock = System.Windows.Forms.DockStyle.Left;
            this.DgvScrutinio.Location = new System.Drawing.Point(0, 0);
            this.DgvScrutinio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvScrutinio.Name = "DgvScrutinio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvScrutinio.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvScrutinio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvScrutinio.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvScrutinio.Size = new System.Drawing.Size(1271, 622);
            this.DgvScrutinio.TabIndex = 0;
            // 
            // lblStatistiche
            // 
            this.lblStatistiche.AutoSize = true;
            this.lblStatistiche.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistiche.Location = new System.Drawing.Point(1352, 30);
            this.lblStatistiche.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatistiche.Name = "lblStatistiche";
            this.lblStatistiche.Size = new System.Drawing.Size(204, 31);
            this.lblStatistiche.TabIndex = 1;
            this.lblStatistiche.Text = "STATISTICHE";
            // 
            // lblStud
            // 
            this.lblStud.AutoSize = true;
            this.lblStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStud.Location = new System.Drawing.Point(1303, 117);
            this.lblStud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStud.Name = "lblStud";
            this.lblStud.Size = new System.Drawing.Size(97, 25);
            this.lblStud.TabIndex = 2;
            this.lblStud.Text = "Studente:";
            // 
            // cmbStudente
            // 
            this.cmbStudente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudente.FormattingEnabled = true;
            this.cmbStudente.Location = new System.Drawing.Point(1421, 113);
            this.cmbStudente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStudente.Name = "cmbStudente";
            this.cmbStudente.Size = new System.Drawing.Size(213, 33);
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
            this.gbContaEsiti.Location = new System.Drawing.Point(1308, 169);
            this.gbContaEsiti.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbContaEsiti.Name = "gbContaEsiti";
            this.gbContaEsiti.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbContaEsiti.Size = new System.Drawing.Size(328, 175);
            this.gbContaEsiti.TabIndex = 4;
            this.gbContaEsiti.TabStop = false;
            this.gbContaEsiti.Text = "CONTA ESITI";
            // 
            // btnContaEsiti
            // 
            this.btnContaEsiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContaEsiti.Location = new System.Drawing.Point(159, 63);
            this.btnContaEsiti.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContaEsiti.Name = "btnContaEsiti";
            this.btnContaEsiti.Size = new System.Drawing.Size(161, 44);
            this.btnContaEsiti.TabIndex = 3;
            this.btnContaEsiti.Text = "CONTA ESITI";
            this.btnContaEsiti.UseVisualStyleBackColor = true;
            this.btnContaEsiti.Click += new System.EventHandler(this.btnContaEsiti_Click);
            // 
            // rdbRimandati
            // 
            this.rdbRimandati.AutoSize = true;
            this.rdbRimandati.Location = new System.Drawing.Point(16, 126);
            this.rdbRimandati.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbRimandati.Name = "rdbRimandati";
            this.rdbRimandati.Size = new System.Drawing.Size(105, 24);
            this.rdbRimandati.TabIndex = 2;
            this.rdbRimandati.TabStop = true;
            this.rdbRimandati.Text = "Rimandati";
            this.rdbRimandati.UseVisualStyleBackColor = true;
            // 
            // rdbBocciati
            // 
            this.rdbBocciati.AutoSize = true;
            this.rdbBocciati.Location = new System.Drawing.Point(16, 73);
            this.rdbBocciati.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbBocciati.Name = "rdbBocciati";
            this.rdbBocciati.Size = new System.Drawing.Size(91, 24);
            this.rdbBocciati.TabIndex = 1;
            this.rdbBocciati.TabStop = true;
            this.rdbBocciati.Text = "Bocciati";
            this.rdbBocciati.UseVisualStyleBackColor = true;
            // 
            // rdbPromossi
            // 
            this.rdbPromossi.AutoSize = true;
            this.rdbPromossi.Location = new System.Drawing.Point(16, 28);
            this.rdbPromossi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbPromossi.Name = "rdbPromossi";
            this.rdbPromossi.Size = new System.Drawing.Size(101, 24);
            this.rdbPromossi.TabIndex = 0;
            this.rdbPromossi.TabStop = true;
            this.rdbPromossi.Text = "Promossi";
            this.rdbPromossi.UseVisualStyleBackColor = true;
            // 
            // cmbMateria
            // 
            this.cmbMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(1421, 386);
            this.cmbMateria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(213, 33);
            this.cmbMateria.TabIndex = 6;
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateria.Location = new System.Drawing.Point(1303, 390);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(83, 25);
            this.lblMateria.TabIndex = 5;
            this.lblMateria.Text = "Materia:";
            // 
            // btnMateriaBalorda
            // 
            this.btnMateriaBalorda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMateriaBalorda.Location = new System.Drawing.Point(1308, 446);
            this.btnMateriaBalorda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMateriaBalorda.Name = "btnMateriaBalorda";
            this.btnMateriaBalorda.Size = new System.Drawing.Size(328, 44);
            this.btnMateriaBalorda.TabIndex = 7;
            this.btnMateriaBalorda.Text = "MATERIA BALORDA";
            this.btnMateriaBalorda.UseVisualStyleBackColor = true;
            // 
            // btnVotoTraDue
            // 
            this.btnVotoTraDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVotoTraDue.Location = new System.Drawing.Point(1308, 503);
            this.btnVotoTraDue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVotoTraDue.Name = "btnVotoTraDue";
            this.btnVotoTraDue.Size = new System.Drawing.Size(328, 44);
            this.btnVotoTraDue.TabIndex = 8;
            this.btnVotoTraDue.Text = "VOTO TRA DUE VALORI";
            this.btnVotoTraDue.UseVisualStyleBackColor = true;
            // 
            // btnStudSuGiu
            // 
            this.btnStudSuGiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudSuGiu.Location = new System.Drawing.Point(1308, 561);
            this.btnStudSuGiu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStudSuGiu.Name = "btnStudSuGiu";
            this.btnStudSuGiu.Size = new System.Drawing.Size(328, 44);
            this.btnStudSuGiu.TabIndex = 9;
            this.btnStudSuGiu.Text = "STUDENTI SU E GIU";
            this.btnStudSuGiu.UseVisualStyleBackColor = true;
            // 
            // FormScrutinio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1665, 622);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

