using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools;
using TestTools.UnitTests;
using TestTools.StructureTests;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_2_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        #region Exercise 3A
        [TestMethod("a. ImmutableNumber.Value is public readonly int property"), TestCategory("Exercise 3A")]
        public void ValueIsPublicReadonlyProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<ImmutableNumber, int>(n => n.Value, IsPublicReadonlyProperty);
            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("a. ImmutableNumber.Number constructor takes int as argument"), TestCategory("Exercise 3B")]
        public void ImmutableNumberConstructorTakesIntAsArgument() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<int, ImmutableNumber>(i => new ImmutableNumber(i), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("b. ImmutableNumber constructor with int as argument sets value property"), TestCategory("Exercise 3B")]
        public void ImmutableNumberConstructorWithIntAsArgumentSetsValueProperty()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ImmutableNumber> number = test.CreateVariable<ImmutableNumber>(nameof(number));

            test.Arrange(number, Expr(() => new ImmutableNumber(2)));
            test.Assert.AreEqual(Expr(number, n => n.Value), Const(2));

            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("a. ImmutableNumber.Add takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void AddTakesImmutableNumberAsArgumentAndReturnsImmutableNumber()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ImmutableNumber, ImmutableNumber, ImmutableNumber>((n1, n2) => n1.Add(n2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. ImmutableNumber.Add performs 1 + 2 = 3"), TestCategory("Exercise 3C")]
        public void AddProducesExpectedResult() {
            UnitTest test = Factory.CreateTest();
            TestVariable<ImmutableNumber> number1 = test.CreateVariable<ImmutableNumber>(nameof(number1));
            TestVariable<ImmutableNumber> number2 = test.CreateVariable<ImmutableNumber>(nameof(number2));
            TestVariable<ImmutableNumber> number3 = test.CreateVariable<ImmutableNumber>(nameof(number3));

            test.Arrange(number1, Expr(() => new ImmutableNumber(1)));
            test.Arrange(number2, Expr(() => new ImmutableNumber(2)));
            test.Arrange(number3, Expr(number1, number2, (n1, n2) => n1.Add(n2)));
            test.Assert.AreEqual(Expr(number3, n => n.Value), Const(3));
            
            test.Execute();
        }

        [TestMethod("c. ImmutableNumber.Subtract takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void SubtractTakesImmutableNumberAsArgumentAndReturnsImmutableNumber() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ImmutableNumber, ImmutableNumber, ImmutableNumber>((n1, n2) => n1.Subtract(n2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("d. ImmutableNumber.Subtract performs 8 - 3 = 5"), TestCategory("Exercise 3C")]
        public void SubstractProducesExpectedResult() {
            UnitTest test = Factory.CreateTest();
            TestVariable<ImmutableNumber> number1 = test.CreateVariable<ImmutableNumber>(nameof(number1));
            TestVariable<ImmutableNumber> number2 = test.CreateVariable<ImmutableNumber>(nameof(number2));
            TestVariable<ImmutableNumber> number3 = test.CreateVariable<ImmutableNumber>(nameof(number3));

            test.Arrange(number1, Expr(() => new ImmutableNumber(8)));
            test.Arrange(number2, Expr(() => new ImmutableNumber(3)));
            test.Arrange(number3, Expr(number1, number2, (n1, n2) => n1.Subtract(n2)));
            test.Assert.AreEqual(Expr(number3, n => n.Value), Const(5));

            test.Execute();
        }

        [TestMethod("e. ImmutableNumber.Multiply takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void MultiplyTakesImmutableAsArgumentAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ImmutableNumber, ImmutableNumber, ImmutableNumber>((n1, n2) => n1.Multiply(n2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("f. ImmutableNumber.Multiply performs 2 * 3 = 6"), TestCategory("Exercise 3C")]
        public void MultiplyProducesExpectedResult() {
            UnitTest test = Factory.CreateTest();
            TestVariable<ImmutableNumber> number1 = test.CreateVariable<ImmutableNumber>(nameof(number1));
            TestVariable<ImmutableNumber> number2 = test.CreateVariable<ImmutableNumber>(nameof(number2));
            TestVariable<ImmutableNumber> number3 = test.CreateVariable<ImmutableNumber>(nameof(number3));

            test.Arrange(number1, Expr(() => new ImmutableNumber(2)));
            test.Arrange(number2, Expr(() => new ImmutableNumber(3)));
            test.Arrange(number3, Expr(number1, number2, (n1, n2) => n1.Add(n2)));
            test.Assert.AreEqual(Expr(number3, n => n.Value), Const(6));

            test.Execute();
        }
        #endregion
    }
}
