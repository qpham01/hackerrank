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

        public BinaryHeap(T[] items, IComparer<T> comparer)
        {
            _comparer = comparer;
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

        public T PeekRoot()
        {
            return _items[0];
        }

        #region Non-public

        private void ShiftUp(int i)
        {
            while (true)
            {
                if (i == 0) return;

                // First compare with sibling node.
                if (i % 2 == 1)
                {
                    if (i + 1 < _items.Count && _comparer.Compare(_items[i], _items[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        return;
                    }
                }
                else
                {
                    if (i - 1 >= 0 && _comparer.Compare(_items[i - 1], _items[i]) == 1)
                    {
                        Swap(i, i - 1);
                        i = i - 1;
                    }
                }

                // Then compare with direct parent node.
                var pi = (i % 2 == 1) ? (i - 1) / 2 : (i - 2) / 2;
                if (pi < 0) return;
                if (pi % 2 == 1) pi++;
                if (_comparer.Compare(_items[i], _items[pi]) == -1)
                {
                    Swap(i, pi);
                    i = pi;
                }
                else break;
            }
        }

        private void ShiftDown(int i)
        {
            while (true)
            {
                // First compare sibling node.
                if (i % 2 == 1)
                {
                    if (i + 1 < _items.Count && _comparer.Compare(_items[i], _items[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        i = i + 1;
                    }
                }
                else if (i > 0)
                {
                    if (i - 1 >= 0 && _comparer.Compare(_items[i - 1], _items[i]) == 1)
                    {
                        Swap(i, i - 1);
                        i = i - 1;
                    }
                }

                // Then compare with left child node
                var cl = 2 * i + 1;
                if (cl >= _items.Count) return;
                if (_comparer.Compare(_items[i], _items[cl]) == 1)
                {
                    Swap(i, cl);
                    i = cl;
                }
                else
                {
                    // If not less than left child, compare with right child node.
                    var cr = 2 * i + 2;
                    if (cr >= _items.Count) return;
                    if (_comparer.Compare(_items[i], _items[cr]) == 1)
                    {
                        Swap(i, cr);
                        i = cr;
                    }
                    else return;
                }
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
