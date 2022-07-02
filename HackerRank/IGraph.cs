using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public interface INode<T>
    {
        T Value { get; }
    }

    public interface IEdge<T>
    {
        INode<T> Node1 { get; }
        INode<T> Node2 { get; }
        double Weight { get; }

    }
    public interface IGraph<T>
    {
        int NodeCount { get; }
        INode<T>[] AllNodes { get; }
        IEdge<T>[] GetEdgesByValue(T value);
        void AddNode(T value);
        void AddEdge(T start, T end, double weight, bool bidirectional);
    }
}
