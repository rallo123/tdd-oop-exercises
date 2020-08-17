using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace;
using TestTools.Structure;
using static TestTools_Tests.TestHelper;

namespace TestTools_Tests.Structure
{
    [TestClass]
    public class PropertyTests
    {
        private static PropertyElement GetPropertyDefinition() => new PropertyElement(typeof(Class).GetProperty("PublicIntProperty"));

        [TestMethod]
        public void GetsValue()
        {
            Class @class = new Class(3);

            Assert.IsTrue(
                (int)GetPropertyDefinition().Get(@class) == @class.PublicIntProperty
            );
        }

        [TestMethod]
        public void SetsValue()
        {
            Class @class = new Class(3);
            @class.PublicIntProperty = 5;

            Assert.IsTrue(
                (int)GetPropertyDefinition().Get(@class) == @class.PublicIntProperty
            );
        }

        [TestMethod]
        public void ThrowsOnInvalidAssignment()
        {
            Class @class = new Class(0);

            AssertThrowsExactException<AssertFailedException>(
                "null is not of type int",
                () => GetPropertyDefinition().Set(@class, null)
            );
        }
    }
}
