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
    /// Класс для информации об игре "Матрицы памяти"
    /// </summary>
    public partial class FormInfo : Form
    {
        /// <summary>
        /// Label для информации об игре
        /// </summary>
        private Label Label;
        /// <summary>
        /// Шрифты
        /// </summary>
        private PrivateFontCollection private_fonts;

        /// <summary>
        /// Конструктор FormAbout
        /// </summary>
        /// <param name="fonts">Шрифты</param>
        public FormInfo(PrivateFontCollection fonts)
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
        private void FormInfo_Load(object sender, EventArgs e)
        {
            Label.BackColor = Color.Transparent;
            Label.UseCompatibleTextRendering = true;
            Label.Left = 10;
            Label.Top = 150;
            Label.Width = 600;
            Label.Height = 400;
            Label.ForeColor = Color.Black;
            Label.Font = new Font(private_fonts.Families[0], 20F);
            Label.BackColor = Color.Transparent;
            Label.Text = "Игра была разработана\n Тибелиус Яниной Олесьевной \nстуденткой группы ЕТ-412";

        }
    }
}
