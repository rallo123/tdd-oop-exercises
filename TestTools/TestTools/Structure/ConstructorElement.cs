using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class ConstructorElement : Element, IFunc
    {
        public ConstructorElement(ConstructorInfo constructorInfo)
        {
            Info = constructorInfo;
        }

        public ConstructorInfo Info { get; set; }
        public override string Name => Info.Name;

        public object Invoke(params object[] parameters)
        {
            return ReflectionHelper.Invoke(Info, null, parameters);
        }
        public object Invoke(object instance, params object[] parameters)
        {
            return Invoke(parameters);
        }
    }
}
