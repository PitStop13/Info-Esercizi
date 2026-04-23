namespace ThreadKitchen
{
    partial class FormMain
    {
        /// <summary>Variabile di progettazione necessaria.</summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        private void InitializeComponent()
        {
            this.components   = new System.ComponentModel.Container();

            // Controlli principali
            this.lblTitolo    = new System.Windows.Forms.Label();
            this.lblSteps     = new System.Windows.Forms.Label();
            this.lblWinner    = new System.Windows.Forms.Label();
            this.lblFornelli  = new System.Windows.Forms.Label();
            this.grpCuochi    = new System.Windows.Forms.GroupBox();
            this.grpLog       = new System.Windows.Forms.GroupBox();
            this.rtbLog       = new System.Windows.Forms.RichTextBox();
            this.pnlPulsanti  = new System.Windows.Forms.Panel();
            this.btnAvvia     = new System.Windows.Forms.Button();
            this.btnReset     = new System.Windows.Forms.Button();

            // Controlli cuoco 0
            this.lblChef0     = new System.Windows.Forms.Label();
            this.pbChef0      = new System.Windows.Forms.ProgressBar();
            this.lblPercChef0 = new System.Windows.Forms.Label();

            // Controlli cuoco 1
            this.lblChef1     = new System.Windows.Forms.Label();
            this.pbChef1      = new System.Windows.Forms.ProgressBar();
            this.lblPercChef1 = new System.Windows.Forms.Label();

            // Controlli cuoco 2
            this.lblChef2     = new System.Windows.Forms.Label();
            this.pbChef2      = new System.Windows.Forms.ProgressBar();
            this.lblPercChef2 = new System.Windows.Forms.Label();

            // Controlli cuoco 3
            this.lblChef3     = new System.Windows.Forms.Label();
            this.pbChef3      = new System.Windows.Forms.ProgressBar();
            this.lblPercChef3 = new System.Windows.Forms.Label();

            this.grpCuochi.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.pnlPulsanti.SuspendLayout();
            this.SuspendLayout();

            // ── Titolo ───────────────────────────────────────────────────────────
            this.lblTitolo.Name      = "lblTitolo";
            this.lblTitolo.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblTitolo.AutoSize  = false;
            this.lblTitolo.Height    = 50;
            this.lblTitolo.Text      = "🍳 ThreadKitchen — La cucina dei thread";
            this.lblTitolo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitolo.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.lblTitolo.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── GroupBox Cuochi ──────────────────────────────────────────────────
            this.grpCuochi.Name      = "grpCuochi";
            this.grpCuochi.Dock      = System.Windows.Forms.DockStyle.Top;
            this.grpCuochi.Height    = 215;
            this.grpCuochi.Text      = "👨\u200d🍳 Cuochi al lavoro";
            this.grpCuochi.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCuochi.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCuochi.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.grpCuochi.Padding   = new System.Windows.Forms.Padding(12, 10, 12, 8);

            // ── Cuoco 0 ──────────────────────────────────────────────────────────
            this.lblChef0.Name      = "lblChef0";
            this.lblChef0.AutoSize  = false;
            this.lblChef0.Size      = new System.Drawing.Size(220, 28);
            this.lblChef0.Location  = new System.Drawing.Point(14, 29);
            this.lblChef0.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChef0.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblChef0.BackColor = System.Drawing.Color.Transparent;
            this.lblChef0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pbChef0.Name     = "pbChef0";
            this.pbChef0.Size     = new System.Drawing.Size(320, 20);
            this.pbChef0.Location = new System.Drawing.Point(242, 32);
            this.pbChef0.Minimum  = 0;
            this.pbChef0.Maximum  = 100;
            this.pbChef0.Value    = 0;

            this.lblPercChef0.Name      = "lblPercChef0";
            this.lblPercChef0.AutoSize  = false;
            this.lblPercChef0.Size      = new System.Drawing.Size(48, 20);
            this.lblPercChef0.Location  = new System.Drawing.Point(570, 32);
            this.lblPercChef0.Text      = "0%";
            this.lblPercChef0.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPercChef0.ForeColor = System.Drawing.Color.LightGreen;
            this.lblPercChef0.BackColor = System.Drawing.Color.Transparent;
            this.lblPercChef0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── Cuoco 1 ──────────────────────────────────────────────────────────
            this.lblChef1.Name      = "lblChef1";
            this.lblChef1.AutoSize  = false;
            this.lblChef1.Size      = new System.Drawing.Size(220, 28);
            this.lblChef1.Location  = new System.Drawing.Point(14, 73);
            this.lblChef1.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChef1.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblChef1.BackColor = System.Drawing.Color.Transparent;
            this.lblChef1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pbChef1.Name     = "pbChef1";
            this.pbChef1.Size     = new System.Drawing.Size(320, 20);
            this.pbChef1.Location = new System.Drawing.Point(242, 76);
            this.pbChef1.Minimum  = 0;
            this.pbChef1.Maximum  = 100;
            this.pbChef1.Value    = 0;

            this.lblPercChef1.Name      = "lblPercChef1";
            this.lblPercChef1.AutoSize  = false;
            this.lblPercChef1.Size      = new System.Drawing.Size(48, 20);
            this.lblPercChef1.Location  = new System.Drawing.Point(570, 76);
            this.lblPercChef1.Text      = "0%";
            this.lblPercChef1.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPercChef1.ForeColor = System.Drawing.Color.LightGreen;
            this.lblPercChef1.BackColor = System.Drawing.Color.Transparent;
            this.lblPercChef1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── Cuoco 2 ──────────────────────────────────────────────────────────
            this.lblChef2.Name      = "lblChef2";
            this.lblChef2.AutoSize  = false;
            this.lblChef2.Size      = new System.Drawing.Size(220, 28);
            this.lblChef2.Location  = new System.Drawing.Point(14, 117);
            this.lblChef2.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChef2.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblChef2.BackColor = System.Drawing.Color.Transparent;
            this.lblChef2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pbChef2.Name     = "pbChef2";
            this.pbChef2.Size     = new System.Drawing.Size(320, 20);
            this.pbChef2.Location = new System.Drawing.Point(242, 120);
            this.pbChef2.Minimum  = 0;
            this.pbChef2.Maximum  = 100;
            this.pbChef2.Value    = 0;

            this.lblPercChef2.Name      = "lblPercChef2";
            this.lblPercChef2.AutoSize  = false;
            this.lblPercChef2.Size      = new System.Drawing.Size(48, 20);
            this.lblPercChef2.Location  = new System.Drawing.Point(570, 120);
            this.lblPercChef2.Text      = "0%";
            this.lblPercChef2.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPercChef2.ForeColor = System.Drawing.Color.LightGreen;
            this.lblPercChef2.BackColor = System.Drawing.Color.Transparent;
            this.lblPercChef2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── Cuoco 3 ──────────────────────────────────────────────────────────
            this.lblChef3.Name      = "lblChef3";
            this.lblChef3.AutoSize  = false;
            this.lblChef3.Size      = new System.Drawing.Size(220, 28);
            this.lblChef3.Location  = new System.Drawing.Point(14, 161);
            this.lblChef3.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChef3.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblChef3.BackColor = System.Drawing.Color.Transparent;
            this.lblChef3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pbChef3.Name     = "pbChef3";
            this.pbChef3.Size     = new System.Drawing.Size(320, 20);
            this.pbChef3.Location = new System.Drawing.Point(242, 164);
            this.pbChef3.Minimum  = 0;
            this.pbChef3.Maximum  = 100;
            this.pbChef3.Value    = 0;

            this.lblPercChef3.Name      = "lblPercChef3";
            this.lblPercChef3.AutoSize  = false;
            this.lblPercChef3.Size      = new System.Drawing.Size(48, 20);
            this.lblPercChef3.Location  = new System.Drawing.Point(570, 164);
            this.lblPercChef3.Text      = "0%";
            this.lblPercChef3.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPercChef3.ForeColor = System.Drawing.Color.LightGreen;
            this.lblPercChef3.BackColor = System.Drawing.Color.Transparent;
            this.lblPercChef3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Aggiunta controlli cuochi al GroupBox
            this.grpCuochi.Controls.Add(this.lblChef0);
            this.grpCuochi.Controls.Add(this.pbChef0);
            this.grpCuochi.Controls.Add(this.lblPercChef0);
            this.grpCuochi.Controls.Add(this.lblChef1);
            this.grpCuochi.Controls.Add(this.pbChef1);
            this.grpCuochi.Controls.Add(this.lblPercChef1);
            this.grpCuochi.Controls.Add(this.lblChef2);
            this.grpCuochi.Controls.Add(this.pbChef2);
            this.grpCuochi.Controls.Add(this.lblPercChef2);
            this.grpCuochi.Controls.Add(this.lblChef3);
            this.grpCuochi.Controls.Add(this.pbChef3);
            this.grpCuochi.Controls.Add(this.lblPercChef3);

            // ── Label Race Condition ─────────────────────────────────────────────
            this.lblSteps.Name      = "lblSteps";
            this.lblSteps.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblSteps.AutoSize  = false;
            this.lblSteps.Height    = 36;
            this.lblSteps.Text      = "Atteso: 0   Reale: 0";
            this.lblSteps.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSteps.ForeColor = System.Drawing.Color.Lime;
            this.lblSteps.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.lblSteps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Label Vincitore ────────────────────────────────────────────────
            this.lblWinner.Name      = "lblWinner";
            this.lblWinner.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblWinner.AutoSize  = false;
            this.lblWinner.Height    = 36;
            this.lblWinner.Text      = "";
            this.lblWinner.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWinner.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblWinner.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Label Fornelli ─────────────────────────────────────────────────
            this.lblFornelli.Name      = "lblFornelli";
            this.lblFornelli.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblFornelli.AutoSize  = false;
            this.lblFornelli.Height    = 36;
            this.lblFornelli.Text      = "Fornelli in uso: 0 / 2";
            this.lblFornelli.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFornelli.ForeColor = System.Drawing.Color.Lime;
            this.lblFornelli.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.lblFornelli.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Panel Pulsanti ───────────────────────────────────────────────────
            this.pnlPulsanti.Name      = "pnlPulsanti";
            this.pnlPulsanti.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPulsanti.Height    = 56;
            this.pnlPulsanti.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
            this.pnlPulsanti.Padding   = new System.Windows.Forms.Padding(10, 8, 10, 8);

            this.btnAvvia.Name      = "btnAvvia";
            this.btnAvvia.Text      = "▶  Avvia cucina";
            this.btnAvvia.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAvvia.ForeColor = System.Drawing.Color.White;
            this.btnAvvia.BackColor = System.Drawing.Color.FromArgb(0, 122, 60);
            this.btnAvvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvvia.Size      = new System.Drawing.Size(160, 38);
            this.btnAvvia.Location  = new System.Drawing.Point(10, 8);
            this.btnAvvia.Click    += new System.EventHandler(this.BtnAvvia_Click);

            this.btnReset.Name      = "btnReset";
            this.btnReset.Text      = "↺  Reset";
            this.btnReset.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(160, 60, 0);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Size      = new System.Drawing.Size(120, 38);
            this.btnReset.Location  = new System.Drawing.Point(180, 8);
            this.btnReset.Click    += new System.EventHandler(this.BtnReset_Click);

            this.pnlPulsanti.Controls.Add(this.btnAvvia);
            this.pnlPulsanti.Controls.Add(this.btnReset);

            // ── GroupBox Log ─────────────────────────────────────────────────────
            this.grpLog.Name      = "grpLog";
            this.grpLog.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Text      = "📜 Log attività";
            this.grpLog.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpLog.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.grpLog.Padding   = new System.Windows.Forms.Padding(6);

            this.rtbLog.Name        = "rtbLog";
            this.rtbLog.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font        = new System.Drawing.Font("Courier New", 9F);
            this.rtbLog.BackColor   = System.Drawing.Color.FromArgb(12, 12, 12);
            this.rtbLog.ForeColor   = System.Drawing.Color.Lime;
            this.rtbLog.ReadOnly    = true;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.ScrollBars  = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            this.grpLog.Controls.Add(this.rtbLog);

            // ── Form ─────────────────────────────────────────────────────────────
            // Ordine di aggiunta: Fill prima, poi Bottom, poi Top (titolo per ultimo)
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.pnlPulsanti);
            this.Controls.Add(this.lblFornelli);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblSteps);
            this.Controls.Add(this.grpCuochi);
            this.Controls.Add(this.lblTitolo);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ClientSize          = new System.Drawing.Size(740, 680);
            this.MinimumSize         = new System.Drawing.Size(760, 720);
            this.Name                = "FormMain";
            this.Text                = "🍳 ThreadKitchen";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load               += new System.EventHandler(this.FormMain_Load);

            this.grpCuochi.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.pnlPulsanti.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Dichiarazioni campi — components è già dichiarato in cima, NON va ripetuto qui
        private System.Windows.Forms.Label                lblTitolo;
        private System.Windows.Forms.GroupBox             grpCuochi;
        private System.Windows.Forms.GroupBox             grpLog;
        private System.Windows.Forms.RichTextBox          rtbLog;
        private System.Windows.Forms.Panel                pnlPulsanti;
        private System.Windows.Forms.Button               btnAvvia;
        private System.Windows.Forms.Button               btnReset;
        private System.Windows.Forms.Label                lblChef0,     lblChef1,     lblChef2,     lblChef3;
        private System.Windows.Forms.ProgressBar          pbChef0,      pbChef1,      pbChef2,      pbChef3;
        private System.Windows.Forms.Label                lblPercChef0, lblPercChef1, lblPercChef2, lblPercChef3;
        private System.Windows.Forms.Label                lblSteps;
        private System.Windows.Forms.Label                lblWinner;
        private System.Windows.Forms.Label                lblFornelli;
    }
}

