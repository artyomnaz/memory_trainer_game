using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System;

namespace Memory_Trainer
{
    public partial class FormLostWord : Form, IGameInterface
    {
        public int timerValue = 0;
        public bool setColor = true;
        public SmoothLabel label;
        public string[] words;
        PrivateFontCollection private_fonts = new PrivateFontCollection();

        private void LoadFont()
        {

            using (MemoryStream fontStream = new MemoryStream(Resource1.Montserrat_ExtraBold))
            {
                System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                private_fonts.AddMemoryFont(data, (int)fontStream.Length);
                fontStream.Close();
                Marshal.FreeCoTaskMem(data);
            }

        }

        public FormLostWord()
        {
            InitializeComponent();
            LoadFont();
        }

        public void DrawField()
        {
            throw new System.NotImplementedException();
        }

        public bool IsFinish()
        {
            throw new System.NotImplementedException();
        }

        public void OpenGame()
        {
            //throw new System.NotImplementedException();
            label1.Text = "OpenGame";

            SmoothLabel label2 = new SmoothLabel
            {
                BackColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 20F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = words[0],
                Width = 300,
                Height = 100,
                ForeColor = Color.White,
                Left = 100,
                Top = 100,
            };
            label2.MouseEnter += ChangeBackMouseEnter;
            label2.MouseLeave += ChangeBackMouseLeave;
            Controls.Add(label2);

        }

        public void SaveGame()
        {
            throw new System.NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new System.NotImplementedException();
        }

        public void ShowRules()
        {
            throw new System.NotImplementedException();
        }

        private void ChangeBackMouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.Blue;
        }

        private void ChangeBackMouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.Red;
        }

        private void TimerIntro_Tick(object sender, System.EventArgs e)
        {
            timerValue++;
            BackColor = setColor ? Color.FromArgb(145, 189, 58) : Color.FromArgb(250, 66, 82);
            setColor = !setColor;

            if (timerValue == 5)
            {
                timerIntro.Enabled = false;
                timerValue = 0;
                label.Hide();
                OpenGame();
            }
        }
        
        private void FormLostWord_Load(object sender, System.EventArgs e)
        {
            label = new SmoothLabel
            {
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 80F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = "Запомни!",
                Width = 800,
                Height = 200,
                ForeColor = Color.White
            };
            label.Left = (Width / 2) - (label.Width / 2);
            label.Top = (Height / 2) - (label.Height / 2);
            Controls.Add(label);

            words = Regex.Split(Resource1.words, "\r\n");
        }

    }
}
