using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{

    public class RecursionTests
    {
        private Recursion _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Recursion();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(5, 120)]
        public void TestFactorial(int n, int answer)
        {
            Assert.AreEqual(answer, _sut.Factorial(n));
        }

    }
}
