using System;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{
    public partial class FormQuadShulte : Form,IGameInterface
    {
        int time;
        public int Level { get; set; }
        public FormQuadShulte()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Magneto", 15);
            Level = 5;
            Game(Level);
        }
        public void Game(int level)
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
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, r+1);
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
        }
        public void DrawField()
        {     

        }

        public bool IsFinish()
        {
            if(num == Math.Pow(Level,2) + 1)
            {
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
            ShowRules();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }
        int count = 0;
        int num = 1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(timer1.Enabled == false)
            {
                timer1.Enabled = true;
                time = 1;
            }
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
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void NewGamebutton_Click(object sender, EventArgs e)
        {
            FormLevel formLevel = new FormLevel();
            formLevel.ShowDialog(this);
            Level = formLevel.Level;
            if (Level != 0)
            {
                timer1.Enabled = false;
                count = 0;
                num = 1;
                TimerLabel.Text = "0:0";
                Inflabel.Text = num.ToString();
                CountLabel.Text = count.ToString();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                Game(Level);
            }
        }
    }
}
