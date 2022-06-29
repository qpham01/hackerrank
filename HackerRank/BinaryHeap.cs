using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class BinaryHeap<T>
    {
        public T[] Items => _items.ToArray();
        public int Count => _items.Count;
        private readonly List<T> _items = new List<T>();
        private readonly IComparer<T> _comparer;

        public BinaryHeap(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public BinaryHeap(T[] items, IComparer<T> comparer) : this(comparer)
        {
            foreach (var item in items) Insert(item);
        }

        public void Insert(T item)
        {
            _items.Add(item);
            ShiftUp(_items.Count - 1);
        }

        public T RemoveRoot()
        {
            var root = _items[0];
            var lastIndex = _items.Count - 1;
            _items[0] = _items[lastIndex];
            _items.RemoveAt(lastIndex);
            ShiftDown(0);
            return root;
        }

        public T RemoveAt(int i)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _items.Clear();
        }

        public T PeekRoot()
        {
            return _items[0];
        }

        #region Non Public

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private void ShiftUp(int i)
        {
            while (i > 0)
            {
                var pi = Parent(i);
                if (_comparer.Compare(_items[pi], _items[i]) == -1) break;
                Swap(pi, i);
                i = pi;
            }
        }

        private void ShiftDown(int i)
        {
            var next = i;

            var l = (2 * i) + 1;

            if (l < _items.Count && _comparer.Compare(_items[i], _items[l]) == 1)
            {
                next = l;
            }

            var r = l + 1;

            if (r < _items.Count && _comparer.Compare(_items[next], _items[r]) == 1)
            {
                next = r;
            }

            if (i != next)
            {
                Swap(i, next);
                ShiftDown(next);
            }
        }

        private void Swap(int i, int pi)
        {
            var temp = _items[i];
            _items[i] = _items[pi];
            _items[pi] = temp;
        }

        #endregion
    }
}
