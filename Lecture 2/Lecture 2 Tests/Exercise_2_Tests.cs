using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Integrated;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
        TestFactory factory = new TestFactory("Lecture_2");

        /* Exercise 2A */
        [TestMethod("Number.Value is public readonly int property"), TestCategory("Exercise 2A")]
        public void ValueIsPublicReadonlyIntProperty() => throw new NotImplementedException();

        /* Exercise 2B */
        [TestMethod("a. Number constructor takes int as argument"), TestCategory("Exercise 2B")]
        public void NumberConstructorTakesIntAsArgument() => throw new NotImplementedException();

        [TestMethod("b. Number constructor with int as argument sets value property"), TestCategory("Exercise 2B")]
        public void NumberConstructorWithIntAsArgumentSetsValueProperty()
        {
            Test test = factory.CreateTest();
            TestObject<Number> number = test.Create<Number>("number");

            test.Arrange(number, () => new Number(2));
            test.Assert(number, n => n.Value == 2);

            test.Execute();
        }

        /* Exercise 2C */
        [TestMethod("a. Number.Add takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void AddTakesNumberAsArgumentsAndReturnsNothing() => throw new NotImplementedException();

        [TestMethod("b. Number.Add performs 1 + 2 = 3"), TestCategory("Exercise 2C")]
        public void AddProducesExpectedResult() {
            Test test = factory.CreateTest();
            TestObject<Number> number1 = test.Create<Number>("number1");
            TestObject<Number> number2 = test.Create<Number>("number2");

            test.Arrange(number1, () => new Number(1));
            test.Arrange(number2, () => new Number(2));
            test.Act(number1, number2, (n1, n2) => n1.Add(n2));
            test.Assert(number1, n => n.Value == 3);

            test.Execute();
        }

        [TestMethod("c. Number.Subtract takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void SubtractTakesNumberAsArgumentAndReturnsNothing() => throw new NotImplementedException();

        [TestMethod("d. Number.Subtract performs 8 - 3 = 5"), TestCategory("Exercise 2C")]
        public void SubtractProducesExpectedResult() {
            Test test = factory.CreateTest();
            TestObject<Number> number1 = test.Create<Number>("number1");
            TestObject<Number> number2 = test.Create<Number>("number2");

            test.Arrange(number1, () => new Number(8));
            test.Arrange(number2, () => new Number(3));
            test.Act(number1, number2, (n1, n2) => n1.Subtract(n2));
            test.Assert(number1, n => n.Value == 5);

            test.Execute();
        }

        [TestMethod("e. Number.Multiply takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void MultiplyTakesNumberAsArgumentAndReturnsNothing() => throw new NotImplementedException();

        [TestMethod("f. Number.Multiply performs 2 * 3 = 6"), TestCategory("Exercise 2C")]
        public void MultiplyProducesExpectedResult()
        {
            Test test = factory.CreateTest();
            TestObject<Number> number1 = test.Create<Number>("number1");
            TestObject<Number> number2 = test.Create<Number>("number2");

            test.Arrange(number1, () => new Number(2));
            test.Arrange(number2, () => new Number(3));
            test.Act(number1, number2, (n1, n2) => n1.Multiply(n2));
            test.Assert(number1, n => n.Value == 6);

            test.Execute();
        }
    }
}
