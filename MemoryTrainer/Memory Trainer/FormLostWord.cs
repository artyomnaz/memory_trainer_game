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
        public int timerValue;
        public bool setColor;
        public SmoothLabel label;
        public SmoothLabel labelFind;
        public string[] words;
        public int[][] blockPositions;
        public int[][] timerPositions;
        public int[] blockPositions2;
        public int[] answerPositions;
        public int[] numberWords;
        public int indexHideWord;
        public int curIndex;
        public Random rnd;

        public List<SmoothLabel> smoothLabels;
        public List<SmoothLabel> smoothTimers;
        public List<SmoothLabel> smoothAnswers;
        public List<int> numberAnswers;
        public PrivateFontCollection private_fonts = new PrivateFontCollection();

        private void LoadFont()
        {
            using (MemoryStream fontStream = new MemoryStream(Resource1.Montserrat_ExtraBold))
            {
                IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
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

            rnd = new Random();
            setColor = true;
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

            blockPositions2 = new int[] { 45, 165, 285, 405, 525 };
            answerPositions = new int[] { 17, 696, 17, 696 };
            InitGame();

        }

        public void InitGame()
        {
            numberWords = new int[] { -1, -1, -1, -1, -1 };
            if (smoothLabels != null)
                Dispose();
            smoothLabels = new List<SmoothLabel>();
            smoothTimers = new List<SmoothLabel>();
            smoothAnswers = new List<SmoothLabel>();
            numberAnswers = new List<int>();
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
                ForeColor = Color.White,
                Parent = this
            };
            label.Left = (Width / 2) - (label.Width / 2);
            label.Top = (Height / 2) - (label.Height / 2);

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

        public void DrawField()
        {
            throw new NotImplementedException();


        }

        public bool IsFinish()
        {
            timerValue++;
            return 2 * 2 == 2 + 2;
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
                Parent = this
            };
            smoothLabels.Add(label2);
        }

        public void OpenGame()
        {
            int k = 20;
        }

        public void SaveGame()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        public void ShowRules()
        {
            throw new NotImplementedException();
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
            }
        }

        public void Dispose()
        {
            foreach (var item in smoothLabels)
            {
                item.Dispose();
            }
            foreach (var item in smoothTimers)
            {
                item.Dispose();
            }
            foreach (var item in smoothAnswers)
            {
                item.Dispose();
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
                        ForeColor = Color.White,
                        Parent = this
                    };
                    label.Left = timerPositions[i][0];
                    label.Top = timerPositions[i][1];
                    smoothTimers.Add(label);
                }
            }
            timerValue++;
        }

        private void TimerCountDown_Tick(object sender, EventArgs e)
        {
            timerValue--;
            if (timerValue > 0)
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
                for (int i = 0; i < 4; i++)
                    smoothTimers[i].Hide();
            }
            else if (timerValue == -3)
            {
                timerValue = 0;
                timerCountDown.Enabled = false;
                labelFind = new SmoothLabel
                {
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(private_fonts.Families[0], 80F),
                    UseCompatibleTextRendering = true,
                    TextRenderingHint = TextRenderingHint.AntiAlias,
                    Text = "Найди!",
                    Width = 800,
                    Height = 200,
                    ForeColor = Color.White,
                    Parent = this
                };
                labelFind.Left = (Width / 2) - (labelFind.Width / 2);
                labelFind.Top = (Height / 2) - (labelFind.Height / 2);
                timerFind.Enabled = true;
            }
        }

        private void TimerFind_Tick(object sender, EventArgs e)
        {
            timerValue++;
            if (timerValue == 5)
            {
                labelFind.Hide();
            }
            else if (timerValue == 6)
            {
                indexHideWord = numberWords[rnd.Next(5)];
                //shuffle array
                int n = smoothLabels.Count;
                while (n > 1)
                {
                    n--;
                    int k = rnd.Next(n);
                    var tempLabel = smoothLabels[n];
                    var tempNumberWord = numberWords[n];
                    smoothLabels[n] = smoothLabels[k];
                    numberWords[n] = numberWords[k];
                    smoothLabels[k] = tempLabel;
                    numberWords[k] = tempNumberWord;
                }
                curIndex = Array.IndexOf(numberWords, indexHideWord);
                for (int i = 0; i < smoothLabels.Count; i++)
                {
                    smoothLabels[i].Left = 364;
                    smoothLabels[i].Top = blockPositions2[i];
                    if (i == curIndex)
                        smoothLabels[curIndex].Text = "?";
                }
                timerFind.Enabled = false;
                timerValue = 0;
                timerShowBlock.Enabled = true;
            }
            else
            {
                BackColor = setColor ? Color.FromArgb(145, 189, 58) : Color.FromArgb(250, 66, 82);
                setColor = !setColor;
            }
        }

        private void TimerShowBlock_Tick(object sender, EventArgs e)
        {
            if (timerValue == 6)
            {
                timerValue = 0;
                timerShowBlock.Enabled = false;
                //creating buttons-answers
                for (int i = 0; i < 4; i++)
                {
                    label = new SmoothLabel
                    {
                        BackColor = Color.Red,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(private_fonts.Families[0], 20F),
                        UseCompatibleTextRendering = true,
                        TextRenderingHint = TextRenderingHint.AntiAlias,
                        Width = 300,
                        Height = 40,
                        ForeColor = Color.White,
                        Parent = this
                    };
                    label.MouseEnter += ChangeBackMouseEnter;
                    label.MouseLeave += ChangeBackMouseLeave;
                    label.Click += Answer_Click;
                    while (true)
                    {
                        var tempNumberWord = rnd.Next(words.Length);
                        if (numberAnswers.IndexOf(tempNumberWord) == -1 && Array.IndexOf(numberWords, tempNumberWord) == -1)
                        {
                            label.Text = words[tempNumberWord];
                            break;
                        }
                    }
                    label.Left = answerPositions[i];
                    label.Top = blockPositions2[curIndex] + 60 * (i / 2);
                    smoothAnswers.Add(label);
                    label.Show();
                }
                smoothAnswers[rnd.Next(4)].Text = words[numberWords[curIndex]];
                return;
            }
            else if (timerValue < 5)
            {
                smoothLabels[timerValue].Show();
            }
            timerValue++;
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            if ((sender as SmoothLabel).Text == words[numberWords[curIndex]])
                timerValue++;

            for (int i = 0; i < smoothAnswers.Count; i++)
            {
                if (smoothAnswers[i].Text == words[numberWords[curIndex]])
                    smoothAnswers[i].BackColor = Color.LightSeaGreen;
                else
                    smoothAnswers[i].BackColor = Color.Yellow;
                smoothAnswers[i].MouseEnter -= ChangeBackMouseEnter;
                smoothAnswers[i].MouseLeave -= ChangeBackMouseLeave;
                smoothAnswers[i].Click -= Answer_Click;
            }
            smoothLabels[curIndex].Text = words[numberWords[curIndex]];
            IsFinish();
        }
    }
}