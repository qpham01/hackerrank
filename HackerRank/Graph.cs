using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HackerRank
{
    public class GraphNode
    {
        public int Id;
        public long Value;
        public bool Visited = false;
        public List<int> Edges = new List<int>();
    }

    public class Graph
    {
        List<GraphNode> _nodes = new List<GraphNode>();
        public GraphNode[] Nodes => _nodes.ToArray();

        public Graph(long[] nodeValues)
        {
            var nodeCount = nodeValues.Length;
            for (var i = 0; i < nodeCount; ++i)
            {
                _nodes.Add(new GraphNode { Id = i, Value = nodeValues[i] });
            }
        }

        public void Add2wayEdge(int node1, int node2)
        {
            _nodes[node1].Edges.Add(node2);
            _nodes[node2].Edges.Add(node1);
        }
    }
}
