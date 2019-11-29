using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Memory_Trainer {
    public partial class FormThimbles : Form, IGameInterface {
        // переменные анимации
        private int ind1, ind2, x1, x2, y1, y2, dx, dy, curstep = 0, level = 1, bPos, choise = -1, v = 2;
        double thimble1_pos_x, thimble1_pos_y, thimble2_pos_x, thimble2_pos_y;
        private bool isAnimation = false, isToTop = true;
        private Rectangle[] thimbles;
        private Rectangle ball_rect;
        private Bitmap thimble_image, ball_image;
        Graphics g;

        private void DrawMe() {
            pictureBox1.Image = Properties.Resources.bg;
            g = Graphics.FromImage(pictureBox1.Image);
            if(!isAnimation)
                g.DrawImage(ball_image, ball_rect);
            for (int i = 0; i < thimbles.Length; i++)
                g.DrawImage(thimble_image, thimbles[i]);
            pictureBox1.Invalidate();
        }

        public FormThimbles() {
            InitializeComponent();
            // массив с координатами наперстков
            thimbles = new [] {
                new Rectangle(107, 360, 180, 250),
                new Rectangle(414, 380, 180, 250),
                new Rectangle(721, 360, 180, 250)
            };

            thimble_image = Properties.Resources.thimble;
            ball_image = Properties.Resources.ball;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label1.Text = "Уровень: 1";
            DrawMe();
        }

        private void Button1_Click(object sender, EventArgs e) {
            // включаем размешивание
            buttonStartGame.Visible = false;
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
                Rectangle temp = thimbles[ind2];
                thimbles[ind2] = thimbles[ind1];
                thimbles[ind1] = temp;
                curstep += 1;
                if (curstep < level + 2)
                {
                    Shuffle();
                    return;
                }
                else
                {
                    curstep = 0;
                    // кладем мяч под наперсток с ind = bPos
                    int b_pos_x = thimbles[bPos].Left + thimbles[bPos].Width / 2 - 44;
                    int b_pos_y = thimbles[bPos].Top + thimbles[bPos].Height - 108;
                    ball_rect = new Rectangle(b_pos_x, b_pos_y, 88, 88);
                    DrawMe();
                    pictureBox1.Click += FormThimbles_Click;
                }
                return;
            }
            else  if (Math.Abs(thimbles[ind1].Left - x2) <= 40 && Math.Abs(thimbles[ind1].Top - y2) <= 20)
            {
                thimbles[ind1] = new Rectangle(x2, y2, thimbles[ind1].Width, thimbles[ind1].Height);
                thimbles[ind2] = new Rectangle(x1, y1, thimbles[ind2].Width, thimbles[ind2].Height);
                DrawMe();
                return;
            }
            thimble1_pos_x += v * dx / timer1.Interval;
            thimble2_pos_x -= v * dx / timer1.Interval;
            thimble1_pos_y += v * dy / timer1.Interval;
            thimble2_pos_y -= v * dy / timer1.Interval;
            thimbles[ind1] = new Rectangle((int)thimble1_pos_x, (int)thimble1_pos_y, thimbles[ind1].Width, thimbles[ind1].Height);
            thimbles[ind2] = new Rectangle((int)thimble2_pos_x, (int)thimble2_pos_y, thimbles[ind2].Width, thimbles[ind2].Height);
            DrawMe();
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
                return;
            }

            int koef = isToTop ? -1 : 1;
            thimbles[ind1] = new Rectangle(thimbles[ind1].Left, thimbles[ind1].Top - koef * dy / timer2.Interval, thimbles[ind1].Width, thimbles[ind1].Height);
            DrawMe();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) {
                int koef = isToTop ? -1 : 1;
                thimbles[i] = new Rectangle(thimbles[i].Left, thimbles[i].Top - koef * dy / timer3.Interval, thimbles[i].Width, thimbles[i].Height);
            }
            if (isToTop && thimbles[0].Top == y2) {
                isToTop = !isToTop;
                Thread.Sleep(400);
            }
            else if (!isToTop && thimbles[0].Top == y1) {
                timer3.Stop();
                timer3.Enabled = false;
                isAnimation = false;
                IsFinish();
                return;
            }
            DrawMe();
        }

        private void FormThimbles_Click(object sender, EventArgs e)
        {
            if (isAnimation) return;
            var mx = ((MouseEventArgs)e).Location.X;
            var my = ((MouseEventArgs)e).Location.Y;
            bool flag = false;
            for (int i = 0; i < 3; i++) {
                if (mx >= thimbles[i].Left && mx <= thimbles[i].Left + thimbles[i].Width &&
                    my >= thimbles[i].Top  && my <= thimbles[i].Top + thimbles[i].Height) {
                    choise = i;
                    flag = true;
                    break;
                }
            }
            if (!flag) return;
            y1 = thimbles[0].Top;
            y2 = y1 - 100;
            dy = y2 - y1;
            // запускаем анимацию
            isToTop = true;
            timer3.Enabled = true;
            timer3.Start();
        }

        private void Animate()
        {
            Random rand = new Random();
            // isAnimation = true;
            // рандомный индекс для мяча
            ind1 = rand.Next(0, 3);
            y1 = thimbles[ind1].Top;
            y2 = y1 - 100;
            dy = y2 - y1;
            // кладем мяч под наперсток с ind = ind1
            bPos = ind1;
            int b_pos_x = thimbles[bPos].Left + thimbles[bPos].Width / 2 - 44;
            int b_pos_y = thimbles[bPos].Top + thimbles[bPos].Height - 108;
            ball_rect = new Rectangle(b_pos_x, b_pos_y, 88, 88);

            isToTop = true;
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
            while (ind1 == ind2)
                ind2 = rand.Next(0, 3);
            if (bPos == ind1)
                bPos = ind2;
            else if (bPos == ind2)
                bPos = ind1;
            x1 = thimbles[ind1].Left;
            x2 = thimbles[ind2].Left;
            y1 = thimbles[ind1].Top;
            y2 = thimbles[ind2].Top;
            dx = x2 - x1;
            dy = y2 - y1;
            thimble1_pos_x = x1;
            thimble2_pos_x = x2;
            thimble1_pos_y = y1;
            thimble2_pos_y = y2;
            // запускаем анимацию
            timer1.Enabled = true;
            timer1.Start();
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

        public bool IsFinish()
        {
            pictureBox1.Click += null;
            if (choise == bPos) {
                level++;
                label1.Text = "Уровень: " + level.ToString();
                if (level % 4 == 0)
                    v++;
                pbBall.Hide();
                Shuffle();
            }
            else
            {
                DialogResult result = MessageBox.Show("Начать новую игру?", "Неверно!", MessageBoxButtons.YesNo);
                v = 2;
                level = 1;
                label1.Text = "Уровень: " + level.ToString();
                if (result == DialogResult.No) {
                    Close();
                    return true;
                }
                Animate();
            }
            return false;
        }

        public void DrawField()
        {
            throw new NotImplementedException();
        }
    }
}