using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class PriorityQueue<T>
    {
        private readonly BinaryHeap<T> _heap;

        public PriorityQueue(IComparer<T> comparer)
        {
            _heap = new BinaryHeap<T>(comparer);
        }

        public int Count => _heap.Count;
        public T[] Items => _heap.Items;

        public void Enqueue(T item)
        {
            _heap.Insert(item);
        }

        public T Dequeue()
        {
            return _heap.RemoveRoot();
        }

        public void RemoveAt(int index)
        {
            _heap.RemoveAt(index);
        }

        public void Clear()
        {
            _heap.Clear();
        }
    }
}
