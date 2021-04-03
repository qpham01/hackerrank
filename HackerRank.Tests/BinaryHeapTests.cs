using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRank.Tests
{
    class IntComparerMin : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return 1;
            if (x < y) return -1;
            return 0;
        }
    }

    class IntComparerMax : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return -1;
            if (x < y) return 1;
            return 0;
        }
    }

    class BinaryHeapTests
    {
        [TestCase(new[] { 2, 1, 3 }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 6, 4, 5, 1, 3, 2 }, new[] { 1, 2, 3, 4, 5, 6})]
        [TestCase(new[] { 8, 9, 3, 6, 5, 1 }, new[] { 1, 3, 5, 6, 8, 9 })]
        [TestCase(new[] { 11, 14, 31, 7, 45, 20, 18, 12, 7 }, new[] { 7, 7, 11, 12, 14, 18, 20, 31, 45 })]
        public void TestInsertionMin(int[] input, int[] expected)
        {
            var heap = new BinaryHeap<int>(input, new IntComparerMin());
            var i = 0;
            while (heap.Count > 0)
            {
                var value = heap.RemoveRoot();
                Assert.AreEqual(expected[i], value);
                i++;
            }
        }
    


        [TestCase(new[] { 8, 9, 3, 6, 5, 1 }, new[] { 9, 8, 6, 5, 3, 1 })]
        [TestCase(new[] { 11, 14, 31, 7, 45, 20, 18, 12, 7 }, new[] { 45, 31, 20, 18, 14, 12, 11, 7, 7 })]
        public void TestInsertionMax(int[] input, int[] expected)
        {
            var heap = new BinaryHeap<int>(input, new IntComparerMax());
            var i = 0;
            while (heap.Count > 0)
            {
                var value = heap.RemoveRoot();
                Assert.AreEqual(expected[i], value);
                i++;
            }
        }
    }
}
