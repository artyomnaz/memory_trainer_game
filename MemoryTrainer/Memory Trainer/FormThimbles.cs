using System;
using System.Windows.Forms;

namespace Memory_Trainer
{
    public partial class FormThimbles : Form {
        // наперстки
        private PictureBox[] thimbles;
        // переменные анимации
        private int ind1, ind2, x1, x2, y1, y2, dx, dy, curstep = 0, level = 1;

        public FormThimbles()
        {
            InitializeComponent();
            // сохраняем наперстки в массив
            thimbles = new PictureBox[3];
            thimbles[0] = pbThimble1;
            thimbles[1] = pbThimble2;
            thimbles[2] = pbThimble3;
        }

        private void Button1_Click(object sender, EventArgs e) {
            // включаем размешивание
            buttonStartGame.Enabled = false;
            Shuffle();
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            // анимация перемешивания
            if (thimbles[ind1].Left == x2 && thimbles[ind1].Top == y2) {
                timer1.Stop();
                timer1.Enabled = false;
                curstep += 1;
                if (curstep < level + 2) Shuffle();
                return;
            }
            else if (Math.Abs(thimbles[ind1].Left - x2) <= 20 && Math.Abs(thimbles[ind1].Top - y2) <= 10) {
                thimbles[ind1].Left = x2;
                thimbles[ind1].Top = y2;
                thimbles[ind2].Left = x1;
                thimbles[ind2].Top = y1;
                return;
            }
            thimbles[ind1].Left += dx / timer1.Interval;
            thimbles[ind2].Left -= dx / timer1.Interval;
            thimbles[ind1].Top += dy / timer1.Interval;
            thimbles[ind2].Top -= dy / timer1.Interval;
        }

        private void Shuffle() {
            // перемешивание
            Random rand = new Random();
            // рандомные индексы обмениваемых
            ind1 = rand.Next(0, 3);
            ind2 = rand.Next(0, 3);
            while (ind1 == ind2)
                ind2 = rand.Next(0, 3);
            x1 = thimbles[ind1].Left;
            x2 = thimbles[ind2].Left;
            y1 = thimbles[ind1].Top;
            y2 = thimbles[ind2].Top;
            dx = x2 - x1;
            dy = y2 - y1;
            // запускаем анимацию
            timer1.Enabled = true;
            timer1.Start();
        }
    }
}