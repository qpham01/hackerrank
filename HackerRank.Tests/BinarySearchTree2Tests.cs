using NUnit.Framework;
using System;

namespace HackerRank.Tests
{
    public class BinarySearchTree2Tests
    {
        private ITree _tree;

        [SetUp]
        public void SetUp()
        {
            _tree = new BSTree();
        }

        [TestCase(new[] {9, 4, 6, 20, 170, 15, 1}, new[] {1, 2, 3, 2, 3, 3, 3})]
        public void TestInsert(int[] input, int[] searchCounts)
        {
            for (var i = 0; i < input.Length; ++i)
            {
                var searchCount = _tree.Insert(input[i]);
                Assert.AreEqual(searchCounts[i], searchCount);
            }
        }

        [Test]
        public void TestRandomLargeInsertCount()
        {
            var tree = new BSTree();
            var rand = new Random();
            var maxSearchCount = int.MinValue;
            for (var i = 0; i < 100000; ++i)
            {
                var r = rand.Next(100000);
                var searchCount = tree.Insert(r);
                var expectedMax = Math.Max(3, Math.Log2(i) * 3);
                Assert.That(searchCount, Is.LessThanOrEqualTo(expectedMax));
                if (searchCount > maxSearchCount) maxSearchCount = searchCount;
            }
            Console.WriteLine($"Max Search Count: {maxSearchCount}");
        }

        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1, -12, 0, 7, 14, 19, 25, 35, 27, 205 }, new[] { 1, 2, 3, 2, 3, 3, 3 })]
        public void TestLookup(int[] input, int[] searchCounts)
        {
            for (var i = 0; i < searchCounts.Length; ++i)
            {
                var searchCount = _tree.Insert(input[i]);
                Assert.AreEqual(searchCounts[i], searchCount);
            }

            for (var i = 0; i < input.Length; ++i)
            {
                var searchCount = _tree.Lookup(input[i], out var found);
                if (i < searchCounts.Length)
                {
                    Assert.AreEqual(searchCounts[i], searchCount);
                    Assert.AreEqual(input[i], found.Value);
                }
                else
                {
                    Assert.IsNull(found);
                }
            }
        }

        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, 9, 4, 1)]
        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, 4, 1, 2)]
        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, 20, 15, 2)]
        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, 6, int.MinValue, 3)]
        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, 15, int.MinValue, 3)]
        public void TestRemove(int[] input, int removeValue, int replaceValue, int expectedSearchCount)
        {
            BuildTree(input);
            var searchCount = _tree.Remove(removeValue, out var removed, out var replaceNode);
            Assert.AreEqual(expectedSearchCount, searchCount);
            Assert.IsTrue(removed);
            _tree.Lookup(removeValue, out var foundNode);
            Assert.IsNull(foundNode);
            if (replaceNode != null)
            {
                Assert.AreEqual(replaceValue, replaceNode.Value);
                searchCount = _tree.Lookup(replaceNode.Value, out foundNode);
                Assert.AreEqual(expectedSearchCount, searchCount);
            }
        }

        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, new[] {9, 4, 20, 1, 6, 15, 170 })]
        [TestCase(new[] { 56, 30, 70, 22, 60, 95, 11, 3, 16, 65, 63, 67, 40}, new[] {56, 30, 70, 22, 40, 60, 95, 11, 65, 3, 16, 63, 67})]
        public void TestBreadthFirstTraversal(int[] input, int[] expectedVisits)
        {
            BuildTree(input);
            var visits = _tree.BreadthFirstTraveral();
            Assert.That(visits, Is.EquivalentTo(expectedVisits));
        }

        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, new[] { 9, 4, 20, 1, 6, 15, 170 })]
        [TestCase(new[] { 56, 30, 70, 22, 60, 95, 11, 3, 16, 65, 63, 67, 40 }, new[] { 56, 30, 70, 22, 40, 60, 95, 11, 65, 3, 16, 63, 67 })]
        public void TestBreadthFirstTraversalRecursive(int[] input, int[] expectedVisits)
        {
            BuildTree(input);
            var visits = _tree.BreadthFirstTraveralRecursive();
            Assert.That(visits, Is.EquivalentTo(expectedVisits));
        }

        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, new[] { 1, 4, 6, 9, 15, 20, 170 })]
        [TestCase(new[] { 56, 30, 70, 22, 60, 95, 11, 3, 16, 65, 63, 67, 40 }, new[] { 3, 11, 16, 22, 30, 40, 56, 60, 63, 65, 67, 70, 95 })]
        public void TestDepthFirstTraversalInOrder(int[] input, int[] expectedVisits)
        {
            BuildTree(input);
            var visits = _tree.DepthFirstTraversalInOrder();
            Assert.That(visits, Is.EquivalentTo(expectedVisits));
        }

        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, new[] { 9, 4, 1, 6, 20, 15, 170 })]
        [TestCase(new[] { 56, 30, 70, 22, 60, 95, 11, 3, 16, 65, 63, 67, 40 }, new[] { 56, 30, 22, 11, 3, 16, 40, 70, 60, 65, 63, 67, 95 })]
        public void TestDepthFirstTraversalPreOrder(int[] input, int[] expectedVisits)
        {
            BuildTree(input);
            var visits = _tree.DepthFirstTraversalPreOrder();
            Assert.That(visits, Is.EquivalentTo(expectedVisits));
        }

        [TestCase(new[] { 9, 4, 6, 20, 170, 15, 1 }, new[] { 1, 6, 4, 15, 170, 20, 9 })]
        [TestCase(new[] { 56, 30, 70, 22, 60, 95, 11, 3, 16, 65, 63, 67, 40 }, new[] { 3, 16, 63, 67, 11, 65, 22, 40, 60, 95, 30, 70, 56 })]
        public void TestDepthFirstTraversalPostOrder(int[] input, int[] expectedVisits)
        {
            BuildTree(input);
            var visits = _tree.DepthFirstTraversalPostOrder();
            Assert.That(visits, Is.EquivalentTo(expectedVisits));
        }

        private void BuildTree(int[] input)
        {
            for (var i = 0; i < input.Length; ++i)
            {
                _tree.Insert(input[i]);
            }
        }
    }
}
