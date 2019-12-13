using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{
    /// <summary>
    /// Класс для формы с игрой Квадрат Шульте
    /// </summary>
    public partial class FormQuadShulte : Form, IGameInterface
    {
        /// <summary>
        /// Переменная для хранения времени
        /// </summary>
        private int time;
        /// <summary>
        /// Переменная для шифрования
        /// </summary>
        private int key;
        /// <summary>
        /// Переменная для хранения уровня
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Переменная для хранения номера игры
        /// </summary>
        public int NameGame { get; set; }
        /// <summary>
        /// Переменная для хранения количества ошибок
        /// </summary>
        private int count = 0;
        /// <summary>
        /// Переменная для хранения текущего значения для выбора в игре
        /// </summary>
        private int num = 1;
        /// <summary>
        /// Переменная для хранения текущего значения черной ячейки в 4ой игре
        /// </summary>
        private int x;
        /// <summary>
        /// Конструктор FormQuadShulte
        /// </summary>
        public FormQuadShulte()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Magneto", 15);
            Level = 5;
            NameGame = 1;
            key = 2;
            Game(Level, NameGame);
        }
        /// <summary>
        /// Функция для открытия игры
        /// </summary>
        /// <param name="level">Переменная для хранения уровня</param>
        /// <param name="name">Переменная для хранения номера игры</param>
        public void Game(int level, int name)
        {
            DataGridViewButtonColumn[] buttonColumn = new DataGridViewButtonColumn[level];
            dataGridView1.RowTemplate.Height = dataGridView1.Height / level - 1;
            for (int i = 0; i < level; i++)
            {
                buttonColumn[i] = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(buttonColumn[i]);
                buttonColumn[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                buttonColumn[i].FlatStyle = FlatStyle.Popup;
            }
            DrawField();

        }
        /// <summary>
        /// Функция для отрисовки поля
        /// </summary>
        public void DrawField()
        {
            dataGridView1.RowCount = Level;
            int r = Level * Level;
            int[] array = new int[r];
            Random rnd = new Random();
            bool ind = false;
            if (NameGame == 1 || NameGame == 3)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(1, r + 1);
                    for (int j = i - 1; j >= 0; j--)
                        if (array[i] == array[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                int[,] mas = new int[Level, Level];
                int k = 0;
                for (int i = 0; i < Level; i++)
                {
                    for (int j = 0; j < Level; j++)
                    {
                        mas[i, j] = array[k];
                        k++;
                    }
                }
                for (int i = 0; i < Level; i++)
                {
                    for (int j = 0; j < Level; j++)
                    {
                        dataGridView1[i, j].Value = mas[i, j];
                    }
                }
                if (NameGame == 3)
                {
                    k = 0;
                    int[] arr = new int[r];
                    for (int i = 0; i < array.Length; i++)
                    {
                        arr[i] = rnd.Next(0, 3);
                    }
                    int[,] mas1 = new int[Level, Level];
                    for (int i = 0; i < Level; i++)
                    {
                        for (int j = 0; j < Level; j++)
                        {
                            mas1[i, j] = arr[k];
                            k++;
                        }
                    }
                    for (int i = 0; i < Level; i++)
                    {
                        for (int j = 0; j < Level; j++)
                        {
                            if (mas1[i, j] == 0)
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
            if (NameGame == 2)
            {
                char[] array21 = new char[r];
                Char[] pwdChars = new Char[32] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
                for (int i = 0; i < array21.Length; i++)
                {
                    array21[i] = pwdChars[rnd.Next(0, Level * Level)];
                    for (int j = i - 1; j >= 0; j--)
                        if (array21[i] == array21[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                char[,] mas21 = new char[Level, Level];
                int k = 0;
                for (int i = 0; i < Level; i++)
                {
                    for (int j = 0; j < Level; j++)
                    {
                        mas21[i, j] = array21[k];
                        k++;
                    }
                }
                for (int i = 0; i < Level; i++)
                {
                    for (int j = 0; j < Level; j++)
                    {
                        dataGridView1[i, j].Value = mas21[i, j];
                    }
                }
            }
            if (NameGame == 4)
            {
                int p;
                p = r / 2;
                int[] array41 = new int[p + 1];
                int[] array42 = new int[p];
                for (int i = 0; i < array41.Length; i++)
                {
                    array41[i] = rnd.Next(1, p + 2);
                    for (int j = i - 1; j >= 0; j--)
                        if (array41[i] == array41[j]) ind = true;
                    if (ind) i = i - 1;
                    ind = false;
                }
                for (int i = 0; i < array42.Length; i++)
                {
                    array42[i] = rnd.Next(1, p + 1);
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
                int[,] mas41 = new int[Level, Level];
                int k = 0;
                for (int i = 0; i < Level; i++)
                {
                    for (int j = 0; j < Level; j++)
                    {
                        mas41[i, j] = arr41[k];
                        k++;
                    }
                }
                int m = 0, n = 0;
                for (int i = 0; i < Level; i++)
                {
                    for (int j = 0; j < Level; j++)
                    {
                        if (mas41[i, j] % 2 != 0)
                        {
                            dataGridView1[i, j].Value = array41[m];
                            m++;
                            dataGridView1[i, j].Style.BackColor = System.Drawing.Color.Black;
                            dataGridView1[i, j].Style.ForeColor = System.Drawing.Color.White;
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
        /// <summary>
        /// Функция для проверки на победу
        /// </summary>
        /// <returns>Возвращает True, когда игра окончена</returns>
        public bool IsFinish()
        {
            if (NameGame == 2 && num == 1072 + Math.Pow(Level, 2))
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
            else if (num == Math.Pow(Level, 2) + 1)
            {
                timer1.Enabled = false;
                FormWin formWin = new FormWin();
                formWin.ShowDialog(this);
            }
            return true;
        }
        /// <summary>
        /// Функция для загрузки игры
        /// </summary>
        public void OpenGame()
        {
            if (!File.Exists(@"QuadShulte_save.txt"))
            {
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(@"QuadShulte_save.txt");
            NameGame = Convert.ToInt32(lines[0].TrimEnd()) ^ key;
            Level = Convert.ToInt32(lines[1].TrimEnd()) ^ key;
            count = Convert.ToInt32(lines[2].TrimEnd()) ^ key;
            time = Convert.ToInt32(lines[3].TrimEnd()) ^ key;
            num = Convert.ToInt32(lines[4].TrimEnd());
            int h = lines.Length;
            if (NameGame == 4)
            {
                h = lines.Length - Level - 2;
                x = Convert.ToInt32(lines[lines.Length - 2]);
            }
            else
            {
                h = lines.Length - Level;
            }

            if (NameGame == 2)
                Inflabel.Text = Convert.ToChar(num).ToString();
            else if (NameGame == 4)
            {
                if (lines[lines.Length - 1] == "Красная")
                {
                    Inflabel.Text = "Красная " + x.ToString();
                }
                else
                    Inflabel.Text = "Черная " + num.ToString();
            }
            else
                Inflabel.Text = num.ToString();
            CountLabel.Text = count.ToString();
            int minute, sec;
            minute = time / 60;
            sec = time % 60;
            TimerLabel.Text = minute.ToString() + ':' + sec.ToString();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            Game(Level, NameGame);
            for (int i = 5; i < h; i++)
            {
                var m = lines[i].Split(' ');
                for (int j = 0; j < m.Length - 1; j++)
                {
                    dataGridView1[i - 5, j].Value = m[j];
                }
            }
            if (NameGame == 4)
            {
                for (int i = 0; i < Level; i++)
                {
                    var k = lines[5 + Level + i].Split(' ');
                    for (int j = 0; j < Level; j++)
                    {
                        if (k[j] == "Black")
                        {
                            dataGridView1[j, i].Style.BackColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            dataGridView1[j, i].Style.BackColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            if (NameGame == 3)
            {
                for (int i = 0; i < Level; i++)
                {
                    var k = lines[5 + Level + i].Split(' ');
                    for (int j = 0; j < Level; j++)
                    {
                        if (k[j] == "LG")
                        {
                            dataGridView1[j, i].Style.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else
                        if (k[j] == "LY")
                        {
                            dataGridView1[j, i].Style.BackColor = System.Drawing.Color.LightYellow;
                        }
                        else
                            dataGridView1[j, i].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                    }
                }
            }
        }
        /// <summary>
        /// Функция для сохранения игры
        /// </summary>
        public void SaveGame()
        {
            var lvl = Level ^ key;
            var nameGame = NameGame ^ key;
            var c = count ^ key;
            var t = time ^ key;
            var n = num;
            List<string> lines = new List<string>();
            lines.Add(nameGame.ToString());
            lines.Add(lvl.ToString());
            lines.Add(c.ToString());
            lines.Add(t.ToString());
            lines.Add(n.ToString());
            for (int i = 0; i < Level; i++)
            {
                string s = "";
                for (int j = 0; j < Level; j++)
                {
                    s += dataGridView1[i, j].Value;
                    s += " ";
                }
                lines.Add(s);
            }
            if (NameGame == 4)
            {
                for (int i = 0; i < Level; i++)
                {
                    string s = "";
                    for (int j = 0; j < Level; j++)
                    {
                        if (dataGridView1[j, i].Style.BackColor == System.Drawing.Color.Black)
                        {
                            s += "Black";
                            s += " ";
                        }
                        else
                        {
                            s += "Red";
                            s += " ";
                        }
                    }
                    lines.Add(s);
                }
                lines.Add(x.ToString());
                lines.Add(Inflabel.Text.Split(' ')[0]);
            }
            if (NameGame == 3)
            {
                for (int i = 0; i < Level; i++)
                {
                    string s = "";
                    for (int j = 0; j < Level; j++)
                    {
                        if (dataGridView1[j, i].Style.BackColor == System.Drawing.Color.LightGreen)
                        {
                            s += "LG";
                            s += " ";
                        }
                        else
                        if (dataGridView1[j, i].Style.BackColor == System.Drawing.Color.LightYellow)
                        {
                            s += "LY";
                            s += " ";
                        }
                        else
                        {
                            s += "LSB";
                            s += " ";
                        }
                    }
                    lines.Add(s);
                }
            }
            var musStr = lines.ToArray();
            System.IO.File.WriteAllLines(@"QuadShulte_save.txt", musStr);
            MessageBox.Show("Игра сохранена!");
        }
        /// <summary>
        /// Функция для показа информации об игре
        /// </summary>
        public void ShowInfo()
        {
            FormInfo info = new FormInfo();
            info.ShowDialog(this);
        }
        /// <summary>
        /// Функция для показа правил
        /// </summary>
        public void ShowRules()
        {
            FormRules rules = new FormRules();
            rules.ShowDialog(this);
        }
        /// <summary>
        /// Функция для закрытия игры
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void FormQuadShulte_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }
        /// <summary>
        /// Функция для отобраения таймера
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            int minute, sec;
            minute = time / 60;
            sec = time % 60;
            TimerLabel.Text = minute.ToString() + ':' + sec.ToString();
            time++;
        }
        /// <summary>
        /// Функция для вызова окна с правилами
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void button3_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ShowRules();
        }
        /// <summary>
        /// Функция для вызова окна с информацией об авторах
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void button5_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ShowInfo();
        }

        /// <summary>
        /// Функция для обработки событий нажатия на ячейки
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActiveControl = null;
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                if (time == 0)
                    time = 1;
            }
            if (NameGame == 2)
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == Convert.ToChar(num).ToString())
                {
                    num++;
                    if (num <= 1071 + Math.Pow(Level, 2))
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
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == System.Drawing.Color.Black &&
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == num.ToString())
                {
                    num++;
                    if (num <= Math.Pow(Level, 2) / 2 + 1)
                    {
                        Inflabel.Text = "Красная " + x.ToString();
                    }
                    IsFinish();
                }
                else if (dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == System.Drawing.Color.Red &&
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == x.ToString())
                {
                    if (x > 0)
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
        /// <summary>
        /// Функция для очистки содержимого окна
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        /// <summary>
        /// Функция для обработки события при нажатия на кнопку-Новая игра
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void NewGamebutton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            FormLevel formLevel = new FormLevel();
            formLevel.ShowDialog(this);
            if (formLevel.f == true)
            {
                Level = formLevel.Level;
                x = Level * Level / 2;
                NameGame = formLevel.NameGame;
            }
            else
            {
                return;
            }
            if (Level != 0 && NameGame != 0)
            {
                timer1.Enabled = false;
                count = 0;
                if (NameGame == 2)
                {
                    num = 1072;
                    Inflabel.Text = Convert.ToChar(num).ToString();
                }
                else
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
        /// <summary>
        /// Функция для вызова открытия игры
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Downloadbutton_Click(object sender, EventArgs e)
        {
            OpenGame();
        }
        /// <summary>
        /// Функция для вызова сохранения игры
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Savebutton_Click(object sender, EventArgs e)
        {
            SaveGame();
        }
    }
}
