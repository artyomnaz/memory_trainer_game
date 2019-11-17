using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{
    public partial class FormQuadShulte : Form,IGameInterface
    {
        int time;
        DataGridViewButtonColumn[] buttonColumn = new DataGridViewButtonColumn[5];
        public FormQuadShulte()
        {
            InitializeComponent();
            Game();
        }

        public void Game()
        {
            dataGridView1.RowTemplate.Height = 104;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);
            for (int i = 0; i < 5; i++)
            {
                buttonColumn[i] = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(buttonColumn[i]);
                buttonColumn[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                buttonColumn[i].FlatStyle = FlatStyle.Popup;
            }
            dataGridView1.RowCount = 5;
            int[] array = new int[25];
            Random rnd = new Random();
            bool ind = false;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 26);
                for (int j = i - 1; j >= 0; j--)
                    if (array[i] == array[j]) ind = true;
                if (ind) i = i - 1;
                ind = false;
            }
            int[,] mas = new int[5, 5];
            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas[i, j] = array[k];
                    k++;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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
            if(num==26)
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
            if(timer1.Enabled==false)
            {
                timer1.Enabled = true;
            }
            if (dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == num.ToString())
            {          
                num++;
                if (num<=25)
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

    }
}
