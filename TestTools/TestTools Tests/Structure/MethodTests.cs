using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace;
using System;
using TestTools.Structure;


namespace TestTools_Tests.Structure
{
    [TestClass]
    public class MethodTests
    {
        private FuncMethodElement GetMethodDefinition() => new FuncMethodElement(typeof(Class).GetMethod("PublicMethodWithParameters"));

        [TestMethod]
        public void ReturnsValue()
        {
            Class @class = new Class(3);
            Assert.AreEqual(
                0,
                GetMethodDefinition().Invoke(@class, new object[] { 0 }),
                "Method does not return correct value"
            );
        }
    }
}
