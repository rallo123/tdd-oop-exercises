using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Integrated
{
    public class Test
    {
        internal Test()
        {

        }

        public void Act<T>(TestObject<T> obj, Expression<Action<T>> action)
        {
            throw new NotImplementedException();
        }

        public void Act<T1, T2>(TestObject<T1> obj1, TestObject<T2> obj2, Expression<Action<T1, T2>> action)
        {
            throw new NotImplementedException();
        }

        public void Act<T1, T2, T3>(TestObject<T1> obj1, TestObject<T2> obj2, TestObject<T3> obj3, Expression<Action<T1, T2, T3>> action)
        {
            throw new NotImplementedException();
        }

        public void ActAssign<T, TValue>(TestObject<T> obj, Expression<Func<T, TValue>> locator, TValue value)
        {
            throw new NotImplementedException();
        }

        public void ActAssign<T, TValue>(TestObject<T> obj1, Expression<Func<T, TValue>> locator, TestObject<TValue> obj2)
        {
            throw new NotImplementedException();
        }

        public void ActAsFunction<T1, T2>(TestObject<T1> obj1, TestObject<T2> obj2, Expression<Func<T1, T2>> action)
        {
            throw new NotImplementedException();
        }

        public void ActAsFunction<T1, T2, T3>(TestObject<T1> obj1, TestObject<T2> obj2, TestObject<T3> obj3, Expression<Func<T1, T2, T3>> action)
        {
            throw new NotImplementedException();
        }

        public void Arrange<T>(TestObject<T> obj, Expression<Func<T>> setup)
        {
            throw new NotImplementedException();
        }

        public void Arrange<T1, T2>(TestObject<T1> obj1, TestObject<T2> obj2, Expression<Func<T2, T1>> setup)
        {
            throw new NotImplementedException();
        }

        public void Arrange<T1, T2, T3>(TestObject<T1> obj1, TestObject<T2> obj2, TestObject<T3> obj3, Expression<Func<T2, T3, T1>> setup)
        {
            throw new NotImplementedException();
        }

        public void Assert<T>(TestObject<T> obj, Expression<Func<T, bool>> assertion)
        {
            throw new NotImplementedException();
        }

        public void Assert<T>(TestObject<T> obj, Expression<Func<T, T, bool>> assertion)
        {
            throw new NotImplementedException();
        }


        public void Assert<T1, T2>(TestObject<T1> obj1, TestObject<T1> obj2, Expression<Func<T1, T2, bool>> assertion)
        {
            throw new NotImplementedException();
        }

        public void Assert<T1, T2>(TestObject<T1> obj1, TestObject<T1> obj2, Expression<Func<T1, T1, T2, T2, bool>> assertion)
        {
            throw new NotImplementedException();
        }

        public void AssertThrows<T>(TestObject<T> obj, Expression<Action<T>> action)
        {
            throw new NotImplementedException();
        }

        public void AssertThrows<T1, T2>(TestObject<T1> obj1, TestObject<T2> obj2, Expression<Action<T1, T2>> action)
        {
            throw new NotImplementedException();
        }

        public void AssertUnchanged<TObj, TProperty>(TestObject<TObj> obj, Expression<Func<TObj, TProperty>> locator)
        {
            throw new NotImplementedException();
        }

        public void AssertIncreased<TObj, TProperty>(TestObject<TObj> obj1, TestObject<TObj> obj2, Expression<Func<TObj, TProperty>> locator)
        {
            throw new NotImplementedException();
        }

        public void AssertWriteOut(string str)
        {
            throw new NotImplementedException();
        }


        public void Assert(TestConsole console, string output)
        {
            throw new NotImplementedException();
        }

        public TestConsole CaptureConsole()
        {
            throw new NotImplementedException();
        }

        public TestObject<T> Create<T>()
        {
            return Create<T>(typeof(T).Name.ToLower());
        }

        
        public TestObject<T> Create<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public AnonymousTestObject<T> CreateAnonymous<T>()
        {
            return CreateAnonymous<T>(typeof(T).Name.ToLower());
        }

        public AnonymousTestObject<T> CreateAnonymous<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {

        }
    }
}
