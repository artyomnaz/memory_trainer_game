using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public partial class FormFindAPair : Form
    {
        private Level lvl;
        private readonly LevelManager _levelManager;
        private readonly PrivateFontCollection _font;
        private List<Button> Btns;
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
            Btns[1].Text = "Правила";
            Btns[2].Text = "Об игре";
            Btns[3].Text = "К играм";
            Btns[3].Click += ReturnToMenu;
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
