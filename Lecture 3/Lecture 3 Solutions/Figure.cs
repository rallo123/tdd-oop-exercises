using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_3_Solutions
{
    public abstract class Figure
    {
        public abstract double CalculateArea();
        public abstract bool Contains(Point p);
    }
}
