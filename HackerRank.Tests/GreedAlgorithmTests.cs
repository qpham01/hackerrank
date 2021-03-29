using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class GreedAlgorithmTests
    {
        [TestCase(new[] {1, 3, 5, 7, 8}, 1)]
        [TestCase(new [] { -59, -36, -13, 1, -53, -92, -2, -96, -54, 75 }, 1)]
        public void TestMinimumAbsoluteDifference(int[] input, int expected)
        {
            var result = GreedyAlgorithms.minimumAbsoluteDifference(input);
            Assert.AreEqual(expected, result);
        }

    }
}
