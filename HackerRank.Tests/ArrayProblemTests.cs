using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class ArrayProblemTests
    {
        [TestCase(new[] { 6 }, 6)]
        [TestCase(new[] {1, 1, 2, 2, 3}, 1)]
        public void TestMigratoryBirds(int[] data, int expected)
        {
            var result = ArrayProblems.migratoryBirds(data.ToList());
            Assert.AreEqual(expected, result);
        }

    }
}
