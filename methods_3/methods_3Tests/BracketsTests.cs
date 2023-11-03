using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class BracketsTests
    {
        [TestMethod()]
        public void rightSequence()
        {
            string input = "(())(()())";

            Brackets b = new Brackets(input);

            Assert.AreEqual(b.solveBrackets(), "Yes");
        }

        [TestMethod()]
        public void rightSequnceWithFillers()
        {
            string input = "((Let's put some text))((here)(and here) and some numbers 1 2 3)";

            Brackets b = new Brackets(input);

            Assert.AreEqual(b.solveBrackets(), "Yes");
        }

        [TestMethod()]
        public void moreLeft()
        {

            string input = "(())((()())";

            Brackets b = new Brackets(input);

            Assert.AreEqual(b.solveBrackets(), "No, too many (");
        }

        [TestMethod()]
        public void moreRight()
        {

            string input = "(())(()()))";

            Brackets b = new Brackets(input);

            Assert.AreEqual(b.solveBrackets(), "No, too many )");
        }

        
    }
}