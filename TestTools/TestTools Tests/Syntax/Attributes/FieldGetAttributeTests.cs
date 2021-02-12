using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using TestTools.Syntax.Attributes;

namespace TestTools_Tests.Syntax.Attributes
{
    [TestClass]
    class FieldGetAttributeTests
    {
        class Fixture
        {
            public int Field;

            public int GetField() => Field;

            public int GetNonExistentField() => throw new NotImplementedException();
        }

        readonly FieldInfo FixtureField = typeof(Fixture).GetField("Field");
        readonly MethodInfo FixtureGetField = typeof(MethodInfo).GetMethod("GetField", new Type[0]);
        readonly MethodInfo FixtureGetNonExistentField = typeof(MethodInfo).GetMethod("GetNonExistentField", new Type[0]);

        [TestMethod("Transform replaces method-call expression with field expression")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.GetField()
            Expression input = Expression.Call(instance, FixtureGetField);

            // instance.Field
            Expression expected = Expression.Field(instance, FixtureField);

            Expression actual = new FieldGetAttribute("Field").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no field with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.GetNonExistentField()
            Expression input = Expression.Call(instance, FixtureGetNonExistentField);

            FieldGetAttribute attribute = new FieldGetAttribute("NonExistentField");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
