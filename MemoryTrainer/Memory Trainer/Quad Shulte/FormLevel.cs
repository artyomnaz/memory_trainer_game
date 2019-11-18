using System;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{ 
    public partial class FormLevel : Form
    {
        public int Level;
        public FormLevel()
        {
            InitializeComponent();
            Level = 0;
        }

        private void Level1Button_Click(object sender, EventArgs e)
        {
            Level = 5;
            Close();
        }

        private void Level2Button_Click(object sender, EventArgs e)
        {
            Level = 7;
            Close();
        }

        private void Level3Button_Click(object sender, EventArgs e)
        {
            Level = 9;
            Close();
        }
    }
}
