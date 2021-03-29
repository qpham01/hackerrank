using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class TwoStackQueue
    {
        private Stack<int> pushStack = new Stack<int>();
        private Stack<int> popStack = new Stack<int>();

        public void Put(int item)
        {
            pushStack.Push(item);
        }

        public int Pop()
        {
            if (popStack.Count > 0)
            {
                var p1 = popStack.Pop();
                return p1;
            }
            while (pushStack.Count > 0)
            {
                var x = pushStack.Pop();
                popStack.Push(x);
            }
            var p = popStack.Pop();

            return p;
        }

        public int Peek()
        {
            if (popStack.Count > 0)
            {
                var p1 = popStack.Peek();
                return p1;
            }
            while (pushStack.Count > 0)
            {
                var x = pushStack.Pop();
                popStack.Push(x);
            }
            return popStack.Peek();
        }

        public int[] QueueOp(string[] ops)
        {
            var result = new List<int>();
            foreach (var op in ops)
            {
                if (op.StartsWith("1"))
                {
                    var parts = op.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var data = int.Parse(parts[1]);
                    Put(data);
                }
                else if (op.StartsWith("2"))
                {
                    var data = Pop();
                }
                else if (op.StartsWith("3"))
                {
                    var data = Peek();
                    result.Add(data);
                }
            }

            return result.ToArray();
        }
    }
}
