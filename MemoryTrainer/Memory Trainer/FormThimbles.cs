﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Memory_Trainer {
    public partial class FormThimbles : Form, IGameInterface {
        private int ind1, ind2, x1, x2, y1, y2, dx, dy, curstep = 0, 
                    level = 1, bPos = 0, choise = -1, v = 2, key = 55;
        double thimble1_pos_x, thimble1_pos_y, thimble2_pos_x, thimble2_pos_y;
        private bool isAnimation = false, isToTop = true;
        private Rectangle[] thimbles;
        private Rectangle ball_rect;
        private Bitmap thimble_image, ball_image;
        Graphics g;

        private void ButtonAbout_Click(object sender, EventArgs e) {
            ShowInfo();
        }

        public FormThimbles() {
            InitializeComponent();
            thimbles = new[] {
                new Rectangle(107, 360, 180, 250),
                new Rectangle(414, 380, 180, 250),
                new Rectangle(721, 360, 180, 250)
            };

            thimble_image = Properties.Resources.thimble;
            ball_image = Properties.Resources.ball;
            label.Parent = pbBackground;
            label.BackColor = Color.Transparent;
            label.Text = "Уровень: 1";
            if (System.IO.File.Exists(@"thimbles_save.txt")) {
                DialogResult result = MessageBox.Show("Имеется сохраненная игра. Открыть?", "Открытие игры", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    OpenGame();
                else DrawField();
            }
            else DrawField();
        }

        public void DrawField() {
            pbBackground.Image = Properties.Resources.bg;
            g = Graphics.FromImage(pbBackground.Image);
            if (!isAnimation)
                g.DrawImage(ball_image, ball_rect);
            for (int i = 0; i < thimbles.Length; i++)
                g.DrawImage(thimble_image, thimbles[i]);
            label.Text = "Уровень: " + level.ToString();
            pbBackground.Invalidate();
        }

        private void ButtonStartGame_Click(object sender, EventArgs e) {
            buttonStartGame.Enabled = false;
            buttonSave.Enabled = false;
            buttonOpen.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            Animate();
        }

        private void Animate() {
            Random rand = new Random();
            ind1 = rand.Next(0, 3);
            bPos = ind1;
            y1 = thimbles[bPos].Top;
            y2 = y1 - 100;
            dy = y2 - y1;
            int b_pos_x = thimbles[bPos].Left + thimbles[bPos].Width / 2 - 44;
            int b_pos_y = thimbles[bPos].Top + thimbles[bPos].Height - 108;
            ball_rect = new Rectangle(b_pos_x, b_pos_y, 88, 88);
            isToTop = true;
            timerOneToTop.Enabled = true;
            timerOneToTop.Start();
        }

        private void Shuffle() {
            Random rand = new Random();
            isAnimation = true;
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
            timerShuffle.Enabled = true;
            timerShuffle.Start();
        }

        private void TimerOneToTop_Tick(object sender, EventArgs e)
        {
            if (isToTop && thimbles[ind1].Top == y2) {
                isToTop = false;
                Thread.Sleep(400);
                return;
            }
            else if (!isToTop && thimbles[ind1].Top == y1) {
                timerOneToTop.Stop();
                timerOneToTop.Enabled = false;
                isAnimation = false;
                isToTop = true;
                Shuffle();
                return;
            }

            int koef = isToTop ? -1 : 1;
            thimbles[ind1] = new Rectangle(thimbles[ind1].Left, thimbles[ind1].Top - koef * dy / timerOneToTop.Interval, 
                                           thimbles[ind1].Width, thimbles[ind1].Height);
            DrawField();
        }

        private void TimerShuffle_Tick(object sender, EventArgs e) {
            if (thimbles[ind1].Left == x2 && thimbles[ind1].Top == y2) {
                timerShuffle.Stop();
                timerShuffle.Enabled = false;
                isAnimation = false;
                Rectangle temp = thimbles[ind2];
                thimbles[ind2] = thimbles[ind1];
                thimbles[ind1] = temp;
                curstep += 1;
                if (curstep < level + 2) {
                    Shuffle();
                    return;
                }
                else {
                    curstep = 0;
                    int b_pos_x = thimbles[bPos].Left + thimbles[bPos].Width / 2 - 44;
                    int b_pos_y = thimbles[bPos].Top + thimbles[bPos].Height - 108;
                    ball_rect = new Rectangle(b_pos_x, b_pos_y, 88, 88);
                    DrawField();
                    buttonSave.Enabled = true;
                    buttonRules.Enabled = true;
                    buttonAbout.Enabled = true;
                    pbBackground.Click += FormThimbles_Click;
                }
                return;
            }
            else  if (Math.Abs(thimbles[ind1].Left - x2) <= 40 && Math.Abs(thimbles[ind1].Top - y2) <= 20) {
                thimbles[ind1] = new Rectangle(x2, y2, thimbles[ind1].Width, thimbles[ind1].Height);
                thimbles[ind2] = new Rectangle(x1, y1, thimbles[ind2].Width, thimbles[ind2].Height);
                DrawField();
                return;
            }
            thimble1_pos_x += v * dx / timerShuffle.Interval;
            thimble2_pos_x -= v * dx / timerShuffle.Interval;
            thimble1_pos_y += v * dy / timerShuffle.Interval;
            thimble2_pos_y -= v * dy / timerShuffle.Interval;
            thimbles[ind1] = new Rectangle((int)thimble1_pos_x, (int)thimble1_pos_y, thimbles[ind1].Width, thimbles[ind1].Height);
            thimbles[ind2] = new Rectangle((int)thimble2_pos_x, (int)thimble2_pos_y, thimbles[ind2].Width, thimbles[ind2].Height);
            DrawField();
        }

        private void TimerCheckWin_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) {
                int koef = isToTop ? -1 : 1;
                thimbles[i] = new Rectangle(thimbles[i].Left, thimbles[i].Top - koef * dy / timerAllToTop.Interval, 
                                            thimbles[i].Width, thimbles[i].Height);
            }
            if (isToTop && thimbles[0].Top == y2) {
                isToTop = !isToTop;
                Thread.Sleep(400);
            }
            else if (!isToTop && thimbles[0].Top == y1) {
                timerAllToTop.Stop();
                timerAllToTop.Enabled = false;
                isAnimation = false;
                IsFinish();
                return;
            }
            DrawField();
        }

        private void FormThimbles_Click(object sender, EventArgs e) {
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
            buttonSave.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            y1 = thimbles[0].Top;
            y2 = y1 - 100;
            dy = y2 - y1;
            isToTop = true;
            timerAllToTop.Enabled = true;
            timerAllToTop.Start();
        }

        public void SaveGame() {
            var bPosXOR = bPos ^ key;
            var levelXOR = level ^ key;
            var vXOR = v ^ key;
            string[] lines = { bPosXOR.ToString(), levelXOR.ToString(), vXOR.ToString() };
            System.IO.File.WriteAllLines(@"thimbles_save.txt", lines);
            MessageBox.Show("Игра сохранена!");
        }

        public void OpenGame() {
            string[] lines = System.IO.File.ReadAllLines(@"thimbles_save.txt");
            int[] parameters = new int [lines.Length];
            for (int i = 0; i < lines.Length; i++)
                parameters[i] = Convert.ToInt32(lines[i].TrimEnd()) ^ key;
            bPos = parameters[0];
            level = parameters[1];
            v = parameters[2];
            buttonStartGame.Enabled = false;
            buttonOpen.Enabled = false;
            buttonSave.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            DrawField();
            Animate();
        }

        public void ShowRules() {
            var formSR = new FormShowRulesThimbles {
                Left = Left,
                Top = Top
            };
            formSR.ShowDialog();
        }

        public void ShowInfo() {
            var formAT = new FormAboutThimbles {
                Left = Left,
                Top = Top
            };
            formAT.ShowDialog();
        }

        public bool IsFinish() {
            pbBackground.Click += null;
            if (choise == bPos) {
                level++;
                label.Text = "Уровень: " + level.ToString();
                if (level % 4 == 0)
                    v++;
                Shuffle();
            }
            else {
                DialogResult result = MessageBox.Show("Начать новую игру?", "Неверно!", MessageBoxButtons.YesNo);
                v = 2;
                level = 1;
                label.Text = "Уровень: " + level.ToString();
                if (result == DialogResult.No) {
                    Close();
                    return true;
                }
                Animate();
            }
            return false;
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            SaveGame();
        }
        private void ButtonOpen_Click(object sender, EventArgs e) {
            buttonStartGame.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            OpenGame();
        }

        private void ButtonRules_Click(object sender, EventArgs e) {
            ShowRules();
        }
    }
}