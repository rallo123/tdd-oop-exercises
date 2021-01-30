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
        public static TestFactory Factory { get; } = new TestFactory("Lecture_2")
        {
            DefaultConfiguration = new UnitTestConfiguration()
            {
                FloatPrecision = 0.001F,
                DecimalPrecision = 0.001M,
                DoublePrecision = 0.001
            }
        };

        public static TestExpression<T> Const<T>(T value) => TestExpression.Create(() => value);

        public static TestExpression Expr(Expression<Action> expression) => TestExpression.Create(expression);

        public static TestExpression Expr<T1>(TestVariable<T1> var, Expression<Action<T1>> expression) => TestExpression.Create(var, expression);

        public static TestExpression Expr<T1, T2>(TestVariable<T1> var1, TestVariable<T2> var2, Expression<Action<T1, T2>> expression) => TestExpression.Create(var1, var2, expression);

        public static TestExpression Expr<T1, T2, T3>(TestVariable<T1> var1, TestVariable<T2> var2, TestVariable<T3> var3, Expression<Action<T1, T2, T3>> expression) => TestExpression.Create(var1, var2, var3, expression);

        public static TestExpression<T> Expr<T>(Expression<Func<T>> expression) => TestExpression.Create(expression);

        public static TestExpression<T> Expr<T1, T>(TestVariable<T1> var, Expression<Func<T1, T>> expression) => TestExpression.Create(var, expression);

        public static TestExpression<T> Expr<T1, T2, T>(TestVariable<T1> var1, TestVariable<T2> var2, Expression<Func<T1, T2, T>> expression) => TestExpression.Create(var1, var2, expression);

        public static TestExpression<T> Expr<T1, T2, T3, T>(TestVariable<T1> var1, TestVariable<T2> var2, TestVariable<T3> var3, Expression<Func<T1, T2, T3, T>> expression) => TestExpression.Create(var1, var2, var3, expression);
    }
}
