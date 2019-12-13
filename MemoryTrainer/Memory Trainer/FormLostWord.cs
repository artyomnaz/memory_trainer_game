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
    /// <summary>
    /// Класс для формы с игрой
    /// </summary>
    public partial class FormLostWord : Form, IGameInterface
    {
        /// <summary>
        /// Текущее значение таймера
        /// </summary>
        public int timerValue;
        /// <summary>
        /// Значение интервала для всех таймеров
        /// </summary>
        public int timerInterval;
        /// <summary>
        /// Проверка установки цвета
        /// </summary>
        public bool setColor;
        /// <summary>
        /// Надпись с названием игры
        /// </summary>
        public SmoothLabel gameName;
        /// <summary>
        /// Надпись в разделе Об игре
        /// </summary>
        public SmoothLabel gameInfo;
        /// <summary>
        /// Надпись в разделе Правила игры
        /// </summary>
        public SmoothLabel gameRules;
        /// <summary>
        /// Кнопка Закрыть в разделе Об игре
        /// </summary>
        public SmoothLabel closeWindow;
        /// <summary>
        /// Кнопка Закрыть в разделе Правила
        /// </summary>
        public SmoothLabel closeWindow2;
        /// <summary>
        /// Временная надпись
        /// </summary>
        public SmoothLabel label;
        /// <summary>
        /// Надпись Найди!
        /// </summary>
        public SmoothLabel labelFind;
        /// <summary>
        /// Надпись о результате игры
        /// </summary>
        public SmoothLabel labelRes;
        /// <summary>
        /// Надпись о успешном сохранении игры
        /// </summary>
        public SmoothLabel labelSave;
        /// <summary>
        /// Надпись о количестве набранных очков
        /// </summary>
        public SmoothLabel scoreLabel;
        /// <summary>
        /// Текст кнопок в меню
        /// </summary>
        public string[] buttonsText;
        /// <summary>
        /// Текст кнопок после прохождения уровня
        /// </summary>
        public string[] buttonsText2;
        /// <summary>
        /// Слова, из которых будут выбираться загаданные слова
        /// </summary>
        public string[] words;
        /// <summary>
        /// Позиции блоков при инициализации уровня
        /// </summary>
        public int[][] blockPositions;
        /// <summary>
        /// Позиции таймеров
        /// </summary>
        public int[][] timerPositions;
        /// <summary>
        /// Позиции блоков при повторном отображении
        /// </summary>
        public int[] blockPositions2;
        /// <summary>
        /// Позиции кнопок после прохождения уровня
        /// </summary>
        public int[] buttonPositions2;
        /// <summary>
        /// Позиции блоков с вариантами ответов
        /// </summary>
        public int[] answerPositions;
        /// <summary>
        /// Индексы слов, учатсвующих в игре, в словаре
        /// </summary>
        public int[] numberWords;
        /// <summary>
        /// Индекс спрятанного слова в словаре
        /// </summary>
        public int indexHideWord;
        /// <summary>
        /// Индекс спрятанного блока
        /// </summary>
        public int curIndex;
        /// <summary>
        /// Объект для использования рандома
        /// </summary>
        public Random rnd;
        /// <summary>
        /// Проверка победил или нет?
        /// </summary>
        public bool win;
        /// <summary>
        /// Количество набранных очков
        /// </summary>
        public int score;

        /// <summary>
        /// Блоки с загаданными словами
        /// </summary>
        public List<SmoothLabel> smoothLabels;
        /// <summary>
        /// Таймеры
        /// </summary>
        public List<SmoothLabel> smoothTimers;
        /// <summary>
        /// Блоки с вариантами ответов
        /// </summary>
        public List<SmoothLabel> smoothAnswers;
        /// <summary>
        /// Кнопки меню
        /// </summary>
        public List<SmoothLabel> smoothButtons;
        /// <summary>
        /// Кнопки меню после прохождения уровня
        /// </summary>
        public List<SmoothLabel> smoothButtons2;
        /// <summary>
        /// Индекс вариантов ответов в словаре
        /// </summary>
        public List<int> numberAnswers;
        /// <summary>
        /// Объект для использования сторонних шрифтов
        /// </summary>
        public PrivateFontCollection private_fonts = new PrivateFontCollection();

        /// <summary>
        /// Функция загрузки шрифта Montserrat из словаря
        /// </summary>
        private void LoadFont()
        {
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Montserrat_ExtraBold))
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

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public FormLostWord()
        {
            InitializeComponent();
            LoadFont();
            timerInterval = 700;
            rnd = new Random();
            setColor = true;
            score = 0;
            words = Regex.Split(Properties.Resources.words, "\r\n");

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
            buttonsText = new string[] {"Начать", "Загрузить", "Правила игры", "Об игре", "Выход"};
            buttonsText2 = new string[] {"Продолжить", "Загрузить", "Сохранить", "Выход" };
            smoothButtons = new List<SmoothLabel>();
            smoothButtons2 = new List<SmoothLabel>();
            gameName = new SmoothLabel
            {
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 80F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = "Потерянное слово",
                Width = 800,
                Height = 200,
                ForeColor = Color.White,
                Parent = this
            };
            gameName.Left = (Width / 2) - (gameName.Width / 2);
            gameName.Top = 50;
            gameName.Show();

            gameInfo = new SmoothLabel
            {
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 20F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = "Игра \"Потерянное слово\" помогает развивать память, способствует концентрации внимания и улучшает реакцию. Игра создана в учебных целях.",
                Width = 800,
                Height = 600,
                ForeColor = Color.White,
                Parent = this
            };
            gameInfo.Left = (Width / 2) - (gameInfo.Width / 2);
            gameInfo.Top = (Height / 2) - (gameInfo.Height / 2);
            gameInfo.Hide();

            closeWindow = new SmoothLabel
            {
                BackColor = Color.FromArgb(163, 88, 109),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 20F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = "Закрыть",
                Width = 300,
                Height = 40,
                ForeColor = Color.White,
                Parent = gameInfo
            };
            closeWindow.Left = (closeWindow.Parent.Width / 2) - (closeWindow.Width / 2);
            closeWindow.Top = 400;
            closeWindow.MouseEnter += ChangeBackMouseEnter;
            closeWindow.MouseLeave += ChangeBackMouseLeave;
            closeWindow.Click += Window_Close;
            closeWindow.Show();

            gameRules = new SmoothLabel
            {
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 12F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = "После начала игры Вам будет предложено 5 слов, которые нужно запомнить. Спустя некоторое время слова пропадут и заново отобразятся за исключением одного,"+
                        "которое Вам и нужно отгадать. На выбор Вам будет предложено 4 варианта ответа и всего 1 попытка, чтобы отгадать слово. Цель игры: отгадать как можно "+
                        "больше слов подряд. Но учтите, что с каждым отгаданным словом времени на запоминание слов будет всё меньше и меньше. Удачи!",
                Width = 800,
                Height = 600,
                ForeColor = Color.White,
                Parent = this
            };
            gameRules.Left = (Width / 2) - (gameRules.Width / 2);
            gameRules.Top = (Height / 2) - (gameRules.Height / 2);
            gameRules.Hide();

            closeWindow2 = new SmoothLabel
            {
                BackColor = Color.FromArgb(163, 88, 109),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 20F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = "Закрыть",
                Width = 300,
                Height = 40,
                ForeColor = Color.White,
                Parent = gameRules
            };
            closeWindow2.Left = (closeWindow2.Parent.Width / 2) - (closeWindow2.Width / 2);
            closeWindow2.Top = 400;
            closeWindow2.MouseEnter += ChangeBackMouseEnter;
            closeWindow2.MouseLeave += ChangeBackMouseLeave;
            closeWindow2.Click += Window_Close;
            closeWindow2.Show();

            for (int i = 0; i < buttonsText.Length; i++)
            {
                label = new SmoothLabel
                {
                    BackColor = Color.FromArgb(163, 88, 109),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(private_fonts.Families[0], 20F),
                    UseCompatibleTextRendering = true,
                    TextRenderingHint = TextRenderingHint.AntiAlias,
                    Width = 300,
                    Height = 40,
                    ForeColor = Color.White,
                    Parent = this
                };
                label.Text = buttonsText[i];
                label.MouseEnter += ChangeBackMouseEnter;
                label.MouseLeave += ChangeBackMouseLeave;
                label.Click += Buttons_Click;

                label.Left = (Width / 2) - (label.Width / 2);
                label.Top = 330 + i * 50;
                smoothButtons.Add(label);
                label.Show();
            }

            for (int i = 0; i < buttonsText2.Length; i++)
            {
                label = new SmoothLabel
                {
                    BackColor = Color.FromArgb(163, 88, 109),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(private_fonts.Families[0], 20F),
                    UseCompatibleTextRendering = true,
                    TextRenderingHint = TextRenderingHint.AntiAlias,
                    Width = 300,
                    Height = 40,
                    ForeColor = Color.White,
                    Parent = this
                };
                label.Text = buttonsText2[i];
                label.MouseEnter += ChangeBackMouseEnter;
                label.MouseLeave += ChangeBackMouseLeave;
                label.Click += Buttons_Click;

                label.Left = (Width / 2) - (label.Width / 2);
                label.Top = 370 + i * 50;
                label.Hide();
                smoothButtons2.Add(label);
            }
        }

        /// <summary>
        /// Закрытие всплывающих окон
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void Window_Close(object sender, EventArgs e)
        {
            (sender as SmoothLabel).Parent.Hide();
        }

        /// <summary>
        /// Обработчик нажатия по кнопке меню
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void Buttons_Click(object sender, EventArgs e)
        {
            string buttonText = (sender as SmoothLabel).Text;
            switch (buttonText)
            {
                case "Начать":
                    {
                        gameName.Hide();
                        for (int i = 0; i < smoothButtons.Count; i++)
                        {
                            smoothButtons[i].Hide();
                        }
                        InitGame();
                        break;
                    }
                case "Продолжить":
                    {
                        labelRes.Hide();
                        scoreLabel.Hide();
                        for (int i = 0; i < smoothButtons2.Count; i++)
                        {
                            smoothButtons2[i].Hide();
                        }
                        InitGame();
                        break;
                    }
                case "Правила игры":
                    gameRules.Show();
                    break;
                case "Об игре":
                    gameInfo.Show();
                    break;
                case "Сохранить":
                    {
                        SaveGame();
                        break;
                    }
                case "Загрузить":
                    OpenGame();
                    break;
                case "Выход":
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Инициализация уровня
        /// </summary>
        public void InitGame()
        {
            if (labelSave != null)
                labelSave.Hide();
            setColor = true;
            timerValue = 0;
            timerIntro.Interval = timerInterval;
            timerCountDown.Interval = timerInterval;
            timerCreateBlock.Interval = timerInterval;
            timerFind.Interval = timerInterval;
            timerFinish.Interval = timerInterval;
            timerShowBlock.Interval = timerInterval;
            timerIntro.Enabled = true;
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

        /// <summary>
        /// Функция прорисовывает игровое поле.
        /// </summary>
        public void DrawField()
        {
            throw new NotImplementedException();
        }


        public bool IsFinish()
        {
            return 2 * 2 == 2 + 2;
        }

        /// <summary>
        /// Создания блока
        /// </summary>
        /// <param name="word">Слово на блоке</param>
        /// <param name="left">Позиция для вставки по х</param>
        /// <param name="top">Позиция для вставки по у</param>
        public void CreateBlocks(string word, int left, int top)
        {
            SmoothLabel label2 = new SmoothLabel
            {
                BackColor = Color.FromArgb(163, 88, 109),
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

        /// <summary>
        /// Функция для открытия сохраненной игры
        /// </summary>
        public void OpenGame()
        {
            string s;
            if (!File.Exists("lostWordSave"))
            {
                return;
            }
            using (FileStream file = File.OpenRead("lostWordSave"))
            {
                byte[] array = new byte[file.Length];
                file.Read(array, 0, array.Length);
                s = System.Text.Encoding.Default.GetString(array);
            }
            var lines = s.Split('\n');
            score = Convert.ToInt32(lines[0]);
            timerInterval = Convert.ToInt32(lines[1]);

            if (labelRes != null)
                labelRes.Hide();
            if (scoreLabel != null)
                scoreLabel.Hide();
            gameName.Hide();
            for (int i = 0; i < smoothButtons.Count; i++)
            {
                smoothButtons[i].Hide();
            }
            for (int i = 0; i < smoothButtons2.Count; i++)
            {
                smoothButtons2[i].Hide();
            }
            timerIntro.Enabled = true;
            InitGame();
        }
        
        /// <summary>
        /// Функция для сохранения игры
        /// </summary>
        public void SaveGame()
        {
            using(FileStream file = new FileStream("lostWordSave", FileMode.Create))
            {
                string s = score.ToString() + "\n" + timerInterval.ToString();
                byte[] array = System.Text.Encoding.Default.GetBytes(s);
                file.Write(array, 0, array.Length);
            }
            labelSave = new SmoothLabel
            {
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(private_fonts.Families[0], 20F),
                UseCompatibleTextRendering = true,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                Text = "Игра сохранена",
                Width = 800,
                Height = 70,
                ForeColor = Color.White,
                Parent = this
            };
            labelSave.Left = (Width / 2) - (labelSave.Width / 2);
            labelSave.Top = 600;
            labelSave.Show();
            timerSave.Enabled = true;
        }

        /// <summary>
        /// Функция для отображения информации об игре
        /// </summary>
        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Функция для отображения правил игры
        /// </summary>
        public void ShowRules()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Функция изменения кнопки при наведении мышки на блок
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void ChangeBackMouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(244, 135, 76);
        }

        /// <summary>
        /// Функция изменения кнопки при покидании мышки блока
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void ChangeBackMouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(163, 88, 109);
        }

        /// <summary>
        /// Таймер при инициализации
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void TimerIntro_Tick(object sender, System.EventArgs e)
        {
            timerValue++;
            BackColor = setColor ? Color.FromArgb(92, 74, 114) : Color.FromArgb(244, 106, 78);
            setColor = !setColor;

            if (timerValue == 5)
            {
                timerIntro.Enabled = false;
                timerValue = 0;
                label.Hide();
                timerCreateBlock.Enabled = true;
            }
        }

        /// <summary>
        /// Функция очистки ресурсов
        /// </summary>
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

        /// <summary>
        /// Таймер при создании блоков
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
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

        /// <summary>
        /// Таймер при исчезновении блоков
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
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

        /// <summary>
        /// Таймер перед исчезновением слова
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
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
                BackColor = setColor ? Color.FromArgb(92, 74, 114) : Color.FromArgb(244, 106, 78);
                setColor = !setColor;
            }
        }

        /// <summary>
        /// Таймер при повторном отображении блоков
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void TimerShowBlock_Tick(object sender, EventArgs e)
        {
            if (timerValue == 6)
            {
                timerValue = 0;
                timerShowBlock.Enabled = false;
                for (int i = 0; i < 4; i++)
                {
                    label = new SmoothLabel
                    {
                        BackColor = Color.FromArgb(163, 88, 109),
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

        /// <summary>
        /// Обработка нажатия на блок варианта ответа
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void Answer_Click(object sender, EventArgs e)
        {
            win = false;
            if ((sender as SmoothLabel).Text == words[numberWords[curIndex]])
            {
                win = true;
                score++;
                timerInterval = timerInterval <= 250 ? 250 : timerInterval-=50;
            }
            else
            {
                score = 0;
                timerInterval = 700;
            }
            timerValue++;
            for (int i = 0; i < smoothAnswers.Count; i++)
            {
                if (smoothAnswers[i].Text == words[numberWords[curIndex]])
                    smoothAnswers[i].BackColor = Color.Green;

                else
                    smoothAnswers[i].BackColor = Color.Red;

                smoothAnswers[i].MouseEnter -= ChangeBackMouseEnter;
                smoothAnswers[i].MouseLeave -= ChangeBackMouseLeave;
                smoothAnswers[i].Click -= Answer_Click;
            }
            smoothLabels[curIndex].Text = words[numberWords[curIndex]];
            timerFinish.Enabled = true;
            timerValue = -1;
            IsFinish();
        }

        /// <summary>
        /// Таймер при прохождения уровня
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void TimerFinish_Tick(object sender, EventArgs e)
        {
            if (timerValue == 1)
            {
                foreach (var item in smoothAnswers)
                {
                    item.Hide();
                }
            }
            else if (timerValue == 2)
            {
                foreach (var item in smoothLabels)
                {
                    item.Hide();
                }
            }
            else if (timerValue == 3)
            {
                labelRes = new SmoothLabel
                {
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(private_fonts.Families[0], 80F),
                    UseCompatibleTextRendering = true,
                    TextRenderingHint = TextRenderingHint.AntiAlias,
                    Text = win ? "Победа!" : "Провал...",
                    Width = 800,
                    Height = 130,
                    ForeColor = Color.White,
                    Parent = this
                };
                labelRes.Left = (Width / 2) - (labelRes.Width / 2);
                labelRes.Top = 150;
                labelRes.Show();

                scoreLabel = new SmoothLabel
                {
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(private_fonts.Families[0], 30F),
                    UseCompatibleTextRendering = true,
                    TextRenderingHint = TextRenderingHint.AntiAlias,
                    Text = "Количество очков: " + score.ToString(),
                    Width = 800,
                    Height = 100,
                    Top = 265,
                    ForeColor = Color.White,
                    Parent = this
                };
                scoreLabel.Left = (Width / 2) - (scoreLabel.Width / 2);
                scoreLabel.Show();

                for (int i = 0; i < smoothButtons2.Count; i++)
                {
                    smoothButtons2[i].Show();
                }
                timerValue = 0;
                timerFinish.Enabled = false;
            }
            timerValue++;
        }

        /// <summary>
        /// Таймер при отображении надписи о сохранении игры
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void TimerSave_Tick(object sender, EventArgs e)
        {
            if(timerValue == 2)
            {
                labelSave.Hide();
                timerValue = 0;
                timerSave.Enabled = false;
            }
            timerValue++;
        }
    }
}