using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Syntax;
using System.Linq.Expressions;
using System.Reflection;
using static TestTools_Tests.TestHelper;

namespace TestTools_Tests.Syntax
{
    [TestClass]
    public class MethodCallAttributeTests
    {
        class Fixture
        {
            public void VoidMethod()
            {
                throw new NotImplementedException();
            }

            public void VoidMethod(int value)
            {
                throw new NotImplementedException();
            }

            public void CallVoidMethod() => VoidMethod();

            public void CallVoidMethod(int value) => VoidMethod(value);

            public int CallVoidMethodAsInt() => throw new NotImplementedException();

            public int CallVoidMethod(int value1, int value2) => throw new NotImplementedException();
        }

        MethodInfo FixtureVoidMethod1 = typeof(Fixture).GetMethod("VoidMethod", new Type[0]);
        MethodInfo FixtureVoidMethod2 = typeof(Fixture).GetMethod("VoidMethod", new Type[] { typeof(int) });
        MethodInfo FixtureCallVoidMethod1 = typeof(Fixture).GetMethod("CallVoidMethod", new Type[0]);
        MethodInfo FixtureCallVoidMethod2 = typeof(Fixture).GetMethod("CallVoidMethod", new Type[] { typeof(int) });
        MethodInfo FixtureCallVoidMethod3 = typeof(Fixture).GetMethod("CallVoidMethod", new Type[] { typeof(int), typeof(int) });
        MethodInfo FixtureCallVoidMethodAsInt = typeof(Fixture).GetMethod("CallVoidMethodAsInt", new Type[0]);

        [TestMethod("Transform replaces method-call expression without arguments with method-call expression")]
        public void Transform_ReplacesMethodCallWithoutArgumentsExpressionWithMethodExpression()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.CallVoidMethod()
            Expression input = Expression.Call(instance, FixtureCallVoidMethod1);

            // instance.ViodMethod()
            Expression expected = Expression.Call(instance, FixtureVoidMethod1);
            
            Expression actual = new MethodCallAttribute("VoidMethod").Transform(input);

            AssertAreEqualExpressions(expected, actual);
        }

        [TestMethod("Transform replaces method-call expression with arguments with method-call expression")]
        public void Transform_ReplacesMethodCallExpressionWithArgumentsWithMethodCallExpression()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.CallVoidMethod(5)
            Expression input = Expression.Call(instance, FixtureCallVoidMethod2, Expression.Constant(5));

            // instance.VoidMethod(5)
            Expression expected = Expression.Call(instance, FixtureVoidMethod2, Expression.Constant(5));

            Expression actual = new MethodCallAttribute("VoidMethod").Transform(input);

            AssertAreEqualExpressions(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if no constructor with equavilent parameter list is found")]
        public void Transform_ThrowsArgumentException_IfNoConstructorWithEquavilentParameterListIsFound()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // Fixture.CallVoidMethod(5, 5)
            Expression input = Expression.Call(instance, FixtureCallVoidMethod3, Expression.Constant(5), Expression.Constant(5));

            MethodCallAttribute attribute = new MethodCallAttribute("VoidMethod");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }

        [TestMethod("Transform throws ArgumentException if method type is not matched")]
        public void Transform_ThrowsArgumetnException_IfMethodReturnTypeIsNotMatched()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // Fixture.CallVoidMethodAsInt()
            Expression input = Expression.Call(instance, FixtureCallVoidMethodAsInt);

            MethodCallAttribute attribute = new MethodCallAttribute("VoidMethod");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
