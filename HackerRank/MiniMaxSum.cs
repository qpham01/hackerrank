using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class MiniMaxSum
    {

        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static long[] Solution(List<uint> arr)
        {
            var sorted = arr.ToArray();
            Array.Sort(sorted);
            long min = sorted[0] + sorted[1] + sorted[2] + sorted[3];
            long i = sorted.Length - 4;
            long max = sorted[i] + sorted[i + 1] + sorted[i + 2] + sorted[i + 3];
            return new long[] { min, max };
        }

    }
}
