using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Syntax;

namespace Lecture_6_Solutions
{
    public class CarSorter
    {
        public IComparer<Car> Comparer { get; set; }

        public void Sort(Car[] cars)
        {
            if (Comparer == null)
                return;

            Array.Sort(cars, Comparer);
        }

        // TestTool Code
        [PropertySet("Comparer")]
        public void SetComparer(IComparer<Car> value) => Comparer = value;
    }
}
