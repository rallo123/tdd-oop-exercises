using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    // based on System.Reflection.FieldInfo
    public class FieldRequirements
    {
        public FieldRequirements(string name) : this(name, null)
        {
            Name = name;
        }

        public FieldRequirements(string name, Type fieldType)
        {
            Name = name;
            FieldType = fieldType;
        }

        public string Name { get; set; }
        public Type FieldType { get; set; }

        public bool? IsPrivate { get; set; }
        public bool? IsFamily { get; set; }
        public bool? IsPublic { get; set; }

        public bool? IsInitOnly { get; set; }
    }
}
