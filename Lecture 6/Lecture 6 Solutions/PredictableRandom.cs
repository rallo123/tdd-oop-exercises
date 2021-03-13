using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_6_Solutions
{
    public class PredictableRandom : IRandom
    {
        int _value;

        public PredictableRandom(int value)
        {
            _value = value;
        }

        public int Next()
        {
            return _value;
        }

        public int Next(int max)
        {
            if (_value > max)
                throw new ArgumentException();

            return _value;
        }

        public int Next(int min, int max)
        {
            if (_value < min || _value > max)
                throw new ArgumentException();

            return _value;
        }
    }
}
