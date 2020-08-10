using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public interface IStaticAccessible : IElement
    {
        object Get();
        object Set(object value);
    }
}
