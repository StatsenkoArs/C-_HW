using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class QueueTests
    {
        [TestMethod()]
        public void pushTest()
        {
            Queue q = new Queue();
            int a = 1;

            q.push(a);

            Assert.AreEqual(a, q.front());
            Assert.AreEqual(1, q.size());
        }

        [TestMethod()]
        public void popTest()
        {
            Queue q = new Queue(new int[] { 1, 2, 3 });
            int len_before = q.size();

            int a = q.pop();

            Assert.AreEqual(a, 1);
            Assert.AreEqual(len_before - 1, q.size());
        }

        [TestMethod()]
        public void frontTest()
        {
            Queue q = new Queue(new int[] { 1, 2, 3 });
            int len_before = q.size();

            int a = q.front();

            Assert.AreEqual(a, 1);
            Assert.AreEqual(len_before, q.size());
        }

        [TestMethod()]
        public void sizeTest()
        {
            Queue q = new Queue(new int[] { 1, 2 });

            int len = q.size();

            Assert.AreEqual(2, len);
        }

        [TestMethod()]
        public void clearTest()
        {
            Queue q = new Queue(new int[] { 1, 2, 3 });

            q.clear();

            Assert.AreEqual(0, q.size());
        }
    }
}