using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    /// <summary>
    /// Класс формы с игрой "Найди пару"
    /// </summary>
    public partial class FormFindAPair : Form
    {
        /// <summary>
        /// Менеджер уровней
        /// </summary>
        private readonly LevelManager _levelManager;
        /// <summary>
        /// Информация об игре
        /// </summary>
        private Info _info;
        /// <summary>
        /// Коллекция настраиваемых шрифтов
        /// </summary>
        private readonly PrivateFontCollection _font;
        /// <summary>
        /// Список кнопок навигации
        /// </summary>
        private List<Button> Btns;
        /// <summary>
        /// Текст с информацией об игре
        /// </summary>
        private string _infoText;
        /// <summary>
        /// Текст с правилами игры
        /// </summary>
        private string _rulesText;
        /// <summary>
        /// Таймер отвечающий за вывод ошибки
        /// </summary>
        private Timer _timer;
        /// <summary>
        /// Выводит сообщение об ошибке
        /// </summary>
        private Label _exeptMsgLbl;
        /// <summary>
        /// Текущее время вывода сообщения об ошибке
        /// </summary>
        private int _time;
        /// <summary>
        /// Конструктор FormFindAPair
        /// </summary>
        public FormFindAPair()
        {
            InitializeComponent();
            _font = new PrivateFontCollection();
            LoadFont();
            BackgroundPB.Parent = this;
            _levelManager = new LevelManager(BackgroundPB, _font);
            Btns = new List<Button>();
            for (int i = 0; i < 4; i++)
            {
                var btn = new Button
                {
                    Visible = true,
                    Parent = BackgroundPB,
                    Font = new Font(_font.Families[0], 10),
                    Width = 150,
                    Height = 50,
                    TabStop = false,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Location = new Point(848, 440 + 60 * i)
                };
                Btns.Add(btn);
            }
            Btns[0].Text = "Загрузить игру";
            Btns[0].Click += LoadGame;
            Btns[1].Text = "Правила";
            Btns[1].Click += OpenRules;
            Btns[2].Text = "Об игре";
            Btns[2].Click += OpenInfo;
            Btns[3].Text = "К играм";
            Btns[3].Click += ReturnToMenu;
            _infoText = "";
            _rulesText = "";
            _time = 0;
            _timer = new Timer
            {
                Interval = 800,
                Enabled = false
            };
            _timer.Tick += TimerTick;
            _exeptMsgLbl = new Label
            {
                Visible = false,
                Font = new Font(_font.Families[0], 20),
                Parent = BackgroundPB,
                AutoSize = true,
                BackColor = Color.CornflowerBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = ""
            };
        }
        /// <summary>
        /// Функция выводящая сообщение об ошибке определенное время
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void TimerTick(object sender, EventArgs e)
        {
            if (_time++ != 1) return;
            _timer.Enabled = false;
            _exeptMsgLbl.Visible = false;
            _time = 0;
            _levelManager.Enabled = true;
            ChangeEnabled(true);
        }
        /// <summary>
        /// Функция для загрузки сохранённой игры
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void LoadGame(object sender, EventArgs e)
        {
            try
            {
                _levelManager.LoadGame();
            }
            catch (Exception exception)
            {
                BackgroundPB.Visible = true;
                _levelManager.Enabled = false;
                ChangeEnabled(false);
                _exeptMsgLbl.Text = exception.Message;
                _exeptMsgLbl.Location = new Point((1028 - _exeptMsgLbl.Width) / 2, 550);
                _exeptMsgLbl.Visible = true;
                _timer.Enabled = true;
                
            }
            
        }
        /// <summary>
        /// Функция делающая активными или не активными кнопки навигации
        /// </summary>
        /// <param name="state">Состояние в которое перейдут кнопки</param>
        private void ChangeEnabled(bool state)
        {
            foreach (var button in Btns)
            {
                button.Enabled = state;
            }
        }
        /// <summary>
        /// Функция открывающая правила игры
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void OpenRules(object sender, EventArgs e)
        {
            if (_rulesText == "")
            {
                _rulesText = Properties.Resources.Rules;
            }
            _info = new Info(BackgroundPB, _rulesText, _font);
            BackgroundPB.Visible = false;
        }
        /// <summary>
        /// Функция открывающая информацию об игре
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void OpenInfo(object sender, EventArgs e)
        {
            if (_infoText == "")
            {
                _infoText = Properties.Resources.Info;
            }
            _info = new Info(BackgroundPB, _infoText, _font);
            BackgroundPB.Visible = false;
        }
        /// <summary>
        /// Функция закрывающая форму и возвращающая в предыдущее меню
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void ReturnToMenu(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }
        /// <summary>
        /// Функция открывающая предыдущее меню при закрытии формы
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void FormFindAPair_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        /// <summary>
        /// Функция загружающая настраевыемый шрифт в проект
        /// </summary>
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
