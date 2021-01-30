using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace TestTools.Unit
{
    public class TestExpression
    {
        protected TestExpression()
        {
            throw new NotImplementedException();
        }

        public static TestExpression Create(Expression<Action> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression Create<T1>(TestVariable<T1> var, Expression<Action<T1>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression Create<T1, T2>(TestVariable<T1> var1, TestVariable<T2> var2, Expression<Action<T1, T2>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression Create<T1, T2, T3>(TestVariable<T1> var1, TestVariable<T2> var2, TestVariable<T3> var3, Expression<Action<T1, T2, T3>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Create<T>(Expression<Func<T>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Create<T1, T>(TestVariable<T1> var, Expression<Func<T1, T>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Create<T1, T2, T>(TestVariable<T1> var1, TestVariable<T2> var2, Expression<Func<T1, T2, T>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Create<T1, T2, T3, T>(TestVariable<T1> var1, TestVariable<T2> var2, TestVariable<T3> var3, Expression<Func<T1, T2, T3, T>> expression)
        {
            throw new NotImplementedException();
        }
    }

    public class TestExpression<T> : TestExpression
    {
        protected TestExpression()
        {
            throw new NotImplementedException();
        } 
    }
}
