using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Exceptions
{
    public class InvalidStructureException : AssertFailedException
    {
        public InvalidStructureException(string template, params object[] values)
            : base(string.Format(template, values))
        {
        }
    }
}
