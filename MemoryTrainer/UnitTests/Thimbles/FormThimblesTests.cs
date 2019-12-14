using System.Drawing;
using System.Runtime.InteropServices;
using Memory_Trainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests.Thimbles
{
    [TestFixture]
    class FormThimblesTests
    {
        private FormThimbles form = new FormThimbles();

        [Test]
        public void TestMethodFormThimbles_Load()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("FormThimbles_Load", null, new object[]{null, null});
        }

        [Test]
        public void TestMethodButtonAbout_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("ButtonAbout_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodButtonStartGame_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("ButtonStartGame_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodTimerOneToTop_Tick()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("TimerOneToTop_Tick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodTimerShuffle_Tick()
        {
            PrivateObject po = new PrivateObject(form);
            Rectangle[] rect = new Rectangle[]
            {
                new Rectangle(0,0,0,0), 
                new Rectangle(0,0,0,0), 
                new Rectangle(0,0,0,0), 
            };
            po.SetField("thimbles",rect);
            po.SetField("ind1",0);
            po.SetField("x2",0);
            po.SetField("y2",0);
            po.Invoke("TimerShuffle_Tick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodButtonRules_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("ButtonRules_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodButtonOpen_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("ButtonOpen_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodButtonSave_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("ButtonSave_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodOpenGame()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("OpenGame");
        }

        [Test]
        public void TestMethodSaveGame()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("SaveGame");
        }

        [Test]
        public void TestMethodFormThimbles_Click()
        {
            PrivateObject po = new PrivateObject(form);
            po.SetField("isAnimation", true);
            po.Invoke("FormThimbles_Click", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodTimerCheckWin_Tick()
        {
            PrivateObject po = new PrivateObject(form);
            po.SetField("isAnimation", true);
            po.SetField("ball_image", new Bitmap(100, 100));
            po.SetField("ball_rect", new Rectangle(100, 100, 100, 100));
            po.SetField("thimble_image", new Bitmap(100, 100));
            var thimbles = new Rectangle[3];
            po.SetField("thimbles", thimbles);
            po.Invoke("TimerCheckWin_Tick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodDrawField()
        {
            PrivateObject po = new PrivateObject(form);
            po.SetField("isAnimation", true);
            po.SetField("ball_image", new Bitmap(100, 100));
            po.SetField("ball_rect", new Rectangle(100, 100, 100,100));
            po.SetField("thimble_image", new Bitmap(100, 100));
            var thimbles = new Rectangle[3];
            po.SetField("thimbles", thimbles);
            po.Invoke("DrawField");
        }

        [Test]
        public void TestMethodIsFinish()
        {
            PrivateObject po = new PrivateObject(form);
            po.SetField("choise", 2);
            po.SetField("bPos", 1);
            Assert.AreEqual(form.IsFinish(), false);
        }

        [Test]
        public void TestMethodShuffle()
        {
            PrivateObject po = new PrivateObject(form);
            po.Invoke("Shuffle");
        }

        [Test]
        public void TestMethodDispose()
        {
            PrivateObject po = new PrivateObject(form);
            form.Dispose();
        }
    }
}
