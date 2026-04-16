namespace ThreadKitchen
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
            this.lblTitolo = new System.Windows.Forms.Label();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExpectedAndTotalSteps = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.lblFornelli = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.grpChefs = new System.Windows.Forms.GroupBox();
            this.lblPrecChef3 = new System.Windows.Forms.Label();
            this.pbChef3 = new System.Windows.Forms.ProgressBar();
            this.lblChef3 = new System.Windows.Forms.Label();
            this.lblPrecChef2 = new System.Windows.Forms.Label();
            this.pbChef2 = new System.Windows.Forms.ProgressBar();
            this.lblChef2 = new System.Windows.Forms.Label();
            this.lblPrecChef1 = new System.Windows.Forms.Label();
            this.pbChef1 = new System.Windows.Forms.ProgressBar();
            this.lblChef1 = new System.Windows.Forms.Label();
            this.lblPrecChef0 = new System.Windows.Forms.Label();
            this.pbChef0 = new System.Windows.Forms.ProgressBar();
            this.lblChef0 = new System.Windows.Forms.Label();
            this.panelBtn.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.grpChefs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitolo.Location = new System.Drawing.Point(0, 0);
            this.lblTitolo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(715, 40);
            this.lblTitolo.TabIndex = 0;
            this.lblTitolo.Text = "🍳 ThreadKIitchen — La cucina dei thread";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBtn
            // 
            this.panelBtn.Controls.Add(this.btnReset);
            this.panelBtn.Controls.Add(this.btnStart);
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtn.Location = new System.Drawing.Point(0, 536);
            this.panelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(715, 61);
            this.panelBtn.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReset.Location = new System.Drawing.Point(202, 13);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 38);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "↺  Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.Location = new System.Drawing.Point(4, 13);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(179, 38);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "▶  Avvia cucina";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.panel1);
            this.panelData.Controls.Add(this.grpLog);
            this.panelData.Controls.Add(this.grpChefs);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 40);
            this.panelData.Margin = new System.Windows.Forms.Padding(2);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(715, 496);
            this.panelData.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblExpectedAndTotalSteps);
            this.panel1.Controls.Add(this.lblWinner);
            this.panel1.Controls.Add(this.lblFornelli);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 99);
            this.panel1.TabIndex = 2;
            // 
            // lblExpectedAndTotalSteps
            // 
            this.lblExpectedAndTotalSteps.AutoSize = true;
            this.lblExpectedAndTotalSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpectedAndTotalSteps.ForeColor = System.Drawing.Color.Lime;
            this.lblExpectedAndTotalSteps.Location = new System.Drawing.Point(302, 17);
            this.lblExpectedAndTotalSteps.Name = "lblExpectedAndTotalSteps";
            this.lblExpectedAndTotalSteps.Size = new System.Drawing.Size(120, 16);
            this.lblExpectedAndTotalSteps.TabIndex = 2;
            this.lblExpectedAndTotalSteps.Text = "Atteso: 0    Reale: 0";
            this.lblExpectedAndTotalSteps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.Lime;
            this.lblWinner.Location = new System.Drawing.Point(318, 43);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(86, 16);
            this.lblWinner.TabIndex = 1;
            this.lblWinner.Text = "Il vincitore è...";
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFornelli
            // 
            this.lblFornelli.AutoSize = true;
            this.lblFornelli.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblFornelli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFornelli.ForeColor = System.Drawing.Color.Lime;
            this.lblFornelli.Location = new System.Drawing.Point(309, 69);
            this.lblFornelli.Name = "lblFornelli";
            this.lblFornelli.Size = new System.Drawing.Size(113, 16);
            this.lblFornelli.TabIndex = 0;
            this.lblFornelli.Text = "Fornelli in uso: 0/2";
            this.lblFornelli.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.rtbLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpLog.Location = new System.Drawing.Point(0, 328);
            this.grpLog.Margin = new System.Windows.Forms.Padding(2);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(2);
            this.grpLog.Size = new System.Drawing.Size(715, 168);
            this.grpLog.TabIndex = 1;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "📜 Log attività";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.ControlText;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.ForeColor = System.Drawing.Color.Lime;
            this.rtbLog.Location = new System.Drawing.Point(2, 19);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(2);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(711, 147);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // grpChefs
            // 
            this.grpChefs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.grpChefs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpChefs.Controls.Add(this.lblPrecChef3);
            this.grpChefs.Controls.Add(this.pbChef3);
            this.grpChefs.Controls.Add(this.lblChef3);
            this.grpChefs.Controls.Add(this.lblPrecChef2);
            this.grpChefs.Controls.Add(this.pbChef2);
            this.grpChefs.Controls.Add(this.lblChef2);
            this.grpChefs.Controls.Add(this.lblPrecChef1);
            this.grpChefs.Controls.Add(this.pbChef1);
            this.grpChefs.Controls.Add(this.lblChef1);
            this.grpChefs.Controls.Add(this.lblPrecChef0);
            this.grpChefs.Controls.Add(this.pbChef0);
            this.grpChefs.Controls.Add(this.lblChef0);
            this.grpChefs.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChefs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChefs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpChefs.Location = new System.Drawing.Point(0, 0);
            this.grpChefs.Margin = new System.Windows.Forms.Padding(2);
            this.grpChefs.Name = "grpChefs";
            this.grpChefs.Padding = new System.Windows.Forms.Padding(2);
            this.grpChefs.Size = new System.Drawing.Size(715, 224);
            this.grpChefs.TabIndex = 0;
            this.grpChefs.TabStop = false;
            this.grpChefs.Text = "👨‍🍳 Cuochi al lavoro";
            // 
            // lblPrecChef3
            // 
            this.lblPrecChef3.AutoSize = true;
            this.lblPrecChef3.ForeColor = System.Drawing.Color.Lime;
            this.lblPrecChef3.Location = new System.Drawing.Point(638, 174);
            this.lblPrecChef3.Name = "lblPrecChef3";
            this.lblPrecChef3.Size = new System.Drawing.Size(46, 18);
            this.lblPrecChef3.TabIndex = 11;
            this.lblPrecChef3.Text = "label1";
            // 
            // pbChef3
            // 
            this.pbChef3.Location = new System.Drawing.Point(286, 169);
            this.pbChef3.Name = "pbChef3";
            this.pbChef3.Size = new System.Drawing.Size(346, 23);
            this.pbChef3.TabIndex = 10;
            // 
            // lblChef3
            // 
            this.lblChef3.AutoSize = true;
            this.lblChef3.Location = new System.Drawing.Point(12, 174);
            this.lblChef3.Name = "lblChef3";
            this.lblChef3.Size = new System.Drawing.Size(46, 18);
            this.lblChef3.TabIndex = 9;
            this.lblChef3.Text = "label1";
            // 
            // lblPrecChef2
            // 
            this.lblPrecChef2.AutoSize = true;
            this.lblPrecChef2.ForeColor = System.Drawing.Color.Lime;
            this.lblPrecChef2.Location = new System.Drawing.Point(638, 128);
            this.lblPrecChef2.Name = "lblPrecChef2";
            this.lblPrecChef2.Size = new System.Drawing.Size(46, 18);
            this.lblPrecChef2.TabIndex = 8;
            this.lblPrecChef2.Text = "label1";
            // 
            // pbChef2
            // 
            this.pbChef2.Location = new System.Drawing.Point(286, 123);
            this.pbChef2.Name = "pbChef2";
            this.pbChef2.Size = new System.Drawing.Size(346, 23);
            this.pbChef2.TabIndex = 7;
            // 
            // lblChef2
            // 
            this.lblChef2.AutoSize = true;
            this.lblChef2.Location = new System.Drawing.Point(12, 128);
            this.lblChef2.Name = "lblChef2";
            this.lblChef2.Size = new System.Drawing.Size(46, 18);
            this.lblChef2.TabIndex = 6;
            this.lblChef2.Text = "label1";
            // 
            // lblPrecChef1
            // 
            this.lblPrecChef1.AutoSize = true;
            this.lblPrecChef1.ForeColor = System.Drawing.Color.Lime;
            this.lblPrecChef1.Location = new System.Drawing.Point(638, 82);
            this.lblPrecChef1.Name = "lblPrecChef1";
            this.lblPrecChef1.Size = new System.Drawing.Size(46, 18);
            this.lblPrecChef1.TabIndex = 5;
            this.lblPrecChef1.Text = "label1";
            // 
            // pbChef1
            // 
            this.pbChef1.Location = new System.Drawing.Point(286, 77);
            this.pbChef1.Name = "pbChef1";
            this.pbChef1.Size = new System.Drawing.Size(346, 23);
            this.pbChef1.TabIndex = 4;
            // 
            // lblChef1
            // 
            this.lblChef1.AutoSize = true;
            this.lblChef1.Location = new System.Drawing.Point(12, 82);
            this.lblChef1.Name = "lblChef1";
            this.lblChef1.Size = new System.Drawing.Size(46, 18);
            this.lblChef1.TabIndex = 3;
            this.lblChef1.Text = "label1";
            // 
            // lblPrecChef0
            // 
            this.lblPrecChef0.AutoSize = true;
            this.lblPrecChef0.ForeColor = System.Drawing.Color.Lime;
            this.lblPrecChef0.Location = new System.Drawing.Point(638, 38);
            this.lblPrecChef0.Name = "lblPrecChef0";
            this.lblPrecChef0.Size = new System.Drawing.Size(46, 18);
            this.lblPrecChef0.TabIndex = 2;
            this.lblPrecChef0.Text = "label1";
            // 
            // pbChef0
            // 
            this.pbChef0.Location = new System.Drawing.Point(286, 33);
            this.pbChef0.Name = "pbChef0";
            this.pbChef0.Size = new System.Drawing.Size(346, 23);
            this.pbChef0.TabIndex = 1;
            // 
            // lblChef0
            // 
            this.lblChef0.AutoSize = true;
            this.lblChef0.Location = new System.Drawing.Point(12, 38);
            this.lblChef0.Name = "lblChef0";
            this.lblChef0.Size = new System.Drawing.Size(46, 18);
            this.lblChef0.TabIndex = 0;
            this.lblChef0.Text = "label1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(715, 597);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelBtn);
            this.Controls.Add(this.lblTitolo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "🍳 ThreadKitchen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBtn.ResumeLayout(false);
            this.panelData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.grpChefs.ResumeLayout(false);
            this.grpChefs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Panel panelBtn;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpChefs;
        private System.Windows.Forms.Label lblPrecChef3;
        private System.Windows.Forms.ProgressBar pbChef3;
        private System.Windows.Forms.Label lblChef3;
        private System.Windows.Forms.Label lblPrecChef2;
        private System.Windows.Forms.ProgressBar pbChef2;
        private System.Windows.Forms.Label lblChef2;
        private System.Windows.Forms.Label lblPrecChef1;
        private System.Windows.Forms.ProgressBar pbChef1;
        private System.Windows.Forms.Label lblChef1;
        private System.Windows.Forms.Label lblPrecChef0;
        private System.Windows.Forms.ProgressBar pbChef0;
        private System.Windows.Forms.Label lblChef0;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFornelli;
        private System.Windows.Forms.Label lblExpectedAndTotalSteps;
        private System.Windows.Forms.Label lblWinner;
    }
}

