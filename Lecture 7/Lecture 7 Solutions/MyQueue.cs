using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_7_Solutions
{
    public class MyQueue<T>
    {
        T[] _data;

        public int Count { get; private set; }

        public int MaxCount { get; }

        public MyQueue(int maxCount) {
            _data = new T[maxCount];
            MaxCount = maxCount;
        }

        public void Enqueue(T value)
        {
            if (Count >= MaxCount)
                throw new InvalidOperationException("Queue is already full");

            for(int i = Count; i > 0; i--)
            {
                _data[i + 1] = _data[i];
            }
            _data[Count++] = value;
        } 

        public T Dequeue()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Queue is already empty");
            
            for(int i = 0; i < Count; i++)
            {
                _data[i] = _data[i + 1];
            }
            Count--;

            return _data[0];
        }

        public T Peek()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Queue is already empty");

            return _data[0];
        }
    }
}
