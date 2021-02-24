using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using TestTools.Syntax;

namespace TestTools_Tests.Syntax.Attributes
{
    [TestClass]
    public class FieldSetAttributeTests
    {
        class Fixture
        {
            public int Field;

            public int SetField(int value) => Field = value;

            public int GetNonExistentField() => throw new NotImplementedException();
        }

        readonly FieldInfo FixtureField = typeof(Fixture).GetField("Field");
        readonly MethodInfo FixtureSetField = typeof(MethodInfo).GetMethod("SetField", new Type[0]);
        readonly MethodInfo FixutreSetNonExistentField = typeof(MethodInfo).GetMethod("SetNonExistentField", new Type[0]);

        [TestMethod("Transform replaces method-call expression with field expression")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.GetField(5)
            Expression input = Expression.Call(instance, FixtureSetField, Expression.Constant(5));

            // instance.Field = 5
            Expression field = Expression.Field(instance, FixtureField);
            Expression expected = Expression.Assign(field, Expression.Constant(5));

            Expression actual = new FieldSetAttribute("Field").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no field with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.SetNonExistentField(5)
            Expression input = Expression.Call(instance, FixutreSetNonExistentField, Expression.Constant(5));

            FieldSetAttribute attribute = new FieldSetAttribute("NonExistentField");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
