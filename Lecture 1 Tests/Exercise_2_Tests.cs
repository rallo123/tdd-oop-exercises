using Lecture_1;
using Lecture_1_Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Lecture_1_Tests.Exercise_2_Helpers;
using static Lecture_1_Tests.Exercise_2_Tests;

namespace Lecture_1_Tests
{
    public static class Exercise_2_Helpers
    {
        public static Number CreateNumber(int value)
        {
            TestHelper.TestConstructorExists(typeof(Number), new Type[] { typeof(int) });
            
            return (Number) MemberHelper.CreateInstance(typeof(Number), new object[] { value });
        }
    }

    public static class Exercise_2_Tests
    {
        public static void TestNumberMemberIsProperty(string name)
        {
            TestHelper.TestMemberIsProperty(typeof(Number), name);
        }

        public static void TestNumberMemberIsPropertyWithPublicGetAndPrivateSetMethods(string name)
        {
            TestHelper.TestMemberIsPropertyWithGetMethod(typeof(Number), name, isPublic: true);
            TestHelper.TestMemberIsPropertyWithSetMethod(typeof(Number), name, isPrivate: true);
        }

        public static void TestNumberMemberIsOfType(string name, Type type)
        {
            TestHelper.TestMemberIsFieldOrPropertyOfType(typeof(Number), name, type);
        }

        public static void TestNumberOperation(Action<Number, Number> operation, int op1, int op2, int expectedResult, string symbol = "?")
        {
            TestNumberMemberIsPropertyWithPublicGetAndPrivateSetMethods("Value");

            Number number1 = CreateNumber(op1);
            Number number2 = CreateNumber(op2);

            operation(number1, number2);

            int actualResult = (int) MemberHelper.GetValue(number1, "Value");

            Assert.IsTrue(
                expectedResult == actualResult,
                $"Produces unexpected result ({op1} {symbol} {op2} = {actualResult})"
            );
        }
    }

    [TestClass]
    public class Exercise_2A_Tests
    {
        [TestMethod]
        public void ValueIsProperty() => TestNumberMemberIsProperty("Value");
        [TestMethod]
        public void ValueIsReadOnlyProperty() => TestNumberMemberIsPropertyWithPublicGetAndPrivateSetMethods("Value");
        [TestMethod]
        public void ValueIsOfTypeInt() => TestNumberMemberIsOfType("Value", typeof(int));
    }

    [TestClass]
    public class Exercise_2B_Tests
    {
        [TestMethod]
        public void OriginalNumberConstructorTakesValueAsArgument() => TestHelper.TestConstructorExists(typeof(Number), new Type[] { typeof(int) });

        [TestMethod]
        public void OriginalNumberConstructorSetsValue()
        {
            Exercise_2A_Tests exercise_2A_Tests = new Exercise_2A_Tests();
            
            OriginalNumberConstructorTakesValueAsArgument();
            exercise_2A_Tests.ValueIsReadOnlyProperty();
            exercise_2A_Tests.ValueIsOfTypeInt();

            int expected = 936;
            Number number = CreateNumber(expected);
            int actual = (int) MemberHelper.GetValue(number, "Value");

            Assert.IsTrue(
                expected == actual,
                "constructor argument does not match Value"
            );
        }
    }

    [TestClass]
    public class Exercise_2C_Tests
    {
        [TestMethod]
        public void AddModifiesExistingValue()
        {
            TestHelper.TestMemberIsMethod(typeof(Number), "Add");
            TestHelper.TestMemberIsMethodOfSignature(typeof(Number), "Add", null, new Type[] { typeof(Number) });

            static void operation(Number sum, Number op) => MemberHelper.CallMethod(sum, "Add", new object[] { op });
            TestNumberOperation(operation, 3, 2, 5, "+");
        }

        [TestMethod]
        public void SubtractModifiesExistingValue()
        {
            TestHelper.TestMemberIsMethod(typeof(Number), "Subtract");
            TestHelper.TestMemberIsMethodOfSignature(typeof(Number), "Subtract", null, new Type[] { typeof(Number) });

            static void operation(Number sum, Number op) => MemberHelper.CallMethod(sum, "Subtract", new object[] { op });
            TestNumberOperation(operation, 3, 2, 1, "-");
        }

        [TestMethod]
        public void MultiplyModifiesExistingValue()
        {
            TestHelper.TestMemberIsMethod(typeof(Number), "Multiply");
            TestHelper.TestMemberIsMethodOfSignature(typeof(Number), "Multiply", null, new Type[] { typeof(Number) });

            static void operation(Number sum, Number op) => MemberHelper.CallMethod(sum, "Multiply", new object[] { op });
            TestNumberOperation(operation, 3, 2, 6, "*");
        }
    }
}
