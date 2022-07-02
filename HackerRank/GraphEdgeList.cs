using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class GNode<T> : INode<T>
    {
        public T Value => _value;
        private readonly T _value;

        public GNode(T value)
        {
            _value = value;
        }
    }

    public class GEdge<T> : IEdge<T>
    {
        public INode<T> Node1 => _node1;
        public INode<T> Node2 => _node2;
        public double Weight => _weight;

        private readonly INode<T> _node1;
        private readonly INode<T> _node2;
        private readonly double _weight;

        public GEdge(INode<T> node1, INode<T> node2, double weight)
        {
            _node1 = node1;
            _node2 = node2;
            _weight = weight;
        }
    }


    public class GraphEdgeList<T> : IGraph<T>
    {
        #region Public
        public int NodeCount => _nodeTable.Values.Count;

        public INode<T>[] AllNodes => _nodeTable.Values.ToArray();

        public void AddNode(T value)
        {
            _nodeTable.Add(value, new GNode<T>(value));
        }

        public void AddEdge(T start, T end, double weight, bool bidirectional)
        {
            var startNode = _nodeTable[start];
            var endNode = _nodeTable[end];
            var edge = new GEdge<T>(startNode, endNode, weight);
            if (!_edgeTable.TryGetValue(start, out var edges))
            {
                edges = new List<IEdge<T>>();
                _edgeTable.Add(start, edges);
            }
            edges.Add(edge);
            if (bidirectional)
            {
                edge = new GEdge<T>(endNode, startNode, weight);
                if (!_edgeTable.TryGetValue(end, out edges))
                {
                    edges = new List<IEdge<T>>();
                    _edgeTable.Add(end, edges);
                }
                edges.Add(edge);
            }
        }

        public IEdge<T>[] GetEdgesByValue(T value)
        {
            if (_edgeTable.TryGetValue(value, out var edges))
            {
                return edges.ToArray();
            }
            return null;
        }

        #endregion;

        #region Non-Public
        private readonly IDictionary<T, INode<T>> _nodeTable = new Dictionary<T, INode<T>>();
        private readonly IDictionary<T, List<IEdge<T>>> _edgeTable = new Dictionary<T, List<IEdge<T>>>();
        #endregion
    }
}
