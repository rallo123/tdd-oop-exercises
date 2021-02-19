using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class InvalidStructureException : AssertFailedException
    {
        public InvalidStructureException(string message) : base(message)
        {

        }
    }
}
