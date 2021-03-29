using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class BinaryTreeTest
    {
        [TestCase("BinaryTree_0.txt", 3)]
        [TestCase("BinaryTree_1.txt", 5)]
        [TestCase("BinaryTree_2.txt", 11)]
        public void TestMakeIntTreeFromText(string fileName, int expectedNodeCount)
        {
            var path = Path.Combine("TestData", fileName);
            var lines = File.ReadAllLines(path);
            var tree = IntTree.MakeIntTreeFromText(lines);
            Assert.AreEqual(expectedNodeCount, tree.NodeCount);
        }

        [TestCase("BinaryTree_1.txt", new [] {2, 4, 1, 3, 5}, 3)] 
        public void TestInOrderTraversal(string fileName, int[] expected, int expectedMaxHeight)
        {
            var path = Path.Combine("TestData", fileName);
            var lines = File.ReadAllLines(path);
            var tree = IntTree.MakeIntTreeFromText(lines);
            var result = tree.InOrderTraversalGetValues(out var maxHeight);
            Assert.That(expected.SequenceEqual(result));
            Assert.AreEqual(expectedMaxHeight, maxHeight);
        }

        [TestCase("BinaryTree_1.txt", 1, new[] {1})]
        [TestCase("BinaryTree_1.txt", 2, new[] {2, 3})]
        [TestCase("BinaryTree_1.txt", 3, new[] {4, 5})]
        public void TestGetNodesAtHeight(string fileName, int height, int[] expected)
        {
            var path = Path.Combine("TestData", fileName);
            var lines = File.ReadAllLines(path);
            var tree = IntTree.MakeIntTreeFromText(lines);
            var nodes = tree.GetNodesAtHeight(height);
            var result = nodes.Select(x => x.Value);
            Assert.That(expected.SequenceEqual(result));
        }

        [TestCase("BinaryTree_0.txt", 1, new[] { 3, 1, 2 })]
        [TestCase("BinaryTree_1.txt", 2, new[] { 4, 2, 1, 5, 3 })]
        [TestCase("BinaryTree_2.txt", 2, new[] { 2, 9, 6, 4, 1, 3, 7, 5, 11, 8, 10 })]
        public void TestSwapNodes(string fileName, int height, int[] expected)
        {
            var path = Path.Combine("TestData", fileName);
            var lines = File.ReadAllLines(path);
            var tree = IntTree.MakeIntTreeFromText(lines);
            tree.SwapNodes(height);
            var result = tree.InOrderTraversalGetValues(out var maxHeight);
            Assert.That(expected.SequenceEqual(result));
        }
    }
}
