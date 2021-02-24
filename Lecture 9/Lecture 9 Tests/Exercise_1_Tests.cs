using Lecture_9_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
using static Lecture_9_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_9_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        #region Exercise 1A
        [TestMethod("SortedCollection<T> implements ICollection<T>")]
        public void SortedCollectionImplementsICollections()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<SortedCollection<int>>(new TypeIsSubclassOfVerifier(typeof(ICollection<int>)));
            test.AssertClass<SortedCollection<double>>(new TypeIsSubclassOfVerifier(typeof(ICollection<double>)));
            test.Execute();
        }

        [TestMethod("SortedCollection<T>.Add(T elem) adds element in correct order")]
        public void SortedCollectionAddAddsElementInOrder()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>()));
            test.Act(Expr(collection, c => c.Add(3)));
            test.Act(Expr(collection, c => c.Add(5)));
            test.Act(Expr(collection, c => c.Add(2)));
            test.Assert.IsTrue(Expr(collection, c => c.SequenceEqual(new[] { 2, 3, 5 })));

            test.Execute();
        }

        [TestMethod("SortedCollection<T>.Clear() removes all elements")]
        public void SortedCollectionClearRemovesAllElements()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3 }));
            test.Act(Expr(collection, c => c.Clear()));
            test.Assert.IsFalse(Expr(collection, c => c.Any()));

            test.Execute();
        }

        [TestMethod("SortedCollection<T>.Contains(T elem) returns true if element in collection")]
        public void SortedCollectionContainsReturnsTrue()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3 }));
            test.Assert.IsTrue(Expr(collection, c => c.Contains(2)));

            test.Execute();
        }

        [TestMethod("SortedCollection<T>.Contains(T elem) returns false if element is not in collection")]
        public void SortedCollectionContainsReturnsFalse()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3 }));
            test.Assert.IsTrue(Expr(collection, c => c.Contains(4)));

            test.Execute();
        }

        [TestMethod("SortedCollection<T>.CopyTo(T[] arr, int i) copies elements to array")]
        public void SortedCollectionCopyToCopiesElementsToArray()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();
            TestVariable<int[]> array = test.CreateVariable<int[]>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 2, 3, 5 }));
            test.Arrange(array, Expr(() => new int[3]));
            test.Act(Expr(collection, array, (c, a) => c.CopyTo(a, 0)));
            test.Assert.IsTrue(Expr(array, a => a.SequenceEqual(new[] { 2, 3, 5 })));

            test.Execute();
        }

        [TestMethod("SortedCollection<T>.Remove(T elem) removes element")]
        public void SortedCollectionRemoveRemovesElement()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3 }));
            test.Act(Expr(collection, c => c.Remove(1)));
            test.Assert.IsTrue(Expr(collection, c => c.SequenceEqual(new[] { 2, 3 })));

            test.Execute();
        }
        #endregion

        #region Exercise 1B
        [TestMethod("SortedCollection<T>[int index] is a readonly property")]
        public void SortedCollectionIsAReadonlyProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<SortedCollection<int>, int>(GetIndexProperty<SortedCollection<int>>());
            test.Execute();
        }

        [TestMethod("SortedCollection<T>[int index] returns correct element")]
        public void SortedCollectionReturnsCorrectElement()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3 }));
            test.Assert.AreEqual(Expr(collection, c => c[1]), Const(2));

            test.Execute();
        }
        #endregion

        #region Exercise 1C
        [TestMethod("SortedCollection<T>.GetAll() returns enumeration of collection")]
        public void SortCollectionGetAllReturnsEnumerationOfCollection()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3 }));
            test.Assert.IsTrue(Expr(collection, c => c.GetAll().SequenceEqual(new[] { 1, 2, 3 })));

            test.Execute();
        }

        [TestMethod("SortedCollection<T>.GetAllReversed() returns reversed enumeration of collection")]
        public void SortedCollectionGetAllReversedReturnsReversedEnumerationOfCollection()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3 }));
            test.Assert.IsTrue(Expr(collection, c => c.GetAllReversed().SequenceEqual(new[] { 3, 2, 1 })));

            test.Execute();
        }
        #endregion

        #region Exercise 1D
        [TestMethod("SortedCollection<T>.GetAll(Predicate<T> p) returns enumeration of collection")]
        public void SortCollectionGetAllReturnsEnumerationOfCollection2()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3, 4 }));
            test.Assert.IsTrue(Expr(collection, c => c.GetAll(x => x % 2 == 0).SequenceEqual(new[] { 2, 4 })));

            test.Execute();
        }

        [TestMethod("SortedCollection<T>.GetAllReversed(Predicate<T> p) returns reversed enumeration of collection")]
        public void SortedCollectionGetAllReversedReturnsReversedEnumerationOfCollection2()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<SortedCollection<int>> collection = test.CreateVariable<SortedCollection<int>>();

            test.Arrange(collection, Expr(() => new SortedCollection<int>() { 1, 2, 3, 4 }));
            test.Assert.IsTrue(Expr(collection, c => c.GetAllReversed(x => x % 2 == 0).SequenceEqual(new[] { 4, 2 })));

            test.Execute();
        }
        #endregion
    }
}
