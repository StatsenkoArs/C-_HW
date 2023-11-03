using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class StackTests
    {
        [TestMethod()]
        public void pushTest()
        {
            int a = 2;
            Stack s = new Stack();
            int len_before = s.size();

            s.push(a);

            Assert.AreEqual(s.size(), len_before + 1);
            Assert.AreEqual(s.back(), a);
        }

        [TestMethod()]
        public void popTest()
        {
            Stack s = new Stack(new int[] { 1, 2, 3 });
            int len_before = s.size();

            int a = s.pop();

            Assert.AreEqual(a, 3);
            Assert.AreEqual(s.size(), len_before - 1);
        }

        [TestMethod()]
        public void backTest()
        {
            Stack s = new Stack(new int[] { 1, 2, 3 });
            int len_before = s.size();

            int a = s.back();

            Assert.AreEqual(a, 3);
            Assert.AreEqual(len_before, s.size());
        }

        [TestMethod()]
        public void sizeTest()
        {
            Stack s = new Stack(new int[] { 1, 2 });

            int len = s.size();

            Assert.AreEqual(2, len);
        }

        [TestMethod()]
        public void clearTest()
        {
            Stack s = new Stack(new int[] { 1, 2, 3 });

            s.clear();

            Assert.AreEqual(0, s.size());
        }
    }
}