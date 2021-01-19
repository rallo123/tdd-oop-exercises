using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Integrated
{
    public class UnitTest
    {
        public UnitTestConfiguration Configuration { get; set; } = new UnitTestConfiguration();

        internal UnitTest()
        {

        }

        public void Assert<T>(UnitTestObject<T> obj, Expression<Func<T, T, bool>> assertion)
        {
            throw new NotImplementedException();
        }


        public void AssertApproximate<TObj>(UnitTestObject<TObj> obj1,  Expression<Func<TObj, bool>> assertion)
        {
            throw new NotImplementedException();
        }

        public void AssertApproximate<TObj1, TObj2>(UnitTestObject<TObj1> obj1, UnitTestObject<TObj2> obj2, Expression<Func<TObj1, TObj2, bool>> assertion)
        {
            throw new NotImplementedException();
        }

        public void AssertCollectionsContains<T1, T2, T3>(UnitTestObject<T1> collectionOwner, UnitTestObject<T2> element, Expression<Func<T1, IEnumerable<T3>>> locator) where T2 : T3
        {
            throw new NotImplementedException();
        }

        public void AssertCollectionsContainsNo<TObj, TProperty>(UnitTestObject<TObj> collectionOwner, UnitTestObject<TProperty> element, Expression<Func<TObj, IEnumerable<TProperty>>> locator)
        {
            throw new NotImplementedException();
        }

        public UnitTestConsole CreateConsole()
        {
            throw new NotImplementedException();
        }

        public UnitTestObject<T> Create<T>()
        {
            return Create<T>(typeof(T).Name.ToLower());
        }

        public UnitTestObject<T> Create<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public AnonymousUnitTestObject<T> CreateAnonymous<T>()
        {
            return CreateAnonymous<T>(typeof(T).Name.ToLower());
        }

        public AnonymousUnitTestObject<T> CreateAnonymous<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public DualUnitTestObject<T> CreateDual<T>()
        {
            return CreateDual<T>(typeof(T).Name.ToLower());
        }

        public DualUnitTestObject<T> CreateDual<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public AnonymousUnitDualTestObject<T> CreateDualAnonymous<T>()
        {
            return CreateDualAnonymous<T>(typeof(T).Name.ToLower());
        }

        public AnonymousUnitDualTestObject<T> CreateDualAnonymous<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {

        }

        public void AssertCollectionEmpty<T1, T2>(UnitTestObject<T1> collectionOwner, Func<T1, IEnumerable<T2>> collectionProperty)
        {
            throw new NotImplementedException();
        }
    }
}
