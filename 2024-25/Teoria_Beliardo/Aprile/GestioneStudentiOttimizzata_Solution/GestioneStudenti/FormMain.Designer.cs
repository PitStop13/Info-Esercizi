namespace GestioneStudenti
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
            this.DgvStudenti = new System.Windows.Forms.DataGridView();
            this.DgvValutazioni = new System.Windows.Forms.DataGridView();
            this.btnStudSenzaVoti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cmbClasse = new System.Windows.Forms.ComboBox();
            this.btnInserisciStudente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.nupVoto = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbLaboratorio = new System.Windows.Forms.RadioButton();
            this.rdbOrale = new System.Windows.Forms.RadioButton();
            this.rdbScritto = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMatricole = new System.Windows.Forms.ComboBox();
            this.btnRicStudMat = new System.Windows.Forms.Button();
            this.btnRicStudCongNom = new System.Windows.Forms.Button();
            this.btnOrdinaStudNominativo = new System.Windows.Forms.Button();
            this.btnContaStudClasse = new System.Windows.Forms.Button();
            this.btnContaVotiStudClasse = new System.Windows.Forms.Button();
            this.btnInserisciVoto = new System.Windows.Forms.Button();
            this.btnMediaPerMateria = new System.Windows.Forms.Button();
            this.btnContaVotiPerTipoPerStudente = new System.Windows.Forms.Button();
            this.btnNumVotiPerStudente = new System.Windows.Forms.Button();
            this.btnCercaStudenteMediaMaggiore = new System.Windows.Forms.Button();
            this.btnMaterieSenzaVoti = new System.Windows.Forms.Button();
            this.btnRisClasseMigliorePeggiore = new System.Windows.Forms.Button();
            this.btnDgvStudentiInsufficienti = new System.Windows.Forms.Button();
            this.btnDgvStudentiClasse = new System.Windows.Forms.Button();
            this.btnDgvValutazioniOrdinateMateria = new System.Windows.Forms.Button();
            this.btnDgvStudentiClasseMedie = new System.Windows.Forms.Button();
            this.DgvInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStudenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvValutazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupVoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvStudenti
            // 
            this.DgvStudenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStudenti.Location = new System.Drawing.Point(3, 4);
            this.DgvStudenti.Margin = new System.Windows.Forms.Padding(4);
            this.DgvStudenti.Name = "DgvStudenti";
            this.DgvStudenti.RowHeadersWidth = 51;
            this.DgvStudenti.Size = new System.Drawing.Size(560, 204);
            this.DgvStudenti.TabIndex = 0;
            // 
            // DgvValutazioni
            // 
            this.DgvValutazioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvValutazioni.Location = new System.Drawing.Point(587, 4);
            this.DgvValutazioni.Margin = new System.Windows.Forms.Padding(4);
            this.DgvValutazioni.Name = "DgvValutazioni";
            this.DgvValutazioni.RowHeadersWidth = 51;
            this.DgvValutazioni.Size = new System.Drawing.Size(560, 204);
            this.DgvValutazioni.TabIndex = 1;
            // 
            // btnStudSenzaVoti
            // 
            this.btnStudSenzaVoti.Location = new System.Drawing.Point(1165, 4);
            this.btnStudSenzaVoti.Margin = new System.Windows.Forms.Padding(4);
            this.btnStudSenzaVoti.Name = "btnStudSenzaVoti";
            this.btnStudSenzaVoti.Size = new System.Drawing.Size(324, 41);
            this.btnStudSenzaVoti.TabIndex = 2;
            this.btnStudSenzaVoti.Text = "STUDENTI SENZA VOTI";
            this.btnStudSenzaVoti.UseVisualStyleBackColor = true;
            this.btnStudSenzaVoti.Click += new System.EventHandler(this.btnStudSenzaVoti_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "COGNOME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 257);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "NOME:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 299);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "CLASSE:";
            // 
            // txtCognome
            // 
            this.txtCognome.Location = new System.Drawing.Point(120, 216);
            this.txtCognome.Margin = new System.Windows.Forms.Padding(4);
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(217, 22);
            this.txtCognome.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(120, 255);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(217, 22);
            this.txtNome.TabIndex = 7;
            // 
            // cmbClasse
            // 
            this.cmbClasse.FormattingEnabled = true;
            this.cmbClasse.Location = new System.Drawing.Point(120, 294);
            this.cmbClasse.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClasse.Name = "cmbClasse";
            this.cmbClasse.Size = new System.Drawing.Size(217, 24);
            this.cmbClasse.TabIndex = 8;
            // 
            // btnInserisciStudente
            // 
            this.btnInserisciStudente.Location = new System.Drawing.Point(6, 329);
            this.btnInserisciStudente.Margin = new System.Windows.Forms.Padding(4);
            this.btnInserisciStudente.Name = "btnInserisciStudente";
            this.btnInserisciStudente.Size = new System.Drawing.Size(333, 41);
            this.btnInserisciStudente.TabIndex = 9;
            this.btnInserisciStudente.Text = "INSERISCI STUDENTE";
            this.btnInserisciStudente.UseVisualStyleBackColor = true;
            this.btnInserisciStudente.Click += new System.EventHandler(this.btnInserisciStudente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "VOTO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(588, 214);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "MATERIA:";
            // 
            // cmbMateria
            // 
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Items.AddRange(new object[] {
            "Italiano",
            "Matematica",
            "Storia",
            "Informatica",
            "Sistemi",
            "Inglese",
            "TPSIT",
            "Telecomunicazioni",
            "Motoria"});
            this.cmbMateria.Location = new System.Drawing.Point(703, 214);
            this.cmbMateria.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(217, 24);
            this.cmbMateria.TabIndex = 15;
            // 
            // nupVoto
            // 
            this.nupVoto.Location = new System.Drawing.Point(703, 255);
            this.nupVoto.Margin = new System.Windows.Forms.Padding(4);
            this.nupVoto.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupVoto.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupVoto.Name = "nupVoto";
            this.nupVoto.Size = new System.Drawing.Size(219, 22);
            this.nupVoto.TabIndex = 16;
            this.nupVoto.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbLaboratorio);
            this.groupBox1.Controls.Add(this.rdbOrale);
            this.groupBox1.Controls.Add(this.rdbScritto);
            this.groupBox1.Location = new System.Drawing.Point(592, 292);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(329, 132);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO";
            // 
            // rdbLaboratorio
            // 
            this.rdbLaboratorio.AutoSize = true;
            this.rdbLaboratorio.Location = new System.Drawing.Point(75, 86);
            this.rdbLaboratorio.Margin = new System.Windows.Forms.Padding(4);
            this.rdbLaboratorio.Name = "rdbLaboratorio";
            this.rdbLaboratorio.Size = new System.Drawing.Size(124, 20);
            this.rdbLaboratorio.TabIndex = 2;
            this.rdbLaboratorio.TabStop = true;
            this.rdbLaboratorio.Text = "LABORATORIO";
            this.rdbLaboratorio.UseVisualStyleBackColor = true;
            // 
            // rdbOrale
            // 
            this.rdbOrale.AutoSize = true;
            this.rdbOrale.Location = new System.Drawing.Point(75, 58);
            this.rdbOrale.Margin = new System.Windows.Forms.Padding(4);
            this.rdbOrale.Name = "rdbOrale";
            this.rdbOrale.Size = new System.Drawing.Size(73, 20);
            this.rdbOrale.TabIndex = 1;
            this.rdbOrale.TabStop = true;
            this.rdbOrale.Text = "ORALE";
            this.rdbOrale.UseVisualStyleBackColor = true;
            // 
            // rdbScritto
            // 
            this.rdbScritto.AutoSize = true;
            this.rdbScritto.Location = new System.Drawing.Point(75, 30);
            this.rdbScritto.Margin = new System.Windows.Forms.Padding(4);
            this.rdbScritto.Name = "rdbScritto";
            this.rdbScritto.Size = new System.Drawing.Size(87, 20);
            this.rdbScritto.TabIndex = 0;
            this.rdbScritto.TabStop = true;
            this.rdbScritto.Text = "SCRITTO";
            this.rdbScritto.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(588, 436);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "MATRICOLA:";
            // 
            // cmbMatricole
            // 
            this.cmbMatricole.FormattingEnabled = true;
            this.cmbMatricole.Location = new System.Drawing.Point(703, 431);
            this.cmbMatricole.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMatricole.Name = "cmbMatricole";
            this.cmbMatricole.Size = new System.Drawing.Size(217, 24);
            this.cmbMatricole.TabIndex = 19;
            // 
            // btnRicStudMat
            // 
            this.btnRicStudMat.Location = new System.Drawing.Point(6, 377);
            this.btnRicStudMat.Margin = new System.Windows.Forms.Padding(4);
            this.btnRicStudMat.Name = "btnRicStudMat";
            this.btnRicStudMat.Size = new System.Drawing.Size(333, 46);
            this.btnRicStudMat.TabIndex = 20;
            this.btnRicStudMat.Text = "RICERCA STUDENTE IN BASE ALLA MATRICOLA";
            this.btnRicStudMat.UseVisualStyleBackColor = true;
            this.btnRicStudMat.Click += new System.EventHandler(this.btnRicStudMat_Click);
            // 
            // btnRicStudCongNom
            // 
            this.btnRicStudCongNom.Location = new System.Drawing.Point(6, 430);
            this.btnRicStudCongNom.Margin = new System.Windows.Forms.Padding(4);
            this.btnRicStudCongNom.Name = "btnRicStudCongNom";
            this.btnRicStudCongNom.Size = new System.Drawing.Size(333, 46);
            this.btnRicStudCongNom.TabIndex = 21;
            this.btnRicStudCongNom.Text = "RICERCA STUDENTE IN BASE A COGNOME E NOME";
            this.btnRicStudCongNom.UseVisualStyleBackColor = true;
            this.btnRicStudCongNom.Click += new System.EventHandler(this.btnRicStudCongNom_Click);
            // 
            // btnOrdinaStudNominativo
            // 
            this.btnOrdinaStudNominativo.Location = new System.Drawing.Point(6, 481);
            this.btnOrdinaStudNominativo.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrdinaStudNominativo.Name = "btnOrdinaStudNominativo";
            this.btnOrdinaStudNominativo.Size = new System.Drawing.Size(333, 46);
            this.btnOrdinaStudNominativo.TabIndex = 22;
            this.btnOrdinaStudNominativo.Text = "ORDINA STUDENTE IN BASE AL NOMINATIVO";
            this.btnOrdinaStudNominativo.UseVisualStyleBackColor = true;
            this.btnOrdinaStudNominativo.Click += new System.EventHandler(this.btnOrdinaStudNominativo_Click);
            // 
            // btnContaStudClasse
            // 
            this.btnContaStudClasse.Location = new System.Drawing.Point(6, 536);
            this.btnContaStudClasse.Margin = new System.Windows.Forms.Padding(4);
            this.btnContaStudClasse.Name = "btnContaStudClasse";
            this.btnContaStudClasse.Size = new System.Drawing.Size(333, 46);
            this.btnContaStudClasse.TabIndex = 23;
            this.btnContaStudClasse.Text = "CONTA NUMERO STUDENTI IN CLASSE";
            this.btnContaStudClasse.UseVisualStyleBackColor = true;
            this.btnContaStudClasse.Click += new System.EventHandler(this.btnContaStudClasse_Click);
            // 
            // btnContaVotiStudClasse
            // 
            this.btnContaVotiStudClasse.Location = new System.Drawing.Point(6, 589);
            this.btnContaVotiStudClasse.Margin = new System.Windows.Forms.Padding(4);
            this.btnContaVotiStudClasse.Name = "btnContaVotiStudClasse";
            this.btnContaVotiStudClasse.Size = new System.Drawing.Size(333, 46);
            this.btnContaVotiStudClasse.TabIndex = 24;
            this.btnContaVotiStudClasse.Text = "CONTA NUMERO DI VOTI DI STUDENTI CLASSE";
            this.btnContaVotiStudClasse.UseVisualStyleBackColor = true;
            this.btnContaVotiStudClasse.Click += new System.EventHandler(this.btnContaVotiStudClasse_Click);
            // 
            // btnInserisciVoto
            // 
            this.btnInserisciVoto.Location = new System.Drawing.Point(588, 465);
            this.btnInserisciVoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnInserisciVoto.Name = "btnInserisciVoto";
            this.btnInserisciVoto.Size = new System.Drawing.Size(333, 41);
            this.btnInserisciVoto.TabIndex = 25;
            this.btnInserisciVoto.Text = "INSERISCI VOTO";
            this.btnInserisciVoto.UseVisualStyleBackColor = true;
            this.btnInserisciVoto.Click += new System.EventHandler(this.btnInserisciVoto_Click);
            // 
            // btnMediaPerMateria
            // 
            this.btnMediaPerMateria.Location = new System.Drawing.Point(588, 513);
            this.btnMediaPerMateria.Margin = new System.Windows.Forms.Padding(4);
            this.btnMediaPerMateria.Name = "btnMediaPerMateria";
            this.btnMediaPerMateria.Size = new System.Drawing.Size(333, 46);
            this.btnMediaPerMateria.TabIndex = 26;
            this.btnMediaPerMateria.Text = "CALCOLA MEDIA VOTI PER MATERIA SELEZIONATA";
            this.btnMediaPerMateria.UseVisualStyleBackColor = true;
            this.btnMediaPerMateria.Click += new System.EventHandler(this.btnMediaPerMateria_Click);
            // 
            // btnContaVotiPerTipoPerStudente
            // 
            this.btnContaVotiPerTipoPerStudente.Location = new System.Drawing.Point(588, 566);
            this.btnContaVotiPerTipoPerStudente.Margin = new System.Windows.Forms.Padding(4);
            this.btnContaVotiPerTipoPerStudente.Name = "btnContaVotiPerTipoPerStudente";
            this.btnContaVotiPerTipoPerStudente.Size = new System.Drawing.Size(333, 46);
            this.btnContaVotiPerTipoPerStudente.TabIndex = 27;
            this.btnContaVotiPerTipoPerStudente.Text = "CONTA NUMERO VOTI PER TIPO SELEZIONATO CON NOMINATIVO IN INPUT";
            this.btnContaVotiPerTipoPerStudente.UseVisualStyleBackColor = true;
            this.btnContaVotiPerTipoPerStudente.Click += new System.EventHandler(this.btnContaVotiPerTipoPerStudente_Click);
            // 
            // btnNumVotiPerStudente
            // 
            this.btnNumVotiPerStudente.Location = new System.Drawing.Point(587, 619);
            this.btnNumVotiPerStudente.Margin = new System.Windows.Forms.Padding(4);
            this.btnNumVotiPerStudente.Name = "btnNumVotiPerStudente";
            this.btnNumVotiPerStudente.Size = new System.Drawing.Size(333, 46);
            this.btnNumVotiPerStudente.TabIndex = 28;
            this.btnNumVotiPerStudente.Text = "CONTARE IL NUMERO DI VOTI PER CIASCUN STUDENTE";
            this.btnNumVotiPerStudente.UseVisualStyleBackColor = true;
            this.btnNumVotiPerStudente.Click += new System.EventHandler(this.btnNumVotiPerStudente_Click);
            // 
            // btnCercaStudenteMediaMaggiore
            // 
            this.btnCercaStudenteMediaMaggiore.Location = new System.Drawing.Point(592, 673);
            this.btnCercaStudenteMediaMaggiore.Margin = new System.Windows.Forms.Padding(4);
            this.btnCercaStudenteMediaMaggiore.Name = "btnCercaStudenteMediaMaggiore";
            this.btnCercaStudenteMediaMaggiore.Size = new System.Drawing.Size(333, 46);
            this.btnCercaStudenteMediaMaggiore.TabIndex = 29;
            this.btnCercaStudenteMediaMaggiore.Text = "CERCA STUDENTE MEDIA MAGGIORE";
            this.btnCercaStudenteMediaMaggiore.UseVisualStyleBackColor = true;
            this.btnCercaStudenteMediaMaggiore.Click += new System.EventHandler(this.btnCercaStudenteMediaMaggiore_Click);
            // 
            // btnMaterieSenzaVoti
            // 
            this.btnMaterieSenzaVoti.Location = new System.Drawing.Point(1165, 52);
            this.btnMaterieSenzaVoti.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaterieSenzaVoti.Name = "btnMaterieSenzaVoti";
            this.btnMaterieSenzaVoti.Size = new System.Drawing.Size(324, 41);
            this.btnMaterieSenzaVoti.TabIndex = 30;
            this.btnMaterieSenzaVoti.Text = "MATERIE SENZA VOTI";
            this.btnMaterieSenzaVoti.UseVisualStyleBackColor = true;
            this.btnMaterieSenzaVoti.Click += new System.EventHandler(this.btnMaterieSenzaVoti_Click);
            // 
            // btnRisClasseMigliorePeggiore
            // 
            this.btnRisClasseMigliorePeggiore.Location = new System.Drawing.Point(1165, 100);
            this.btnRisClasseMigliorePeggiore.Margin = new System.Windows.Forms.Padding(4);
            this.btnRisClasseMigliorePeggiore.Name = "btnRisClasseMigliorePeggiore";
            this.btnRisClasseMigliorePeggiore.Size = new System.Drawing.Size(324, 46);
            this.btnRisClasseMigliorePeggiore.TabIndex = 31;
            this.btnRisClasseMigliorePeggiore.Text = "CERCARE LA CLASSE MIGLIORE E PEGGIORE (media voti) ";
            this.btnRisClasseMigliorePeggiore.UseVisualStyleBackColor = true;
            this.btnRisClasseMigliorePeggiore.Click += new System.EventHandler(this.btnRisClasseMigliorePeggiore_Click);
            // 
            // btnDgvStudentiInsufficienti
            // 
            this.btnDgvStudentiInsufficienti.Location = new System.Drawing.Point(1165, 153);
            this.btnDgvStudentiInsufficienti.Margin = new System.Windows.Forms.Padding(4);
            this.btnDgvStudentiInsufficienti.Name = "btnDgvStudentiInsufficienti";
            this.btnDgvStudentiInsufficienti.Size = new System.Drawing.Size(324, 46);
            this.btnDgvStudentiInsufficienti.TabIndex = 32;
            this.btnDgvStudentiInsufficienti.Text = "CARICARE IN UNA NUOVA DGV GLI STUDENTI INSUFFICIENTI (media voti) ";
            this.btnDgvStudentiInsufficienti.UseVisualStyleBackColor = true;
            this.btnDgvStudentiInsufficienti.Click += new System.EventHandler(this.btnDgvStudentiInsufficienti_Click);
            // 
            // btnDgvStudentiClasse
            // 
            this.btnDgvStudentiClasse.Location = new System.Drawing.Point(1165, 206);
            this.btnDgvStudentiClasse.Margin = new System.Windows.Forms.Padding(4);
            this.btnDgvStudentiClasse.Name = "btnDgvStudentiClasse";
            this.btnDgvStudentiClasse.Size = new System.Drawing.Size(324, 46);
            this.btnDgvStudentiClasse.TabIndex = 33;
            this.btnDgvStudentiClasse.Text = "CARICARE IN UNA NUOVA DGV GLI STUDENTI DI UNA CLASSE (via combo)";
            this.btnDgvStudentiClasse.UseVisualStyleBackColor = true;
            this.btnDgvStudentiClasse.Click += new System.EventHandler(this.btnDgvStudentiClasse_Click);
            // 
            // btnDgvValutazioniOrdinateMateria
            // 
            this.btnDgvValutazioniOrdinateMateria.Location = new System.Drawing.Point(1165, 258);
            this.btnDgvValutazioniOrdinateMateria.Margin = new System.Windows.Forms.Padding(4);
            this.btnDgvValutazioniOrdinateMateria.Name = "btnDgvValutazioniOrdinateMateria";
            this.btnDgvValutazioniOrdinateMateria.Size = new System.Drawing.Size(324, 63);
            this.btnDgvValutazioniOrdinateMateria.TabIndex = 34;
            this.btnDgvValutazioniOrdinateMateria.Text = "CARICARE IN UNA NUOVA DGV LE VALUTAZIONI DI UNA MATERIA ORDINATI IN BASE AL VOTO " +
    "(via combo) ";
            this.btnDgvValutazioniOrdinateMateria.UseVisualStyleBackColor = true;
            this.btnDgvValutazioniOrdinateMateria.Click += new System.EventHandler(this.btnDgvValutazioniOrdinateMateria_Click);
            // 
            // btnDgvStudentiClasseMedie
            // 
            this.btnDgvStudentiClasseMedie.Location = new System.Drawing.Point(1165, 329);
            this.btnDgvStudentiClasseMedie.Margin = new System.Windows.Forms.Padding(4);
            this.btnDgvStudentiClasseMedie.Name = "btnDgvStudentiClasseMedie";
            this.btnDgvStudentiClasseMedie.Size = new System.Drawing.Size(324, 63);
            this.btnDgvStudentiClasseMedie.TabIndex = 36;
            this.btnDgvStudentiClasseMedie.Text = "CARICARE IN UNA NUOVA DGV GLI STUDENTI DI UNA CLASSE (via combo) CON LE LORO MEDI" +
    "E VOTI";
            this.btnDgvStudentiClasseMedie.UseVisualStyleBackColor = true;
            this.btnDgvStudentiClasseMedie.Click += new System.EventHandler(this.btnDgvStudentiClasseMedie_Click);
            // 
            // DgvInfo
            // 
            this.DgvInfo.ColumnHeadersHeight = 20;
            this.DgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvInfo.Location = new System.Drawing.Point(952, 400);
            this.DgvInfo.Margin = new System.Windows.Forms.Padding(4);
            this.DgvInfo.Name = "DgvInfo";
            this.DgvInfo.RowHeadersWidth = 51;
            this.DgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvInfo.Size = new System.Drawing.Size(537, 204);
            this.DgvInfo.TabIndex = 37;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 734);
            this.Controls.Add(this.DgvInfo);
            this.Controls.Add(this.btnDgvStudentiClasseMedie);
            this.Controls.Add(this.btnDgvValutazioniOrdinateMateria);
            this.Controls.Add(this.btnDgvStudentiClasse);
            this.Controls.Add(this.btnDgvStudentiInsufficienti);
            this.Controls.Add(this.btnRisClasseMigliorePeggiore);
            this.Controls.Add(this.btnMaterieSenzaVoti);
            this.Controls.Add(this.btnCercaStudenteMediaMaggiore);
            this.Controls.Add(this.btnNumVotiPerStudente);
            this.Controls.Add(this.btnContaVotiPerTipoPerStudente);
            this.Controls.Add(this.btnMediaPerMateria);
            this.Controls.Add(this.btnInserisciVoto);
            this.Controls.Add(this.btnContaVotiStudClasse);
            this.Controls.Add(this.btnContaStudClasse);
            this.Controls.Add(this.btnOrdinaStudNominativo);
            this.Controls.Add(this.btnRicStudCongNom);
            this.Controls.Add(this.btnRicStudMat);
            this.Controls.Add(this.cmbMatricole);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nupVoto);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnInserisciStudente);
            this.Controls.Add(this.cmbClasse);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCognome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStudSenzaVoti);
            this.Controls.Add(this.DgvValutazioni);
            this.Controls.Add(this.DgvStudenti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Gestione studenti";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStudenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvValutazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupVoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvStudenti;
        private System.Windows.Forms.DataGridView DgvValutazioni;
        private System.Windows.Forms.Button btnStudSenzaVoti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cmbClasse;
        private System.Windows.Forms.Button btnInserisciStudente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.NumericUpDown nupVoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbLaboratorio;
        private System.Windows.Forms.RadioButton rdbOrale;
        private System.Windows.Forms.RadioButton rdbScritto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMatricole;
        private System.Windows.Forms.Button btnRicStudMat;
        private System.Windows.Forms.Button btnRicStudCongNom;
        private System.Windows.Forms.Button btnOrdinaStudNominativo;
        private System.Windows.Forms.Button btnContaStudClasse;
        private System.Windows.Forms.Button btnContaVotiStudClasse;
        private System.Windows.Forms.Button btnInserisciVoto;
        private System.Windows.Forms.Button btnMediaPerMateria;
        private System.Windows.Forms.Button btnContaVotiPerTipoPerStudente;
        private System.Windows.Forms.Button btnNumVotiPerStudente;
        private System.Windows.Forms.Button btnCercaStudenteMediaMaggiore;
        private System.Windows.Forms.Button btnMaterieSenzaVoti;
        private System.Windows.Forms.Button btnRisClasseMigliorePeggiore;
        private System.Windows.Forms.Button btnDgvStudentiInsufficienti;
        private System.Windows.Forms.Button btnDgvStudentiClasse;
        private System.Windows.Forms.Button btnDgvValutazioniOrdinateMateria;
        private System.Windows.Forms.Button btnDgvStudentiClasseMedie;
        private System.Windows.Forms.DataGridView DgvInfo;
    }
}

