using NUnit.Framework;

namespace HackerRank.Tests
{
    class LibraryRoadTests
    {
        private static object[][] TestCase1 = new []
        {
            new object[] { new [,] {{1, 7}, {1, 3}, {1, 2}, {2, 3}, {5, 6}, {6, 8}}, 8, 3, 2, 19}
        };
        private static object[][] TestCase2 = new[]
        {
            new object[] { new [,] {{1, 7}, {1, 3}, {1, 2}, {2, 3}, {5, 6}, {6, 8}}, 8, 2, 3, 16}
        };
        private static object[][] TestCase3 = new[]
        {
            new object[] { new [,] {{1, 2}, {3, 1}, {2, 3}}, 3, 2, 1, 4}
        };
        private static object[][] TestCase4 = new[]
        {
            new object[] { new [,] {{1, 2}, {1, 3}, {4, 5}, {4, 6}}, 6, 2, 3, 12}
        };
        private static object[][] TestCase5 = new[]
        {
            new object[] { new [,] {{8, 2}, {2, 9}}, 9, 91, 84, 805}
        };
        [Test]
        [TestCaseSource("TestCase1")]
        [TestCaseSource("TestCase2")]
        [TestCaseSource("TestCase3")]
        [TestCaseSource("TestCase4")]
        [TestCaseSource("TestCase5")]
        public void TestLibraryRoads(int[,] roads, int n, int c_lib, int c_road, int expected)
        {
            var roadCount = roads.GetLength(0);
            var roadArray = new int[roadCount][];
            for (var i = 0; i < roadCount; ++i)
            {
                var road = new[] {roads[i, 0], roads[i, 1]};
                roadArray[i] = road;
            }
            var result = LibraryRoads.roadsAndLibraries(n, c_lib, c_road, roadArray);
            Assert.AreEqual(expected, result);
        }
    }
}
