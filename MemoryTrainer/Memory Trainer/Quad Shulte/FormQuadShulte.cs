﻿using System;
using System.Text;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{
    public partial class FormQuadShulte : Form,IGameInterface
    {
        int time;
        public int Level { get; set; }
        public int NameGame { get; set; }
        public FormQuadShulte()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Magneto", 15);
            Level = 5;
            NameGame = 1;
            Game(Level, NameGame);
        }
        public void Game(int level, int name)
        {
            DataGridViewButtonColumn[] buttonColumn = new DataGridViewButtonColumn[level];
            dataGridView1.RowTemplate.Height = dataGridView1.Height/level-1;        
            for (int i = 0; i < level; i++)
            {
                buttonColumn[i] = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(buttonColumn[i]);
                buttonColumn[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                buttonColumn[i].FlatStyle = FlatStyle.Popup;
            }
            dataGridView1.RowCount = level;
            int r = level * level;
            int[] array = new int[r];
            Random rnd = new Random();
            bool ind = false;
            if (name == 1 || name == 3)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(1, r + 1);
                    for (int j = i - 1; j >= 0; j--)
                        if (array[i] == array[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                int[,] mas = new int[level, level];
                int k = 0;
                for (int i = 0; i < level; i++)
                {
                    for (int j = 0; j < level; j++)
                    {
                        mas[i, j] = array[k];
                        k++;
                    }
                }
                for (int i = 0; i < level; i++)
                {
                    for (int j = 0; j < level; j++)
                    {
                        dataGridView1[i, j].Value = mas[i, j];
                    }
                }
                if (name == 3)
                {
                    k = 0;
                    int[] arr = new int[r];
                    for (int i = 0; i < array.Length; i++)
                    {
                        arr[i] = rnd.Next(0, 3);
                    }
                    int[,] mas1 = new int[level, level];
                    for (int i = 0; i < level; i++)
                    {
                        for (int j = 0; j < level; j++)
                        {
                            mas1[i, j] = arr[k];
                            k++;
                        }
                    }
                    for(int i = 0; i < level; i++)
                    {
                        for(int j = 0; j< level; j++)
                        {
                            if(mas1[i,j]==0)
                            {
                                dataGridView1[i, j].Style.BackColor = System.Drawing.Color.LightGreen;
                            }
                            if (mas1[i, j] == 1)
                            {
                                dataGridView1[i, j].Style.BackColor = System.Drawing.Color.LightYellow;
                            }
                            if (mas1[i, j] == 2)
                            {
                                dataGridView1[i, j].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                            }
                        }
                    }
                }
            }
            if (name == 2)
            {
                char[] array21 = new char[r];
                Char[] pwdChars = new Char[32] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
                for (int i = 0; i < array21.Length; i++)
                {
                    array21[i] = pwdChars[rnd.Next(0, Level*Level)];
                    for (int j = i - 1; j >= 0; j--)
                        if (array21[i] == array21[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                char[,] mas21 = new char[level, level];
                int k = 0;
                for (int i = 0; i < level; i++)
                {
                    for (int j = 0; j < level; j++)
                    {
                        mas21[i, j] = array21[k];
                        k++;
                    }
                }
                for (int i = 0; i < level; i++)
                {
                    for (int j = 0; j < level; j++)
                    {
                        dataGridView1[i, j].Value = mas21[i, j];
                    }
                }
            }
            if(name == 4)
            {
                int p;
                p = r / 2;
                int[] array41 = new int[p+1];
                int[] array42 = new int[p];
                for (int i = 0; i < array41.Length; i++)
                {
                    array41[i] = rnd.Next(1, p+2);
                    for (int j = i - 1; j >= 0; j--)
                        if (array41[i] == array41[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                for (int i = 0; i < array42.Length; i++)
                {
                    array42[i] = rnd.Next(1, p+1);
                    for (int j = i - 1; j >= 0; j--)
                        if (array42[i] == array42[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                int[] arr41 = new int[r];
                for (int i = 0; i < arr41.Length; i++)
                {
                    arr41[i] = rnd.Next(1, r + 1);
                    for (int j = i - 1; j >= 0; j--)
                        if (arr41[i] == arr41[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                int[,] mas41 = new int[level, level];
                int k = 0;
                for (int i = 0; i < level; i++)
                {
                    for (int j = 0; j < level; j++)
                    {
                        mas41[i, j] = arr41[k];
                        k++;
                    }
                }
                int m = 0,n=0;        
                for (int i = 0; i < level; i++)
                {
                    for (int j = 0; j < level; j++)
                    {
                        if (mas41[i,j]%2!=0)
                        {
                            dataGridView1[i, j].Value = array41[m];
                            m++;
                            dataGridView1[i, j].Style.BackColor = System.Drawing.Color.Black;
                            dataGridView1[i,j].Style.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            dataGridView1[i, j].Value = array42[n];
                            n++;
                            dataGridView1[i, j].Style.BackColor = System.Drawing.Color.Red;
                            dataGridView1[i, j].Style.ForeColor = System.Drawing.Color.White;
                        }                     
                    }
                }
            }
        }
        public void DrawField()
        {     

        }

        public bool IsFinish()
        {
            if (NameGame==2 && num == 1072 + Math.Pow(Level, 2))
            {
                timer1.Enabled = false;
                FormWin formWin = new FormWin();
                formWin.ShowDialog(this);
            }
            else if (NameGame == 4 && num == Convert.ToInt32((Math.Pow(Level, 2)) / 2 + 2))
            {
                timer1.Enabled = false;
                FormWin formWin = new FormWin();
                formWin.ShowDialog(this);
            }
            else if(num == Math.Pow(Level,2) + 1)
            {
                timer1.Enabled = false;
                FormWin formWin = new FormWin();
                formWin.ShowDialog(this);
            }
            return true;
        }

        public void OpenGame()
        {
            throw new NotImplementedException();
        }

        public void SaveGame()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            FormInfo info = new FormInfo();
            info.ShowDialog(this);
        }

        public void ShowRules()
        {
            FormRules rules = new FormRules();
            rules.ShowDialog(this);
        }

        private void FormQuadShulte_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            int minute, sec;
            minute = time / 60;
            sec = time % 60;
            TimerLabel.Text = minute.ToString() + ':' + sec.ToString();
            time++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ShowRules();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ShowInfo();
        }
        int count = 0;
        int num = 1;
        int x;
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActiveControl = null;
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                time = 1;
            }
            if (NameGame == 2)
            {      
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == Convert.ToChar(num).ToString())
                {
                    num++;
                    if (num <= 1071+Math.Pow(Level, 2))
                    {
                        Inflabel.Text = Convert.ToChar(num).ToString();
                    }
                    IsFinish();
                }
                else
                {
                    count++;
                    CountLabel.Text = count.ToString();
                }
            }
            else
            if (NameGame == 4)
            {
                if(dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == System.Drawing.Color.Black &&
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == num.ToString())
                {
                    num++;
                    if (num <= Math.Pow(Level, 2)/2+1)
                    {
                        Inflabel.Text = "Красная " + x.ToString();
                    }
                    IsFinish();
                }
                else if(dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == System.Drawing.Color.Red &&
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == x.ToString())
                {  
                    if (x>0)
                    {
                        Inflabel.Text = "Черная " + num.ToString();
                    }
                    x--;
                    IsFinish();
                }
                else
                {
                    count++;
                    CountLabel.Text = count.ToString();
                }
            }
            else
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == num.ToString())
                {
                    num++;
                    if (num <= Math.Pow(Level, 2))
                    {
                        Inflabel.Text = num.ToString();
                    }
                    IsFinish();
                }
                else
                {
                    count++;
                    CountLabel.Text = count.ToString();
                }
            }           
        }
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void NewGamebutton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            FormLevel formLevel = new FormLevel();
            formLevel.ShowDialog(this);
            Level = formLevel.Level;
            x = Level * Level / 2;
            NameGame = formLevel.NameGame;
            if (Level != 0 && NameGame != 0)
            {
                timer1.Enabled = false;
                count = 0;
                if(NameGame==2)
                {
                    num = 1072;
                    Inflabel.Text = Convert.ToChar(num).ToString();
                }else
                if (NameGame == 4)
                {
                    num = 1;
                    Inflabel.Text = "Черная " + num.ToString();
                }
                else
                {
                    num = 1;
                    Inflabel.Text = num.ToString();
                }
                TimerLabel.Text = "0:0";
                CountLabel.Text = count.ToString();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                Game(Level, NameGame);
            }
        }
    }
}
