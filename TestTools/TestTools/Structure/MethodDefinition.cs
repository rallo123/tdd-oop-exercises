using System;
using System.Reflection;
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

        public object Invoke(object instance, object[] parameters = null)
        {
            instance = GetValueOfPreviousDefinition(instance);
            
            Helper.CheckEachArgumentIsOfType(Info.GetParameters(), parameters);

            return Info.Invoke(instance, Helper.GetArguments(Info.GetParameters(), parameters));
        }
    }
}
