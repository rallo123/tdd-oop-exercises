using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Structure;
using TestTools.Structure.Exceptions;

namespace TestTools_Tests.Structure
{
    [TestClass]
    public class NamespaceTests
    {

        [TestMethod]
        public void ThrowsOnEmptyNamespace()
        {
            Assert.ThrowsException<EmptyNamespaceException>(() => new NamespaceElement("EmptyNamespace"));
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
