using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public interface ITree
    {
        int Insert(int value);
        int Lookup(int value, out BinaryNode foundNode);
        int Remove(int value, out bool removed, out BinaryNode replaceNode);
        int[] BreadthFirstTraveral();
        int[] BreadthFirstTraveralRecursive();
        int[] DepthFirstTraversalInOrder();
        int[] DepthFirstTraversalPreOrder();
        int[] DepthFirstTraversalPostOrder();
    }

    public class BinaryNode
    {
        public BinaryNode Parent;
        public BinaryNode Left;
        public BinaryNode Right;
        public int Value;
    }

    public class BSTree : ITree
    {
        #region Public
        public int Insert(int value)
        {
            int searchCount = 1;
            if (Root == null)
            {
                Root = new BinaryNode { Value = value };
                return 1;
            }

            if (value < Root.Value) searchCount = Insert(Root, Root.Left, true, value, searchCount);
            else searchCount = Insert(Root, Root.Right, false, value, 1);
            return searchCount;
        }

        public int Lookup(int value, out BinaryNode foundNode)
        {
            var searchCount = 1;
            if (Root == null) foundNode = null;
            else if (value == Root.Value) foundNode = Root;
            else
            {
                if (value < Root.Value) searchCount = Lookup(Root.Left, value, searchCount, out foundNode);
                else searchCount = Lookup(Root.Right, value, searchCount, out foundNode);
            }
            return searchCount;
        }

        public int Remove(int value, out bool removed, out BinaryNode replaceNode)
        {
            var searchCount = Lookup(value, out var foundNode);
            if (foundNode == null)
            {
                removed = false;
                replaceNode = null;
                return searchCount;
            }
            removed = true;
            replaceNode = foundNode.Left;
            if (foundNode == Root)
            {
                Root = replaceNode;
                Root.Parent = null;
            }
            else
            {
                var parent = foundNode.Parent;
                if (parent.Left == foundNode) parent.Left = replaceNode;
                else if (parent.Right == foundNode) parent.Right = replaceNode;
                if (replaceNode != null) replaceNode.Parent = parent;
            }
            return searchCount;
        }
        public int[] BreadthFirstTraveral()
        {
            var queue = new Queue<BinaryNode>();
            var values = new List<int>();
            queue.Enqueue(Root);
            BreadthFirstVisit(queue, values);
            while (queue.Count > 0)
            {
                BreadthFirstVisit(queue, values);
            }
            return values.ToArray();
        }
        public int[] BreadthFirstTraveralRecursive()
        {
            var queue = new Queue<BinaryNode>();
            var values = new List<int>();
            queue.Enqueue(Root);
            BreadthFirstVisitRecursive(queue, values);
            return values.ToArray();
        }


        public int[] DepthFirstTraversalInOrder()
        {
            var values = new List<int>();
            TraverseInOrder(Root, values);
            return values.ToArray();
        }

        public int[] DepthFirstTraversalPreOrder()
        {
            var values = new List<int>();
            TraversePreOrder(Root, values);
            return values.ToArray();
        }

        public int[] DepthFirstTraversalPostOrder()
        {
            var values = new List<int>();
            TraversePostOrder(Root, values);
            return values.ToArray();
        }
        #endregion

        #region Constructor
        private BinaryNode Root;

        public BSTree()
        {
            Root = null;
        }
        #endregion

        #region Non-Public
        private int Insert(BinaryNode parent, BinaryNode node, bool isLeft, int value, int searchCount)
        {
            searchCount++;
            if (node == null)
            {
                node = new BinaryNode() { Value = value, Parent = parent };
                if (isLeft) parent.Left = node;
                else parent.Right = node;
                return searchCount;
            }
            if (value < node.Value) searchCount = Insert(node, node.Left, true, value, searchCount);
            else searchCount = Insert(node, node.Right, false, value, searchCount);
            return searchCount;
        }

        private int Lookup(BinaryNode node, int value, int searchCount, out BinaryNode foundNode)
        {
            searchCount++;
            if (node == null) foundNode = null;
            else if (node.Value == value) foundNode = node;
            else
            {
                if (value < node.Value) searchCount = Lookup(node.Left, value, searchCount, out foundNode);
                else searchCount = Lookup(node.Right, value, searchCount, out foundNode);
            }
            return searchCount;
        }

        private void BreadthFirstVisit(Queue<BinaryNode> queue, List<int> values)
        {
            var node = queue.Dequeue();
            values.Add(node.Value);
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);                 
        }

        private void BreadthFirstVisitRecursive(Queue<BinaryNode> queue, List<int> values)
        {
            if (queue.Count == 0) return;
            var node = queue.Dequeue();
            values.Add(node.Value);
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
            BreadthFirstVisitRecursive(queue, values);
        }

        private void TraverseInOrder(BinaryNode node, List<int> values)
        {
            if (node.Left != null)
            {
                TraverseInOrder(node.Left, values);
            }
            values.Add(node.Value);
            if (node.Right != null)
            {
                TraverseInOrder(node.Right, values);
            }
        }

        private void TraversePreOrder(BinaryNode node, List<int> values)
        {
            values.Add(node.Value);
            if (node.Left != null)
            {
                TraversePreOrder(node.Left, values);
            }
            if (node.Right != null)
            {
                TraversePreOrder(node.Right, values);
            }
        }

        private void TraversePostOrder(BinaryNode node, List<int> values)
        {
            if (node.Left != null)
            {
                TraversePostOrder(node.Left, values);
            }
            if (node.Right != null)
            {
                TraversePostOrder(node.Right, values);
            }
            values.Add(node.Value);
        }

        #endregion
    }
}
