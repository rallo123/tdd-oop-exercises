using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_6_Potential_Solutions
{
    public interface IRandom
    {
        int Next();
        int Next(int max);
        int Next(int min, int max);
    }
}
