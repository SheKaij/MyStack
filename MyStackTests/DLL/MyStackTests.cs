using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStack.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack.DLL.Tests
{
    [TestClass()]
    public class MyStackTests
    {
        private MyStack TestStack;

        [TestMethod()]
        public void PushTest()
        {
            TestStack = new MyStack(10);
            TestStack.Push(10);
            Assert.AreEqual(1, TestStack.Count);
            Assert.AreEqual(10, TestStack.Peek);
        }

        [TestMethod()]
        public void PushTest2()
        {
            TestStack = new MyStack(100);
            int n = 50;
            for (int i = 1; i <= n; i++)
            {
                TestStack.Push(i);
            }
            Assert.AreEqual(50, TestStack.Count);
            for (int i = 50; i > 0; i--)
            {
                Assert.AreEqual(i, TestStack.Pop());
            }
            Assert.AreEqual(0, TestStack.Count);
        }

        [TestMethod()]
        public void PushTest3()
        {
            TestStack = new MyStack(100);
            int n = 200;
            for (int i = 1; i <= n; i++)
            {
                TestStack.Push(i);
            }
            Assert.AreEqual(100, TestStack.Count);
            for (int i = 100; i > 0; i--)
            {
                Assert.AreEqual(i, TestStack.Pop());
            }
            Assert.AreEqual(0, TestStack.Count);
        }

        [TestMethod()]
        public void PopTest()
        {
            TestStack = new MyStack(10);
            TestStack.Push(10);
            var item = TestStack.Pop();
            Assert.AreEqual(0, TestStack.Count);
            Assert.AreEqual(10, item);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopTest2()
        {
            TestStack = new MyStack(10);
            var item = TestStack.Pop();
            Assert.AreEqual(0, TestStack.Count);
        }

        [TestMethod()]
        public void PopTest3()
        {
            TestStack = new MyStack(100);
            int n = 50;
            for (int i = 1; i <= n; i++)
            {
                TestStack.Push(i);
            }
            Assert.AreEqual(50, TestStack.Count);
            for (int i = 50; i > 0; i--)
            {
                Assert.AreEqual(i, TestStack.Pop());
            }
            Assert.AreEqual(0, TestStack.Count);
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }
    }
}