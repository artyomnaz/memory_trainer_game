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
        private float _scalingFactor;
        private readonly Timer _timer;
        private bool _flip;

        public float ScalingFactor
        {
            get => _scalingFactor;
            set
            {
                _scalingFactor = value;
                Image.Height = Convert.ToInt32(Image.Height * _scalingFactor);
                Image.Width = Convert.ToInt32(Image.Width * _scalingFactor);
            }
        }
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (value)
                {
                    if (!IsOpen)
                        _timer.Enabled = true;
                }
                else
                {
                    if (IsOpen)
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
            _scalingFactor = 1f;
            Image = new PictureBox
            {
                Image = imageClose,
                Height = Convert.ToInt32(imageClose.Height * ScalingFactor),
                Width = Convert.ToInt32(imageClose.Width * ScalingFactor),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = true,
                //BorderStyle = BorderStyle.FixedSingle,
                Parent = control,
                Location = new Point(0)
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
                    Image.Location = new Point(location.X + 10, location.Y);
                    Image.Size = new Size(size.Width - 20, size.Height);
                }
                else
                {
                    if (size.Width < Image.Image.Width * ScalingFactor)
                    {
                        Image.Location = new Point(location.X - 10, location.Y);
                        Image.Size = new Size(size.Width + 20, size.Height);
                    }

                    if (Image.Size.Width == Image.Image.Width * ScalingFactor)
                    {
                        _flip = false;
                        _timer.Enabled = false;
                    }
                    else
                    {

                        if (Image.Size.Width > Image.Image.Width * ScalingFactor)
                        {
                            Image.Size = new Size(Convert.ToInt32(Image.Image.Width * ScalingFactor), Convert.ToInt32(Image.Image.Height * ScalingFactor));
                            _flip = false;
                            _timer.Enabled = false;
                        }
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
