using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class DequeTests
    {
        [TestMethod()]
        public void pushTest()
        {
            Deque<int> d = new Deque<int>(new int[] {1, 2 });

            d.pushBack(0);
            d.pushForward(0);

            Assert.AreEqual(d.size(), 4);
            Assert.AreEqual(d.front(), d.back());
            Assert.AreEqual(d.front(), 0);
        }

        [TestMethod()]
        public void popTest()
        {
            Deque<int> d = new Deque<int>(new int[] {0, 1, 1, 0 });

            int f = d.popFront();
            int b = d.popBack();

            Assert.AreEqual(d.size(), 2);
            Assert.AreEqual(f, b);
            Assert.AreEqual(f, 0);
            Assert.AreEqual(d.front(), d.back());
            Assert.AreEqual(d.front(), 1);
        }

        [TestMethod()]
        public void peekTest()
        {
            Deque<int> d = new Deque<int>(new int[] { 1, 2 });

            int f = d.front();
            int b = d.back();

            Assert.AreEqual(d.size(), 2);
            Assert.AreEqual(f, 1);
            Assert.AreEqual(b, 2);
        }

        [TestMethod()]
        public void sizeTest()
        {
            Deque<int> i = new Deque<int>();
            int sizeBefore = i.size();

            i.pushBack(1);
            i.popBack();
            int sizeAfter = i.size();

            Assert.AreEqual(sizeBefore, sizeAfter);
        }

        [TestMethod()]
        public void findTest()
        {
            Deque<int> d = new Deque<int>(new int[] {1, 2, 3, 4 });
            int[] exp = new int[] { 2 };
            int toFind = 3;

            int[] res = d.find(toFind);

            Assert.AreEqual(exp[0], res[0]);
        }

        [TestMethod()]
        public void deleteTest()
        {
            Deque<int> d = new Deque<int>(new int[] {1, 2, 3 });

            d.delete(2);
            d.delete(1);
            d.delete(3);

            Assert.AreEqual(d.size(), 0);
        }
    }
}