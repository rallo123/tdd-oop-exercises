using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class PropertyRequirements
    {
        public PropertyRequirements()
        {
            Name = "";
            PropertyType = null;
        }

        public PropertyRequirements(string name)
        {
            Name = name;
            PropertyType = null;
        }

        public PropertyRequirements(string name, Type propertyType)
        {
            Name = name;
            PropertyType = propertyType;
        }

        public string Name { get; set; }
        public Type PropertyType { get; set; }

        public MethodRequirements GetMethod { get; set; }
        public MethodRequirements SetMethod { get; set; }
    }
}
