using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class SortTests
    {
        [TestCase(new[] { 1, 2, 3 }, 0)]
        [TestCase(new[] { 1, 2, 4, 3 }, 1)]
        [TestCase(new[] { 6, 4, 1 }, 3)]
        [TestCase(new[] { 22, -17, 3, 41, -2, 3, -26, 8, 44, 15, 0, 11, -48, -12, 1 }, 59)]
        public void TestCountBubbleSortSwaps(int[] array, int swapCount)
        {
            var result = Sort.BubbleSort(array);
            Assert.AreEqual(swapCount, result);
            Assert.IsTrue(IsSorted(array));
        }

        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 4, 3 })]
        [TestCase(new[] { 6, 4, 1 })]
        [TestCase(new[] { 22, -17, 3, 41, -2, 3, -26, 8, 44, 15, 0, 11, -48, -12, 1 })]
        public void TestSelectionSort(int[] array)
        {
            Sort.SelectionSort(array);
            Assert.IsTrue(IsSorted(array));
        }

        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 4, 3 })]
        [TestCase(new[] { 6, 4, 1 })]
        [TestCase(new[] { 22, -17, 3, 41, -2, 3, -26, 8, 44, 15, 0, 11, -48, -12, 1 })]
        public void TestInsertionSort(int[] array)
        {
            Sort.InsertionSort(array);
            Assert.IsTrue(IsSorted(array));
        }

        [TestCase(new int[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 }, 5, 2)]
        [TestCase(new[] { 10, 20, 30, 40, 50 }, 3, 1)]
        [TestCase(new[] { 1, 2, 3, 4, 4 }, 4, 0)]
        public void TestActivityNotification(int[] expenditures, int lookBackDays, int expected)
        {
            var result = Sort.activityNotification(expenditures, lookBackDays);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new[] { 1, 2, 3 }, 0, 2, 1, new[] {1, 1, 2})]
        [TestCase(new[] { 1, 2, 3 }, 1, 2, -1, new[] { 2, 3, 3 })]
        [TestCase(new[] { 1, 2, 4, 3, 5, 7 }, 3, 3, -3, new[] {3, 5, 7, 3, 5, 7})]
        [TestCase(new[] { 6, 4, 1, 0, -2, -5 }, 1, 2, 2, new[] { 6, 4, 1, 4, 1, -5 })]
        public void TestShift(int[] data, int start, int count, int distance, int[] expected)
        {
            Sort.shift(data, start, count, distance);
            Assert.AreEqual(expected, data);
        }

        private bool IsSorted(int[] data)
        {
            for (var i = 0; i < data.Length - 1; ++i)
            {
                if (data[i] > data[i + 1]) return false;
            }
            return true;
        }
    }
}
