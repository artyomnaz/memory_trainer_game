using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Trainer.Memory_matrix;

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
            return;
        }

        private void buttonQuadShulte_Click(object sender, EventArgs e)
        {
            return;
        }

        private void buttonMemoryMatrix_Click(object sender, EventArgs e)
        {
            FormMemoryMatrix formMemoryMatrix = new FormMemoryMatrix();
            Hide();
            formMemoryMatrix.ShowDialog();
            Show();
        }

        private void buttonThimbles_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
