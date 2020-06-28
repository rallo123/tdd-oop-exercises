using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Structure;
using Namespace;
using static TestTools_Tests.TestHelper;
using System.Reflection;

namespace TestTools_Tests.Structure
{
    [TestClass]
    public class ClassTests
    {
        private static ClassDefinition GetClassDefinition() => new ClassDefinition(typeof(Class));

        [TestClass]
        public class FieldTests
        {
            [TestMethod]
            public void DetectsPrivateField()
            {
                GetClassDefinition().Field("PrivateIntField", typeof(int));
            }
            
            [TestMethod]
            public void ThrowsOnNonExistentField()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class does not contain instance member FakeField",
                    () => GetClassDefinition().Field("FakeField", typeof(int))
                );
            }

            [TestMethod]
            public void ThrowsOnWrongType()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Instance field PublicIntField is not of type string",
                    () => GetClassDefinition().Field("PublicIntField", typeof(string))
                );
            }

            [TestMethod]
            public void ThrowsOnNonPrivate()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Instance field PublicIntField is not private",
                    () => GetClassDefinition().Field("PublicIntField", typeof(int), AccessLevel.Private)
                );
            }

            [TestMethod]
            public void ThrowsOnNonProtected()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Instance field PrivateIntField is not protected",
                    () => GetClassDefinition().Field("PrivateIntField", typeof(int), AccessLevel.Protected)
                );
            }

            [TestMethod]
            public void ThrowsOnNonPublic()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Instance field PrivateIntField is not public",
                    () => GetClassDefinition().Field("PrivateIntField", typeof(int), AccessLevel.Public)
                );
            }
        }
        
        [TestClass]
        public class StaticFieldTests { }

        [TestClass]
        public class PropertyTests {
            [TestMethod]
            public void DetectsPrivateProperty()
            {
                GetClassDefinition().Property("PrivateIntProperty", typeof(int));
            }

            [TestMethod]
            public void DetectsPrivateReadonlyProperty()
            {
                GetClassDefinition().Property("PrivateReadonlyIntProperty", typeof(int), getMethod: new GetMethod(AccessLevel.Private));
            }
            
            [TestMethod]
            public void DetectsPrivateWriteonlyProperty()
            {
                GetClassDefinition().Property("PrivateWriteonlyIntProperty", typeof(int), setMethod: new SetMethod(AccessLevel.Private));
            }
            
            [TestMethod]
            public void ThrowsOnNonExistentProperty()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class does not contain instance member FakeProperty",
                    () => GetClassDefinition().Property("FakeProperty", typeof(int))
                );
            }

            [TestMethod]
            public void ThrowsOnWrongType()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Instance property PublicIntProperty is not of type string",
                    () => GetClassDefinition().Property("PublicIntProperty", typeof(string))
                );
            }

            [TestMethod]
            public void ThrowsOnNonPrivateGetMethod()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance property PublicIntProperty get method is not private",
                    () => GetClassDefinition().Property("PublicIntProperty", typeof(int), getMethod: new GetMethod(AccessLevel.Private))
                );
            }

            [TestMethod]
            public void ThrowsOnNonProtectedGetMethod()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance property PrivateIntProperty get method is not protected",
                    () => GetClassDefinition().Property("PrivateIntProperty", typeof(int), getMethod: new GetMethod(AccessLevel.Protected))
                );
            }

            [TestMethod]
            public void ThrowsOnNonPublicGetMethod()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance property PrivateIntProperty get method is not public",
                    () => GetClassDefinition().Property("PrivateIntProperty", typeof(int), getMethod: new GetMethod(AccessLevel.Public))
                );
            }

            [TestMethod]
            public void ThrowsOnNonPrivateSetMethod()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance property PublicIntProperty set method is not private",
                    () => GetClassDefinition().Property("PublicIntProperty", typeof(int), setMethod: new SetMethod(AccessLevel.Private))
                );
            }

            [TestMethod]
            public void ThrowsOnNonProtectedSetMethod()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance property PrivateIntProperty set method is not protected",
                    () => GetClassDefinition().Property("PrivateIntProperty", typeof(int), setMethod: new SetMethod(AccessLevel.Protected))
                );
            }

            [TestMethod]
            public void ThrowsOnNonPublicSetMethod()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance property PrivateIntProperty set method is not public",
                    () => GetClassDefinition().Property("PrivateIntProperty", typeof(int), setMethod: new SetMethod(AccessLevel.Public))
                );
            }
        }

        [TestClass]
        public class StaticPropertyTests { }

        [TestClass]
        public class MethodTests {
            [TestMethod]
            public void DetectsPrivateMethodWithoutParameters()
            {
                GetClassDefinition().Method("PrivateMethodWithoutParameters", typeof(void));
            }

            [TestMethod]
            public void DetectsPrivateMethodWithParameters()
            {
                GetClassDefinition().Method("PrivateMethodWithParameters", typeof(int), new Type[] { typeof(int) });
            }

            [TestMethod]
            public void ThrowsOnNonExistentMethod()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class does not contain instance member FakeMethod",
                    () => GetClassDefinition().Method("FakeMethod", typeof(void))
                );
            }

            [TestMethod]
            public void ThrowsOnWrongReturnType()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Instance method PrivateMethodWithParameters return type is not string",
                    () => GetClassDefinition().Method("PrivateMethodWithParameters", typeof(string), new Type[] { typeof(int) })
                );
            }

            [TestMethod]
            public void ThrowsOnWrongParameters()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class does not contain instance method string PublicMethodWithParameters()",
                    () => GetClassDefinition().Method("PublicMethodWithParameters", typeof(string))
                );
            }

            [TestMethod]
            public void ThrowsOnNonPrivate()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance method void PublicMethodWithoutParameters() is not private",
                    () => GetClassDefinition().Method("PublicMethodWithoutParameters", typeof(void), accessLevel: AccessLevel.Private)
                );
            }

            [TestMethod]
            public void ThrowsOnNonProtected()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance method void PrivateMethodWithoutParameters() is not protected",
                    () => GetClassDefinition().Method("PrivateMethodWithoutParameters", typeof(void), accessLevel: AccessLevel.Protected)
                );
            }

            [TestMethod]
            public void ThrowsOnNonPublic()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class instance method void PrivateMethodWithoutParameters() is not public",
                    () => GetClassDefinition().Method("PrivateMethodWithoutParameters", typeof(void), accessLevel: AccessLevel.Public)
                );
            }
        }

        [TestClass]
        public class StaticMethodTests { }

        [TestClass]
        public class EventTests { }

        [TestClass]
        public class StaticEventTests { }

        [TestClass]
        public class ConstructorTests { 
            [TestMethod]
            public void DetectsPrivateConstructor()
            {
                GetClassDefinition().Constructor();
            }

            [TestMethod]
            public void ThrowsOnNonExistentConstructor()
            {
                AssertThrowsExactException<ArgumentException>(
                    "Class does not contain constructor Class(string par1)",
                    () => GetClassDefinition().Constructor(new Type[] {typeof(string)})
                );
            }

            [TestMethod]
            public void ThrowsOnNonPrivate()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class constructor Class(int par1) is not private",
                    () => GetClassDefinition().Constructor(new Type[] { typeof(int) }, AccessLevel.Private)
                );
            }

            [TestMethod]
            public void ThrowsOnNonProtected()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class constructor Class() is not protected",
                    () => GetClassDefinition().Constructor(accessLevel: AccessLevel.Protected)
                );
            }

            [TestMethod]
            public void ThrowsOnNonPublic()
            {
                AssertThrowsExactException<AssertFailedException>(
                    "Class constructor Class() is not public",
                    () => GetClassDefinition().Constructor(accessLevel: AccessLevel.Public)
                );
            }
        }
    }
}
