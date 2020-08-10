using System;
using System.Reflection;
using TestTools.Helpers;
using TestTools.Structure;

namespace TestTools.Structure
{
    public class FuncMethodElement : Element, IFunc
    {
        public FuncMethodElement(MethodInfo methodInfo)
        {
            Info = methodInfo;
        }

        public MethodInfo Info { get; set; }
        public override string Name => Info.Name;

        public object Invoke(object instance, object[] arguments)
        {
            instance = GetValueOfPreviousElement(instance);
            return ReflectionHelper.Invoke(Info, instance, arguments);
        }
    }
}
