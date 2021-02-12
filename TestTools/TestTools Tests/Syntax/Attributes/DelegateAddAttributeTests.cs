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
    class DelegateAddAttributeTests
    {
        class Fixture
        {
            public Action FieldDelegate;

            public Action PropertyDelegate { get; set; }

            public void AddFieldDelegate(Action handler) => FieldDelegate += handler;

            public void AddPropertyDelegate(Action handler) => PropertyDelegate += handler;

            public void AddNonExistentDelegate(EventHandler handler) => throw new NotImplementedException();
        }

        readonly MethodInfo DelegateCombine = typeof(Delegate).GetMethod("Combine");

        readonly FieldInfo FixtureFieldDelegate = typeof(Fixture).GetField("FieldDelegate");
        readonly PropertyInfo FixturePropertyDelegate = typeof(Fixture).GetProperty("PropertyDelegate");
        readonly MethodInfo FixtureAddDelegate = typeof(MethodInfo).GetMethod("AddFieldDelegate", new Type[] { typeof(Action) });
        readonly MethodInfo FixtureAddPropertyDelegate = typeof(MethodInfo).GetMethod("AddPropertyDelegate", new Type[] { typeof(Action) });
        readonly MethodInfo FixtureAddNonExistentDelegate = typeof(MethodInfo).GetMethod("AddNonExistentDelegate", new Type[] { typeof(Action) });

        [TestMethod("Transform replaces method-call expression with add-assign expression for field events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.AddFieldDelegate(handler);
            Expression input = Expression.Call(instance, FixtureAddDelegate, handler);

            // instance.FieldDelegate = Deletate.Combine(instance.FieldDelegate, handler)
            Expression field = Expression.Field(instance, FixtureFieldDelegate);
            Expression call = Expression.Call(DelegateCombine, field, handler);
            Expression expected = Expression.Assign(field, call);

            Expression actual = new EventAddAttribute("FieldDelegate").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform replaces method-call expression with add-assign expression for property events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForPropertyEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.AddPropertyDelegate(handler);
            Expression input = Expression.Call(instance, FixtureAddPropertyDelegate, handler);

            // instance.PropertyDelegate = Deletate.Combine(instance.PropertyDelegate, handler)
            Expression property = Expression.Property(instance, FixturePropertyDelegate);
            Expression call = Expression.Call(DelegateCombine, property, handler);
            Expression expected = Expression.Assign(property, call);

            Expression actual = new EventAddAttribute("PropertyDelegate").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no field or property with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.AddNonExistentDelegate(handler);
            Expression input = Expression.Call(instance, FixtureAddNonExistentDelegate, handler);

            EventAddAttribute attribute = new EventAddAttribute("NonExistentDelegate");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
