using System;
using System.Drawing;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public class Card
    {
        public PictureBox Image;
        public Bitmap ImageOpen { get; set; }
        public Bitmap ImageClose { get; set; }
        private bool _isOpen;
        private readonly Timer _timer;
        private bool _flip;

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (value)
                {
                    if(!IsOpen)
                        _timer.Enabled = true;
                }
                else
                {
                    if(IsOpen)
                        _timer.Enabled = true;
                }
                _isOpen = value;
            }
        }

        private readonly int _imageType;
        public Card(Bitmap imageClose, Bitmap imageOpen, int imageType, Control control)
        {
            ImageClose = imageClose;
            ImageOpen = imageOpen;
            _isOpen = false;
            _flip = false;
            _timer = new Timer
            {
                Interval = 1,
                Enabled = false
            };
            _timer.Tick += TimerTick;
            
            Image = new PictureBox
            {
                Image = imageClose,
                Height = imageClose.Height,
                Width = imageClose.Width,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = true,
                BorderStyle = BorderStyle.FixedSingle,
                Parent = control
            };
            Image.Click += ImageClick;
            _imageType = imageType;
        }

        private void Animation(Bitmap image)
        {
            if (Image.Size.Width <= 0 && !_flip)
            {
                Image.Image = image;
                _flip = true;
            }
            else
            {
                Point location = Image.Location;
                Size size = Image.Size;
                if (!_flip)
                {
                    Image.Location = new Point(location.X + 5, location.Y);
                    Image.Size = new Size(size.Width - 10, size.Height);
                }
                else
                {
                    if(size.Width < Image.Image.Width)
                    {
                        Image.Location = new Point(location.X - 5, location.Y);
                        Image.Size = new Size(size.Width + 10, size.Height);
                    }
                    /*if (Image.Size.Width > Image.Image.Width)
                    {
                        Image.Size = new Size(Image.Image.Width, Image.Image.Height);
                    }*/

                    if (Image.Size.Width == Image.Image.Width)
                    {
                        _flip = false;
                        _timer.Enabled = false;
                    }
                }
            }
            Image.Invalidate();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            Animation(IsOpen ? ImageOpen : ImageClose);
        }
        private void ImageClick(object sender, EventArgs e)
        {
            IsOpen = true;
        }
    }
}
