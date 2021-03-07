using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using TestTools.Syntax;
using static TestTools_Tests.TestHelper;

namespace TestTools_Tests.Syntax
{
    [TestClass]
    public class PropertyGetAttributeTests
    {
        class Fixture
        {
            public int Property { get; set; }

            public int WriteonlyProperty { set { } }

            public int GetProperty() => Property;

            public int GetNonExistentProperty() => throw new NotImplementedException();

            public int GetWriteonlyProperty() => throw new NotImplementedException();
        }

        readonly PropertyInfo FixtureProperty = typeof(Fixture).GetProperty("Property");

        readonly MethodInfo FixtureGetProperty = typeof(Fixture).GetMethod("GetProperty", new Type[0]);
        readonly MethodInfo FixtureGetNonExistentProperty = typeof(Fixture).GetMethod("GetNonExistentProperty", new Type[0]);
        readonly MethodInfo FixtureGetWriteonlyProperty = typeof(Fixture).GetMethod("GetWriteonlyProperty", new Type[0]);

        [TestMethod("Transform replaces method-call expression with property expression")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.GetProperty()
            Expression input = Expression.Call(instance, FixtureGetProperty);

            // instance.Property
            Expression expected = Expression.Property(instance, FixtureProperty);

            Expression actual = new PropertyGetAttribute("Property").Transform(input);

            AssertAreEqualExpressions(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no property with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.GetNonExistentProperty()
            Expression input = Expression.Call(instance, FixtureGetNonExistentProperty);

            PropertyGetAttribute attribute = new PropertyGetAttribute("NonExistentProperty");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }

        [TestMethod("Transform throws ArgumentException on writeonly property")]
        public void Transform_ThrowsArgumentExceptionOnReadonlyProperty()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");

            // instance.GetWriteonlyProperty()
            Expression input = Expression.Call(instance, FixtureGetWriteonlyProperty);

            PropertyGetAttribute attribute = new PropertyGetAttribute("ReadonlyProperty");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
