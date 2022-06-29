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

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(5, 5)]
        [TestCase(8, 21)]
        [TestCase(11, 89)]
        public void TestFibonacci(int i, int answer)
        {
            Assert.AreEqual(answer, _sut.Fibonacci(i));
        }

        [TestCase("hello", "olleh")]
        [TestCase("fibonacci", "iccanobif")]
        [TestCase("good morning", "gninrom doog")]
        public void TestReverseString(string start, string reversed)
        {
            var result = _sut.ReverseString(start);
            Assert.That(reversed, Is.EqualTo(result));
        }
    }
}
