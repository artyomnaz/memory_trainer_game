using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    /// <summary>
    /// Класс, описывающий карту на игровом поле
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Рисует карту
        /// </summary>
        public PictureBox Image;
        /// <summary>
        /// Хранит картинку открытой карты
        /// </summary>
        public Bitmap ImageOpen { get; set; }
        /// <summary>
        /// Хранит картинку закрытой карты
        /// </summary>
        public Bitmap ImageClose { get; set; }
        /// <summary>
        /// Открыта ли карта
        /// </summary>
        private bool _isOpen;
        /// <summary>
        /// Коэффициент масштабирования карты
        /// </summary>
        private float _scalingFactor;
        /// <summary>
        /// Таймер отвечающий за анимацию
        /// </summary>
        private readonly Timer _timer;
        /// <summary>
        /// Перевернута ли карта
        /// </summary>
        private bool _flip;
        /// <summary>
        /// Хранит события клика на мышь
        /// </summary>
        public event EventHandler MouseClick;
        /// <summary>
        /// Коэффициент масштабирования карты
        /// </summary>
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
        /// <summary>
        /// Открыта ли карта
        /// </summary>
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
        /// <summary>
        /// Тип карты
        /// </summary>
        public int ImageType { get; }
        /// <summary>
        /// Конструктор Card
        /// </summary>
        /// <param name="imageClose">Картинка закрытой карты</param>
        /// <param name="imageOpen">Картинка открытой карты</param>
        /// <param name="imageType">Тип карты</param>
        /// <param name="control">Контрол на котором необходимо отрисовать карту</param>
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
                Parent = control,
                Location = new Point(0),
                BackColor = Color.Transparent
            };
            Image.Click += OnMouseClick;
            ImageType = imageType;
            MouseClick += delegate { };
        }
        /// <summary>
        /// Функция отвечающая за анимацию переворота карты
        /// </summary>
        /// <param name="image">Текущая картинка карты</param>
        private void Animation(Bitmap image)
        {
            Point location = Image.Location;
            Size size = Image.Size;
            if (Image.Size.Width <= 0 && !_flip)
            {
                Image.Image = image;
                _flip = true;
            }
            else
            {
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
        /// <summary>
        /// Функция вызывающая анимацию при каждом тике таймера
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void TimerTick(object sender, EventArgs e)
        {
            Animation(IsOpen ? ImageOpen : ImageClose);
        }
        /// <summary>
        /// Функция вызывающая все события поля MouseClick
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void OnMouseClick(object sender, EventArgs e)
        {
            var handler = MouseClick;
            handler?.Invoke(this, e);
        }
    }
}
