using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Tests
{
    public class GraphEdgeListTests
    {
        private IGraph<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new GraphEdgeList<int>();
        }

        [TestCase(new[] {0, 1, 2})]
        public void TestAddNode(int[] values)
        {
            foreach (var value in values)
            {
                _sut.AddNode(value);
            }
            Assert.AreEqual(values.Length, _sut.NodeCount);
        }

        [TestCase(new[] { 0, 1, 2 }, new[] {0, 1, 2}, new[] {1, 2, 0}, true, 6)]
        [TestCase(new[] { 0, 1, 2 }, new[] {0, 1, 2 }, new[] { 1, 2, 0 }, false, 3)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 1, 2, 2, 3, 4, 4 }, new[] { 2, 5, 3, 5, 4, 5, 6 }, true, 14)]
        public void TestAddEdges(int[] values, int[] starts, int[] ends, bool bidirectional, int edgeCount)
        {
            BuildGraph(values, starts, ends, bidirectional);
            Assert.AreEqual(values.Length, _sut.NodeCount);
            List<IEdge<int>> edges = new List<IEdge<int>>();
            foreach (var value in values)
            {
                var nodeEdges = _sut.GetEdgesByValue(value);
                foreach (var edge in nodeEdges)
                {
                    Assert.AreEqual(value, edge.Node1.Value);
                }
                edges.AddRange(nodeEdges);
            }
            Assert.AreEqual(edgeCount, edges.Count);
        }

        [TestCase(new[] { 0, 1, 2 }, new[] { 0, 1, 2 }, new[] { 1, 2, 0 }, true, 6)]
        [TestCase(new[] { 0, 1, 2 }, new[] { 0, 1, 2 }, new[] { 1, 2, 0 }, false, 3)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 1, 2, 2, 3, 4, 4 }, new[] { 2, 5, 3, 5, 4, 5, 6 }, true, 1)]
        public void TestPrintEdges(int[] values, int[] starts, int[] ends, bool bidirectional, int edgeCount)
        {
            BuildGraph(values, starts, ends, bidirectional);
            foreach (var value in values)
            {
                var edges = _sut.GetEdgesByValue(value);
                foreach (var edge in edges)
                {
                    Console.WriteLine($"{value}: {edge.Node1.Value} --> {edge.Node2.Value}");
                }
            }            
        }

        [TestCase(new[] {1, 2, 3, 4, 5, 6}, new[] {1, 1, 2, 2, 3, 4, 4}, new[] {2, 5, 3, 5, 4, 5, 6}, true, 1, -1,  new[] { 1, 2, 5, 3, 4, 6 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 1, 2, 2, 3, 4, 4 }, new[] { 2, 5, 3, 5, 4, 5, 6 }, true, 1, 3, new[] { 1, 2, 5, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 1, 2, 2, 3, 3 }, new[] { 2, 3, 4, 5, 6, 7 }, true, 1, -1,  new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 1, 2, 2, 3, 3 }, new[] { 2, 3, 4, 5, 6, 7 }, true, 1, 3, new[] { 1, 2, 3 })]
        public void TestBreadthFirstSearch(int[] values, int[] starts, int[] ends, bool bidirectional, int start, int target, int[] expectedVisits)
        {
            BuildGraph(values, starts, ends, bidirectional);
            var visits = _sut.BreadthFirstSearch(start, target);
            Assert.That(visits, Is.EqualTo(expectedVisits));
        }

        private void BuildGraph(int[] values, int[] starts, int[] ends, bool bidirectional)
        {
            for (var i = 0; i < values.Length; ++i)
            {
                _sut.AddNode(values[i]);
            }
            for (var i = 0; i < starts.Length; ++i)
            {
                _sut.AddEdge(starts[i], ends[i], 1, bidirectional);
            }
        }
    }
}
