using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestTools;
using TestTools.Unit;

namespace Lecture_2_Tests
{
    public static class TestHelper
    {
        public static TestFactory Factory { get; } = new TestFactory("Lecture_2_Solutions", "Lecture_2")
        {
            DefaultConfiguration = new UnitTestConfiguration()
            {
            }
        };
    }
}
