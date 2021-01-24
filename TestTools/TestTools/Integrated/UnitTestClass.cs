using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Integrated
{
    // For static members
    // Used to Arrange, Act and Assert on the reflected namespace 
    public class UnitTestClass
    {
        internal UnitTestClass() { }

        public void Act(Expression<Action> action)
        {
            throw new NotImplementedException();
        }

        public UnitTestObject<TOther> WithParameters<TOther>(UnitTestObject<TOther> UnitTestObject)
        {
            throw new NotImplementedException();
        }

        public UnitTestObject<TOther1, TOther2> WithParameters<TOther1, TOther2>(UnitTestObject<TOther1> UnitTestObject1, UnitTestObject<TOther2> UnitTestObject2)
        {
            throw new NotImplementedException();
        }

        public AssertObject Assert { get; }

        public CollectionAssertObject CollectionAssert { get; }

        public class AssertObject
        {
            public void IsTrue(Expression<Func<bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse(Expression<Func<bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void ThrowsException<TException>(Expression<Action<T>> action)
            {
                throw new NotImplementedException();
            }

            public void EqualToDual<TProperty>(Expression<Func<T, TProperty>> locator)
            {
                throw new NotImplementedException();
            }
        }

        public class CollectionAssertObject
        {
            public void Contains<TItem>(Expression<Func<ICollection<TItem>>> collectionLocator, TItem item)
            {
                throw new NotImplementedException();
            }

            public void DoesNotContains<TItem>(Expression<Func<ICollection<TItem>>> collectionLocator, TItem item)
            {
                throw new NotImplementedException();
            }


        }
    }
}
