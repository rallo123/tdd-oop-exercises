﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TestTools.Structure;
using System.Linq.Expressions;
using System.Reflection;

namespace TestTools_Tests.Structure
{
    [TestClass]
    public class TypeVisitorTests
    {
        class ClassA
        {
            public int Field;
            public int Property { get; set; }
            public event EventHandler Event;
            public void VoidMethod()
            {
            }
        }

        class ClassB
        {
            public int Field;
            public int Property { get; set; }
            public event EventHandler Event;
            public void VoidMethod()
            {
            }
        }

        ITypeTranslator typeTranslator;
        IMemberTranslator memberTranslator;

        ConstructorInfo ClassAConstructor = typeof(ClassA).GetConstructor(new Type[0]);
        FieldInfo ClassAField = typeof(ClassA).GetField("Field");
        EventInfo ClassAEvent = typeof(ClassA).GetEvent("Event");
        MethodInfo ClassAVoidMethod = typeof(ClassA).GetMethod("VoidMethod", new Type[0]);
        PropertyInfo ClassAProperty = typeof(ClassA).GetProperty("Property");

        ConstructorInfo ClassBConstructor = typeof(ClassB).GetConstructor(new Type[0]);
        FieldInfo ClassBField = typeof(ClassB).GetField("Field");
        EventInfo ClassBEvent = typeof(ClassB).GetEvent("Event");
        MethodInfo ClassBVoidMethod = typeof(ClassB).GetMethod("VoidMethod", new Type[0]);
        PropertyInfo ClassBProperty = typeof(ClassB).GetProperty("Property");

        [TestInitialize]
        public void TestInitialize()
        {
            typeTranslator = Substitute.For<ITypeTranslator>();
            typeTranslator.Translate(typeof(ClassA)).Returns(typeof(ClassB));

            memberTranslator = Substitute.For<IMemberTranslator>();
            memberTranslator.Translate(ClassAField).Returns(ClassBField);
            memberTranslator.Translate(ClassAConstructor).Returns(ClassBConstructor);
        }

        [TestMethod("Visit correctly transforms ParameterExpression")]
        public void VisitCorrectlyTransformsParameterExpression()
        {
            ITypeTranslator translator = Substitute.For<ITypeTranslator>();
            translator.Translate(typeof(ClassA)).Returns(typeof(ClassB));
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = translator
            };
            TypeVisitor visitor = new TypeVisitor(service);

            Expression input = Expression.Parameter(typeof(ClassA));
            Expression expected = Expression.Parameter(typeof(ClassB));

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Visit correctly transforms NewExpression")]
        public void VisitCorrectlyTransformsNewExpression()
        {
            ITypeTranslator typeTranslator = Substitute.For<ITypeTranslator>();
            typeTranslator.Translate(typeof(ClassA)).Returns(typeof(ClassB));
            IMemberTranslator memberTranslator = Substitute.For<IMemberTranslator>();
            memberTranslator.Translate(ClassAConstructor).Returns(ClassBConstructor);
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator
            };
            TypeVisitor visitor = new TypeVisitor(service);

            Expression input = Expression.New(ClassAConstructor);
            Expression expected = Expression.New(ClassBConstructor);

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Visit correctly transforms MethodCallExpression")]
        public void VisitCorrectlyTransformsMethodCallExpression()
        {
            ITypeTranslator typeTranslator = Substitute.For<ITypeTranslator>();
            typeTranslator.Translate(typeof(ClassA)).Returns(typeof(ClassB));
            IMemberTranslator memberTranslator = Substitute.For<IMemberTranslator>();
            memberTranslator.Translate(ClassAVoidMethod).Returns(ClassBVoidMethod);
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator
            };
            TypeVisitor visitor = new TypeVisitor(service);

            Expression input = Expression.Call(Expression.Parameter(typeof(ClassA)), ClassAVoidMethod);
            Expression expected = Expression.Call(Expression.Parameter(typeof(ClassB)), ClassBVoidMethod);

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Visit correctly transforms MemberExpression for field")]
        public void VisitCorrectlyTransformMemberExpressionForField()
        {
            ITypeTranslator typeTranslator = Substitute.For<ITypeTranslator>();
            typeTranslator.Translate(typeof(ClassA)).Returns(typeof(ClassB));
            IMemberTranslator memberTranslator = Substitute.For<IMemberTranslator>();
            memberTranslator.Translate(ClassAField).Returns(ClassBField);
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator
            };
            TypeVisitor visitor = new TypeVisitor(service);

            Expression input = Expression.Field(Expression.Parameter(typeof(ClassA)), ClassAField);
            Expression expected = Expression.Field(Expression.Parameter(typeof(ClassB)), ClassBField);

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Visit correctly transforms MemberExpression for property")]
        public void VisitCorrectlyTransformMemberExpressionForProperty()
        {
            ITypeTranslator typeTranslator = Substitute.For<ITypeTranslator>();
            typeTranslator.Translate(typeof(ClassA)).Returns(typeof(ClassB));
            IMemberTranslator memberTranslator = Substitute.For<IMemberTranslator>();
            memberTranslator.Translate(ClassAProperty).Returns(ClassBProperty);
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator
            };
            TypeVisitor visitor = new TypeVisitor(service);

            Expression input = Expression.Property(Expression.Parameter(typeof(ClassA)), ClassAProperty);
            Expression expected = Expression.Property(Expression.Parameter(typeof(ClassB)), ClassBProperty);

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }
        
        //TODO write tests to verify verifications
    }
}
