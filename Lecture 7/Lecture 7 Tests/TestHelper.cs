using System;
using System.Collections.Generic;
using System.Text;
using TestTools;
using TestTools.Unit;
using System.Linq.Expressions;

namespace Lecture_7_Tests
{
    public static class TestHelper
    {
        static TestHelper()
        {
            // To force the inclusion of the Lecture 7 Exercises assembly
            // a class from this assembly is referenced 
            Lecture_7.Program.Main(new string[0]);
        }

        // public static TestFactory Factory { get; } = new TestFactory("Lecture_7_Solutions", "Lecture_7_Solutions");
        public static TestFactory Factory { get; } = new TestFactory("Lecture_7_Solutions", "Lecture_7");
    }
}
