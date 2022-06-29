using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace HackerRank.Tests
{
    public class AStarTests
    {
        private static double[,] _map1;
        private static double[,] _map2;

        public static bool Blocked(double cost)
        {
            return cost > 5.0;
        }

        public static double EuclideanDistance((int, int) start, (int, int) end)
        {
            var dx = start.Item1 - end.Item1;
            var dy = start.Item2 - end.Item2;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private AStar _sut;

        [SetUp]
        public void SetUp()
        {
            _map1 = new[,]
            {
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0},
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0},
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0},
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0},
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0},
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0},
            };
            _map2 = new[,]
            {
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
            };

            _sut = new AStar();
        }

        [Test]
        public void TestNearestDiagonalPath()
        {
            var path = _sut.BuildPath(AStarDirections.Eight, _map1, (0, 0), (5, 5), EuclideanDistance, Blocked);
            var mapSize = _map1.GetLength(0);
            Assert.AreEqual(_map1.GetLength(0), path.Count);
            for (var i = 0; i < mapSize; i++)
            {
                Assert.AreEqual(path[i].Item1, i);
                Assert.AreEqual(path[i].Item2, i);
            }
        }

        [Test]
        public void TestNearestHorizontalPath()
        {
            var path = _sut.BuildPath(AStarDirections.Eight, _map1, (0, 3), (5, 3), EuclideanDistance, Blocked);
            var mapSize = _map1.GetLength(0);
            Assert.AreEqual(_map1.GetLength(0), path.Count);
            for (var i = 0; i < mapSize; i++)
            {
                Assert.AreEqual(path[i].Item1, i);
                Assert.AreEqual(path[i].Item2, 3);
            }
        }

        [Test]
        public void TestNearestVerticalPath()
        {
            var path = _sut.BuildPath(AStarDirections.Eight, _map1, (4, 0), (4, 5), EuclideanDistance, Blocked);
            var mapSize = _map1.GetLength(0);
            Assert.AreEqual(_map1.GetLength(0), path.Count);
            for (var i = 0; i < mapSize; i++)
            {
                Assert.AreEqual(path[i].Item1, 4);
                Assert.AreEqual(path[i].Item2, i);
            }
        }

        [TestCase(0, 0, 5, 5, 8)]
        [TestCase(0, 3, 5, 3, 6)]
        [TestCase(0, 5, 5, 0, 9)]
        public void TestBottomOpening(int x1, int y1, int x2, int y2, int expected)
        {
            for (var i = 0; i < 5; ++i)
            {
                _map1[3, i] = 6.0;
            }
            var path = _sut.BuildPath(AStarDirections.Eight, _map1, (x1, y1), (x2, y2), EuclideanDistance, Blocked);
            Assert.AreEqual(expected, path.Count);
        }

        [TestCase(0, 0, 9, 9, 16)]
        [TestCase(0, 5, 9, 5, 14)]
        [TestCase(0, 9, 9, 0, 14)]
        public void TestTwoObstacles(int x1, int y1, int x2, int y2, int expected)
        {
            for (var i = 1; i < 9; ++i)
            {
                _map2[3, i] = 6.0;
            }
            for (var i = 2; i < 10; ++i)
            {
                _map2[7, i] = 6.0;
            }
            var path = _sut.BuildPath(AStarDirections.Eight, _map2, (x1, y1), (x2, y2), EuclideanDistance, Blocked);
            Assert.AreEqual(expected, path.Count);
        }

        [TestCase(0, 0, 5, 5, 8)]
        [TestCase(0, 3, 5, 3, 6)]
        [TestCase(0, 5, 5, 0, 9)]
        public void TestNoPath(int x1, int y1, int x2, int y2, int expected)
        {
            for (var i = 0; i < 6; ++i)
            {
                _map1[3, i] = 6.0;
            }
            var path = _sut.BuildPath(AStarDirections.Eight, _map1, (x1, y1), (x2, y2), EuclideanDistance, Blocked);
            Assert.IsNull(path);
        }

        [Test]
        public void TestNearestDiagonalPathFour()
        {
            var path = _sut.BuildPath(AStarDirections.Four, _map1, (0, 0), (5, 5), EuclideanDistance, Blocked);
            var mapSize = _map1.GetLength(0);
            Assert.AreEqual(_map1.GetLength(0) * 2 - 1, path.Count);
        }

        [Test]
        public void TestNearestHorizontalPathFour()
        {
            var path = _sut.BuildPath(AStarDirections.Four, _map1, (0, 3), (5, 3), EuclideanDistance, Blocked);
            var mapSize = _map1.GetLength(0);
            Assert.AreEqual(_map1.GetLength(0), path.Count);
            for (var i = 0; i < mapSize; i++)
            {
                Assert.AreEqual(path[i].Item1, i);
                Assert.AreEqual(path[i].Item2, 3);
            }
        }

        [Test]
        public void TestNearestVerticalPathFour()
        {
            var path = _sut.BuildPath(AStarDirections.Four, _map1, (4, 0), (4, 5), EuclideanDistance, Blocked);
            var mapSize = _map1.GetLength(0);
            Assert.AreEqual(_map1.GetLength(0), path.Count);
            for (var i = 0; i < mapSize; i++)
            {
                Assert.AreEqual(path[i].Item1, 4);
                Assert.AreEqual(path[i].Item2, i);
            }
        }

        [TestCase(0, 0, 5, 5, 11)]
        [TestCase(0, 3, 5, 3, 10)]
        [TestCase(0, 5, 5, 0, 11)]
        public void TestBottomOpeningFour(int x1, int y1, int x2, int y2, int expected)
        {
            for (var i = 0; i < 5; ++i)
            {
                _map1[3, i] = 6.0;
            }
            var path = _sut.BuildPath(AStarDirections.Four, _map1, (x1, y1), (x2, y2), EuclideanDistance, Blocked);
            Assert.AreEqual(expected, path.Count);
        }

        [TestCase(0, 0, 9, 9, 19)]
        [TestCase(0, 5, 9, 5, 20)]
        [TestCase(0, 9, 9, 0, 19)]
        public void TestTwoObstaclesFour(int x1, int y1, int x2, int y2, int expected)
        {
            for (var i = 1; i < 9; ++i)
            {
                _map2[3, i] = 6.0;
            }
            for (var i = 2; i < 10; ++i)
            {
                _map2[7, i] = 6.0;
            }
            var path = _sut.BuildPath(AStarDirections.Four, _map2, (x1, y1), (x2, y2), EuclideanDistance, Blocked);
            Assert.AreEqual(expected, path.Count);
        }

        [TestCase(0, 0, 5, 5, 8)]
        [TestCase(0, 3, 5, 3, 6)]
        [TestCase(0, 5, 5, 0, 9)]
        public void TestNoPathFour(int x1, int y1, int x2, int y2, int expected)
        {
            for (var i = 0; i < 6; ++i)
            {
                _map1[3, i] = 6.0;
            }
            var path = _sut.BuildPath(AStarDirections.Four, _map1, (x1, y1), (x2, y2), EuclideanDistance, Blocked);
            Assert.IsNull(path);
        }
    }
}
