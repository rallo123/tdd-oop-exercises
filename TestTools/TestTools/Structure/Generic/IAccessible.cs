using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IAccessible<TRoot, TMember> : IAccessible
    {
        public TMember Get(TRoot instance);
        public void Set(TRoot instance, TMember value);
    }
}
