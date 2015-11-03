namespace LinearDataStructure.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoResizableStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AutoResizableStackTests
    {
        [TestMethod]
        public void TestPushFuncionality()
        {
            var stack = new AutoResizableStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        public void PeekShouldNotChangeCount()
        {
            var stack = new AutoResizableStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(3, stack.Peek());
            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPeekFunctionalityOnEmptyStackShouldThrowException()
        {
            var stack = new AutoResizableStack<int>();
            stack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPopFunctionalityOnEmptyStackShouldThrowException()
        {
            var stack = new AutoResizableStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void TestCountAndCapacity()
        {
            var elementsToAdd = 930;

            var stack = new AutoResizableStack<int>();
            for (int i = 0; i < elementsToAdd; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(elementsToAdd, stack.Count);
            Assert.AreEqual(1024, stack.Capacity);
        }
    }
}
