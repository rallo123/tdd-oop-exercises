using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Syntax;
using System.Linq.Expressions;
using System.Reflection;

namespace TestTools_Tests.Syntax
{
    [TestClass]
    public class ConstructorCallAttributeTests
    {
        class Fixture
        {
            public Fixture() { }

            public Fixture(int value) { }

            public static Fixture CreateTestClass() => new Fixture();

            public static Fixture CreateTestClass(int value) => new Fixture(value);

            public static Fixture CreateClass(int value1, int value2) => throw new NotImplementedException();
        }

        ConstructorInfo FixtureConstructor1 = typeof(Fixture).GetConstructor(new Type[0]);
        ConstructorInfo FixtureConstructor2 = typeof(Fixture).GetConstructor(new Type[] { typeof(int) });
        MethodInfo FixtureCreateTestClass1 = typeof(MethodInfo).GetMethod("CreateTestClass", new Type[0]);
        MethodInfo FixtureCreateTestClass2 = typeof(MethodInfo).GetMethod("CreateTestClass", new Type[] { typeof(int) });
        MethodInfo FixtureCreateTestClass3 = typeof(MethodInfo).GetMethod("CreateTestClass", new Type[] { typeof(int), typeof(int) });

        [TestMethod("Transform replaces method call expression without arguments with new expression")]
        public void Transform_ReplacesMethodCallWithoutArgumentsExpressionWithNewExpression()
        {
            // Fixture.CreateTestClass()
            Expression input = Expression.Call(FixtureCreateTestClass1);

            // new Fixture()
            Expression expected = Expression.New(FixtureConstructor1);
            
            Expression actual = new ConstructorCallAttribute().Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform replaces method call expression with arguments with new expression")]
        public void Transform_ReplacesMethodCallExpressionWithArgumentsWithNewExpression()
        {
            // Fixture.CreateTestClass(5)
            Expression input = Expression.Call(FixtureCreateTestClass2, Expression.Constant(5));

            // new Fixture(5)
            Expression expected = Expression.New(FixtureConstructor2, Expression.Constant(5));

            Expression actual = new ConstructorCallAttribute().Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if no constructor with equavilent parameter list is found")]
        public void Transform_ThrowsArgumentException_IfNoConstructorWithEquavilentParameterListIsFound()
        {
            // Fixture.CreateTestClass(5, 5)
            Expression input = Expression.Call(FixtureCreateTestClass3, Expression.Constant(5), Expression.Constant(5));

            ConstructorCallAttribute attribute = new ConstructorCallAttribute();
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
