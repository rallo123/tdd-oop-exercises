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

        #region Field Assertions
        public void AssertField<TInstance, TField>(Expression<Func<TInstance, TField>> locator, Expression<Func<FieldInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticField<TInstance>(Expression<Action<TInstance>> locator, Expression<Func<ConstructorInfo, bool>> predicate)
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

        public void AssertStaticMethod<TReturn>(Expression<Action<TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TReturn>(Expression<Action<TPar1, TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TPar2, TReturn>(Expression<Action<TPar1, TPar2, TReturn>> locator, Expression<Func<MethodInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Property Assertions
        public void AssertProperty<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> locator, Expression<Func<PropertyInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticProperty<TReturn>(Expression<Action<TReturn>> locator, Expression<Func<PropertyInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
