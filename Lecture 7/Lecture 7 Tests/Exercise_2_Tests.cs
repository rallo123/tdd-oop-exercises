using Lecture_7_Solutions;
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
using static Lecture_7_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_7_Tests
{
    [TestClass]
    public class Exercise_2_Tests {
        #region Exercise 2B
        [TestMethod("MyQueue has constructor which takes int"), TestCategory("2B")]
        public void MyQueueHasConstructorWhichTakesInt()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<int, MyQueue<int>>(i => new MyQueue<int>(i), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("MyQueue.MaxCount is public read-only property"), TestCategory("2B")]
        public void MyQueueMaxCountIsPublicReadonlyProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<MyQueue<int>, int>(q => q.MaxCount, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("MyQueue(int value) sets MaxCount equal to value"), TestCategory("2B")]
        public void MyQueueConstructorSetsMaxCount()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(5));
            queue.Assert.IsTrue(q => q.MaxCount == 5);

            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("MyQueue.Count is read-only int property"), TestCategory("2C")]
        public void MyQueueCountIsReadOnlyIntProoerty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<MyQueue<int>, int>(q => q.Count, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("MyQueue.Count is initialized as 0")]
        public void MyQueueCountIsInitializedAs0()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(5));
            queue.Assert.IsTrue(q => q.Count == 0);

            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("MyQueue.Enqueue() takes T and returns nothing")]
        public void MyQueueEnqueueTakesTAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<MyQueue<int>, int>(q => q.Peek(), IsPublicMethod);
            test.AssertMethod<MyQueue<double>, double>(q => q.Peek(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("MyQueue.Dequeue() takes T and returns nothing")]
        public void MyQueueDequeueTakesNothingAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<MyQueue<int>, int>(q => q.Peek(), IsPublicMethod);
            test.AssertMethod<MyQueue<double>, double>(q => q.Peek(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("MyQueue.Enqueue(T value) increases Count")]
        public void MyQueueEnqueueIncreasesCount()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(5));
            queue.Act(q => q.Enqueue(1));
            queue.Assert.IsTrue(q => q.Count == 1);

            test.Execute();
        }

        [TestMethod("MyQueue.Dequeue(T value) decreases Count")]
        public void MyQueueDequeueDecreaseCount()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(5));
            queue.Act(q => q.Enqueue(1));
            queue.Act(q => q.Dequeue());
            queue.Assert.IsTrue(q => q.Count == 0);

            test.Execute();
        }

        [TestMethod("MyQueue.Enqueue(T value) throws InvalidOperationException if queue is already full")]
        public void MyQueueEnqueueThrowsInvalidOperationException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(0));
            queue.Assert.ThrowsException<InvalidOperationException>(q => q.Enqueue(1));

            test.Execute();
        }

        [TestMethod("MyQueue.Enqueue(T value) throws ArgumentException if queue is already empty")]
        public void MyQueueDequeueThrowsInvalidOperationException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(5));
            queue.Assert.ThrowsException<InvalidOperationException>(q => q.Dequeue());

            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("MyQueue.Peek() takes nothing and returns T")]
        public void MyQueuePeekIsPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<MyQueue<int>, int>(q => q.Peek(), IsPublicMethod);
            test.AssertMethod<MyQueue<double>, double>(q => q.Peek(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("MyQueue.Peek() returns first element in queue")]
        public void MyQueuePeekReturnsFirstElementInQueue()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(5));
            queue.Act(q => q.Enqueue(1));
            queue.Act(q => q.Enqueue(2));
            queue.Assert.IsTrue(q => q.Peek() == 1);

            test.Execute();
        }

        [TestMethod("MyQueue.Peek() does not modify queue")]
        public void MyQueuePeekDoesNotModifyQueue()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> queue = test.CreateVariable<MyQueue<int>>();

            queue.Arrange(() => new MyQueue<int>(5));
            queue.Act(q => q.Enqueue(1));
            queue.Act(q => q.Enqueue(2));
            queue.Act(q => q.Peek());
            queue.Assert.IsTrue(q => q.Peek() == 1);

            test.Execute();
        }
        #endregion
    }
}
