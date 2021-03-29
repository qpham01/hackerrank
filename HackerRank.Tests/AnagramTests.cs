using NUnit.Framework;

namespace HackerRank.Tests
{
    public class AnagramTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("mo", "om", true)]
        public void TestIsAnagram(string s1, string s2, bool expected)
        {
            var result = Anagrams.IsAnagrams(s1, s2);
            Assert.AreEqual(expected, result);
        }

        [TestCase("mom", 2)]
        [TestCase("abba", 4)]
        [TestCase("bbcaadacaacbdddcdbddaddabcccdaaadcadcbddadababdaaabcccdcdaacadcababbabbdbacabbdcbbbbbddacdbbcdddbaaa", 4832)]
        [TestCase("babacaccaaabaaaaaaaccaaaccaaccabcbbbabccbbabababccaabcccacccaaabaccbccccbaacbcaacbcaaaaaaabacbcbbbcc", 8640)]
        [TestCase("cacccbbcaaccbaacbbbcaaaababcacbbababbaacabccccaaaacbcababcbaaaaaacbacbccabcabbaaacabccbabccabbabcbba", 13022)]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 166650)]
        public void TestCountAnagrams(string s, int expected)
        {
            var result = Anagrams.CountAnagrams(s);
            Assert.AreEqual(expected, result);
        }

        [TestCase("cde", "abc", 4)]
        [TestCase("cde", "dcf", 2)]
        public void TestMakeAnagrams(string s1, string s2, int expected)
        {
            var result = Anagrams.makeAnagram(s1, s2);
            Assert.AreEqual(expected, result);
        }
    }
}
