using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    /// <summary>
    /// Класс, отвечающий за отображение информации об игре
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Выводит информацию об игре
        /// </summary>
        private Label _infoLbl;
        /// <summary>
        /// Кнопка возврата в меню
        /// </summary>
        private Button _backBtn;
        /// <summary>
        /// Контрол на котором необходимо отрисовать уровень
        /// </summary>
        private Control _control;
        /// <summary>
        /// Класс Info
        /// </summary>
        /// <param name="control">Контрол на котором необходимо отрисовать уровень</param>
        /// <param name="text">Текст с информацией об игре</param>
        /// <param name="font">Коллекция настраиваемых шрифтов</param>
        public Info(Control control, string text, PrivateFontCollection font)
        {
            _control = control;
            _infoLbl = new Label
            {
                Text = text,
                Font = new Font(font.Families[0], 13),
                Parent = control.Parent,
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            _infoLbl.Location = new Point((1028 - _infoLbl.Width) / 2, 150);
            _backBtn = new Button
            {
                Visible = true,
                Font = new Font(font.Families[0], 15),
                AutoSize = true,
                Parent = control.Parent,
                Text = @"Назад",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Location = new Point(848, 600)
            };
            _backBtn.Click += ButtonMouseClick;
        }
        /// <summary>
        /// Очищающая все контролы для данного класса
        /// </summary>
        private void Dispose()
        {
            _infoLbl.Dispose();
            _backBtn.Dispose();
        }
        /// <summary>
        /// Функция возвращающая в меню
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void ButtonMouseClick(object sender, EventArgs e)
        {
            Dispose();
            _control.Visible = true;
        }
    }
}
