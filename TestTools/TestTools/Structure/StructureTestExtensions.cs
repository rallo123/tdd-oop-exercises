using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public static class StructureTestExtensions
    {
        // Design note, methods with qualifiers (like public & abstract) should not be extendable
        // and instead the methods without qualifiers should be used. This is done in an effort to avoid
        // StructureTest.AssertPublicClass<T>(new TypeIsAbstract()) and
        // StructureTest.AssertAbstractClass<T>(new TypeAccessLevel(AccessLevel.Public)),
        // which are fully equavilent however look different.

        public static void AssertClass<T>(this StructureTest test, params ITypeVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertAbstractClass<T>(this StructureTest test)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicClass<T>(this StructureTest test)
        {
            throw new NotImplementedException();
        }

        public static void AssertDelegate<T, TDelegate>(this StructureTest test, params ITypeVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicDelegate<T, TDelegate>(this StructureTest test)
        {
            throw new NotImplementedException();
        }

        public static void AssertInterface<T>(this StructureTest test, params ITypeVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicInterface<T>(this StructureTest test)
        {
            throw new NotImplementedException();
        }

        public static void AssertConstructor(this StructureTest test, ConstructorInfo constructorInfo, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertConstructor<TReturn>(this StructureTest test, Expression<Func<TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertConstructor<TPar1, TReturn>(this StructureTest test, Expression<Func<TPar1, TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertConstructor<TPar1, TPar2, TReturn>(this StructureTest test, Expression<Func<TPar1, TPar2, TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicConstructor<TReturn>(this StructureTest test, Expression<Func<TReturn>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicConstructor<TPar1, TReturn>(this StructureTest test, Expression<Func<TPar1, TReturn>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicConstructor<TPar1, TPar2, TReturn>(this StructureTest test, Expression<Func<TPar1, TPar2, TReturn>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertEvent(this StructureTest test, EventInfo info, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicEvent(this StructureTest test, EventInfo info)
        {
            throw new NotImplementedException();
        }

        public static void AssertField(this StructureTest test, FieldInfo fieldInfo, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertField<TInstance, TField>(this StructureTest test, Expression<Func<TInstance, TField>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicField<TInstance, TField>(this StructureTest test, Expression<Func<TInstance, TField>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicReadonlyField<TInstance, TField>(this StructureTest test, Expression<Func<TInstance, TField>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertProperty<TInstance, TField>(this StructureTest test, PropertyInfo propertyInfo, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertProperty<TInstance, TProperty>(this StructureTest test, Expression<Func<TInstance, TProperty>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicProperty<TInstance, TProperty>(this StructureTest test, Expression<Func<TInstance, TProperty>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicReadonlyProperty<TInstance, TProperty>(this StructureTest test, Expression<Func<TInstance, TProperty>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicWriteonlyProperty<TInstance, TProperty>(this StructureTest test, Expression<Func<TInstance, TProperty>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertMethod(this StructureTest test, MethodInfo methodInfo, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertMethod<TInstance, TReturn>(this StructureTest test, Expression<Func<TInstance, TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertMethod<TInstance, TPar1, TReturn>(this StructureTest test, Expression<Func<TInstance, TPar1, TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertMethod<TInstance, TPar1, TPar2, TReturn>(this StructureTest test, Expression<Func<TInstance, TPar1, TPar2, TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertMethod<TInstance>(this StructureTest test, Expression<Action<TInstance>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertMethod<TInstance, TPar1>(this StructureTest test, Expression<Action<TInstance, TPar1>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertMethod<TInstance, TPar1, TPar2>(this StructureTest test, Expression<Action<TInstance, TPar1, TPar2>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicMethod<TInstance, TReturn>(this StructureTest test, Expression<Func<TInstance, TReturn>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicMethod<TInstance, TPar1, TReturn>(this StructureTest test, Expression<Func<TInstance, TPar1, TReturn>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicMethod<TInstance, TPar1, TPar2, TReturn>(this StructureTest test, Expression<Func<TInstance, TPar1, TPar2, TReturn>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicMethod<TInstance>(this StructureTest test, Expression<Action<TInstance>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicMethod<TInstance, TPar1>(this StructureTest test, Expression<Action<TInstance, TPar1>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertPublicMethod<TInstance, TPar1, TPar2>(this StructureTest test, Expression<Action<TInstance, TPar1, TPar2>> locator)
        {
            throw new NotImplementedException();
        }

        public static void AssertStaticMethod<TReturn>(this StructureTest test, Expression<Func<TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertStaticMethod<TPar1, TReturn>(this StructureTest test, Expression<Func<TPar1, TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertStaticMethod<TPar1, TPar2, TReturn>(this StructureTest test, Expression<Func<TPar1, TPar2, TReturn>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertStaticMethod(this StructureTest test, Expression<Action> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertStaticMethod<TPar1>(this StructureTest test, Expression<Action<TPar1>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public static void AssertStaticMethod<TPar1, TPar2>(this StructureTest test, Expression<Action<TPar1, TPar2>> locator, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }
    }
}
