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
        public static TestFactory Factory { get; } = new TestFactory("Lecture_7_Solutions", "Lecture_7")
        {
            DefaultConfiguration = new UnitTestConfiguration()
            {
            }
        };
    }
}
