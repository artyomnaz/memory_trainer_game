using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    /// <summary>
    /// Класс, описывающий менеджер уровней
    /// </summary>
    public class LevelManager
    {
        /// <summary>
        /// Хранит уровень игры
        /// </summary>
        private Level level;
        /// <summary>
        /// Контрол на котором необходимо отрисовать менеджер уровней
        /// </summary>
        private Control _control;
        /// <summary>
        /// Выводит название игры
        /// </summary>
        private Label NameGame;
        /// <summary>
        /// Выводит надпись выбора уровня
        /// </summary>
        private Label ChooseLevel;
        /// <summary>
        /// Список кнопок с уровнями
        /// </summary>
        private List<Button> BtnsLvl;
        /// <summary>
        /// Коллекция настраиваемых шрифтов
        /// </summary>
        private PrivateFontCollection _font;
        /// <summary>
        /// Отвечает за видимость менеджера
        /// </summary>
        private bool _enabled;
        /// <summary>
        /// Отвечает за видимость менеджера
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            set
            {
                ChangeEnabled(value);
                _enabled = value;
            }
        }
        /// <summary>
        /// Конструктор LevelManager
        /// </summary>
        /// <param name="control">Контрол на котором необходимо отрисовать менеджер уровней</param>
        /// <param name="font">Коллекция настраиваемых шрифтов</param>
        public LevelManager(Control control, PrivateFontCollection font)
        {
            _control = control;
            _font = font;
            NameGame = new Label
            {
                Text = "Найди\n пару",
                Parent = _control,
                Visible = true,
                Font = new Font(_font.Families[0], 40),
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            ChooseLevel = new Label
            {
                Text = "Выбор уровня",
                Parent = _control,
                Visible = true,
                Font = new Font(_font.Families[0], 20),
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            BtnsLvl = new List<Button>();
            for (int i = 1, j = 0, k = 0; i < 10; i++, j++)
            {
                var btn = new Button
                {
                    Width = 70,
                    Height = 70,
                    Visible = true,
                    Parent = _control,
                    Text = i.ToString(),
                    Font = new Font(_font.Families[0], 30),
                    FlatStyle = FlatStyle.Flat,
                    TabStop = false,
                    Location = new Point(379 + 100 * j, (680 - NameGame.Height - ChooseLevel.Height) / 2 + 100 * k),
                    BackColor = Color.White,
                };
                btn.MouseClick += ButtonMouseClick;
                BtnsLvl.Add(btn);
                
                if (i % 3 == 0)
                {
                    k++;
                    j = -1;
                }
            }
            NameGame.Location = new Point((1028 - NameGame.Width) / 2, 50);
            ChooseLevel.Location = new Point((1028 - ChooseLevel.Width) / 2, 60 + NameGame.Height);
        }
        /// <summary>
        /// Функция создающий новый уровень в зависимости от нажатой кнопки
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void ButtonMouseClick(object sender, MouseEventArgs e)
        {
            ((PictureBox) _control).Visible = false;
            level = new Level(Convert.ToInt32(((Button)sender).Text), _control, _font, OpeningРarameter.New);
            level.DrawField();
        }
        /// <summary>
        /// Функция выполняющая загрузку уровня
        /// </summary>
        public void LoadGame()
        {
            ((PictureBox)_control).Visible = false;
            level = new Level(1, _control, _font, OpeningРarameter.Load);
        }
        /// <summary>
        /// Функция делающая активными или не активными все кнопки менеджера
        /// </summary>
        /// <param name="state">Состояние в которое перейдут кнопки</param>
        private void ChangeEnabled(bool state)
        {
            foreach (var button in BtnsLvl)
            {
                button.Enabled = state;
            }
        }
    }
}