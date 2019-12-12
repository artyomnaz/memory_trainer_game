using System;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{ 
    /// <summary>
    /// Класс для формы с уровнями
    /// </summary>
    public partial class FormLevel : Form
    {
        /// <summary>
        /// Переменная для хранения уровня
        /// </summary>
        public int Level;
        /// <summary>
        /// Переменная для хранения номера игры
        /// </summary>
        public int NameGame;
        /// <summary>
        /// Переменная для хранения того, какая игра запущена
        /// </summary>
        public bool f;
        /// <summary>
        /// Конструктор FormLevel
        /// </summary>
        public FormLevel()
        {
            InitializeComponent();
            Level = 0;
            f = false;
            NameGame = 0;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 1ой игры и 1ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level1Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();    
            NameGame = 1;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 1ой игры и 2ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level2Button_Click(object sender, EventArgs e)
        {
            Level = 7;
            f = true;
            Close();
            NameGame = 1;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 3ей игры и 1ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level31Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();
            NameGame = 3;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 3ей игры и 2ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level32Button_Click(object sender, EventArgs e)
        {
            Level = 7;
            f = true;
            Close();
            NameGame = 3;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 3ей игры и 3ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level33Button_Click(object sender, EventArgs e)
        {
            Level = 9;
            f = true;
            Close();
            NameGame = 3;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 2ой игры и 1ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level21Button_Click(object sender, EventArgs e)
        {
            Level = 3;
            f = true;
            Close();
            NameGame = 2;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 2ой игры и 2ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level22Button_Click(object sender, EventArgs e)
        {
            Level = 4;
            f = true;
            Close();
            NameGame = 2;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 2ой игры и 3ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level23Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();
            NameGame = 2;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 4ой игры и 1ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level41Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();
            NameGame = 4;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 4ой игры и 2ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level42Button_Click(object sender, EventArgs e)
        {
            Level = 7;
            f = true;
            Close();
            NameGame = 4;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 4ой игры и 3ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level43Button_Click(object sender, EventArgs e)
        {
            Level = 9;
            f = true;
            Close();
            NameGame = 4;
        }
        /// <summary>
        /// Функция для обработки события нажатия на кнопку 1ой игры и 3ого уровня
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Level3Button_Click(object sender, EventArgs e)
        {
            Level = 9;
            f = true;
            Close();
            NameGame = 1;
        }
    }
}
