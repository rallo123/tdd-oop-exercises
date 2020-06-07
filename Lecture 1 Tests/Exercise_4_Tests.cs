using Lecture_1;
using Lecture_1_Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static Lecture_1_Tests.Exercise_2_Helpers;
using static Lecture_1_Tests.Exercise_3_Helpers;
using static Lecture_1_Tests.Exercise_4_Tests;

namespace Lecture_1_Tests
{
    public static class Exercise_4_Tests
    {
        public static void TestNumberEquates(bool expectedResult, int n1, int n2)
        {
            TestHelper.TestMemberIsMethodOfSignature(typeof(Number), "Equals", typeof(bool), new Type[] { typeof(object) });

            Number number1 = CreateNumber(n1);
            Number number2 = CreateNumber(n2);

            bool actualResult = (bool) MemberHelper.CallMethod(number1, "Equals", new object[] { number2 });

            Assert.IsTrue(
                expectedResult == actualResult,
                expectedResult ? $"Number does not equate {n1} and {n2}" : $"Number equates {n1} and {n2}"
            );
        }

        public static void TestImmutableNumberEquates(bool expectedResult, int n1, int n2)
        {
            TestHelper.TestMemberIsMethodOfSignature(typeof(ImmutableNumber), "Equals", typeof(bool), new Type[] { typeof(object) });

            ImmutableNumber number1 = CreateImmutableNumber(n1);
            ImmutableNumber number2 = CreateImmutableNumber(n2);

            bool actualResult = (bool)MemberHelper.CallMethod(number1, "Equals", new object[] { number2 });

            Assert.IsTrue(
                expectedResult == actualResult,
                expectedResult ? $"ImmutableNumber does not equate {n1} and {n2}" : $"ImmutableNumber equates {n1} and {n2}"
            );
        }
    }

    [TestClass]
    public class Exercise_4B_Tests
    {
        [TestMethod]
        public void NumberDoesNotEquateFourAndFive() => TestNumberEquates(false, 4, 5);

        [TestMethod]
        public void NumberEquatesFiveAndFive() => TestNumberEquates(true, 5, 5);
    }

    [TestClass]
    public class Exercise_4C_Tests
    {
        [TestMethod]
        public void ImmutableNumberDoesNotEquateFourAndFive() => TestImmutableNumberEquates(false, 4, 5);

        [TestMethod]
        public void ImmutableNumberEquatesFiveAndFive() => TestImmutableNumberEquates(true, 5, 5);
    }
}
