using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank.Tests
{
    class FindShortestCloneTests
    {
        [TestCase(new[] { 1, 1, 4 }, new[] { 2, 3, 2 }, new long[] { 1, 2, 1, 1 }, 1, 1)]
        [TestCase(new[] { 1, 1, 4 }, new[] { 2, 3, 2 }, new long[] { 1, 2, 3, 4 }, 2, -1)]
        [TestCase(new[] { 1, 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new long[] { 1, 2, 3, 3, 2 }, 2, 3)]
        [TestCase(new[] { 1, 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new long[] { 1, 2, 3, 3, 2 }, 3, 3)]
        [TestCase(new[] { 1, 1, 2, 3 }, new[] { 2, 3, 4, 5 }, new long[] { 1, 2, 3, 3, 2 }, 3, 3)]
        [TestCase(new[] { 1, 1, 2, 3, 5 }, new[] { 2, 3, 4, 5, 6 }, new long[] { 1, 2, 3, 3, 2, 3 }, 3, 2)]
        [TestCase(new[] { 1, 1, 2, 3, 5 }, new[] { 2, 3, 4, 5, 2 }, new long[] { 1, 2, 3, 3, 2 }, 2, 1)]
        public void TestMinDistance(int[] from, int[] to, long[] values, long value, int expected)
        {
            var list = new List<int>();
            var result = FindShortestClone.findShortest(values.Length, from, to, values, value, list);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new[] { 1, 1, 4 }, new[] { 2, 3, 2 }, new long[] { 1, 2, 1, 1 }, 1, new[] { 0, 1, 3, 2 })]
        [TestCase(new[] { 1, 1, 2, 3, 5 }, new[] { 2, 3, 4, 5, 2 }, new long[] { 1, 2, 3, 3, 2 }, 2, new[] { 1, 0, 2, 4, 1, 3, 4 })]
        public void TestDepthFirstSearch(int[] from, int[] to, long[] values, long value, int[] expected)
        {
            var list = new List<int>();
            var result = FindShortestClone.findShortest(values.Length, from, to, values, value, list);
            Assert.AreEqual(expected.Length, list.Count);
            Assert.That(expected.SequenceEqual(list.ToArray()));
        }

        [TestCase("GraphFindShortestTestCase2.txt", -1)]
        [TestCase("GraphFindShortestTestCase3.txt", -1)]
        public void TestFindShortestFromFile(string fileName, int expected)
        {
            var path = Path.Combine("TestData", fileName);
            var lines = File.ReadAllLines(path);
            string[] graphNodesEdges = lines[0].Split(' ');

            int graphNodes = Convert.ToInt32(graphNodesEdges[0]);
            int graphEdges = Convert.ToInt32(graphNodesEdges[1]);

            int[] graphFrom = new int[graphEdges];
            int[] graphTo = new int[graphEdges];

            for (int i = 1; i <= graphEdges; i++)
            {
                string[] graphFromTo = lines[i].Split(' ');
                graphFrom[i - 1] = Convert.ToInt32(graphFromTo[0]);
                graphTo[i - 1] = Convert.ToInt32(graphFromTo[1]);
            }

            long[] ids = Array.ConvertAll(lines[graphEdges + 1].Split(
                new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), idsTemp => Convert.ToInt64(idsTemp))
            ;
            int val = Convert.ToInt32(lines[graphEdges + 2]);

            int ans = FindShortestClone.findShortest(graphNodes, graphFrom, graphTo, ids, val);
            Assert.AreEqual(expected, ans);
        }
    }
}
