using Lecture_9_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Integrated;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
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
            test.AssertClass<ObservableCollection<int>>(HasClassImplementedInterface(typeof(ICollection<int>)));
            test.Execute();
        }
        #endregion

        #region Exercise 4B
        [TestMethod("a. ObservableCollection<T> implements INotifyCollectionChanged")]
        public void ObservableCollectionImplementsINotifyCollectionChanged()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<ObservableCollection<int>>(HasClassImplementedInterface(typeof(INotifyCollectionChanged)));
            test.Execute();
        }

        [TestMethod("b. ObservableCollection<T>.Add(T elem) emits CollectionChanged event")]
        public void ObservableCollectionAddEmitsCollectionChangedEvents()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ObservableCollection<int>> collection = test.CreateVariable<ObservableCollection<int>>();
            
            collection.Arrange(() => new ObservableCollection<int>());
            collection.DelegateAssert.IsInvoked(Subscribe<ObservableCollection<int>, NotifyCollectionChangedEventHandler>("CollectionChanged"));
            collection.Act(c => c.Add(5));
            
            test.Execute();
        }

        [TestMethod("c. ObservableCollection<T>.Clear() emits CollectionChanged event")]
        public void ObservableCollectionClearEmitsCollectionChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ObservableCollection<int>> collection = test.CreateVariable<ObservableCollection<int>>();

            collection.Arrange(() => new ObservableCollection<int>());
            collection.DelegateAssert.IsInvoked(Subscribe<ObservableCollection<int>, NotifyCollectionChangedEventHandler>("CollectionChanged"));
            collection.Act(c => c.Clear());

            test.Execute();
        }

        [TestMethod("d. ObservableCollection<T>.Remove(T elem) emits CollectionChanged event")]
        public void ObservableCollectionRemoveEmitsCollectionChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ObservableCollection<int>> collection = test.CreateVariable<ObservableCollection<int>>();

            collection.Arrange(() => new ObservableCollection<int>() { 1 });
            collection.DelegateAssert.IsInvoked(Subscribe<ObservableCollection<int>, NotifyCollectionChangedEventHandler>("CollectionChanged"));
            collection.Act(c => c.Remove(1));

            test.Execute();
        }
        #endregion
    }
}
