using Lecture_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools;
using TestTools.Structure;

namespace Lecture_1_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        private NamespaceDefinition @namespace => new NamespaceDefinition("Lecture_1");

        private ClassDefinition immutableNumber => new ClassDefinition(typeof(ImmutableNumber));
        private PropertyDefinition immutableNumberValue => immutableNumber.Property("Value", typeof(int), new GetMethod(AccessLevel.Public));
        private MethodDefinition immutableNumberAdd => immutableNumber.Method("Add", immutableNumber.Type, new Type[] { immutableNumber.Type });
        private MethodDefinition immutableNumberSubtract => immutableNumber.Method("Subtract", immutableNumber.Type, new Type[] { immutableNumber.Type });
        private MethodDefinition immutableNumberMultiply => immutableNumber.Method("Multiply", immutableNumber.Type, new Type[] { immutableNumber.Type });
        private ImmutableNumber CreateImmutableNumber(int value) => (ImmutableNumber)immutableNumber.Constructor(new Type[] { typeof(int) }).Invoke(new object[] { value });

        private void DoNothing(object par) { }
        private void TestImmutableNumberOperation(Func<ImmutableNumber, ImmutableNumber, ImmutableNumber> operation, int op1, int op2, int expectedResult, string symbol = "?")
        {
            ImmutableNumber n1 = CreateImmutableNumber(op1);
            ImmutableNumber n2 = CreateImmutableNumber(op2);

            int actualResult = (int)immutableNumberValue.Get(operation(n1, n2));

            if (actualResult != expectedResult)
                Assert.Fail($"Produces unexpected result, {op1} {symbol} {op2} = {actualResult}");
        }
        
        public Exercise_3_Tests()
        {
            bool ImmutableNumberEquals(object obj1, object obj2) => immutableNumberValue.Get(obj1).Equals(immutableNumberValue.Get(obj2));
            string ImmutableNumberToString(object obj) => $"immutable number {immutableNumberValue.Get(obj)}";

            ObjectMethodRegistry.RegisterEquals(immutableNumber.Type, ImmutableNumberEquals);
            ObjectMethodRegistry.RegisterToString(immutableNumber.Type, ImmutableNumberToString);
        }

        /* Exercise 3A */
        [TestMethod("Value is public readonly int property"), TestCategory("Exercise 3A")]
        public void ValueIsPublicReadonlyProperty() => DoNothing(immutableNumberValue);

        /* Exercise 3B */
        [TestMethod("a. Number constructor takes int as argument"), TestCategory("Exercise 3B")]
        public void ImmutableNumberConstructorTakesIntAsArgument() => DoNothing(CreateImmutableNumber(0));

        [TestMethod("b. Number constructor with int as argument sets value property"), TestCategory("Exercise 3B")]
        public void ImmutableNumberConstructorWithIntAsArgumentSetsValueProperty()
        {
            ImmutableNumber n = CreateImmutableNumber(2);

            if ((int)immutableNumberValue.Get(n) != 2)
                Assert.Fail("ImmutableNumber constructor ImmutableNumber(int par) does not set value");
        }

        /* Exercise 2C*/
        [TestMethod("a. Add takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void AddTakesImmutableAsArgumentAndReturnsNothing() => DoNothing(immutableNumberAdd);

        [TestMethod("b. Add performs 1 + 2 = 3"), TestCategory("Exercise 3C")]
        public void AddProducesExpectedResult() => TestImmutableNumberOperation((n1, n2) => (ImmutableNumber)immutableNumberAdd.Invoke(n1, new object[] { n2 }), 1, 2, 3, symbol: "+");

        [TestMethod("c. Subtract takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void SubtractTakesImmutableAsArgumentAndReturnsNothing() => DoNothing(immutableNumberSubtract);

        [TestMethod("d. Subtract performs 8 - 3 = 5"), TestCategory("Exercise 3C")]
        public void SubstractProducesExpectedResult() => TestImmutableNumberOperation((n1, n2) => (ImmutableNumber)immutableNumberSubtract.Invoke(n1, new object[] { n2 }), 8, 3, 5, symbol: "-");

        [TestMethod("e. Multiply takes ImmutableNumber as argument and returns ImmutableNumber"), TestCategory("Exercise 3C")]
        public void MultiplyTakesImmutableAsArgumentAndReturnsNothing() => DoNothing(immutableNumberMultiply);

        [TestMethod("f. Multiply performs 2 * 3 = 6"), TestCategory("Exercise 3C")]
        public void MultiplyProducesExpectedResult() => TestImmutableNumberOperation((n1, n2) => (ImmutableNumber)immutableNumberMultiply.Invoke(n1, new object[] { n2 }), 2, 3, 6, symbol: "*");
    }
}
