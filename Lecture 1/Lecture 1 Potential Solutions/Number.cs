using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_1_Potential_Solutions
{
    public class Number
    {
        public Number(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public void Add(Number operand)
        {
            Value += operand.Value;
        }

        public void Subtract(Number operand)
        {
            Value -= operand.Value;
        }

        public void Multiply(Number operand)
        {
            Value *= operand.Value;
        }

        public override bool Equals(object obj)
        {
            if(obj is Number)
            {
                return ((Number)obj).Value == Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
