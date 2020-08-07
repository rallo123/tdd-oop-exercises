using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;
using TestTools.Structure;
using static TestTools_Tests.TestHelper;

namespace TestTools_Tests.Structure
{
    [TestClass]
    public class StructureHelperTests
    {
        /* == Field tests == */
        [TestMethod, TestCategory("Field")]
        public void DetectsPrivateField()
        {
            StructureHelper.GetFieldInfo(typeof(Class), "PrivateIntField", typeof(int));
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonExistentField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeField",
                () => StructureHelper.GetFieldInfo(typeof(Class), "FakeField", typeof(int))
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnWrongTypeField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PublicIntField is not of type string",
                () => StructureHelper.GetFieldInfo(typeof(Class), "PublicIntField", typeof(string))
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPrivateField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PublicIntField is not private",
                () => StructureHelper.GetFieldInfo(typeof(Class), "PublicIntField", typeof(int), AccessLevel.Private)
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonProtectedField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PrivateIntField is not protected",
                () => StructureHelper.GetFieldInfo(typeof(Class), "PrivateIntField", typeof(int), AccessLevel.Protected)
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPublicField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PrivateIntField is not public",
                () => StructureHelper.GetFieldInfo(typeof(Class), "PrivateIntField", typeof(int), AccessLevel.Public)
            );
        }

        /* == Property tests == */
        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateProperty()
        {
            StructureHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int));
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateReadonlyProperty()
        {
            StructureHelper.GetPropertyInfo(typeof(Class), "PrivateReadonlyIntProperty", typeof(int), get: new PropertyAccessor(AccessLevel.Private));
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateWriteonlyProperty()
        {
            StructureHelper.GetPropertyInfo(typeof(Class), "PrivateWriteonlyIntProperty", typeof(int), set: new PropertyAccessor(AccessLevel.Private));
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonExistentProperty()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeProperty",
                () => StructureHelper.GetPropertyInfo(typeof(Class), "FakeProperty", typeof(int))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnWrongTypeProperty()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PublicIntProperty is not of type string",
                 () => StructureHelper.GetPropertyInfo(typeof(Class), "PublicIntProperty", typeof(string))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivatePropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PublicIntProperty get accessor is not private",
                () => StructureHelper.GetPropertyInfo(typeof(Class), "PublicIntProperty", typeof(int), get: new PropertyAccessor(AccessLevel.Private))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty get accessor is not protected",
                () => StructureHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), get: new PropertyAccessor(AccessLevel.Protected))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty get accessor is not public",
                () => StructureHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), get: new PropertyAccessor(AccessLevel.Public))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivateSetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PublicIntProperty set accessor is not private",
                () => StructureHelper.GetPropertyInfo(typeof(Class), "PublicIntProperty", typeof(int), set: new PropertyAccessor(AccessLevel.Private))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertySetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty set accessor is not protected",
                () => StructureHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), set: new PropertyAccessor(AccessLevel.Protected))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertySetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty set accessor is not public",
                () => StructureHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), set: new PropertyAccessor(AccessLevel.Public))
            );
        }

        /* == Method tests == */
        [TestMethod, TestCategory("Method")]
        public void DetectsPrivateMethodWithoutParameters()
        {
            StructureHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithoutParameters", typeof(void));
        }

        [TestMethod, TestCategory("Method")]
        public void DetectsPrivateMethodWithParameters()
        {
            StructureHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithParameters", typeof(int), new Type[] { typeof(int) });
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonExistentMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeMethod",
                () => StructureHelper.GetMethodInfo(typeof(Class), "FakeMethod", typeof(void))
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodReturnType()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method PrivateMethodWithParameters return type is not string",
                () => StructureHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithParameters", typeof(string), new Type[] { typeof(int) })
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodParameters()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method PublicMethodWithParameters return type is not string",
                () => StructureHelper.GetMethodInfo(typeof(Class), "PublicMethodWithParameters", typeof(string))
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPrivateMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method void PublicMethodWithoutParameters() is not private",
                () => StructureHelper.GetMethodInfo(typeof(Class), "PublicMethodWithoutParameters", typeof(void), accessLevel: AccessLevel.Private)
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonProtectedMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method void PrivateMethodWithoutParameters() is not protected",
                () => StructureHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithoutParameters", typeof(void), accessLevel: AccessLevel.Protected)
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPublicMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method void PrivateMethodWithoutParameters() is not public",
                () => StructureHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithoutParameters", typeof(void), accessLevel: AccessLevel.Public)
            );
        }

        /* == Constructor tests == */
        [TestMethod, TestCategory("Constructor")]
        public void DetectsPrivateConstructor()
        {
            StructureHelper.GetConstructorInfo(typeof(Class));
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonExistentConstructor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain constructor Class(string par1)",
                () => StructureHelper.GetConstructorInfo(typeof(Class), new Type[] { typeof(string) })
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPrivate()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class(int par1) is not private",
                () => StructureHelper.GetConstructorInfo(typeof(Class), new Type[] { typeof(int) }, AccessLevel.Private)
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonProtected()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class() is not protected",
                () => StructureHelper.GetConstructorInfo(typeof(Class), accessLevel: AccessLevel.Protected)
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPublic()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class() is not public",
                () => StructureHelper.GetConstructorInfo(typeof(Class), accessLevel: AccessLevel.Public)
            );
        }
    }
}
