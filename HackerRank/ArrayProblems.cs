using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace HackerRank
{
    public class ArrayProblems
    {
        public static int migratoryBirds(List<int> arr)
        {

            var valueMap = new SortedDictionary<int, int>();
            foreach (var n in arr)
            {
                if (valueMap.ContainsKey(n)) valueMap[n]++;
                else valueMap.Add(n, 1);
            }
            var values = new string[valueMap.Count];
            var i = 0;
            foreach (var key in valueMap.Keys)
            {
                var s = $"{valueMap[key]}:{key}";
                values[i] = s;
                i++;
            }
            Array.Sort(values);
            var count = -1;
            var previousItem = 0;
            for (var j = values.Length - 1; j >= 0; j--)
            {
                var parts = values[j].Split(new[] { ':' });
                var itemCount = int.Parse(parts[0]);
                var item = int.Parse(parts[1]);
                if (count < 0) count = itemCount;
                if (j == 0) return previousItem == 0 ? item : previousItem;
                if (itemCount < count) return previousItem;
                previousItem = item;
            }

            return 0;
        }
        
    }
}
