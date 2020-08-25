using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    // based upon System.Reflection.ParameterInfo
    public struct ParameterOptions
    {
        public ParameterOptions(Type type)
        {
            ParameterType = type;
            Name = null;
        }

        public string Name { get; set; }

        public Type ParameterType { get; set; }
    }
}
