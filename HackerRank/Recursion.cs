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
    }
}
