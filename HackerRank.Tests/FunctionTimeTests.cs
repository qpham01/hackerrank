using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class FunctionTimeTests
    {
        [Test]
        public static void Test1()
        {
            var functions = new[] { "F1", "F2", "F2", "F1" };
            var operations = new[] { "E", "E", "X", "X" };
            var timestamps = new[] { 10, 20, 30, 40 };
            var solution = new FunctionTime();
            solution.CalculateTimeSpent(functions, operations, timestamps);
            var result = solution.Results;
            Assert.AreEqual(20, result["F1"]);
            Assert.AreEqual(10, result["F2"]);
        }

        [Test]
        public static void Test2()
        {
            var functions = new[] { "F1", "F2", "F3", "F3", "F4", "F4", "F2", "F1" };
            var operations = new[] { "E", "E", "E", "X", "E", "X", "X", "X" };
            var timestamps = new[] { 100, 110, 120, 130, 140, 150, 160, 170 };
            var solution = new FunctionTime();
            solution.CalculateTimeSpent(functions, operations, timestamps);
            var result = solution.Results;
            Assert.AreEqual(20, result["F1"]);
            Assert.AreEqual(30, result["F2"]);
            Assert.AreEqual(10, result["F3"]);
            Assert.AreEqual(10, result["F4"]);
        }
    }
}
