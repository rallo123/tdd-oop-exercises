using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;
using TestTools.Structure;
using TestTools.Structure.Exceptions;

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
            try {
                ReflectionHelper.GetFieldInfo(typeof(Class), new FieldOptions("FakeField", typeof(int)));
                Assert.Fail("No exception was thrown");
            }
            catch (TestTools.Structure.Exceptions.MissingMemberException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreEqual("FakeField", ex.MemberName);
            }
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnWrongTypeField()
        {
            FieldOptions options = new FieldOptions("PublicIntField", typeof(string));
            try
            {
                ReflectionHelper.GetFieldInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidFieldTypeException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
            }
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPrivateField()
        {
            FieldOptions options = new FieldOptions("PublicIntField", typeof(int)) { IsPrivate = true };
            try
            {
                ReflectionHelper.GetFieldInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidFieldModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Private, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonProtectedField()
        {
            FieldOptions options = new FieldOptions("PublicIntField", typeof(int)) { IsFamily = true };
            try
            {
                ReflectionHelper.GetFieldInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidFieldModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Protected, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonPublicField()
        {
            FieldOptions options = new FieldOptions("PrivateIntField", typeof(int)) { IsPublic = true };
            try
            {
                ReflectionHelper.GetFieldInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidFieldModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Public, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
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
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyOptions("FakeProperty", typeof(int)));
                Assert.Fail("No exception was thrown");
            }
            catch (TestTools.Structure.Exceptions.MissingMemberException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreEqual("FakeProperty", ex.MemberName);
            }
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnWrongTypeProperty()
        {
            PropertyOptions options = new PropertyOptions("PublicIntProperty", typeof(string));
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidPropertyTypeException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
            }
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivatePropertyGetAccessor()
        {
            PropertyOptions options = new PropertyOptions("PublicIntProperty", typeof(int)) { GetMethod = new MethodOptions() { IsPrivate = true } };
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidPropertyGetModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Private, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertyGetAccessor()
        {

            PropertyOptions options = new PropertyOptions("PrivateIntProperty", typeof(int)) { GetMethod = new MethodOptions() { IsFamily = true } };
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidPropertyGetModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Protected, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertyGetAccessor()
        {
            PropertyOptions options = new PropertyOptions("PrivateIntProperty", typeof(int)) { GetMethod = new MethodOptions() { IsPublic = true } };
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidPropertyGetModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Public, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPrivateSetAccessor()
        {
            PropertyOptions options = new PropertyOptions("PublicIntProperty", typeof(int)) { SetMethod = new MethodOptions() { IsPrivate = true } };
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidPropertySetModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Private, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonProtectedPropertySetAccessor()
        {
            PropertyOptions options = new PropertyOptions("PrivateIntProperty", typeof(int)) { SetMethod = new MethodOptions() { IsFamily = true } };
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidPropertySetModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Protected, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonPublicPropertySetAccessor()
        {
            PropertyOptions options = new PropertyOptions("PrivateIntProperty", typeof(int)) { SetMethod = new MethodOptions() { IsPublic = true } };
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidPropertySetModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Public, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
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
            try
            {
                ReflectionHelper.GetMethodInfo(typeof(Class), new MethodOptions("FakeMethod", typeof(void), new Type[0]));
                Assert.Fail("No exception was thrown");
            } 
            catch (TestTools.Structure.Exceptions.MissingMemberException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreEqual("FakeMethod", ex.MemberName);
            }
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodReturnType()
        {
            MethodOptions options = new MethodOptions("PrivateMethodWithParameters", typeof(string), new Type[] { typeof(int) });
            try
            {
                ReflectionHelper.GetMethodInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidMethodReturnTypeException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
            }
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnWrongMethodParameters()
        {
            MethodOptions options = new MethodOptions("PrivateMethodWithParameters", typeof(int), new Type[] { typeof(string) });
            try
            {
                ReflectionHelper.GetMethodInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (TestTools.Structure.Exceptions.MissingMethodException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
            }
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPrivateMethod()
        {
            MethodOptions options = new MethodOptions("PublicMethodWithoutParameters", typeof(void), new Type[0]) { IsPrivate = true };
            try
            {
                ReflectionHelper.GetMethodInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidMethodModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Private, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonProtectedMethod()
        {
            MethodOptions options = new MethodOptions("PrivateMethodWithoutParameters", typeof(void), new Type[0]) { IsFamily = true };
            try
            {
                ReflectionHelper.GetMethodInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidMethodModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Protected, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonPublicMethod()
        {
            MethodOptions options = new MethodOptions("PrivateMethodWithoutParameters", typeof(void), new Type[0]) { IsPublic = true };
            try
            {
                ReflectionHelper.GetMethodInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidMethodModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Public, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
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
            ConstructorOptions options = new ConstructorOptions(new Type[] { typeof(string) });
            try
            {
                ReflectionHelper.GetConstructorInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (MissingConstructorException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
            }
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPrivate()
        {
            ConstructorOptions options = new ConstructorOptions(new Type[] { typeof(int) }) { IsPrivate = true };
            try
            {
                ReflectionHelper.GetConstructorInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch(InvalidConstructorModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Private, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonProtected()
        {
            ConstructorOptions options = new ConstructorOptions(new Type[0]) { IsFamily = true };
            try
            {
                ReflectionHelper.GetConstructorInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidConstructorModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Protected, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonPublic()
        {
            ConstructorOptions options = new ConstructorOptions(new Type[0]) { IsPublic = true };
            try
            {
                ReflectionHelper.GetConstructorInfo(typeof(Class), options);
                Assert.Fail("No exception was thrown");
            }
            catch (InvalidConstructorModifierException ex)
            {
                Assert.AreEqual(typeof(Class), ex.Type);
                Assert.AreSame(options, ex.Options);
                Assert.AreEqual(MemberModifiers.Public, ex.Modifier);
                Assert.IsTrue(ex.ShouldHaveModifier);
            }
        }
    }
}
