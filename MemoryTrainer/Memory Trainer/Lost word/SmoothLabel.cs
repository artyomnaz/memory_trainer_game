using System.Drawing.Text;
using System.Windows.Forms;

namespace Memory_Trainer
{
    public class SmoothLabel : Label
    {
        public TextRenderingHint TextRenderingHint { get; set; } = TextRenderingHint.SystemDefault;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint;
            base.OnPaint(e);
        }
    }
}
