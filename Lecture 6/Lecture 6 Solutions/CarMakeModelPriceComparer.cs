using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lecture_6_Solutions
{
    public class CarMakeModelPriceComparer : IComparer<Car>
    {
        public int Compare([AllowNull] Car x, [AllowNull] Car y)
        {
            if (x == null || y == null)
                return 1;

            if (x.Make != y.Make)
                return x.Make.CompareTo(y.Make);

            if (x.Model != y.Model)
                return x.Model.CompareTo(y.Model);

            return (int)(x.Price - y.Price);
        }
    }
}
