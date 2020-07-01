using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class PropertyAccessor
    {
        public PropertyAccessor(AccessLevel? accessLevel = null)
        {
            AccessLevel = accessLevel;
        }

        public AccessLevel? AccessLevel { get; }
    }
}
