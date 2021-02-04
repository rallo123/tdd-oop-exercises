using System;
using System.Collections;
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
            Arrange(variable, TestExpression.Expr(() => default(T)));
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

            public void AreEqual(TestExpression<double> expected, TestExpression<double> actual, double delta)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<double> expected, TestExpression<double> actual, double delta, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<double> expected, TestExpression<double> actual, double delta, string message, params object[] parameters)
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
            #region AllItemsAreInstancesOfType Overloads
            public void AllItemsAreInstancesOfType(TestExpression<ICollection> collection, TestExpression<Type> expectedType)
            {
                throw new NotImplementedException();
            }

            public void AllItemsAreInstancesOfType(TestExpression<ICollection> collection, TestExpression<Type> expectedType, string message)
            {
                throw new NotImplementedException();
            }

            public void AllItemsAreInstancesOfType(TestExpression<ICollection> collection, TestExpression<Type> expectedType, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AllItemsAreNotNull Overloads
            public void AllItemsAreNotNull(TestExpression<ICollection> collection)
            {
                throw new NotImplementedException();
            }

            public void AllItemsAreNotNull(TestExpression<ICollection> collection, string message)
            {
                throw new NotImplementedException();
            }

            public void AllItemsAreNotNull(TestExpression<ICollection> collection, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AllItemsAreUnique Overloads
            public void AllItemsAreUnique(TestExpression<ICollection> collection)
            {
                throw new NotImplementedException();
            }

            public void AllItemsAreUnique(TestExpression<ICollection> collection, string message)
            {
                throw new NotImplementedException();
            }

            public void AllItemsAreUnique(TestExpression<ICollection> collection, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AreEqual Overloads
            public void AreEqual(TestExpression<ICollection> expected, TestExpression<ICollection> actual)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<ICollection> expected, TestExpression<ICollection> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<ICollection> expected, TestExpression<ICollection> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<ICollection> expected, TestExpression<ICollection> actual, IComparer comparer)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<ICollection> expected, TestExpression<ICollection> actual, IComparer comparer, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEqual(TestExpression<ICollection> expected, TestExpression<ICollection> actual, IComparer comparer, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AreNotEqual Overloads
            public void AreNotEqual(TestExpression<ICollection> notExpected, TestExpression<ICollection> actual)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<ICollection> notExpected, TestExpression<ICollection> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<ICollection> notExpected, TestExpression<ICollection> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<ICollection> notExpected, TestExpression<ICollection> actual, IComparer comparer)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<ICollection> notExpected, TestExpression<ICollection> actual, IComparer comparer, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEqual(TestExpression<ICollection> notExpected, TestExpression<ICollection> actual, IComparer comparer, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AreEquivalent Overloads
            public void AreEquivalent(TestExpression<ICollection> expected, TestExpression<ICollection> actual)
            {
                throw new NotImplementedException();
            }

            public void AreEquivalent(TestExpression<ICollection> expected, TestExpression<ICollection> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreEquivalent(TestExpression<ICollection> expected, TestExpression<ICollection> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region AreNotEquivalent Overloads
            public void AreNotEquivalent(TestExpression<ICollection> expected, TestExpression<ICollection> actual)
            {
                throw new NotImplementedException();
            }

            public void AreNotEquivalent(TestExpression<ICollection> expected, TestExpression<ICollection> actual, string message)
            {
                throw new NotImplementedException();
            }

            public void AreNotEquivalent(TestExpression<ICollection> expected, TestExpression<ICollection> actual, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region Contains Overloads
            public void Contains(TestExpression<ICollection> collection, TestExpression<object> element)
            {
                throw new NotImplementedException();
            }

            public void Contains(TestExpression<ICollection> collection, TestExpression<object> element, string message)
            {
                throw new NotImplementedException();
            }

            public void Contains(TestExpression<ICollection> collection, TestExpression<object> element, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region DoesNotContain Overloads
            public void DoesNotContain(TestExpression<ICollection> collection, TestExpression<object> element)
            {
                throw new NotImplementedException();
            }

            public void DoesNotContain(TestExpression<ICollection> collection, TestExpression<object> element, string message)
            {
                throw new NotImplementedException();
            }

            public void DoesNotContain(TestExpression<ICollection> collection, TestExpression<object> element, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsSubsetOf Overloads
            public void IsSubsetOf(TestExpression<ICollection> subset, TestExpression<ICollection> superset) 
            { 
                throw new NotImplementedException();
            }
            public void IsSubsetOf(TestExpression<ICollection> subset, TestExpression<ICollection> superset, string message)
            {
                throw new NotImplementedException();
            }

            public void IsSubsetOf(TestExpression<ICollection> subset, TestExpression<ICollection> superset, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region IsNotSubsetOf Overloads
            public void IsNotSubsetOf(TestExpression<ICollection> subset, TestExpression<ICollection> superset)
            {
                throw new NotImplementedException();
            }
            public void IsNotSubsetOf(TestExpression<ICollection> subset, TestExpression<ICollection> superset, string message)
            {
                throw new NotImplementedException();
            }
            public void IsNotSubsetOf(TestExpression<ICollection> subset, TestExpression<ICollection> superset, string message, params object[] parameters)
            {
                throw new NotImplementedException();
            }
            #endregion
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
