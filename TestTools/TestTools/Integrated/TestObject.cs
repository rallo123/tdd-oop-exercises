using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Integrated
{
    public class TestObject<T>
    {
        internal TestObject() {}
    }

    public class AnonymousTestObject<T> : TestObject<T>
    {

    }
}
