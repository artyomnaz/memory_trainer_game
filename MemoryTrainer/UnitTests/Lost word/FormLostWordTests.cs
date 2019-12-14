using System;
using System.Collections.Generic;
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
    class FormLostWordTests
    {
        FormLostWord flw = new FormLostWord();

        [Test]
        public void TestMethodLoadFont()
        { 
            PrivateObject po = new PrivateObject(flw);
            po.Invoke("LoadFont");
        }

        [Test]
        public void TestMethodWindow_Close()
        {
            PrivateObject po = new PrivateObject(flw);
            po.Invoke("Window_Close", new object[] { new SmoothLabel{Parent = new Control("")}, null });
        }

        [Test]
        public void TestMethodButtons_Click()
        {
            PrivateObject po = new PrivateObject(flw);
            po.Invoke("Buttons_Click", new object[] { new SmoothLabel { Text = "Начать"}, null });
           po.SetField("labelRes", new SmoothLabel());
           po.SetField("scoreLabel", new SmoothLabel());
            po.Invoke("Buttons_Click", new object[] { new SmoothLabel { Text = "Продолжить" }, null });
            po.Invoke("Buttons_Click", new object[] { new SmoothLabel { Text = "Правила игры" }, null });
            po.Invoke("Buttons_Click", new object[] { new SmoothLabel { Text = "Об игре" }, null });
            po.Invoke("Buttons_Click", new object[] { new SmoothLabel { Text = "Сохранить" }, null });
            po.Invoke("Buttons_Click", new object[] { new SmoothLabel { Text = "Выход" }, null });
            po.Invoke("Buttons_Click", new object[] { new SmoothLabel { Text = "Загрузить" }, null });
        }

        [Test]
        public void TestMethodIsFinish()
        {
            Assert.AreEqual(flw.IsFinish(), true);
        }

        [Test]
        public void TestMethodCreateBlocks()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.smoothLabels = new List<SmoothLabel>();
            po.Invoke("CreateBlocks", new object[] { "word", 10, 10});
        }

        [Test]
        public void TestMethodChangeBackMouseEnter()
        {
            PrivateObject po = new PrivateObject(flw);
            po.Invoke("ChangeBackMouseEnter", new object[] { new Label(), null});
        }

        [Test]
        public void TestMethodChangeBackMouseLeave()
        {
            PrivateObject po = new PrivateObject(flw);
            po.Invoke("ChangeBackMouseLeave", new object[] { new Label(), null });
        }

        [Test]
        public void TestMethodTimerIntro_Tick()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.timerValue = 4;
            po.Invoke("TimerIntro_Tick", new object[] { null, null });
        }
        
        [Test]
        public void TestMethodDispose()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.smoothLabels = new List<SmoothLabel>
            {
                new SmoothLabel()
            };
            flw.smoothTimers = new List<SmoothLabel>{
                new SmoothLabel()
            }; ;
            flw.smoothAnswers = new List<SmoothLabel>{
                new SmoothLabel()
            }; ;
            po.Invoke("Dispose");
        }

        [Test]
        public void TestMethodTimerCreateBlock_Tick()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.words = new[] {"a", "b"};
            flw.blockPositions = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                flw.blockPositions[i] = new int[2];
                flw.blockPositions[i][0] = 0;
                flw.blockPositions[i][1] = 0;
            }
            flw.timerValue = 4;
            flw.smoothLabels = new List<SmoothLabel>();
            flw.smoothTimers = new List<SmoothLabel>();
            flw.numberWords = new int[]{0, 1,1 ,1 , 1};
            po.Invoke("TimerCreateBlock_Tick", new object[] { null, null });
        }

        [Test]
        public void TestMethodTimerCountDown_Tick()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.timerValue = 4;
            flw.smoothTimers = new List<SmoothLabel>
            {
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
            };
            flw.smoothLabels = new List<SmoothLabel>
            {
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
            };
            po.Invoke("TimerCountDown_Tick", new object[] { null, null });
            flw.timerValue = 1;
            po.Invoke("TimerCountDown_Tick", new object[] { null, null });
            flw.timerValue = 0;
            po.Invoke("TimerCountDown_Tick", new object[] { null, null });
            flw.timerValue = -1;
            po.Invoke("TimerCountDown_Tick", new object[] { null, null });
            flw.timerValue = -2;
            po.Invoke("TimerCountDown_Tick", new object[] { null, null });
            flw.timerValue = -3;
            po.Invoke("TimerCountDown_Tick", new object[] { null, null });
        }

        [Test]
        public void TestMethodTimerFind_Tick()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.timerValue = 4;
            flw.labelFind = new SmoothLabel();
            po.Invoke("TimerFind_Tick", new object[] { null, null });
            flw.timerValue = 5;
            flw.numberWords = new int[]{1, 2, 3, 4, 5};
            flw.smoothLabels = new List<SmoothLabel>
            {
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
            };
            po.Invoke("TimerFind_Tick", new object[] { null, null });
            flw.timerValue = 6;
            po.Invoke("TimerFind_Tick", new object[] { null, null });
        }

        [Test]
        public void TestMethodTimerShowBlock_Tick()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.smoothLabels = new List<SmoothLabel>
            {
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
            };
            po.Invoke("TimerShowBlock_Tick", new object[] { null, null });
            flw.timerValue = 6;
            flw.numberAnswers = new List<int>
            {
                -1
            };
            flw.numberWords = new int[] { 1};
            flw.smoothAnswers = new List<SmoothLabel>();
            po.Invoke("TimerShowBlock_Tick", new object[] { null, null });
            
        }

        [Test]
        public void TestMethodAnswer_Click()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.smoothLabels = new List<SmoothLabel>
            {
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
            };
            flw.timerValue = 6;
            flw.numberAnswers = new List<int>
            {
                -1
            };
            flw.curIndex = 0;
            flw.numberWords = new int[] { 0 };
            flw.words = new[] {"1"};
            flw.smoothAnswers = new List<SmoothLabel>
            {
                new SmoothLabel()
            };

            po.Invoke("Answer_Click", new object[] { new SmoothLabel{Text =  "1"}, null });

        }

        [Test]
        public void TestMethodTimerFinish_Tick()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.smoothLabels = new List<SmoothLabel>
            {
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
                new SmoothLabel(),
            };
            flw.timerValue = 1;
            flw.smoothAnswers = new List<SmoothLabel>
            {
                new SmoothLabel()
            };

            po.Invoke("TimerFinish_Tick", new object[] { null, null });
            flw.timerValue = 2;
            po.Invoke("TimerFinish_Tick", new object[] { null, null });
            flw.timerValue = 3;
            po.Invoke("TimerFinish_Tick", new object[] { null, null });

        }

        [Test]
        public void TestMethodTimerSave_Tick()
        {
            PrivateObject po = new PrivateObject(flw);
            flw.timerValue = 2;
            flw.labelSave = new SmoothLabel();
            po.Invoke("TimerSave_Tick", new object[] { null, null });

        }
    }
}
