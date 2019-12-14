using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory_Trainer;
using NUnit.Framework;

namespace UnitTests.Thimbles
{
    [TestFixture]
    class FormAboutThimblesTests
    {
        private FormAboutThimbles fat = new FormAboutThimbles();

        [Test]
        public void TestMethodConstructorFormAboutThimbles()
        {
            fat.Dispose();
        }
    }
}
