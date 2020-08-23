using Lecture_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
#pragma warning disable IDE1006 // Naming Styles
        private ClassElement<Number> number => new ClassElement<Number>();
        private PropertyElement<Number, int> numberValue => number.Property<int>("Value", get: new AccessorOptions() { IsPublic = true });
        private ActionMethodElement<Number, Number> numberAdd => number.ActionMethod<Number>("Add", new MethodOptions() { IsPublic = true });
        private ActionMethodElement<Number, Number> numberSubtract => number.ActionMethod<Number>("Subtract", new MethodOptions() { IsPublic = true });
        private ActionMethodElement<Number, Number> numberMultiply => number.ActionMethod<Number>("Multiply", new MethodOptions() { IsPublic = true });
        private Number CreateNumber(int value) => number.Constructor<int>().Invoke(value);

        private void DoNothing(object par) { }
        private void TestNumberOperation(Action<Number, Number> operation, int op1, int op2, int expectedResult, string symbol = "?")
        {
            Number n1 = CreateNumber(op1);
            Number n2 = CreateNumber(op2);

            operation(n1, n2);

            int actualResult = numberValue.Get(n1);

            if (actualResult != expectedResult)
                Assert.Fail($"Produces unexpected result, {op1} {symbol} {op2} = {actualResult}");
        }
#pragma warning restore IDE1006 // Naming Styles

        public Exercise_2_Tests()
        {
            bool NumberEquals(object obj1, object obj2) => numberValue.Get(obj1).Equals(numberValue.Get(obj2));
            string NumberToString(object obj) => $"number {numberValue.Get(obj)}";

            ObjectMethodRegistry.RegisterEquals(number.Type, NumberEquals);
            ObjectMethodRegistry.RegisterToString(number.Type, NumberToString);
        }

        /* Exercise 2A */
        [TestMethod("Number.Value is public readonly int property"), TestCategory("Exercise 2A")]
        public void ValueIsPublicReadonlyIntProperty() => DoNothing(numberValue);

        /* Exercise 2B */
        [TestMethod("a. Number constructor takes int as argument"), TestCategory("Exercise 2B")]
        public void NumberConstructorTakesIntAsArgument() => DoNothing(CreateNumber(0));

        [TestMethod("b. Number constructor with int as argument sets value property"), TestCategory("Exercise 2B")]
        public void NumberConstructorWithIntAsArgumentSetsValueProperty()
        {
            Number n = CreateNumber(2);

            if ((int)numberValue.Get(n) != 2)
                Assert.Fail("Number constructor Number(int par) does not set value");
        }

        /* Exercise 2C */
        [TestMethod("a. Number.Add takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void AddTakesNumberAsArgumentsAndReturnsNothing() => DoNothing(numberAdd);

        [TestMethod("b. Number.Add performs 1 + 2 = 3"), TestCategory("Exercise 2C")]
        public void AddProducesExpectedResult() => TestNumberOperation((n1, n2) => numberAdd.Invoke(n1, new object[] { n2 }), 1, 2, 3, symbol: "+");

        [TestMethod("c. Number.Subtract takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void SubtractTakesNumberAsArgumentAndReturnsNothing() => DoNothing(numberSubtract);

        [TestMethod("d. Number.Subtract performs 8 - 3 = 5"), TestCategory("Exercise 2C")]
        public void SubtractProducesExpectedResult() => TestNumberOperation((n1, n2) => numberSubtract.Invoke(n1, new object[] { n2 }), 8, 3, 5, symbol: "-");

        [TestMethod("e. Number.Multiply takes Number as argument and returns nothing"), TestCategory("Exercise 2C")]
        public void MultiplyTakesNumberAsArgumentAndReturnsNothing() => DoNothing(numberMultiply);

        [TestMethod("f. Number.Multiply performs 2 * 3 = 6"), TestCategory("Exercise 2C")]
        public void MultiplyProducesExpectedResult() => TestNumberOperation((n1, n2) => numberMultiply.Invoke(n1, new object[] { n2 }), 2, 3, 6, symbol: "*");
    }
}
