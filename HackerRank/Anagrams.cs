using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class Anagrams
    {
        static List<string> MakeSubstringList(string s, int length)
        {
            var substringList = new List<string>();
            for (var i = 0; i <= s.Length - length; ++i)
            {
                substringList.Add(s.Substring(i, length));
            }

            return substringList;
        }
        public static Dictionary<string, int> MakeLetterDictionary(string s)
        {
            var table = new Dictionary<string, int>();
            for (var i = 0; i < s.Length; ++i)
            {
                var letter = s.Substring(i, 1);
                if (table.ContainsKey(letter))
                {
                    table[letter]++;
                }
                else
                {
                    table.Add(letter, 1);
                }
            }

            return table;
        }

        public static bool IsAnagrams(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            var table1 = MakeLetterDictionary(s1);
            var table2 = MakeLetterDictionary(s2);
            var result = true;
            foreach (var key in table1.Keys)
            {
                if (!table2.TryGetValue(key, out var count) || count != table1[key])
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static List<(string, string)> MakePairs(IEnumerable<string> items)
        {
            var result = new List<(string, string)>();
            var itemArray = items.ToArray();
            for (var i = 0; i < itemArray.Length; ++i)
            {
                for (var j = i + 1; j < itemArray.Length; ++j)
                {
                    result.Add((itemArray[i], itemArray[j]));
                }
            }

            return result;
        }

        public static int CountAnagrams(string s)
        {
            var result = 0;
            for (var l = 1; l < s.Length; ++l)
            {
                var substringList = MakeSubstringList(s, l);
                var pairs = MakePairs(substringList);
                foreach (var pair in pairs)
                {
                    if (IsAnagrams(pair.Item1, pair.Item2))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public static int makeAnagram(string a, string b)
        {

            var table1 = MakeLetterDictionary(a);
            var table2 = MakeLetterDictionary(b);
            var deleteCount = 0;
            var keySet = new HashSet<string>();
            foreach (var key in table1.Keys) keySet.Add(key);
            foreach (var key in table2.Keys) keySet.Add(key);
            foreach (var key in keySet)
            {
                table1.TryGetValue(key, out var value1);
                table2.TryGetValue(key, out var value2);
                deleteCount += Math.Abs(value1 - value2);
            }
            return deleteCount;
        }

        public static string validString(string s)
        {
            var table = MakeLetterDictionary(s);
            var values = table.Values.ToArray();
            var frequencySet = new Dictionary<int, int>();
            var result = "YES";
            foreach (var value in values)
            {
                if (frequencySet.ContainsKey(value)) frequencySet[value]++;
                else frequencySet.Add(value, 1);
                if (frequencySet.Count > 2)
                {
                    result = "NO";
                    break;
                }
            }

            if (result == "NO") return result;
            if (frequencySet.Count == 1) return "YES";
            if ((frequencySet.First().Key == 1 && frequencySet.First().Value == 1) ||
                (frequencySet.Last().Key == 1 && frequencySet.Last().Value == 1)) return "YES";
            if (frequencySet.First().Value > 1 && frequencySet.Last().Value > 1) return "NO";
            if (Math.Abs(frequencySet.First().Key - frequencySet.Last().Key) > 1) return "NO";
            return "YES";
        }
    }
}
