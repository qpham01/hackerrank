using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    class BitTests
    {
        [TestCase(2147483647, 2147483648)]
        [TestCase(1, 4294967294)]
        [TestCase(0, 4294967295)]
        public void FlippingBitsTests(long input, long expected)
        {
            var result = Bits.flippingBits(input);
            Assert.AreEqual(expected, result);
        }
    }
}
