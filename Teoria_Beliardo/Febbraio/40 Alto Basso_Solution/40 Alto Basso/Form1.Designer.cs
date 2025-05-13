namespace _40_Alto_Basso
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
            this.rbtnBase = new System.Windows.Forms.RadioButton();
            this.rbtnIntermedio = new System.Windows.Forms.RadioButton();
            this.rbtnAvanzato = new System.Windows.Forms.RadioButton();
            this.btnIndovina = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTentativi = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbtnBase
            // 
            this.rbtnBase.AutoSize = true;
            this.rbtnBase.Location = new System.Drawing.Point(13, 13);
            this.rbtnBase.Name = "rbtnBase";
            this.rbtnBase.Size = new System.Drawing.Size(53, 17);
            this.rbtnBase.TabIndex = 0;
            this.rbtnBase.TabStop = true;
            this.rbtnBase.Text = "BASE";
            this.rbtnBase.UseVisualStyleBackColor = true;
            this.rbtnBase.CheckedChanged += new System.EventHandler(this.rbtnBase_CheckedChanged);
            // 
            // rbtnIntermedio
            // 
            this.rbtnIntermedio.AutoSize = true;
            this.rbtnIntermedio.Location = new System.Drawing.Point(89, 12);
            this.rbtnIntermedio.Name = "rbtnIntermedio";
            this.rbtnIntermedio.Size = new System.Drawing.Size(93, 17);
            this.rbtnIntermedio.TabIndex = 1;
            this.rbtnIntermedio.TabStop = true;
            this.rbtnIntermedio.Text = "INTERMEDIO";
            this.rbtnIntermedio.UseVisualStyleBackColor = true;
            this.rbtnIntermedio.CheckedChanged += new System.EventHandler(this.rbtnIntermedio_CheckedChanged);
            // 
            // rbtnAvanzato
            // 
            this.rbtnAvanzato.AutoSize = true;
            this.rbtnAvanzato.Location = new System.Drawing.Point(206, 12);
            this.rbtnAvanzato.Name = "rbtnAvanzato";
            this.rbtnAvanzato.Size = new System.Drawing.Size(83, 17);
            this.rbtnAvanzato.TabIndex = 2;
            this.rbtnAvanzato.TabStop = true;
            this.rbtnAvanzato.Text = "AVANZATO";
            this.rbtnAvanzato.UseVisualStyleBackColor = true;
            this.rbtnAvanzato.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnIndovina
            // 
            this.btnIndovina.Location = new System.Drawing.Point(46, 102);
            this.btnIndovina.Name = "btnIndovina";
            this.btnIndovina.Size = new System.Drawing.Size(75, 23);
            this.btnIndovina.TabIndex = 3;
            this.btnIndovina.Text = "INDOVINA";
            this.btnIndovina.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "INSERISCI IL NUMERO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "TENTATIVI RIMASTI:";
            // 
            // lblTentativi
            // 
            this.lblTentativi.AutoSize = true;
            this.lblTentativi.Location = new System.Drawing.Point(143, 72);
            this.lblTentativi.Name = "lblTentativi";
            this.lblTentativi.Size = new System.Drawing.Size(35, 13);
            this.lblTentativi.TabIndex = 6;
            this.lblTentativi.Text = "label3";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(146, 45);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 7;
            // 
            // AltoBasso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblTentativi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIndovina);
            this.Controls.Add(this.rbtnAvanzato);
            this.Controls.Add(this.rbtnIntermedio);
            this.Controls.Add(this.rbtnBase);
            this.Name = "AltoBasso";
            this.Text = "Gioco alto basso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnBase;
        private System.Windows.Forms.RadioButton rbtnIntermedio;
        private System.Windows.Forms.RadioButton rbtnAvanzato;
        private System.Windows.Forms.Button btnIndovina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTentativi;
        private System.Windows.Forms.TextBox txtNumero;
    }
}

