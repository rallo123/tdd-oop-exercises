using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Unit
{
    public class UnitTest
    {
        public UnitTestConfiguration Configuration { get; set; } = new UnitTestConfiguration();

        public AssertObject Assert { get; } = new AssertObject();

        public CollectionAssertObject CollectionAssert { get; } = new CollectionAssertObject();

        public DelegateAssertObject DelegateAssert { get; } = new DelegateAssertObject();

        internal UnitTest()
        {
        }

        public TestConsole CaptureConsole()
        {
            throw new NotImplementedException();
        }

        public TestFileSystem CaptureFileSystem()
        {
            throw new NotImplementedException();
        }

        public TestVariable<T> CreateVariable<T>()
        {
            return CreateVariable<T>(typeof(T).Name.ToLower());
        }

        public TestVariable<T> CreateVariable<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public void Arrange<T>(TestVariable<T> variable)
        {
            Arrange(variable, TestExpression.Create(() => default(T)));
        }

        public void Arrange<T>(TestVariable<T> variable, TestExpression<T> initialization)
        {
            throw new NotImplementedException();
        }

        public void Act(TestExpression action)
        {
            throw new NotImplementedException();
        }

        public class AssertObject
        {
            public void AreEqual<T>(TestExpression<T> value1, TestExpression<T> value2)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual<T>(TestExpression<T> value1, TestExpression<T> value2)
            {
                throw new NotImplementedException();
            }

            public void AreSame<T>(TestExpression<T> value1, TestExpression<T> value2)
            {
                throw new NotImplementedException();
            }

            public void AreNotSame<T>(TestExpression<T> value1, TestExpression<T> value2)
            {
                throw new NotImplementedException();
            }

            public void IsTrue(TestExpression<bool> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse(TestExpression<bool> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsNull<T>(TestExpression<T> value)
            {
                throw new NotImplementedException();
            }

            public void IsNotNull<T>(TestExpression<T> value)
            {
                throw new NotImplementedException();
            }

            public void ThrowsException<TException>(TestExpression<Action> action)
            {
                throw new NotImplementedException();
            }
        }

        public class CollectionAssertObject
        {
            public void Contains<T1, T2>(TestExpression<ICollection<T1>> collection, TestExpression<T2> element) where T2 : T1
            {
                throw new NotImplementedException();
            }
        }

        public class DelegateAssertObject
        {
            public void IsInvoked<TDelegate>(TestExpression<Action<TDelegate>> subscribe) where TDelegate : Delegate
            {
                throw new NotImplementedException();
            }

            public void IsInvoked<TDelegate>(TestExpression<Action<TDelegate>> subscribe, TDelegate assertionCallback) where TDelegate : Delegate
            {
                throw new NotImplementedException();
            }

            public void IsNotInvoked<TDelegate>(TestExpression<Action<TDelegate>> subscribe) where TDelegate : Delegate
            {
                throw new NotImplementedException();
            }
        }

        public void Execute()
        {

        }
    }
}
