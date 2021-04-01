using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class LibraryRoads
    {
        class Graph
        {
            public int Id;
            public HashSet<int> Cities = new HashSet<int>();
        }

        // Complete the roadsAndLibraries function below.
        public static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] roads)
        {

            var roadCount = roads.GetLength(0);
            if (c_road >= c_lib) return (long) n * c_lib;
            var cityMap = new Dictionary<int, int>();
            var graphMap = new Dictionary<int, Graph>();
            for (var i = 1; i <= n; ++i)
            {
                var graph = new Graph {Id = i};
                graph.Cities.Add(i);
                graphMap.Add(i, graph);
                cityMap.Add(i, i);
            }
            for (var i = 0; i < roadCount; ++i)
            {
                var city1 = roads[i][0];
                var city2 = roads[i][1];
                var graphId1 = -1;
                var graphId2 = -1;
                if (cityMap.TryGetValue(city1, out var outGraphId1))
                {
                    graphId1 = outGraphId1;
                }

                if (cityMap.TryGetValue(city2, out var outGraphId2))
                {
                    graphId2 = outGraphId2;
                }
                if (graphId1 < 0)
                {
                    var graph = graphMap[graphId2];
                    graph.Cities.Add(city1);
                    cityMap.Add(city1, graphId2);
                }
                else if (graphId2 < 0)
                {
                    var graph = graphMap[graphId1];
                    graph.Cities.Add(city2);
                    cityMap.Add(city2, graphId1);
                }
                else
                {
                    if (graphId1 != graphId2)
                    {
                        var graph1 = graphMap[graphId1];
                        var graph2 = graphMap[graphId2];
                        foreach (var city in graph2.Cities)
                        {
                            graph1.Cities.Add(city);
                            cityMap[city] = graph1.Id;
                        }
                        graphMap.Remove(graphId2);
                    }
                }
            }

            var cost = 0L;
            foreach (var graph in graphMap.Values)
            {
                cost += c_lib + (graph.Cities.Count - 1) * c_road;
            }
            return cost;
        }

    }
}
