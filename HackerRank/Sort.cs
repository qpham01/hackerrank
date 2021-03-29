using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace HackerRank
{
    public class Sort
    {
        public static void swap(int[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static int BubbleSort(int[] a)
        {
            var n = a.Length;
            var swapCount = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        swap(a, j, j + 1);
                        swapCount++;
                    }
                }
            }

            return swapCount;
        }

        public static int activityNotification(int[] expenditures, int lookBackDays)
        {
            if (expenditures.Length <= lookBackDays) return 0;
            var middle = lookBackDays / 2;
            var isOdd = lookBackDays % 2 == 1;
            if (!isOdd)
            {
                middle--;
            }

            var noticeCount = 0;
            for (var i = lookBackDays; i < expenditures.Length; ++i)
            {
                var lookBackSpend = new int[lookBackDays];
                var start = i - lookBackDays;
                for (var j = start; j < i; ++j)
                {
                    lookBackSpend[j - start] = expenditures[j];
                }
                Array.Sort(lookBackSpend);
                var median = isOdd ? lookBackSpend[middle] : (lookBackSpend[middle] + lookBackSpend[middle + 1]) / 2.0;
                if (expenditures[i] >= median * 2) 
                    noticeCount++;
            }

            return noticeCount;
        }
    }
}
