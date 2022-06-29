using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class MiniMaxSumTests
    {
        [Test]
        public void TestCase1()
        {
            var input1 = new uint[] { 1, 2, 3, 4, 5 };
            var input2 = new uint[] { 5, 4, 3, 2, 1 };

            var expected = new uint[] { 10, 14 };

            var output1 = MiniMaxSum.Solution(input1.ToList());
            Assert.AreEqual(expected[0], output1[0]);
            Assert.AreEqual(expected[1], output1[1]);

            var output2 = MiniMaxSum.Solution(input2.ToList());
            Assert.AreEqual(expected[0], output2[0]);
            Assert.AreEqual(expected[1], output2[1]);

        }

        public void TestCase2()
        {
            var input = new uint[] { 256741038, 623958417, 467905213, 714532089, 938071625 };
            var expected = new uint[] { 2063136757, 2744467344 };
            var output = MiniMaxSum.Solution(input.ToList());
            Assert.AreEqual(expected[0], output[0]);
            Assert.AreEqual(expected[1], output[1]);
        }
    }
}
