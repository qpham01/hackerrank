using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class Recursion
    {
        public int RecurseCalls => _recurseCalls;
        public int MemoizedCalls => _memoizedCalls;

        private int _recurseCalls;
        private int _memoizedCalls;

        public int Factorial(int n, int previous = 1)
        {
            if (n == 0) return previous;
            previous *= n;
            return Factorial(n - 1, previous);
        }

        public static List<int> _fibList = new List<int> { 0, 1 };

        public void ResetFibCache()
        {
            _fibList.Clear();
            _fibList.Add(0);
            _fibList.Add(1);
        }

        public int FibonacciRecurse(int i)
        {
            _recurseCalls = 0;
            return InternalFibonacciRecurse(i);
        }
        public int FibonacciMemoized(int i)
        {
            _memoizedCalls = 0;
            return InternalFibonacciMemoized(i);
        }

        private int InternalFibonacciRecurse(int i)
        {
            _recurseCalls++;
            if (i < 2) return i;
            return InternalFibonacciRecurse(i - 1) + InternalFibonacciRecurse(i - 2);
        }

        private int InternalFibonacciMemoized(int n)
        {
            _memoizedCalls++;
            if (n < _fibList.Count) return _fibList[n];
            var result = InternalFibonacciMemoized(n - 1) + InternalFibonacciMemoized(n - 2);
            _fibList.Add(result);
            return result;
        }

        public string ReverseString(string start)
        {
            char[] reversed = new char[start.Length];
            RecursiveReverseString(start, 0, reversed);
            return new string(reversed);
        }

        private void RecursiveReverseString(string start, int i, char[] reversed)
        {
            reversed[start.Length - 1 - i] = start[i];
            if (i == start.Length - 1) return;
            RecursiveReverseString(start, i + 1, reversed);
        }
    }
}
