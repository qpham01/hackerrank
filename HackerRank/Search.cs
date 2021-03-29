using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class Search
    {
        public static (int,int) TwoNumberSumSearchHash(int[] input, int sum)
        {
            var map = new Dictionary<int, List<int>>();
            for (var i = 0; i < input.Length; ++i)
            {
                var value = input[i];
                if (!map.ContainsKey(value)) map.Add(value, new List<int> {i});
                else map[value].Add(i);
            }
            for (var i = 0; i < input.Length; ++i)
            {
                var value = input[i];
                var other = sum - value;
                if (map.ContainsKey(other))
                {
                    var list = map[other];
                    if (value == other && list.Count < 2) continue;
                    return list.Count > 1 ? (i, map[other][1]) : (i, map[other][0]);
                }
            }

            return (-1, -1);
        }

        public static (int, int) TwoNumberSumSearch(int[] input, int target)
        {
            var map = new Dictionary<int, int>();
            for (var i = 0; i < input.Length; ++i)
            {
                var value = input[i];
                var diff = target - value;
                if (map.TryGetValue(diff, out var index))
                {
                    return (index, i);
                }

                if (!map.ContainsKey(value)) map.Add(value, i);
            }

            return (-1, -1);
        }
        public static void whatFlavors1(int[] costs, int money)
        {
            var result = TwoNumberSumSearch(costs, money);
            Console.WriteLine($"{result.Item1 + 1} {result.Item2 + 1}");
        }
    }
}
