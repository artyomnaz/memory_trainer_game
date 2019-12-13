using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Memory_Trainer.Memory_matrix
{
    /// <summary>
    /// Класс для формы с игрой "Memory matrix"
    /// </summary>
    public partial class FormMemoryMatrix : Form, IGameInterface
    {
        /// <summary>
        /// Игровая сетка
        /// </summary>
        private DataGridView FigureGrid;

        /// <summary>
        /// Поле для вывода уровня
        /// </summary>
        private Label LevelLabel;

        /// <summary>
        /// Поле для вывода подсказки для пользователя
        /// </summary>
        private Label label;

        /// <summary>
        /// Кнопка сохранения игры
        /// </summary>
        private Button SaveButton;

        /// <summary>
        /// Кнопка открытия игры
        /// </summary>
        private Button OpenButton;

        /// <summary>
        /// Кнопка открытия правил игры
        /// </summary>
        private Button RulesButton;

        /// <summary>
        /// Кнопка открытия информации об игре
        /// </summary>
        private Button AboutButton;

        /// <summary>
        /// Размерность сетки
        /// </summary>
        private int n;

        /// <summary>
        /// Количество закрашенных квадратиков
        /// </summary>
        private int m;

        /// <summary>
        /// Уровень игры
        /// </summary>
        private int Level;

        /// <summary>
        /// Массив со значениями ячеек сетки
        /// </summary>
        private int[][] pos;

        /// <summary>
        /// Счетчик для таймера
        /// </summary>
        private int timerValue;

        /// <summary>
        /// Ключ шифрования
        /// </summary>
        private int key = 22;

        /// <summary>
        /// Число на которое изменяется количество закрашенных квадратиков при увеличения уровня
        /// </summary>
        private int delta;

        /// <summary>
        /// Перечисление состояний массива со значениями ячеек
        /// </summary>
        enum pos_state { NoColor, WithColor, ForAnimation, Chosen };

        /// <summary>
        /// Шрифты
        /// </summary>
        public PrivateFontCollection private_fonts = new PrivateFontCollection();

        /// <summary>
        /// Функция для загрузки шрифтов
        /// </summary>
        private void LoadFont()
        {
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.MyFont))
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
        /// Конструктор FormMemoryMatrix
        /// </summary>
        public FormMemoryMatrix()
        {
            InitializeComponent();
            LoadFont();
            FigureGrid = new DataGridView();
            FigureGrid.Parent = this;
            LevelLabel = new Label();
            LevelLabel.Parent = this;
            label = new Label();
            SaveButton = new Button();
            OpenButton = new Button();
            SaveButton.Parent = this;
            OpenButton.Parent = this;
            RulesButton = new Button();
            AboutButton = new Button();
            RulesButton.Parent = this;
            AboutButton.Parent = this;
            label.Parent = this;
        }

        /// <summary>
        /// Функция загрузки формы FormMemoryMatrix
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void FormMemoryMatrix_Load(object sender, EventArgs e)
        {
            Level = 1;

            LevelLabel.BackColor = Color.Transparent;
            LevelLabel.TextAlign = ContentAlignment.MiddleCenter;
            LevelLabel.UseCompatibleTextRendering = true;
            LevelLabel.Left = 10;
            LevelLabel.Top = 20;
            LevelLabel.Width = 180;
            LevelLabel.Height = 60;
            LevelLabel.ForeColor = Color.FromArgb(39, 36, 36);
            LevelLabel.Font = new Font(private_fonts.Families[0], 20F);
            LevelLabel.Text = "Уровень: " + Level.ToString();
            LevelLabel.BackColor = Color.Transparent;

            label.TextAlign = ContentAlignment.MiddleCenter;
            label.UseCompatibleTextRendering = true;
            label.Font = new Font(private_fonts.Families[0], 22F);
            label.Width = 160;
            label.Height = 60;
            label.Left = this.Width / 2 - 75;
            label.Top = 20;
            label.ForeColor = Color.FromArgb(92, 61, 70);
            label.Text = "Запомни!";
            label.BackColor = Color.Transparent;

            SaveButton.Left = this.Width - 170;
            SaveButton.Top = 30;
            SaveButton.Click += Save;
            SaveButton.Height = 50;
            SaveButton.Width = 130;
            SaveButton.Text = "Сохранить игру";
            SaveButton.BackColor = Color.FromArgb(231, 245, 222);
            SaveButton.Padding = Padding.Empty;

            OpenButton.Left = this.Width - 170;
            OpenButton.Top = 100;
            OpenButton.Click += Open;
            OpenButton.Height = 50;
            OpenButton.Width = 130;
            OpenButton.Text = "Открыть игру";
            OpenButton.BackColor = Color.FromArgb(231, 245, 222);

            RulesButton.Left = this.Width - 170;
            RulesButton.Top = this.Height - 140;
            RulesButton.Click += Rules;
            RulesButton.Height = 50;
            RulesButton.Width = 130;
            RulesButton.Text = "Правила";
            RulesButton.BackColor = Color.FromArgb(231, 245, 222);

            AboutButton.Left = this.Width - 170;
            AboutButton.Top = this.Height - 210;
            AboutButton.Click += Info;
            AboutButton.Height = 50;
            AboutButton.Width = 130;
            AboutButton.Text = "Об игре";
            AboutButton.BackColor = Color.FromArgb(231, 245, 222);

            timerValue = 0;
            delta = 0;
            n = 3;
            m = (int)(n * n * 0.25) + delta;
            pos = new int[n][];
            CreateFormGrid();
            RandomPosition();
            Start();
        }

        /// <summary>
        /// Функция для создания игровой сетки
        /// </summary>
        private void CreateFormGrid()
        {
            FigureGrid.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                pos[i] = new int[n];
                var row = new DataGridViewRow();
                for (int j = 0; j < n; j++)
                {
                    pos[i][j] = (int)pos_state.NoColor;
                    var cell = new DataGridViewTextBoxCell();
                    row.Cells.Add(cell);
                }
                FigureGrid.Rows.Add(row);
            }
            SetSettings();
        }

        /// <summary>
        /// Функция для установки настроек для игровой сетки
        /// </summary>
        private void SetSettings()
        {
            FigureGrid.AllowUserToResizeRows = false;
            FigureGrid.AllowDrop = false;
            FigureGrid.AllowUserToAddRows = false;
            FigureGrid.AllowUserToDeleteRows = false;
            FigureGrid.AllowUserToOrderColumns = false;
            FigureGrid.AllowUserToResizeColumns = false;
            FigureGrid.AllowUserToResizeRows = false;
            FigureGrid.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            FigureGrid.Click += null;

            FigureGrid.Width = 2 * this.Height / 3;
            FigureGrid.Height = 2 * this.Height / 3;
            FigureGrid.Top = this.Height / 2 - FigureGrid.Height / 2;
            FigureGrid.Left = this.Width / 2 - FigureGrid.Width / 2;
            FigureGrid.GridColor = Color.DarkGray; 
            FigureGrid.BorderStyle = BorderStyle.Fixed3D;

            FigureGrid.RowHeadersVisible = false;
            FigureGrid.ColumnHeadersVisible = false;

            FigureGrid.ScrollBars = ScrollBars.None;
            FigureGrid.MultiSelect = false;
            FigureGrid.DoubleClick += null;

            for (int i = 0; i < n; i++)
            {
                FigureGrid.Rows[i].Height = FigureGrid.Height / n;
                FigureGrid.Columns[i].Width = FigureGrid.Width / n;
                for (int j = 0; j < n; j++)
                {
                    pos[i][j] = (int)pos_state.NoColor;
                    FigureGrid.Rows[i].Cells[j].Selected = false;
                    FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(231, 245, 222);
                }
            }
        }

        /// <summary>
        /// Функция для обработки события при нажатии на ячейку
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void onClick(object sender, EventArgs e)
        {
            if (timer.Enabled)
                return;
            int i = (sender as DataGridView).CurrentCell.RowIndex;
            int j = (sender as DataGridView).CurrentCell.ColumnIndex;

            GameProcess(i, j);
        }

        /// <summary>
        /// Функция, рандомно задающая позиции для закрашенных квадратиков
        /// </summary>
        private void RandomPosition()
        {
            var r = new int[m];
            Random random = new Random();
            for (int i = 0; i < m; i++) {
                r[i] = random.Next(n * n);
                for (int j = 0; j < i; j++)
                    if (r[i] == r[j])
                    {
                        r[i] = random.Next(n * n);
                        i--;
                    }
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < m; k++)
                        if (r[k] == i * n + j)
                            pos[i][j] = (int)pos_state.ForAnimation;
        }

        /// <summary>
        /// Таймер для закрашивания квадратов
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            DrawField();
            timerValue++;

            if (timerValue == m + 1)
            {
                Thread.Sleep(1500);
                label.Text = "Повтори!";
                ClearGrid();
                FigureGrid.CellClick += onClick;
                timerValue = 0;
                Stop();
            }
        }

        /// <summary>
        /// Функция, останавливающая таймер
        /// </summary>
        private void Stop()
        {
            timer.Stop();
            timer.Enabled = false;
        }

        /// <summary>
        /// Функция, запускающая таймер
        /// </summary>
        private void Start()
        {
            FigureGrid.CellClick += null;
            timer.Enabled = true;
            timer.Start();
        }

        /// <summary>
        /// Функция, очищающая сетку
        /// </summary>
        private void ClearGrid()
        {

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(231, 245, 222); ;
        }

        /// <summary>
        /// Функция, реализующая игровой процесс после нажатия на ячейку
        /// </summary>
        /// <param name="i">Координата ячейки по оси x</param>
        /// <param name="j">Координата ячейки по оси y</param>
        private void GameProcess(int i, int j)
        {
            if (pos[i][j] == (int)pos_state.WithColor)
            {
                FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(92, 134, 141);
                FigureGrid.ClearSelection();
                pos[i][j] = (int)pos_state.Chosen;
                if (IsFinish())
                {
                    MessageBox.Show("Верно!");
                    Level++;
                    if (Level % 4 == 0)
                    {
                        n++;
                        delta = -1;
                        FigureGrid.Click += null;
                        AddCells();
                    }
                    delta++;
                    m = (int)(n * n * 0.25) + delta;
                    LevelLabel.Text = "Уровень: " + Level.ToString();
                    label.Text = "Запомни!";
                    ClearGrid();
                    RandomPosition();
                    Start();
                }
            }
            else if (pos[i][j] == (int)pos_state.NoColor)
            {
                DialogResult result = MessageBox.Show("Начать новую игру?", "Неверно!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    Close();
                Level = 1;
                LevelLabel.Text = "Уровень: " + Level.ToString();
                label.Text = "Запомни!";
                n = 3;
                delta = 0;
                m = (int)(n * n * 0.25) + delta;
                FigureGrid.ColumnCount = n;
                FigureGrid.RowCount = n;
                ClearGrid();
                SetSettings();
                RandomPosition();
                Start();
            }
            FigureGrid.ClearSelection();
        }

        /// <summary>
        /// Функция для добавления ячеек в сетку
        /// </summary>
        private void AddCells()
        {
            FigureGrid.ColumnCount = n;

            pos = null;
            pos = new int[n][];
            var row = new DataGridViewRow();
            for (int j = 0; j < n; j++)
            {
                pos[j] = new int[n];
                var cell = new DataGridViewTextBoxCell();
                row.Cells.Add(cell);
            }
            FigureGrid.Rows.Add(row);

            SetSettings();
        }

        /// <summary>
        /// Функция отрисовки одного закрашенного квадратика
        /// </summary>
        public void DrawField()
        {
            for (int i = 0; i < n; i++)
            {
                var flag = false;
                for (int j = 0; j < n; j++)
                    if (pos[i][j] == (int)pos_state.ForAnimation)
                    {
                        FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(92, 134, 141);
                        pos[i][j] = (int)pos_state.WithColor;
                        flag = true;
                        break;
                    }
                if (flag)
                    break;
            }
        }

        /// <summary>
        /// Функция проверки окончания игры
        /// </summary>
        /// <returns>true - в случае финиша, false - в случае продолжения игры</returns>
        public bool IsFinish()
        {
            bool IsFinish = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (pos[i][j] == (int)pos_state.WithColor)
                    {
                        IsFinish = false;
                        break;
                    }
            return IsFinish;
        }

        /// <summary>
        /// Функция для обработки события при нажатии на кнопку "Сохранить игру"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void SaveGame()
        {
            List<string> SaveList = new List<string>();
            var level_shifr = Level ^ key;
            var n_shifr = n ^ key;
            var m_shifr = m ^ key;
            var delta_shifr = delta ^ key;
            SaveList.Add(level_shifr.ToString());
            SaveList.Add(n_shifr.ToString());
            SaveList.Add(m_shifr.ToString());
            SaveList.Add(delta_shifr.ToString());
            for (int i = 0; i < n; i++)
            {
                string tmp = "";
                for (int j = 0; j < n; j++)
                    tmp += (pos[i][j] ^ key).ToString() + " ";
                SaveList.Add(tmp);
            }

            var SaveArray = SaveList.ToArray();

            System.IO.File.WriteAllLines("MemoryMatrix_save.txt", SaveArray);
            MessageBox.Show("Игра сохранена. Тёма, иди кушать.");
        }

        /// <summary>
        /// Функция для обработки события при нажатии на кнопку "Открыть игру"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void OpenGame()
        {
            if (timer.Enabled)
                return;
            var Lines = System.IO.File.ReadAllLines("MemoryMatrix_save.txt");
            Level = int.Parse(Lines[0].TrimEnd()) ^ key;
            n = int.Parse(Lines[1].TrimEnd()) ^ key;
            m = int.Parse(Lines[2].TrimEnd()) ^ key;
            delta = int.Parse(Lines[3].TrimEnd()) ^ key;

            pos = null;
            FigureGrid.RowCount = n;

            pos = new int[n][];
            FigureGrid.ColumnCount = n;
            FigureGrid.RowCount = n + 1;

            for (int i = 0; i < n; i++)
            {
                var tmp = Lines[i + 4].TrimEnd().Split(' ');
                pos[i] = new int[n];
                for (int j = 0; j < n; j++)
                    pos[i][j] = int.Parse(tmp[j]) ^ key;
            }

            SetSettings();
            LevelLabel.Text = "Уровень: " + Level.ToString();
            label.Text = "Запомни!";
            FigureGrid.Refresh();
            timerValue = 0;
            ClearGrid();
            RandomPosition();
            Start();
        }

        /// <summary>
        /// Функция для обработки события при нажатии на кнопку "Правила"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void ShowRules()
        {
            FormRules formRules = new FormRules(private_fonts);
            formRules.ShowDialog();
            Show();
        }

        /// <summary>
        /// Функция для обработки события при нажатии на кнопку "О программе"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void ShowInfo()
        {
            FormInfo formInfo = new FormInfo(private_fonts);
            formInfo.ShowDialog();
            Show();
        }

        /// <summary>
        /// Функция для вызова сохранения игры
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void Save(object sender, EventArgs e)
        {
            if (timer.Enabled)
                return;
            SaveGame();
        }

        /// <summary>
        /// Функция для вызова открытия игры
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void Open(object sender, EventArgs e)
        {
            if (timer.Enabled)
                return;
            OpenGame();
        }

        /// <summary>
        /// Функция для вызова правил игры
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void Rules(object sender, EventArgs e)
        {
            if (timer.Enabled)
                return;
            ShowRules();
        }

        /// <summary>
        /// Функция для вызова информации об игре
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        public void Info(object sender, EventArgs e)
        {
            if (timer.Enabled)
                return;
            ShowInfo();
        }

    }
}
