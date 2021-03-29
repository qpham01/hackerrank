using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class SortTests
    {
        [TestCase(new [] {6,4,1}, 3, 1, 6)]
        public void TestCountBubbleSortSwaps(int[] array, int swapCount, int first, int last)
        {
            var result = Sort.BubbleSort(array);
            Assert.AreEqual(swapCount, result);
            Assert.AreEqual(first, array.First());
            Assert.AreEqual(last, array.Last());
        }

        [TestCase(new int[] {2, 3, 4, 2, 3, 6, 8, 4, 5}, 5, 2)]
        [TestCase(new [] { 10, 20, 30, 40, 50 }, 3, 1)]
        [TestCase(new [] { 1, 2, 3, 4, 4 }, 4, 0)]
        public void TestActivityNotification(int[] expenditures, int lookBackDays, int expected)
        {
            var result = Sort.activityNotification(expenditures, lookBackDays);
            Assert.AreEqual(expected, result);
        }
    }
}
