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
    class EventAddAttributeTests
    {
        class Fixture
        {
            EventHandler _propertyEvent;

            public event EventHandler FieldEvent;

            public EventHandler FieldDelegate;

            public event EventHandler PropertyEvent { 
                add => _propertyEvent += value; 
                remove => _propertyEvent -= value; 
            }

            public void AddFieldEvent(EventHandler handler) => FieldEvent += handler;

            public void AddFieldDelegate(EventHandler handler) => PropertyEvent += handler;

            public void AddPropertyEvent(EventHandler handler) => PropertyEvent += handler;

            public void AddNonExistentEvent(EventHandler handler) => PropertyEvent += handler;
        }

        readonly MethodInfo DelegateCombine = typeof(Delegate).GetMethod("Combine");

        readonly FieldInfo FixtureFieldEvent = typeof(Fixture).GetField("FieldEvent");
        readonly PropertyInfo FixturePropertyEvent = typeof(Fixture).GetProperty("PropertyEvent");
        readonly MethodInfo FixtureAddFieldEvent = typeof(MethodInfo).GetMethod("AddFieldEvent", new Type[] { typeof(EventHandler) });
        readonly MethodInfo FixtureAddFieldDelegate = typeof(MethodInfo).GetMethod("AddFieldDelegate", new Type[] { typeof(EventHandler) });
        readonly MethodInfo FixtureAddPropertyEvent = typeof(MethodInfo).GetMethod("AddPropertyEvent", new Type[] { typeof(EventHandler) });
        readonly MethodInfo FixtureAddNonExistentEvent = typeof(MethodInfo).GetMethod("AddNonExistentEvent", new Type[] { typeof(EventHandler) });

        [TestMethod("Transform replaces method-call expression with add-assign expression for field events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.AddFieldEvent(handler);
            Expression input = Expression.Call(instance, FixtureAddFieldEvent, handler);

            // instance.FieldEvent = Deletate.Combine(instance.FieldEvent, handler)
            Expression field = Expression.Field(instance, FixtureFieldEvent);
            Expression call = Expression.Call(DelegateCombine, field, handler);
            Expression expected = Expression.Assign(field, call);

            Expression actual = new EventAddAttribute("FieldEvent").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform replaces method-call expression with add-assign expression for property events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForPropertyEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.AddPropertyEvent(handler);
            Expression input = Expression.Call(instance, FixtureAddPropertyEvent, handler);

            // instance.PropertyEvent = Deletate.Combine(instance.PropertyEvent, handler)
            Expression property = Expression.Property(instance, FixturePropertyEvent);
            Expression call = Expression.Call(DelegateCombine, property, handler);
            Expression expected = Expression.Assign(property, call);

            Expression actual = new EventAddAttribute("PropertyEvent").Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no field or property with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.AddNonExistentEvent(handler);
            Expression input = Expression.Call(instance, FixtureAddNonExistentEvent, handler);

            EventAddAttribute attribute = new EventAddAttribute("NonExistentEvent");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }

        [TestMethod("Transform throws ArgumentException on non-event")]
        public void Transform_ThrowsArgumentException_OnNonEvent()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(EventHandler), "handler");

            // instance.AddFieldDelegate(handler);
            Expression input = Expression.Call(instance, FixtureAddFieldDelegate, handler);

            EventAddAttribute attribute = new EventAddAttribute("FieldDelegate");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
