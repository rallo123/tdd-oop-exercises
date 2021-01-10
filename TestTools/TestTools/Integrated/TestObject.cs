using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Integrated
{
    // Used to Arrange, Act and Assert on the reflected namespace
    public class TestObject<T>
    {
        internal TestObject() {}
    }

    // Used to Arrange, Act and Assert on the reflected namespace, but is transparent in errors
    public class AnonymousTestObject<T> : TestObject<T>
    {
        internal AnonymousTestObject() { }
    }

    /* 
     * NOTE Should only be used in situations, where you find yourself reimplementing 
     * or using solution code in tests, because it limits test validation
     */
    // Used to Arrange, Act and Assert on the reflected and current namespace
    public class DualTestObject<T> : TestObject<T>
    {
        internal DualTestObject() { }
    }

    /* 
     * NOTE Should only be used in situations, where you find yourself reimplementing 
     * or using solution code in tests, because it limits test validation
     */
    // Used to Arrange, Act and Assert on the reflected and current namespace, but is transparent in errors
    public class AnonymousDualTestObject<T> : DualTestObject<T>
    {
        internal AnonymousDualTestObject() { }
    }
}
