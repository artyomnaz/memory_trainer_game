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
    public partial class FormMemoryMatrix : Form, IGameInterface
    {
        private DataGridView FigureGrid;
        private Label LevelLabel;
        private Label label;
        private Button SaveButton;
        private Button OpenButton;
        private Button RulesButton;
        private Button AboutButton;
        private int n;
        private int m;
        private int Level;
        private int[][] pos;
        private int timerValue;
        private int key = 22;
        private int delta;

        enum pos_state { NoColor, WithColor, ForAnimation, Chosen };

        public PrivateFontCollection private_fonts = new PrivateFontCollection();

        private void LoadFont()
        {
            using (MemoryStream fontStream = new MemoryStream(Resource2.MyFont))
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
            LevelLabel.ForeColor = Color.Black;
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
            label.ForeColor = Color.Red;
            label.Text = "Запомни!";
            label.BackColor = Color.Transparent;

            SaveButton.Left = this.Width - 170;
            SaveButton.Top = 30;
            SaveButton.Click += Save;
            SaveButton.Height = 50;
            SaveButton.Width = 130;
            SaveButton.Text = "Сохранить игру";

            OpenButton.Left = this.Width - 170;
            OpenButton.Top = 100;
            OpenButton.Click += Open;
            OpenButton.Height = 50;
            OpenButton.Width = 130;
            OpenButton.Text = "Открыть игру";

            RulesButton.Left = this.Width - 170;
            RulesButton.Top = this.Height - 140;
            RulesButton.Click += Rules;
            RulesButton.Height = 50;
            RulesButton.Width = 130;
            RulesButton.Text = "Правила";

            AboutButton.Left = this.Width - 170;
            AboutButton.Top = this.Height - 210;
            AboutButton.Click += Info;
            AboutButton.Height = 50;
            AboutButton.Width = 130;
            AboutButton.Text = "Об игре";

            timerValue = 0;
            delta = 0;
            n = 3;
            m = (int)(n * n * 0.25) + delta;
            pos = new int[n][];
            CreateFormGrid();
            RandomPosition();
            Start();
        }

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
                    FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void onClick(object sender, EventArgs e)
        {
            if (timer.Enabled)
                return;
            int i = (sender as DataGridView).CurrentCell.RowIndex;
            int j = (sender as DataGridView).CurrentCell.ColumnIndex;

            GameProcess(i, j);
        }

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

        private void Stop()
        {
            timer.Stop();
            timer.Enabled = false;
        }

        private void Start()
        {
            FigureGrid.CellClick += null;
            timer.Enabled = true;
            timer.Start();
        }

        private void ClearGrid()
        {

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.WhiteSmoke;
        }

        private void GameProcess(int i, int j)
        {
            if (pos[i][j] == (int)pos_state.WithColor)
            {
                FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.IndianRed;
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

        public void DrawField()
        {
            for (int i = 0; i < n; i++)
            {
                var flag = false;
                for (int j = 0; j < n; j++)
                    if (pos[i][j] == (int)pos_state.ForAnimation)
                    {
                        FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.IndianRed;
                        pos[i][j] = (int)pos_state.WithColor;
                        flag = true;
                        break;
                    }
                if (flag)
                    break;
            }
        }

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

        public void SaveGame()
        {
            if (timer.Enabled)
                return;

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

        public void ShowRules()
        {
            FormRules formRules = new FormRules(private_fonts);
            formRules.ShowDialog();
            Show();
        }

        public void ShowInfo()
        {
            FormInfo formInfo = new FormInfo(private_fonts);
            formInfo.ShowDialog();
            Show();
        }

        public void Save(object sender, EventArgs e)
        {
            SaveGame();
        }

        public void Open(object sender, EventArgs e)
        {
            OpenGame();
        }

        public void Rules(object sender, EventArgs e)
        {
            ShowRules();
        }

        public void Info(object sender, EventArgs e)
        {
            ShowInfo();
        }

    }
}
