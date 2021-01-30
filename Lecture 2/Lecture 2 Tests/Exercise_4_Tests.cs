using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Structure.Generic;
using TestTools.Structure;
using TestTools.Unit;
using static Lecture_2_Tests.TestHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        #region Exercise 4B
        [TestMethod("a. Number.Equals does not equate 4 and 5"), TestCategory("Exercise 4B")]
        public void EqualsDoesNotEquateFourAndFive()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number1 = test.CreateVariable<Number>(nameof(number1));
            TestVariable<Number> number2 = test.CreateVariable<Number>(nameof(number2));

            test.Arrange(number1, Expr(() => new Number(4)));
            test.Arrange(number2, Expr(() => new Number(5)));
            test.Assert.IsFalse(Expr(number1, number2, (n1, n2) => n1.Equals(n2)));

            test.Execute();
        }

        [TestMethod("b. Number.Equals equates 5 and 5"), TestCategory("Exercise 4B")]
        public void EqualsEquatesFiveAndFive()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number1 = test.CreateVariable<Number>(nameof(number1));
            TestVariable<Number> number2 = test.CreateVariable<Number>(nameof(number2));

            test.Arrange(number1, Expr(() => new Number(5)));
            test.Arrange(number2, Expr(() => new Number(5)));
            test.Assert.IsTrue(Expr(number1, number2, (n1, n2) => n1.Equals(n2)));

            test.Execute();
        }
        #endregion

        #region Exercise 4C
        [TestMethod("a. Number.GetHashCode does not equate 4 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeDoesNotEquateFourAndFive()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number1 = test.CreateVariable<Number>(nameof(number1));
            TestVariable<Number> number2 = test.CreateVariable<Number>(nameof(number2));

            test.Arrange(number1, Expr(() => new Number(4)));
            test.Arrange(number2, Expr(() => new Number(5)));
            test.Assert.IsFalse(Expr(number1, number2, (n1, n2) => n1.GetHashCode() == n2.GetHashCode()));

            test.Execute();
        }

        [TestMethod("b. Number.GetHashCode equates 5 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeEquatesFiveAndFice()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number1 = test.CreateVariable<Number>(nameof(number1));
            TestVariable<Number> number2 = test.CreateVariable<Number>(nameof(number2));

            test.Arrange(number1, Expr(() => new Number(5)));
            test.Arrange(number2, Expr(() => new Number(5)));
            test.Assert.IsTrue(Expr(number1, number2, (n1, n2) => n1.GetHashCode() == n2.GetHashCode()));

            test.Execute();
        }
        #endregion
    }
}
