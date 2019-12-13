using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Trainer.Memory_matrix
{
    /// <summary>
    /// Класс формы с информацией о правилах для игры "Матрицы памяти"
    /// </summary>
    public partial class FormRules : Form
    {
        /// <summary>
        /// Label для правил
        /// </summary>
        private Label Label;
        /// <summary>
        /// Шрифты 
        /// </summary>
        private PrivateFontCollection private_fonts;

        /// <summary>
        /// Конструктор FormRules
        /// </summary>
        /// <param name="fonts">Шрифты</param>
        public FormRules(PrivateFontCollection fonts)
        {
            InitializeComponent();
            private_fonts = fonts;
            Label = new Label();
            Label.Parent = this;
        }

        /// <summary>
        /// Функция загрузки формы
        /// </summary>
        /// <param name="sender">Объект, который в обработке</param>
        /// <param name="e">Аргументы события</param>
        private void FormRules_Load(object sender, EventArgs e)
        {
            Label.BackColor = Color.Transparent;
            Label.UseCompatibleTextRendering = true;
            Label.Left = 10;
            Label.Top = 40;
            Label.Width = 600;
            Label.Height = 400;
            Label.ForeColor = Color.Black;
            Label.Font = new Font(private_fonts.Families[0], 20F);
            Label.BackColor = Color.Transparent;
            Label.Text = "Игра «Матрица памяти» построена на простом и понятном алгоритме – необходимо запоминать положение указанных объектов. На игровом поле будут появляться закрашенные квадратики. Ваша задача будет запомнить их место расположения и точно воспроизвести, когда они пропадут. С увеличением уровня будет увеличиваться игровое поле и число закрашенных квадратиков. ";

        }
    }
}
