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

        public static TestExpression<bool> And(TestExpression<bool> leftSide, TestExpression<bool> rightSide)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Assign<T>(TestExpression<T> leftSide, TestExpression<T> rightSide)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Const<T>(T value) => Expr(() => value);

        public static TestExpression<TDelegate> Event<TDelegate>(TestExpression<object> expression, string eventName) where TDelegate : Delegate
        {
            throw new NotImplementedException();
        }

        public static TestExpression Expr(Expression<Action> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression Expr<T1>(TestVariable<T1> var, Expression<Action<T1>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression Expr<T1, T2>(TestVariable<T1> var1, TestVariable<T2> var2, Expression<Action<T1, T2>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression Expr<T1, T2, T3>(TestVariable<T1> var1, TestVariable<T2> var2, TestVariable<T3> var3, Expression<Action<T1, T2, T3>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Expr<T>(Expression<Func<T>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Expr<T1, T>(TestVariable<T1> var, Expression<Func<T1, T>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Expr<T1, T2, T>(TestVariable<T1> var1, TestVariable<T2> var2, Expression<Func<T1, T2, T>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<T> Expr<T1, T2, T3, T>(TestVariable<T1> var1, TestVariable<T2> var2, TestVariable<T3> var3, Expression<Func<T1, T2, T3, T>> expression)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<bool> Or(TestExpression<bool> leftSide, TestExpression<bool> rightSide)
        {
            throw new NotImplementedException();
        }

        public static TestExpression<bool> Not(TestExpression<bool> expression)
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

        public static TestExpression Subscribe<TDelegate>(TestExpression<TDelegate> rightSide, TestExpression<TDelegate> leftSide) where TDelegate : Delegate
        {
            throw new NotImplementedException();
        }

        public static TestExpression UnSubscribe<TDelegate>(TestExpression<TDelegate> rightSide, TestExpression<TDelegate> leftSide) where TDelegate : Delegate
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
