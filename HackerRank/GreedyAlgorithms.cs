using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HackerRank
{
    public class GreedyAlgorithms
    {
        public static int minimumAbsoluteDifference(int[] arr)
        {
            var list = new SortedList<int, int>();
            foreach (var value in arr)
            {
                if (list.ContainsKey(value)) return 0;
                list.Add(value, 1);
            }

            var minDiff = int.MaxValue;
            var first = true;
            var previousValue = 0;
            foreach (var item in list)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    var diff = Math.Abs(item.Key - previousValue);
                    if (diff == 0) return 0;
                    if (diff < minDiff) minDiff = diff;
                }

                previousValue = item.Key;
            }
            return minDiff;
        }
    }
}
