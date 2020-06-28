using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class StaticFieldDefinition : Definition, IStaticAccessible
    {
        public StaticFieldDefinition(FieldInfo fieldInfo)
        {
            Info = fieldInfo;
        }

        public FieldInfo Info { get; }
        public override string Name => Info.Name;

        public object Get()
        {
            throw new NotImplementedException();
        }

        public object Set(object value)
        {
            throw new NotImplementedException();
        }
    }
}
