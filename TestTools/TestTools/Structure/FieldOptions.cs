using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class FieldOptions
    {
        public bool? IsPrivate { get; set; }
        public bool? IsFamily { get; set; }
        public bool? IsPublic { get; set; }

        public bool? IsInitOnly { get; set; }
    }
}
