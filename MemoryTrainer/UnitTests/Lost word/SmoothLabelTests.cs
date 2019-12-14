using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Trainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.Lost_word
{
    [TestFixture]
    class SmoothLabelTests
    {
        SmoothLabel sl = new SmoothLabel();
        [Test]
        public void TestPropertyTextRenderingHint()
        {
            sl.TextRenderingHint = TextRenderingHint.AntiAlias;
            Assert.AreEqual(sl.TextRenderingHint, TextRenderingHint.AntiAlias);
            sl.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            Assert.AreEqual(sl.TextRenderingHint, TextRenderingHint.AntiAliasGridFit);
            sl.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Assert.AreEqual(sl.TextRenderingHint, TextRenderingHint.ClearTypeGridFit);
            sl.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            Assert.AreEqual(sl.TextRenderingHint, TextRenderingHint.SingleBitPerPixel);
            sl.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            Assert.AreEqual(sl.TextRenderingHint, TextRenderingHint.SingleBitPerPixelGridFit);
            sl.TextRenderingHint = TextRenderingHint.SystemDefault;
            Assert.AreEqual(sl.TextRenderingHint, TextRenderingHint.SystemDefault);
        }
        [Test]
        public void TestMethodOnPaint()
        {
           PrivateObject po = new PrivateObject(sl);
           po.Invoke("OnPaint", new Type[] {typeof(PaintEventArgs)}, new object[]
           {
               new PaintEventArgs(Graphics.FromImage(Properties.Resources.Back), new Rectangle(10,10,10,10))
           });
        }
    }
}
