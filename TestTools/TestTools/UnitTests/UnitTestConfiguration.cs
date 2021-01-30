using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Unit
{
    public class UnitTestConfiguration
    {
        /* Float, decimal, and double are not well suited for direct comparison, 
         * because of floating-point errors. So in order to accomodate these errors, 
         * floating-point values can be compared within a margin error.
         * So v1 == v2 becomes (v2 + precision) <= v1 <= (v2 + precision)
         */
        public float? FloatPrecision { get; set; }
        public decimal? DecimalPrecision { get; set; }
        public double? DoublePrecision { get; set; }
    }
}
