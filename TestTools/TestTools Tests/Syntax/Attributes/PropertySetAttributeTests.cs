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
    class PropertySetAttributeTests
    {
        class Fixture
        {
            public int Property { get; set; }
            
            public int ReadonlyProperty {
                get => throw new NotImplementedException();
            }

            public int SetProperty(int value) => Property = value;

            public int GetNonExistentProperty() => throw new NotImplementedException();

            public int GetReadonlyProperty() => throw new NotImplementedException();
        }

        readonly PropertyInfo FixtureProperty = typeof(Fixture).GetProperty("Property");

        readonly MethodInfo FixtureSetProperty = typeof(MethodInfo).GetMethod("SetProperty", new Type[0]);
        readonly MethodInfo FixtureSetNonExistentProperty = typeof(MethodInfo).GetMethod("GetNonExistentProperty", new Type[0]);
        readonly MethodInfo FixtureReadonlyProperty = typeof(MethodInfo).GetMethod("GetReadonlyProperty", new Type[0]);


        [TestMethod("Transform replaces method-call expression with field expression")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.SetProperty(5)
            Expression input = Expression.Call(instance, FixtureSetProperty, Expression.Constant(5));

            // instance.Property = 5
            Expression property = Expression.Property(instance, FixtureProperty);
            Expression expected = Expression.Assign(property, Expression.Constant(5));

            Expression actual = new PropertySetAttribute("Property").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no property with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.SetNonExistentProperty(5)
            Expression input = Expression.Call(instance, FixtureSetNonExistentProperty, Expression.Constant(5));

            PropertySetAttribute attribute = new PropertySetAttribute("NonExistentProperty");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }

        [TestMethod("Transform throws ArgumentException on readonly property")]
        public void Transform_ThrowsArgumentException_OnReadonlyProperty()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.SetReadonlyProperty(5)
            Expression input = Expression.Call(instance, FixtureReadonlyProperty, Expression.Constant(5));

            PropertySetAttribute attribute = new PropertySetAttribute("ReadonlyProperty");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
