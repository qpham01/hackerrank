using NUnit.Framework;

namespace HackerRank.Tests
{
    public class MinimumSwapTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Ignore("Not working")]
        [TestCase(new [] {4, 3, 1, 2}, 3)]
        [TestCase(new [] {4, 3, 2, 1}, 2)]
        [TestCase(new [] {6, 2, 5, 3, 4, 1 }, 3)]
        [TestCase(new [] {3, 7, 6, 9, 1, 8, 10, 4, 2, 5}, 9)]
        [TestCase(new [] {7, 1, 3, 2, 4, 5, 6}, 5)]
        [TestCase(new [] { 8, 45, 35, 84, 79, 12, 74, 92, 81, 82, 61, 32, 36, 1, 65, 44, 89, 40, 28, 20, 97, 90, 22, 87, 48, 26, 56, 18, 49, 71, 23, 34, 59, 54, 14, 16, 19, 76, 83, 95, 31, 30, 69, 7, 9, 60, 66, 25, 52, 5, 37, 27, 63, 80, 24, 42, 3, 50, 6, 11, 64, 10, 96, 47, 38, 57, 2, 88, 100, 4, 78, 85, 21, 29, 75, 94, 43, 77, 33, 86, 98, 68, 73, 72, 13, 91, 70, 41, 17, 15, 67, 93, 62, 39, 53, 51, 55, 58, 99, 46 }, 91)]
        public void TestMinimumSwap(int[] arr, int minSwap)
        {
            var answer = HackerRank.MinimumSwap.minimumSwaps(arr);
            Assert.AreEqual(minSwap, answer);
        }

        [TestCase(new[] { 4, 3, 1, 2 }, 3)]
        [TestCase(new[] { 4, 3, 2, 1 }, 2)]
        [TestCase(new[] { 6, 2, 5, 3, 4, 1 }, 3)]
        [TestCase(new[] { 3, 7, 6, 9, 1, 8, 10, 4, 2, 5 }, 9)]
        [TestCase(new[] { 7, 1, 3, 2, 4, 5, 6 }, 5)]
        [TestCase(new[] { 8, 45, 35, 84, 79, 12, 74, 92, 81, 82, 61, 32, 36, 1, 65, 44, 89, 40, 28, 20, 97, 90, 22, 87, 48, 26, 56, 18, 49, 71, 23, 34, 59, 54, 14, 16, 19, 76, 83, 95, 31, 30, 69, 7, 9, 60, 66, 25, 52, 5, 37, 27, 63, 80, 24, 42, 3, 50, 6, 11, 64, 10, 96, 47, 38, 57, 2, 88, 100, 4, 78, 85, 21, 29, 75, 94, 43, 77, 33, 86, 98, 68, 73, 72, 13, 91, 70, 41, 17, 15, 67, 93, 62, 39, 53, 51, 55, 58, 99, 46 }, 91)]
        public void TestMinimumSwap2(int[] arr, int minSwap)
        {
            var answer = HackerRank.MinimumSwap.minimumSwaps2(arr);
            Assert.AreEqual(minSwap, answer);
        }
    }
}