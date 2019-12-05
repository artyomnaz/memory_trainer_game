using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace Memory_Trainer
{
    public partial class FormLostWord : Form, IGameInterface
    {
        public int timerValue = 0;
        public bool setColor = true;
        public SmoothLabel label;
        public string[] words;
        public int[][] blockPositions;
        public int[][] timerPositions;
        public int[] numberWords = { -1, -1, -1, -1, -1 };
        public List<SmoothLabel> smoothLabels;
        public List<SmoothLabel> smoothTimers;
        public PrivateFontCollection private_fonts = new PrivateFontCollection();

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

        public void CreateBlocks(string word, int left, int top)
        {
            SmoothLabel label2 = new SmoothLabel
            {
                BackColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 20F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = word,
                Width = 300,
                Height = 100,
                ForeColor = Color.White,
                Left = left,
                Top = top,
            };
            smoothLabels.Add(label2);
            Controls.Add(label2);
        }

        public void OpenGame()
        {
            //throw new System.NotImplementedException();
            
            
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
                timerCreateBlock.Enabled = true;
                OpenGame();
            }
        }

        private void FormLostWord_Load(object sender, System.EventArgs e)
        {
            Random rnd = new Random();
            smoothLabels = new List<SmoothLabel>();
            smoothTimers = new List<SmoothLabel>();
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

            blockPositions = new int[5][];
            blockPositions[0] = new int[] { 107, 100 };
            blockPositions[1] = new int[] { 621, 100 };
            blockPositions[2] = new int[] { 364, 300 };
            blockPositions[3] = new int[] { 107, 500 };
            blockPositions[4] = new int[] { 621, 500 };

            timerPositions = new int[4][];
            timerPositions[0] = new int[] { 464, 100 };
            timerPositions[1] = new int[] { 207, 300 };
            timerPositions[2] = new int[] { 721, 300 };
            timerPositions[3] = new int[] { 464, 500 };

            int curTemp = 0;
            while (curTemp != 5)
            {
                int tempNumber = rnd.Next(words.Length);
                bool find = false;
                for (int i = 0; i < curTemp; i++)
                {
                    if (tempNumber == numberWords[i])
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    numberWords[curTemp] = tempNumber;
                    curTemp++;
                }
            }
        }


        private void TimerCreateBlock_Tick(object sender, EventArgs e)
        {
            CreateBlocks(words[numberWords[timerValue]], blockPositions[timerValue][0], blockPositions[timerValue][1]);
            if (timerValue == 4)
            {
                timerValue = 5;
                timerCreateBlock.Enabled = false;
                timerCountDown.Enabled = true;
                for (int i = 0; i < 4; i++)
                {
                    label = new SmoothLabel
                    {
                        BackColor = Color.Transparent,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(private_fonts.Families[0], 25F),
                        UseCompatibleTextRendering = true,
                        TextRenderingHint = TextRenderingHint.AntiAlias,
                        Text = "",
                        Width = 100,
                        Height = 100,
                        ForeColor = Color.White
                    };
                    label.Left = timerPositions[i][0];
                    label.Top = timerPositions[i][1];
                    smoothTimers.Add(label);
                    Controls.Add(label);
                }
            }
            timerValue++;
        }

        private void TimerCountDown_Tick(object sender, EventArgs e)
        {
            timerValue--;
            if (timerValue >= 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    smoothTimers[i].Text = timerValue.ToString();
                }
            }
            if (timerValue == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    smoothTimers[i].Text = "GO!";
                }
            }
            else if (timerValue == -1)
            {
                for (int i = 0; i < 5; i++)
                    smoothLabels[i].Hide();
            }
            else if (timerValue == -2)
            {
                timerCountDown.Enabled = false;
                for (int i = 0; i < 4; i++)
                    smoothTimers[i].Hide();
                timerValue = 0;
            }
        }
    }
}
