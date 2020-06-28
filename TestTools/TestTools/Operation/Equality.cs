using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using TestTools.Structure;

namespace TestTools.Operation
{
    public static class Equality
    {
        public static void Equals(object instance1, object instance2, string message = "{0} does not equal {1}")
        {
            if (!ObjectMethodRegistry.Equals(instance1, instance2))
            {
                string formatted1 = ObjectMethodRegistry.ToString(instance1);
                string formatted2 = ObjectMethodRegistry.ToString(instance2);

                Assert.Fail(String.Format(message, formatted1, formatted2));
            }
        }
    }
}
