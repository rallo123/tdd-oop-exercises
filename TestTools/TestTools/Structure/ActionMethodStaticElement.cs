using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class ActionMethodStaticElement : Element, IStaticAction
    {
        public MethodInfo Info { get; }
        public override string Name => Info.Name;

        public ActionMethodStaticElement(MethodInfo methodInfo)
        {
            Info = methodInfo;
        }

        public void Invoke(object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
