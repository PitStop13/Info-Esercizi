# CHEATSHEET VERIFICA C# WinForms
> Tutti i pattern pronti per il copia-incolla. Adatta solo i nomi dei controlli.

---

## USING DA METTERE SEMPRE IN CIMA

```csharp
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
```

---

## 1 — SETUP FORM (Form_Load)

```csharp
private void Form1_Load(object sender, EventArgs e)
{
    this.Text = "Titolo";
    this.Size = new Size(800, 600);
    this.FormBorderStyle = FormBorderStyle.FixedSingle; // bordo fisso, no resize
    this.MaximizeBox = false;   // no fullscreen
    this.MinimizeBox = true;    // sì icona
    this.StartPosition = FormStartPosition.CenterScreen;
}
```

---

## 2 — BOTTONI DINAMICI RANDOMIZZATI (metà inferiore)

```csharp
// Da mettere dentro Form1_Load
Random rng = new Random();
string[] etichette = { "Parte 3", "Parte 4", "Parte 5", "Parte 6", "Parte 7", "FAC" };

const int btnW = 80, btnH = 30;

foreach (string testo in etichette)
{
    Button b = new Button();
    b.Text  = testo;
    b.Size  = new Size(btnW, btnH);
    b.Name  = "btn_" + testo.Replace(" ", ""); // es. "btn_Parte3", "btn_FAC"

    // X: 0 .. larghezza form - larghezza bottone
    // Y: 300 .. altezza client - altezza bottone  (metà inferiore = sotto 300)
    b.Location = new Point(
        rng.Next(0, this.ClientSize.Width  - btnW),
        rng.Next(300, this.ClientSize.Height - btnH)
    );

    b.Click += GestisciClick; // un solo handler per tutti
    this.Controls.Add(b);
}
```

### Handler centralizzato con switch

```csharp
private void GestisciClick(object sender, EventArgs e)
{
    Button btn = sender as Button;
    if (btn == null) return;

    switch (btn.Name)
    {
        case "btn_Parte3": /* ... */ break;
        case "btn_Parte4": /* ... */ break;
        case "btn_Parte5": /* ... */ break;
        case "btn_Parte6": /* ... */ break;
        case "btn_Parte7": /* ... */ break;
        case "btn_FAC":    /* ... */ break;
    }
}
```

---

## 3 — MESSAGEBOX YES/NO → ESCI

```csharp
DialogResult r = MessageBox.Show(
    "Sei sicuro di voler uscire?",
    "Conferma uscita",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);
if (r == DialogResult.Yes)
    Application.Exit();
```

---

## 4 — OPEN FILE DIALOG → MOSTRA PERCORSO

```csharp
OpenFileDialog ofd = new OpenFileDialog();
ofd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

if (ofd.ShowDialog() == DialogResult.OK)
{
    MessageBox.Show(ofd.FileName, "File selezionato",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
}
```

---

## 5 — RICHTEXTBOX DINAMICO (metà superiore) + SAVE FILE DIALOG

```csharp
// Crea RichTextBox che occupa la metà superiore
RichTextBox rtb = new RichTextBox();
rtb.Multiline = true;
rtb.Location  = new Point(0, 0);
rtb.Size      = new Size(this.ClientSize.Width, 300);
this.Controls.Add(rtb);

// Mostra dialog salvataggio
SaveFileDialog sfd = new SaveFileDialog();
sfd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

if (sfd.ShowDialog() == DialogResult.OK)
{
    // Aggiunge il percorso scelto come riga nel RichTextBox
    rtb.AppendText(sfd.FileName + Environment.NewLine);
}
```

---

## 6 — SALVA FILE IN CARTELLA PROGRAMMA

```csharp
// Application.StartupPath = cartella dove gira l'exe (bin\Debug)
string path = Path.Combine(Application.StartupPath, "salvataggio.txt");

string[] righe = {
    "Pietro Olivero",
    DateTime.Now.ToString("dd/MM/yyyy")
};

try
{
    File.WriteAllLines(path, righe);
    MessageBox.Show("Salvato in: " + path);
}
catch (Exception ex)
{
    MessageBox.Show("Errore: " + ex.Message, "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

---

## 7 — LEGGI FILE E MOSTRA IN MESSAGEBOX

```csharp
string path = Path.Combine(Application.StartupPath, "salvataggio.txt");

