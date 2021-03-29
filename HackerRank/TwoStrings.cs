using System;
using System.Collections.Generic;

namespace HackerRank
{
    class TwoStrings
    {

        static HashSet<string> MakeSubstringSet(string s, int length)
        {
            var substringSet = new HashSet<string>();
            for (var i = 0; i <= s.Length - length; ++i)
            {
                substringSet.Add(s.Substring(i, length));
            }
            return substringSet;
        }

        static HashSet<string> MakeAllSubstringSet(string s)
        {
            var substringSet = new HashSet<string>();
            for (var i = 0; i <= s.Length; ++i)
            {
                for (var j = 1; j < s.Length - i; ++j)
                {
                    substringSet.Add(s.Substring(i, j));
                }
            
            }

            return substringSet;
        }

        static string twoStrings2(string s1, string s2)
        {

            var result = "NO";

            var shorterString = s1.Length < s2.Length ? s1 : s2;
            var substringSet1 = MakeAllSubstringSet(s1);
            var substringSet2 = MakeAllSubstringSet(s2);
            substringSet1.IntersectWith(substringSet2);
            if (substringSet1.Count > 0)
            {
                result = "YES";
            }

            return result;
        }

        // Complete the twoStrings function below.
        static string twoStrings1(string s1, string s2)
        {

            var result = "NO";

            var shorterString = s1.Length < s2.Length ? s1 : s2;
            for (var j = 1; j <= 1; ++j)
            {
                var substringSet1 = MakeSubstringSet(s1, j);
                var substringSet2 = MakeSubstringSet(s2, j);
                Console.WriteLine($"Intersection {substringSet1.Count} substrings with {substringSet2.Count} substrings of length {j}.");
                substringSet1.IntersectWith(substringSet2);
                if (substringSet1.Count > 0)
                {
                    result = "YES";
                    break;
                }
            }

            return result;
        }
    }
}