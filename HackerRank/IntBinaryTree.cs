using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace HackerRank
{
    public class IntBinaryTree
    {
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public Node(int d) {
                Data = d;
                Left = null;
                Right = null;
            }
        };

        public static Node Find(Node node, int value)
        {
            return node == null ? null : PreOrderTraverse(node, value);
        }

        public static Node LeftInsert(Node node, int parentData, int data)
        {
            var parent = Find(node, parentData);
            if (parent == null) return null;
            parent.Left = new Node(data);
            return parent.Left;
        }

        public static Node RightInsert(Node node, int parentData, int data)
        {
            var parent = Find(node, parentData);
            if (parent == null) return null;
            parent.Right = new Node(data);
            return parent.Right;
        }

        public static int[] PreOrder(Node root)
        {
            var results = new List<int>();
            PreOrderTraverse(root, results);
            return results.ToArray();
        }

        private static Node PreOrderTraverse(Node node, int target)
        {
            if (node == null) return null;
            if (node.Data == target) return node; 
            var result = PreOrderTraverse(node.Left, target);
            if (result != null) return result;
            result = PreOrderTraverse(node.Right, target);
            return result;
        }

        private static void PreOrderTraverse(Node node, List<int> results)
        {
            if (node == null) return;
            results.Add(node.Data);
            PreOrderTraverse(node.Left, results);
            PreOrderTraverse(node.Right, results);
        }
    }; 
}
