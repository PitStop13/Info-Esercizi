namespace Es_Master_Mind
{
    partial class Form_MasterMind
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
            this.DgvInput = new System.Windows.Forms.DataGridView();
            this.btnRow1 = new System.Windows.Forms.Button();
            this.DgvRisultato = new System.Windows.Forms.DataGridView();
            this.btnRow2 = new System.Windows.Forms.Button();
            this.btnRow3 = new System.Windows.Forms.Button();
            this.btnRow4 = new System.Windows.Forms.Button();
            this.btnRow5 = new System.Windows.Forms.Button();
            this.btnRow6 = new System.Windows.Forms.Button();
            this.btnRow7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRisultato)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvInput
            // 
            this.DgvInput.AllowUserToAddRows = false;
            this.DgvInput.AllowUserToDeleteRows = false;
            this.DgvInput.AllowUserToResizeColumns = false;
            this.DgvInput.AllowUserToResizeRows = false;
            this.DgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInput.ColumnHeadersVisible = false;
            this.DgvInput.Location = new System.Drawing.Point(0, 0);
            this.DgvInput.Margin = new System.Windows.Forms.Padding(4);
            this.DgvInput.Name = "DgvInput";
            this.DgvInput.ReadOnly = true;
            this.DgvInput.RowHeadersVisible = false;
            this.DgvInput.RowHeadersWidth = 51;
            this.DgvInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvInput.Size = new System.Drawing.Size(372, 426);
            this.DgvInput.TabIndex = 0;
            this.DgvInput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInput_CellClick);
            // 
            // btnRow1
            // 
            this.btnRow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow1.Location = new System.Drawing.Point(380, 13);
            this.btnRow1.Margin = new System.Windows.Forms.Padding(4);
            this.btnRow1.Name = "btnRow1";
            this.btnRow1.Size = new System.Drawing.Size(45, 41);
            this.btnRow1.TabIndex = 1;
            this.btnRow1.Text = ">";
            this.btnRow1.UseVisualStyleBackColor = true;
            this.btnRow1.Click += new System.EventHandler(this.btnRow1_Click);
            // 
            // DgvRisultato
            // 
            this.DgvRisultato.AllowUserToAddRows = false;
            this.DgvRisultato.AllowUserToDeleteRows = false;
            this.DgvRisultato.AllowUserToResizeColumns = false;
            this.DgvRisultato.AllowUserToResizeRows = false;
            this.DgvRisultato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRisultato.ColumnHeadersVisible = false;
            this.DgvRisultato.Enabled = false;
            this.DgvRisultato.Location = new System.Drawing.Point(433, 0);
            this.DgvRisultato.Margin = new System.Windows.Forms.Padding(4);
            this.DgvRisultato.MultiSelect = false;
            this.DgvRisultato.Name = "DgvRisultato";
            this.DgvRisultato.ReadOnly = true;
            this.DgvRisultato.RowHeadersVisible = false;
            this.DgvRisultato.RowHeadersWidth = 51;
            this.DgvRisultato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvRisultato.Size = new System.Drawing.Size(372, 426);
            this.DgvRisultato.TabIndex = 2;
            // 
            // btnRow2
            // 
            this.btnRow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow2.Location = new System.Drawing.Point(380, 71);
            this.btnRow2.Margin = new System.Windows.Forms.Padding(4);
            this.btnRow2.Name = "btnRow2";
            this.btnRow2.Size = new System.Drawing.Size(45, 41);
            this.btnRow2.TabIndex = 3;
            this.btnRow2.Text = ">";
            this.btnRow2.UseVisualStyleBackColor = true;
            this.btnRow2.Click += new System.EventHandler(this.btnRow2_Click);
            // 
            // btnRow3
            // 
            this.btnRow3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow3.Location = new System.Drawing.Point(380, 131);
            this.btnRow3.Margin = new System.Windows.Forms.Padding(4);
            this.btnRow3.Name = "btnRow3";
            this.btnRow3.Size = new System.Drawing.Size(45, 41);
            this.btnRow3.TabIndex = 4;
            this.btnRow3.Text = ">";
            this.btnRow3.UseVisualStyleBackColor = true;
            this.btnRow3.Click += new System.EventHandler(this.btnRow3_Click);
            // 
            // btnRow4
            // 
            this.btnRow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow4.Location = new System.Drawing.Point(380, 192);
            this.btnRow4.Margin = new System.Windows.Forms.Padding(4);
            this.btnRow4.Name = "btnRow4";
            this.btnRow4.Size = new System.Drawing.Size(45, 41);
            this.btnRow4.TabIndex = 5;
            this.btnRow4.Text = ">";
            this.btnRow4.UseVisualStyleBackColor = true;
            this.btnRow4.Click += new System.EventHandler(this.btnRow4_Click);
            // 
            // btnRow5
            // 
            this.btnRow5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow5.Location = new System.Drawing.Point(380, 257);
            this.btnRow5.Margin = new System.Windows.Forms.Padding(4);
            this.btnRow5.Name = "btnRow5";
            this.btnRow5.Size = new System.Drawing.Size(45, 41);
            this.btnRow5.TabIndex = 6;
            this.btnRow5.Text = ">";
            this.btnRow5.UseVisualStyleBackColor = true;
            this.btnRow5.Click += new System.EventHandler(this.btnRow5_Click);
            // 
            // btnRow6
            // 
            this.btnRow6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow6.Location = new System.Drawing.Point(380, 315);
            this.btnRow6.Margin = new System.Windows.Forms.Padding(4);
            this.btnRow6.Name = "btnRow6";
            this.btnRow6.Size = new System.Drawing.Size(45, 41);
            this.btnRow6.TabIndex = 7;
            this.btnRow6.Text = ">";
            this.btnRow6.UseVisualStyleBackColor = true;
            this.btnRow6.Click += new System.EventHandler(this.btnRow6_Click);
            // 
            // btnRow7
            // 
            this.btnRow7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow7.Location = new System.Drawing.Point(380, 373);
            this.btnRow7.Margin = new System.Windows.Forms.Padding(4);
            this.btnRow7.Name = "btnRow7";
            this.btnRow7.Size = new System.Drawing.Size(45, 41);
            this.btnRow7.TabIndex = 8;
            this.btnRow7.Text = ">";
            this.btnRow7.UseVisualStyleBackColor = true;
            this.btnRow7.Click += new System.EventHandler(this.btnRow7_Click);
            // 
            // Form_MasterMind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 427);
            this.Controls.Add(this.btnRow7);
            this.Controls.Add(this.btnRow6);
            this.Controls.Add(this.btnRow5);
            this.Controls.Add(this.btnRow4);
            this.Controls.Add(this.btnRow3);
            this.Controls.Add(this.btnRow2);
            this.Controls.Add(this.DgvRisultato);
            this.Controls.Add(this.btnRow1);
            this.Controls.Add(this.DgvInput);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_MasterMind";
            this.Text = "Master mind";
            this.Load += new System.EventHandler(this.Form_MasterMind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRisultato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvInput;
        private System.Windows.Forms.Button btnRow1;
        private System.Windows.Forms.DataGridView DgvRisultato;
        private System.Windows.Forms.Button btnRow2;
        private System.Windows.Forms.Button btnRow3;
        private System.Windows.Forms.Button btnRow4;
        private System.Windows.Forms.Button btnRow5;
        private System.Windows.Forms.Button btnRow6;
        private System.Windows.Forms.Button btnRow7;
    }
}

