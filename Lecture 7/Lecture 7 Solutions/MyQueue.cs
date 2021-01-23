using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_7_Solutions
{
    public class MyQueue<T>
    {
        int _startPosition = 0;
        int _endPosistion = 0;
        T[] _data;

        private int StartPosition
        {
            get => _startPosition;
            set => _startPosition = value % _data.Length;
        }

        private int EndPosition
        {
            get => _endPosistion;
            set => _endPosistion = value % _data.Length;
        }

        public int Count
        {
            get
            {
                if (StartPosition > EndPosition)
                    return EndPosition + (_data.Length - StartPosition);
               
                return EndPosition - StartPosition;
            }
        }

        public int MaxCount { get; }

        public MyQueue(int maxCount) {
            _data = new T[maxCount];
            MaxCount = maxCount;
        }

        public void Enqueue(T value)
        {
            EndPosition++;

            if (StartPosition == EndPosition)
            {
                EndPosition--;
                throw new InvalidOperationException("Queue is already full");
            }

            _data[EndPosition] = value;
        } 

        public T Dequeue()
        {
            StartPosition++;

            if (StartPosition == EndPosition)
            {
                StartPosition--;
                throw new InvalidOperationException("Queue is already empty");
            }

            return _data[StartPosition];
        }

        public T Peek()
        {
            if (StartPosition + 1 == EndPosition)
                throw new InvalidOperationException("Queue is already empty");

            return _data[StartPosition];
        }

    }
}
