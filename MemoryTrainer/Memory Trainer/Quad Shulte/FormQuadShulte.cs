using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Trainer.Quad_Shulte
{
    public partial class FormQuadShulte : Form,IGameInterface
    {
        int time;
        public FormQuadShulte()
        {
            InitializeComponent();
        }

        public void DrawField()
        {
            throw new NotImplementedException();
        }

        public bool IsFinish()
        {
            throw new NotImplementedException();
        }

        public void OpenGame()
        {
            throw new NotImplementedException();
        }

        public void SaveGame()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        public void ShowRules()
        {
            throw new NotImplementedException();
        }

        private void FormQuadShulte_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int minute, sec;
            minute = time / 60;
            sec = time % 60;
            label3.Text = minute.ToString() + ':' + sec.ToString();
            time++;
        }
    }
}
