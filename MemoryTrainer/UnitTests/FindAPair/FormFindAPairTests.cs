using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Trainer.Find_a_pair;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTests.FindAPair
{
    [TestFixture]
    class FormFindAPairTests
    {
        private static readonly PrivateFontCollection _font = new PrivateFontCollection();
        private FormFindAPair ffaf;
        [Test]
        public void TestMethodTimerTick()
        {
            LoadFont();
            ffaf = new FormFindAPair();
            PrivateObject po = new PrivateObject(ffaf);
            po.SetField("_time", 1);
            po.Invoke("TimerTick", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodOpenRules()
        {
            LoadFont();
            ffaf = new FormFindAPair();
            PrivateObject po = new PrivateObject(ffaf);
            po.Invoke("OpenRules", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodLoadGame()
        {
            LoadFont();
            ffaf = new FormFindAPair();
            PrivateObject po = new PrivateObject(ffaf);
            po.Invoke("LoadGame", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodOpenInfo()
        {
            LoadFont();
            ffaf = new FormFindAPair();
            PrivateObject po = new PrivateObject(ffaf);
            po.Invoke("OpenInfo", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodReturnToMenu()
        {
            LoadFont();
            ffaf = new FormFindAPair();
            ffaf.Owner = new Form();
            PrivateObject po = new PrivateObject(ffaf);
            po.Invoke("ReturnToMenu", null, new object[] { null, null });
        }

        [Test]
        public void TestMethodFormFindAPair_FormClosed()
        {
            LoadFont();
            ffaf = new FormFindAPair();
            ffaf.Owner = new Form();
            PrivateObject po = new PrivateObject(ffaf);
            po.Invoke("FormFindAPair_FormClosed", null, new object[] { null, null });
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
