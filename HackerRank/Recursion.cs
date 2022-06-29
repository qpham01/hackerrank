using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class Recursion
    {
        public int Factorial(int n, int previous = 1)
        {
            if (n == 0) return previous;
            previous *= n;
            return Factorial(n - 1, previous);
        }

        public int Fibonacci(int i)
        {
            var arraySize = i + 1;
            int[] fib = new int[arraySize];
            fib[0] = 0;
            if (i == 0) return fib[i];
            fib[1] = 1;
            if (i == 1) return fib[i];
            RecursiveFibonacci(i, 2, fib);
            return fib[i];
        }

        private void RecursiveFibonacci(int maxIndex, int i, int[] fibArray)
        {
            fibArray[i] = fibArray[i - 1] + fibArray[i - 2];
            if (i == maxIndex) return;
            RecursiveFibonacci(maxIndex, i + 1, fibArray);
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
