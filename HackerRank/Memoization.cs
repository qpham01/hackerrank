using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class Memoization
    {
        public static Dictionary<int, int> _cache = new Dictionary<int, int>();

        public static int AddTo80(int n)
        {
            return 80 + n;
        }

        public static int MemoizedAddTo80(int n)
        {
            if (_cache.TryGetValue(n, out var result)) return result;
            result = 80 + n;
            _cache.Add(n, result);
            return result;
        }
    }
}
