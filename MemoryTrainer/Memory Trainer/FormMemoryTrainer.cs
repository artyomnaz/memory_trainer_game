using System;
using System.Windows.Forms;

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
            return;
        }

        private void buttonLostWord_Click(object sender, EventArgs e)
        {
            var formLostWord = new FormLostWord();
            formLostWord.Left = Left;
            formLostWord.Top = Top;
            Hide();
            formLostWord.ShowDialog();
            Show();
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
