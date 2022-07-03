using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class SimpleTimer : IDisposable
    {
        private readonly string _label;
        private readonly Stopwatch _stopwatch;
        public SimpleTimer(string label)
        {
            _label = label;
            _stopwatch = Stopwatch.StartNew();
        }

        public double ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;

        public void Dispose()
        {
            _stopwatch.Stop();
            Console.WriteLine($"{_label}: {_stopwatch.ElapsedMilliseconds}");
        }
    }
}
