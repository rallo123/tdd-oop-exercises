using Lecture_9_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using static TestTools.Unit.TestExpression;
using static Lecture_9_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;
using System.Collections.Specialized;

namespace Lecture_9_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        #region Exercise 4A
        [TestMethod("a. ObservableCollection<T> implements ICollection")]
        public void ObservableCollectionImplementsICollection()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<ObservableCollection<int>>(new TypeIsSubclassOfVerifier(typeof(ICollection<int>)));
            test.Execute();
        }
        #endregion

        #region Exercise 4B
        [TestMethod("a. ObservableCollection<T> implements INotifyCollectionChanged")]
        public void ObservableCollectionImplementsINotifyCollectionChanged()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<ObservableCollection<int>>(new TypeIsSubclassOfVerifier(typeof(INotifyCollectionChanged)));
            test.Execute();
        }

        [TestMethod("b. ObservableCollection<T>.Add(T elem) emits CollectionChanged event")]
        public void ObservableCollectionAddEmitsCollectionChangedEvents()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ObservableCollection<int>> collection = test.CreateVariable<ObservableCollection<int>>();

            test.Arrange(collection, Expr(() => new ObservableCollection<int>()));
            test.DelegateAssert.IsInvoked(Lambda<NotifyCollectionChangedEventHandler>(handler => Expr(collection, c => c.AddCollectionChanged(handler))));
            test.Act(Expr(collection, c => c.Add(5)));

            test.Execute();
        }

        [TestMethod("c. ObservableCollection<T>.Clear() emits CollectionChanged event")]
        public void ObservableCollectionClearEmitsCollectionChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ObservableCollection<int>> collection = test.CreateVariable<ObservableCollection<int>>();

            test.Arrange(collection, Expr(() => new ObservableCollection<int>()));
            test.DelegateAssert.IsInvoked(Lambda<NotifyCollectionChangedEventHandler>(handler => Expr(collection, c => c.AddCollectionChanged(handler))));
            test.Act(Expr(collection, c => c.Clear()));

            test.Execute();
        }

        [TestMethod("d. ObservableCollection<T>.Remove(T elem) emits CollectionChanged event")]
        public void ObservableCollectionRemoveEmitsCollectionChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ObservableCollection<int>> collection = test.CreateVariable<ObservableCollection<int>>();

            test.Arrange(collection, Expr(() => new ObservableCollection<int>() { 1 }));
            test.DelegateAssert.IsInvoked(Lambda<NotifyCollectionChangedEventHandler>(handler => Expr(collection, c => c.AddCollectionChanged(handler))));
            test.Act(Expr(collection, c => c.Remove(1)));

            test.Execute();
        }
        #endregion
    }
}
