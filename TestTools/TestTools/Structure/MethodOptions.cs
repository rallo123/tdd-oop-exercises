using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    // based upon System.Reflection.MethodInfo
    public class MethodOptions
    {
        public bool? IsPrivate { get; set; }
        public bool? IsFamily { get; set; }
        public bool? IsPublic { get; set; }

        public bool? IsVirtual { get; set; }

        public bool IsAbstract { get; set; }

        public Type DeclaringType { get; set; }
    }
}
