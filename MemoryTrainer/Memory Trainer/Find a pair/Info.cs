using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    class Info
    {
        private Label _infoLbl;
        private Button _backBtn;
        private Control _control;
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

        private void Dispose()
        {
            _infoLbl.Dispose();
            _backBtn.Dispose();
        }

        private void ButtonMouseClick(object sender, EventArgs e)
        {
            Dispose();
            _control.Visible = true;
        }
    }
}
