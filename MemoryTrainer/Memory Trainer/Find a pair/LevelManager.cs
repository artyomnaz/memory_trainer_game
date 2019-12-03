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
    public class LevelManager
    {
        private Level level;
        private Control _control;
        private Label NameGame;
        private Label ChooseLevel;
        private List<Button> BtnsLvl;
        private PrivateFontCollection _font;

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
        private void ButtonMouseClick(object sender, MouseEventArgs e)
        {
            ((PictureBox) _control).Visible = false;
            level = new Level(Convert.ToInt32(((Button)sender).Text), _control, _font, this);
            level.DrawField();
        }
        
    }
}