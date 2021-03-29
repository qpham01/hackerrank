using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class StackQueue
    {
        public static string isBalanced(string s)
        {

            var stack = new Stack<char>();
            var chars = s.ToCharArray();
            foreach (var c in chars)
            {
                if (c == '[' || c == '{' || c == '(') stack.Push(c);
                else if (c == ']' || c == '}' || c == ')')
                {
                    if (stack.Count == 0) return "NO";                    
                    var open = stack.Pop();
                    if (c == ']' && open != '[') return "NO";
                    if (c == '}' && open != '{') return "NO";
                    if (c == ')' && open != '(') return "NO";
                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }

        public static int largestRectangle(int[] heights)
        {
            var maxArea = heights.Length;
            var stack = new Stack<int>();
            var queue = new Queue<int>();
            foreach (var h in heights)
            {
                stack.Push(h);
                queue.Enqueue(h);
            }

            var previousArea = 0;
            while (stack.Count > 0 && queue.Count > 0)
            {
                var area = stack.Min() * stack.Count;
                if (maxArea < area)
                {
                    maxArea = area;
                }

                stack.Pop();

                area = queue.Min() * queue.Count;
                if (maxArea < area)
                {
                    maxArea = area;
                }

                queue.Dequeue();
            }
            return maxArea;
        }
    }
}
