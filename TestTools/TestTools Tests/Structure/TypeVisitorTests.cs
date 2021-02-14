using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TestTools.Structure;
using System.Linq.Expressions;
using System.Reflection;

namespace TestTools_Tests.Unit
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
            typeTranslator.Translate("", typeof(ClassA)).Returns(typeof(ClassB));

            memberTranslator = Substitute.For<IMemberTranslator>();
            memberTranslator.Translate(typeof(ClassB), ClassAField).Returns(ClassBField);
            memberTranslator.Translate(typeof(ClassB), ClassAConstructor).Returns(ClassBConstructor);
        }

        [TestMethod("Visit applies TypeTranslator on (parameter expression) types")]
        public void Visit_AppliesTypeTranslatorOnTypes()
        {
            TypeVisitor visitor = new TypeVisitor()
            {
                TypeTranslator = typeTranslator
            };
            Expression input = Expression.Parameter(typeof(ClassA));
            Expression expected = Expression.Parameter(typeof(ClassB));

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Visit applies TypeVerifier on types, and therefore throws")]
        public void Visit_AppliesTypeVerifierOnTypes_AndThereforeThrows()
        {
            ITypeVerifier verifier = Substitute.For<ITypeVerifier>();
            verifier.When(x => x.Verify(typeof(ClassA), typeof(ClassB))).Throw<Exception>();
            TypeVisitor visitor = new TypeVisitor()
            {
                TypeTranslator = typeTranslator,
                TypeVerifiers = new[] { verifier }
            };
            Expression input = Expression.Parameter(typeof(ClassA));

            Assert.ThrowsException<Exception>(() => visitor.Visit(input));
        }

        [TestMethod("Visit applies MemberTranslator on members")]
        public void Visit_AppliesTypeTranslatorOnMembers()
        {
            TypeVisitor visitor = new TypeVisitor()
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator
            };
            Expression instanceA = Expression.Parameter(typeof(ClassA));
            Expression instanceB = Expression.Parameter(typeof(ClassB));
            Expression input = Expression.Field(instanceA, ClassAField);
            Expression expected = Expression.Field(instanceB, ClassBField);

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Visit applies IMemberVerfier on fields, and therefore throws")]
        public void Visit_AppliesIMemberVerfierConstructorInfoOnConstructor_AndThereforeThrows()
        {
            IMemberVerifier verifier = Substitute.For<IMemberVerifier>();
            verifier.When(x => x.Verify(ClassAConstructor, ClassBConstructor)).Throw<Exception>();
            TypeVisitor visitor = new TypeVisitor()
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator,
                MemberVerifiers = new[] { verifier }
            };
            Expression instance = Expression.Parameter(typeof(ClassA));
            Expression input = Expression.Field(instance, ClassAField);

            Assert.ThrowsException<Exception>(() => visitor.Visit(input));
        }
    }
}
