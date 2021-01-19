using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools;
using TestTools.Integrated;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        TestFactory factory = new TestFactory("Lecture_2");

        /* Exercise 3A */
        [TestMethod("a. ImmutableNumber.Value is public readonly int property"), TestCategory("Exercise 3A")]
        public void ValueIsPublicReadonlyProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<ImmutableNumber, int>(
                n => n.Value,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        /* Exercise 3B */
        [TestMethod("a. ImmutableNumber.Number constructor takes int as argument"), TestCategory("Exercise 3B")]
        public void ImmutableNumberConstructorTakesIntAsArgument() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertConstructor<int, ImmutableNumber>(
                i => new ImmutableNumber(i),
                new ConstructorRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("b. ImmutableNumber constructor with int as argument sets value property"), TestCategory("Exercise 3B")]
        public void ImmutableNumberConstructorWithIntAsArgumentSetsValueProperty()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<ImmutableNumber> number = test.Create<ImmutableNumber>("immutableNumber");

            number.Arrange(() => new ImmutableNumber(2));
            number.Assert.IsTrue(n => n.Value == 2);

            test.Execute();
        }

        /* Exercise 2C*/
        [TestMethod("a. ImmutableNumber.Add takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void AddTakesImmutableNumberAsArgumentAndReturnsImmutableNumber()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertMethod<ImmutableNumber, ImmutableNumber, ImmutableNumber>(
                (n1, n2) => n1.Add(n2),
                new MethodRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("b. ImmutableNumber.Add performs 1 + 2 = 3"), TestCategory("Exercise 3C")]
        public void AddProducesExpectedResult() {
            UnitTest test = factory.CreateTest();
            UnitTestObject<ImmutableNumber> number1 = test.Create<ImmutableNumber>("immutableNumber1");
            UnitTestObject<ImmutableNumber> number2 = test.Create<ImmutableNumber>("immutableNumber2");
            UnitTestObject<ImmutableNumber> number3 = test.Create<ImmutableNumber>("immutableNumber2");

            number1.Arrange(() => new ImmutableNumber(1));
            number2.Arrange(() => new ImmutableNumber(2));
            number3.WithParameters(number1, number2).Arrange((n1, n2) => n1.Add(n2));
            number3.Assert.IsTrue(n => n.Value == 3);

            test.Execute();
        }

        [TestMethod("c. ImmutableNumber.Subtract takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void SubtractTakesImmutableNumberAsArgumentAndReturnsImmutableNumber() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertMethod<ImmutableNumber, ImmutableNumber, ImmutableNumber>(
                (n1, n2) => n1.Subtract(n2),
                new MethodRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("d. ImmutableNumber.Subtract performs 8 - 3 = 5"), TestCategory("Exercise 3C")]
        public void SubstractProducesExpectedResult() {
            UnitTest test = factory.CreateTest();
            UnitTestObject<ImmutableNumber> number1 = test.Create<ImmutableNumber>("immutableNumber1");
            UnitTestObject<ImmutableNumber> number2 = test.Create<ImmutableNumber>("immutableNumber2");
            UnitTestObject<ImmutableNumber> number3 = test.Create<ImmutableNumber>("immutableNumber2");

            number1.Arrange(() => new ImmutableNumber(8));
            number2.Arrange(() => new ImmutableNumber(5));
            number3.WithParameters(number1, number2).Arrange((n1, n2) => n1.Subtract(n2)); 
            number3.Assert.IsTrue(n => n.Value == 3);
            test.Execute();
        }

        [TestMethod("e. ImmutableNumber.Multiply takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void MultiplyTakesImmutableAsArgumentAndReturnsNothing()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertMethod<ImmutableNumber, ImmutableNumber, ImmutableNumber>(
                (n1, n2) => n1.Multiply(n2),
                new MethodRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("f. ImmutableNumber.Multiply performs 2 * 3 = 6"), TestCategory("Exercise 3C")]
        public void MultiplyProducesExpectedResult() {
            UnitTest test = factory.CreateTest();
            UnitTestObject<ImmutableNumber> number1 = test.Create<ImmutableNumber>("immutableNumber1");
            UnitTestObject<ImmutableNumber> number2 = test.Create<ImmutableNumber>("immutableNumber2");
            UnitTestObject<ImmutableNumber> number3 = test.Create<ImmutableNumber>("immutableNumber2");

            number1.Arrange(() => new ImmutableNumber(2));
            number2.Arrange(() => new ImmutableNumber(3));
            number3.WithParameters(number1, number2).Arrange((n1, n2) => n1.Multiply(n2));
            number3.Assert.IsTrue(n => n.Value == 6);

            test.Execute();
        }
    }
}
