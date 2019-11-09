using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Memory_Trainer.Find_a_pair;

namespace Memory_Trainer
{
    public partial class FormMemoryTrainer : Form
    {
        public FormMemoryTrainer()
        {
            InitializeComponent();
        }

        private void buttonFindAPair_Click(object sender, EventArgs e)
        {
            FormFindAPair game = new FormFindAPair();
            game.Owner = this;
            game.Show();
            Hide();
        }

        private void buttonLostWord_Click(object sender, EventArgs e)
        {
            return;
        }

        private void buttonQuadShulte_Click(object sender, EventArgs e)
        {
            return;
        }

        private void buttonMemoryMatrix_Click(object sender, EventArgs e)
        {
            return;
        }

        private void buttonThimbles_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
