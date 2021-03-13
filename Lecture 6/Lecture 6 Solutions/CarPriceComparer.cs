using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lecture_6_Solutions
{
    public class CarPriceComparer : IComparer<Car>
    {
        public int Compare([AllowNull] Car x, [AllowNull] Car y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;
            return x.Price.CompareTo(y.Price);
        }
    }
}
