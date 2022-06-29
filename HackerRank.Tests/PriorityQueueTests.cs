using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    class PriorityQueueTests
    {
        [TestCase(new[] { 2, 1, 3 }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 6, 4, 5, 1, 3, 2 }, new[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new[] { 8, 9, 3, 6, 5, 1 }, new[] { 1, 3, 5, 6, 8, 9 })]
        [TestCase(new[] { 11, 14, 31, 7, 45, 20, 18, 12, 7 }, new[] { 7, 7, 11, 12, 14, 18, 20, 31, 45 })]
        public void TestEnqueueMin(int[] input, int[] expected)
        {
            var queue = new PriorityQueue<int>(new IntComparerMin());
            foreach (var item in input)
            {
                queue.Enqueue(item);
            }
            Assert.AreEqual(input.Length, queue.Count);
            var i = 0;
            while (queue.Count > 0)
            {
                var value = queue.Dequeue();
                Assert.AreEqual(expected[i], value);
                i++;
            }
        }

        [TestCase(new[] { 2, 1, 3 }, new[] { 3, 2, 1 })]
        [TestCase(new[] { 6, 4, 5, 1, 3, 2 }, new[] { 6, 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 8, 9, 3, 6, 5, 1 }, new[] { 9, 8, 6, 5, 3, 1 })]
        [TestCase(new[] { 11, 14, 31, 7, 45, 20, 18, 12, 7 }, new[] { 45, 31, 20, 18, 14, 12, 11, 7, 7 })]
        public void TestInsertionMax(int[] input, int[] expected)
        {
            var queue = new PriorityQueue<int>(new IntComparerMax());
            foreach (var item in input)
            {
                queue.Enqueue(item);
            }
            Assert.AreEqual(input.Length, queue.Count);
            var i = 0;
            while (queue.Count > 0)
            {
                var value = queue.Dequeue();
                Assert.AreEqual(expected[i], value);
                i++;
            }
        }
    }
}
