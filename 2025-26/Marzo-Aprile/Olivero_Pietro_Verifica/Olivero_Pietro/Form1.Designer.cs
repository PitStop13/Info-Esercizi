namespace Olivero_Pietro
{
    partial class Form1
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
            this.panelUp = new System.Windows.Forms.Panel();
            this.panelDown = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.SystemColors.Info;
            this.panelUp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panelUp.Location = new System.Drawing.Point(12, 12);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(760, 355);
            this.panelUp.TabIndex = 1;
            // 
            // panelDown
            // 
            this.panelDown.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelDown.Location = new System.Drawing.Point(12, 373);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(760, 176);
            this.panelDown.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Panel panelDown;
    }
}

