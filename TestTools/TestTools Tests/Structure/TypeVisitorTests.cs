using System;
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

        [TestMethod("Visit applies TypeTranslator on (parameter expression) types")]
        public void Visit_AppliesTypeTranslatorOnTypes()
        {
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator
            };
            TypeVisitor visitor = new TypeVisitor(service);
            Expression input = Expression.Parameter(typeof(ClassA));
            Expression expected = Expression.Parameter(typeof(ClassB));

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Visit applies TypeVerifier on types, and therefore throws")]
        public void Visit_AppliesTypeVerifierOnTypes_AndThereforeThrows()
        {
            ITypeVerifier verifier = Substitute.For<ITypeVerifier>();
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator,
                DefaultTypeVerifiers = new[] { verifier }
            };
            TypeVisitor visitor = new TypeVisitor(service);
            Expression input = Expression.Parameter(typeof(ClassA));

            visitor.Visit(input);

            verifier.Received().Verify(typeof(ClassA), typeof(ClassB));
        }

        [TestMethod("Visit applies MemberTranslator on members")]
        public void Visit_AppliesTypeTranslatorOnMembers()
        {
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator
            };
            TypeVisitor visitor = new TypeVisitor(service);
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
            StructureService service = new StructureService("TestTools_Tests.Structure", "TestTools_Tests.Structure")
            {
                TypeTranslator = typeTranslator,
                MemberTranslator = memberTranslator,
                DefaultMemberVerifiers = new[] { verifier }
            };
            TypeVisitor visitor = new TypeVisitor(service);
            Expression instance = Expression.Parameter(typeof(ClassA));
            Expression input = Expression.Field(instance, ClassAField);

            visitor.Visit(input);

            verifier.Received().Verify(ClassAConstructor, ClassBConstructor);
        }
    }
}
