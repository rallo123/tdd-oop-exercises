using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

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

        public object Invoke(object[] parameters = null)
        {
            if (!Helper.IsEachArgumentOfType(Info.GetParameters(), parameters))
                throw new AssertFailedException("Wrong arguments");

            return Info.Invoke(parameters);
        }
    }
}
