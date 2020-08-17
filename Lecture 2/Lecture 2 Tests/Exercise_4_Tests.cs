using Lecture_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Structure.Generic;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
#pragma warning disable IDE1006 // Naming Styles
        private ClassElement<Number> number => new ClassElement<Number>();
        private FuncMethodElement<Number, object, bool> numberEquals => number.FuncMethod<object, bool>("Equals");
        private FuncMethodElement<Number, int> numberGetHashCode => number.FuncMethod<int>("GetHashCode");
        private Number CreateNumber(int value) => number.Constructor<int>().Invoke(value);
#pragma warning restore IDE1006 // Naming Styles

        /* Exercise 4B */
        [TestMethod("a. Number.Equals does not equate 4 and 5"), TestCategory("Exercise 4B")]
        public void EqualsDoesNotEquateFourAndFive()
        {
            Number four = CreateNumber(4);
            Number five = CreateNumber(5);

            bool isEquated = numberEquals.Invoke(four, five);

            if (isEquated)
                throw new AssertFailedException("Number.Equals(Number n) equates 4 and 5");
        }

        [TestMethod("b. Number.Equals equates 5 and 5"), TestCategory("Exercise 4B")]
        public void EqualsEquatesFiveAndFive()
        {
            Number five1 = CreateNumber(5);
            Number five2 = CreateNumber(5);

            bool isEquated = numberEquals.Invoke(five1, five2);

            if (!isEquated)
                throw new AssertFailedException("Number.Equals(Number n) does not equate 5 and 5");
        }

        /* Exercise 4C */
        [TestMethod("a. Number.GetHashCode does not equate 4 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeDoesNotEquateFourAndFive()
        {
            Number four = CreateNumber(4);
            Number five = CreateNumber(5);

            bool isEquated = numberGetHashCode.Invoke(four) == numberGetHashCode.Invoke(five);

            if (isEquated)
                throw new AssertFailedException("Number.GetHashCode(Number n) equates 4 and 5");
        }

        [TestMethod("b. Number.GetHashCode equates 5 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeEquatesFiveAndFice()
        {
            Number five1 = CreateNumber(5);
            Number five2 = CreateNumber(5);

            bool isEquated = numberGetHashCode.Invoke(five1) == numberGetHashCode.Invoke(five2);

            if (!isEquated)
                throw new AssertFailedException("Number.GetHashCode(Number n) does not equate 5 and 5");
        }
    }
}
