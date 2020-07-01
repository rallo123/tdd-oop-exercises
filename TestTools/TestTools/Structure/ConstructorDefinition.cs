using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class ConstructorDefinition : Definition, IStaticInvocable
    {
        public ConstructorDefinition(ConstructorInfo constructorInfo)
        {
            Info = constructorInfo;
        }

        public ConstructorInfo Info { get; set; }
        public override string Name => Info.Name;

        public object Invoke(params object[] parameters)
        {
            return StructureHelper.Invoke(Info, parameters);
        }
    }
}
