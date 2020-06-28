using Lecture_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Structure;

namespace Lecture_1_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        private NamespaceDefinition @namespace => new NamespaceDefinition("Lecture_1");

        private ClassDefinition number => new ClassDefinition(typeof(Number));
        private MethodDefinition numberEquals => number.Method("Equals", typeof(bool), new Type[] { typeof(object) });
        private MethodDefinition numberGetHashCode => number.Method("GetHashCode", typeof(int));
        private Number CreateNumber(int value) => (Number)number.Constructor(new Type[] { typeof(int) }).Invoke(new object[] { value });

        /* Exercise 4B */
        [TestMethod("a. Equals does not equate 4 and 5"), TestCategory("Exercise 4B")]
        public void EqualsDoesNotEquateFourAndFive()
        {
            Number four = CreateNumber(4);
            Number five = CreateNumber(5);

            bool isEquated = (bool)numberEquals.Invoke(four, new object[] { five });

            if (isEquated)
                Assert.Fail("Equals equates 4 and 5");
        }

        [TestMethod("b. Equals equates 5 and 5"), TestCategory("Exercise 4B")]
        public void EqualsEquatesFiveAndFive()
        {
            Number five1 = CreateNumber(5);
            Number five2 = CreateNumber(5);

            bool isEquated = (bool)numberEquals.Invoke(five1, new object[] { five2 });

            if (!isEquated)
                Assert.Fail("Equals does not equate 5 and 5");
        }

        /* Exercise 4C */
        [TestMethod("a. GetHashCode does not equate 4 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeDoesNotEquateFourAndFive()
        {
            Number four = CreateNumber(4);
            Number five = CreateNumber(5);

            bool isEquated = numberGetHashCode.Invoke(four) == numberGetHashCode.Invoke(five);

            if (isEquated)
                Assert.Fail("Equals equates 4 and 5");
        }

        [TestMethod("b. GetHashCode equates 5 and 5"), TestCategory("Exercise 4C")]
        public void GetHashCodeEquatesFiveAndFice()
        {
            Number five1 = CreateNumber(5);
            Number five2 = CreateNumber(5);

            bool isEquated = (int)numberGetHashCode.Invoke(five1) == (int)numberGetHashCode.Invoke(five2);

            if (!isEquated)
                Assert.Fail("GetHashCode does not equate 5 and 5");
        }
    }
}
