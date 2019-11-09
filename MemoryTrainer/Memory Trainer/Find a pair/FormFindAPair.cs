using System;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public partial class FormFindAPair : Form, IGameInterface
    {
        public FormFindAPair()
        {
            InitializeComponent();
        }

        public void SaveGame()
        {
            throw new NotImplementedException();
        }

        public void OpenGame()
        {
            throw new NotImplementedException();
        }

        public void ShowRules()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        public void DrawField()
        {
            throw new NotImplementedException();
        }

        public bool IsFinish()
        {
            throw new NotImplementedException();
        }

        private void FormFindAPair_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }
    }
}
