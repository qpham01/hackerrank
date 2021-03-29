using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class SearchTests
    {
        [TestCase(new[] { 1, 4, 5, 3, 2 }, 4, new[] { 0, 3 })]
        [TestCase( new[] { 2, 2, 4, 3 }, 4, new [] {0, 1})]
        [TestCase(new [] { 1, 4, 5, 3, 2, }, 4, new [] {0, 3})]
        [TestCase(new[] { 2, 1, 3, 4, 5, }, 5, new[] { 0, 2 })]
        [TestCase(new[] { 4, 3, 2, 5, 7}, 8, new [] {1, 3} )]
        public void TestTwoNumberSumSearch(int[] input, int sum, int[] expected)
        {
            var result = Search.TwoNumberSumSearch(input, sum);
            Assert.AreEqual(expected[0], result.Item1);
            Assert.AreEqual(expected[1], result.Item2);
        }

        [TestCase("TwoNumberSumSearch00.txt")]
        [TestCase("TwoNumberSumSearch01.txt")]
        public void TestTwoNumberSumSearch(string inputFile)
        {
            var path = Path.Combine("TestData", inputFile);
            var lines = File.ReadAllLines(path);
            var testCount = int.Parse(lines[0]);
            var lineNumber = 0;
            var expected = new List<(int, int)>();
            for (var i = 0; i < testCount; ++i)
            {
                lineNumber++;
                var line = lines[lineNumber];
                var answers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                expected.Add((int.Parse(answers[0]), int.Parse(answers[1])));
            }

            for (var i = 0; i < testCount; ++i)
            {
                lineNumber++;
                var line = lines[lineNumber];
                var sum = int.Parse(line);
                lineNumber += 2;
                line = lines[lineNumber];
                var values = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var input = new List<int>();
                foreach (var value in values)
                {
                    input.Add(int.Parse(value));
                }

                var result = Search.TwoNumberSumSearchHash(input.ToArray(), sum);
                Assert.AreEqual(expected[i].Item1, result.Item1 + 1);
                Assert.AreEqual(expected[i].Item2, result.Item2 + 1);
            }
        }
    }
}
