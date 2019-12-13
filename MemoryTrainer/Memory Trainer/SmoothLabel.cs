using System.Drawing.Text;
using System.Windows.Forms;

namespace Memory_Trainer
{
    /// <summary>
    /// Класс со сглаженным текстом, наследованный от Label
    /// </summary>
    public class SmoothLabel : Label
    {
        /// <summary>
        /// Сглаживание текста
        /// </summary>
        public TextRenderingHint TextRenderingHint { get; set; } = TextRenderingHint.SystemDefault;

        /// <summary>
        /// Функция включения сглаживания при рисовании
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint;
            base.OnPaint(e);
        }
    }
}
