using System;
using System.Drawing;
using System.Threading;
using Memory_Trainer.Find_a_pair;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.FindAPair
{
    [TestFixture]
    class CardTests
    {
        private static Bitmap image = new Bitmap(200, 200);
        private static readonly Card card = new Card(image, image, 0, null);
        

        [Test]
        public void TestPropertyImageOpen()
        {
            card.ImageOpen = image;
            Assert.AreEqual(card.ImageOpen,image);
        }
        [Test]
        public void TestPropertyImageClose()
        {
            card.ImageClose = image;
            Assert.AreEqual(card.ImageClose, image);
        }

        [Test]
        public void TestPropertyScalingFactor()
        {
            card.ScalingFactor = 0.5f;
            //Assert.AreEqual(card.Image.Width, image.Width * 0.5f);
            Assert.AreEqual(card.Image.Height, image.Height*0.5f);
        }

        [Test]
        public void TestPropertyIsOpen()
        {
            card.IsOpen = true;
            //PrivateObject po = new PrivateObject(card);
            Assert.AreEqual(card.IsOpen, true);
            card.IsOpen = false;
            Assert.AreEqual(card.IsOpen, false);
        }

        [Test]
        public void TestPropertyImageType()
        {
            //PrivateObject po = new PrivateObject(card);
            Assert.AreEqual(card.ImageType, 0);
        }

        [Test]
        public void TestMethodOnMouseClick()
        {
            PrivateObject po = new PrivateObject(card);

            po.Invoke("OnMouseClick", null,new object[]{null,null});
        }

        [Test]
        public void TestMethodAnimationP()
        {
            PrivateObject po = new PrivateObject(card);
            po.Invoke("Animation", null, new object[] { null});
            var tmp = card.Image.Width;
            card.Image.Width = 0;
            po = new PrivateObject(card);
            po.Invoke("Animation", null, new object[] { null });
            card.Image.Width = tmp;
        }

    }
}
