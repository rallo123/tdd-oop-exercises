using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TestTools.Structure;

namespace TestTools.Integrated
{
    public class StructureTest
    {
        internal StructureTest() { }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        #region Class Assertions
        public void AssertClass(Type @class, Expression<Func<Type, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertClass<TClass>(Expression<Func<Type, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Constructor Assertions
        public void AssertConstructor<TReturn>(Expression<Func<TReturn>> locator, Expression<Func<ConstructorInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructor<TPar1, TReturn>(Expression<Func<TPar1, TReturn>> locator, Expression<Func<ConstructorInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructor<TPar1, TPar2, TReturn>(Expression<Func<TPar1, TPar2, TReturn>> locator, Expression<Func<ConstructorInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delegate Assertions
        public void AssertDelegate<TDelegate1, TDelegate2>(Expression<Func<Type, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Assertions 
        public void AssertEvent<TInstance, TDelegate>(EventInfo info)
        {
            throw new NotImplementedException();
        }

        public void AssertEvent<TInstance, TDelegate>(EventInfo info, Expression<Func<EventInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticEvent<TDelegate>(Expression<Action<TDelegate>> locator)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticEvent<TInstance>(Expression<Action<TInstance>> locator, Expression<Func<EventInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Field Assertions
        public void AssertField<TInstance, TField>(Expression<Func<TInstance, TField>> locator, Expression<Func<FieldInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticField<TField>(Expression<Func<TField>> locator, Expression<Func<ConstructorInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Method Assertions
        public void AssertMethod<TInstance, TReturn>(Expression<Func<TInstance, TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TReturn>(Expression<Func<TInstance, TPar1, TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TPar2, TReturn>(Expression<Func<TInstance, TPar1, TPar2, TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance>(Expression<Action<TInstance>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1>(Expression<Action<TInstance, TPar1>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TPar2>(Expression<Action<TInstance, TPar1, TPar2>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TReturn>(Expression<Action> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1>(Expression<Action<TPar1>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TPar2>(Expression<Action<TPar1, TPar2>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TReturn>(Expression<Func<TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TReturn>(Expression<Func<TPar1, TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TPar2, TReturn>(Expression<Func<TPar1, TPar2, TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Property Assertions
        public void AssertProperty<TInstance, TProperty>(PropertyInfo info, Expression<Func<PropertyInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertProperty<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> locator, Expression<Func<PropertyInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticProperty<TReturn>(PropertyInfo info, Expression<Func<PropertyInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticProperty<TReturn>(Expression<Action<TReturn>> locator, Expression<Func<PropertyInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertInterface<T>()
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<T1, T2>(Func<T1, T2> p)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<T1, T2, T3>(Func<T1, T3, T3> p)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<T1, T2, T3, T4>(Func<T1, T4, T4, T4> p)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
