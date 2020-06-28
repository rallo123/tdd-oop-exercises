using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTools_Tests
{
    public static class TestHelper
    {
        public static void AssertThrowsExactException<T>(string exceptionMessage, Action action) where T : Exception
        {
            try
            {
                action();
                Assert.Fail($"Expected throw of {typeof(T).Name}");
            }
            catch (T exception)
            {
                if (!exception.Message.Equals(exceptionMessage))
                    Assert.Fail($"Expected message: {exceptionMessage}, Actual message: {exception.Message}");
            }
        }
    }
}
