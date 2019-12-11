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

//using System.Drawing.Text;
//using System.IO;
//using System.Runtime.InteropServices;
//using System.Text.RegularExpressions;

namespace Memory_Trainer.Memory_matrix
{
    public partial class FormMemoryMatrix : Form, IGameInterface
    {
        private DataGridView FigureGrid;
        private Label label;
        private int n;
        private int m;
        private int Level;
        private int[][] pos;
        private int timerValue;

        enum pos_state {NoColor, WithColor, ForAnimation, Chosen};
        //public PrivateFontCollection private_fonts = new PrivateFontCollection();

        public FormMemoryMatrix()
        {
            InitializeComponent();
        }

        //private void LoadFont()
        //{
            //using (MemoryStream fontStream = new MemoryStream(Resource1.Montserrat_ExtraBold))
           // {
               // IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
               // byte[] fontdata = new byte[fontStream.Length];
               // fontStream.Read(fontdata, 0, (int)fontStream.Length);
               // Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
               // private_fonts.AddMemoryFont(data, (int)fontStream.Length);
               // fontStream.Close();
               // Marshal.FreeCoTaskMem(data);
            //}
        //}

        private void FormMemoryMatrix_Load(object sender, EventArgs e)
        {
            Level = 1;
            label = new Label();
            label.Parent = this;
            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleCenter;
            //label.Font = new Font(private_fonts.Families[0], 25F);
            label.UseCompatibleTextRendering = true;
            //label.TextRenderingHint = TextRenderingHint.AntiAlias;
            label.Width = 200;
            label.Height = 200;
            label.ForeColor = Color.Black;
            label.Text = "Уровень: " + Level.ToString();
            timerValue = 0;
            n = 3;
            m = (int)(n * n * 0.25);
            pos = new int[n][];
            CreateFormGrid();
            RandomPosition();
            Start();
        }

        private void CreateFormGrid()
        {
            FigureGrid = new DataGridView();
            FigureGrid.Parent = this;
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
                    //Thread.Sleep(800);
                    MessageBox.Show("Все верно");
                    Level++;
                    if (Level % 4 == 0) { 
                        n++;
                        FigureGrid.Click += null;
                        AddCells();
                    }
                    label.Text = "Уровень: " + Level.ToString();
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
                label.Text = "Уровень: " + Level.ToString();
                n = 3;
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
           // pos[n - 1] = new int[n];
            var row = new DataGridViewRow();
            for (int j = 0; j < n; j++)
            {
                pos[j] = new int[n];
                //pos[j][n - 1] = (int)pos_state.NoColor;
                //pos[n - 1][j] = (int)pos_state.NoColor;
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
            throw new NotImplementedException();
        }

        public void OpenGame()
        {
            throw new NotImplementedException();
        }

        public void ShowRules()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

    }
}
