using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Structure.Generic;
using TestTools.Integrated;
using static Lecture_2_Tests.TestHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        /* Exercise 4B */
        [TestMethod("a. Number.Equals does not equate 4 and 5"), TestCategory("Exercise 4B")]
        public void EqualsDoesNotEquateFourAndFive()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number1 = test.Create<Number>();
            UnitTestObject<Number> number2 = test.Create<Number>();

            number1.Arrange(() => new Number(4));
            number2.Arrange(() => new Number(5));
            number1.WithParameters(number2).Assert.IsFalse((n1, n2) => n1.Equals(n2));
        }

        [TestMethod("b. Number.Equals equates 5 and 5"), TestCategory("Exercise 4B")]
        public void EqualsEquatesFiveAndFive()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number1 = test.Create<Number>();
            UnitTestObject<Number> number2 = test.Create<Number>();

            number1.Arrange(() => new Number(5));
            number2.Arrange(() => new Number(5));
            number1.WithParameters(number2).Assert.IsTrue((n1, n2) => n1.Equals(n2));
        }

        /* Exercise 4C */
        [TestMethod("a. Number.GetHashCode does not equate 4 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeDoesNotEquateFourAndFive()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number1 = test.Create<Number>();
            UnitTestObject<Number> number2 = test.Create<Number>();

            number1.Arrange(() => new Number(4));
            number2.Arrange(() => new Number(5));
            number1.WithParameters(number2).Assert.IsFalse((n1, n2) => n1.GetHashCode() == n2.GetHashCode());
        }

        [TestMethod("b. Number.GetHashCode equates 5 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeEquatesFiveAndFice()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Number> number1 = test.Create<Number>();
            UnitTestObject<Number> number2 = test.Create<Number>();

            number1.Arrange(() => new Number(5));
            number2.Arrange(() => new Number(5));
            number1.WithParameters(number2).Assert.IsTrue((n1, n2) => n1.GetHashCode() == n2.GetHashCode());
        }
    }
}
