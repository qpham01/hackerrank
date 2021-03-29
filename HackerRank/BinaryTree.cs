using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class BinaryNode<T>
    {
        public T Value;
        public BinaryNode<T> Left;
        public BinaryNode<T> Right;
    }

    public class BinaryTree<T>
    {
        public BinaryNode<T> Root;
        public int NodeCount;

        public T[] InOrderTraversalGetValues()
        {
            var values = new List<T>();
            TraverseInOrder(Root, values, 1);
            return values.ToArray();
        }

        public List<BinaryNode<T>> GetNodesAtHeight(int height)
        {
            var list = new List<BinaryNode<T>>();
            if (height == 1)
            {
                list.Add(Root);
                return list;
            }

            GetNodesAtHeight(Root, list, height, 1);
            return list;
        }

        private void TraverseInOrder(BinaryNode<T> node, List<T> values, int height)
        {
            if (node.Left != null) TraverseInOrder(node.Left, values, height + 1);
            values.Add(node.Value);
            if (node.Right != null) TraverseInOrder(node.Right, values, height + 1);
        }

        private void GetNodesAtHeight(BinaryNode<T> node, List<BinaryNode<T>> nodes, int targetHeight, int height)
        {
            if (height == targetHeight)
            {
                nodes.Add(node);
                return;
            }
            if (node.Left != null) GetNodesAtHeight(node.Left, nodes, targetHeight, height + 1);
            if (node.Right != null) GetNodesAtHeight(node.Right, nodes, targetHeight, height + 1);
        }
    }

    public class IntTree : BinaryTree<int>
    {
        public static IntTree MakeIntTreeFromText(string[] lines)
        {
            var expectedNodeCount = int.Parse(lines[0]);
            var nodes = new int[expectedNodeCount][];
            for (var i = 1; i < lines.Length; ++i)
            {
                var parts = lines[i].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var value1 = int.Parse(parts[0]);
                var value2 = int.Parse(parts[1]);
                nodes[i - 1] = new[] {value1, value2};
            }

            return MakeIntTreeFromNodes(nodes);
        }


        public static IntTree MakeIntTreeFromNodes(int[][] nodes)
        { 
            var tree = new IntTree {Root = new BinaryNode<int>() {Value = 1}};
            var currentNode = tree.Root;
            var queue = new Queue<BinaryNode<int>>();
            var nodeCount = 1;
            var expectedNodeCount = nodes.GetLength(0);
            for (var i = 0; i < expectedNodeCount; ++i)
            {
                var value1 = nodes[i][0];
                var value2 = nodes[i][1];
                if (value1 >= 0)
                {
                    var leftNode = new BinaryNode<int> { Value = value1 };
                    queue.Enqueue(leftNode);
                    currentNode.Left = leftNode;
                    nodeCount++;
                }

                if (value2 >= 0)
                {
                    var rightNode = new BinaryNode<int> { Value = value2 };
                    queue.Enqueue(rightNode);
                    currentNode.Right = rightNode;
                    nodeCount++;
                }
                if (queue.Count > 0)
                    currentNode = queue.Dequeue();
            }

            if (nodeCount != nodes.GetLength(0))
                throw new Exception($"Unexpected node count {nodeCount}, expected {expectedNodeCount}");
            tree.NodeCount = nodeCount;

            return tree;
        }

        public void SwapNodes(int height)
        {
            for (var h = height;; h += height)
            {
                var nodes = GetNodesAtHeight(h);
                if (nodes.Count == 0) break;
                foreach (var node in nodes)
                {
                    var leftNode = node.Left;
                    var rightNode = node.Right;
                    node.Left = rightNode;
                    node.Right = leftNode;
                }
            }
        }
    }

}
