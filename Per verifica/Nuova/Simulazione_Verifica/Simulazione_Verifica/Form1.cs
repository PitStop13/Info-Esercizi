using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulazione_Verifica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * Parte 1 (1 pt):
                Realizzare una soluzione (Form) per i punti successivi; la form dovrà consentire di scegliere la    
                parte da testare mediante controlli di tipo “Button” posizionati nella sua parte inferiore; dovrà
                avere dimensioni fisse di 800x600, non sarà ridimensionabile, non dovrà consentire la
                visualizzazione a tutto schermo, dovrà invece consentire la riduzione a icona.
            */
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            /*
             * Parte 2 (1 pt)
             * Generare dinamicamente 6 bottoni e posizionarli in modo casuale nella metà inferiore della
                form (da 300 in giù); ogni bottone avrà come etichetta uno dei punti successivi (da “Parte 3” a “FAC”).
            */

            Random rng = new Random();
            string[] etichette = { "Parte 3", "Parte 4", "Parte 5", "Parte 6", "Parte 7", "FAC" };

            const int btnWidth = 80;
            const int btnHeight = 30;

            foreach (string testo in etichette)
            {
                Button nuovoBottone = new Button();
                nuovoBottone.Text = testo;
                nuovoBottone.Size = new Size(btnWidth, btnHeight);
                nuovoBottone.Name = "btn_" + testo.Replace(" ", "");
                // X: tra 0 e il bordo destro (meno la larghezza del bottone)
                // Y: tra 300 e il bordo inferiore (meno l'altezza del bottone)
                int posX = rng.Next(0, this.ClientSize.Width - btnWidth);
                int posY = rng.Next(300, this.ClientSize.Height - btnHeight);

                //Aggiungo una funzione che andrà con uno switch a gestire i click dei bottoni
                nuovoBottone.Click += GestisciClickDinamico;

                nuovoBottone.Location = new Point(posX, posY);
                this.Controls.Add(nuovoBottone);
            }

        }

        /*
         * Parte 3 (1 pt):
           Fare in modo che al click del bottone con etichetta “Parte 3” venga visualizzata una MessageBox con icona di domanda che chieda “Sei sicuro di voler uscire?” ed offra come pulsanti SÌ e NO.
           Se si preme SÌ chiudere il programma, altrimenti nulla.
        */
        private void GestisciClickDinamico(object sender, EventArgs e)
        {
            Button btnCliccato = sender as Button;
            //MessageBox.Show(btnCliccato.Name);
            switch (btnCliccato.Name)
            {
                case "btn_Parte3":
                    DialogResult risposta = MessageBox.Show("Sei sicuro di voler uscire?", "Conferma uscita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (risposta == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;

                /*Parte 4 (1 pt):
                Alla pressione del bottone con etichetta “Parte 4” dovrà essere visualizzata una dialog per
                apertura file che filtri per *.txt e per *.*. Alla chiusura della dialog (solo con OK) una
                MessageBox visualizzerà il percorso del file selezionato.
                */
                case "btn_Parte4":
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
                    openFileDialog1.FilterIndex = 1;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string percorsoFile = openFileDialog1.FileName;
                        MessageBox.Show(percorsoFile, "File Selezionato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "btn_Parte5":
                    /*
                     * Parte 5 (1 pt):
                    Alla pressione del bottone con etichetta “Parte 5” dovrà essere creato dinamicamente un
                    RichTextBox multiline che occupi tutta la parte superiore della finestra e visualizzata una dialog
                    per salvataggio file. Alla chiusura della dialog (solo con OK) aggiungere al contenuto del
                    RichTextBox una riga contenente il percorso del file impostato.
                    */
                    RichTextBox rtb = new RichTextBox();
                    rtb.Multiline = true;
                    rtb.Location = new Point(0, 0);
                    rtb.Size = new Size(this.ClientSize.Width, 300);
                    this.Controls.Add(rtb);

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string percorsoFile = saveFileDialog1.FileName;
                        rtb.AppendText("File selezionato: " + percorsoFile + Environment.NewLine);
                    }
                    break;
                case "btn_Parte6":
                    /*
                     * Parte 6 (1 pt):
                        Salvare nella cartella del programma un file denominato “salvataggio.txt” che contenga sulla
                        prima riga il vostro nome e cognome e sulla seconda riga la data del giorno (ottenuta
                        dinamicamente).
                    */
                    
                    string nomeFile = "salvataggio.txt";
                    string percorsoCompleto = Path.Combine(Application.StartupPath, nomeFile);

                    string nomeCognome = "Pietro Olivero";
                    string dataOggi = DateTime.Now.ToString("dd/MM/yyyy");
                    try
                    {
                        string[] righe = { nomeCognome, dataOggi };
                        File.WriteAllLines(percorsoCompleto, righe);

                        MessageBox.Show("File salvato correttamente in: " + percorsoCompleto);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore durante il salvataggio: " + ex.Message);
                    }
                    break;
                case "btn_Parte7":
                    /*
                     * Parte 7 (1 pt):
                       Leggere dalla cartella del programma il file denominato “salvataggio.txt” e visualizzarne il
                        contenuto all’interno di una apposita MessageBox.
                    */

                    string percorso = Path.Combine(Application.StartupPath, "salvataggio.txt");
                    FileInfo fileInfo = new FileInfo(percorso);

                    if (fileInfo.Exists)
                    {
                        string contenuto = File.ReadAllText(percorso);
                        MessageBox.Show(contenuto, "Contenuto di salvataggio.txt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Il file salvataggio.txt non è stato trovato!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case "btn_FAC":
                    /*Facoltativo (1 pt):
                    Visualizzare il contenuto del file “salvataggio.txt” in una nuova form modale (dialog) creata
                    dinamicamente e contenente un campo di testo multi-linea, anch’esso creato dinamicamente*/

                    string pathFac = Path.Combine(Application.StartupPath, "salvataggio.txt");
                    if (File.Exists(pathFac))
                    {
                        string contenuto = File.ReadAllText(pathFac);

                        // Creo la form dinamica
                        Form formDialog = new Form();
                        formDialog.Text = "Contenuto salvataggio.txt";
                        formDialog.Size = new Size(400, 300);
                        formDialog.StartPosition = FormStartPosition.CenterParent;
                        formDialog.FormBorderStyle = FormBorderStyle.FixedDialog;

                        // Creo la TextBox multiline dinamica
                        TextBox txtContenuto = new TextBox();
                        txtContenuto.Multiline = true;
                        txtContenuto.Dock = DockStyle.Fill;
                        txtContenuto.ScrollBars = ScrollBars.Vertical;
                        txtContenuto.Text = contenuto;
                        txtContenuto.ReadOnly = true;

                        formDialog.Controls.Add(txtContenuto);
                        formDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Il file salvataggio.txt non esiste!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }
    }
}
