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
    public class EventRemoveAttributeTests
    {
        class Fixture
        {
            EventHandler _propertyEvent;

            public event EventHandler FieldEvent;

            public event EventHandler PropertyEvent { 
                add => _propertyEvent += value; 
                remove => _propertyEvent -= value; 
            }

            public void RemoveFieldEvent(EventHandler handler) => FieldEvent -= handler;

            public void RemovePropertyEvent(EventHandler handler) => PropertyEvent -= handler;

            public void RemoveNonExistentEvent(EventHandler handler) => PropertyEvent += handler;
        }

        readonly MethodInfo DelegateRemove = typeof(Delegate).GetMethod("Remove");

        readonly FieldInfo FixtureFieldEvent = typeof(Fixture).GetField("FieldEvent");
        readonly PropertyInfo FixturePropertyEvent = typeof(Fixture).GetProperty("PropertyEvent");
        readonly MethodInfo FixtureRemoveField = typeof(MethodInfo).GetMethod("RemoveField", new Type[] { typeof(EventHandler) });
        readonly MethodInfo FixtureRemovePropertyEvent = typeof(MethodInfo).GetMethod("RemovePropertyEvent", new Type[] { typeof(EventHandler) });
        readonly MethodInfo FixtureRemoveNonExistentEvent = typeof(MethodInfo).GetMethod("RemoveNonExistentEvent", new Type[] { typeof(EventHandler) });

        [TestMethod("Transform replaces method-call expression with add-assign expression for field events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.RemoveFieldEvent(handler);
            Expression input = Expression.Call(instance, FixtureRemoveField, handler);

            // instance.FieldEvent = Deletate.Combine(instance.FieldEvent, handler)
            Expression field = Expression.Field(instance, FixtureFieldEvent);
            Expression call = Expression.Call(DelegateRemove, field, handler);
            Expression expected = Expression.Assign(field, call);

            Expression actual = new EventRemoveAttribute("FieldEvent").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform replaces method-call expression with add-assign expression for property events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForPropertyEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.RemovePropertyEvent(handler);
            Expression input = Expression.Call(instance, FixtureRemovePropertyEvent, handler);

            // instance.PropertyEvent = Deletate.Remove(instance.PropertyEvent, handler)
            Expression property = Expression.Property(instance, FixturePropertyEvent);
            Expression call = Expression.Call(DelegateRemove, property, handler);
            Expression expected = Expression.Assign(property, call);

            Expression actual = new EventRemoveAttribute("PropertyEvent").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no field or property with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.RemoveNonExistentEvent(handler);
            Expression input = Expression.Call(instance, FixtureRemoveNonExistentEvent, handler);

            EventRemoveAttribute attribute = new EventRemoveAttribute("NonExistentEvent");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
