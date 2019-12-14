using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Trainer.Memory_matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests.MemoryMatrix
{
    [TestFixture]
    class FormMemoryMatrixTests
    {
        private FormMemoryMatrix form = new FormMemoryMatrix();

        [Test]
        public void TestMethodLoadFont()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("LoadFont");
        }

        [Test]
        public void TestMethodFormMemoryMatrix_Load()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("FormMemoryMatrix_Load", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodonClick()
        {
            PrivateObject po = new PrivateObject(form);
            DataGridView dv = new DataGridView();
            dv.ColumnCount = 1;
            var row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewButtonCell());
            dv.Rows.Add(row);
            po.Invoke("onClick", new object[] { dv, null });
        }

        [Test]
        public void TestMethodtimer_Tick()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("timer_Tick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodGameProcess()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("GameProcess",new object []{0, 0});
        }

        [Test]
        public void TestMethodAddCells()
        {
            PrivateObject po = new PrivateObject(form);
            var dgv = new DataGridView();
            dgv.ColumnCount = 5;
            po.SetField("FigureGrid", dgv);
            po.Invoke("AddCells");
        }

        [Test]
        public void TestMethodDrawField()
        {
            PrivateObject po = new PrivateObject(form);
            var pos = new int[5][];
            po.SetField("n", 5);
            po.SetField("pos", pos);
            po.Invoke("DrawField");
        }

        [Test]
        public void TestMethodIsFinish()
        {
            PrivateObject po = new PrivateObject(form);
            Assert.AreEqual(form.IsFinish(), false);
        }

        [Test]
        public void TestMethodSaveGame()
        {
            PrivateObject po = new PrivateObject(form);
            po.SetField("n", 5);
            form.SaveGame();
        }

        [Test]
        public void TestMethodOpenGame()
        {
            PrivateObject po = new PrivateObject(form);
            SaveGame();
            po.SetField("n", 5);
            po.SetField("m", 2);
            po.Invoke("OpenGame");
            //form.OpenGame();
        }

        [Test]
        public void TestMethodShowRules()
        {
            PrivateObject po = new PrivateObject(form);
            form.ShowRules();
        }

        public void SaveGame()
        {
            var Level = 1;
            var key = 55;
            var n = 5;
            var m = 2;
            var delta = 1;
            var pos = new int[5, 5];
            pos[0,0] = 1;
            List<string> SaveList = new List<string>();
            var level_shifr = Level ^ key;
            var n_shifr = n ^ key;
            var m_shifr = m ^ key;
            var delta_shifr = delta ^ key;
            SaveList.Add(level_shifr.ToString());
            SaveList.Add(n_shifr.ToString());
            SaveList.Add(m_shifr.ToString());
            SaveList.Add(delta_shifr.ToString());
            for (int i = 0; i < n; i++)
            {
                string tmp = "";
                for (int j = 0; j < n; j++)
                    tmp += (pos[i,j] ^ key).ToString() + " ";
                SaveList.Add(tmp);
            }

            var SaveArray = SaveList.ToArray();

            System.IO.File.WriteAllLines("MemoryMatrix_save.txt", SaveArray);
        }

        [Test]
        public void TestMethodShowInfo()
        {
            PrivateObject po = new PrivateObject(form);
            form.ShowInfo();
        }

        [Test]
        public void TestMethodSave()
        {
            PrivateObject po = new PrivateObject(form);
            form.Save(null, null);
        }

        [Test]
        public void TestMethodOpen()
        {
            PrivateObject po = new PrivateObject(form);
            form.Open(null, null);
        }

        [Test]
        public void TestMethodRules()
        {
            PrivateObject po = new PrivateObject(form);
            form.Rules(null, null);
        }

        [Test]
        public void TestMethodInfo()
        {
            PrivateObject po = new PrivateObject(form);
            form.Info(null, null);
        }
    }
}
