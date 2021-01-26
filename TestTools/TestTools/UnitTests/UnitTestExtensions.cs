using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.UnitTests
{
    public static class UnitTestExtensions
    {
        public static void Assign<T>(this UnitTest unitTest, TestExpression<T> left, TestExpression<T> right)
        {
            throw new NotImplementedException();
        }

        public static void Increment<T>(this UnitTest unitTest, TestExpression<T> left, TestExpression<T> right)
        {
            throw new NotImplementedException();
        }

        public static void Decrement<T>(this UnitTest unitTest, TestExpression<T> left, TestExpression<T> right)
        {
            throw new NotImplementedException();
        }

        public static void ThrowsExceptionOn<TException>(this UnitTest.AssertObject assertObject, TestExpression expression)
        {
            throw new NotImplementedException();
        }

        public static void ThrowsExceptionOn<TException, T>(this UnitTest.AssertObject assertObject, TestExpression<T> expression)
        {
            throw new NotImplementedException();
        }

        public static void ThrowsExceptionOnAssignment<TException, T>(this UnitTest.AssertObject assertObject, TestExpression<T> left, TestExpression<T> right)
        {
            throw new NotImplementedException();
        }
    }
}
