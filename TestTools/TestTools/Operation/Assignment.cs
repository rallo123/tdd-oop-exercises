using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Structure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTools.Operation
{
    public static class Assignment
    {
        public static void Valid(object instance, IAccessible property, object value)
        {
            property.Set(instance, value);

            if (!object.Equals(value, property.Get(instance)))
                Assert.Fail("value was not set");
        }

        public static void Invalid<T>(object instance, IAccessible property, object value) where T : Exception
        {
            Assert.ThrowsException<T>(() => property.Set(instance, value));
        }

        public static void Ignored(object instance, IAccessible property, object value)
        {
            object originalValue = property.Get(instance);

            property.Set(instance, value);

            if (!object.Equals(originalValue, property.Get(instance)))
                Assert.Fail("value was not ignored");
        }
    }
}
