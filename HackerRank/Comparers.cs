using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class IntComparerMin : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return 1;
            if (x < y) return -1;
            return 0;
        }
    }

    public class IntComparerMax : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return -1;
            if (x < y) return 1;
            return 0;
        }
    }

}
