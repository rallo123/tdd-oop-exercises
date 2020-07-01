using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IAccessible<TClass, TMember> : IAccessible
    {
        public TMember Get(TClass instance);
        public void Set(TClass instance, TMember value);
    }
}
