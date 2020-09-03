using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Structure;

namespace TestTools_Tests.Structure
{
    [TestClass]
    public class FieldTests
    {
        private static FieldElement GetFieldDefinition() => new FieldElement(typeof(Class).GetField("PublicIntField"));
        
        [TestMethod]
        public void GetsValue()
        {
            Class @class = new Class(3);

            Assert.IsTrue(
                (int)GetFieldDefinition().Get(@class) == @class.PublicIntField
            );
        }

        [TestMethod]
        public void SetsValue()
        {
            Class @class = new Class(3);
            @class.PublicIntField = 5;

            Assert.IsTrue(
                (int)GetFieldDefinition().Get(@class) == @class.PublicIntField
            );
        }
    }
}
