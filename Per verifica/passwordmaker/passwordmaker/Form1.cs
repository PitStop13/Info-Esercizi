using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordmaker
{
    public partial class Form1 : Form
    {
        public enum SymbolType
        {
            Letter,
            Number,
            Symbol,
            Clear,
            Undefined
        }
        public struct BtnStruct
        {
            public char Content;
            public SymbolType Type;
            public BtnStruct(char content,SymbolType type)
            {
                Content = content;
                Type = type;
            }
            public override string ToString()
            {
                return Content.ToString();
            }
        }
        private BtnStruct[,] buttons =
{
    // Riga 0
    { new BtnStruct('A', SymbolType.Letter), new BtnStruct('B', SymbolType.Letter), new BtnStruct('C', SymbolType.Letter),
      new BtnStruct('1', SymbolType.Number), new BtnStruct('2', SymbolType.Number), new BtnStruct('3', SymbolType.Number),
      new BtnStruct('!', SymbolType.Symbol), new BtnStruct('@', SymbolType.Symbol), new BtnStruct('#', SymbolType.Symbol) },

    // Riga 1
    { new BtnStruct('D', SymbolType.Letter), new BtnStruct('E', SymbolType.Letter), new BtnStruct('F', SymbolType.Letter),
      new BtnStruct('4', SymbolType.Number), new BtnStruct('5', SymbolType.Number), new BtnStruct('6', SymbolType.Number),
      new BtnStruct('$', SymbolType.Symbol), new BtnStruct('%', SymbolType.Symbol), new BtnStruct('^', SymbolType.Symbol) },

    // Riga 2
    { new BtnStruct('G', SymbolType.Letter), new BtnStruct('H', SymbolType.Letter), new BtnStruct('I', SymbolType.Letter),
      new BtnStruct('7', SymbolType.Number), new BtnStruct('8', SymbolType.Number), new BtnStruct('9', SymbolType.Number),
      new BtnStruct('&', SymbolType.Symbol), new BtnStruct('*', SymbolType.Symbol), new BtnStruct('(', SymbolType.Symbol) },

    // Riga 3
    { new BtnStruct('C', SymbolType.Clear),  new BtnStruct('0', SymbolType.Number), new BtnStruct('.', SymbolType.Symbol),
      new BtnStruct('+', SymbolType.Symbol), new BtnStruct('-', SymbolType.Symbol), new BtnStruct('=', SymbolType.Symbol),
      new BtnStruct('<', SymbolType.Symbol), new BtnStruct('>', SymbolType.Symbol), new BtnStruct('?', SymbolType.Symbol) }
};
        Label lblPassword;
        BtnStruct previousBtn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeButtonLabel();
            MakeButtons(4,9);
        }

        private void MakeButtons(int rows, int cols)
        {
            int btnWith = 55;
            int btnHeight = 55;
            int stratX = 10;
            int stratY = 90;
            for (int i = 0; i < rows; i++)
            {
                for(int j=0;j<cols;j++)
                {
                    Button btn=new Button();
                    btn.Width = btnWith;
                    btn.Height = btnHeight;
                    btn.Left = stratX + i * btnWith;
                    btn.Top = stratY + j * btnWith;
                    btn.Font= new Font("Segoe UI",14,FontStyle.Bold);
                    btn.Text=buttons[i,j].ToString();
                    switch (buttons[i, j].Type)
                    {
                        case SymbolType.Letter: btn.BackColor = Color.White; break;
                        case SymbolType.Number: btn.BackColor = Color.LightBlue; break ;
                        case SymbolType.Symbol: btn.BackColor = Color.LightGreen;break;
                        case SymbolType.Clear: btn.BackColor = Color.IndianRed;break;
                    }
                    btn.Tag = buttons[i, j];
                    btn.Click += Button_Click;
                    this.Controls.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn=(Button)sender;
            BtnStruct bs=(BtnStruct)btn.Tag;
            switch(bs.Type)
            {
                case SymbolType.Letter:
                case SymbolType.Number:
                case SymbolType.Symbol:
                    lblPassword.Text += bs.Content;
                        break;
                case SymbolType.Clear:
                    lblPassword.Text = "";
                    break;
            }
            previousBtn = bs;

        }

        private void MakeButtonLabel()
        {
            lblPassword = new Label();
            lblPassword.Font=new Font("Consolas",18,FontStyle.Bold);
            lblPassword.TextAlign=ContentAlignment.MiddleLeft;
            lblPassword.AutoSize = false;
            lblPassword.Location = new Point(10, 10);
            lblPassword.Size = new Size(this.ClientSize.Width - 20, 60);
            lblPassword.BorderStyle = BorderStyle.FixedSingle;
            lblPassword.Padding=new Padding(15);
            lblPassword.Text = "";
            this.Controls.Add(lblPassword);
        }
    }
}
