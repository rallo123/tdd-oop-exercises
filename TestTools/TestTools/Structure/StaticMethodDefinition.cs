using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class StaticMethodDefinition : Definition, IStaticInvocable
    {
        public MethodInfo Info { get; }
        public override string Name => Info.Name;

        public StaticMethodDefinition(MethodInfo methodInfo)
        {
            Info = methodInfo;
        }

        public object Invoke(object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
