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

        public void AssertClass<TClass>(ClassOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructor<TReturn>(Expression<Func<TReturn>> field, ConstructorOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructor<TPar1, TReturn>(Expression<Func<TPar1, TReturn>> field, ConstructorOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructor<TPar1, TPar2, TReturn>(Expression<Func<TPar1, TPar2, >> field, ConstructorOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticField<TInstance>(Expression<Action<TInstance>> staticField, PropertyOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertField<TInstance, TField>(Expression<Func<TInstance, TField>> field, PropertyOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TReturn>(Expression<Action<TReturn>> staticMethod, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TReturn>(Expression<Action<TPar1, TReturn>> staticMethod, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticMethod<TPar1, TPar2, TReturn>(Expression<Action<TPar1, TPar2, TReturn>> staticMethod, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TReturn>(Expression<Func<TInstance, TReturn>> field, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TReturn>(Expression<Func<TInstance, TPar1, TReturn>> field, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TPar2, TReturn>(Expression<Func<TInstance, TPar1, TPar2, TReturn>> field, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance>(Expression<Action<TInstance>> field, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1>(Expression<Action<TInstance, TPar1>> field, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertMethod<TInstance, TPar1, TPar2>(Expression<Action<TInstance, TPar1, TPar2>> field, MethodOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertStaticProperty<TReturn>(Expression<Action<TReturn>> staticProperty, PropertyOptions info)
        {
            throw new NotImplementedException();
        }

        public void AssertProperty<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> property, PropertyOptions info)
        {
            throw new NotImplementedException();
        }
    }
}
