using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HackerRank
{
    public class FindShortestClone
    {
        static int _shortestDistance;
        static int _currentDistance;
        static long _value;

        public static void DepthFirstSearch(GraphNode[] nodes, GraphNode node, int fromNode, List<int> searchedNodes = null)
        {
            Console.WriteLine($"Visited {node.Id}");
            if (searchedNodes != null)
                searchedNodes.Add(node.Id);
            if (_currentDistance >= 0)
            {
                _currentDistance++;
                Console.WriteLine($"Updated distance {_currentDistance} for {_value}");
            }
            var distanceCache = _currentDistance;
            if (node.Value == _value)
            {
                if (_currentDistance > 0 && _currentDistance < _shortestDistance)
                {
                    _shortestDistance = _currentDistance;
                }
                _currentDistance = 0;
            }

            if (node.Visited)
            {
                return;
            }
            node.Visited = true;

            foreach (var nextNode in node.Edges)
            {
                if (nextNode == fromNode) continue;
                DepthFirstSearch(nodes, nodes[nextNode], node.Id, searchedNodes);
            }
            if (distanceCache >= 0) _currentDistance = distanceCache - 1;
        }

        public static int findShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] ids, long val, List<int> searchNodes = null)
        {
            var graph = new Graph(ids);
            for (var i = 0; i < graphFrom.Length; ++i)
            {
                graph.Add2wayEdge(graphFrom[i] - 1, graphTo[i] - 1);
            }
            _value = val;
            _currentDistance = -1;
            _shortestDistance = int.MaxValue;
            var nodes = graph.Nodes;
            for (var i = 0; i < nodes.Length; ++i)
            {
                if (nodes[i].Value == _value)
                {
                    DepthFirstSearch(nodes, nodes[i], -1, searchNodes);
                    break;
                }
            }
            return _shortestDistance == int.MaxValue ? -1 : _shortestDistance;
        }

        public class Comparer : IComparer<(long, int)>
        {
            public int Compare([AllowNull] (long, int) x, [AllowNull] (long, int) y)
            {
                if (x.Item2 > y.Item2) return 1;
                if (x.Item2 < y.Item2) return -1;
                if (x.Item1 > y.Item1) return 1;
                if (x.Item1 < y.Item1) return -1;
                return 0;
            }
        }
    }
}
