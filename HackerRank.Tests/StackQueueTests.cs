using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class StackQueueTests
    {
        [TestCase("{[()]}", "YES")]
        [TestCase("{[(])}", "NO")]
        [TestCase("{ {[[(())]]} }", "YES")]
        [TestCase("}][}}(}][))]", "NO")]
        [TestCase("{{}(", "NO")]
        public void TestBalancedBrackets(string s, string expected)
        {
            var result = StackQueue.isBalanced(s);
            Assert.AreEqual(expected, result);
        }

        [TestCase("BalancedBracket04.txt")]
        public void TestBalancedBrackets(string inputFile)
        {
            var path = Path.Combine("TestData", inputFile);
            var lines = File.ReadAllLines(path);
            var testCount = int.Parse(lines[0]);
            var lineNumber = 0;
            var expected = new List<string>();
            for (var i = 0; i < testCount; ++i)
            {
                lineNumber++;
                var line = lines[lineNumber];
                expected.Add(line);
            }

            for (var i = 0; i < testCount; ++i)
            {
                lineNumber++;
                var line = lines[lineNumber];
                var result = StackQueue.isBalanced(line);
                Assert.AreEqual(expected[i], result);
            }
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 9)]
        [TestCase(new[] { 1, 2, 5, 6, 7 }, 15)]
        [TestCase(new[] { 1, 2, 5, 6, 7, 1, 2 }, 15)]
        [TestCase(new[] { 1, 2, 5, 6, 7, 1, 2, 8, 9, 1 }, 16)]
        [TestCase(new[] { 8979, 4570, 6436, 5083, 7780, 3269, 5400, 7579, 2324, 2116 }, 26152)]
        [TestCase(new[] { 6873, 7005, 1372, 5438, 1323, 9238, 9184, 2396, 4605, 162, 7170, 9421, 4012, 5302, 6277, 2438, 4409, 3391, 4956, 4488, 622, 9365, 5088, 6926, 2691, 6909, 1050, 2824, 3538, 5801, 8468, 411, 9158, 9841, 2201, 481, 5431, 1385, 2877, 36, 1547, 48, 5809, 1911, 1702, 8439, 4349, 6111, 1830, 5657, 6951, 8804, 5022, 8391, 2083, 7713, 5300, 3133, 6890, 5190, 5286, 1710, 1953, 4445, 7903, 4154, 4926, 3335, 5539, 4156, 9723, 3438, 556, 1885, 5349, 2258, 324, 6050, 4722, 8506, 1707, 1673, 7310, 3081, 65, 9393, 7147, 1717, 8878, 389, 6908, 4165, 2099, 5213, 8610, 3, 9368, 3536, 9690, 1259 }, 51060)]
        public void TestLargestRectangle(int[] input, int expected)
        {
            var result = StackQueue.largestRectangle(input);
            Assert.AreEqual(expected, result);
        }
    }
}
