using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.StructureTests;
using TestTools.UnitTests;
using static Lecture_2_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
        #region Exercise 2A
        [TestMethod("Number.Value is public readonly int property"), TestCategory("Exercise 2A")]
        public void ValueIsPublicReadonlyIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Number, int>(n => n.Value, IsPublicReadonlyProperty);
            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("a. Number constructor takes int as argument"), TestCategory("Exercise 2B")]
        public void NumberConstructorTakesIntAsArgument() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<int, Number>(i => new Number(i), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("b. Number constructor with int as argument sets value property"), TestCategory("Exercise 2B")]
        public void NumberConstructorWithIntAsArgumentSetsValueProperty()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number = test.CreateVariable<Number>(nameof(number));

            test.Arrange(number, Expr(() => new Number(2)));
            test.Assert.AreEqual(Expr(number, n => n.Value), Const(2));

            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("a. Number.Add takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void AddTakesNumberAsArgumentsAndReturnsNothing() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Number, Number>((n1, n2) => n1.Add(n2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. Number.Add performs 1 + 2 = 3"), TestCategory("Exercise 2C")]
        public void AddProducesExpectedResult() {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number1 = test.CreateVariable<Number>(nameof(number1));
            TestVariable<Number> number2 = test.CreateVariable<Number>(nameof(number2));

            test.Arrange(number1, Expr(() => new Number(1)));
            test.Arrange(number2, Expr(() => new Number(2)));
            test.Act(Expr(number1, number2, (n1, n2) => n1.Add(n2)));
            test.Assert.AreEqual(Expr(number1, n => n.Value), Const(3));

            test.Execute();
        }

        [TestMethod("c. Number.Subtract takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void SubtractTakesNumberAsArgumentAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Number, Number>((n1, n2) => n1.Subtract(n2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("d. Number.Subtract performs 8 - 3 = 5"), TestCategory("Exercise 2C")]
        public void SubtractProducesExpectedResult() {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number1 = test.CreateVariable<Number>(nameof(number1));
            TestVariable<Number> number2 = test.CreateVariable<Number>(nameof(number2));

            test.Arrange(number1, Expr(() => new Number(8)));
            test.Arrange(number2, Expr(() => new Number(3)));
            test.Act(Expr(number1, number2, (n1, n2) => n1.Subtract(n2)));
            test.Assert.AreEqual(Expr(number1, n => n.Value), Const(5));

            test.Execute();
        }

        [TestMethod("e. Number.Multiply takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void MultiplyTakesNumberAsArgumentAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Number, Number>((n1, n2) => n1.Multiply(n2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("f. Number.Multiply performs 2 * 3 = 6"), TestCategory("Exercise 2C")]
        public void MultiplyProducesExpectedResult()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Number> number1 = test.CreateVariable<Number>(nameof(number1));
            TestVariable<Number> number2 = test.CreateVariable<Number>(nameof(number2));

            test.Arrange(number1, Expr(() => new Number(2)));
            test.Arrange(number2, Expr(() => new Number(3)));
            test.Act(Expr(number1, number2, (n1, n2) => n1.Multiply(n2)));
            test.Assert.AreEqual(Expr(number1, n => n.Value), Const(6));

            test.Execute();
        }
        #endregion
    }
}
