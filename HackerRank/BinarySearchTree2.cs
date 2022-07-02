﻿using System;
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
        int[] BreadthFirstSearch();
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
        public int[] BreadthFirstSearch()
        {
            throw new NotImplementedException();
        }

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

        #endregion
    }
}