using Lecture_7_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
using static Lecture_7_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_7_Tests
{
    [TestClass]
    public class Exercise_2_Tests {
        #region Exercise 2B
        [TestMethod("MyQueue has constructor which takes int"), TestCategory("Exercise 2B")]
        public void MyQueueHasConstructorWhichTakesInt()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<int, MyQueue<int>>(i => new MyQueue<int>(i));
            test.Execute();
        }

        [TestMethod("MyQueue.MaxCount is public read-only property"), TestCategory("Exercise 2B")]
        public void MyQueueMaxCountIsPublicReadonlyProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<MyQueue<int>, int>(q => q.MaxCount);
            test.Execute();
        }

        [TestMethod("MyQueue(int value) sets MaxCount equal to value"), TestCategory("Exercise 2B")]
        public void MyQueueConstructorSetsMaxCount()
        {
            MyQueue<int> queue = new MyQueue<int>(5);
            Assert.AreEqual(queue.MaxCount, 5);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(5)));
            test.Assert.AreEqual(Expr(_queue, q => q.MaxCount), Const(5));
            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("MyQueue.Count is read-only int property"), TestCategory("Exercise 2C")]
        public void MyQueueCountIsReadOnlyIntProoerty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<MyQueue<int>, int>(q => q.Count);
            test.Execute();
        }

        [TestMethod("MyQueue.Count is initialized as 0"), TestCategory("Exercise 2C")]
        public void MyQueueCountIsInitializedAs0()
        {
            MyQueue<int> queue = new MyQueue<int>(5);
            Assert.AreEqual(queue.Count, 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(5)));
            test.Assert.AreEqual(Expr(_queue, q => q.Count), Const(0));
            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("MyQueue.Enqueue() takes T and returns nothing"), TestCategory("Exercise 2D")]
        public void MyQueueEnqueueTakesTAndReturnsNothing()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<MyQueue<int>, int>(q => q.Peek());
            test.AssertPublicMethod<MyQueue<double>, double>(q => q.Peek());
            test.Execute();
        }

        [TestMethod("MyQueue.Dequeue() takes T and returns nothing"), TestCategory("Exercise 2D")]
        public void MyQueueDequeueTakesNothingAndReturnsNothing()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<MyQueue<int>, int>(q => q.Peek());
            test.AssertPublicMethod<MyQueue<double>, double>(q => q.Peek());
            test.Execute();
        }

        [TestMethod("MyQueue.Enqueue(T value) increases Count"), TestCategory("Exercise 2D")]
        public void MyQueueEnqueueIncreasesCount()
        {
            MyQueue<int> queue = new MyQueue<int>(5);
            
            queue.Enqueue(1);

            Assert.AreEqual(queue.Count, 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(5)));
            test.Act(Expr(_queue, q => q.Enqueue(1)));
            test.Assert.AreEqual(Expr(_queue, q => q.Count), Const(1));
            test.Execute();
        }

        [TestMethod("MyQueue.Dequeue(T value) decreases Count"), TestCategory("Exercise 2D")]
        public void MyQueueDequeueDecreaseCount()
        {
            // FAILS AND REQUIRES MORE WORK
            MyQueue<int> queue = new MyQueue<int>(5);
            
            queue.Enqueue(1);
            queue.Dequeue();
            
            Assert.AreEqual(queue.Count, 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(5)));
            test.Act(Expr(_queue, q => q.Enqueue(1)));
            test.Act(Expr(_queue, q => q.Dequeue()));
            test.Assert.AreEqual(Expr(_queue, q => q.Count), Const(0));
            test.Execute();
        }

        [TestMethod("MyQueue.Enqueue(T value) throws InvalidOperationException if queue is already full"), TestCategory("Exercise 2D")]
        public void MyQueueEnqueueThrowsInvalidOperationException()
        {
            // FAILS AND REQUIRES MORE WORK
            MyQueue<int> queue = new MyQueue<int>(2);
            queue.Enqueue(1);
            Assert.ThrowsException<InvalidOperationException>(() => queue.Enqueue(2));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(2)));
            test.Act(Expr(_queue, q => q.Enqueue(1)));
            test.Assert.ThrowsExceptionOn<InvalidOperationException>(Expr(_queue, q => q.Enqueue(2)));
            test.Execute();
        }

        [TestMethod("MyQueue.Enqueue(T value) throws ArgumentException if queue is already empty"), TestCategory("Exercise 2D")]
        public void MyQueueDequeueThrowsInvalidOperationException()
        {
            // FAILS AND REQUIRES MORE WORK
            MyQueue<int> queue = new MyQueue<int>(5);
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(5)));
            test.Assert.ThrowsExceptionOn<InvalidOperationException, int>(Expr(_queue, q => q.Dequeue()));
            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("MyQueue.Peek() takes nothing and returns T"), TestCategory("Exercise 2E")]
        public void MyQueuePeekIsPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<MyQueue<int>, int>(q => q.Peek());
            test.AssertPublicMethod<MyQueue<double>, double>(q => q.Peek());
            test.Execute();
        }

        [TestMethod("MyQueue.Peek() returns first element in queue"), TestCategory("Exercise 2E")]
        public void MyQueuePeekReturnsFirstElementInQueue()
        {
            // FAILS AND REQUIRES MORE WORK
            MyQueue<int> queue = new MyQueue<int>(5);

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(queue.Peek(), 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(5)));
            test.Act(Expr(_queue, q => q.Enqueue(1)));
            test.Act(Expr(_queue, q => q.Enqueue(2)));
            test.Assert.AreEqual(Expr(_queue, q => q.Peek()), Const(1));
            test.Execute();
        }

        [TestMethod("MyQueue.Peek() does not modify queue"), TestCategory("Exercise 2E")]
        public void MyQueuePeekDoesNotModifyQueue()
        {
            // FAILS AND REQUIRES MORE WORK
            MyQueue<int> queue = new MyQueue<int>(5);
            
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Peek();

            Assert.AreEqual(queue.Peek(), 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyQueue<int>> _queue = test.CreateVariable<MyQueue<int>>();
            test.Arrange(_queue, Expr(() => new MyQueue<int>(5)));
            test.Act(Expr(_queue, q => q.Enqueue(1)));
            test.Act(Expr(_queue, q => q.Enqueue(2)));
            test.Act(Expr(_queue, q => q.Peek()));
            test.Assert.AreEqual(Expr(_queue, q => q.Peek()), Const(1));
            test.Execute();
        }
        #endregion
    }
}
