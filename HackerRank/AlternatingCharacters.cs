using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class AlternatingCharacters
    {
        public static int alternatingCharacters(string s)
        {

            var count = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (i > 0 && s[i - 1] == s[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
