using System;
using System.Reflection;
using TestTools.Helpers;
using TestTools.Structure;

namespace TestTools.Structure
{
    public class ActionMethodElement : Element, IAction
    {
        public ActionMethodElement(MethodInfo methodInfo)
        {
            Info = methodInfo;
        }

        public MethodInfo Info { get; set; }
        public override string Name => Info.Name;

        public void Invoke(object instance, object[] arguments)
        {
            instance = GetValueOfPreviousElement(instance);
            ReflectionHelper.Invoke(Info, instance, arguments);
        }
    }
}
