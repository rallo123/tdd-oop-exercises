using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Unit
{
    public static class UnitTestExtensions
    {
        public static void ThrowsExceptionOn<TException>(this UnitTest.AssertObject assertObject, TestExpression expression)
        {
            throw new NotImplementedException();
        }

        public static void ThrowsExceptionOn<TException, T>(this UnitTest.AssertObject assertObject, TestExpression<T> expression)
        {
            throw new NotImplementedException();
        }
    }
}
