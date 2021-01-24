using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Integrated
{
    // For static members
    // Used to Arrange, Act and Assert on the reflected namespace 
    public class UnitTestEventTracker<T> : UnitTestObject<T> where T : Delegate
    {
        public new AssertObject Assert { get; }

        public new class AssertObject
        {
            public void IsTrue<TPar1>(Expression<Func<TPar1, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsTrue<TPar1, TPar2>(Expression<Func<TPar1, TPar2, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsTrue<TPar1, TPar2, TPar3>(Expression<Func<TPar1, TPar2, TPar3, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse<TPar1>(Expression<Func<TPar1, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse<TPar1, TPar2>(Expression<Func<TPar1, TPar2, bool>> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse<TPar1, TPar2, TPar3>(Expression<Func<TPar1, TPar2, TPar3, bool>> assertion)
            {
                throw new NotImplementedException();
            }
        }
    }
}