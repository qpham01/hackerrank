using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class MinimumSwap
    {

        // Complete the minimumSwaps function below.
        public static int minimumSwaps1(int[] arr)
        {
            var size = arr.Length;
            var swapCount = 0;
            for (var i = 0; i < arr.Length; ++i)
            {
                var value = arr[i];
                if (value == i + 1)
                {
                    size -= 1;
                    if (size == 0)
                        break;
                    continue;
                }
                else if (arr[i] > i && arr[value - 1] == i + 1)
                {
                    size -= 2;
                    swapCount++;
                }
            }

            return swapCount + (size > 0 ? size - 1 : 0);
        }

        public static int minimumSwaps(int[] arr)
        {
            var table = new int[arr.Length + 1];
            for (var i = 0; i < arr.Length; ++i)
            {
                table[arr[i]] = i;
            }

            var size = arr.Length;
            var swapCount = 0;
            for (var n = 1; n <= size; ++n)
            {
                var index = n - 1;
                if (arr[n - 1] == n) continue;
                var i = table[n];
                var temp = arr[n - 1];
                arr[n - 1] = arr[i];
                arr[i] = temp;
                swapCount++;
            }

            return swapCount;
        }

        public static int minimumSwaps2(int[] arr)
        {

            var minSwap = 0;
            while (true)
            {
                var swap1 = -1;
                var swap2 = -1;
                var value1 = -1;
                for (var i = 0; i < arr.Length; ++i)
                {
                    var value = arr[i];
                    var expected = i + 1;
                    if (value == expected) continue;
                    if (swap1 < 0)
                    {
                        swap1 = i;
                        value1 = arr[i];
                    }
                    else
                    {
                        if (value < value1)
                        {
                            swap2 = i;
                            value1 = arr[i];
                        }
                    }
                }
                if (swap1 < 0 && swap2 < 0) break;
                var temp = arr[swap1];
                arr[swap1] = arr[swap2];
                arr[swap2] = temp;
                minSwap++;
            }
            return minSwap;
        }
    }
}
