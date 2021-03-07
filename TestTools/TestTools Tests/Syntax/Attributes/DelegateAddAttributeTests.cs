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
    public class DelegateAddAttributeTests
    {
        class Fixture
        {
            public Action FieldDelegate;

            public Action PropertyDelegate { get; set; }

            public void AddFieldDelegate(Action handler) => FieldDelegate += handler;

            public void AddPropertyDelegate(Action handler) => PropertyDelegate += handler;

            public void AddNonExistentDelegate(Action handler) => throw new NotImplementedException();
        }

        readonly MethodInfo DelegateCombine = typeof(Delegate).GetMethod("Combine", new Type[] { typeof(Delegate), typeof(Delegate) });

        readonly FieldInfo FixtureFieldDelegate = typeof(Fixture).GetField("FieldDelegate");
        readonly PropertyInfo FixturePropertyDelegate = typeof(Fixture).GetProperty("PropertyDelegate");
        readonly MethodInfo FixtureAddDelegate = typeof(Fixture).GetMethod("AddFieldDelegate", new Type[] { typeof(Action) });
        readonly MethodInfo FixtureAddPropertyDelegate = typeof(Fixture).GetMethod("AddPropertyDelegate", new Type[] { typeof(Action) });
        readonly MethodInfo FixtureAddNonExistentDelegate = typeof(Fixture).GetMethod("AddNonExistentDelegate", new Type[] { typeof(Action) });

        [TestMethod("Transform replaces method-call expression with add-assign expression for field events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForFieldEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(Action), "handler");

            // instance.AddFieldDelegate(handler);
            Expression input = Expression.Call(instance, FixtureAddDelegate, handler);

            // instance.FieldDelegate = (Action)Deletate.Combine(instance.FieldDelegate, handler)
            Expression field = Expression.Field(instance, FixtureFieldDelegate);
            Expression call = Expression.Call(DelegateCombine, field, handler);
            Expression castedCall = Expression.Convert(call, typeof(Action));
            Expression expected = Expression.Assign(field, castedCall);

            Expression actual = new DelegateAddAttribute("FieldDelegate").Transform(input);

            AssertAreEqualExpressions(expected, actual);
        }

        [TestMethod("Transform replaces method-call expression with add-assign expression for property events")]
        public void Transform_ReplacesMethodCallExpressionWithAddAssignExpression_ForPropertyEvents()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(Action), "handler");

            // instance.AddPropertyDelegate(handler);
            Expression input = Expression.Call(instance, FixtureAddPropertyDelegate, handler);

            // instance.PropertyDelegate = (Action)Delegate.Combine(instance.PropertyDelegate, handler)
            Expression property = Expression.Property(instance, FixturePropertyDelegate);
            Expression call = Expression.Call(DelegateCombine, property, handler);
            Expression castedCall = Expression.Convert(call, typeof(Action));
            Expression expected = Expression.Assign(property, castedCall);

            Expression actual = new DelegateAddAttribute("PropertyDelegate").Transform(input);

            AssertAreEqualExpressions(expected, actual);
        }

        [TestMethod("Transform throws ArgumentException if there is no field or property with name")]
        public void Transform_ThrowsArgumentException_IfThereIsNoFieldOrPropertyWithName()
        {
            Expression instance = Expression.Parameter(typeof(Fixture), "instance");
            Expression handler = Expression.Parameter(typeof(Action), "handler");

            // instance.AddNonExistentDelegate(handler);
            Expression input = Expression.Call(instance, FixtureAddNonExistentDelegate, handler);

            DelegateAddAttribute attribute = new DelegateAddAttribute("NonExistentDelegate");
            Assert.ThrowsException<ArgumentException>(() => attribute.Transform(input));
        }
    }
}
