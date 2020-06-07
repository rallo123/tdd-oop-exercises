using Lecture_1;
using Lecture_1_Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static Lecture_1_Tests.Exercise_3_Helpers;
using static Lecture_1_Tests.Exercise_3_Tests;

namespace Lecture_1_Tests
{
    public static class Exercise_3_Helpers
    {
        public static ImmutableNumber CreateImmutableNumber(int value)
        {
            TestHelper.TestConstructorExists(typeof(Number), new Type[] { typeof(int) });

            return (ImmutableNumber)MemberHelper.CreateInstance(typeof(ImmutableNumber), new object[] { value });
        }
    }

    public class Exercise_3_Tests
    {
        public static void TestImmutableNumberMemberIsProperty(string name)
        {
            TestHelper.TestMemberIsProperty(typeof(ImmutableNumber), name);
        }

        public static void TestImmutableNumberMemberIsPropertyWithPublicGet(string name)
        {
            TestHelper.TestMemberIsPropertyWithGetMethod(typeof(ImmutableNumber), name, isPublic: true);
        }

        public static void TestImmutableNumberMemberIsOfType(string name, Type type)
        {
            TestHelper.TestMemberIsFieldOrPropertyOfType(typeof(ImmutableNumber), name, type);
        }

        public static void TestNumberOperation(Func<ImmutableNumber, ImmutableNumber, ImmutableNumber> operation, int op1, int op2, int expectedResult, string symbol = "?")
        {
            TestImmutableNumberMemberIsPropertyWithPublicGet("Value");

            ImmutableNumber number1 = CreateImmutableNumber(op1);
            ImmutableNumber number2 = CreateImmutableNumber(op2);
            
            int actualResult = (int)MemberHelper.GetValue(operation(number1, number2), "Value");

            Assert.IsTrue(
                expectedResult == actualResult,
                $"Produces unexpected result ({op1} {symbol} {op2} = {actualResult})"
            );
        }
    }

    [TestClass]
    public class Exercise_3A_Tests
    {
        [TestMethod]
        public void ValueIsProperty() => TestImmutableNumberMemberIsProperty("Value");
        [TestMethod]
        public void ValueIsReadOnlyProperty() => TestImmutableNumberMemberIsPropertyWithPublicGet("Value");
        [TestMethod]
        public void ValueIsOfTypeInt() => TestImmutableNumberMemberIsOfType("Value", typeof(int));
    }

    [TestClass]
    public class Exercise_3B_Tests
    {
        [TestMethod]
        public void OriginalNumberConstructorTakesValueAsArgument() => TestHelper.TestConstructorExists(typeof(ImmutableNumber), new Type[] { typeof(int) });

        [TestMethod]
        public void OriginalNumberConstructorSetsValue()
        {
            Exercise_3A_Tests exercise_3A_Tests = new Exercise_3A_Tests();

            OriginalNumberConstructorTakesValueAsArgument();
            exercise_3A_Tests.ValueIsReadOnlyProperty();
            exercise_3A_Tests.ValueIsOfTypeInt();

            int expected = 936;
            ImmutableNumber number = CreateImmutableNumber(expected);
            int actual = (int)MemberHelper.GetValue(number, "Value");

            Assert.IsTrue(
                expected == actual,
                "constructor argument does not match Value"
            );
        }
    }

    [TestClass]
    public class Exercise_3C_Tests
    {
        [TestMethod]
        public void AddModifiesExistingValue()
        {
            TestHelper.TestMemberIsMethod(typeof(ImmutableNumber), "Add");
            TestHelper.TestMemberIsMethodOfSignature(typeof(ImmutableNumber), "Add", typeof(ImmutableNumber), new Type[] { typeof(ImmutableNumber) });

            static ImmutableNumber operation(ImmutableNumber sum, ImmutableNumber op) => (ImmutableNumber) MemberHelper.CallMethod(sum, "Add", new object[] { op });
            TestNumberOperation(operation, 3, 2, 5, "+");
        }

        [TestMethod]
        public void SubtractModifiesExistingValue()
        {
            TestHelper.TestMemberIsMethod(typeof(ImmutableNumber), "Subtract");
            TestHelper.TestMemberIsMethodOfSignature(typeof(ImmutableNumber), "Subtract", typeof(ImmutableNumber), new Type[] { typeof(ImmutableNumber) });

            static ImmutableNumber operation(ImmutableNumber sum, ImmutableNumber op) => (ImmutableNumber) MemberHelper.CallMethod(sum, "Subtract", new object[] { op });
            TestNumberOperation(operation, 3, 2, 1, "-");
        }

        [TestMethod]
        public void MultiplyModifiesExistingValue()
        {
            TestHelper.TestMemberIsMethod(typeof(ImmutableNumber), "Multiply");
            TestHelper.TestMemberIsMethodOfSignature(typeof(ImmutableNumber), "Multiply", typeof(ImmutableNumber), new Type[] { typeof(ImmutableNumber) });

            static ImmutableNumber operation(ImmutableNumber sum, ImmutableNumber op) => (ImmutableNumber) MemberHelper.CallMethod(sum, "Multiply", new object[] { op });
            TestNumberOperation(operation, 3, 2, 6, "*");
        }
    }
}
