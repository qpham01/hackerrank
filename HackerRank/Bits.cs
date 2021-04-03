using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class Bits
    {
        public static long flippingBits(long n)
        {
            var m = (uint) n;
            Console.WriteLine(bitString(m));
            Console.WriteLine("--------------------------------");
            uint r = 0;
            for (var i = 0; i < 32; ++i)
            {
                if ((m & 1) == 0) r += 1u << i;
                m >>= 1;
                Console.WriteLine(bitString(r));
            }

            return (long) r;
        }

        public static string bitString(uint n)
        {
            var sb = new StringBuilder();
            for (var i = 31; i >= 0; i--)
            {
                var b = (uint) 1 << i;
                var s = ((n & b) > 0) ? "1" : "0";
                sb.Append(s);
            }

            return sb.ToString();
        }
    }
}
