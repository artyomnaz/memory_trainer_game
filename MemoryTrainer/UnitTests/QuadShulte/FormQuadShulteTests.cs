using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Trainer.Quad_Shulte;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.QuadShulte
{
    [TestFixture]
    class FormQuadShulteTests
    {
        private FormQuadShulte form = new FormQuadShulte();

        [Test]
        public void TestMethodDispose()
        {
            form.Dispose();
        }

        [Test]
        public void TestMethodGame()
        {
            FormQuadShulte form = new FormQuadShulte();
            PrivateObject po = new PrivateObject(form);
            po.Invoke("Game", 1, 1);
        }

        [Test]
        public void TestMethodShowInfo()
        {
            FormQuadShulte form = new FormQuadShulte();

            PrivateObject po = new PrivateObject(form);
            po.Invoke("ShowInfo");
        }

        [Test]
        public void TestMethodShowRules()
        {
            FormQuadShulte form = new FormQuadShulte();

            PrivateObject po = new PrivateObject(form);
            po.Invoke("ShowRules");
        }

        [Test]
        public void TestMethodtimer1_Tick()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("timer1_Tick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodbutton3_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("button3_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodbutton5_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("button5_Click", null, new object[] { null, null });
        }


        [Test]
        public void TestMethodNewGamebutton_Click()
        {
            FormQuadShulte form = new FormQuadShulte();

            PrivateObject po = new PrivateObject(form);
            po.Invoke("NewGamebutton_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodDownloadbutton_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("Downloadbutton_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodSavebutton_Click()
        {
            FormQuadShulte form = new FormQuadShulte();

            PrivateObject po = new PrivateObject(form);
            form.NameGame = 4;
            po.Invoke("Savebutton_Click", null, new object[] { null, null });
            form.NameGame = 3;
            po.Invoke("Savebutton_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethoddataGridView1_CellClick()
        {
            PrivateObject po = new PrivateObject(form);
            var dgv = new DataGridView();
            DataGridViewButtonColumn[] buttonColumn = new DataGridViewButtonColumn[2];
            dgv.RowTemplate.Height = dgv.Height / 2 - 1;
            dgv.RowCount = 2;
            for (int i = 0; i < 2; i++)
            {
                buttonColumn[i] = new DataGridViewButtonColumn();
                dgv.Columns.Add(buttonColumn[i]);
                buttonColumn[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                buttonColumn[i].FlatStyle = FlatStyle.Popup;
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dgv[i,j].Value = Convert.ToChar(190).ToString();
                }
            }
            
            po.SetField("num", 190);
            
            form.NameGame = 2;
            po.Invoke("dataGridView1_CellClick", new Type[] {typeof(object), typeof(DataGridViewCellEventArgs) }, new object[] { new object(), new DataGridViewCellEventArgs(0, 0) });
            form.NameGame = 4;
            po.Invoke("dataGridView1_CellClick", new Type[] { typeof(object), typeof(DataGridViewCellEventArgs) }, new object[] { new object(), new DataGridViewCellEventArgs(0, 0) });
        }

        [Test]
        public void TestMethodFormQuadShulte_FormClosed()
        {
            PrivateObject po = new PrivateObject(form);
            form.Owner = new Form();
            po.Invoke("FormQuadShulte_FormClosed", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodSaveGame()
        {
            FormQuadShulte form = new FormQuadShulte();

            PrivateObject po = new PrivateObject(form);
            form.SaveGame();
        }

        [Test]
        public void TestMethodFormWin()
        {
            var temp = new FormWin();
            temp.Dispose();
        }

        [Test]
        public void TestMethoddataGridView1_SelectionChanged_1()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("dataGridView1_SelectionChanged_1", null, new object[] { null, null });
            form.Dispose();
        }

        [Test]
        public void TestMethodIsFinish()
        {
            FormQuadShulte form = new FormQuadShulte();

            form.Level = 1;
            PrivateObject po = new PrivateObject(form);
            po.SetField("num", 2);
            Assert.AreEqual(form.IsFinish(), true);

            form.NameGame = 2;
            form.Level = 1;
            po.SetField("num", 1073);
            Assert.AreEqual(form.IsFinish(), true);

            form.NameGame = 4;
            form.Level = 1;
            po.SetField("num", 2);
            Assert.AreEqual(form.IsFinish(), true);
        }

        [Test]
        public void TestMethodOpenGame()
        {
            FormQuadShulte form = new FormQuadShulte();
            PrivateObject po = new PrivateObject(form);
            form.SaveGame();

            var lines = new[] { "0",
                "7",
                "2",
                "6",
                "1075",
                "т в ф ц г",
                "у л ч а и",
                "й ш е с о",
                "х ж б р к",
                "м д п н з" };
            po.SetField("key", 2);
            System.IO.File.WriteAllLines("QuadShulte_save.txt", lines);
            form.OpenGame();
            po.Invoke("OpenGame");/*
            lines = new[] { "1",
                "7",
                "2",
                "6",
                "1075",
                "т в ф ц г",
                "у л ч а и",
                "й ш е с о",
                "х ж б р к",
                "м д п н з" };

            System.IO.File.WriteAllLines("QuadShulte_save.txt", lines);
            form.OpenGame();
            lines = new[] { "2",
                "7",
                "2",
                "6",
                "1075",
                "т в ф ц г",
                "у л ч а и",
                "й ш е с о",
                "х ж б р к",
                "м д п н з" };
            System.IO.File.WriteAllLines("QuadShulte_save.txt", lines);
            form.OpenGame();*/

        }

        [Test]
        public void TestMethodDrawField()
        {
            FormQuadShulte form = new FormQuadShulte();

            PrivateObject po = new PrivateObject(form);
            form.NameGame = 4;
            po.Invoke("DrawField");
            form.NameGame = 3;
            po.Invoke("DrawField");
        }

    }
}
