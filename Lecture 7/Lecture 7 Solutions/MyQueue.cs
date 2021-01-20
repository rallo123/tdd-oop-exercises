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

        public MyQueue(int maxLength) {
            _data = new T[maxLength];
        }

        public void Enqueue(T value)
        {
            EndPosition++;

            if (StartPosition == EndPosition)
            {
                EndPosition--;
                throw new Exception("Exceeds queue length");
            }

            _data[EndPosition] = value;
        } 

        public T Dequeue()
        {
            StartPosition++;

            if (StartPosition == EndPosition)
            {
                StartPosition--;
                throw new Exception("Queue is empty");
            }

            return _data[StartPosition];
        }
    }
}
