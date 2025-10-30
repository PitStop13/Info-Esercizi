using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace telecomando
{
    public partial class Form1 :Form
    {
        public enum SymbolType
        {
            Channel,
            VolumeUp,
            VolumeDown,
            Mute,
            Power,
            Clear,
            Undefined
        }
        public struct BtnStruct
        {
            public char Content;
            public SymbolType Type;
            public BtnStruct(char C, SymbolType T)
            {
                Content = C; Type = T;
            }
            public override string ToString()
            {
                return Content.ToString();
            }
        }
        private BtnStruct[,] buttons =
        {
            {new BtnStruct('1',SymbolType.Channel), new BtnStruct('2',SymbolType.Channel), new BtnStruct('3',SymbolType.Channel), new BtnStruct('↑',SymbolType.VolumeUp) },
            {new BtnStruct('4',SymbolType.Channel), new BtnStruct('5',SymbolType.Channel), new BtnStruct('6',SymbolType.Channel),new BtnStruct('↓',SymbolType.VolumeDown) },
            {new BtnStruct('7', SymbolType.Channel), new BtnStruct('8', SymbolType.Channel), new BtnStruct('9', SymbolType.Channel), new BtnStruct('M', SymbolType.Mute)},
            {new BtnStruct('P',SymbolType.Power), new BtnStruct('0',SymbolType.Channel), new BtnStruct('.',SymbolType.Undefined),new BtnStruct('C',SymbolType.Clear) }

        };
        
        Label lblStatus;
        bool isON=false;
        int channel = 1;
        int volume = 0;
        bool isMuted = false;
        BtnStruct previusBTN;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(380, 380);
            this.Text = "teleocmando TV";
            this.StartPosition = FormStartPosition.CenterScreen;

            MakeStatusLabel();
            MakeButtons(4, 4);
            UpdateStatus();
        }

        private void MakeButtons(int rows, int Cols)
        {
            int w = 70, h=60;
            int x=10, y=110;
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < Cols; j++)
                {
                    Button btn=new Button();
                    btn.Width = w;btn.Height = h;
                    btn.Left = x + j * w;
                    btn.Top = y + i * h;
                    btn.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                    btn.Text = buttons[i,j].Content == '↑' ? "Vol+":
                              buttons[i, j].Content == '↓' ? "Vol−" :
                              buttons[i, j].ToString();
                    switch (buttons[i, j].Type)
                    {
                        case SymbolType.Channel: btn.BackColor = Color.LightBlue; break;
                        case SymbolType.VolumeUp:
                        case SymbolType.VolumeDown: btn.BackColor = Color.LightGreen; break;
                        case SymbolType.Mute: btn.BackColor = Color.Orange; break;
                        case SymbolType.Power: btn.BackColor = Color.IndianRed; btn.ForeColor = Color.White; break;
                        case SymbolType.Clear: btn.BackColor = Color.Gray; break;
                    }
                    btn.Tag = buttons[i,j];
                    btn.Click += Button_Click;
                    this.Controls.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            BtnStruct bs=(BtnStruct)btn.Tag;
            if (!isON && bs.Type != SymbolType.Power)
            {
                return;
            }
            switch (bs.Type)
            {
                case SymbolType.Channel:
                    if (bs.Content >= '0' && bs.Content<='9')
                    {
                        channel=bs.Content - '0';                        
                    }
                    break;
                case SymbolType.VolumeUp:
                    if (!isMuted && volume<30)
                    {
                        volume++;
                    }
                    break;
                case SymbolType.VolumeDown:
                    if (!isMuted && volume>0)
                    {
                        volume--;
                    }
                    break;
                case SymbolType.Mute:
                    isMuted = !isMuted;
                    break;
                case SymbolType.Power:
                case SymbolType.Clear:
                    isON = !isON;
                  if(!isON)
                    {
                        channel = 1;
                        volume = 0;
                        isMuted=false;
                    }
                  break;
            }
            UpdateStatus();
            previusBTN = bs;

        }

        private void UpdateStatus()
        {
            if(!isON)
            {
                lblStatus.Text = "tv spenta";
                lblStatus.ForeColor = Color.Red;
                return;
            }
            string mute = isMuted ? "[muto]" : $"volume:{volume}";
            lblStatus.Text = $"channel {channel} {mute}\n accesa";
            lblStatus.ForeColor = Color.Green;
        }
        private void MakeStatusLabel()
        {
            lblStatus=new Label();
            lblStatus.Font = new Font("Consolas", 14);
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Location = new Point(10, 10);
            lblStatus.Size = new Size(340, 80);
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Padding = new Padding(10);
            this.Controls.Add(lblStatus);
        }
    }
}
