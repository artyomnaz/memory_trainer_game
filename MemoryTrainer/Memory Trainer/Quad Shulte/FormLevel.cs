using System;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{ 
    public partial class FormLevel : Form
    {
        public int Level,NameGame;
        public bool f;
        public FormLevel()
        {
            InitializeComponent();
            Level = 0;
            f = false;
            NameGame = 0;
        }

        private void Level1Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();    
            NameGame = 1;
        }

        private void Level2Button_Click(object sender, EventArgs e)
        {
            Level = 7;
            f = true;
            Close();
            NameGame = 1;
        }

        private void Level31Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();
            NameGame = 3;
        }

        private void Level32Button_Click(object sender, EventArgs e)
        {
            Level = 7;
            f = true;
            Close();
            NameGame = 3;
        }

        private void Level33Button_Click(object sender, EventArgs e)
        {
            Level = 9;
            f = true;
            Close();
            NameGame = 3;
        }

        private void Level21Button_Click(object sender, EventArgs e)
        {
            Level = 3;
            f = true;
            Close();
            NameGame = 2;
        }

        private void Level22Button_Click(object sender, EventArgs e)
        {
            Level = 4;
            f = true;
            Close();
            NameGame = 2;
        }

        private void Level23Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();
            NameGame = 2;
        }

        private void Level41Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            f = true;
            Close();
            NameGame = 4;
        }

        private void Level42Button_Click(object sender, EventArgs e)
        {
            Level = 7;
            f = true;
            Close();
            NameGame = 4;
        }

        private void Level43Button_Click(object sender, EventArgs e)
        {
            Level = 9;
            f = true;
            Close();
            NameGame = 4;
        }

        private void Level3Button_Click(object sender, EventArgs e)
        {
            Level = 9;
            f = true;
            Close();
            NameGame = 1;
        }
    }
}
