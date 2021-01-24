using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Integrated
{
    // For object members
    // Used to Arrange, Act and Assert on the reflected namespace
    public class UnitTestObject<T>
    {
        internal UnitTestObject() {}

        public void Act(Expression<Action<T>> action)
        {
            throw new NotImplementedException();
        }

        public void Arrange(Expression<Func<T>> setup)
        {
            throw new NotImplementedException();
        }

        public UnitTestObject<T, TOther> WithParameters<TOther>(UnitTestObject<TOther> UnitTestObject)
        {
            throw new NotImplementedException();
        }

        public UnitTestObject<T, TOther1, TOther2> WithParameters<TOther1, TOther2>(UnitTestObject<TOther1> UnitTestObject1, UnitTestObject<TOther2> UnitTestObject2)
        {
            throw new NotImplementedException();
        }

        public AssertObject Assert { get; }

        public CollectionAssertObject CollectionAssert { get; } 

        public class AssertObject
        {
            public void IsTrue(Expression<Func<T, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse(Expression<Func<T, bool>> assertion)
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
            public void Contains<TItem>(Expression<Func<T, ICollection<TItem>>> collectionLocator, TItem item)
            {
                throw new NotImplementedException();
            }

            public void DoesNotContains<TItem>(Expression<Func<T, ICollection<TItem>>> collectionLocator, TItem item)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class UnitTestObject<T1, T2>
    {
        internal UnitTestObject() { }

        public void Act(Expression<Action<T1, T2>> action)
        {
            throw new NotImplementedException();
        }

        public void Arrange(Expression<Func<T2, T1>> setup)
        {
            throw new NotImplementedException();
        }

        public UnitTestObject<T1, T2, TOther> WithParameters<TOther>(UnitTestObject<TOther> UnitTestObject)
        {
            throw new NotImplementedException();
        }

        public AssertObject Assert { get; }

        public CollectionAssertObject CollectionAssert { get; }

        public class AssertObject
        {
            public void IsTrue(Expression<Func<T1, T2, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse(Expression<Func<T1, T2, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void AssertThrowsException<TException>(Expression<Action<T1, T2>> action)
            {
                throw new NotImplementedException();
            }
        }

        public class CollectionAssertObject
        {
            public void Contains<TItem>(Expression<Func<T1, ICollection<TItem>>> collectionLocator)
            {
                throw new NotImplementedException();
            }

            public void DoesNotContains<TItem>(Expression<Func<T1, ICollection<TItem>>> collectionLocator)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class UnitTestObject<T1, T2, T3>
    {
        internal UnitTestObject() { }

        public void Act(Expression<Action<T1, T2, T3>> action)
        {
            throw new NotImplementedException();
        }

        public void Arrange(Expression<Func<T2, T3, T1>> setup)
        {
            throw new NotImplementedException();
        }

        public AssertObject Assert { get; }

        public class AssertObject
        {
            public void IsTrue(Expression<Func<T1, T2, T3, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse(Expression<Func<T1, T2, T3, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void AssertThrowsException<TException>(Expression<Action<T1, T2, T3>> action)
            {
                throw new NotImplementedException();
            }
        }
    }

    // Used to Arrange, Act and Assert on the reflected namespace, but is transparent in errors
    public class AnonymousUnitTestObject<T> : UnitTestObject<T>
    {
        internal AnonymousUnitTestObject() { }
    }

    /* 
     * NOTE Should only be used in situations, where you find yourself reimplementing 
     * or using solution code in tests, because it limits test validation
     */
    // Used to Arrange, Act and Assert on the reflected and current namespace
    public class DualUnitTestObject<T> : UnitTestObject<T>
    {
        internal DualUnitTestObject() { }
    }

    /* 
     * NOTE Should only be used in situations, where you find yourself reimplementing 
     * or using solution code in tests, because it limits test validation
     */
    // Used to Arrange, Act and Assert on the reflected and current namespace, but is transparent in errors
    public class AnonymousUnitDualTestObject<T> : DualUnitTestObject<T>
    {
        internal AnonymousUnitDualTestObject() { }
    }
}
