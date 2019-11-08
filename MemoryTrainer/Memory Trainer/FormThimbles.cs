using System;
using System.Threading;
using System.Windows.Forms;

namespace Memory_Trainer
{
    public partial class FormThimbles : Form {
        // наперстки
        private PictureBox[] thimbles;
        // переменные анимации
        private int ind1, ind2, x1, x2, y1, y2, dx, dy, curstep = 0, level = 1, bPos;
        private bool isAnimation = false, isToTop = true;

        public FormThimbles() {
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
            Animate();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // анимация перемешивания
            if (thimbles[ind1].Left == x2 && thimbles[ind1].Top == y2)
            {
                timer1.Stop();
                timer1.Enabled = false;
                isAnimation = false;
                curstep += 1;
                if (curstep < level + 2) Shuffle();
                else
                {
                    curstep = 0;
                    // кладем мяч под наперсток с ind = bPos
                    int b_pos_x = thimbles[bPos].Left + thimbles[bPos].Width / 2 - pbBall.Width / 2;
                    int b_pos_y = thimbles[bPos].Top + thimbles[bPos].Height - pbBall.Height - 20;
                    pbBall.Left = b_pos_x;
                    pbBall.Top = b_pos_y;
                    pbBall.Visible = true;
                    for (int i = 0; i < 3; i++)
                    {
                        thimbles[i].Click += FormThimbles_Click;
                    }
                }
                return;
            }
            else if (Math.Abs(thimbles[ind1].Left - x2) <= 20 && Math.Abs(thimbles[ind1].Top - y2) <= 10)
            {
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

        private void Timer2_Tick(object sender, EventArgs e)
        {
            // анимация перемешивания
            if (isToTop && thimbles[ind1].Top == y2)
            {
                isToTop = false;
                Thread.Sleep(400);
                return;
            }
            else if (!isToTop && thimbles[ind1].Top == y1)
            {
                timer2.Stop();
                timer2.Enabled = false;
                isAnimation = false;
                pbBall.Visible = false;
                isToTop = true;
                Shuffle();
            }

            int koef = isToTop ? -1 : 1;
            thimbles[ind1].Top -= koef * dy / timer2.Interval;
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                int koef = isToTop ? -1 : 1;
                thimbles[i].Top -= koef * dy / timer3.Interval;
            }
        }

        private void FormThimbles_Click(object sender, EventArgs e)
        {
            int choise = -1;
            for (int i = 0; i < 3; i++)
            {
                if (((PictureBox)sender) == thimbles[i])
                {
                    choise = i;
                    break;
                }
            }
            y1 = thimbles[0].Top;
            y2 = y1 - 100;
            dy = y2 - y1;
            // запускаем анимацию
            timer3.Enabled = true;
            timer3.Start();
        }

        private void Animate()
        {
            Random rand = new Random();
            isAnimation = true;
            // рандомные индексы обмениваемых
            ind1 = rand.Next(0, 3);
            ind2 = rand.Next(0, 3);
            while (ind1 == ind2)
                ind2 = rand.Next(0, 3);
            y1 = thimbles[ind1].Top;
            y2 = y1 - 100;
            dy = y2 - y1;
            // кладем мяч под наперсток с ind = ind1
            int b_pos_x = thimbles[ind1].Left + thimbles[ind1].Width / 2 - pbBall.Width / 2;
            int b_pos_y = thimbles[ind1].Top + thimbles[ind1].Height - pbBall.Height - 20;
            pbBall.Left = b_pos_x;
            pbBall.Top = b_pos_y;
            bPos = ind1;
            // запускаем анимацию показа мяча
            timer2.Enabled = true;
            timer2.Start();
        }

        private void Shuffle()
        {
            // перемешивание
            Random rand = new Random();
            isAnimation = true;
            // рандомные индексы обмениваемых
            ind1 = rand.Next(0, 3);
            ind2 = rand.Next(0, 3);
            if (bPos == ind1)
                bPos = ind2;
            else if (bPos == ind2)
                bPos = ind1;
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