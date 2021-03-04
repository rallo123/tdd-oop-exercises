using System;
using System.Collections.Generic;
using System.Text;
using TestTools;
using TestTools.Unit;
using System.Linq.Expressions;

namespace Lecture_4_Tests
{
    public static class TestHelper
    {
        public static TestFactory Factory { get; } = new TestFactory("Lecture_4_Solutions", "Lecture_4")
        {
            DefaultConfiguration = new UnitTestConfiguration()
            {
            }
        };
    }
}
