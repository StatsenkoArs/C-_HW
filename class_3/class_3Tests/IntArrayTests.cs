using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class IntArrayTests
    {
        [TestMethod()]
        public void IntArrayTest()
        {
            int[] expected = new int[3] { 0, 0, 0 };
            
            IntArray check = new IntArray(3);

            Assert.AreEqual(String.Join(", ", expected), check.GetDataString());
        }

        [TestMethod()]
        public void InputDataTest()
        {
            int[] expected = new int[3] { 1, 2, 3 };

            IntArray check = new IntArray(3);
            check.InputData(new int[] { 1, 2, 3 });

            Assert.AreEqual(String.Join(", ", expected), check.GetDataString());
        }

        [TestMethod()]
        public void FindValueTest()
        {
            int[] expected = new int[1] { 0 };
            IntArray check = new IntArray(3);
            check.InputData(new int[] { 1, 2, 3 });

            int[] res = check.FindValue(1);

            Assert.AreEqual(String.Join(", ", expected), String.Join(", ", res));
        }

        [TestMethod()]
        public void DelValueTest()
        {
            IntArray check = new IntArray(3);
            check.InputData(new int[] { 1, 2, 3 });
            int toDel = 1;
            IntArray expected = new IntArray(2);
            expected.InputData(new int[2] { 2, 3 });

            check.DelValue(toDel);

            Assert.AreEqual(expected.GetDataString(), check.GetDataString());
        }

        [TestMethod()]
        public void AddTest()
        {
            IntArray check = new IntArray(3);
            check.InputData(new int[] {1, 2, 3});
            int[] toAdd = new int[] { 1, 2, 3 };
            IntArray expected = new IntArray(3);
            expected.InputData(new int[3] {2, 4, 6});

            check.Add(toAdd);

            Assert.AreEqual(expected.GetDataString(), check.GetDataString());
        }

        [TestMethod()]
        public void SortTest()
        {
            IntArray check = new IntArray(3);
            check.InputData(new int[3] { 2, 1, 3});
            IntArray expected = new IntArray(3);
            expected.InputData(new int[3] { 1, 2, 3 });

            check.Sort();

            Assert.AreEqual(expected.GetDataString(), check.GetDataString());
        }
    }
}