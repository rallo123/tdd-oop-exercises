using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_6_Potential_Solutions
{
    public class CarListSorter
    {
        public IComparer<Car> Comparer { get; set; }

        public void SortList(List<Car> cars)
        {
            cars.Sort(Comparer);
        }
    }
}
