using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static TestTools_Tests.TestHelper;
using TestTools.Structure;

namespace TestTools_Tests.Structure
{
    [TestClass]
    public class NamespaceTests
    {
        [TestMethod]
        public void ThrowsOnEmptyNamespace()
        {
            AssertThrowsExactException<AssertFailedException>(
                "Namespace EmptyNamespace does not contain any members",
                () => new NamespaceElement("EmptyNamespace")
            );
        }

        [TestMethod]
        public void DetectsInternalClass()
        {
            new NamespaceElement("Namespace").Class("InternalClass");
        }

        [TestMethod]
        public void DetectsPublicClass()
        {
            new NamespaceElement("Namespace").Class("PublicClass");
        }
    }
}
