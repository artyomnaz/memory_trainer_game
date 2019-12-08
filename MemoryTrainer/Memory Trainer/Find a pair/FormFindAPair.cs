using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public partial class FormFindAPair : Form
    {
        private Level lvl;
        private readonly LevelManager _levelManager;
        private Info _info;
        private readonly PrivateFontCollection _font;
        private List<Button> Btns;
        private string _infoText;
        private string _rulesText;
        private Timer _timer;
        private Label _exeptMsgLbl;
        private int _time;
        public FormFindAPair()
        {
            InitializeComponent();
            _font = new PrivateFontCollection();
            LoadFont();
            BackgroundPB.Parent = this;
            _levelManager = new LevelManager(BackgroundPB, _font);
            Btns = new List<Button>();
            for (int i = 0; i < 4; i++)
            {
                var btn = new Button
                {
                    Visible = true,
                    Parent = BackgroundPB,
                    Font = new Font(_font.Families[0], 10),
                    Width = 150,
                    Height = 50,
                    TabStop = false,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Location = new Point(848, 440 + 60 * i)
                };
                Btns.Add(btn);
            }
            Btns[0].Text = "Загрузить игру";
            Btns[0].Click += LoadGame;
            Btns[1].Text = "Правила";
            Btns[1].Click += OpenRules;
            Btns[2].Text = "Об игре";
            Btns[2].Click += OpenInfo;
            Btns[3].Text = "К играм";
            Btns[3].Click += ReturnToMenu;
            _infoText = "";
            _rulesText = "";
            _time = 0;
            _timer = new Timer
            {
                Interval = 800,
                Enabled = false
            };
            _timer.Tick += TimerTick;
            _exeptMsgLbl = new Label
            {
                Visible = false,
                Font = new Font(_font.Families[0], 20),
                Parent = BackgroundPB,
                AutoSize = true,
                BackColor = Color.CornflowerBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = ""
            };
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_time++ != 1) return;
            _timer.Enabled = false;
            _exeptMsgLbl.Visible = false;
            _time = 0;
            _levelManager.Enabled = true;
            ChangeEnabled(true);
        }

        private void LoadGame(object sender, EventArgs e)
        {
            try
            {
                _levelManager.LoadGame();
            }
            catch (Exception exception)
            {
                BackgroundPB.Visible = true;
                _levelManager.Enabled = false;
                ChangeEnabled(false);
                _exeptMsgLbl.Text = exception.Message;
                _exeptMsgLbl.Location = new Point((1028 - _exeptMsgLbl.Width) / 2, 550);
                _exeptMsgLbl.Visible = true;
                _timer.Enabled = true;
                
            }
            
        }
        private void ChangeEnabled(bool state)
        {
            foreach (var button in Btns)
            {
                button.Enabled = state;
            }
        }
        private void OpenRules(object sender, EventArgs e)
        {
            if (_rulesText == "")
            {
                _rulesText = Properties.Resources.Rules;
            }
            _info = new Info(BackgroundPB, _rulesText, _font);
            BackgroundPB.Visible = false;
        }

        private void OpenInfo(object sender, EventArgs e)
        {
            if (_infoText == "")
            {
                _infoText = Properties.Resources.Info;
            }
            _info = new Info(BackgroundPB, _infoText, _font);
            BackgroundPB.Visible = false;
        }

        private void ReturnToMenu(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void FormFindAPair_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private void LoadFont()
        {
            byte[] fontData = Properties.Resources.fonto;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            _font.AddMemoryFont(fontPtr, Properties.Resources.fonto.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.fonto.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
        }
    }
}
