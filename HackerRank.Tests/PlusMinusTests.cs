using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{

    class PlusMinusTests
    {
        [Test]
        public void TestCase1()
        {
            var input = new[] { -4, 3, -9, 0, 4, 1 };
            var expected = new[] { "0.500000", "0.333333", "0.166667" };
            var output = PlusMinus.Solution(input.ToList());
            Assert.AreEqual(expected[0], output[0]);
            Assert.AreEqual(expected[1], output[1]);
            Assert.AreEqual(expected[2], output[2]);
        }
    }
}
