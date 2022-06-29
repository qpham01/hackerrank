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

        public static void shift(int[] a, int start, int count, int distance)
        {
            if (distance == 0) return;
            var first = start + distance;
            if (first < 0) throw new InvalidOperationException("Cannot shift beyond start of array.");
            if (first + count > a.Length) throw new InvalidOperationException("Cannot shift beyond end of array.");
            if (distance < 0)
            {
                for (var i = 0; i < count; ++i)
                {
                    a[first + i] = a[start + i];
                }
            }
            else
            {
                for (var i = count - 1; i >= 0; --i)
                {
                    a[first + i] = a[start + i];
                }
            }
        }

        public static int BubbleSort(int[] a)
        {
            var n = a.Length;
            var allSwapCount = 0;
            for (int i = 0; i < n; i++)
            {
                var swapCount = 0;
                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        swap(a, j, j + 1);
                        swapCount++;
                        allSwapCount++;
                    }
                }
                if (swapCount == 0) break;
            }

            return allSwapCount;
        }

        public static void SelectionSort(int[] a)
        {
            var n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                var min = int.MaxValue;
                var minIndex = -1;
                for (int j = i; j < n; j++)
                {
                    if (min > a[j])
                    {
                        min = a[j];
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                    swap(a, minIndex, i);
            }
        }

        public static void InsertionSort(int[] a)
        {
            var n = a.Length;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < a[0])
                {
                    var temp = a[i];
                    Sort.shift(a, 0, i, 1);
                    a[0] = temp;
                }
                else
                {
                    for (var j = 1; j < i; ++j)
                    {
                        if (a[i] > a[j - 1] && a[i] <= a[j])
                        {
                            var temp = a[i];
                            Sort.shift(a, j, i - j, 1);
                            a[j] = temp;
                        }
                    }
                }
            }
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
