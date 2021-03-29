using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace HackerRank.Tests
{
    class AlternatingCharacterTests
    {
        [TestCase("AAAA", 3)]
        [TestCase("BBBBB", 4)]
        [TestCase("ABABABAB", 0)]
        [TestCase("BABABA", 0)]
        [TestCase("AAABBB", 4)]
        public void TestAlternatingCharacters(string s, int expected)
        {
            var result = AlternatingCharacters.alternatingCharacters(s);
            Assert.AreEqual(expected, result);
        }
    }
}
