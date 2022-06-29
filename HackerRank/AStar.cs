using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HackerRank
{
    public enum AStarDirections
    {
        Four,
        Eight
    }

    public class AStarNode
    {
        public (int, int) Location { get; set; }
        public double F { get; set; }
        public double G { get; set; }
        public double H { get; set; }
        public double Cost { get; set; }
        public AStarNode Parent { get; set; }

        public void ClearCosts()
        {
            F = 0;
            G = 0;
            H = 0;
        }
    }

    public class AStarComparer : IComparer<AStarNode>
    {
        public int Compare(AStarNode x, AStarNode y)
        {
            if (x == null || y == null) throw new InvalidOperationException();
            if (x.F > y.F) return 1;
            if (x.F < y.F) return -1;
            return 0;
        }
    }

    public class AStar
    {
        public int OpenQueueSize => _openQueue.Count;
        public int CloseListSize => _closeList.Count;
        public int QueueInserts => _queueInserts;

        private readonly PriorityQueue<AStarNode> _openQueue;
        private readonly Dictionary<(int, int), AStarNode> _closeList;
        private static ConsoleLogger Log = new ConsoleLogger("AStar");

        private int _queueInserts;

        public AStar()
        {
            _openQueue = new PriorityQueue<AStarNode>(new AStarComparer());
            _closeList = new Dictionary<(int, int), AStarNode>();
        }

        public List<(int, int)> BuildPath(AStarDirections directions, double[,] costs, (int, int) start, (int, int) end, Func<(int, int), (int, int), double> distanceFunc, Func<double, bool> blocked)
        {
            if (start == end) return new List<(int, int)>();
            var maxX = costs.GetLength(0);
            var maxY = costs.GetLength(1);
            if (InvalidLocation(maxX, maxY, start)) throw new InvalidOperationException($"Invalid start {start}");
            if (InvalidLocation(maxX, maxY, end)) throw new InvalidOperationException($"Invalid end {end}");
            _openQueue.Clear();
            _closeList.Clear();

            var first = new AStarNode() {Location = start, Parent = null, Cost = costs[start.Item1, start.Item2]};
            first.ClearCosts();
            _openQueue.Enqueue(first);

            _queueInserts = 1;

            while (_openQueue.Count > 0)
            {
                var current = _openQueue.Dequeue();
                List<AStarNode> neighbors = directions == AStarDirections.Eight 
                    ? GetNeighborsEight(costs, current, current.Location, blocked)
                    : GetNeighborsFour(costs, current, current.Location, blocked);

                foreach (var n in neighbors)
                {
                    if (n.Location == end)
                    {
                        Log.LogInfo($"Open Queue Size: {OpenQueueSize}");
                        Log.LogInfo($"Queue Inserts: {QueueInserts}");
                        Log.LogInfo($"Closed Spaces: {CloseListSize}");
                        var path = MakePath(current);
                        path.Add(n.Location);
                        return path;
                    }

                    n.G = current.G + n.Cost;
                    n.H = distanceFunc(n.Location, end);
                    n.F = n.G + n.H;

                    var openNodes = _openQueue.Items;
                    var skip = false;
                    foreach (var node in openNodes)
                    {
                        if (node.Location == n.Location && node.F < n.F)
                        {
                            skip = true;
                            break;
                        }
                    }

                    if (skip) continue;

                    if (_closeList.TryGetValue(n.Location, out var closeNode))
                    {
                        if (closeNode.F < n.F) continue;
                    }
                    _openQueue.Enqueue(n);
                    _queueInserts++;
                }
                _closeList.AddOrUpdate(current.Location, current);
            }

            Log.LogInfo($"Open Queue Size: {OpenQueueSize}");
            Log.LogInfo($"Queue Inserts: {QueueInserts}");
            Log.LogInfo($"Closed Spaces: {CloseListSize}");
            Log.LogError($"No path found from {start} to {end}");
            return null;
        }

        private bool InvalidLocation(int maxX, int maxY, (int, int) location)
        {
            var x = location.Item1;
            var y = location.Item2;
            return (x < 0 || x >= maxX || y < 0 || y >= maxY);
        }

        private List<(int, int)> MakePath(AStarNode end)
        {
            var stack = new Stack<AStarNode>();
            var next = end;
            while (next != null)
            {
                stack.Push(next);
                next = next.Parent;
            }

            var list = new List<(int, int)>();
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                list.Add(node.Location);
            }

            return list;
        }

        private List<AStarNode> GetNeighborsFour(double[,] costs, AStarNode parent, (int, int) location, Func<double, bool> blocked)
        {
            var maxX = costs.GetLength(0);
            var maxY = costs.GetLength(1);
            var x = location.Item1;
            var y = location.Item2;
            var neighbors = new List<AStarNode>();
            var coords = new[] {(x, y - 1), (x, y + 1), (x - 1, y), (x + 1, y)};
            foreach (var xy in coords)
            {
                var i = xy.Item1;
                var j = xy.Item2;
                if (i < 0 || i >= maxX || j < 0 || j >= maxY || blocked(costs[i, j])) continue;
                neighbors.Add(new AStarNode { Cost = costs[i, j], Location = (i, j), Parent = parent });
            }
            return neighbors;
        }

        private List<AStarNode> GetNeighborsEight(double[,] costs, AStarNode parent, (int, int) location, Func<double, bool> blocked)
        {
            var maxX = costs.GetLength(0);
            var maxY = costs.GetLength(1);
            var x = location.Item1;
            var y = location.Item2;
            var neighbors = new List<AStarNode>();
            for (var i = x - 1; i <= x + 1; ++i)
            {
                if (i < 0 || i >= maxX) continue;
                for (var j = y - 1; j <= y + 1; ++j)
                {
                    if (j < 0 || j >= maxY || (i == x && j == y) || blocked(costs[i,j])) continue;
                    var n = new AStarNode {Cost = costs[i, j], Location = (i, j), Parent = parent};
                    neighbors.Add(n);
                }
            }

            return neighbors;
        }
    }
}
