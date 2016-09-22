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
        private MyStack _testStack;
        private const int StackSize = 10; // bigger than 2
        private const int RandomInt = 79; // RandomInt + RandomInt2 < int.MaxValue
        private const int RandomInt2 = 91;

        [TestMethod()]
        public void PushTest()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(RandomInt);
            Assert.AreEqual(RandomInt, _testStack.Peek);
        }

        [TestMethod()]
        public void PushTestMore()
        {
            _testStack = new MyStack(StackSize);
            int n = StackSize / 2;
            for (int i = 1; i <= n; i++)
            {
                _testStack.Push(i);
            }
            Assert.AreEqual(n, _testStack.Count);
            for (int i = n; i > 0; i--)
            {
                Assert.AreEqual(i, _testStack.Pop());
            }
        }

        [TestMethod()]
        public void PushTestOverflow()
        {
            _testStack = new MyStack(StackSize);
            int n = StackSize * 2;
            for (int i = 1; i <= n; i++)
            {
                _testStack.Push(i);
            }
            Assert.AreEqual(StackSize, _testStack.Count);
            for (int i = n; i > n - StackSize; i--)
            {
                Assert.AreEqual(i, _testStack.Pop());
            }
        }

        [TestMethod()]
        public void PopTest()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(RandomInt);
            var item = _testStack.Pop();
            Assert.AreEqual(0, _testStack.Count);
            Assert.AreEqual(RandomInt, item);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopTestEmpty()
        {
            _testStack = new MyStack(StackSize);
            var item = _testStack.Pop();
        }

        [TestMethod()]
        public void PopTestMore()
        {
            _testStack = new MyStack(StackSize);
            int n = StackSize / 2;
            for (int i = 1; i <= n; i++)
            {
                _testStack.Push(i);
            }
            for (int i = n; i > 0; i--)
            {
                Assert.AreEqual(i, _testStack.Pop());
            }
            Assert.AreEqual(0, _testStack.Count);
        }

        [TestMethod()]
        public void ClearTest()
        {
            _testStack = new MyStack(StackSize);
            int n = StackSize / 2;
            for (int i = 1; i <= n; i++)
            {
                _testStack.Push(i);
            }
            _testStack.Clear();
            Assert.AreEqual(0, _testStack.Count);
        }

        [TestMethod()]
        public void PeekTest()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(10);
            for (int i = 0; i < StackSize; i++)
            {
                Assert.AreEqual(10, _testStack.Peek);
                Assert.AreEqual(1, _testStack.Count);
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekTestEmpty()
        {
            _testStack = new MyStack(StackSize);
            var item = _testStack.Peek;
        }

        [TestMethod()]
        public void PeekTestMore()
        {
            _testStack = new MyStack(StackSize);
            int n = StackSize / 2;
            for (int i = 1; i <= n; i++)
            {
                _testStack.Push(i);
                Assert.AreEqual(i, _testStack.Peek);
            }
            for (int i = n; i > 0; i--)
            {
                Assert.AreEqual(i, _testStack.Peek);
                _testStack.Pop();
            }
        }

        [TestMethod()]
        public void CountTest()
        {
            _testStack = new MyStack(StackSize);
            int n = StackSize * 2;
            Assert.AreEqual(0, _testStack.Count);
            for (int i = 1; i <= n; i++)
            {
                _testStack.Push(i);
                if (i <= _testStack.MaxSize)
                {
                    Assert.AreEqual(i, _testStack.Count);
                }
                else
                {
                    Assert.AreEqual(_testStack.MaxSize, _testStack.Count);
                }
            }
            for (int i = _testStack.MaxSize; i > 0; i--)
            {
                Assert.AreEqual(i, _testStack.Count);
                _testStack.Pop();
            }
            Assert.AreEqual(0, _testStack.Count);
        }

        [TestMethod()]
        public void TestMaxSize()
        {
            _testStack = new MyStack(StackSize);
            int n = StackSize * 2;
            for (int i = 1; i <= n + 1; i++)
            {
                _testStack.Push(i);
            }
            Assert.AreEqual(_testStack.Count, _testStack.MaxSize);
            _testStack.MaxSize = 10;
            Assert.AreEqual(_testStack.Count, _testStack.MaxSize);
        }

        [TestMethod()]
        public void TestAddTop()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(RandomInt);
            _testStack.Push(RandomInt2);
            var result = _testStack.AddTop();
            Assert.AreEqual(RandomInt + RandomInt2, result);
            Assert.AreEqual(1, _testStack.Count);
            Assert.AreEqual(RandomInt + RandomInt2, _testStack.Peek);
        }

        [TestMethod()]
        public void TestAddTopEmplty()
        {
            _testStack = new MyStack(StackSize);
            var result = _testStack.AddTop();
            Assert.AreEqual(0, result);
            Assert.AreEqual(1, _testStack.Count);
            Assert.AreEqual(0, _testStack.Peek);
        }

        [TestMethod()]
        public void TestAddTopOne()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(RandomInt);
            var result = _testStack.AddTop();
            Assert.AreEqual(RandomInt, result);
            Assert.AreEqual(1, _testStack.Count);
            Assert.AreEqual(RandomInt, _testStack.Peek);
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void TestAddTopOverflow()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(int.MaxValue);
            _testStack.Push(int.MaxValue);
            var result = _testStack.AddTop();
        }

        [TestMethod()]
        public void TestMultiplyTop()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(RandomInt);
            _testStack.Push(RandomInt2);
            var result = _testStack.MultiplyTop();
            Assert.AreEqual(RandomInt * RandomInt2, result);
            Assert.AreEqual(1, _testStack.Count);
            Assert.AreEqual(RandomInt * RandomInt2, _testStack.Peek);
        }

        [TestMethod()]
        public void TestMultiplyTopEmplty()
        {
            _testStack = new MyStack(StackSize);
            var result = _testStack.MultiplyTop();
            Assert.AreEqual(0, result);
            Assert.AreEqual(1, _testStack.Count);
            Assert.AreEqual(0, _testStack.Peek);
        }

        [TestMethod()] public void TestMultplyTopOne()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(RandomInt);
            var result = _testStack.MultiplyTop();
            Assert.AreEqual(RandomInt, result);
            Assert.AreEqual(1, _testStack.Count);
            Assert.AreEqual(RandomInt, _testStack.Peek);
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void TestMultiplyTopOverflow()
        {
            _testStack = new MyStack(StackSize);
            _testStack.Push(int.MaxValue);
            _testStack.Push(int.MaxValue);
            var result = _testStack.MultiplyTop();
        }

        [TestMethod()]
        public void TestAddAll()
        {
            _testStack = new MyStack(StackSize);
            int sum = 0;
            int n = 10;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
                _testStack.Push(i);
            }
            Assert.AreEqual(n, _testStack.Count);
            Assert.AreEqual(sum, _testStack.AddAll());
        }

        [TestMethod()]
        public void TestMultiplyAll()
        {
            _testStack = new MyStack(StackSize);
            int product;
            int n = 10;
            _testStack.Push(1);
            product = 1;
            for (int i = 2; i <= n; i++)
            {
                product *= i;
                _testStack.Push(i);
            }
            Assert.AreEqual(n, _testStack.Count);
            Assert.AreEqual(product, _testStack.MultiplyAll());
        }
    }
}