if (File.Exists(path))
{
    string contenuto = File.ReadAllText(path);
    MessageBox.Show(contenuto, "Contenuto del file",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
}
else
{
    MessageBox.Show("File non trovato!", "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

---

## FAC — FORM DINAMICA MODALE con TEXTBOX MULTILINE

```csharp
string path = Path.Combine(Application.StartupPath, "salvataggio.txt");

if (File.Exists(path))
{
    string contenuto = File.ReadAllText(path);

    // 1. Crea la form
    Form f = new Form();
    f.Text            = "Visualizza file";
    f.Size            = new Size(400, 300);
    f.StartPosition   = FormStartPosition.CenterParent;
    f.FormBorderStyle = FormBorderStyle.FixedDialog;
    f.MaximizeBox     = false;
    f.MinimizeBox     = false;

    // 2. Crea TextBox multiline (usa TextBox, non RichTextBox, se vuoi ReadOnly semplice)
    TextBox txt = new TextBox();
    txt.Multiline   = true;
    txt.Dock        = DockStyle.Fill;
    txt.ScrollBars  = ScrollBars.Vertical;
    txt.ReadOnly    = true;
    txt.Text        = contenuto;

    // 3. Aggiunge e mostra come dialog (blocca la form padre)
    f.Controls.Add(txt);
    f.ShowDialog();
}
else
{
    MessageBox.Show("File non trovato!", "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

---

## EXTRA — MENU DINAMICO

```csharp
// Crea e aggiungi il MenuStrip
MenuStrip ms = new MenuStrip();
ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");

ToolStripMenuItem apriItem  = new ToolStripMenuItem("Apri");
ToolStripMenuItem salvaItem = new ToolStripMenuItem("Salva");
ToolStripMenuItem esciItem  = new ToolStripMenuItem("Esci");

apriItem.Name  = "apriItem";
salvaItem.Name = "salvaItem";
esciItem.Name  = "esciItem";

apriItem.Click  += MenuClick;
salvaItem.Click += MenuClick;
esciItem.Click  += MenuClick;

fileMenu.DropDownItems.Add(apriItem);
fileMenu.DropDownItems.Add(salvaItem);
fileMenu.DropDownItems.Add(esciItem);

ms.Items.Add(fileMenu);
this.Controls.Add(ms);
this.MainMenuStrip = ms;

// Handler
private void MenuClick(object sender, EventArgs e)
{
    ToolStripMenuItem item = sender as ToolStripMenuItem;
    if (item == null) return;
    switch (item.Name)
    {
        case "apriItem":  ApriFile();  break;
        case "salvaItem": SalvaFile(); break;
        case "esciItem":  Application.Exit(); break;
    }
}
```

---

## EXTRA — STATUSBAR CON RIGA/COLONNA

```csharp
// Nella Form_Load:
StatusStrip ss = new StatusStrip();
ToolStripStatusLabel lblInfo = new ToolStripStatusLabel("Riga: 1, Col: 1");
ss.Items.Add(lblInfo);
this.Controls.Add(ss);

// Evento sul RichTextBox:
rtbEditor.SelectionChanged += (s, e) =>
{
    int idx    = rtbEditor.GetFirstCharIndexOfCurrentLine();
    int col    = rtbEditor.SelectionStart - idx + 1;
    int riga   = rtbEditor.GetLineFromCharIndex(rtbEditor.SelectionStart) + 1;
    lblInfo.Text = $"Riga: {riga}, Col: {col}";
};
```

---

## EXTRA — APRI FILE in RichTextBox (metodo completo)

```csharp
private void ApriFile()
{
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

    if (ofd.ShowDialog() == DialogResult.OK)
    {
        try
        {
            rtbEditor.Text = File.ReadAllText(ofd.FileName);
            this.Text = Path.GetFileName(ofd.FileName) + " - Editor";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Errore apertura:\n" + ex.Message, "Errore",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

---

## EXTRA — SALVA FILE da RichTextBox (metodo completo)

```csharp
private void SalvaFile()
{
    SaveFileDialog sfd = new SaveFileDialog();
    sfd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";

    if (sfd.ShowDialog() == DialogResult.OK)
    {
        try
        {
            File.WriteAllText(sfd.FileName, rtbEditor.Text);
            this.Text = Path.GetFileName(sfd.FileName) + " - Editor";
            MessageBox.Show("Salvato!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Errore salvataggio: " + ex.Message, "Errore",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

---

## EXTRA — FORM FIGLIA "ABOUT" DINAMICA

```csharp
private void MostraAbout()
{
    Form f = new Form();
    f.Text            = "Informazioni";
    f.Size            = new Size(350, 200);
    f.FormBorderStyle = FormBorderStyle.FixedDialog;
    f.StartPosition   = FormStartPosition.CenterParent;
    f.MaximizeBox     = false;
    f.MinimizeBox     = false;

    Label lbl = new Label();
    lbl.Text      = $"Programma v1.0\nPietro Olivero\n{DateTime.Now:dd/MM/yyyy}";
    lbl.Font      = new Font("Arial", 10);
    lbl.Dock      = DockStyle.Fill;
    lbl.TextAlign = ContentAlignment.MiddleCenter;

    f.Controls.Add(lbl);
    f.ShowDialog(); // modale
}
```

---

## EXTRA — FONTDIALOG (cambia font testo selezionato)

```csharp
FontDialog fd = new FontDialog();
fd.Font = rtbEditor.SelectionFont ?? rtbEditor.Font;

if (fd.ShowDialog() == DialogResult.OK)
    rtbEditor.SelectionFont = fd.Font;
```

---

## EXTRA — COLORDIALOG (cambia colore testo selezionato)

```csharp
ColorDialog cd = new ColorDialog();
cd.Color = rtbEditor.SelectionColor;

if (cd.ShowDialog() == DialogResult.OK)
    rtbEditor.SelectionColor = cd.Color;
```

---

## EXTRA — VAI A RIGA N (form dinamica con NumericUpDown)

```csharp
Form f            = new Form();
f.Text            = "Vai a riga";
f.Size            = new Size(280, 130);
f.FormBorderStyle = FormBorderStyle.FixedDialog;
f.StartPosition   = FormStartPosition.CenterParent;
f.MaximizeBox     = false;
f.MinimizeBox     = false;

Label lbl    = new Label() { Text = "Numero riga:", Location = new Point(10, 15), AutoSize = true };
NumericUpDown num = new NumericUpDown();
num.Location = new Point(100, 12);
num.Minimum  = 1;
num.Maximum  = rtbEditor.Lines.Length > 0 ? rtbEditor.Lines.Length : 1;
num.Value    = 1;
num.Width    = 80;

Button btnOk       = new Button() { Text = "OK", Location = new Point(90, 50) };
btnOk.DialogResult = DialogResult.OK;

f.Controls.Add(lbl);
f.Controls.Add(num);
f.Controls.Add(btnOk);
f.AcceptButton = btnOk;

if (f.ShowDialog() == DialogResult.OK)
{
    int riga      = (int)num.Value - 1; // 0-based
    int charIndex = rtbEditor.GetFirstCharIndexFromLine(riga);
    rtbEditor.SelectionStart  = charIndex;
    rtbEditor.SelectionLength = 0;
    rtbEditor.ScrollToCaret();
    rtbEditor.Focus();
}
```

---



---

## EXTRA — CONTA RIGHE/PAROLE E SALVA SU FILE

```csharp
string testo = rtbEditor.Text.Trim();

int righe  = testo == "" ? 0 : rtbEditor.Lines.Length;
int parole = testo == "" ? 0 : testo.Split(
    new char[] { ' ', '\n', '\r', '\t' },
    StringSplitOptions.RemoveEmptyEntries
).Length;

string path = Path.Combine(Application.StartupPath, "salvataggio.txt");
string[] righeFile = {
    "Pietro Olivero",
    DateTime.Now.ToString("dd/MM/yyyy"),
    "Righe: "  + righe,
    "Parole: " + parole
};

File.WriteAllLines(path, righeFile);
MessageBox.Show("Righe: " + righe + "\nParole: " + parole, "Statistiche",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
```
> `rtbEditor.Lines` è un array — `.Length` = numero righe.  
> `.Split()` su whitespace con `RemoveEmptyEntries` = numero parole reale.
