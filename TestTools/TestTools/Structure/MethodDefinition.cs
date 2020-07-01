using System;
using System.Reflection;
using TestTools.Helpers;
using TestTools.Structure;

namespace TestTools.Structure
{
    public class MethodDefinition : Definition, IInvocable
    {
        public MethodDefinition(MethodInfo methodInfo)
        {
            Info = methodInfo;
        }

        public MethodInfo Info { get; set; }
        public override string Name => Info.Name;

        public object Invoke(object instance, object[] arguments)
        {
            instance = GetValueOfPreviousDefinition(instance);
            return StructureHelper.Invoke(Info, instance, arguments);
        }
    }
}
