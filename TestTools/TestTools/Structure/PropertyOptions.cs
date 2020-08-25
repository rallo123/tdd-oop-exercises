using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class PropertyOptions
    {
        public PropertyOptions(string name)
        {
            Name = name;
            PropertyType = null;
        }

        public PropertyOptions(string name, Type propertyType)
        {
            Name = name;
            PropertyType = propertyType;
        }

        public string Name { get; set; }
        public Type PropertyType { get; set; }

        public MethodOptions GetMethod { get; set; }
        public MethodOptions SetMethod { get; set; }
    }
}
