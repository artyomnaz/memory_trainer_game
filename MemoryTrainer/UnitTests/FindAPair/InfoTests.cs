using System;
using System.Drawing.Text;
using System.Windows.Forms;
using Memory_Trainer.Find_a_pair;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTests.FindAPair
{
    [TestFixture]
    class InfoTests
    {
        private static readonly PrivateFontCollection _font = new PrivateFontCollection();
        private Info info;

        [Test]
        public void TestMethodButtonMouseClick()
        {
            LoadFont();
            info = new Info(new PictureBox(), "", _font);
            PrivateObject po = new PrivateObject(info);
            po.Invoke("ButtonMouseClick", null, new object[] { null, null });
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
