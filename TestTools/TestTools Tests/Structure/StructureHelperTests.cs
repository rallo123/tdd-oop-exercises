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
            ReflectionHelper.GetFieldInfo(typeof(Class), new FieldOptions("PrivateIntField", typeof(int)));
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonExistentField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeField",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), new FieldOptions("FakeField", typeof(int)))
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnWrongTypeField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PublicIntField is not of type string",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), new FieldOptions("PublicIntField", typeof(string)))
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPrivateField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PublicIntField is not private",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), new FieldOptions("PublicIntField", typeof(int)) { IsPrivate = true })
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonProtectedField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateIntField is not protected",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), new FieldOptions("PrivateIntField", typeof(int)) { IsFamily = true })
            );
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPublicField()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateIntField is not public",
                () => ReflectionHelper.GetFieldInfo(typeof(Class), new FieldOptions("PrivateIntField", typeof(int)) { IsPublic = true })
            );
        }

        /* == Property tests == */
        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PrivateIntProperty", typeof(int)));
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateReadonlyProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PrivateReadonlyIntProperty", typeof(int)) { GetMethod = new MethodOptions() { IsPrivate = true } });
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateWriteonlyProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PrivateWriteonlyIntProperty", typeof(int)) { SetMethod = new MethodOptions() { IsPrivate = true } });
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonExistentProperty()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeProperty",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("FakeProperty", typeof(int)))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnWrongTypeProperty()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PublicIntProperty is not of type string",
                 () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PublicIntProperty", typeof(string)))
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivatePropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PublicIntProperty's get accessor is not private",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PublicIntProperty", typeof(int)) { GetMethod = new MethodOptions() { IsPrivate = true } })
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateIntProperty's get accessor is not protected",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PrivateIntProperty", typeof(int)) { GetMethod = new MethodOptions() { IsFamily = true } })
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertyGetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateIntProperty's get accessor is not public",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PrivateIntProperty", typeof(int)) { GetMethod = new MethodOptions() { IsPublic = true } })
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivateSetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PublicIntProperty's set accessor is not private",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PublicIntProperty", typeof(int)) { SetMethod = new MethodOptions() { IsPrivate = true } })
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertySetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateIntProperty's set accessor is not protected",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PrivateIntProperty", typeof(int)) { SetMethod = new MethodOptions() { IsFamily = true } })
            );
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertySetAccessor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateIntProperty's set accessor is not public",
                () => ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("PrivateIntProperty", typeof(int)) { SetMethod = new MethodOptions() { IsPublic = true } })
            );
        }

        /* == Method tests == */
        [TestMethod, TestCategory("Method")]
        public void DetectsPrivateMethodWithoutParameters()
        {
            ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("PrivateMethodWithoutParameters", typeof(void), new Type[0]));
        }

        [TestMethod, TestCategory("Method")]
        public void DetectsPrivateMethodWithParameters()
        {
            ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("PrivateMethodWithParameters", typeof(int), new Type[] { typeof(int) }));
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonExistentMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain member FakeMethod",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("FakeMethod", typeof(void), new Type[0]))
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodReturnType()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateMethodWithParameters's return type is not string",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("PrivateMethodWithParameters", typeof(string), new Type[] { typeof(int) }))
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodParameters()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PublicMethodWithParameters's return type is not string",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("PublicMethodWithParameters", typeof(string), new Type[0]))
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPrivateMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PublicMethodWithoutParameters() is not private",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("PublicMethodWithoutParameters", typeof(void), new Type[0]) { IsPrivate = true })
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonProtectedMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateMethodWithoutParameters() is not protected",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("PrivateMethodWithoutParameters", typeof(void), new Type[0]) { IsFamily = true })
            );
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPublicMethod()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class.PrivateMethodWithoutParameters() is not public",
                () => ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("PrivateMethodWithoutParameters", typeof(void), new Type[0]) { IsPublic = true })
            );
        }

        /* == Constructor tests == */
        [TestMethod, TestCategory("Constructor")]
        public void DetectsPrivateConstructor()
        {
            ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorOptions());
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonExistentConstructor()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class does not contain constructor Class(string par1)",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorOptions(new Type[] { typeof(string) }))
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPrivate()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class(int par1) is not private",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorOptions(new Type[] { typeof(int) }) { IsPrivate = true })
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonProtected()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class() is not protected",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorOptions() { IsFamily = true })
            );
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPublic()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Class constructor Class() is not public",
                () => ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorOptions() { IsPublic = true })
            );
        }
    }
}
