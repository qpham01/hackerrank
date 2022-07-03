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
        public List<IEdge<T>> Edges => _edges;

        
        private readonly T _value;
        private readonly List<IEdge<T>> _edges;
        
        public GNode(T value)
        {
            _value = value;
            _edges = new List<IEdge<T>>();
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
            startNode.Edges.Add(edge);
            if (bidirectional)
            {
                var reverseEdge = new GEdge<T>(endNode, startNode, weight);
                endNode.Edges.Add(reverseEdge);
            }
        }

        public IEdge<T>[] GetEdgesByValue(T value)
        {
            if (_nodeTable.TryGetValue(value, out var node))
            {
                return node.Edges.ToArray();
            }
            return null;
        }

        public T[] BreadthFirstSearch(T start, T target)
        {
            if (!_nodeTable.TryGetValue(start, out var startNode)) return null;
            var queue = new Queue<INode<T>>();
            var toVisit = new HashSet<T>();
            var orderedVisits = new List<T>();
            queue.Enqueue(startNode);
            toVisit.Add(start);
            BreadthFirstVisit(queue, toVisit, orderedVisits, target);
            return orderedVisits.ToArray();
        }

        public T[] DepthFirsSearch(T start, T target)
        {
            throw new NotImplementedException();
        }

        #endregion;

        #region Non-Public
        private readonly IDictionary<T, INode<T>> _nodeTable = new Dictionary<T, INode<T>>();

        private void BreadthFirstVisit(Queue<INode<T>> queue, HashSet<T> toVisit, List<T> orderedVisits, T target)
        {
            if (queue.Count == 0) return;
            var node = queue.Dequeue();
            orderedVisits.Add(node.Value);
            if (node.Value.Equals(target)) return;
            foreach (var edge in node.Edges)
            {
                if (toVisit.Contains(edge.Node2.Value)) continue;
                toVisit.Add(edge.Node2.Value);
                queue.Enqueue(edge.Node2);
            }
            BreadthFirstVisit(queue, toVisit, orderedVisits, target);
        }
        #endregion
    }
}
