using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class TwoStackQueueTest
    {
        [TestCase(new [] {"1 20", "3", "2"}, new [] {20})]
        [TestCase(new[] { "1 42", "2", "1 14", "3", "1 28", "3", "1 60", "1 78", "2", "2" }, new[] { 14, 14 })]
        public void TestTwoStackQueue(string[] input, int[] expected)
        {
            var queue = new TwoStackQueue();
            var result = queue.QueueOp(input);
            for (var i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
