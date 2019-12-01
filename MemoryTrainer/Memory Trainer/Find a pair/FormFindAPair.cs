using System;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public partial class FormFindAPair : Form
    {
        private Level lvl;
        private readonly LevelManager _levelManager;
        private readonly PrivateFontCollection _font;
        public FormFindAPair()
        {
            InitializeComponent();
            _font = new PrivateFontCollection();
            LoadFont();
            BackgroundPB.Parent = this;
            _levelManager = new LevelManager(BackgroundPB, _font);
        }

        private void FormFindAPair_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lvl.HideCards();
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private void LoadFont()
        {
            byte[] fontData = Properties.Resources.fonto;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            _font.AddMemoryFont(fontPtr, Properties.Resources.fonto.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.fonto.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
        }
    }
}
