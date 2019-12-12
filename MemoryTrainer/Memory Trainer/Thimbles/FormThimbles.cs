using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Memory_Trainer {
    /// <summary>
    /// Класс для формы с игрой 
    /// </summary>
    public partial class FormThimbles : Form, IGameInterface {
        /// <summary>
        /// Индекс 1 обмениваемого наперстка
        /// </summary>
        private int ind1;
        /// <summary>
        /// Индекс 2 обмениваемого наперстка
        /// </summary>
        private int ind2;
        /// <summary>
        /// Позиция обмена 1 по х.
        /// </summary>
        private int x1;
        /// <summary>
        /// Позиция обмена 2 по х.
        /// </summary>
        private int x2;
        /// <summary>
        /// Позиция обмена 1 по y.
        /// </summary>
        private int y1;
        /// <summary>
        /// Позиция обмена 2 по y.
        /// </summary>
        private int y2;
        /// <summary>
        /// Смещение по х.
        /// </summary>
        private int dx;
        /// <summary>
        /// Смещение по у.
        /// </summary>
        private int dy;
        /// <summary>
        /// Текущий шаг анимации.
        /// </summary>
        private int curstep;
        /// <summary>
        /// Уровень
        /// </summary>
        private int level;
        /// <summary>
        /// Позиция мяча
        /// </summary>
        private int bPos;
        /// <summary>
        /// Выбор наперстка
        /// </summary>
        private int choise;
        /// <summary>
        /// Скорость анимации
        /// </summary>
        private int v;
        /// <summary>
        /// Ключ шифрования
        /// </summary>
        private int key;
        /// <summary>
        /// Позиция наперстка 1 по х.
        /// </summary>
        private double thimble1_pos_x;
        /// <summary>
        /// Позиция наперстка 1 по у.
        /// </summary>
        private double thimble1_pos_y;
        /// <summary>
        /// Позиция наперстка 2 по х.
        /// </summary>
        private double thimble2_pos_x;
        /// <summary>
        /// Позиция наперстка 2 по у.
        /// </summary>
        private double thimble2_pos_y;
        /// <summary>
        /// Флаг анимации.
        /// </summary>
        private bool isAnimation;
        /// <summary>
        /// Флаг - поднимаем ли?
        /// </summary>
        private bool isToTop;
        /// <summary>
        /// Массив прямоугольников для отображения наперстков
        /// </summary>
        private Rectangle[] thimbles;
        /// <summary>
        /// Прямоугольник для отображения мяча.
        /// </summary>
        private Rectangle ball_rect;
        /// <summary>
        /// Изображение для наперстка
        /// </summary>
        private Bitmap thimble_image;
        /// <summary>
        /// Изображение для мяча.
        /// </summary>
        private Bitmap ball_image;
        /// <summary>
        /// Объект для отображения графика.
        /// </summary>
        private Graphics g;
        /// <summary>
        /// Объект для рандома.
        /// </summary>
        private Random rand;

        /// <summary>
        /// Функция инициализации формы
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void FormThimbles_Load(object sender, EventArgs e) {
            curstep = 0;
            level = 1;
            bPos = 0;
            choise = -1;
            v = 2;
            key = 55;
            isAnimation = false;
            isToTop = true;
            thimble_image = Properties.Resources.thimble;
            ball_image = Properties.Resources.ball;
            label.Parent = pbBackground;
            label.BackColor = Color.Transparent;
            label.Text = "Уровень: 1";
            // Открытие сохраненной игры при ее наличии
            if (System.IO.File.Exists(@"thimbles_save.txt")) {
                DialogResult result = MessageBox.Show("Имеется сохраненная игра. Открыть?", "Открытие игры", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) OpenGame();
            }
            DrawField();
        }

        /// <summary>
        /// Обработка нажатия на кнопку "О программе"
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            // Показать информацию об игре
            ShowInfo();
        }

        /// <summary>
        /// Конструктор FormThimbles
        /// </summary>
        public FormThimbles() {
            // Инициализация переменных
            InitializeComponent();
            thimbles = new[] {
                new Rectangle(107, 360, 180, 250),
                new Rectangle(414, 380, 180, 250),
                new Rectangle(721, 360, 180, 250)
            };
            rand = new Random();
        }

        /// <summary>
        /// Функция прорисовывает игровое поле.
        /// </summary>
        public void DrawField()
        {
            // Прорисовка фона, наперстков, мяча
            pbBackground.Image = Properties.Resources.bg;
            g = Graphics.FromImage(pbBackground.Image);
            // Мяч при анимации не рисуем
            if (!isAnimation) g.DrawImage(ball_image, ball_rect);

            for (int i = 0; i < thimbles.Length; i++)
                g.DrawImage(thimble_image, thimbles[i]);

            label.Text = "Уровень: " + level.ToString();
            // Обновляем вид
            pbBackground.Invalidate();
        }

        /// <summary>
        /// Обработка события нажатия на клавишу начала игры.
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            // Отключаем кнопки, анимируем
            buttonStartGame.Enabled = false;
            buttonSave.Enabled = false;
            buttonOpen.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            Animate();
        }

        /// <summary>
        /// Функция для анимации
        /// </summary>
        private void Animate()
        {
            bPos = ind1 = rand.Next(0, 3);
            y1 = thimbles[bPos].Top;
            // параметры анимации подъема
            y2 = y1 - 100;
            dy = y2 - y1;
            // координаты мяча
            int b_pos_x = thimbles[bPos].Left + thimbles[bPos].Width / 2 - 44;
            int b_pos_y = thimbles[bPos].Top + thimbles[bPos].Height - 108;
            ball_rect = new Rectangle(b_pos_x, b_pos_y, 88, 88);
            isToTop = true;
            timerOneToTop.Enabled = true;
            // Старт анимации
            timerOneToTop.Start();
        }

        /// <summary>
        /// Функция для перемешивания наперстков
        /// </summary>
        private void Shuffle()
        {
            // Перемешивание наперстков
            isAnimation = true;
            // Выбор смещаемых наперстков
            ind1 = rand.Next(0, 3);
            ind2 = rand.Next(0, 3);
            while (ind1 == ind2)
                ind2 = rand.Next(0, 3);

            if (bPos == ind1) bPos = ind2;
            else if (bPos == ind2) bPos = ind1;
            // Параметры анимации
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
            // Включаем таймер анимации перемешивания
            timerShuffle.Enabled = true;
            timerShuffle.Start();
        }

        /// <summary>
        /// Таймер для анимации подъема одного наперстка вверх
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void TimerOneToTop_Tick(object sender, EventArgs e)
        {
            // таймер анимации подъема
            if (isToTop && thimbles[ind1].Top == y2)
            {
                isToTop = false;
                // подняли - подержим в воздухе
                Thread.Sleep(400);
                return;
            }
            else if (!isToTop && thimbles[ind1].Top == y1)
            {
                // выключаем таймер
                timerOneToTop.Stop();
                timerOneToTop.Enabled = false;
                isAnimation = false;
                isToTop = true;
                // перемешиваем
                Shuffle();
                return;
            }

            // Запоминаем позицию наперстка
            int koef = isToTop ? -1 : 1;
            thimbles[ind1] = new Rectangle(thimbles[ind1].Left, thimbles[ind1].Top - koef * dy / timerOneToTop.Interval,
                                           thimbles[ind1].Width, thimbles[ind1].Height);
            // рисуем поле
            DrawField();
        }

        /// <summary>
        /// Таймер для анимации перемешивания напестков
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void TimerShuffle_Tick(object sender, EventArgs e)
        {
            // таймер случайного перемешивания
            if (thimbles[ind1].Left == x2 && thimbles[ind1].Top == y2)
            {
                // нашли позицию - стоп таймера
                timerShuffle.Stop();
                timerShuffle.Enabled = false;
                isAnimation = false;
                Rectangle temp = thimbles[ind2];
                thimbles[ind2] = thimbles[ind1];
                thimbles[ind1] = temp;
                curstep += 1;
                if (curstep < level + 2)
                {
                    // перемешиваем
                    Shuffle();
                    return;
                }
                else
                {
                    // параметры анимации
                    curstep = 0;
                    int b_pos_x = thimbles[bPos].Left + thimbles[bPos].Width / 2 - 44;
                    int b_pos_y = thimbles[bPos].Top + thimbles[bPos].Height - 108;
                    ball_rect = new Rectangle(b_pos_x, b_pos_y, 88, 88);
                    // прорисовка поля
                    DrawField();
                    // включение кнопок
                    buttonSave.Enabled = true;
                    buttonRules.Enabled = true;
                    buttonAbout.Enabled = true;
                    // навешивание события клика
                    pbBackground.Click += FormThimbles_Click;
                }
                return;
            }
            else if (Math.Abs(thimbles[ind1].Left - x2) <= 40 && Math.Abs(thimbles[ind1].Top - y2) <= 20)
            {
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

        /// <summary>
        /// Таймер проверки на победу
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void TimerCheckWin_Tick(object sender, EventArgs e)
        {
            // таймер проверки на победу - подъем всех вверх
            for (int i = 0; i < 3; i++)
            {
                // перебор и подъем наперстка вверх - вниз (koef)
                int koef = isToTop ? -1 : 1;
                thimbles[i] = new Rectangle(thimbles[i].Left, thimbles[i].Top - koef * dy / timerAllToTop.Interval,
                                            thimbles[i].Width, thimbles[i].Height);
            }
            if (isToTop && thimbles[0].Top == y2)
            {
                // подняли - задержали
                isToTop = !isToTop;
                Thread.Sleep(400);
            }
            else if (!isToTop && thimbles[0].Top == y1)
            {
                // остановили таймер
                timerAllToTop.Stop();
                timerAllToTop.Enabled = false;
                isAnimation = false;
                // проверка победы
                IsFinish();
                return;
            }
            DrawField();
        }

        /// <summary>
        /// Обработка события нажатия на форму
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void FormThimbles_Click(object sender, EventArgs e)
        {
            if (isAnimation)
            {
                return;
            }
            // координаты мыши
            var mx = ((MouseEventArgs)e).Location.X;
            var my = ((MouseEventArgs)e).Location.Y;
            bool flag = false;
            // запоминаем выбор
            for (int i = 0; i < 3; i++)
            {
                if (mx >= thimbles[i].Left && mx <= thimbles[i].Left + thimbles[i].Width &&
                    my >= thimbles[i].Top && my <= thimbles[i].Top + thimbles[i].Height)
                {
                    choise = i;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                return;
            }
            // выключаем кнопки
            buttonSave.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            // параметры анимации
            y1 = thimbles[0].Top;
            y2 = y1 - 100;
            dy = y2 - y1;
            isToTop = true;
            // анимируем подъем всех
            timerAllToTop.Enabled = true;
            timerAllToTop.Start();
        }

        /// <summary>
        /// Функция для сохранения игры
        /// </summary>
        public void SaveGame()
        {
            // сохранение с шифрованием
            var bPosXOR = bPos ^ key;
            var levelXOR = level ^ key;
            var vXOR = v ^ key;
            string[] lines = { bPosXOR.ToString(), levelXOR.ToString(), vXOR.ToString() };
            System.IO.File.WriteAllLines(@"thimbles_save.txt", lines);
            MessageBox.Show("Игра сохранена!");
        }

        /// <summary>
        /// Функция для открытия сохраненной игры
        /// </summary>
        public void OpenGame()
        {
            // открытие сохраненной игры
            string[] lines = System.IO.File.ReadAllLines(@"thimbles_save.txt");
            int[] parameters = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                parameters[i] = Convert.ToInt32(lines[i].TrimEnd()) ^ key;
            }

            bPos = parameters[0];
            level = parameters[1];
            v = parameters[2];
            // выключение кнопок
            buttonStartGame.Enabled = false;
            buttonOpen.Enabled = false;
            buttonSave.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            // прорисовка поля, включение игры
            DrawField();
            Animate();
        }

        /// <summary>
        /// Функция для отображения правил
        /// </summary>
        public void ShowRules()
        {
            // показываем правла
            var formSR = new FormShowRulesThimbles
            {
                Left = Left,
                Top = Top
            };
            formSR.ShowDialog();
        }

        /// <summary>
        /// Функция для отображения информации об игре
        /// </summary>
        public void ShowInfo()
        {
            // показываем информацию об игре
            var formAT = new FormAboutThimbles
            {
                Left = Left,
                Top = Top
            };
            formAT.ShowDialog();
        }

        /// <summary>
        /// Проверка на победу, на окончание игры
        /// </summary>
        /// <returns>true - в случае финиша, false - в случае продолжения игры</returns>
        public bool IsFinish()
        {
            // запрет клика
            pbBackground.Click += null;
            // проверка выбора
            // если верный
            if (choise == bPos)
            {
                // увеличиваем уровень
                level++;
                label.Text = "Уровень: " + level.ToString();
                // увеличиваем скорость
                if (level % 4 == 0)
                {
                    v++;
                }
                // перемешиваем
                Shuffle();
            }
            else
            {
                // диалог с пользователем
                DialogResult result = MessageBox.Show("Начать новую игру?", "Неверно!", MessageBoxButtons.YesNo);
                v = 2;
                level = 1;
                label.Text = "Уровень: " + level.ToString();
                if (result == DialogResult.No)
                {
                    Close();
                    return true;
                }
                Animate();
            }
            return false;
        }

        /// <summary>
        /// Функция для обработки события клика по кнопке "Сохранить"
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // сохранение игры
            SaveGame();
        }

        /// <summary>
        /// Обработчик события клика по кнопке "Открыть"
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            // открыть игру
            buttonStartGame.Enabled = false;
            buttonRules.Enabled = false;
            buttonAbout.Enabled = false;
            OpenGame();
        }

        /// <summary>
        /// Обработчик события клика по кнопке "Правила"
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void ButtonRules_Click(object sender, EventArgs e)
        {
            // показать правила
            ShowRules();
        }
    }
}