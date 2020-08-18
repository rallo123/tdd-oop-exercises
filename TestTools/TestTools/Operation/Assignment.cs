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

        public static void Invalid<T>(object instance, IAccessible property, object value)
        {
            try
            {
                property.Set(instance, value);
                throw new AssertFailedException($"assignment did not throw {typeof(T).Name}");
            }
            catch(Exception ex)
            {
                Type actual = ex.InnerException.InnerException.GetType();
                Type expected = typeof(T);

                if (actual != expected)
                    throw new AssertFailedException($"assignment threw {actual.Name} instead of {expected.Name}");
            }
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
