using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace;
using System;
using TestTools.Structure;
using static TestTools_Tests.TestHelper;


namespace TestTools_Tests.Structure
{
    [TestClass]
    public class MethodTests
    {
        private MethodDefinition GetMethodDefinition() => new MethodDefinition(typeof(Class).GetMethod("PublicMethodWithParameters"));

        [TestMethod]
        public void ReturnsValue(){
            Class @class = new Class(3);
            Assert.AreEqual(
                0,
                GetMethodDefinition().Invoke(@class, new object[] { 0 }),
                "Method does not return correct value"
            );
        }

        [TestMethod]
        public void ThrowsOnTooFewArguments()
        {
            Class @class = new Class(3);
            AssertThrowsExactException<ArgumentException>(
                "INTERNAL: Too few arguments",
                () => GetMethodDefinition().Invoke(@class, new object[] {})
            );
        }

        [TestMethod]
        public void ThrowsOnTooManyArguments()
        {
            Class @class = new Class(3);
            AssertThrowsExactException<AssertFailedException>(
                "Too many arguments",
                () => GetMethodDefinition().Invoke(@class, new object[] {0, 0})
            );
        }

        [TestMethod]
        public void ThrowsOnWrongTypeArgument()
        {
            Class @class = new Class(3);
            AssertThrowsExactException<AssertFailedException>(
                "Parameter i argument null is not of type int",
                () => GetMethodDefinition().Invoke(@class, new object[] { null })
            );
        }
    }
}
