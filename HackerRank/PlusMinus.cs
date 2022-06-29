using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class PlusMinus
    {

        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static string[] Solution(List<int> arr)
        {
            int posCount = 0;
            int negCount = 0;
            int totalCount = arr.Count;
            foreach (var i in arr)
            {
                if (i > 0) posCount++;
                if (i < 0) negCount++;
            }
            double posRatio = (double)posCount / (double)totalCount;
            double negRatio = (double)negCount / (double)totalCount;
            double zeroRatio = (double)(totalCount - posCount - negCount) / (double)totalCount;

            return new string[]
                { posRatio.ToString("0.000000"), negRatio.ToString("0.000000"), zeroRatio.ToString("0.000000") };
        }
    }
}
