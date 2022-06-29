using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    class BinarySearchTreeTest
    {

        [TestCase(new[] { 4, 2, 3, 1, 7, 6 }, 1, 7, 4)]
        [TestCase(new[] { 5, 3, 8, 2, 4, 6, 7 }, 7, 3, 5)]
        [TestCase(new[] { 8, 4, 9, 1, 2, 3, 6, 5 }, 1, 2, 1)]
        public void TestLeastCommonAncestor(int[] data, int data1, int data2, int expected)
        {
            var tree = BinarySearchTree.MakeTreeFromData(data);
            var result = BinarySearchTree.LowestCommonAncestor(tree.root, data1, data2);
            Console.WriteLine(tree.ToString());
            Assert.AreEqual(expected, result.data);
        }

        [TestCase(new[] { 4, 2, 3, 1, 7, 6 }, new[] { 4, 2, 7, 1, 3, 6 })]
        public void TestBreadthFirstSearch(int[] data, int[] expected)
        {
            var tree = BinarySearchTree.MakeTreeFromData(data);
            var queue = new Queue<Node>();
            var path = new List<int>();
            BinarySearchTree.BreathFirstSearch(tree.root, queue, path);
            Assert.That(expected.SequenceEqual(path));

        }
    }
}
