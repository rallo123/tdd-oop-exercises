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
            ReflectionHelper.GetFieldInfo(typeof(Class), "PrivateIntField", typeof(int), null);
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonExistentField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeField",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), "FakeField", typeof(int), null)
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnWrongTypeField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PublicIntField is not of type string",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), "PublicIntField", typeof(string), null)
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPrivateField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PublicIntField is not private",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), "PublicIntField", typeof(int), new FieldOptions() { AccessLevel = AccessLevel.Private })
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonProtectedField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PrivateIntField is not protected",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), "PrivateIntField", typeof(int), new FieldOptions() { AccessLevel = AccessLevel.Protected })
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPublicField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class field PrivateIntField is not public",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), "PrivateIntField", typeof(int), new FieldOptions() { AccessLevel = AccessLevel.Public })
            );
        }

        /* == Property tests == */
        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), get: null, set: null);
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateReadonlyProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), "PrivateReadonlyIntProperty", typeof(int), get: new AccessorOptions() { AccessLevel = AccessLevel.Private }, set: null);
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateWriteonlyProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), "PrivateWriteonlyIntProperty", typeof(int), get: null, set: new AccessorOptions() { AccessLevel = AccessLevel.Private });
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonExistentProperty()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeProperty",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), "FakeProperty", typeof(int), get: null, set: null)
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnWrongTypeProperty()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PublicIntProperty is not of type string",
                 () => ReflectionHelper.GetPropertyInfo(typeof(Class), "PublicIntProperty", typeof(string), get: null, set: null)
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivatePropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PublicIntProperty get accessor is not private",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), "PublicIntProperty", typeof(int), get: new AccessorOptions() { AccessLevel = AccessLevel.Private }, set: null)
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty get accessor is not protected",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), get: new AccessorOptions() { AccessLevel = AccessLevel.Protected }, set: null)
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty get accessor is not public",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: null)
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivateSetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PublicIntProperty set accessor is not private",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), "PublicIntProperty", typeof(int), get: null, set: new AccessorOptions() { AccessLevel = AccessLevel.Private })
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertySetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty set accessor is not protected",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), get: null, set: new AccessorOptions() { AccessLevel = AccessLevel.Protected })
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertySetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class property PrivateIntProperty set accessor is not public",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), "PrivateIntProperty", typeof(int), get: null, set: new AccessorOptions() { AccessLevel = AccessLevel.Public })
            );
        }

        /* == Method tests == */
        [TestMethod, TestCategory("Method")]
        public void DetectsPrivateMethodWithoutParameters()
        {
            ReflectionHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithoutParameters", typeof(void), new Type[] { }, null);
        }

        [TestMethod, TestCategory("Method")]
        public void DetectsPrivateMethodWithParameters()
        {
            ReflectionHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithParameters", typeof(int), new Type[] { typeof(int) }, null);
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonExistentMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeMethod",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), "FakeMethod", typeof(void), new Type[] { }, null)
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodReturnType()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method PrivateMethodWithParameters return type is not string",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithParameters", typeof(string), new Type[] { typeof(int) }, null)
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodParameters()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method PublicMethodWithParameters return type is not string",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), "PublicMethodWithParameters", typeof(string), new Type[] { }, null)
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPrivateMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method void PublicMethodWithoutParameters() is not private",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), "PublicMethodWithoutParameters", typeof(void), new MethodOptions() { AccessLevel = AccessLevel.Private })
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonProtectedMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method void PrivateMethodWithoutParameters() is not protected",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithoutParameters", typeof(void), new MethodOptions() { AccessLevel = AccessLevel.Protected })
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPublicMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class method void PrivateMethodWithoutParameters() is not public",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), "PrivateMethodWithoutParameters", typeof(void), new MethodOptions() { AccessLevel = AccessLevel.Public })
            );
        }

        /* == Constructor tests == */
        [TestMethod, TestCategory("Constructor")]
        public void DetectsPrivateConstructor()
        {
            ReflectionHelper.GetConstructorInfo(typeof(Class), null);
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonExistentConstructor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain constructor Class(string par1)",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new Type[] { typeof(string) }, null)
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPrivate()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class(int par1) is not private",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new Type[] { typeof(int) }, new ConstructorOptions() { AccessLevel = AccessLevel.Private })
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonProtected()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class() is not protected",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorOptions() { AccessLevel = AccessLevel.Protected })
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPublic()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class() is not public",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorOptions() { AccessLevel = AccessLevel.Public })
            );
        }
    }
}
