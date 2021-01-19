using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Integrated;
using TestTools.Structure;
using static Lecture_2_Tests.TestHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
        /* Exercise 2A */
        [TestMethod("Number.Value is public readonly int property"), TestCategory("Exercise 2A")]
        public void ValueIsPublicReadonlyIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Number, int>(
                n => n.Value,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        /* Exercise 2B */
        [TestMethod("a. Number constructor takes int as argument"), TestCategory("Exercise 2B")]
        public void NumberConstructorTakesIntAsArgument() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<int, Number>(
                i => new Number(i),
                new ConstructorRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("b. Number constructor with int as argument sets value property"), TestCategory("Exercise 2B")]
        public void NumberConstructorWithIntAsArgumentSetsValueProperty()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number = test.Create<Number>("number");

            number.Arrange(() => new Number(2));
            number.Assert.IsTrue(n => n.Value == 2);

            test.Execute();
        }

        /* Exercise 2C */
        [TestMethod("a. Number.Add takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void AddTakesNumberAsArgumentsAndReturnsNothing() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Number, Number>(
                (n1, n2) => n1.Add(n2),
                new MethodRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("b. Number.Add performs 1 + 2 = 3"), TestCategory("Exercise 2C")]
        public void AddProducesExpectedResult() {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number1 = test.Create<Number>("number1");
            UnitTestObject<Number> number2 = test.Create<Number>("number2");

            number1.Arrange(() => new Number(1));
            number2.Arrange(() => new Number(2));
            number1.WithParameters(number2).Act((n1, n2) => n1.Add(n2));
            number1.Assert.IsTrue(n => n.Value == 3);

            test.Execute();
        }

        [TestMethod("c. Number.Subtract takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void SubtractTakesNumberAsArgumentAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Number, Number>(
                (n1, n2) => n1.Subtract(n2),
                new MethodRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("d. Number.Subtract performs 8 - 3 = 5"), TestCategory("Exercise 2C")]
        public void SubtractProducesExpectedResult() {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number1 = test.Create<Number>("number1");
            UnitTestObject<Number> number2 = test.Create<Number>("number2");

            number1.Arrange(() => new Number(8));
            number2.Arrange(() => new Number(3));
            number1.WithParameters(number2).Act((n1, n2) => n1.Subtract(n2));
            number1.Assert.IsTrue(n => n.Value == 5);

            test.Execute();
        }

        [TestMethod("e. Number.Multiply takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void MultiplyTakesNumberAsArgumentAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Number, Number>(
                (n1, n2) => n1.Multiply(n2),
                new MethodRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("f. Number.Multiply performs 2 * 3 = 6"), TestCategory("Exercise 2C")]
        public void MultiplyProducesExpectedResult()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number1 = test.Create<Number>("number1");
            UnitTestObject<Number> number2 = test.Create<Number>("number2");

            number1.Arrange(() => new Number(2));
            number2.Arrange(() => new Number(3));
            number1.WithParameters(number2).Act((n1, n2) => n1.Multiply(n2));
            number1.Assert.IsTrue(n => n.Value == 6);

            test.Execute();
        }
    }
}
