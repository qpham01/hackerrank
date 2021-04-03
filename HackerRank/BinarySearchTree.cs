using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
        }
    }

    public class BinarySearchTree
    {
        public Node root;

        public static Node lca(Node root, int v1, int v2)
        {
            //Decide if you have to call rekursively
            //Samller than both
            if (root.data < v1 && root.data < v2)
            {
                return lca(root.right, v1, v2);
            }
            //Bigger than both
            if (root.data > v1 && root.data > v2)
            {
                return lca(root.left, v1, v2);
            }

            //Else solution already found
            return root;
        }

        public static Node lca2(Node root, int v1, int v2)
        {
            var path1 = new List<Node>();
            BinarySearch(root, v1, path1);
            var path2 = new List<Node>();
            BinarySearch(root, v2, path2);
            for (var i = path1.Count - 1; i >= 0; i--)
            {
                for (var j = path2.Count - 1; j >= 0; j--)
                {
                    if (path1[i].data == path2[j].data) return path1[i];
                }
            }

            return root;
        }

        public override string ToString()
        {
            var searchNodes = new Queue<Node>();
            var searchPath = new List<int>();
            BreathFirstSearch(root, searchNodes, searchPath);
            var output = String.Join(", ", searchPath);
            return output;
        }

        public static void BinarySearch(Node node, int target, List<Node> path)
        {
            if (node.data == target) return;
            path.Add(node);
            BinarySearch(target > node.data ? node.right : node.left, target, path);
        }

        public static void BreathFirstSearch(Node node, Queue<Node> searchNodes, List<int> searchPath)
        {
            searchPath.Add(node.data);
            if (node.left != null) searchNodes.Enqueue(node.left);
            if (node.right != null) searchNodes.Enqueue(node.right);
            if (searchNodes.Count == 0) return;
            Node nextNode = searchNodes.Dequeue();
            BreathFirstSearch(nextNode, searchNodes, searchPath);
        }

        public static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        public static BinarySearchTree MakeTreeFromData(int[] data)
        {
            var tree = new BinarySearchTree();
            var root = tree.root;
            foreach (var d in data)
            {
                root = insert(root, d);
            }

            tree.root = root;
            return tree;
        }
    }
}
