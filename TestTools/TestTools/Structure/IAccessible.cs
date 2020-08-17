using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public interface IAccessible : IElement
    {
        public object Get(object instance);
        public void Set(object instance, object value);
    }
}
