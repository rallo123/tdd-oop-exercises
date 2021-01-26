using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestTools.UnitTests;

namespace TestTools.Helpers
{
    public class ExpressionHelper
    {
        public static TestExpression Assignment<T>(TestExpression<T> leftSide, TestExpression<T> rightSide)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<Action> Lambda(TestExpression expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<Func<T>> Lambda<T>(TestExpression<T> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<Action<TDelegate>> LambdaSubscribe<T, TDelegate>(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}
