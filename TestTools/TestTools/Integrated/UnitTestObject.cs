using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Integrated
{
    // Used to Arrange, Act and Assert on the reflected namespace
    public class UnitTestObject<T>
    {
        internal UnitTestObject() {}
    }

    // Used to Arrange, Act and Assert on the reflected namespace, but is transparent in errors
    public class AnonymousUnitTestObject<T> : UnitTestObject<T>
    {
        internal AnonymousUnitTestObject() { }
    }

    /* 
     * NOTE Should only be used in situations, where you find yourself reimplementing 
     * or using solution code in tests, because it limits test validation
     */
    // Used to Arrange, Act and Assert on the reflected and current namespace
    public class DualUnitTestObject<T> : UnitTestObject<T>
    {
        internal DualUnitTestObject() { }
    }

    /* 
     * NOTE Should only be used in situations, where you find yourself reimplementing 
     * or using solution code in tests, because it limits test validation
     */
    // Used to Arrange, Act and Assert on the reflected and current namespace, but is transparent in errors
    public class AnonymousUnitDualTestObject<T> : DualUnitTestObject<T>
    {
        internal AnonymousUnitDualTestObject() { }
    }
}
