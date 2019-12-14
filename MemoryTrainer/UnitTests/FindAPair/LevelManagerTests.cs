using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Trainer.Find_a_pair;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.FindAPair
{
    [TestFixture]
    class LevelManagerTests
    {
        private static readonly PrivateFontCollection _font = new PrivateFontCollection();
        private LevelManager levelManager;

        [Test]
        public void TestPropertyImageOpen()
        {
            LoadFont();
            levelManager = new LevelManager(new PictureBox(), _font);
            levelManager.Enabled = true;
            Assert.AreEqual(levelManager.Enabled, true);
        }

        [Test]
        public void TestMethodLoadGame()
        {
            LoadFont();
            levelManager = new LevelManager(new PictureBox(), _font);
            PrivateObject po = new PrivateObject(levelManager);
            SaveGame();
            po.Invoke("LoadGame");
        }

        [Test]
        public void TestMethodButtonMouseClick()
        {
            LoadFont();
            levelManager = new LevelManager(new PictureBox(), _font);
            PrivateObject po = new PrivateObject(levelManager);
            po.Invoke("ButtonMouseClick",new Type[]{typeof(Button), typeof(MouseEventArgs) }, new object[]{new Button{Text = "1"}, null});
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
