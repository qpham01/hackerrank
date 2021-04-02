using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class Extensions
    {
        public static void AddOrUpdate<T, U>(this Dictionary<T, U> map, T key, U value)
        {
            if (map.ContainsKey(key)) map[key] = value;
            else map.Add(key, value);
        }
    }
}
