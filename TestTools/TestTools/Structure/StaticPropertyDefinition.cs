using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class StaticPropertyDefinition : Definition, IStaticAccessible
    {
        public MethodInfo Info { get; }
        public override string Name => Info.Name;

        public object Get()
        {
            throw new NotImplementedException();
        }

        public object Set(object value)
        {
            throw new NotImplementedException();
        }
    }
}
