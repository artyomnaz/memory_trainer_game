using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory_Trainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class FormMemoryTrainerTests
    {
        FormMemoryTrainer mt = new FormMemoryTrainer();

        [Test]
        public void TestMethodbuttonFindAPair_Click()
        {
            PrivateObject po = new PrivateObject(mt);
            po.Invoke("buttonFindAPair_Click", null, new object[] { null, null });
        }
        [Test]
        public void TestMethodbuttonLostWord_Click()
        {
            PrivateObject po = new PrivateObject(mt);
            po.Invoke("buttonLostWord_Click", null, new object[] { null, null });
        }
        [Test]
        public void TestMethodbuttonQuadShulte_Click()
        {
            PrivateObject po = new PrivateObject(mt);
            po.Invoke("buttonQuadShulte_Click", null, new object[] { null, null });
        }
        [Test]
        public void TestMethodbuttonMemoryMatrix_Click()
        {
            PrivateObject po = new PrivateObject(mt);
            po.Invoke("buttonMemoryMatrix_Click", null, new object[] { null, null });
        }
        [Test]
        public void TestMethodbuttonThimbles_Click()
        {
            PrivateObject po = new PrivateObject(mt);
            po.Invoke("buttonThimbles_Click", null, new object[] { null, null });
        }
    }
}
