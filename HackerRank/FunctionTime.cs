using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class FunctionTime
    {
        private int _machineTime;
        private Stack<string> _calls = new Stack<string>();
        private Dictionary<string, int> _results = new Dictionary<string, int>();
        public Dictionary<string, int> Results => _results;

        public void CalculateTimeSpent(string[] functions, string[] operations, int[] timestamps)
        {
            _machineTime = timestamps[0];
            for (var i = 0; i < functions.Length; ++i)
            {
                _results.TryAdd(functions[i], 0);
            }
            for (var i = 0; i < functions.Length; ++i)
            {
                if (operations[i] == "E") EnterCall(functions[i], timestamps[i]);
                if (operations[i] == "X") ExitCall(functions[i], timestamps[i]);
            }
        }

        public void EnterCall(string function, int timeStamp)
        {
            _calls.TryPeek(out var parent);
            if (parent != null)
            {
                _results[parent] += timeStamp - _machineTime;
            }
            _calls.Push(function);
            _machineTime = timeStamp;
        }

        public void ExitCall(string function, int timeStamp)
        {
            _results[function] += timeStamp - _machineTime;
            _calls.Pop();
            _machineTime = timeStamp;
        }
    }
}
