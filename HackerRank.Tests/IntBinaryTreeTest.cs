using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class IntBinaryTreeTest
    {
        [Test]
        public void TestPreOrder01()
        {
            var root = new IntBinaryTree.Node(1)
            {
                Left = new IntBinaryTree.Node(2),
                Right = new IntBinaryTree.Node(3)
            };
            root.Left.Left = new IntBinaryTree.Node(4);

            var result = IntBinaryTree.PreOrder(root);
            Assert.That(result, Is.EquivalentTo(new int[] {1, 2, 4, 3}));
        }

        [Test]
        public void TestPreOrder02()
        {
            var root = new IntBinaryTree.Node(1);
            IntBinaryTree.LeftInsert(root, 1, 2);
            IntBinaryTree.RightInsert(root, 1, 3);
            IntBinaryTree.LeftInsert(root, 2, 4);

            var result = IntBinaryTree.PreOrder(root);
            Assert.That(result, Is.EquivalentTo(new int[] { 1, 2, 4, 3 }));
        }
    }
}
