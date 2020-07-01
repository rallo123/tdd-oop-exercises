using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IStaticAccessible<TMember> : IStaticAccessible
    {
        public new TMember Get();
        public void Set(TMember value);
    }
}
