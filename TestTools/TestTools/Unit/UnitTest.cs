using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Abstractions;
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

        public ConsoleAssertObject ConsoleAssert { get; } = new ConsoleAssertObject();

        internal UnitTest()
        {
        }

        public TestVariable<IFileSystem> CaptureFileSystem()
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

        // Based on Microsoft.VisualStudio.TestTools.UnitTesting.Assert
        public class AssertObject
        {
            #region AreEqual Overloads
            public void AreEqual<T>(TestExpression<T> expected, TestExpression<T> actual)
            {
                throw new NotImplementedException();
            }

            public void AreEqual<T>(TestExpression<T> expected, TestExpression<T> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual<T>(TestExpression<T> expected, TestExpression<T> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<object> expected, TestExpression<object> actual)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<object> expected, TestExpression<object> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<object> expected, TestExpression<object> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<float> expected, TestExpression<float> actual, float delta)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<float> expected, TestExpression<float> actual, float delta, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<float> expected, TestExpression<float> actual, float delta, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<double> expected, TestExpression<double> actual, float delta)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<double> expected, TestExpression<double> actual, float delta, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<double> expected, TestExpression<double> actual, float delta, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<string> expected, TestExpression<string> actual, bool ignoreCase)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<string> expected, TestExpression<string> actual, bool ignoreCase, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<string> expected, TestExpression<string> actual, bool ignoreCase, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<string> expected, TestExpression<string> actual, bool ignoreCase, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<string> expected, TestExpression<string> actual, bool ignoreCase, CultureInfo culture, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<string> expected, TestExpression<string> actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AreNotEqual Overloads
            public void AreNotEqual<T>(TestExpression<T> notExpected, TestExpression<T> actual)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual<T>(TestExpression<T> notExpected, TestExpression<T> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual<T>(TestExpression<T> notExpected, TestExpression<T> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<object> notExpected, TestExpression<object> actual)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<object> notExpected, TestExpression<object> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<object> notExpected, TestExpression<object> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<float> notExpected, TestExpression<float> actual, float delta)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<float> notExpected, TestExpression<float> actual, float delta, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<float> notExpected, TestExpression<float> actual, float delta, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<double> notExpected, TestExpression<double> actual, double delta)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<double> notExpected, TestExpression<double> actual, double delta, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<double> notExpected, TestExpression<double> actual, double delta, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<string> notExpected, TestExpression<string> actual, bool ignoreCase)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<double> notExpected, TestExpression<double> actual, bool ignoreCase, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<double> notExpected, TestExpression<double> actual, bool ignoreCase, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<string> notExpected, TestExpression<string> actual, bool ignoreCase, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<double> notExpected, TestExpression<double> actual, bool ignoreCase, CultureInfo culture, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<double> notExpected, TestExpression<double> actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AreSame Overloads
            public void AreSame<T>(TestExpression<T> expected, TestExpression<T> actual)
            {
                throw new NotImplementedException();
            }

            public void AreSame<T>(TestExpression<T> expected, TestExpression<T> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreSame<T>(TestExpression<T> expected, TestExpression<T> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreSame(TestExpression<object> expected, TestExpression<object> actual)
            {
                throw new NotImplementedException();
            }

            public void AreSame(TestExpression<object> expected, TestExpression<object> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreSame(TestExpression<object> expected, TestExpression<object> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AreNotSame Overloads
            public void AreNotSame<T>(TestExpression<T> notExpected, TestExpression<T> actual)
            {
                throw new NotImplementedException();
            }

            public void AreNotSame<T>(TestExpression<T> notExpected, TestExpression<T> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotSame<T>(TestExpression<T> notExpected, TestExpression<T> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreNotSame(TestExpression<object> notExpected, TestExpression<object> actual)
            {
                throw new NotImplementedException();
            }

            public void AreNotSame<T>(TestExpression<object> notExpected, TestExpression<object> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotSame<T>(TestExpression<object> notExpected, TestExpression<object> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region Fail Overloads
            public void Fail()
            {
                throw new NotImplementedException();
            }

            public void Fail(string message)
            {
                throw new NotImplementedException();
            }

            public void Fail(string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region Inconclusive Overloads
            public void Inconclusive()
            {
                throw new NotImplementedException();
            }

            public void Inconclusive(string message)
            {
                throw new NotImplementedException();
            }

            public void Inconclusive(string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsTrue Overloads
            public void IsTrue(TestExpression<bool> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsTrue(TestExpression<bool> assertion, string message)
            {
                throw new NotImplementedException();
            }

            public void IsTrue(TestExpression<bool> assertion, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsFalse Overloads
            public void IsFalse(TestExpression<bool> assertion)
            {
                throw new NotImplementedException();
            }

            public void IsFalse(TestExpression<bool> assertion, string message)
            {
                throw new NotImplementedException();
            }

            public void IsFalse(TestExpression<bool> assertion, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsInstanceOfType Overloads
            public void IsInstanceOfType(TestExpression<object> value, TestExpression<Type> expectedType)
            {
                throw new NotImplementedException();
            }

            public void IsInstanceOfType(TestExpression<object> value, TestExpression<Type> expectedType, string message)
            {
                throw new NotImplementedException();
            }

            public void IsInstanceOfType(TestExpression<object> value, TestExpression<Type> expectedType, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsNotInstanceOfType Overloads
            public void IsNotInstanceOfType(TestExpression<object> value, TestExpression<Type> notExpectedType)
            {
                throw new NotImplementedException();
            }

            public void IsNotInstanceOfType(TestExpression<object> value, TestExpression<Type> notExpectedType, string message)
            {
                throw new NotImplementedException();
            }

            public void IsNotInstanceOfType(TestExpression<object> value, TestExpression<Type> notExpectedType, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsNull Overloads
            public void IsNull<T>(TestExpression<T> value)
            {
                throw new NotImplementedException();
            }

            public void IsNull<T>(TestExpression<T> value, string message)
            {
                throw new NotImplementedException();
            }

            public void IsNull<T>(TestExpression<T> value, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsNotNull Overloads
            public void IsNotNull<T>(TestExpression<T> value)
            {
                throw new NotImplementedException();
            }

            public void IsNotNull<T>(TestExpression<T> value, string message)
            {
                throw new NotImplementedException();
            }

            public void IsNotNull<T>(TestExpression<T> value, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region ThrowsException Overloads
            public void ThrowsException<TException>(TestExpression<Action> action)
            {
                throw new NotImplementedException();
            }

            public void ThrowsException<TException>(TestExpression<Action> action, string message)
            {
                throw new NotImplementedException();
            }

            public void ThrowsException<TException>(TestExpression<Action> action, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void ThrowsException<TException>(TestExpression<Func<object>> action)
            {
                throw new NotImplementedException();
            }

            public void ThrowsException<TException>(TestExpression<Func<object>> action, string message)
            {
                throw new NotImplementedException();
            }

            public void ThrowsException<TException>(TestExpression<Func<object>> action, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion
        }

        // Based on Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert
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

        public class ConsoleAssertObject
        {
            public void WritesOut(TestExpression<Action> action, TestExpression<string> writeout)
            {
                throw new NotImplementedException();
            }

            public void WritesErr(TestExpression<Action> action, TestExpression<string> writeout)
            {
                throw new NotImplementedException();
            }
        }

        public void Execute()
        {

        }
    }
}
