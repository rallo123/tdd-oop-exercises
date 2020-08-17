using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class FuncMethodStaticElement : Element, IStaticFunc
    {
        public MethodInfo Info { get; }
        public override string Name => Info.Name;

        public FuncMethodStaticElement(MethodInfo methodInfo)
        {
            Info = methodInfo;
        }

        public object Invoke(object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
