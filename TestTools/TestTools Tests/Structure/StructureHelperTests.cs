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
            ReflectionHelper.GetFieldInfo(typeof(Class), new FieldRequirements("PrivateIntField", typeof(int)));
        }

        [TestMethod, TestCategory("Field")]
        public void ThrowsOnNonExistentField()
        {
            try {
                ReflectionHelper.GetFieldInfo(typeof(Class), new FieldRequirements("FakeField", typeof(int)));
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
            FieldRequirements options = new FieldRequirements("PublicIntField", typeof(string));
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
            FieldRequirements options = new FieldRequirements("PublicIntField", typeof(int)) { IsPrivate = true };
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
            FieldRequirements options = new FieldRequirements("PublicIntField", typeof(int)) { IsFamily = true };
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
            FieldRequirements options = new FieldRequirements("PrivateIntField", typeof(int)) { IsPublic = true };
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
            ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyRequirements("PrivateIntProperty", typeof(int)));
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateReadonlyProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyRequirements("PrivateReadonlyIntProperty", typeof(int)) { GetMethod = new MethodRequirements() { IsPrivate = true } });
        }

        [TestMethod, TestCategory("Property")]
        public void DetectsPrivateWriteonlyProperty()
        {
            ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyRequirements("PrivateWriteonlyIntProperty", typeof(int)) { SetMethod = new MethodRequirements() { IsPrivate = true } });
        }

        [TestMethod, TestCategory("Property")]
        public void ThrowsOnNonExistentProperty()
        {
            try
            {
                ReflectionHelper.GetPropertyInfo(typeof(Class), new PropertyRequirements("FakeProperty", typeof(int)));
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
            PropertyRequirements options = new PropertyRequirements("PublicIntProperty", typeof(string));
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
            PropertyRequirements options = new PropertyRequirements("PublicIntProperty", typeof(int)) { GetMethod = new MethodRequirements() { IsPrivate = true } };
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

            PropertyRequirements options = new PropertyRequirements("PrivateIntProperty", typeof(int)) { GetMethod = new MethodRequirements() { IsFamily = true } };
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
            PropertyRequirements options = new PropertyRequirements("PrivateIntProperty", typeof(int)) { GetMethod = new MethodRequirements() { IsPublic = true } };
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
            PropertyRequirements options = new PropertyRequirements("PublicIntProperty", typeof(int)) { SetMethod = new MethodRequirements() { IsPrivate = true } };
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
            PropertyRequirements options = new PropertyRequirements("PrivateIntProperty", typeof(int)) { SetMethod = new MethodRequirements() { IsFamily = true } };
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
            PropertyRequirements options = new PropertyRequirements("PrivateIntProperty", typeof(int)) { SetMethod = new MethodRequirements() { IsPublic = true } };
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
            ReflectionHelper.GetMethodInfo(typeof(Class), new MethodRequirements("PrivateMethodWithoutParameters", typeof(void), new Type[0]));
        }

        [TestMethod, TestCategory("Method")]
        public void DetectsPrivateMethodWithParameters()
        {
            ReflectionHelper.GetMethodInfo(typeof(Class), new MethodRequirements("PrivateMethodWithParameters", typeof(int), new Type[] { typeof(int) }));
        }

        [TestMethod, TestCategory("Method")]
        public void ThrowsOnNonExistentMethod()
        {
            try
            {
                ReflectionHelper.GetMethodInfo(typeof(Class), new MethodRequirements("FakeMethod", typeof(void), new Type[0]));
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
            MethodRequirements options = new MethodRequirements("PrivateMethodWithParameters", typeof(string), new Type[] { typeof(int) });
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
            MethodRequirements options = new MethodRequirements("PrivateMethodWithParameters", typeof(int), new Type[] { typeof(string) });
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
            MethodRequirements options = new MethodRequirements("PublicMethodWithoutParameters", typeof(void), new Type[0]) { IsPrivate = true };
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
            MethodRequirements options = new MethodRequirements("PrivateMethodWithoutParameters", typeof(void), new Type[0]) { IsFamily = true };
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
            MethodRequirements options = new MethodRequirements("PrivateMethodWithoutParameters", typeof(void), new Type[0]) { IsPublic = true };
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
            ReflectionHelper.GetConstructorInfo(typeof(Class), new ConstructorRequirements());
        }

        [TestMethod, TestCategory("Constructor")]
        public void ThrowsOnNonExistentConstructor()
        {
            ConstructorRequirements options = new ConstructorRequirements(new Type[] { typeof(string) });
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
            ConstructorRequirements options = new ConstructorRequirements(new Type[] { typeof(int) }) { IsPrivate = true };
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
            ConstructorRequirements options = new ConstructorRequirements(new Type[0]) { IsFamily = true };
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
            ConstructorRequirements options = new ConstructorRequirements(new Type[0]) { IsPublic = true };
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
