using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using Memory_Trainer.Find_a_pair;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.FindAPair
{
    [TestFixture]
    class LevelTest
    {
        private static readonly PrivateFontCollection _font = new PrivateFontCollection();
        private Level level;

        [Test]
        public void TestMethodTimerSaveGameTick()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.SetField("_timeSaveGame", 1);
            po.Invoke("TimerSaveGameTick", null, new object[] { null, null });
            po.SetField("_timeSaveGame", 2);
            po.Invoke("TimerSaveGameTick", null, new object[] { null, null });
        }
        [Test]
        public void TestMethodSaveBtnClick()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.Invoke("SaveBtnClick", null, new object[] { null, null });

        }

        [Test]
        public void TestMethodGetCountPair()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            for (int i = 1; i < 10; i++)
            {
                Assert.AreEqual(Convert.ToInt32(po.Invoke("GetCountPair", i)), GetCountPair(i));
            }

            GetCountPair(10);
        }

        [Test]
        public void TestMethodTimerOpenCardOnTick()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.SetField("_timeOpenCard", 1);
            po.SetField("_openCard", new List<int> { 0, 1 });
            List<Card> cards = new List<Card>
            {
                new Card(new Bitmap(200,200), new Bitmap(200,200), 0, null),
                new Card(new Bitmap(200,200), new Bitmap(200,200), 0, null),
            };
            po.SetField("_cards", cards);
            po.Invoke("TimerOpenCardOnTick", null, new object[] { null, null });
            Level level1 = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            po = new PrivateObject(level1);
            po.SetField("_timeOpenCard", 1);
            po.SetField("_openCard", new List<int> { 0, 1 });
            cards = new List<Card>
            {
                new Card(new Bitmap(200,200), new Bitmap(200,200), 1, null),
                new Card(new Bitmap(200,200), new Bitmap(200,200), 0, null),
            };
            po.SetField("_cards", cards);
            po.Invoke("TimerOpenCardOnTick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodTimerOnTick()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.Invoke("TimerOnTick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodDispose()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.Invoke("Dispose");
        }

        [Test]
        public void TestMethodOpenGame()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            SaveGame();
            po.Invoke("OpenGame");
        }

        [Test]
        public void TestMethodEndGame()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.Invoke("EndGame");
        }

        [Test]
        public void TestMethodEndGameBtnClick()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.Invoke("EndGameBtnClick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodDrawField()
        {
            LoadFont();
            level = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            PrivateObject po = new PrivateObject(level);
            po.Invoke("DrawField");
            Level level1 = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            po = new PrivateObject(level1);
            po.SetField("_countPair", 6);
            po.Invoke("DrawField");
            Level level2 = new Level(1, new PictureBox(), _font, OpeningРarameter.New);
            po = new PrivateObject(level2);
            po.SetField("_countPair", 7);
            po.Invoke("DrawField");
        }


        public void SaveGame()
        {
            List<Card> _cards = new List<Card>
            {
                new Card(new Bitmap(200,200), new Bitmap(200,200), 1, null),
                new Card(new Bitmap(200,200), new Bitmap(200,200), 2, null),
            };
            string text = "";
            text += "Level: " + 1 + "\n";
            text += "Count cards: " + 2 + "\n";
            foreach (var card in _cards)
            {
                text += "{\n";
                text += "\tIsDisposed: " + card.Image.IsDisposed + "\n";
                text += "\tLocation: " + card.Image.Location + "\n";
                text += "\tIndexImage: " + card.ImageType + "\n";
                text += "\tIsOpen: " + card.IsOpen + "\n";
                text += "\tScalingFactor: " + card.ScalingFactor + "\n";
                text += "}\n";
            }
            text += "OpenCard: " + 1 + "\n";
            text += "Time: " + 0 + "\n";
            text += "Clicks: " + 0 + "\n";
            text += "OpenPair: " + 0 + "\n";
            text += "Successful save!";
            using (FileStream fstream = new FileStream("SaveFindAPair", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
        }

        private int GetCountPair(int level)
        {
            switch (level)
            {
                case 1:
                    return 2;
                case 2:
                    return 4;
                case 3:
                    return 6;
                case 4:
                    return 9;
                case 5:
                    return 10;
                case 6:
                    return 12;
                case 7:
                    return 14;
                case 8:
                    return 16;
                case 9:
                    return 18;
            }

            return 1;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private void LoadFont()
        {
            byte[] fontData = Properties.Resources.fonto;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            _font.AddMemoryFont(fontPtr, Properties.Resources.fonto.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.fonto.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
        }

    }
}
