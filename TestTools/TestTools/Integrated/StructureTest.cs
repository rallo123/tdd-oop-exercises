using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestTools.Structure;

namespace TestTools.Integrated
{
    public class StructureTest
    {
        internal StructureTest() { }

        #region Class Assertions
        public void AssertClass<TClass>(ClassRequirements info)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Constructor Assertions
        public void AssertConstructor<TReturn>(Expression<Func<TReturn>> field, ConstructorRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructor<TPar1, TReturn>(Expression<Func<TPar1, TReturn>> field, ConstructorRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructor<TPar1, TPar2, TReturn>(Expression<Func<TPar1, TPar2, TReturn>> field, ConstructorRequirements info)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Field Assertions
        public void AssertField<TInstance, TField>(Expression<Func<TInstance, TField>> field, PropertyRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticField<TInstance>(Expression<Action<TInstance>> staticField, PropertyRequirements info)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Method Assertions
        public void AssertMethod<TInstance, TReturn>(Expression<Func<TInstance, TReturn>> field, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TReturn>(Expression<Func<TInstance, TPar1, TReturn>> field, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TPar2, TReturn>(Expression<Func<TInstance, TPar1, TPar2, TReturn>> field, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance>(Expression<Action<TInstance>> field, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1>(Expression<Action<TInstance, TPar1>> field, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TPar2>(Expression<Action<TInstance, TPar1, TPar2>> field, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TReturn>(Expression<Action<TReturn>> staticMethod, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TReturn>(Expression<Action<TPar1, TReturn>> staticMethod, MethodRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TPar2, TReturn>(Expression<Action<TPar1, TPar2, TReturn>> staticMethod, MethodRequirements info)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Property Assertions
        public void AssertProperty<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> property, PropertyRequirements info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticProperty<TReturn>(Expression<Action<TReturn>> staticProperty, PropertyRequirements info)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
