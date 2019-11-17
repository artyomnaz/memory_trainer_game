using System;
using System.Drawing;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public partial class FormFindAPair : Form, IGameInterface
    {
        private Level lvl;
        public FormFindAPair()
        {
            InitializeComponent();
            lvl = new Level(3, this);
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

        public void DrawField()
        {
            lvl.Draw();
        }

        public bool IsFinish()
        {
            throw new NotImplementedException();
        }

        private void FormFindAPair_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*Bitmap bmp = new Bitmap(pictureBox2.Image);
            Bitmap b = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    if (b.GetPixel(j, i) == Color.FromArgb(17, 112, 184))
                    {
                        b.SetPixel(j,i,Color.Red);
                    }
                }
            }
            pictureBox1.Image = b;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            pictureBox1.Invalidate();
            timer1.Enabled = true;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Bitmap bmp = new Bitmap(pictureBox1.Image);
            PictureBox pb = new PictureBox();
            pb.Image = bmp;
            pb.Size = new Size(120,200);
            pb.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 210);
            Controls.Add(pb);
            pb.Show();*/
        }
        private void FormFindAPair_Shown(object sender, EventArgs e)
        {
            DrawField();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lvl.off();
        }
    }
}
